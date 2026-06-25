using Unity.VisualScripting;
using UnityEngine;

public class GoalObject : MonoBehaviour
{
    //自身のTransform
    private Transform myTrans;
    //のposition
    private Vector3 myPos;
    //周期
    private const float cycleTime = 3.0f;
    //幅
    private const float moveWidth = 0.25f;

    void Start()
    {
        //Init
        myTrans = this.GetComponent<Transform>();
        myPos = transform.position;
    }

    void Update()
    {
        myTrans.position =  new Vector3(myPos.x, myPos.y + moveWidth * Mathf.Sin(Time.time*cycleTime), myPos.z);
    }

    private void OnTriggerEnter(Collider collider)
    {
        if(collider.tag == "Player")
            Debug.Log("ゴール！");
    }
}
