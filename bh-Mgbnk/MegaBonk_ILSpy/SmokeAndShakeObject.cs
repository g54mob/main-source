using System;
using Assets.Scripts.Utility;
using Cpp2ILInjected;
using UnityEngine;

public class SmokeAndShakeObject : MonoBehaviour
{
	public float shakeStrength = 1f;

	private float readyAtTime;

	private float maxDistanceToPlayer = 6400f;

	private float minSpeed = 10f;

	private float maxSpeed = 40f;

	public static Action<float> A_Impact;

	private unsafe void OnCollisionEnter(Collision other)
	{
		//IL_020a: Expected I, but got O
		//IL_0138: Invalid comparison between F4 and I4
		//IL_0167: Unknown result type (might be due to invalid IL or missing references)
		//IL_016c: Expected O, but got Unknown
		//IL_0180: Expected O, but got Ref
		//IL_01a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a9: Expected O, but got Unknown
		//IL_01d3: Expected O, but got Ref
		//IL_01d3: Expected O, but got Ref
		GameObject gameObject = other.gameObject;
		int layer = gameObject.layer;
		int num = LayerMask.NameToLayer("Player");
		if (layer != num && !(readyAtTime > MyTime.time))
		{
			Vector3 relativeVelocity = other.relativeVelocity;
			nint num2 = (nint)typeof(Math);
			float num3 = relativeVelocity.y * relativeVelocity.y;
			float num4 = relativeVelocity.z * relativeVelocity.z;
			float num5 = relativeVelocity.x * relativeVelocity.x;
			float num6 = num3 + num5;
			float num7 = num6 + num4;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"ucomisd xmm0,xmm1\"");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v286 @ rcx_v12 (Il2CppClass<System.Math>)+E4]");
			if ((nint)0 <= (nint)0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"sqrtpd xmm0,xmm1\"");
			}
			else
			{
				double num8 = Math.Sqrt(num7);
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsd2ss xmm1,xmm0\"");
			if (!(minSpeed > 0f))
			{
				ContactPoint[] contacts = other.contacts;
				object obj = contacts + 32;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182268200");
				object obj2 = default(object);
				Quaternion quaternion = Quaternion.LookRotation((Vector3)(&obj2));
				ContactPoint[] contacts2 = other.contacts;
				object obj3 = contacts2 + 32;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1822681E0");
				EffectManager instance = EffectManager.Instance;
				object obj4 = default(object);
				GameObject gameObject2 = UnityEngine.Object.Instantiate(instance.smokeHit, (Vector3)(&obj2), (Quaternion)(&obj4));
				float num9 = MyTime.time + 0.5f;
				readyAtTime = num9;
			}
		}
	}
}
