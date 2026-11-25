using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private const string IS_WALKING = "IsWalking";


    [SerializeField] private Player player; //Ссылка на скрипт Player, чтобы получить доступ к переменной isWalking, тут можно было ничего не писать, а в Awake() написать  .GetComponent<Player>(), но так будет лучше, так как мы можем перетащить ссылку в инспекторе, а не искать компонент в коде


    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        animator.SetBool(IS_WALKING, player.IsWalking());
    }
}
