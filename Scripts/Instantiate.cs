using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Linq;


public class Instantiate : MonoBehaviour
{
    int randMax = 300;
    int randMin = 0;
    int randVal;
    int lockPorc = 225;
    int dowlockPorc = 150;
    List<int> randNum = new List<int>();
    List<int> randmsk = new List<int>();
    public GameObject people;

    public bool inicio = false;
    //float xf = 20f;
    float xi = -20f;
    int PeopleAmount = 300;
    //float zf = -7.00f;
    float zi = 14.00f;
    public ToggleGroup toggleGp;
    
    public bool selec(int id){
        var tog = toggleGp.GetComponentsInChildren<Toggle>();
        if(tog[id].isOn == true){
            return true;
        }
        return false;
    }


    public GameObject [] deletes;
    //public Toggle GetSelectedToggle(){
    //Toggle[] togg=GetComponentsInChildren<Toggle>();
    //foreach (var tog in togg)
     //   if (tog.isOn) return tog;  
        //return null;           
    //}

    void instate(){
        int parcentMask = (int)(PeopleAmount * 0.7f/*CovidGui.pMask/100*/);
        int parcentSick = (int)(PeopleAmount * 0.04f/*CovidGui.iContaminated/100*/);
        int lockd = (int)(PeopleAmount * 0.75f);
        Debug.Log("porcentagem" + parcentSick);
        int colunas = (int)PeopleAmount / 10;
        int linhas = (int)PeopleAmount / 20;
        float distPessoasCol = 1.35f;//(Mathf.Abs(xi) + Mathf.Abs(xf)) / colunas;
        float distPessoasLin = 2.1f;//(Mathf.Abs(zi) + Mathf.Abs(zf)) / linhas;
        int z = 0;
        int x = 0;
        int y = 0;

        for (int i = 0; i < PeopleAmount; i++){

                float newX = xi + (x * distPessoasCol);
                float newZ = zi - (z * distPessoasLin);
                rand1(parcentMask);
                if(selec(0) == true){
                    rand(lockPorc);
                    if(y < parcentSick){ 
                        if(randmsk.Contains(i)){
                            if(randNum.Contains(i)){
                                people.GetComponent<BallColor>().mask = true;
                                people.GetComponent<BallBouncer>().atHome = true;
                                people.GetComponent<BallColor>().sick = true;
                                Instantiate(people, new Vector3(newX, 3.72f, newZ), Quaternion.identity);
                                y++;
                                x++;
                                }else{
                                    people.GetComponent<BallColor>().mask = true;
                                    people.GetComponent<BallBouncer>().atHome = false;
                                    people.GetComponent<BallColor>().sick = true;
                                    Instantiate(people, new Vector3(newX, 3.72f, newZ), Quaternion.identity);
                                    y++;
                                    x++;
                                }
                        }else{
                            if(randNum.Contains(i)){
                                people.GetComponent<BallColor>().mask = false;
                                people.GetComponent<BallBouncer>().atHome = true;
                                people.GetComponent<BallColor>().sick = true;
                                Instantiate(people, new Vector3(newX, 3.72f, newZ), Quaternion.identity);
                                y++;
                                x++;
                            }else{
                                people.GetComponent<BallColor>().mask = false;
                                people.GetComponent<BallBouncer>().atHome = false;
                                people.GetComponent<BallColor>().sick = true;
                                Instantiate(people, new Vector3(newX, 3.72f, newZ), Quaternion.identity);
                                y++;
                                x++;
                            }
                        }
                    }   
                    else{
                        if(randmsk.Contains(i)){
                            if(randNum.Contains(i)){
                                people.GetComponent<BallColor>().mask = true;
                                people.GetComponent<BallBouncer>().atHome = true;
                                people.GetComponent<BallColor>().sick = false;
                                Instantiate(people, new Vector3(newX, 3.72f, newZ), Quaternion.identity);
                                y++;
                                x++;
                            }else{
                                people.GetComponent<BallColor>().mask = true;
                                people.GetComponent<BallBouncer>().atHome = false;
                                people.GetComponent<BallColor>().sick = false;
                                Instantiate(people, new Vector3(newX, 3.72f, newZ), Quaternion.identity);
                                y++;
                                x++;
                            }
                            }else{
                                if(randNum.Contains(i)){
                                    people.GetComponent<BallColor>().mask = false;
                                    people.GetComponent<BallBouncer>().atHome = true;
                                    people.GetComponent<BallColor>().sick = false;
                                    Instantiate(people, new Vector3(newX, 3.72f, newZ), Quaternion.identity);
                                    y++;
                                    x++;
                                }else{
                                    people.GetComponent<BallColor>().mask = false;
                                    people.GetComponent<BallBouncer>().atHome = false;
                                    people.GetComponent<BallColor>().sick = false;
                                    Instantiate(people, new Vector3(newX, 3.72f, newZ), Quaternion.identity);
                                    y++;
                                    x++;
                                }
                            }
                    }
                    if (x > colunas - 1)
                    {
                        x = 0;
                        z++;
                    }
                }
                /*if(selec(1) == true){
                    rand1(dowlockPorc);
                    if(y < parcentSick){ 
                        if(randmsk.Contains(i)){
                            if(randNum.Contains(i)){
                                people.GetComponent<BallColor>().mask = true;
                                people.GetComponent<BallBouncer>().atHome = true;
                                people.GetComponent<BallColor>().sick = true;
                                Instantiate(people, new Vector3(newX, 3.72f, newZ), Quaternion.identity);
                                y++;
                                x++;
                                }else{
                                    people.GetComponent<BallColor>().mask = true;
                                    people.GetComponent<BallBouncer>().atHome = false;
                                    people.GetComponent<BallColor>().sick = true;
                                    Instantiate(people, new Vector3(newX, 3.72f, newZ), Quaternion.identity);
                                    y++;
                                    x++;
                                }
                        }else{
                            if(randNum.Contains(i)){
                                people.GetComponent<BallColor>().mask = false;
                                people.GetComponent<BallBouncer>().atHome = true;
                                people.GetComponent<BallColor>().sick = true;
                                Instantiate(people, new Vector3(newX, 3.72f, newZ), Quaternion.identity);
                                y++;
                                x++;
                            }else{
                                people.GetComponent<BallColor>().mask = false;
                                people.GetComponent<BallBouncer>().atHome = false;
                                people.GetComponent<BallColor>().sick = true;
                                Instantiate(people, new Vector3(newX, 3.72f, newZ), Quaternion.identity);
                                y++;
                                x++;
                            }
                        }
                    }
                    else{
                        if(randmsk.Contains(i)){
                            if(randNum.Contains(i)){
                                people.GetComponent<BallColor>().mask = true;
                                people.GetComponent<BallBouncer>().atHome = true;
                                people.GetComponent<BallColor>().sick = false;
                                Instantiate(people, new Vector3(newX, 3.72f, newZ), Quaternion.identity);
                                y++;
                                x++;
                            }else{
                                people.GetComponent<BallColor>().mask = true;
                                people.GetComponent<BallBouncer>().atHome = false;
                                people.GetComponent<BallColor>().sick = false;
                                Instantiate(people, new Vector3(newX, 3.72f, newZ), Quaternion.identity);
                                y++;
                                x++;
                            }
                            }else{
                                if(randNum.Contains(i)){
                                    people.GetComponent<BallColor>().mask = false;
                                    people.GetComponent<BallBouncer>().atHome = true;
                                    people.GetComponent<BallColor>().sick = false;
                                    Instantiate(people, new Vector3(newX, 3.72f, newZ), Quaternion.identity);
                                    y++;
                                    x++;
                                }else{
                                    people.GetComponent<BallColor>().mask = false;
                                    people.GetComponent<BallBouncer>().atHome = false;
                                    people.GetComponent<BallColor>().sick = false;
                                    Instantiate(people, new Vector3(newX, 3.72f, newZ), Quaternion.identity);
                                    y++;
                                    x++;
                                }
                            }
                    }
                    if (x > colunas - 1)
                    {
                        x = 0;
                        z++;
                    }
                }*/
    
        }
    }

