using UnityEngine;

public class MainTitleCameraShake : MonoBehaviour
{
	[Header("흔들림 설정")]
	public float wobbleSpeed = 20f;

	public float amountX = 0.05f;

	public float amountY = 0.05f;

	private Vector3 initialLocalPos;

	private void Start()
	{
		initialLocalPos = base.transform.localPosition;
	}

	private void Update()
	{
		float x = Mathf.Sin(Time.time * wobbleSpeed) * amountX;
		float y = Mathf.Cos(Time.time * wobbleSpeed * 1.3f) * amountY;
		base.transform.localPosition = initialLocalPos + new Vector3(x, y, 0f);
	}
}
