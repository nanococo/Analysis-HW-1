using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleSort : MonoBehaviour
{

    public int n;
    public GameObject NAxis;
    public GameObject TAxis;
    private float maxN;
  
    

    // Start is called before the first frame update
    void Start()
    {
        maxN = 10000;
        transform.position += new Vector3(calculateXPosition(), 7.0f, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void sort(int[] arr)
    {

        int temp;
        for (int j = 0; j <= arr.Length - 2; j++)
        {
            for (int i = 0; i <= arr.Length - 2; i++)
            {
                if (arr[i] > arr[i + 1])
                {
                    temp = arr[i + 1];
                    arr[i + 1] = arr[i];
                    arr[i] = temp;
                }
            }
        }
    }

    private float calculateXPosition()
    {
        return (n * NAxis.transform.localScale.x) / maxN;
    }



}
