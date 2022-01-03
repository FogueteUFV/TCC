using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Serialization;
using TMPro;
using UnityEngine.SceneManagement;

public class CovidGui : MonoBehaviour
{
    [SerializeField] public Slider SliderPmask;
    [SerializeField] public Slider SliderIcontaminated;
    [SerializeField] public TMP_Text PmaskText;
    [SerializeField] public TMP_Text IcontaminatedText;
    public static float pMask;
    public static float iContaminated; 



    // Start is called before the first frame update
    void Start()
    {
        
        //pMask = ball.maskPorc;
        //iContaminated = ball.sickPorc;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Up(){
        //Destroy(inst.people.gameObject);
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void OnPMask(){
        pMask = (float)SliderPmask.value;
        PmaskText.text = pMask.ToString("N1");
        //Instantiate.maskPorc = pMask/100;
        //insta.GetComponent<Instantiate>().maskPorc = pMask/100;
        
    }

    public void OnIContaminated(){
        iContaminated = SliderIcontaminated.value;
        IcontaminatedText.text = iContaminated.ToString("N1"); 
        //Instantiate.sickPork = iContaminated/100;
        //insta.GetComponent<Instantiate>().sickPorc = iContaminated/100;
    }
    //Debug.Log("mask:"+ pMask);  
}
