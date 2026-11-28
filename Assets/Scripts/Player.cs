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

        float PlaySize = 0.7f; //Размер персонажа, чтобы персонаж не проходил сквозь стены, так как у нас нет коллайдера на персонаже, а есть только коллайдер на стенах, поэтому мы проверяем, есть ли препятствие перед персонажем, если есть, то персонаж не будет двигаться в этом направлении
        bool canMove = !Physics.Raycast(transform.position, moveDir, PlaySize); //Проверяем, есть ли препятствие перед персонажем !true, если есть, то персонаж не будет двигаться в этом направлении, так как получим false
        if (canMove) //Если есть препятствие перед персонажем, то персонаж не будет двигаться в этом направлении, а если нет препятствия, то персонаж будет двигаться в этом направлении
        {
            transform.position += moveDir * moveSpeed * Time.deltaTime;
        }

        isWalking = moveDir != Vector3.zero; //Анимация ходьбы будет проигрываться только когда персонаж движется

        float rotateSpeed = 10f;
        transform.forward = Vector3.Slerp(transform.forward, moveDir, Time.deltaTime * rotateSpeed);

    }

    public bool IsWalking()
    {
        return isWalking; //Метод для получения значения переменной isWalking, чтобы другие скрипты могли узнать, движется ли персонаж
    }

}
