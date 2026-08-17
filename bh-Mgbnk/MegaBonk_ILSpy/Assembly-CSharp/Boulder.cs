using Assets.Scripts.Utility;
using Cpp2ILInjected;
using UnityEngine;

public class Boulder : MonoBehaviour
{
	public Rigidbody rb;

	private float defaultSize = 2f;

	public float frictionStrength = 0.5f;

	public AudioSource audio;

	private float minSpeedVolume = 2f;

	private float maxVolumeSpeed = 20f;

	private void Start()
	{
		Transform transform = base.transform;
		float num = transform.localScale.x / defaultSize;
		float mass = rb.mass;
		float mass2 = mass * num;
		rb.mass = mass2;
	}

	private unsafe void FixedUpdate()
	{
		//IL_00b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bd: Expected O, but got Unknown
		//IL_00e7: Expected O, but got Ref
		//IL_01ba: Expected O, but got Ref
		Vector3 velocity = rb.velocity;
		float num = velocity.x * velocity.x;
		object obj2 = default(object);
		object obj = obj2 * obj2;
		float num2 = (float)obj + num;
		float num3 = velocity.z * velocity.z;
		float num4 = num2 + num3;
		float num8 = default(float);
		if (num4 > 0.001f)
		{
			Vector3 velocity2 = rb.velocity;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331950");
			object obj4 = default(object);
			object obj3 = obj4 ^ -0f;
			float num5 = (float)obj3 * frictionStrength;
			float num6 = num5 * MyTime.fixedDeltaTime;
			float num7 = num6 * 50f;
			rb.AddForce((Vector3)(&num8), ForceMode.Force);
			num8 = num7;
		}
		Vector3 angularVelocity = rb.angularVelocity;
		float num9 = angularVelocity.x * angularVelocity.x;
		object obj5 = obj2 * obj2;
		float num10 = (float)obj5 + num9;
		float num11 = angularVelocity.z * angularVelocity.z;
		float num12 = num10 + num11;
		if (num12 > 0.001f)
		{
			Vector3 angularVelocity2 = rb.angularVelocity;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331950");
			rb.AddTorque((Vector3)(&num8), ForceMode.Force);
		}
	}

	private void Update()
	{
		//IL_0064: Invalid comparison between I4 and F4
		//IL_00af: Expected F4, but got I4
		//IL_00f0: Invalid comparison between I4 and F4
		//IL_0154: Invalid comparison between F4 and I4
		if (MyTime.paused)
		{
			return;
		}
		Vector3 velocity = rb.velocity;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331860");
		float num = maxVolumeSpeed - minSpeedVolume;
		float num2 = velocity.x - minSpeedVolume;
		float num3 = num2 / num;
		if (!(0f > num3))
		{
			if (num3 > 1f)
			{
				num3 = 1f;
			}
		}
		else
		{
			num3 = 0f;
		}
		float volume = num3 * 0.85f;
		audio.volume = volume;
		float volume2 = audio.volume;
		if (!(0f < volume2) && audio.isPlaying)
		{
			audio.Stop();
			return;
		}
		float volume3 = audio.volume;
		if (volume3 > 0f && !audio.isPlaying)
		{
			audio.Play();
		}
	}
}
