using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 7f;

    [SerializeField] private GameInput gameInput; //Ссылка на скрипт GameInput, чтобы получить доступ к переменной inputVector, тут можно было ничего не писать, а в Awake() написать  .GetComponent<GameInput>(), но так будет лучше, так как мы можем перетащить ссылку в инспекторе, а не искать компонент в коде

    private bool isWalking; //Переменная Анимации для отслеживания состояния движения персонажа

    private void Update()
    {
        Vector2 inputVector = gameInput.GetMovementVectorNormalized();//Получаем данные, вектор движения из скрипта GameInput 

        Vector3 moveDir = new Vector3(inputVector.x, 0f, inputVector.y);
        transform.position += moveDir * moveSpeed * Time.deltaTime;

        isWalking = moveDir != Vector3.zero; //Анимация ходьбы будет проигрываться только когда персонаж движется

        float rotateSpeed = 10f;
        transform.forward = Vector3.Slerp(transform.forward, moveDir, Time.deltaTime * rotateSpeed);

    }

    public bool IsWalking()
    {
        return isWalking; //Метод для получения значения переменной isWalking, чтобы другие скрипты могли узнать, движется ли персонаж
    }

}
