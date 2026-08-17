using System;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using UnityEngine;

namespace Assets.Scripts.Inventory__Items__Pickups.Weapons;

public class EnemyScanContainer
{
	public float range;

	public float time;

	public Vector3 position;

	private const float distThreshold = 2f;

	private const float distThresholdSqr = 4f;

	private const float timeThreshold = 0.04f;

	private const float rangeThreshold = 1f;

	public EnemyScanContainer(Vector3 position, float time, float range)
	{
		//IL_0015: Expected O, but got F4
		base._002Ector();
		this.position = (Vector3)position.x;
		this.time = time;
		this.range = range;
		_ = position.z;
	}

	public void Set(Vector3 position, float time, float range)
	{
		//IL_000f: Expected O, but got F4
		this.position = (Vector3)position.x;
		_ = position.z;
		this.time = time;
		this.range = range;
	}

	public bool IsEqual(Vector3 pos, float t, float range)
	{
		//IL_00ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f4: Expected O, but got Unknown
		//IL_00fd: Invalid comparison between F4 and O
		//IL_0135: Unknown result type (might be due to invalid IL or missing references)
		//IL_013a: Expected O, but got Unknown
		//IL_0143: Invalid comparison between F4 and O
		//IL_0162: Invalid comparison between F4 and I4
		float num = pos.x - (float)position;
		float num2 = pos.y;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Assets.Scripts.Inventory__Items__Pickups.Weapons.EnemyScanContainer)+1C]");
		float num3 = num2 - 0f;
		float num4 = pos.z;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Assets.Scripts.Inventory__Items__Pickups.Weapons.EnemyScanContainer)+20]");
		float num5 = num4 - 0f;
		float num6 = num3 * num3;
		float num7 = num5 * num5;
		float num8 = num * num;
		float num9 = num6 + num8;
		float num10 = num9 + num7;
		if (4f > num10)
		{
			float num11 = t - time;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18262ED80]");
			object obj = num11 & 0;
			if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)0.04f) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj))
			{
				float num12 = this.range - range;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18262ED80]");
				object obj2 = num12 & 0;
				bool flag = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)1f) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2);
				float num13 = 1f - (float)obj2;
				bool flag2 = num13 == 0f;
				bool flag3 = !flag;
				bool flag4 = !flag2;
				return flag4 & flag3;
			}
		}
		return false;
	}

	public unsafe bool IsEqual(EnemyScanContainer other)
	{
		//IL_0050: Expected I4, but got O
		//IL_0039: Expected O, but got Ref
		object obj = default(object);
		if (other != null)
		{
			return IsEqual((Vector3)(&obj), other.time, other.range);
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}
}
