
using UnityEngine;

public class repcolor : MonoBehaviour
{ 
    [Header("Настройки цвета")]
    public Color[] colors; // Массив цветов для перехода
public float speed = 1f; // Скорость смены цвета

private Renderer targetRenderer;
private int currentColorIndex = 0;
private int nextColorIndex;
private float t = 0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        targetRenderer = GetComponent<Renderer>();

        // Проверяем, есть ли рендерер
        if (targetRenderer == null)
        {
            Debug.LogError("Нет компонента Renderer на объекте!");
            enabled = false;
            return;
        }

        // Убеждаемся, что есть хотя бы 2 цвета
        if (colors == null || colors.Length < 2)
        {
            Debug.LogError("Добавьте минимум 2 цвета в массив!");
            enabled = false;
            return;
        }

        nextColorIndex = (currentColorIndex + 1) % colors.Length;
        targetRenderer.material.color = colors[currentColorIndex];

    }

    // Update is called once per frame
    void Update()
    {
        // Плавный переход между цветами
        t += Time.deltaTime * speed;
        targetRenderer.material.color = Color.Lerp(colors[currentColorIndex], colors[nextColorIndex], t);

        // Если переход завершен, выбираем следующий цвет
        if (t >= 1f)
        {
            t = 0f;
            currentColorIndex = nextColorIndex;
            nextColorIndex = (currentColorIndex + 1) % colors.Length;
        }

    }
}


