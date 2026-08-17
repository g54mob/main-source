using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.Bindings;

namespace Com.LuisPedroFonseca.ProCamera2D;

public class ProCamera2DZoomToFitTargets : BasePC2D, ISizeOverrider
{
	public static string ExtensionName = "Zoom To Fit";

	public float ZoomOutBorder;

	public float ZoomInBorder;

	public float ZoomInSmoothness;

	public float ZoomOutSmoothness;

	public float MaxZoomInAmount;

	public float MaxZoomOutAmount;

	public bool DisableWhenOneTarget;

	public bool CompensateForCameraPosition;

	private float _zoomVelocity;

	private float _previousCamSize;

	private float _targetCamSize;

	private float _targetCamSizeSmoothed;

	private float _minCameraSize;

	private float _maxCameraSize;

	private int _soOrder;

	public int SOOrder
	{
		get
		{
			return _soOrder;
		}
		set
		{
			_soOrder = value;
		}
	}

	protected override void Awake()
	{
		base.Awake();
		ProCamera2D proCamera2D = base.ProCamera2D;
		if ((object)proCamera2D != null && ((UnityEngine.Object)proCamera2D).m_CachedPtr != (IntPtr)0)
		{
			ProCamera2D proCamera2D2 = base.ProCamera2D;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v201 @ rax_v10 (Com.LuisPedroFonseca.ProCamera2D.ProCamera2D)+5C]");
			_targetCamSizeSmoothed = (_targetCamSize = 0f * 0.5f);
			ProCamera2D proCamera2D3 = base.ProCamera2D;
			proCamera2D3.AddSizeOverrider(this);
		}
	}

	protected override void OnDestroy()
	{
		Disable();
		ProCamera2D proCamera2D = base.ProCamera2D;
		if ((object)proCamera2D != null && ((UnityEngine.Object)proCamera2D).m_CachedPtr != (IntPtr)0)
		{
			ProCamera2D proCamera2D2 = base.ProCamera2D;
			bool flag = ((List<object>)(object)proCamera2D2._sizeOverriders).Remove((object)this);
		}
	}

	public unsafe float OverrideSize(float deltaTime, float originalSize)
	{
		//IL_02c2: Expected O, but got I4
		//IL_019a: Invalid comparison between F4 and I
		//IL_024d: Expected F4, but got I
		//IL_02f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f5: Expected Ref, but got Unknown
		float result;
		if ((object)this != null)
		{
			if (((UnityEngine.Object)this).m_CachedPtr != (IntPtr)0)
			{
				object obj = Behaviour.get_enabled_Injected(((UnityEngine.Object)this).m_CachedPtr);
				if (obj == null)
				{
					result = originalSize;
					goto IL_0329;
				}
				ProCamera2D proCamera2D = base.ProCamera2D;
				if ((object)proCamera2D != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v96 @ rax_v13 (Com.LuisPedroFonseca.ProCamera2D.ProCamera2D)+64]");
					float targetCamSizeSmoothed = 0f * 0.5f;
					_targetCamSizeSmoothed = targetCamSizeSmoothed;
					if (!DisableWhenOneTarget)
					{
						goto IL_0157;
					}
					ProCamera2D proCamera2D2 = base.ProCamera2D;
					if ((object)proCamera2D2 != null)
					{
						List<CameraTarget> cameraTargets = proCamera2D2.CameraTargets;
						if (proCamera2D2.CameraTargets != null)
						{
							if (cameraTargets._size > 1)
							{
								goto IL_0157;
							}
							ProCamera2D proCamera2D3 = base.ProCamera2D;
							if ((object)proCamera2D3 != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v99 @ rax_v23 (Com.LuisPedroFonseca.ProCamera2D.ProCamera2D)+5C]");
								float targetCamSize = 0f * 0.5f;
								_targetCamSize = targetCamSize;
								goto IL_0214;
							}
						}
					}
				}
			}
			else
			{
				UnityEngine.Bindings.ThrowHelper.ThrowNullReferenceException(this);
			}
		}
		goto IL_02ac;
		IL_02ac:
		throw new NullReferenceException();
		IL_0214:
		ProCamera2D proCamera2D4 = base.ProCamera2D;
		if ((object)proCamera2D4 == null)
		{
			goto IL_02ac;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v102 @ rax_v15 (Com.LuisPedroFonseca.ProCamera2D.ProCamera2D)+64]");
		_previousCamSize = 0f;
		float maxSpeed = default(float);
		float deltaTime2 = default(float);
		result = (_targetCamSizeSmoothed = Mathf.SmoothDamp(smoothTime: (!(_targetCamSizeSmoothed > _targetCamSize)) ? ZoomOutSmoothness : ZoomInSmoothness, current: _targetCamSizeSmoothed, target: _targetCamSize, currentVelocity: ref *(float*)(this + 124), maxSpeed: maxSpeed, deltaTime: deltaTime2));
		goto IL_0329;
		IL_0157:
		ProCamera2D proCamera2D5 = base.ProCamera2D;
		if ((object)proCamera2D5 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 00000001851CCC97h\"");
			float previousCamSize = _previousCamSize;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ rax_v17 (Com.LuisPedroFonseca.ProCamera2D.ProCamera2D)+64]");
			if (previousCamSize == 0f)
			{
				ProCamera2D proCamera2D6 = base.ProCamera2D;
				if ((object)proCamera2D6 == null)
				{
					goto IL_02ac;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v101 @ rax_v20 (Com.LuisPedroFonseca.ProCamera2D.ProCamera2D)+64]");
				float num = 0f * 0.5f;
				_zoomVelocity = 0f;
				_targetCamSize = num;
				_targetCamSizeSmoothed = num;
			}
			UpdateTargetCamSize();
			goto IL_0214;
		}
		goto IL_02ac;
		IL_0329:
		return result;
	}

	public override void OnReset()
	{
		_zoomVelocity = 0f;
		ProCamera2D proCamera2D = base.ProCamera2D;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rax_v1 (Com.LuisPedroFonseca.ProCamera2D.ProCamera2D)+5C]");
		_targetCamSizeSmoothed = (_targetCamSize = (_previousCamSize = 0f * 0.5f));
	}

	private void UpdateTargetCamSize()
	{
		//IL_056e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0573: Expected O, but got Unknown
		//IL_0583: Unknown result type (might be due to invalid IL or missing references)
		//IL_0588: Expected O, but got Unknown
		//IL_079e: Unknown result type (might be due to invalid IL or missing references)
		//IL_07a3: Expected O, but got Unknown
		//IL_0804: Unknown result type (might be due to invalid IL or missing references)
		//IL_0809: Expected O, but got Unknown
		//IL_067a: Unknown result type (might be due to invalid IL or missing references)
		//IL_067f: Expected O, but got Unknown
		//IL_0867: Unknown result type (might be due to invalid IL or missing references)
		//IL_086c: Expected O, but got Unknown
		//IL_076b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0770: Expected O, but got Unknown
		//IL_0d82: Expected O, but got F4
		//IL_08d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_08d5: Expected O, but got Unknown
		//IL_0d2d: Expected O, but got F4
		//IL_0dda: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ddf: Expected O, but got Unknown
		//IL_0830->IL0a0c: Incompatible stack heights: 4 vs 3
		//IL_078f->IL0c91: Incompatible stack heights: 10 vs 2
		//IL_08ff->IL0cd4: Incompatible stack heights: 6 vs 5
		//IL_0e11->IL0cd4: Incompatible stack heights: 8 vs 5
		//IL_09b4->IL0cd4: Incompatible stack heights: 8 vs 5
		//IL_0d52->IL0e02: Incompatible stack heights: 11 vs 8
		//IL_052f->IL0023: Incompatible stack heights: 29 vs 1
		ProCamera2D proCamera2D = base.ProCamera2D;
		bool flag = (object)proCamera2D == null;
		object obj = null;
		float num = 1f / 0f;
		float num2 = -1f / 0f;
		float num3 = 1f / 0f;
		float num4 = -1f / 0f;
		object obj2 = null;
		while (true)
		{
			List<CameraTarget> cameraTargets = proCamera2D.CameraTargets;
			bool flag2 = proCamera2D.CameraTargets == null;
			if ((nint)obj2 >= cameraTargets._size)
			{
				break;
			}
			Func<Vector3, float> vector3H = Vector3H;
			ProCamera2D proCamera2D2 = base.ProCamera2D;
			bool flag3 = (object)proCamera2D2 == null;
			List<CameraTarget> cameraTargets2 = proCamera2D2.CameraTargets;
			bool flag4 = proCamera2D2.CameraTargets == null;
			bool flag5 = (nint)obj >= cameraTargets2._size;
			CameraTarget[] items = cameraTargets2._items;
			bool flag6 = cameraTargets2._items == null;
			bool flag7 = (nint)obj >= items.Length;
			bool flag8 = items[obj] == null;
			Vector3 targetPosition = items[obj].TargetPosition;
			bool flag9 = Vector3H == null;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v249 @ rsi_v14 (System.Func`2<UnityEngine.Vector3, System.Single>)+18] (should have been resolved before IL gen)");
			ProCamera2D proCamera2D3 = base.ProCamera2D;
			bool flag10 = (object)proCamera2D3 == null;
			List<CameraTarget> cameraTargets3 = proCamera2D3.CameraTargets;
			bool flag11 = proCamera2D3.CameraTargets == null;
			bool flag12 = (nint)obj >= cameraTargets3._size;
			CameraTarget[] items2 = cameraTargets3._items;
			bool flag13 = cameraTargets3._items == null;
			bool flag14 = (nint)obj >= items2.Length;
			CameraTarget cameraTarget = items2[obj];
			bool flag15 = items2[obj] == null;
			Func<Vector3, float> vector3V = Vector3V;
			ProCamera2D proCamera2D4 = base.ProCamera2D;
			bool flag16 = (object)proCamera2D4 == null;
			List<CameraTarget> cameraTargets4 = proCamera2D4.CameraTargets;
			bool flag17 = proCamera2D4.CameraTargets == null;
			bool flag18 = (nint)obj >= cameraTargets4._size;
			CameraTarget[] items3 = cameraTargets4._items;
			bool flag19 = cameraTargets4._items == null;
			bool flag20 = (nint)obj >= items3.Length;
			bool flag21 = items3[obj] == null;
			Vector3 targetPosition2 = items3[obj].TargetPosition;
			bool flag22 = Vector3V == null;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v250 @ rsi_v15 (System.Func`2<UnityEngine.Vector3, System.Single>)+18] (should have been resolved before IL gen)");
			ProCamera2D proCamera2D5 = base.ProCamera2D;
			bool flag23 = (object)proCamera2D5 == null;
			List<CameraTarget> cameraTargets5 = proCamera2D5.CameraTargets;
			bool flag24 = proCamera2D5.CameraTargets == null;
			bool flag25 = (nint)obj >= cameraTargets5._size;
			CameraTarget[] items4 = cameraTargets5._items;
			bool flag26 = cameraTargets5._items == null;
			bool flag27 = (nint)obj >= items4.Length;
			CameraTarget cameraTarget2 = items4[obj];
			bool flag28 = items4[obj] == null;
			float num5 = targetPosition2.x;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v228 @ rdx_v48 (Com.LuisPedroFonseca.ProCamera2D.CameraTarget)+24]");
			float num6 = num5 + 0f;
			float num7 = (float)cameraTarget.TargetOffset + targetPosition.x;
			if (num7 > num4)
			{
				num4 = num7;
			}
			if (num3 > num7)
			{
				num3 = num7;
			}
			if (num6 > num2)
			{
				num2 = num6;
			}
			if (num > num6)
			{
				num = num6;
			}
			obj++;
			proCamera2D = base.ProCamera2D;
			bool flag29 = (object)proCamera2D == null;
			float x = targetPosition2.x;
			float x2 = targetPosition.x;
			obj2 = obj;
		}
		bool flag30 = !CompensateForCameraPosition;
		float num8 = num4 - num3;
		float num9 = num2 - num;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12890]");
		object obj3 = num8 & 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12890]");
		object obj4 = num9 & 0;
		if (!flag30)
		{
			Camera vector3H2 = (Camera)(object)Vector3H;
			ProCamera2D proCamera2D6 = base.ProCamera2D;
			bool flag31 = (object)proCamera2D6 == null;
			bool flag32 = Vector3H == null;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v146.m_NonSerializedVersion (System.UInt32) (should have been resolved before IL gen)");
			Camera vector3H3 = (Camera)(object)Vector3H;
			ProCamera2D proCamera2D7 = base.ProCamera2D;
			bool flag33 = (object)proCamera2D7 == null;
			Vector3 localPosition = proCamera2D7.LocalPosition;
			bool flag34 = Vector3H == null;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v147.m_NonSerializedVersion (System.UInt32) (should have been resolved before IL gen)");
			Camera vector3V2 = (Camera)(object)Vector3V;
			float num10 = (float)proCamera2D6._003CTargetsMidPoint_003Ek__BackingField - localPosition.x;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12890]");
			object obj5 = num10 & 0;
			object obj6 = obj5 + obj5;
			obj3 += obj6;
			ProCamera2D proCamera2D8 = base.ProCamera2D;
			bool flag35 = (object)proCamera2D8 == null;
			bool flag36 = Vector3V == null;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v148.m_NonSerializedVersion (System.UInt32) (should have been resolved before IL gen)");
			object vector3V3 = Vector3V;
			ProCamera2D proCamera2D9 = base.ProCamera2D;
			bool flag37 = (object)proCamera2D9 == null;
			Vector3 localPosition2 = proCamera2D9.LocalPosition;
			bool flag38 = Vector3V == null;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v149 @ rbx_v18 (System.Object)+18] (should have been resolved before IL gen)");
			float num11 = (float)proCamera2D8._003CTargetsMidPoint_003Ek__BackingField - localPosition2.x;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12890]");
			object obj7 = num11 & 0;
			object obj8 = obj7 + obj7;
			obj4 += obj8;
		}
		float num12 = (float)obj3 * 0.5f;
		float num13 = (float)obj4 * 0.5f;
		ProCamera2D proCamera2D10 = base.ProCamera2D;
		bool flag39 = (object)proCamera2D10 == null;
		object obj9 = proCamera2D10._003CScreenSizeInWorldCoordinates_003Ek__BackingField * ZoomOutBorder;
		float num14 = (float)obj9 * 0.5f;
		bool num15;
		bool num17;
		float targetCamSize;
		if (!(num12 > num14))
		{
			ProCamera2D proCamera2D11 = base.ProCamera2D;
			bool flag40 = (object)proCamera2D11 == null;
			num15 = flag40;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v747 @ rax_v36 (Com.LuisPedroFonseca.ProCamera2D.ProCamera2D)+64]");
			object obj10 = 0 * ZoomOutBorder;
			float num16 = (float)obj10 * 0.5f;
			if (!(num13 > num16))
			{
				ProCamera2D proCamera2D12 = base.ProCamera2D;
				bool flag41 = (object)proCamera2D12 == null;
				num17 = flag41;
				object obj11 = proCamera2D12._003CScreenSizeInWorldCoordinates_003Ek__BackingField * ZoomInBorder;
				float num18 = (float)obj11 * 0.5f;
				if (num18 > num12)
				{
					ProCamera2D proCamera2D13 = base.ProCamera2D;
					bool flag42 = (object)proCamera2D13 == null;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v749 @ rax_v38 (Com.LuisPedroFonseca.ProCamera2D.ProCamera2D)+64]");
					object obj12 = 0 * ZoomInBorder;
					float num19 = (float)obj12 * 0.5f;
					if (num19 > num13)
					{
						ProCamera2D proCamera2D14 = base.ProCamera2D;
						bool flag43 = (object)proCamera2D14 == null;
						ProCamera2D proCamera2D15 = base.ProCamera2D;
						bool flag44 = (object)proCamera2D15 == null;
						float num20 = num13;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v751 @ rax_v40 (Com.LuisPedroFonseca.ProCamera2D.ProCamera2D)+64]");
						float num21 = num20 / 0f;
						float num22 = num12 / (float)proCamera2D14._003CScreenSizeInWorldCoordinates_003Ek__BackingField;
						if (!(num22 < num21))
						{
							ProCamera2D proCamera2D16 = base.ProCamera2D;
							bool flag45 = (object)proCamera2D16 == null;
							object gameCamera = proCamera2D16.GameCamera;
							bool flag46 = (object)proCamera2D16.GameCamera == null;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v151 @ rbx_v14 (System.Object)+10]");
							bool flag47 = (nint)0 == 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v151 @ rbx_v14 (System.Object)+10]");
							object obj13 = Camera.get_aspect_Injected((IntPtr)0);
							float num23 = num12 / num21;
							targetCamSize = num23 / ZoomInBorder;
							goto IL_0e02;
						}
						float targetCamSize2 = num13 / ZoomInBorder;
						_targetCamSize = targetCamSize2;
					}
				}
				goto IL_0cd4;
			}
		}
		ProCamera2D proCamera2D17 = base.ProCamera2D;
		bool flag48 = (object)proCamera2D17 == null;
		num15 = flag48;
		ProCamera2D proCamera2D18 = base.ProCamera2D;
		bool flag49 = (object)proCamera2D18 == null;
		num17 = flag49;
		float num24 = num13;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v754 @ rax_v26 (Com.LuisPedroFonseca.ProCamera2D.ProCamera2D)+64]");
		float num25 = num24 / 0f;
		float num26 = num12 / (float)proCamera2D17._003CScreenSizeInWorldCoordinates_003Ek__BackingField;
		if (num26 < num25)
		{
			float targetCamSize3 = num13 / ZoomOutBorder;
			_targetCamSize = targetCamSize3;
			goto IL_0cd4;
		}
		ProCamera2D proCamera2D19 = base.ProCamera2D;
		bool flag50 = (object)proCamera2D19 == null;
		Camera gameCamera2 = proCamera2D19.GameCamera;
		bool flag51 = (object)proCamera2D19.GameCamera == null;
		bool flag52 = ((UnityEngine.Object)gameCamera2).m_CachedPtr == (IntPtr)0;
		object obj14 = Camera.get_aspect_Injected(((UnityEngine.Object)gameCamera2).m_CachedPtr);
		float num27 = num12 / num25;
		targetCamSize = num27 / ZoomOutBorder;
		goto IL_0e02;
		IL_0cd4:
		ProCamera2D proCamera2D20 = base.ProCamera2D;
		bool flag53 = (object)proCamera2D20 == null;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v756 @ rax_v22 (Com.LuisPedroFonseca.ProCamera2D.ProCamera2D)+5C]");
		float num28 = 0f * 0.5f;
		float minCameraSize = num28 / MaxZoomInAmount;
		_minCameraSize = minCameraSize;
		ProCamera2D proCamera2D21 = base.ProCamera2D;
		bool flag54 = (object)proCamera2D21 == null;
		float num29 = _targetCamSize;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v757 @ rax_v23 (Com.LuisPedroFonseca.ProCamera2D.ProCamera2D)+5C]");
		float num30 = 0f * 0.5f;
		float num31 = (_maxCameraSize = num30 * MaxZoomOutAmount);
		if (!(_minCameraSize > _targetCamSize))
		{
			if (num29 > num31)
			{
				num29 = num31;
			}
		}
		else
		{
			num29 = _minCameraSize;
		}
		_targetCamSize = num29;
		return;
		IL_0e02:
		_targetCamSize = targetCamSize;
		goto IL_0cd4;
	}

	public ProCamera2DZoomToFitTargets()
	{
		//IL_0062: Expected I, but got O
		ZoomOutBorder = 0.6f;
		ZoomInBorder = 0.4f;
		ZoomInSmoothness = 2f;
		ZoomOutSmoothness = 1f;
		MaxZoomInAmount = 2f;
		MaxZoomOutAmount = 4f;
		DisableWhenOneTarget = true;
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
