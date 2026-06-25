using UnityEngine;

public class GameManager : MonoBehaviour
{
    //どこからでもアクセスできるように。
    public static GameManager Instance { get; private set; }

    private void Awake()
    {
        // すでに存在している場合は自分自身を破棄する
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        // 自分自身をインスタンスとして登録
        Instance = this;

        // シーンをまたいでもオブジェクトを破壊しない
        DontDestroyOnLoad(gameObject);
    }
}
