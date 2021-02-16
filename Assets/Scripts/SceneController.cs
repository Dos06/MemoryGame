using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public const int rows = 2;
    public const int cols = 4;
    public const float offsetX = 4f;
    public const float offsetY = 5f;

    [SerializeField] private Card mainCard;
    [SerializeField] private Sprite[] images;

    private void Start()
    {
        Vector3 startPosition = mainCard.transform.position;
        int[] numbers = { 0, 0, 1, 1, 2, 2, 3, 3 };
        numbers = ShuffleArray(numbers);

        for (int i = 0; i < cols; i++)
        {
            for (int j = 0; j < rows; j++)
            {
                Card newCard;
                if (i == 0 && j == 0)
                {
                    newCard = mainCard;
                }
                else
                {
                    newCard = Instantiate(mainCard) as Card;
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

    private Card _firstRevealed;
    private Card _secondRevealed;
    private int _score = 0;
    [SerializeField] private TextMesh scoreLabel;

    public bool canReveal
    {
        get { return _secondRevealed == null; }
    }

    public void CardRevealed(Card card)
    {
        if (_firstRevealed == null)
        {
            _firstRevealed = card;
        }
        else
        {
            _secondRevealed = card;
            StartCoroutine(ChechMatch());
        }
    }

    private IEnumerator ChechMatch()
    {
        if (_firstRevealed.id == _secondRevealed.id)
        {
            _score++;
            scoreLabel.text = "Score: " + _score;
        }
        else
        {
            yield return new WaitForSeconds(0.5f);
            _firstRevealed.Unreveal();
            _secondRevealed.Unreveal();
        }

        _firstRevealed = null;
        _secondRevealed = null;
    }

    public void Restart()
    {
        SceneManager.LoadScene("Scene");
    }

}
