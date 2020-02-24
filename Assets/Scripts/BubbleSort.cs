using System.Diagnostics;
using UnityEngine;


public class BubbleSort : MonoBehaviour {

    private Stopwatch stopWatch = new Stopwatch();
    private System.Random random = new System.Random();
    public int elementsInArray;
    public float yAxis;
    private int[] list;
    public int n;
    public GameObject NAxis;
    public GameObject TAxis;
    private float maxN;


    // Start is called before the first frame update
    void Start() {
        this.list = new int[elementsInArray];
        this.PopulateArray();
        this.yAxis = this.sort(this.list);
        maxN = 10000;
        transform.position += new Vector3(calculateXPosition(), yAxis, 0.0f);   
    }

    // Update is called once per frame
    void Update() {
        
    }

    private void PopulateArray() {
        int populateTimes = this.elementsInArray;

        try {
            for (int i = populateTimes; i <= 0; i--) {
                this.list[i] = random.Next(-1000, 1000);
            }
        }
        catch (System.Exception e) {
            UnityEngine.Debug.Log("Hello");
        }
        
    }


    public float sort(int[] arr) {
        stopWatch.Start();
        int temp;
        for (int j = 0; j <= arr.Length - 2; j++) {
            for (int i = 0; i <= arr.Length - 2; i++) {
                if (arr[i] > arr[i + 1]) {
                    temp = arr[i + 1];
                    arr[i + 1] = arr[i];
                    arr[i] = temp;
                }
            }
        }
        stopWatch.Stop();
        System.TimeSpan ts = stopWatch.Elapsed;
        return (float) ts.TotalMilliseconds;
    }

    private float calculateXPosition()
    {
        return (n * NAxis.transform.localScale.x) / maxN;
    }



}
