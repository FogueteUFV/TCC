using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class Counter : MonoBehaviour
{
    private int numHealthy  = 300;
    private int numSick     = 0;
    private int numImune    = 0;

    private int simulationMaxTime = 2000;

    List<int> vH = new List<int>();
    List<int> vS = new List<int>();
    List<int> vI = new List<int>();

    public void reset(){
        
    }
     
    public void addHealthy() 
    {
        numImune -= 1;
        numHealthy += 1;
    }

    public void addSick()
    {
        numHealthy -= 1;
        numSick += 1;
    }

    public void addImune()
    {
        numSick -= 1;
        numImune += 1;
    }

    private void Start()
    {
        Directory.CreateDirectory("./Results");
    }

    private void FixedUpdate()
    {
        vH.Add(numHealthy);
        vS.Add(numSick);
        vI.Add(numImune);

        //Debug.Log(numHealthy + "," +
        //          numSick + "," +
        //          numImune + " - " + 
        //          (numHealthy+numSick+numImune));

        if (vH.Count == simulationMaxTime)
        {            
            TextWriter tw = new StreamWriter("Results/Simulation.csv");
            tw.WriteLine("Healthy,Sick,Imune");
            for (int i=0; i<vH.Count; i++)
            { 
                tw.Write(vH[i].ToString()+",");
                tw.Write(vS[i].ToString() + ",");
                tw.WriteLine(vI[i].ToString());
            }
            tw.Close();
            
            Debug.Log("Simulation finished");
            //Application.Quit();
        }
    }

}
