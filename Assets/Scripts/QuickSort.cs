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
        this.PopulateArray();
        stopWatch.Start();
        this.Quick_Sort(arr, 0, arr.Length - 1);
        stopWatch.Stop();
        System.TimeSpan ts = stopWatch.Elapsed;
        return (float)ts.TotalMilliseconds;
    }

    public void Quick_Sort(int[] arr, int left, int right) {
        if (left < right) {
            int pivot = Partition(arr, left, right);

            if (pivot > 1) {
                Quick_Sort(arr, left, pivot - 1);
            }
            if (pivot + 1 < right) {
                Quick_Sort(arr, pivot + 1, right);
            }
        }

    }

    private int Partition(int[] arr, int left, int right) {
        int pivot = arr[left];
        while (true) {

            while (arr[left] < pivot) {
                left++;
            }

            while (arr[right] > pivot) {
                right--;
            }

            if (left < right) {
                if (arr[left] == arr[right]) return right;

                int temp = arr[left];
                arr[left] = arr[right];
                arr[right] = temp;


            }
            else {
                return right;
            }
        }
    }


    private float calculateXPosition() {
        return (n * NAxis.transform.localScale.x) / maxN;
    }


    private float calculateYPosition() {
        return (miliseconds * TAxis.transform.localScale.y) / maxTime;
    }

}
