using System;
using System.Collections.Generic;
using Assets.Scripts.Actors.Player;
using Cpp2ILInjected;
using UnityEngine;

public class MusicPauseZone : MonoBehaviour
{
	public float radius;

	private float nextCheckTime;

	private float checkDelay = 0.1f;

	private void Update()
	{
		//IL_01cc: Expected I, but got O
		//IL_0141: Invalid comparison between F4 and I4
		float time = Time.time;
		if (nextCheckTime > time)
		{
			return;
		}
		float time2 = Time.time;
		float num = time2 + checkDelay;
		nextCheckTime = num;
		if (MyPlayer.Instance != null)
		{
			Transform transform = base.transform;
			Vector3 position = transform.position;
			Transform transform2 = MyPlayer.Instance.transform;
			Vector3 position2 = transform2.position;
			nint num2 = (nint)typeof(Math);
			float num3 = position.x - position2.x;
			float num4 = position.y - position2.y;
			float num5 = position.z - position2.z;
			float num6 = num4 * num4;
			float num7 = num3 * num3;
			float num8 = num5 * num5;
			float num9 = num6 + num7;
			float num10 = num9 + num8;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"ucomisd xmm0,xmm1\"");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v374 @ rcx_v16 (Il2CppClass<System.Math>)+E4]");
			if ((nint)0 <= (nint)0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"sqrtpd xmm0,xmm1\"");
			}
			else
			{
				double num11 = Math.Sqrt(num10);
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsd2ss xmm1,xmm0\"");
			float value = ((!(radius > 0f)) ? 1f : 0.12f);
			MusicController instance = MusicController.Instance;
			((Dictionary<object, float>)(object)instance.zoneInfluences).set_Item((object)this, value);
		}
	}

	private unsafe void OnDrawGizmosSelected()
	{
		//IL_002b: Expected O, but got Ref
		Transform transform = base.transform;
		Vector3 position = transform.position;
		object obj = default(object);
		Gizmos.DrawWireSphere((Vector3)(&obj), radius);
	}
}
