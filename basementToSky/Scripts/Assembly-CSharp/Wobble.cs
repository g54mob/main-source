using UnityEngine;

public class Wobble : MonoBehaviour
{
	public float MaxWobble = 0.03f;

	public float WobbleSpeed = 5f;

	public float RecoveryRate = 1f;

	private Renderer rend;

	private Vector3 prevPos;

	private Vector3 prevRot;

	private float wobbleAmountToAddX;

	private float wobbleAmountToAddZ;

	private void Start()
	{
		rend = GetComponent<Renderer>();
	}

	private void Update()
	{
		wobbleAmountToAddX = Mathf.Lerp(wobbleAmountToAddX, 0f, Time.deltaTime * RecoveryRate);
		wobbleAmountToAddZ = Mathf.Lerp(wobbleAmountToAddZ, 0f, Time.deltaTime * RecoveryRate);
		float value = wobbleAmountToAddX * Mathf.Sin(WobbleSpeed * Time.time);
		float value2 = wobbleAmountToAddZ * Mathf.Sin(WobbleSpeed * Time.time);
		rend.material.SetFloat("_WobbleX", value);
		rend.material.SetFloat("_WobbleZ", value2);
		Vector3 vector = (prevPos - base.transform.position) / Time.deltaTime;
		Vector3 vector2 = base.transform.rotation.eulerAngles - prevRot;
		wobbleAmountToAddX += Mathf.Clamp((vector.x + vector2.z * 0.2f) * MaxWobble, 0f - MaxWobble, MaxWobble);
		wobbleAmountToAddZ += Mathf.Clamp((vector.z + vector2.x * 0.2f) * MaxWobble, 0f - MaxWobble, MaxWobble);
		prevPos = base.transform.position;
		prevRot = base.transform.rotation.eulerAngles;
	}
}
