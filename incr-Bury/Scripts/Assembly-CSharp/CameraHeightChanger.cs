using UnityEngine;

public class CameraHeightChanger : MonoBehaviour
{
	private Vector3 startingCamPosition;

	private float camMoveSpeed = 8f;

	private float camMoveSpeed_Held = 2f;

	private void Start()
	{
		startingCamPosition = base.transform.localPosition;
	}

	private void Update()
	{
		float axis = Input.GetAxis("Mouse ScrollWheel");
		if (axis > 0f)
		{
			base.transform.Translate(Vector3.up * (camMoveSpeed * Time.deltaTime), Space.Self);
		}
		else if (axis < 0f)
		{
			base.transform.Translate(Vector3.up * (0f - camMoveSpeed * Time.deltaTime), Space.Self);
		}
		if (Input.GetMouseButtonDown(2))
		{
			base.transform.localPosition = startingCamPosition;
		}
		if (Input.GetKeyDown(KeyCode.Comma))
		{
			camMoveSpeed_Held -= 0.25f;
		}
		if (Input.GetKeyDown(KeyCode.Period))
		{
			camMoveSpeed_Held += 0.25f;
		}
		if (Input.GetMouseButton(3))
		{
			base.transform.Translate(Vector3.up * (0f - camMoveSpeed_Held * Time.deltaTime), Space.Self);
		}
		if (Input.GetMouseButton(4))
		{
			base.transform.Translate(Vector3.up * (camMoveSpeed_Held * Time.deltaTime), Space.Self);
		}
		if (Input.GetKeyDown(KeyCode.M))
		{
			AudioManager.Singleton.musicVolume = 0f;
			AudioManager.Singleton.ambientVolume = 0f;
			AudioManager.Singleton.StopAmbientMusic();
			AudioManager.Singleton.StopShopMusic();
		}
		if (Input.GetKeyDown(KeyCode.Alpha1))
		{
			PlayerStats.Singleton.berryGrowthRate_Multiplier -= 0.25f;
		}
		if (Input.GetKeyDown(KeyCode.Alpha2))
		{
			PlayerStats.Singleton.berryGrowthRate_Multiplier += 0.25f;
		}
	}
}
