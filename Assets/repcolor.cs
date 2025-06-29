
using UnityEngine;

public class repcolor : MonoBehaviour
{ 
    [Header("��������� �����")]
    public Color[] colors; // ������ ������ ��� ��������
public float speed = 1f; // �������� ����� �����

private Renderer targetRenderer;
private int currentColorIndex = 0;
private int nextColorIndex;
private float t = 0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        targetRenderer = GetComponent<Renderer>();

        // ���������, ���� �� ��������
        if (targetRenderer == null)
        {
            Debug.LogError("��� ���������� Renderer �� �������!");
            enabled = false;
            return;
        }

        // ����������, ��� ���� ���� �� 2 �����
        if (colors == null || colors.Length < 2)
        {
            Debug.LogError("�������� ������� 2 ����� � ������!");
            enabled = false;
            return;
        }

        nextColorIndex = (currentColorIndex + 1) % colors.Length;
        targetRenderer.material.color = colors[currentColorIndex];

    }

    // Update is called once per frame
    void Update()
    {
        // ������� ������� ����� �������
        t += Time.deltaTime * speed;
        targetRenderer.material.color = Color.Lerp(colors[currentColorIndex], colors[nextColorIndex], t);

        // ���� ������� ��������, �������� ��������� ����
        if (t >= 1f)
        {
            t = 0f;
            currentColorIndex = nextColorIndex;
            nextColorIndex = (currentColorIndex + 1) % colors.Length;
        }

    }
}


