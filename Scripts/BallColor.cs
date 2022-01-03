using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallColor : MonoBehaviour
{
    [SerializeField] private Material HealthyPerson;
    [SerializeField] private Material SickPerson;
    [SerializeField] private Material ImunizedPerson; //Antibodies
    [SerializeField] public bool sick = false;
    [SerializeField] public bool imunized = false;
    [SerializeField] public bool mask;    
    [SerializeField] private float timeSickInSeconds = 24f;
    [SerializeField] private float timeImunizedInSeconds = 60f;
    [SerializeField] public float maskPercentageNo = 100f;
    [SerializeField] public float maskPercentageHealthy = 70f;
    [SerializeField] public float maskPercentageSick = 25f;
    [SerializeField] public float maskPercentagePair = 10f;

    private MeshRenderer mr;

    private GameObject counter;
  
  

    float rand() {
        return Random.Range(0.0f, 100.0f);
    }

    // Start is called before the first frame update
    void Start()
    {
        if (counter == null){
            counter = GameObject.FindWithTag("Counter");
        }
        mr = GetComponent<MeshRenderer>();

        if (sick == true)
        {
            StartCoroutine(goRed());
        }

        if (imunized == true)
        {
            StartCoroutine(goPurple());
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (sick == false & imunized == false) { mr.material = HealthyPerson;}
        if (sick == true & imunized == false) { mr.material = SickPerson; }
        if (sick == false & imunized == true) { mr.material = ImunizedPerson; }
        if (sick == true & imunized == true) { mr.material = SickPerson; }
    }

     void OnCollisionEnter(Collision other)
    {
        //Testa se a colisão foi com uma bola
        if (other.transform.tag == "People")
        { 
            // Outro doente e eu saudável
            if ((other.gameObject.GetComponent<BallColor>().sick == true) & 
                ((transform.GetComponent<BallColor>().imunized == false) & 
                 (transform.GetComponent<BallColor>().sick == false)))
            {  
                //Fico doente
                if(other.gameObject.GetComponent<BallColor>().mask == false & transform.GetComponent<BallColor>().mask == false){
                       if (rand() <= maskPercentageNo){       
                        StartCoroutine(goRed());     
                    }    
                }
                if(other.gameObject.GetComponent<BallColor>().mask == true & transform.GetComponent<BallColor>().mask == false){
                    if(rand() <= maskPercentageSick){
                        StartCoroutine(goRed());
                    }
                }
                if(other.gameObject.GetComponent<BallColor>().mask == false & transform.GetComponent<BallColor>().mask == true){
                    if(rand() <= maskPercentageHealthy){
                        StartCoroutine(goRed());
                    }
                }
                if(other.gameObject.GetComponent<BallColor>().mask == true & transform.GetComponent<BallColor>().mask == true){
                    if(rand() <= maskPercentagePair){
                        StartCoroutine(goRed());
                    }
                }
                
      
            }
        }
    }

    IEnumerator goRed()
    {
        // Get sick
        transform.GetComponent<BallColor>().sick = true;
        counter.GetComponent<Counter>().addSick();
        yield return new WaitForSeconds(timeSickInSeconds);

        // Get imunized
        transform.GetComponent<BallColor>().sick = false;
        transform.GetComponent<BallColor>().imunized = true;
        counter.GetComponent<Counter>().addImune();
        yield return new WaitForSeconds(timeImunizedInSeconds);
        
        // Get healthy
        transform.GetComponent<BallColor>().imunized = false;
        counter.GetComponent<Counter>().addHealthy();
    }

    IEnumerator goPurple()
    {
        // Get imunized
        transform.GetComponent<BallColor>().imunized = true;
        counter.GetComponent<Counter>().addImune();

        yield return new WaitForSeconds(timeImunizedInSeconds);
        transform.GetComponent<BallColor>().imunized = false;
        counter.GetComponent<Counter>().addHealthy();
    }
}
