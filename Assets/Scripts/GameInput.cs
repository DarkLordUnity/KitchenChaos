using UnityEngine;

public class GameInput : MonoBehaviour
{
    private PlayerInputActions playerInputActions; //Пишем переменную playerInputActions, которая будет хранить объект PlayerInputActions, который был создан автоматически при создании Input Actions, когда поставили галочку Generate C# Class, чтобы мы могли использовать его в коде
    private void Awake()
    {
        playerInputActions = new PlayerInputActions(); //Создаем объект PlayerInputActions, который был создан автоматически при создании Input Actions, когда поставили галочку Generate C# Class, чтобы мы могли использовать его в коде
        playerInputActions.Player.Enable(); //Включаем действия игрока, чтобы они могли быть использованы в коде
    }
    public Vector2 GetMovementVectorNormalized() //Для того, чтоб ыотдать данные скрипту Player, который будет использовать их для движения персонажа
    {
        Vector2 inputVector = playerInputActions.Player.Move.ReadValue<Vector2>(); //Получаем значение вектора движения из Input Actions, который был создан автоматически при создании Input Actions, когда поставили галочку Generate C# Class, чтобы мы могли использовать его в коде

        return inputVector.normalized;
    }
}
