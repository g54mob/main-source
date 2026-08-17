using System;
using Cpp2ILInjected;
using MilkShake;
using UnityEngine;

public class BossMeteor : MonoBehaviour
{
	public Transform destination;

	public float speed = 200f;

	public GameObject explosionFx;

	public FianlBossCinematic cinematic;

	private unsafe void Update()
	{
		//IL_02da: Invalid comparison between F4 and I4
		//IL_0121: Expected O, but got Ref
		//IL_0054: Invalid comparison between F4 and I4
		//IL_00ac: Expected I, but got O
		//IL_0204: Expected O, but got I4
		Transform transform = base.transform;
		Transform transform2 = base.transform;
		Vector3 position = transform2.position;
		Vector3 position2 = destination.position;
		float deltaTime = Time.deltaTime;
		float num = deltaTime * speed;
		float num2 = position2.x - position.x;
		float num3 = position2.z - position.z;
		float num4 = position2.y - position.y;
		float num5 = num2 * num2;
		float num6 = num3 * num3;
		float num7 = num4 * num4;
		float num8 = num7 + num5;
		float num9 = num8 + num6;
		bool flag = num9 == 0f;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 000000018048B159h\"");
		if (!flag)
		{
			if (!(num < 0f))
			{
				float num10 = num * num;
				if (!(num10 < num9))
				{
					goto IL_0114;
				}
			}
			nint num11 = (nint)typeof(Math);
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"ucomisd xmm0,xmm1\"");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v407 @ rcx_v24 (Il2CppClass<System.Math>)+E4]");
			if ((nint)0 <= (nint)0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"sqrtpd xmm0,xmm1\"");
			}
			else
			{
				double num12 = Math.Sqrt(num9);
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsd2ss xmm0,xmm0\"");
		}
		goto IL_0114;
		IL_0114:
		float num13 = default(float);
		transform.position = (Vector3)(&num13);
		Transform transform3 = base.transform;
		Vector3 position3 = transform3.position;
		Transform transform4 = destination.transform;
		if (!(transform4.position.y < position3.y))
		{
			explosionFx.SetActive(value: true);
			Transform transform5 = explosionFx.transform;
			transform5.parentInternal = null;
			GameObject obj = base.gameObject;
			UnityEngine.Object.Destroy(obj);
			FianlBossCinematic fianlBossCinematic = cinematic;
			ShakeInstance shakeInstance = fianlBossCinematic.shaker.Shake(fianlBossCinematic.impactShake, (int?)(object)0);
			ControllerShaker.Shake(0, 0.8f, 1f);
		}
	}
}
