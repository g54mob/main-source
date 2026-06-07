using UnityEngine;

public class WindTurbine : MonoBehaviour
{
	public Transform Housing;

	public Transform Blades;

	public float SpeedFactor = 1f;

	public float RotSpeed = 1f;

	private float Rot;

	private void Start()
	{
		Rot = Random.Range(0f, 360f);
		Blades.localRotation = Quaternion.Euler(0f, Rot, 0f);
	}

	private void FixedUpdate()
	{
		if (GameSettings.GameSpeed > 0f)
		{
			float num = Time.deltaTime * GameSettings.GameSpeed;
			Vector2 windiness = TimeOfDay.Instance.Windiness;
			float magnitude = windiness.magnitude;
			Housing.rotation = Quaternion.RotateTowards(Housing.rotation, Quaternion.Euler(-90f, 0f, (0f - Mathf.Atan2(windiness.x / magnitude, windiness.y / magnitude)) * 57.29578f), RotSpeed * num);
			Rot += magnitude.MapRange(0.01f, 0.02f, 0f, 1f, true) * SpeedFactor * num;
			if (Rot > 360f)
			{
				Rot -= 360f;
			}
			Blades.localRotation = Quaternion.Euler(0f, Rot, 0f);
		}
	}
}
