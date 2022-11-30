using System.Collections;
using System.Threading;
using System.Collections.Generic;
using System;
using UnityEngine.UI;
using Unity.Jobs;
using UnityEngine;


/*public struct CPUTest : IJob
{
    //int iterationCap = 100000;
    private double CPUPiTest(int iterations)
    {
        double pi = 0;
        int n = 0;

        for(int i = 0; i < iterations; i+=2)
        {
            pi += Math.Pow(-1, n+1) * (4 / iterations);
            n++;
        }
        return pi;
    }
    public void Execute()
    {
        //int iterationCap = 100;
        //CPUPiTest(100000000);

        
    }
}*/


public class PerformanceStressTest : MonoBehaviour
{
    int threads = 0;
    List<Thread> threadList;
    bool threadOverride = false;
    public Slider threadSlider;
    public GameObject gpuRenderObjects;

    Resolution screenRes;
    // Start is called before the first frame update
    void Start()
    {
        threads = SystemInfo.processorCount;
        Debug.Log("Working with: " + threads + " threads");
        threadList = new List<Thread>();
    }

    public void CPUTest()
    {
        long count = 0;
        while (true)
        {
            count++;
            if (count > 10000000)
            {
                count = 0;
            }

        }
    }
    public void StartCPUTest()
    {
        int targetThreads = threads;
        if(!threadOverride)
        {
            targetThreads = (int)threadSlider.value;
        }

        Debug.Log("Starting: " + targetThreads + " threads");
        for (int i = 0; i < targetThreads; i++)
        {
            threadList.Add(new Thread(new ThreadStart(CPUTest)));
            threadList[i].Start();
        }
    }
    
    public void StopCPUTest()
    {
        Debug.Log("Stopping: " + threadList.Count + " threads");
        for (int i = 0; i < threadList.Count; i++)
        {

            threadList[i].Abort();
        }
        threadList.Clear();
    }

    public void ToggleOverride()
    {
        threadOverride = !threadOverride;
    }

    public void StartGPUTest()
    {
        Debug.Log("Starting GPU Stress Test");
        gpuRenderObjects.SetActive(true);
    }

    public void StopGPUTest()
    {
        Debug.Log("Stopping GPU Stress Test");
        gpuRenderObjects.SetActive(false);
    }

}
