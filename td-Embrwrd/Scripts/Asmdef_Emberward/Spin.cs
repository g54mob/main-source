using UnityEngine;

public class Spin : MonoBehaviour
{
	[Header("旋轉速度 (圈數/每秒)")]
	public Vector3 rotationsPerSecond;

	[Header("是否受遊戲速度影響 (除非特殊狀況不然都不勾)")]
	public bool ignoreTimeScale;

	[Header("是不是Local座標 (不勾的話就用世界座標)")]
	public bool isLocalCoordinate;

	private Rigidbody mRb;

	private Transform mTrans;

	private void Start()
	{
	}

	private void Update()
	{
	}

	private void FixedUpdate()
	{
	}

	public void ApplyDelta(float delta)
	{
	}
}
