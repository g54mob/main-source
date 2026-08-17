using System;
using Assets.Scripts.Actors.Player;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class JumpPad : MonoBehaviour
{
	public float force = 35f;

	public Transform spring;

	public Transform direction;

	private float animationTime = -1f;

	private float animationScale = 5f;

	private float animationSpeed = 5f;

	public AudioSource audioSource;

	private Vector3 defaultScale;

	private void Awake()
	{
		//IL_004c: Expected O, but got F4
		if (spring != null)
		{
			Vector3 localScale = spring.localScale;
			defaultScale = (Vector3)localScale.x;
			_ = localScale.z;
		}
	}

	public unsafe Vector3 GetForce()
	{
		//IL_00ea: Expected I, but got O
		//IL_00b8: Expected native int or pointer, but got O
		//IL_00c5: Expected native int or pointer, but got O
		//IL_00d2: Expected native int or pointer, but got O
		float x;
		float y;
		float z;
		if (direction != null)
		{
			if ((object)direction == null)
			{
				return (Vector3)new NullReferenceException();
			}
			Vector3 forward = direction.forward;
			x = force * forward.x;
			y = force * forward.y;
			z = force * forward.z;
		}
		else
		{
			nint num = (nint)typeof(Vector3);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v93 @ rax_v7 (Il2CppClass<UnityEngine.Vector3>)+B8]");
			nint num2 = 0;
			x = force * (float)Vector3.upVector;
			object obj = default(object);
			y = force * (float)obj;
			float num3 = force;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v94 @ rcx_v6 (Il2CppStaticFields<UnityEngine.Vector3>)+20]");
			z = num3 * 0f;
		}
		Vector3 vector = default(Vector3);
		((Vector3*)(nint)vector)->z = z;
		((Vector3*)(nint)vector)->y = y;
		((Vector3*)(nint)vector)->x = x;
		return vector;
	}

	private void OnTriggerEnter(Collider other)
	{
		GameObject gameObject = other.gameObject;
		GameObject gameObject2 = MyPlayer.Instance.gameObject;
		if (gameObject == gameObject2)
		{
			MyPlayer instance = MyPlayer.Instance;
			instance.playerMovement.JumpPad(this);
			if (audioSource != null)
			{
				audioSource.Play();
			}
			animationTime = 0f;
		}
	}

	private void AnimateSpring()
	{
		if (audioSource != null)
		{
			audioSource.Play();
		}
		animationTime = 0f;
	}

	private unsafe void Update()
	{
		//IL_0182: Invalid comparison between I4 and F4
		//IL_0171: Expected O, but got Ref
		//IL_0116: Invalid comparison between I4 and F4
		//IL_01b0: Expected O, but got Ref
		if (0f > animationTime || !(animationTime < 1f) || !(spring != null))
		{
			return;
		}
		float deltaTime = Time.deltaTime;
		float num = deltaTime * animationSpeed;
		float num2 = (animationTime = num + animationTime);
		Vector3 localScale2;
		object obj = default(object);
		Transform transform;
		if (!(num2 > 1f))
		{
			float num3 = num2 + num2;
			float t = ((!(num2 > 0.5f)) ? num3 : (2f - num3));
			float num4 = Easing.InOutCubic(t);
			float num5 = num4 * animationScale;
			Vector3 localScale = spring.localScale;
			if (0f > num5 || num5 > 1f)
			{
			}
			localScale2 = (Vector3)(&obj);
			transform = spring;
		}
		else
		{
			transform = spring;
			animationTime = 1f;
			localScale2 = (Vector3)(&obj);
		}
		transform.localScale = localScale2;
	}
}
