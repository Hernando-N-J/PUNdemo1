using UnityEngine;

public class TestSuma : MonoBehaviour
{

    int a = 3, b = 5;

    // Start is called before the first frame update
    void Start()
    {





    }
    void mensajes()
    {
        string suma1 = "suma: " + suma(a, b).ToString();
        string resta1 = "resta: " + resta(a, b).ToString();
        string multiplicacion1 = "multiplicacion: " + multiplicacion(a, b).ToString();
        string division1 = "division: " + division(a, b).ToString();
    }
    int suma(int a, int b)
    {
        int c = a + b;
        return c;
    }

    int resta(int a, int b)
    {
        int c = b - a;
        return c;
    }

    float multiplicacion(int a, int b)
    {
        int c = a * b;
        return c;
    }


    float division(int a, int b)
    {
        int c = a / b;
        return c;
    }

}
