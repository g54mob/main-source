using UnityEngine;

public class Func_PerlinNoiseFloat : MonoBehaviour
{
	[SerializeField]
	private bool isLocalPosition;

	[SerializeField]
	private float offsetSpeedMultiplier;

	[SerializeField]
	private float offsetMultiplier;

	[SerializeField]
	private float rotateSpeedMultiplier;

	[SerializeField]
	private float rotationAngle;

	[SerializeField]
	private float perlinOffsetMultiplier;

	[SerializeField]
	private float randomPerlinOffsetMultiplier;

	[Header("是否使用unscaledTime")]
	[SerializeField]
	private bool useUnscaledTime;

	private float perlinOffset;

	private Vector3 startPos;

	private Quaternion startRot;

	private float externalSpeedMultiplier;

	private float timer;

	private void Start()
	{
	}

	private void Update()
	{
	}

	public void ResetStartPos()
	{
	}

	public void SetExternalSpeedMultiplier(float value)
	{
	}
}