   // public Toggle lockdown{
   //     get{ return toggleGp.ActiveToggles().FirstOrDefault();
       // }
   // } 

    public void rand(int n){
        while(randNum.Count!=n){
            int sort = Random.Range(randMax,randMin);
            if(!randNum.Contains(sort)){
                randNum.Add(sort);
            }
        }
    }
    public void rand1(int n){
        while(randmsk.Count!=n){
            int sort = Random.Range(randMax,randMin);
            if(!randmsk.Contains(sort)){
                randmsk.Add(sort);
            }
        }
    }

public void del(){
    deletes = GameObject.FindGameObjectsWithTag("People");
    foreach(GameObject dele in deletes){
        GameObject.Destroy(dele);
    }
}

public void result(){
    File.Delete("./Results/Simulation.csv");
}


public void botao(){
    del();
    result();
    instate();
}

void Start(){
    toggleGp = GetComponent<ToggleGroup>();
   // Debug.Log(lockdown.name);
    if(inicio==false){
        instate();  
    }else{
        botao();    
            // zerar contador
    }
        /*int parcentMask = (int)(PeopleAmount * maskPorc);
        int parcentSick = (int)(PeopleAmount * 0.10f);
        int lockd = (int)(PeopleAmount * 0.75f);
        Debug.Log("porcentagem" + parcentSick);
        int colunas = (int)PeopleAmount / 10;
        int linhas = (int)PeopleAmount / 20;
        float distPessoasCol = (Mathf.Abs(xi) + Mathf.Abs(xf)) / colunas;
        float distPessoasLin = (Mathf.Abs(zi) + Mathf.Abs(zf)) / linhas;
        int z = 0;
        int x = 0;
        int y = 0;
        int w = 0;
        if (lockdown.isOn == true)
        {
            for (int i = 0; i < PeopleAmount; i++)
            {

                float newX = xi + (x * distPessoasCol);
                float newZ = zi - (z * distPessoasLin);
                if (w < lockd){ 
                    if (y < parcentSick)
                    {
                        sickPeople.GetComponent<BallBouncer>().atHome = true;
                        Instantiate(sickPeople, new Vector3(newX, 3.72f, newZ), Quaternion.identity);
                        y++;
                        x++;
                        w++;
                    }
                    else
                    {
                        sickPeople.GetComponent<BallBouncer>().atHome = true;
                        Instantiate(people, new Vector3(newX, 3.72f, newZ), Quaternion.identity);
                        x++;
                        w++;
                    }
                    if (x > colunas - 1)
                    {
                        x = 0;
                        z++;
                    }
               }
               else{

               }
            }
        }
        else
        {
            for (int i = 0; i < PeopleAmount; i++)
            {

                float newX = xi + (x * distPessoasCol);
                float newZ = zi - (z * distPessoasLin);
                
                if (y < parcentSick)
                {
                    Instantiate(sickPeople, new Vector3(newX, 3.72f, newZ), Quaternion.identity);
                    y++;
                    x++;
                }
                else
                {
                    Instantiate(people, new Vector3(newX, 3.72f, newZ), Quaternion.identity);
                    x++;
                }
                if (x > colunas - 1)
                {
                    x = 0;
                    z++;
                }
            }
        }*/
    }
    void Update()
    {

    }

}
