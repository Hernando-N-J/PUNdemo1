using UnityEngine;

public class TestSuma : MonoBehaviour
{
    private int a = 3, b = 5;

    // Start is called before the first frame update
    private void Start()
    {





    }

    private void mensajes()
    {
        string suma1 = "suma: " + suma(a, b).ToString();
        string resta1 = "resta: " + resta(a, b).ToString();
        string multiplicacion1 = "multiplicacion: " + multiplicacion(a, b).ToString();
        string division1 = "division: " + division(a, b).ToString();
    }

    private int suma(int a, int b)
    {
        int c = a + b;
        return c;
    }

    private int resta(int a, int b)
    {
        int c = b - a;
        return c;
    }

    private float multiplicacion(int a, int b)
    {
        int c = a * b;
        return c;
    }


    private float division(int a, int b)
    {
        int c = a / b;
        return c;
    }

}
