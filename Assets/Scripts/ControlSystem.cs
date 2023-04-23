using UnityEngine;

public class ControlSystem : MonoBehaviour
{
	[Header("移動速度"), Range(0.5f, 99.9f)]
	public float moveSpeed = 10.5f;

	[Header("2D剛體")]
	public Rigidbody2D rig;

	[Header("跑步動畫")]
	public Animator ani;

	[Header("跑步參數")]
	public string parRun = "開關跑步";

	private void Awake()
	{
		// print($"{1 + 2}");
	}

	private void Start()
	{
		// print("<color=orange>開始事件</color>");
	}

	private void Update()
	{
		// print("<color=blue>更新事件</color>");
		float h = Input.GetAxis("Horizontal");
		float v = Input.GetAxis("Vertical");
		
		rig.velocity = new Vector3(h, v, 0) * moveSpeed;
	}
}
