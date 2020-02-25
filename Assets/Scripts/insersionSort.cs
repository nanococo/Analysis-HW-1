using System.Diagnostics;
using UnityEngine;

public class QuickSort : MonoBehaviour {


    private Stopwatch stopWatch = new Stopwatch();
    private System.Random random = new System.Random();
    public float miliseconds;
    private int[] list;
    public int n;
    public GameObject NAxis;
    public GameObject TAxis;
    private float maxN;
    private float maxTime;


    // Start is called before the first frame update
    void Start() {
        this.list = new int[n];
        this.PopulateArray();

        maxN = 10000;
        maxTime = 1000;
        this.miliseconds = this.QuickSortIntermediary(this.list);

        transform.position += new Vector3(calculateXPosition(), calculateYPosition(), 0.0f);
    }

    // Update is called once per frame
    void Update() {

    }

    private void PopulateArray() {
        int populateTimes = this.n;

        try {
            for (int i = populateTimes; i <= 0; i--) {
                this.list[i] = random.Next(-1000, 1000);
            }
        }
        catch (System.Exception e) {
            UnityEngine.Debug.Log("Hello");
        }

    }

    public float QuickSortIntermediary(int[] arr) {
        UnityEngine.Debug.Log(arr.Length);
        this.PopulateArray();
        stopWatch.Start();
        this.InsertionSort(arr);
        stopWatch.Stop();
        System.TimeSpan ts = stopWatch.Elapsed;
        return (float)ts.TotalMilliseconds;
    }

    private int[] InsertionSort(int[] inputArray) {
        for (int i = 0; i < inputArray.Length - 1; i++) {
            for (int j = i + 1; j > 0; j--) {
                if (inputArray[j - 1] > inputArray[j]) {
                    int temp = inputArray[j - 1];
                    inputArray[j - 1] = inputArray[j];
                    inputArray[j] = temp;
                }
            }
        }
        return inputArray;
    }


    private float calculateXPosition() {
        return (n * NAxis.transform.localScale.x) / maxN;
    }


    private float calculateYPosition() {
        return (miliseconds * TAxis.transform.localScale.y) / maxTime;
    }

}
