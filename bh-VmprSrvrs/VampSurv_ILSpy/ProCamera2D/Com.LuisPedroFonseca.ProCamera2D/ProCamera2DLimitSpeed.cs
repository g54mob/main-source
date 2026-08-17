using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using UnityEngine;

namespace Com.LuisPedroFonseca.ProCamera2D;

public class ProCamera2DLimitSpeed : BasePC2D, IPositionDeltaChanger
{
	public static string ExtensionName = "Limit Speed";

	public bool LimitHorizontalSpeed;

	public float MaxHorizontalSpeed;

	public bool LimitVerticalSpeed;

	public float MaxVerticalSpeed;

	private int _pdcOrder;

	public int PDCOrder
	{
		get
		{
			return _pdcOrder;
		}
		set
		{
			_pdcOrder = value;
		}
	}

	protected override void Awake()
	{
		base.Awake();
		ProCamera2D proCamera2D = base.ProCamera2D;
		proCamera2D.AddPositionDeltaChanger(this);
	}

	protected override void OnDestroy()
	{
		Disable();
		ProCamera2D proCamera2D = base.ProCamera2D;
		if ((object)proCamera2D != null && ((UnityEngine.Object)proCamera2D).m_CachedPtr != (IntPtr)0)
		{
			ProCamera2D proCamera2D2 = base.ProCamera2D;
			bool flag = ((List<object>)(object)proCamera2D2._positionDeltaChangers).Remove((object)this);
		}
	}

	public unsafe Vector3 AdjustDelta(float deltaTime, Vector3 originalDelta)
	{
		//IL_020a: Expected O, but got I4
		//IL_01f1: Expected native int or pointer, but got O
		//IL_025d: Expected native int or pointer, but got O
		//IL_01c5: Expected F4, but got I
		//IL_01d2: Expected F4, but got O
		//IL_01cd: Expected native int or pointer, but got O
		bool flag = ((UnityEngine.Object)this).m_CachedPtr == (IntPtr)0;
		object obj = Behaviour.get_enabled_Injected(((UnityEngine.Object)this).m_CachedPtr);
		float z;
		Vector3 vector = default(Vector3);
		if (obj != null)
		{
			Func<Vector3, float> vector3H = Vector3H;
			float num = 1f / deltaTime;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v103 @ rcx_v11 (System.Func`2<UnityEngine.Vector3, System.Single>)+18] (should have been resolved before IL gen)");
			Func<Vector3, float> vector3V = Vector3V;
			float num2 = originalDelta.x * num;
			float x = originalDelta.x;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v104 @ rcx_v13 (System.Func`2<UnityEngine.Vector3, System.Single>)+18] (should have been resolved before IL gen)");
			bool flag2 = !LimitHorizontalSpeed;
			float num3 = originalDelta.x * num;
			if (!flag2)
			{
				x = MaxHorizontalSpeed ^ -0f;
				if (!(x > num2))
				{
					if (num2 > MaxHorizontalSpeed)
					{
						num2 = MaxHorizontalSpeed;
					}
				}
				else
				{
					num2 = x;
				}
			}
			if (LimitVerticalSpeed)
			{
				x = MaxVerticalSpeed ^ -0f;
				if (!(x > num3))
				{
					if (num3 > MaxVerticalSpeed)
					{
						num3 = MaxVerticalSpeed;
					}
				}
				else
				{
					num3 = x;
				}
			}
			Func<float, float, Vector3> vectorHV = VectorHV;
			float num4 = num3 * deltaTime;
			float num5 = num2 * deltaTime;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v91 @ rdx_v9 (System.Func`3<System.Single, System.Single, UnityEngine.Vector3>)+18] (should have been resolved before IL gen)");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v450 @ rax_v20+8]");
			z = 0f;
			object obj2 = default(object);
			((Vector3*)(nint)vector)->x = (float)obj2;
		}
		else
		{
			z = originalDelta.z;
			((Vector3*)(nint)vector)->x = originalDelta.x;
		}
		((Vector3*)(nint)vector)->z = z;
		return vector;
	}

	public ProCamera2DLimitSpeed()
	{
		//IL_004c: Expected I, but got O
		LimitHorizontalSpeed = true;
		MaxHorizontalSpeed = 2f;
		LimitVerticalSpeed = true;
		MaxVerticalSpeed = 2f;
		_pdcOrder = 1000;
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
