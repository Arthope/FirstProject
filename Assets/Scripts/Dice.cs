using System.Collections;
using UnityEngine;

public class Dice : MonoBehaviour
{

    // Массив спрайтов сторон игральных костей для загрузки из папки Resources
    private Sprite[] diceSides;

    //Ссылка на средство визуализации спрайтов для изменения спрайтов
    private SpriteRenderer rend;

    public static int NumberOfCoin = 0;

    // Используйте это для инициализации
    private void Start()
    {

        // Назначить компонент визуализатора
        rend = GetComponent<SpriteRenderer>();

        // Загрузите спрайты сторон игральных костей в массив из подпапки DiceSides папки Resources.
        diceSides = Resources.LoadAll<Sprite>("DiceSides/");
    }

    // Если щелкнуть левой кнопкой мыши по кубику, запустится сопрограмма RollTheDice.
    public void MakeRandomNumber()
    {
        StartCoroutine("RollTheDice");
    }

    // Корутина, которая бросает кости
    private IEnumerator RollTheDice()
    {
        //Переменная, содержащая случайный номер стороны кости.
        // Его нужно присвоить. пусть изначально 0
        int randomDiceSide = 0;

        // Конечная сторона или значение, которое читает кости в конце сопрограммы
        int finalSide = 0;

        //Цикл для случайного переключения сторон кубиков 
        // до того, как появится последняя сторона. 20 итераций здесь.
        for (int i = 0; i <= 20; i++)
        {
            // Подберите случайное значение от 0 до 5 (Все включено)
            randomDiceSide = Random.Range(0, 5);

            // Установите спрайт на верхнюю грань кости из массива в соответствии со случайным значением
            rend.sprite = diceSides[randomDiceSide];

            //Пауза перед следующей итерацией
            yield return new WaitForSeconds(0.05f);
        }

        // Назначение конечной стороны, чтобы вы могли использовать это значение позже в своей игре.
        // для движения игрока например
        finalSide = randomDiceSide + 1;
        NumberOfCoin = finalSide;
    }
}
