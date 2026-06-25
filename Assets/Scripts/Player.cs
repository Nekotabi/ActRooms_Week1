using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    private PlayerAction input;
    private Rigidbody plRigid;
    private Transform myTrans;
    private Vector3 direct;
    private Vector3 origin;
    [SerializeField] LayerMask groundMask;
    private const float moveSpeed = 5f;
    private const float jumpingPower = 5f;
    private const float deadLineSpeed = -40.0f;
    [SerializeField] private bool isGround;

    private void Awake()
    {
        //変数初期化
        input = new PlayerAction();
        plRigid = this.gameObject.GetComponent<Rigidbody>();
        myTrans = this.transform.GetComponent<Transform>();

        if (input == null)
            Debug.Log("inputが見つかりません");
        if (plRigid == null)
            Debug.Log("plRigidが見つかりません");

        plRigid.useGravity = true;
        direct = Vector3.zero;
        isGround = true;
    }

    private void OnEnable()
    {
        input.Enable();
        input.Player.Move.performed += OnMove;
        input.Player.Move.canceled += OnMove;
        input.Player.Jump.performed += OnJump;
    }

    private void OnDisable()
    {
        input.Disable();
        input.Player.Move.performed -= OnMove;
        input.Player.Move.canceled -= OnMove;
        input.Player.Jump.performed -= OnJump;
    }

    private void FixedUpdate()
    {
        plRigid.linearVelocity = new Vector3(direct.x * moveSpeed, plRigid.linearVelocity.y, direct.z * moveSpeed);

        Vector3 origin = transform.position + Vector3.up * 0.1f;

        isGround = Physics.CheckSphere(origin + Vector3.down * 0.9f, 0.3f, groundMask);

        if(plRigid.linearVelocity.y < deadLineSpeed)
            Debug.Log("ご臨の終でございやしたねwww");
    }

    private void OnMove(InputAction.CallbackContext _callback)
    {
        Vector2 entered = _callback.ReadValue<Vector2>();
        direct = new Vector3(entered.x, 0f, entered.y);
    }

    private void OnJump(InputAction.CallbackContext _callback)
    {
        if (!isGround)
            return;
        plRigid.linearVelocity = new Vector3(plRigid.linearVelocity.x, jumpingPower, plRigid.linearVelocity.z);
    }
}
