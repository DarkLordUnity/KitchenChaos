using UnityEngine;

public class GameInput : MonoBehaviour
{
    private void Awake()
    {
        //PlayerInputActions PlayerInputActions = new PlayerInputActions(); //Создаем объект PlayerInputActions, который был создан автоматически при создании Input Actions, когда поставили галочку Generate C# Class, чтобы мы могли использовать его в коде
        //PlayerInputActions.Player.Enable(); //Включаем действия игрока, чтобы они могли быть использованы в коде
    }
    public Vector2 GetMovementVectorNormalized()
    {
        Vector2 inputVector = new Vector2(0, 0);

        if (Input.GetKey(KeyCode.W))
        {
            inputVector.y = +1;
        }
        if (Input.GetKey(KeyCode.S))
        {
            inputVector.y = -1;
        }
        if (Input.GetKey(KeyCode.A))
        {
            inputVector.x = -1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            inputVector.x = +1;
        }

        return inputVector.normalized;
    }
}
