using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.Bindings;

namespace Com.LuisPedroFonseca.ProCamera2D;

public class ProCamera2DPointerInfluence : BasePC2D, IPreMover
{
	public static string ExtensionName = "Pointer Influence";

	public float MaxHorizontalInfluence;

	public float MaxVerticalInfluence;

	public float InfluenceSmoothness;

	private Vector2 _influence;

	private Vector2 _velocity;

	private int _prmOrder;

	public int PrMOrder
	{
		get
		{
			return _prmOrder;
		}
		set
		{
			_prmOrder = value;
		}
	}

	protected override void Awake()
	{
		base.Awake();
		ProCamera2D proCamera2D = base.ProCamera2D;
		proCamera2D.AddPreMover(this);
	}

	protected override void OnDestroy()
	{
		Disable();
		ProCamera2D proCamera2D = base.ProCamera2D;
		if ((object)proCamera2D != null && ((UnityEngine.Object)proCamera2D).m_CachedPtr != (IntPtr)0)
		{
			ProCamera2D proCamera2D2 = base.ProCamera2D;
			bool flag = ((List<object>)(object)proCamera2D2._preMovers).Remove((object)this);
		}
	}

	public override void OnReset()
	{
		//IL_0013: Expected I, but got O
		//IL_004e: Expected I, but got O
		nint num = (nint)typeof(Vector2);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (Il2CppClass<UnityEngine.Vector2>)+B8]");
		nint num2 = 0;
		_influence = Vector2.zeroVector;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v33 @ rdx_v1 (Il2CppStaticFields<UnityEngine.Vector2>)+4]");
		_ = 0;
		nint num3 = (nint)typeof(Vector2);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v53 @ rax_v4 (Il2CppClass<UnityEngine.Vector2>)+B8]");
		nint num4 = 0;
		_velocity = Vector2.zeroVector;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v54 @ rcx_v3 (Il2CppStaticFields<UnityEngine.Vector2>)+4]");
		_ = 0;
	}

	public void PreMove(float deltaTime)
	{
		//IL_0044: Expected O, but got I4
		bool flag = ((UnityEngine.Object)this).m_CachedPtr == (IntPtr)0;
		object obj = Behaviour.get_enabled_Injected(((UnityEngine.Object)this).m_CachedPtr);
		if (obj != null)
		{
			ApplyInfluence(deltaTime);
		}
	}

	private unsafe void ApplyInfluence(float deltaTime)
	{
		//IL_0159: Unknown result type (might be due to invalid IL or missing references)
		//IL_015e: Expected Ref, but got Unknown
		ProCamera2D proCamera2D = base.ProCamera2D;
		Camera gameCamera = proCamera2D.GameCamera;
		Input.get_mousePosition_Injected(out Vector3 _);
		if (((UnityEngine.Object)gameCamera).m_CachedPtr != (IntPtr)0)
		{
			Vector3 position = default(Vector3);
			Camera.ScreenToViewportPoint_Injected(((UnityEngine.Object)gameCamera).m_CachedPtr, ref position, out Vector3 ret2);
			object obj = ret2 + ret2;
			float num = (float)obj - 1f;
			if (-1f > num || num > 1f)
			{
			}
			object obj3 = default(object);
			object obj2 = obj3 + obj3;
			float num2 = (float)obj2 - 1f;
			if (-1f > num2 || num2 > 1f)
			{
			}
			Vector2 vector = default(Vector2);
			float maxSpeed = default(float);
			float deltaTime2 = default(float);
			Vector2 influence = Vector2.SmoothDamp(vector, vector, ref *(Vector2*)(this + 116), InfluenceSmoothness, maxSpeed, deltaTime2);
			_influence = influence;
			ProCamera2D proCamera2D2 = base.ProCamera2D;
			proCamera2D2.ApplyInfluence(vector);
			return;
		}
		UnityEngine.Bindings.ThrowHelper.ThrowNullReferenceException(gameCamera);
		throw new NullReferenceException();
	}

	public ProCamera2DPointerInfluence()
	{
		//IL_0041: Expected I, but got O
		MaxHorizontalInfluence = 3f;
		MaxVerticalInfluence = 2f;
		InfluenceSmoothness = 0.2f;
		_prmOrder = 3000;
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
