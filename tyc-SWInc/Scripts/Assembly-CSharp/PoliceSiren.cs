using UnityEngine;

public class PoliceSiren : MonoBehaviour
{
	public CarScript Car;

	public AudioSource Audio;

	public Light[] Lights;

	public float RotSpeed = 1f;

	private void Update()
	{
		if (GameSettings.Instance.IsReferenceNull())
		{
			return;
		}
		if (Car.Parked)
		{
			ToggleLights(false);
			if (Audio.isPlaying)
			{
				Audio.Stop();
			}
			return;
		}
		bool flag = GameSettings.Instance.ActiveFloor >= 0;
		ToggleLights(flag);
		if (flag)
		{
			Quaternion quaternion = Quaternion.Euler(0f, Time.deltaTime * GameSettings.GameSpeed * RotSpeed, 0f);
			for (int i = 0; i < Lights.Length; i++)
			{
				Lights[i].transform.rotation = quaternion * Lights[i].transform.rotation;
			}
		}
		if (Audio.isPlaying && GameSettings.GameSpeed == 0f)
		{
			Audio.Pause();
		}
		if (!Audio.isPlaying && GameSettings.GameSpeed > 0f)
		{
			Audio.Play();
		}
		Audio.outputAudioMixerGroup = ((GameSettings.Instance.sRoomManager.CameraRoom == GameSettings.Instance.sRoomManager.Outside) ? AudioManager.InGameNormal : AudioManager.InGameHighPass);
	}

	private void ToggleLights(bool on)
	{
		for (int i = 0; i < Lights.Length; i++)
		{
			Lights[i].enabled = on;
		}
	}
}
