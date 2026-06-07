using UnityEngine;

public class FireHose : MonoBehaviour
{
	public Holdable Parent;

	public ParticleSystem Particles;

	public AudioSource SFX;

	private void Update()
	{
		bool flag = false;
		if (Parent.Holder != null && Parent.Holder.InspectRooms != null && Parent.Holder.AIScript.HasFlag(AI.NodeFlag.SprayHose) && !Parent.Holder.Turn)
		{
			Room cleaningRoom = Parent.Holder.CleaningRoom;
			if (cleaningRoom != null)
			{
				flag = true;
				Vector3 v = cleaningRoom.Center.ToVector3((float)(cleaningRoom.Floor * 2) + 1f) - Particles.transform.position;
				Particles.transform.rotation = v.LookDir();
				ParticleSystem.MainModule main = Particles.main;
				main.startLifetimeMultiplier = v.magnitude / 10f;
			}
		}
		bool flag2 = GameSettings.GameSpeed > 0f && flag;
		if (flag2)
		{
			if (!SFX.isPlaying)
			{
				SFX.Play();
			}
			SFX.outputAudioMixerGroup = ((GameSettings.Instance.sRoomManager.CameraRoom == GameSettings.Instance.sRoomManager.Outside) ? AudioManager.InGameNormal : AudioManager.InGameHighPass);
		}
		else if (!flag2 && SFX.isPlaying)
		{
			SFX.Stop();
		}
		if (flag)
		{
			if (!Particles.isPlaying)
			{
				Particles.Play();
			}
			ParticleSystem.MainModule main2 = Particles.main;
			main2.simulationSpeed = Mathf.Max(0.01f, HUD.Instance.GameSpeed);
		}
		else if (Particles.isPlaying)
		{
			Particles.Stop();
		}
	}
}
