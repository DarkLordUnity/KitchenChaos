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

        float playerRadius = 0.7f; //Размер персонажа, чтобы персонаж не проходил сквозь стены, так как у нас нет коллайдера на персонаже, а есть только коллайдер на стенах, поэтому мы проверяем, есть ли препятствие перед персонажем, если есть, то персонаж не будет двигаться в этом направлении
        float playerHeight = 2f; //Высота персонажа, чтобы персонаж не проходил сквозь стены, так как у нас нет коллайдера на персонаже, а есть только коллайдер на стенах, поэтому мы проверяем, есть ли препятствие перед персонажем, если есть, то персонаж не будет двигаться в этом направлении
        float moveDistance = moveSpeed * Time.deltaTime; //Шаг, на который персонаж будет двигаться в этом кадре, чтобы персонаж не проходил сквозь стены, так как у нас нет коллайдера на персонаже, а есть только коллайдер на стенах, поэтому мы проверяем, есть ли препятствие перед персонажем, если есть, то персонаж не будет двигаться в этом направлении
        bool canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDir, moveDistance); //Проверяем, есть ли препятствие перед персонажем !true, если есть, то персонаж не будет двигаться в этом направлении, так как получим false

        // If we cannot move in the desired direction, attempt to move only along the X or Z axis
        if (!canMove)
        {
            // Cannot move towards moveDir

            // Attempt only X movement
            Vector3 moveDirX = new Vector3(moveDir.x, 0, 0).normalized;
            canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDirX, moveDistance);

            if (canMove)
            {
                // Can move only on the X
                moveDir = moveDirX;
            }
            else
            {
                // Cannot move only on the X

                // Attempt only Z movement
                Vector3 moveDirZ = new Vector3(0, 0, moveDir.z).normalized;
                canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDirZ, moveDistance);

                if (canMove)
                {
                    // Can move only on the Z
                    moveDir = moveDirZ;
                }
                else
                {
                    // Cannot move in any direction
                }
            }
        }



        if (canMove) //Если есть препятствие перед персонажем, то персонаж не будет двигаться в этом направлении, а если нет препятствия, то персонаж будет двигаться в этом направлении
        {
            transform.position += moveDir * moveDistance;
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
