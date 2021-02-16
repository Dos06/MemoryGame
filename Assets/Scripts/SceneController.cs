using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    public const int rows = 2;
    public const int cols = 4;
    public const float offsetX = 4f;
    public const float offsetY = 5f;

    [SerializeField] private Card card;
    [SerializeField] private Sprite[] images;

    private void Start()
    {
        Vector3 startPosition = card.transform.position;
        int[] numbers = { 0, 0, 1, 1, 2, 2, 3, 3 };
        numbers = ShuffleArray(numbers);

        for (int i = 0; i < cols; i++)
        {
            for (int j = 0; j < rows; j++)
            {
                Card newCard;
                if (i == 0 && j == 0)
                {
                    newCard = card;
                }
                else
                {
                    newCard = Instantiate(card) as Card;
                }

                int index = j * cols + i;
                int id = numbers[index];
                newCard.ChangeSprite(id, images[id]);

                float positionX = (offsetX * i) + startPosition.x;
                float positionY = (offsetY * j) + startPosition.y;
                newCard.transform.position = new Vector3(positionX, positionY, startPosition.z);
            }
        }
    }

    private int[] ShuffleArray(int[] numbers)
    {
        int[] newArray = numbers.Clone() as int[];
        for (int i = 0; i < numbers.Length; i++)
        {
            int temp = newArray[i];
            int r = Random.Range(i, newArray.Length);
            newArray[i] = newArray[r];
            newArray[r] = temp;
        }
        return newArray;
    }

}
