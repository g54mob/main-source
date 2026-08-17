using System;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using UnityEngine;

namespace Com.LuisPedroFonseca.ProCamera2D;

public class MoveInColliderBoundaries
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static Func<Vector3, float> _003C_003E9__20_0;

		public static Func<Vector3, float> _003C_003E9__20_1;

		public static Func<float, float, Vector3> _003C_003E9__20_2;

		public static Func<Vector3, float> _003C_003E9__20_3;

		public static Func<Vector3, float> _003C_003E9__20_4;

		public static Func<float, float, Vector3> _003C_003E9__20_5;

		public static Func<Vector3, float> _003C_003E9__20_6;

		public static Func<Vector3, float> _003C_003E9__20_7;

		public static Func<float, float, Vector3> _003C_003E9__20_8;

		static _003C_003Ec()
		{
			_003C_003Ec obj = new _003C_003Ec();
			_003C_003E9 = obj;
		}

		internal float _003C_002Ector_003Eb__20_0(Vector3 vector)
		{
			return vector.x;
		}

		internal float _003C_002Ector_003Eb__20_1(Vector3 vector)
		{
			return vector.y;
		}

		internal unsafe Vector3 _003C_002Ector_003Eb__20_2(float h, float v)
		{
			//IL_0008: Expected native int or pointer, but got O
			//IL_0015: Expected native int or pointer, but got O
			//IL_0023: Expected native int or pointer, but got O
			Vector3 vector = default(Vector3);
			((Vector3*)(nint)vector)->x = h;
			((Vector3*)(nint)vector)->y = v;
			((Vector3*)(nint)vector)->z = 0f;
			return vector;
		}

		internal float _003C_002Ector_003Eb__20_3(Vector3 vector)
		{
			return vector.x;
		}

		internal float _003C_002Ector_003Eb__20_4(Vector3 vector)
		{
			return vector.z;
		}

		internal unsafe Vector3 _003C_002Ector_003Eb__20_5(float h, float v)
		{
			//IL_0008: Expected native int or pointer, but got O
			//IL_0015: Expected native int or pointer, but got O
			//IL_0023: Expected native int or pointer, but got O
			Vector3 vector = default(Vector3);
			((Vector3*)(nint)vector)->x = h;
			((Vector3*)(nint)vector)->z = v;
			((Vector3*)(nint)vector)->y = 0f;
			return vector;
		}

		internal float _003C_002Ector_003Eb__20_6(Vector3 vector)
		{
			return vector.z;
		}

		internal float _003C_002Ector_003Eb__20_7(Vector3 vector)
		{
			return vector.y;
		}

		internal unsafe Vector3 _003C_002Ector_003Eb__20_8(float h, float v)
		{
			//IL_0008: Expected native int or pointer, but got O
			//IL_0015: Expected native int or pointer, but got O
			//IL_0023: Expected native int or pointer, but got O
			Vector3 vector = default(Vector3);
			((Vector3*)(nint)vector)->y = v;
			((Vector3*)(nint)vector)->z = h;
			((Vector3*)(nint)vector)->x = 0f;
			return vector;
		}
	}

	private Func<Vector3, float> Vector3H;

	private Func<Vector3, float> Vector3V;

	private Func<float, float, Vector3> VectorHV;

	private const float Offset = 0.2f;

	private const float RaySizeCompensation = 0.2f;

	public Transform CameraTransform;

	public Vector2 CameraSize;

	public LayerMask CameraCollisionMask;

	public int TotalHorizontalRays;

	public int TotalVerticalRays;

	private RaycastOrigins _raycastOrigins;

	private CameraCollisionState _cameraCollisionState;

	private RaycastHit _raycastHit;

	private float _verticalDistanceBetweenRays;

	private float _horizontalDistanceBetweenRays;

	private ProCamera2D _proCamera2D;

	public unsafe RaycastOrigins RaycastOrigins
	{
		get
		{
			//IL_000a: Expected native int or pointer, but got O
			RaycastOrigins raycastOrigins = default(RaycastOrigins);
			((RaycastOrigins*)(nint)raycastOrigins)->TopRight = (Vector3)_raycastOrigins;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rdx (Com.LuisPedroFonseca.ProCamera2D.MoveInColliderBoundaries)+54]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rdx (Com.LuisPedroFonseca.ProCamera2D.MoveInColliderBoundaries)+64]");
			_ = 0;
			return raycastOrigins;
		}
	}

	public CameraCollisionState CameraCollisionState => _cameraCollisionState;

	public MoveInColliderBoundaries(ProCamera2D proCamera2D)
	{
		//IL_0049: Expected O, but got I4
		TotalHorizontalRays = 3;
		TotalVerticalRays = 3;
		_proCamera2D = proCamera2D;
		ProCamera2D proCamera2D2 = _proCamera2D;
		bool flag = proCamera2D2.Axis == MovementAxis.XY;
		if (!flag)
		{
			object obj = proCamera2D2.Axis - 1;
			if (!flag)
			{
				if ((nint)obj == 1)
				{
					Func<Vector3, float> vector3H = _003C_003Ec._003C_003E9__20_6;
					if (_003C_003Ec._003C_003E9__20_6 == null)
					{
						Func<Vector3, float> func = null;
						float num = ((_003C_003Ec)(object)func)._003C_002Ector_003Eb__20_6((Vector3)_003C_003Ec._003C_003E9);
						_003C_003Ec._003C_003E9__20_6 = func;
						vector3H = func;
					}
					Vector3H = vector3H;
					Func<Vector3, float> vector3V = _003C_003Ec._003C_003E9__20_7;
					if (_003C_003Ec._003C_003E9__20_7 == null)
					{
						Func<Vector3, float> func2 = null;
						float num2 = ((_003C_003Ec)(object)func2)._003C_002Ector_003Eb__20_7((Vector3)_003C_003Ec._003C_003E9);
						_003C_003Ec._003C_003E9__20_7 = func2;
						vector3V = func2;
					}
					Vector3V = vector3V;
					Func<float, float, Vector3> vectorHV = _003C_003Ec._003C_003E9__20_8;
					if (_003C_003Ec._003C_003E9__20_8 == null)
					{
						Func<float, float, Vector3> func3 = null;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1809B7230");
						_003C_003Ec._003C_003E9__20_8 = func3;
						vectorHV = func3;
					}
					VectorHV = vectorHV;
				}
			}
			else
			{
				Func<Vector3, float> vector3H2 = _003C_003Ec._003C_003E9__20_3;
				if (_003C_003Ec._003C_003E9__20_3 == null)
				{
					Func<Vector3, float> func4 = null;
					float num3 = ((_003C_003Ec)(object)func4)._003C_002Ector_003Eb__20_3((Vector3)_003C_003Ec._003C_003E9);
					_003C_003Ec._003C_003E9__20_3 = func4;
					vector3H2 = func4;
				}
				Vector3H = vector3H2;
				Func<Vector3, float> vector3V2 = _003C_003Ec._003C_003E9__20_4;
				if (_003C_003Ec._003C_003E9__20_4 == null)
				{
					Func<Vector3, float> func5 = null;
					float num4 = ((_003C_003Ec)(object)func5)._003C_002Ector_003Eb__20_4((Vector3)_003C_003Ec._003C_003E9);
					_003C_003Ec._003C_003E9__20_4 = func5;
					vector3V2 = func5;
				}
				Vector3V = vector3V2;
				Func<float, float, Vector3> vectorHV2 = _003C_003Ec._003C_003E9__20_5;
				if (_003C_003Ec._003C_003E9__20_5 == null)
				{
					Func<float, float, Vector3> func6 = null;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1809B7230");
					_003C_003Ec._003C_003E9__20_5 = func6;
					vectorHV2 = func6;
				}
				VectorHV = vectorHV2;
			}
		}
		else
		{
			Func<Vector3, float> vector3H3 = _003C_003Ec._003C_003E9__20_0;
			if (_003C_003Ec._003C_003E9__20_0 == null)
			{
				Func<Vector3, float> func7 = null;
				float num5 = ((_003C_003Ec)(object)func7)._003C_002Ector_003Eb__20_0((Vector3)_003C_003Ec._003C_003E9);
				_003C_003Ec._003C_003E9__20_0 = func7;
				vector3H3 = func7;
			}
			Vector3H = vector3H3;
			Func<Vector3, float> vector3V3 = _003C_003Ec._003C_003E9__20_1;
			if (_003C_003Ec._003C_003E9__20_1 == null)
			{
				Func<Vector3, float> func8 = null;
				float num6 = ((_003C_003Ec)(object)func8)._003C_002Ector_003Eb__20_1((Vector3)_003C_003Ec._003C_003E9);
				_003C_003Ec._003C_003E9__20_1 = func8;
				vector3V3 = func8;
			}
			Vector3V = vector3V3;
			Func<float, float, Vector3> vectorHV3 = _003C_003Ec._003C_003E9__20_2;
			if (_003C_003Ec._003C_003E9__20_2 == null)
			{
				Func<float, float, Vector3> func9 = null;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1809B7230");
				_003C_003Ec._003C_003E9__20_2 = func9;
				vectorHV3 = func9;
			}
			VectorHV = vectorHV3;
		}
	}

	public unsafe Vector3 Move(Vector3 deltaMovement)
	{
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Expected Ref, but got Unknown
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		//IL_0067: Expected Ref, but got Unknown
		//IL_0070: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Expected O, but got Unknown
		//IL_00b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b8: Expected Ref, but got Unknown
		//IL_00c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c6: Expected O, but got Unknown
		//IL_0109: Unknown result type (might be due to invalid IL or missing references)
		//IL_010e: Expected Ref, but got Unknown
		//IL_0117: Unknown result type (might be due to invalid IL or missing references)
		//IL_011c: Expected O, but got Unknown
		//IL_0180: Unknown result type (might be due to invalid IL or missing references)
		//IL_0185: Expected O, but got Unknown
		//IL_01be: Invalid comparison between F4 and I4
		//IL_01d7: Expected F4, but got I4
		//IL_026f: Expected O, but got I
		//IL_0278: Unknown result type (might be due to invalid IL or missing references)
		//IL_027d: Expected O, but got Unknown
		//IL_02b1: Invalid comparison between F4 and I4
		//IL_02ca: Expected F4, but got I4
		//IL_0217: Unknown result type (might be due to invalid IL or missing references)
		//IL_021c: Expected O, but got Unknown
		//IL_0371: Unknown result type (might be due to invalid IL or missing references)
		//IL_0376: Expected O, but got Unknown
		//IL_038d: Expected F4, but got O
		//IL_0388: Expected native int or pointer, but got O
		//IL_03a2: Expected F4, but got I
		//IL_039d: Expected native int or pointer, but got O
		//IL_030a: Unknown result type (might be due to invalid IL or missing references)
		//IL_030f: Expected O, but got Unknown
		//IL_0363: Expected O, but got I4
		UpdateRaycastOrigins();
		ref bool horizontalCheck = ref *(bool*)(this + 121);
		object obj = default(object);
		Vector3 rayTargetPos = (Vector3)(obj - 48);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rdx (Com.LuisPedroFonseca.ProCamera2D.MoveInColliderBoundaries)+70]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rdx (Com.LuisPedroFonseca.ProCamera2D.MoveInColliderBoundaries)+68]");
		_ = 0;
		ref bool verticalCheck = default(ref bool);
		float hSign = default(float);
		float vSign = default(float);
		GetOffsetAndForceMovement(rayTargetPos, ref *(Vector3*)deltaMovement, ref horizontalCheck, ref verticalCheck, hSign, vSign);
		ref bool horizontalCheck2 = ref *(bool*)(this + 123);
		Vector3 rayTargetPos2 = (Vector3)(obj - 48);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rdx (Com.LuisPedroFonseca.ProCamera2D.MoveInColliderBoundaries)+64]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rdx (Com.LuisPedroFonseca.ProCamera2D.MoveInColliderBoundaries)+5C]");
		_ = 0;
		GetOffsetAndForceMovement(rayTargetPos2, ref *(Vector3*)deltaMovement, ref horizontalCheck2, ref verticalCheck, hSign, vSign);
		ref bool horizontalCheck3 = ref *(bool*)(this + 117);
		Vector3 rayTargetPos3 = (Vector3)(obj - 48);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rdx (Com.LuisPedroFonseca.ProCamera2D.MoveInColliderBoundaries)+58]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rdx (Com.LuisPedroFonseca.ProCamera2D.MoveInColliderBoundaries)+50]");
		_ = 0;
		GetOffsetAndForceMovement(rayTargetPos3, ref *(Vector3*)deltaMovement, ref horizontalCheck3, ref verticalCheck, hSign, vSign);
		ref bool horizontalCheck4 = ref *(bool*)(this + 119);
		Vector3 rayTargetPos4 = (Vector3)(obj - 48);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rdx (Com.LuisPedroFonseca.ProCamera2D.MoveInColliderBoundaries)+4C]");
		_ = 0;
		_ = _raycastOrigins;
		GetOffsetAndForceMovement(rayTargetPos4, ref *(Vector3*)deltaMovement, ref horizontalCheck4, ref verticalCheck, hSign, vSign);
		Func<Vector3, float> vector3H = Vector3H;
		if (Vector3H != null)
		{
			object obj2 = obj - 48;
			float num = deltaMovement.x;
			_ = deltaMovement.x;
			_ = deltaMovement.z;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v75 @ rcx_v6 (System.Func`2<UnityEngine.Vector3, System.Single>)+18] (should have been resolved before IL gen)");
			bool flag = deltaMovement.x == 0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 00000001851A58BCh\"");
			float num2 = 0f;
			if (!flag)
			{
				Func<Vector3, float> vector3H2 = Vector3H;
				if (Vector3H == null)
				{
					goto IL_03a7;
				}
				object obj3 = obj - 48;
				_ = deltaMovement.x;
				_ = deltaMovement.z;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v187 @ rcx_v17 (System.Func`2<UnityEngine.Vector3, System.Single>)+18] (should have been resolved before IL gen)");
				num = MoveInAxis(deltaMovement.x, isHorizontal: true);
				num2 = num;
			}
			Func<Vector3, float> vector3V = Vector3V;
			if (Vector3V != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v189 @ rcx_v10 (System.Func`2<UnityEngine.Vector3, System.Single>)+18]");
				object obj4 = 0;
				object obj5 = obj - 48;
				float x = deltaMovement.x;
				_ = deltaMovement.x;
				_ = deltaMovement.z;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v189 @ rcx_v10 (System.Func`2<UnityEngine.Vector3, System.Single>)+18] (should have been resolved before IL gen)");
				bool flag2 = num == 0f;
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 00000001851A5935h\"");
				float num3 = 0f;
				if (!flag2)
				{
					Func<Vector3, float> vector3V2 = Vector3V;
					if (Vector3V == null)
					{
						goto IL_03a7;
					}
					object obj6 = obj - 48;
					_ = deltaMovement.x;
					_ = deltaMovement.z;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v188 @ rcx_v14 (System.Func`2<UnityEngine.Vector3, System.Single>)+18] (should have been resolved before IL gen)");
					num = MoveInAxis(deltaMovement.x, isHorizontal: false);
					x = deltaMovement.x;
					num3 = num;
					obj4 = 0;
				}
				Func<float, float, Vector3> vectorHV = VectorHV;
				if (VectorHV != null)
				{
					object obj7 = obj - 48;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v185 @ rdx_v11 (System.Func`3<System.Single, System.Single, UnityEngine.Vector3>)+18] (should have been resolved before IL gen)");
					Vector3 vector = default(Vector3);
					object obj8 = default(object);
					((Vector3*)(nint)vector)->x = (float)obj8;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v300 @ rax_v23+8]");
					((Vector3*)(nint)vector)->z = 0f;
					return vector;
				}
			}
		}
		goto IL_03a7;
		IL_03a7:
		return (Vector3)new NullReferenceException();
	}

	private unsafe void UpdateRaycastOrigins()
	{
		//IL_06c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_06c5: Expected O, but got Unknown
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Expected O, but got Unknown
		//IL_072c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0731: Expected O, but got Unknown
		//IL_00bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c4: Expected O, but got Unknown
		//IL_0110: Unknown result type (might be due to invalid IL or missing references)
		//IL_0115: Expected O, but got Unknown
		//IL_079b: Unknown result type (might be due to invalid IL or missing references)
		//IL_07a0: Expected O, but got Unknown
		//IL_01d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01de: Expected O, but got Unknown
		//IL_080a: Unknown result type (might be due to invalid IL or missing references)
		//IL_080f: Expected O, but got Unknown
		//IL_0248: Unknown result type (might be due to invalid IL or missing references)
		//IL_024d: Expected O, but got Unknown
		//IL_0299: Unknown result type (might be due to invalid IL or missing references)
		//IL_029e: Expected O, but got Unknown
		//IL_0879: Unknown result type (might be due to invalid IL or missing references)
		//IL_087e: Expected O, but got Unknown
		//IL_0362: Unknown result type (might be due to invalid IL or missing references)
		//IL_0367: Expected O, but got Unknown
		//IL_08e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_08ed: Expected O, but got Unknown
		//IL_03d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d6: Expected O, but got Unknown
		//IL_0422: Unknown result type (might be due to invalid IL or missing references)
		//IL_0427: Expected O, but got Unknown
		//IL_0957: Unknown result type (might be due to invalid IL or missing references)
		//IL_095c: Expected O, but got Unknown
		//IL_04f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_04f5: Expected O, but got Unknown
		//IL_09c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_09cb: Expected O, but got Unknown
		//IL_055f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0564: Expected O, but got Unknown
		//IL_05b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_05b5: Expected O, but got Unknown
		//IL_0639: Expected O, but got I4
		//IL_0649: Expected O, but got I4
		//IL_06f1->IL0686: Incompatible stack heights: 1 vs 0
		//IL_00a7->IL0686: Incompatible stack heights: 1 vs 0
		//IL_0760->IL0686: Incompatible stack heights: 2 vs 0
		//IL_0102->IL0686: Incompatible stack heights: 2 vs 0
		//IL_01c1->IL0686: Incompatible stack heights: 2 vs 0
		//IL_07cf->IL0686: Incompatible stack heights: 3 vs 0
		//IL_0230->IL0686: Incompatible stack heights: 3 vs 0
		//IL_083e->IL0686: Incompatible stack heights: 4 vs 0
		//IL_028b->IL0686: Incompatible stack heights: 4 vs 0
		//IL_034a->IL0686: Incompatible stack heights: 4 vs 0
		//IL_08ad->IL0686: Incompatible stack heights: 5 vs 0
		//IL_03b9->IL0686: Incompatible stack heights: 5 vs 0
		//IL_091c->IL0686: Incompatible stack heights: 6 vs 0
		//IL_0414->IL0686: Incompatible stack heights: 6 vs 0
		//IL_04d8->IL0686: Incompatible stack heights: 6 vs 0
		//IL_098b->IL0686: Incompatible stack heights: 7 vs 0
		//IL_0547->IL0686: Incompatible stack heights: 7 vs 0
		//IL_09fa->IL0686: Incompatible stack heights: 8 vs 0
		//IL_05a2->IL0686: Incompatible stack heights: 8 vs 0
		Transform cameraTransform = CameraTransform;
		Func<float, float, Vector3> vectorHV = VectorHV;
		Func<Vector3, float> vector3H = Vector3H;
		if ((object)CameraTransform != null)
		{
			_ = 0;
			_ = 0;
			bool flag = ((UnityEngine.Object)cameraTransform).m_CachedPtr == (IntPtr)0;
			object obj2 = default(object);
			object obj = obj2 - 80;
			Transform.get_localPosition_Injected(((UnityEngine.Object)cameraTransform).m_CachedPtr, out *(Vector3*)obj);
			if (Vector3H != null)
			{
				object obj3 = obj2 - 64;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v13 @ rsp-50]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v13 @ rsp-48]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v18 @ rsi_v1 (System.Func`2<UnityEngine.Vector3, System.Single>)+18] (should have been resolved before IL gen)");
				Func<Vector3, float> cameraTransform2 = (Func<Vector3, float>)(object)CameraTransform;
				Transform vector3V = (Transform)(object)Vector3V;
				if ((object)CameraTransform != null)
				{
					_ = 0;
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v407 @ rsi_v19 (System.Func`2<UnityEngine.Vector3, System.Single>)+10]");
					bool flag2 = (nint)0 == 0;
					object obj4 = obj2 - 80;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v407 @ rsi_v19 (System.Func`2<UnityEngine.Vector3, System.Single>)+10]");
					Transform.get_localPosition_Injected((IntPtr)0, out *(Vector3*)obj4);
					if (Vector3V != null)
					{
						object obj5 = obj2 - 64;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v13 @ rsp-50]");
						_ = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v13 @ rsp-48]");
						_ = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v419 @ rdi_v19 (UnityEngine.Transform)+18] (should have been resolved before IL gen)");
						if (VectorHV != null)
						{
							object obj6 = obj2 - 64;
							float num = (float)CameraSize * 0.5f;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Com.LuisPedroFonseca.ProCamera2D.MoveInColliderBoundaries)+34]");
							float num2 = 0f * 0.5f;
							float num3 = num;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v13 @ rsp-50]");
							float num4 = num3 + 0f;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v13 @ rsp-50]");
							float num5 = 0f - num2;
							Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v17 @ r15_v1 (System.Func`3<System.Single, System.Single, UnityEngine.Vector3>)+18] (should have been resolved before IL gen)");
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v159 @ rax_v58+8]");
							_ = 0;
							object cameraTransform3 = CameraTransform;
							Func<float, float, Vector3> vectorHV2 = VectorHV;
							Transform vector3H2 = (Transform)(object)Vector3H;
							if ((object)CameraTransform != null)
							{
								_ = 0;
								_ = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ r14_v20 (System.Object)+10]");
								bool flag3 = (nint)0 == 0;
								object obj7 = obj2 - 80;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ r14_v20 (System.Object)+10]");
								Transform.get_localPosition_Injected((IntPtr)0, out *(Vector3*)obj7);
								if (Vector3H != null)
								{
									object obj8 = obj2 - 64;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v13 @ rsp-50]");
									_ = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v13 @ rsp-48]");
									_ = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v420 @ rdi_v20 (UnityEngine.Transform)+18] (should have been resolved before IL gen)");
									Func<Vector3, float> cameraTransform4 = (Func<Vector3, float>)(object)CameraTransform;
									Transform vector3V2 = (Transform)(object)Vector3V;
									if ((object)CameraTransform != null)
									{
										_ = 0;
										_ = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v408 @ rsi_v21 (System.Func`2<UnityEngine.Vector3, System.Single>)+10]");
										bool flag4 = (nint)0 == 0;
										object obj9 = obj2 - 80;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v408 @ rsi_v21 (System.Func`2<UnityEngine.Vector3, System.Single>)+10]");
										Transform.get_localPosition_Injected((IntPtr)0, out *(Vector3*)obj9);
										if (Vector3V != null)
										{
											object obj10 = obj2 - 64;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v13 @ rsp-50]");
											_ = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v13 @ rsp-48]");
											_ = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v421 @ rdi_v21 (UnityEngine.Transform)+18] (should have been resolved before IL gen)");
											if (VectorHV != null)
											{
												object obj11 = obj2 - 64;
												float num6 = (float)CameraSize * 0.5f;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Com.LuisPedroFonseca.ProCamera2D.MoveInColliderBoundaries)+34]");
												float num7 = 0f * 0.5f;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v13 @ rsp-50]");
												float num8 = 0f - num6;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v13 @ rsp-50]");
												float num9 = 0f - num7;
												Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v415 @ r15_v19 (System.Func`3<System.Single, System.Single, UnityEngine.Vector3>)+18] (should have been resolved before IL gen)");
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v162 @ rax_v74+8]");
												_ = 0;
												object cameraTransform5 = CameraTransform;
												Func<float, float, Vector3> vectorHV3 = VectorHV;
												Transform vector3H3 = (Transform)(object)Vector3H;
												if ((object)CameraTransform != null)
												{
													_ = 0;
													_ = 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v51 @ r14_v22 (System.Object)+10]");
													bool flag5 = (nint)0 == 0;
													object obj12 = obj2 - 80;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v51 @ r14_v22 (System.Object)+10]");
													Transform.get_localPosition_Injected((IntPtr)0, out *(Vector3*)obj12);
													if (Vector3H != null)
													{
														object obj13 = obj2 - 64;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v13 @ rsp-50]");
														_ = 0;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v13 @ rsp-48]");
														_ = 0;
														Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v422 @ rdi_v22 (UnityEngine.Transform)+18] (should have been resolved before IL gen)");
														Func<Vector3, float> cameraTransform6 = (Func<Vector3, float>)(object)CameraTransform;
														Transform vector3V3 = (Transform)(object)Vector3V;
														if ((object)CameraTransform != null)
														{
															_ = 0;
															_ = 0;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v409 @ rsi_v23 (System.Func`2<UnityEngine.Vector3, System.Single>)+10]");
															bool flag6 = (nint)0 == 0;
															object obj14 = obj2 - 80;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v409 @ rsi_v23 (System.Func`2<UnityEngine.Vector3, System.Single>)+10]");
															Transform.get_localPosition_Injected((IntPtr)0, out *(Vector3*)obj14);
															if (Vector3V != null)
															{
																object obj15 = obj2 - 64;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v13 @ rsp-50]");
																_ = 0;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v13 @ rsp-48]");
																_ = 0;
																Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v423 @ rdi_v23 (UnityEngine.Transform)+18] (should have been resolved before IL gen)");
																if (VectorHV != null)
																{
																	object obj16 = obj2 - 64;
																	float num10 = (float)CameraSize * 0.5f;
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Com.LuisPedroFonseca.ProCamera2D.MoveInColliderBoundaries)+34]");
																	float num11 = 0f * 0.5f;
																	float num12 = num10;
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v13 @ rsp-50]");
																	float num13 = num12 + 0f;
																	float num14 = num11;
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v13 @ rsp-50]");
																	float num15 = num14 + 0f;
																	Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v416 @ r15_v20 (System.Func`3<System.Single, System.Single, UnityEngine.Vector3>)+18] (should have been resolved before IL gen)");
																	object raycastOrigins = default(object);
																	_raycastOrigins = (RaycastOrigins)raycastOrigins;
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v165 @ rax_v90+8]");
																	_ = 0;
																	object cameraTransform7 = CameraTransform;
																	Func<float, float, Vector3> vectorHV4 = VectorHV;
																	Transform vector3H4 = (Transform)(object)Vector3H;
																	if ((object)CameraTransform != null)
																	{
																		_ = 0;
																		_ = 0;
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v53 @ r14_v24 (System.Object)+10]");
																		bool flag7 = (nint)0 == 0;
																		object obj17 = obj2 - 80;
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v53 @ r14_v24 (System.Object)+10]");
																		Transform.get_localPosition_Injected((IntPtr)0, out *(Vector3*)obj17);
																		if (Vector3H != null)
																		{
																			object obj18 = obj2 - 64;
																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v13 @ rsp-50]");
																			_ = 0;
																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v13 @ rsp-48]");
																			_ = 0;
																			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v424 @ rdi_v24 (UnityEngine.Transform)+18] (should have been resolved before IL gen)");
																			Func<Vector3, float> cameraTransform8 = (Func<Vector3, float>)(object)CameraTransform;
																			Transform vector3V4 = (Transform)(object)Vector3V;
																			if ((object)CameraTransform != null)
																			{
																				_ = 0;
																				_ = 0;
																				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v410 @ rsi_v25 (System.Func`2<UnityEngine.Vector3, System.Single>)+10]");
																				bool flag8 = (nint)0 == 0;
																				object obj19 = obj2 - 80;
																				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v410 @ rsi_v25 (System.Func`2<UnityEngine.Vector3, System.Single>)+10]");
																				Transform.get_localPosition_Injected((IntPtr)0, out *(Vector3*)obj19);
																				if (Vector3V != null)
																				{
																					object obj20 = obj2 - 64;
																					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v13 @ rsp-50]");
																					_ = 0;
																					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v13 @ rsp-48]");
																					_ = 0;
																					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v425 @ rdi_v25 (UnityEngine.Transform)+18] (should have been resolved before IL gen)");
																					if (VectorHV != null)
																					{
																						object obj21 = obj2 - 64;
																						float num16 = (float)CameraSize * 0.5f;
																						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Com.LuisPedroFonseca.ProCamera2D.MoveInColliderBoundaries)+34]");
																						float num17 = 0f * 0.5f;
																						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v13 @ rsp-50]");
																						float num18 = 0f - num16;
																						float num19 = num17;
																						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v13 @ rsp-50]");
																						float num20 = num19 + 0f;
																						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v417 @ r15_v21 (System.Func`3<System.Single, System.Single, UnityEngine.Vector3>)+18] (should have been resolved before IL gen)");
																						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1507 @ rax_v106+8]");
																						_ = 0;
																						object obj22 = TotalVerticalRays - 1;
																						object obj23 = TotalHorizontalRays - 1;
																						float horizontalDistanceBetweenRays = (float)CameraSize / (float)obj22;
																						_horizontalDistanceBetweenRays = horizontalDistanceBetweenRays;
																						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Com.LuisPedroFonseca.ProCamera2D.MoveInColliderBoundaries)+34]");
																						float verticalDistanceBetweenRays = 0f / (float)obj23;
																						_verticalDistanceBetweenRays = verticalDistanceBetweenRays;
																						return;
																					}
																				}
																			}
																		}
																	}
																}
															}
														}
													}
												}
											}
										}
									}
								}
							}
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	private unsafe void GetOffsetAndForceMovement(Vector3 rayTargetPos, ref Vector3 deltaMovement, ref bool horizontalCheck, ref bool verticalCheck, float hSign, float vSign)
	{
		//IL_0008: Expected O, but got Ref
		//IL_0025: Expected O, but got Ref
		//IL_0085: Expected O, but got Ref
		//IL_00c7: Expected O, but got Ref
		//IL_00e1: Expected O, but got I
		//IL_00fe: Expected O, but got I
		//IL_0116: Expected O, but got Ref
		//IL_012e: Invalid comparison between O and F4
		//IL_09bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_09c1: Expected O, but got Unknown
		//IL_09de: Expected O, but got I
		//IL_09ec: Expected O, but got Ref
		//IL_0a54: Expected O, but got Ref
		//IL_0a67: Expected O, but got Ref
		//IL_0a94: Expected O, but got Ref
		//IL_0941: Expected I, but got O
		//IL_0961: Expected O, but got I
		//IL_019e: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a3: Expected Ref, but got Unknown
		//IL_01b1: Expected O, but got Ref
		//IL_01bf: Expected O, but got Ref
		//IL_01cd: Expected O, but got Ref
		//IL_0215: Expected O, but got I
		//IL_0227: Expected O, but got I4
		//IL_0263: Expected O, but got Ref
		//IL_02ae: Expected O, but got I
		//IL_02db: Expected O, but got Ref
		//IL_031c: Expected O, but got I
		//IL_032c: Expected O, but got I
		//IL_0364: Expected O, but got I4
		//IL_061d: Expected O, but got Ref
		//IL_039b: Expected O, but got Ref
		//IL_06ae: Expected O, but got Ref
		//IL_042c: Expected O, but got Ref
		//IL_06fc: Expected O, but got Ref
		//IL_047a: Expected O, but got Ref
		//IL_0777: Expected O, but got Ref
		//IL_079a: Expected F4, but got O
		//IL_04f5: Expected O, but got Ref
		//IL_0518: Expected F4, but got O
		//IL_07e1: Expected O, but got I
		//IL_07ef: Expected O, but got Ref
		//IL_055f: Expected O, but got I
		//IL_056d: Expected O, but got Ref
		//IL_0983: Expected O, but got Ref
		//IL_08df->IL0851: Incompatible stack heights: 1 vs 0
		//IL_0068->IL0851: Incompatible stack heights: 1 vs 0
		//IL_092e->IL0851: Incompatible stack heights: 2 vs 0
		//IL_00b4->IL0851: Incompatible stack heights: 2 vs 0
		//IL_0250->IL0851: Incompatible stack heights: 2 vs 0
		//IL_02c8->IL0851: Incompatible stack heights: 2 vs 0
		//IL_060a->IL0851: Incompatible stack heights: 2 vs 0
		//IL_0388->IL0851: Incompatible stack heights: 2 vs 0
		//IL_069b->IL0851: Incompatible stack heights: 2 vs 0
		//IL_0419->IL0851: Incompatible stack heights: 2 vs 0
		//IL_06e9->IL0851: Incompatible stack heights: 2 vs 0
		//IL_0467->IL0851: Incompatible stack heights: 2 vs 0
		//IL_0757->IL0851: Incompatible stack heights: 2 vs 0
		//IL_04d5->IL0851: Incompatible stack heights: 2 vs 0
		//IL_07cc->IL0851: Incompatible stack heights: 2 vs 0
		//IL_054a->IL0851: Incompatible stack heights: 2 vs 0
		//IL_0837->IL0851: Incompatible stack heights: 2 vs 0
		//IL_05b5->IL0851: Incompatible stack heights: 2 vs 0
		object obj2 = default(object);
		object obj = (object)(&obj2);
		Transform cameraTransform = CameraTransform;
		Func<float, float, Vector3> vectorHV = VectorHV;
		Func<Vector3, float> vector3H = Vector3H;
		ref Vector3 reference2;
		if ((object)CameraTransform != null)
		{
			bool flag = ((UnityEngine.Object)cameraTransform).m_CachedPtr == (IntPtr)0;
			Transform.get_localPosition_Injected(((UnityEngine.Object)cameraTransform).m_CachedPtr, out Vector3 ret);
			if (Vector3H != null)
			{
				object obj3 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 121));
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v49 @ rsi_v1 (System.Func`2<UnityEngine.Vector3, System.Single>)+18] (should have been resolved before IL gen)");
				Transform cameraTransform2 = CameraTransform;
				Func<Vector3, float> vector3V = Vector3V;
				if ((object)CameraTransform != null)
				{
					bool flag2 = ((UnityEngine.Object)cameraTransform2).m_CachedPtr == (IntPtr)0;
					Transform.get_localPosition_Injected(((UnityEngine.Object)cameraTransform2).m_CachedPtr, out ret);
					if (Vector3V != null)
					{
						object obj4 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 121));
						_ = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v162 @ rsi_v7 (System.Func`2<UnityEngine.Vector3, System.Single>)+18] (should have been resolved before IL gen)");
						if (VectorHV != null)
						{
							object obj5 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 121));
							Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v48 @ r13_v1 (System.Func`3<System.Single, System.Single, UnityEngine.Vector3>)+18] (should have been resolved before IL gen)");
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v16 @ rbp_v1+4F]");
							object obj6 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v878 @ r14_v8+8]");
							nint num = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v877 @ rax_v29+8]");
							object obj7 = num - 0;
							object obj8 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 121));
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182C6C6E0");
							Vector3 vector = default(Vector3);
							object obj10;
							if (System.Runtime.CompilerServices.Unsafe.As<Vector3, UIntPtr>(ref vector) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)1E-05f))
							{
								object obj9 = obj7 / (object)vector;
								ret = vector;
								obj10 = obj9;
							}
							else
							{
								nint num2 = (nint)typeof(Vector3);
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v956 @ rax_v74 (Il2CppClass<UnityEngine.Vector3>)+B8]");
								nint num3 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v957 @ rcx_v62 (Il2CppStaticFields<UnityEngine.Vector3>)+8]");
								obj10 = 0;
								ret = Vector3.zeroVector;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v16 @ rbp_v1-65]");
							object obj11 = vector - 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v878 @ r14_v8+8]");
							nint num4 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v877 @ rax_v29+8]");
							object obj12 = num4 - 0;
							object obj13 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 105));
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1829A8670");
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v877 @ rax_v29+8]");
							float num5 = 0f + 0.01f;
							float num6 = num5 + 0.5f;
							object obj14 = default(object);
							float num7 = (float)obj14 * num6;
							float num8 = (float)obj10 * num6;
							Vector3 dir = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 105));
							Vector3 start = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 121));
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v877 @ rax_v29+8]");
							_ = 0;
							float num9 = default(float);
							DrawRay(start, dir, (Color)(&ret), num9);
							PhysicsScene defaultPhysicsScene = Physics.defaultPhysicsScene;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v877 @ rax_v29+8]");
							_ = 0;
							ref RaycastHit hitInfo = ref *(RaycastHit*)(this + 124);
							Vector3 direction = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 105));
							Vector3 origin = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 121));
							PhysicsScene physicsScene = (PhysicsScene)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 71));
							int layerMask = default(int);
							QueryTriggerInteraction queryTriggerInteraction = default(QueryTriggerInteraction);
							if (!((PhysicsScene*)physicsScene)->Raycast(origin, direction, out hitInfo, num9, layerMask, queryTriggerInteraction))
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v16 @ rbp_v1+67]");
								object obj15 = 0;
								ref bool reference = ref *(bool*)null;
								obj15 = 0;
								return;
							}
							Func<Vector3, float> vector3H2 = Vector3H;
							if (Vector3H != null)
							{
								object obj16 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 105));
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Com.LuisPedroFonseca.ProCamera2D.MoveInColliderBoundaries)+88]");
								_ = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Com.LuisPedroFonseca.ProCamera2D.MoveInColliderBoundaries)+90]");
								_ = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v263 @ rcx_v32 (System.Func`2<UnityEngine.Vector3, System.Single>)+18] (should have been resolved before IL gen)");
								Func<Vector3, float> vector3V2 = Vector3V;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Com.LuisPedroFonseca.ProCamera2D.MoveInColliderBoundaries)+88]");
								nint num10 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12890]");
								object obj17 = num10 & 0;
								if (Vector3V != null)
								{
									object obj18 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 105));
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Com.LuisPedroFonseca.ProCamera2D.MoveInColliderBoundaries)+88]");
									_ = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Com.LuisPedroFonseca.ProCamera2D.MoveInColliderBoundaries)+90]");
									_ = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v264 @ rcx_v34 (System.Func`2<UnityEngine.Vector3, System.Single>)+18] (should have been resolved before IL gen)");
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Com.LuisPedroFonseca.ProCamera2D.MoveInColliderBoundaries)+88]");
									nint num11 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12890]");
									object obj19 = num11 & 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v16 @ rbp_v1+67]");
									object obj20 = 0;
									if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj17) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj19))
									{
										bool flag3 = !horizontalCheck;
										obj20 = flag3;
										Func<Vector3, float> vector3V3 = Vector3V;
										if (Vector3V != null)
										{
											object obj21 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 105));
											_ = deltaMovement;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [deltaMovement @ r8 (UnityEngine.Vector3&)+8]");
											_ = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v265 @ rcx_v50 (System.Func`2<UnityEngine.Vector3, System.Single>)+18] (should have been resolved before IL gen)");
											Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp near ptr 00000001851A667Ch\"");
											if ((object)deltaMovement != null)
											{
												return;
											}
											Func<Vector3, float> vector3H3 = Vector3H;
											Func<float, float, Vector3> vectorHV2 = VectorHV;
											if (Vector3H != null)
											{
												object obj22 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 105));
												_ = deltaMovement;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [deltaMovement @ r8 (UnityEngine.Vector3&)+8]");
												_ = 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v266 @ rcx_v52 (System.Func`2<UnityEngine.Vector3, System.Single>)+18] (should have been resolved before IL gen)");
												if (VectorHV != null)
												{
													object obj23 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 105));
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v16 @ rbp_v1+77]");
													float num12 = 0f * 0.1f;
													Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v164 @ rsi_v14 (System.Func`3<System.Single, System.Single, UnityEngine.Vector3>)+18] (should have been resolved before IL gen)");
													object obj24 = default(object);
													reference2 = ref *(Vector3*)obj24;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v249 @ rax_v64+8]");
													_ = 0;
													Func<Vector3, float> vector3V4 = Vector3V;
													if (Vector3V != null)
													{
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v249 @ rax_v64+8]");
														_ = 0;
														object obj25 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 105));
														Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v268 @ rcx_v55 (System.Func`2<UnityEngine.Vector3, System.Single>)+18] (should have been resolved before IL gen)");
														float num13 = MoveInAxis((float)deltaMovement, isHorizontal: false);
														Func<Vector3, float> vector3H4 = Vector3H;
														Func<float, float, Vector3> vectorHV3 = VectorHV;
														if (Vector3H != null)
														{
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v269 @ rcx_v58 (System.Func`2<UnityEngine.Vector3, System.Single>)+18]");
															object obj26 = 0;
															object obj27 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 105));
															object obj28 = deltaMovement;
															_ = deltaMovement;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [deltaMovement @ r8 (UnityEngine.Vector3&)+8]");
															_ = 0;
															Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v269 @ rcx_v58 (System.Func`2<UnityEngine.Vector3, System.Single>)+18] (should have been resolved before IL gen)");
															if (VectorHV != null)
															{
																float num14 = num13;
																float num15 = num13;
																goto IL_0975;
															}
														}
													}
												}
											}
										}
									}
									else
									{
										bool flag4 = obj20 == null;
										ref bool reference = ref *(flag4 ? ((bool*)1) : ((bool*)null));
										Func<Vector3, float> vector3H5 = Vector3H;
										if (Vector3H != null)
										{
											object obj29 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 105));
											_ = deltaMovement;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [deltaMovement @ r8 (UnityEngine.Vector3&)+8]");
											_ = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v271 @ rcx_v39 (System.Func`2<UnityEngine.Vector3, System.Single>)+18] (should have been resolved before IL gen)");
											Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp near ptr 00000001851A667Ch\"");
											if ((object)deltaMovement != null)
											{
												return;
											}
											Func<Vector3, float> vector3V5 = Vector3V;
											Func<float, float, Vector3> vectorHV4 = VectorHV;
											if (Vector3V != null)
											{
												object obj30 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 105));
												_ = deltaMovement;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [deltaMovement @ r8 (UnityEngine.Vector3&)+8]");
												_ = 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v272 @ rcx_v41 (System.Func`2<UnityEngine.Vector3, System.Single>)+18] (should have been resolved before IL gen)");
												if (VectorHV != null)
												{
													object obj31 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 105));
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v16 @ rbp_v1+6F]");
													float num16 = 0f * 0.1f;
													Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v166 @ rsi_v12 (System.Func`3<System.Single, System.Single, UnityEngine.Vector3>)+18] (should have been resolved before IL gen)");
													object obj32 = default(object);
													reference2 = ref *(Vector3*)obj32;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v255 @ rax_v54+8]");
													_ = 0;
													Func<Vector3, float> vector3H6 = Vector3H;
													if (Vector3H != null)
													{
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v255 @ rax_v54+8]");
														_ = 0;
														object obj33 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 105));
														Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v274 @ rcx_v44 (System.Func`2<UnityEngine.Vector3, System.Single>)+18] (should have been resolved before IL gen)");
														float num13 = MoveInAxis((float)deltaMovement, isHorizontal: true);
														Func<Vector3, float> vector3V6 = Vector3V;
														Func<float, float, Vector3> vectorHV3 = VectorHV;
														if (Vector3V != null)
														{
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v275 @ rcx_v47 (System.Func`2<UnityEngine.Vector3, System.Single>)+18]");
															object obj26 = 0;
															object obj34 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 105));
															object obj28 = deltaMovement;
															_ = deltaMovement;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [deltaMovement @ r8 (UnityEngine.Vector3&)+8]");
															_ = 0;
															Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v275 @ rcx_v47 (System.Func`2<UnityEngine.Vector3, System.Single>)+18] (should have been resolved before IL gen)");
															if (VectorHV != null)
															{
																float num14 = num13;
																float num15 = num13;
																goto IL_0975;
															}
														}
													}
												}
											}
										}
									}
								}
							}
						}
					}
				}
			}
		}
		throw new NullReferenceException();
		IL_0975:
		object obj35 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 105));
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1100 @ rsi_v11 (System.Func`3<System.Single, System.Single, UnityEngine.Vector3>)+18] (should have been resolved before IL gen)");
		object obj36 = default(object);
		reference2 = ref *(Vector3*)obj36;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1107 @ rax_v47+8]");
		_ = 0;
	}

	private unsafe float MoveInAxis(float deltaMovement, bool isHorizontal)
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Expected O, but got Unknown
		//IL_0fe5: Invalid comparison between F4 and I4
		//IL_0ffb: Unknown result type (might be due to invalid IL or missing references)
		//IL_1000: Expected O, but got Unknown
		//IL_1033: Expected O, but got I4
		//IL_0236: Expected F4, but got I
		//IL_0246: Expected O, but got I
		//IL_01ad: Expected F4, but got I
		//IL_01bd: Expected O, but got I
		//IL_0115: Expected F4, but got I
		//IL_0125: Expected O, but got I
		//IL_0082: Expected F4, but got I
		//IL_0092: Expected O, but got I
		//IL_0272: Expected O, but got I4
		//IL_0570: Unknown result type (might be due to invalid IL or missing references)
		//IL_0575: Expected O, but got Unknown
		//IL_059d: Unknown result type (might be due to invalid IL or missing references)
		//IL_05a2: Expected O, but got Unknown
		//IL_02c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c5: Expected O, but got Unknown
		//IL_05d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_05de: Expected O, but got Unknown
		//IL_030b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0310: Expected O, but got Unknown
		//IL_032e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0333: Expected O, but got Unknown
		//IL_07aa: Expected O, but got I4
		//IL_0807: Unknown result type (might be due to invalid IL or missing references)
		//IL_080c: Expected O, but got Unknown
		//IL_0713: Expected O, but got I4
		//IL_04fc: Expected O, but got I4
		//IL_0826: Unknown result type (might be due to invalid IL or missing references)
		//IL_082b: Expected Ref, but got Unknown
		//IL_0839: Unknown result type (might be due to invalid IL or missing references)
		//IL_083e: Expected O, but got Unknown
		//IL_0847: Unknown result type (might be due to invalid IL or missing references)
		//IL_084c: Expected O, but got Unknown
		//IL_0884: Unknown result type (might be due to invalid IL or missing references)
		//IL_0889: Expected O, but got Unknown
		//IL_0956: Expected F4, but got I
		//IL_095e: Expected native int or pointer, but got O
		//IL_096c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0971: Expected O, but got Unknown
		//IL_0979: Expected native int or pointer, but got O
		//IL_09b3: Expected F4, but got I4
		//IL_09e0: Expected O, but got I
		//IL_09f8: Expected F4, but got I4
		//IL_046b: Expected O, but got I4
		//IL_08c5: Expected F4, but got I
		//IL_08ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_08d3: Expected O, but got Unknown
		//IL_08e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_08e6: Expected O, but got Unknown
		//IL_0920: Expected F4, but got I4
		//IL_0938: Expected I, but got O
		//IL_0941: Expected F4, but got I4
		//IL_0a1e: Expected F4, but got I4
		//IL_10b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_10b5: Expected O, but got Unknown
		//IL_0a50: Expected F4, but got I4
		//IL_0b41: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b46: Expected O, but got Unknown
		//IL_0b50: Expected F4, but got O
		//IL_0b78: Invalid comparison between F4 and O
		//IL_0b8b: Expected F4, but got O
		//IL_0a77: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a7c: Expected O, but got Unknown
		//IL_0a86: Expected F4, but got O
		//IL_0aae: Invalid comparison between O and F4
		//IL_0ac1: Expected F4, but got O
		//IL_0ed7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0edc: Expected O, but got Unknown
		//IL_0ee6: Expected F4, but got O
		//IL_0cef: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cf4: Expected O, but got Unknown
		//IL_0cfe: Expected F4, but got O
		//IL_0d26: Invalid comparison between F4 and O
		//IL_0d39: Expected F4, but got O
		//IL_0da0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0da5: Expected O, but got Unknown
		//IL_0daf: Expected F4, but got O
		//IL_0c25: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c2a: Expected O, but got Unknown
		//IL_0c34: Expected F4, but got O
		//IL_0c5c: Invalid comparison between O and F4
		//IL_0c6f: Expected F4, but got O
		//IL_0dff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e04: Expected O, but got Unknown
		//IL_0f8d: Expected F4, but got O
		//IL_0f98: Expected F4, but got O
		//IL_0fa0: Expected O, but got Ref
		//IL_0fa8: Expected F4, but got O
		//IL_0e76: Expected F4, but got O
		//IL_0e7f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e84: Expected O, but got Unknown
		object obj = default(object);
		Vector3 vector = (Vector3)(obj - 408);
		bool flag = deltaMovement < 0f;
		float num = deltaMovement - 0f;
		bool flag2 = num == 0f;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12890]");
		object obj2 = deltaMovement & 0;
		float num2 = (float)obj2 + 0.2f;
		bool flag3 = !flag;
		bool flag4 = !flag2;
		object obj3 = flag4 & flag3;
		float num3;
		int num4;
		float num6;
		float num8 = default(float);
		if (!isHorizontal)
		{
			if (obj3 != null)
			{
				if ((object)CameraTransform == null)
				{
					goto IL_0fb2;
				}
				Vector3 up = CameraTransform.up;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Com.LuisPedroFonseca.ProCamera2D.MoveInColliderBoundaries)+50]");
				num3 = 0f;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Com.LuisPedroFonseca.ProCamera2D.MoveInColliderBoundaries)+58]");
				object obj4 = 0;
				num4 = TotalVerticalRays;
				float num5 = deltaMovement;
				num6 = up.z;
			}
			else
			{
				if ((object)CameraTransform == null)
				{
					goto IL_0fb2;
				}
				Vector3 up2 = CameraTransform.up;
				float num7 = num8 ^ -0f;
				float num9 = up2.z ^ -0f;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Com.LuisPedroFonseca.ProCamera2D.MoveInColliderBoundaries)+68]");
				num3 = 0f;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Com.LuisPedroFonseca.ProCamera2D.MoveInColliderBoundaries)+70]");
				object obj4 = 0;
				num4 = TotalVerticalRays;
				float x = up2.x;
				float num5 = -0f;
				num6 = num9;
			}
		}
		else
		{
			if (obj3 != null)
			{
				if ((object)CameraTransform == null)
				{
					goto IL_0fb2;
				}
				Vector3 right = CameraTransform.right;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Com.LuisPedroFonseca.ProCamera2D.MoveInColliderBoundaries)+5C]");
				num3 = 0f;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Com.LuisPedroFonseca.ProCamera2D.MoveInColliderBoundaries)+64]");
				object obj4 = 0;
				float num5 = deltaMovement;
				num6 = right.z;
			}
			else
			{
				if ((object)CameraTransform == null)
				{
					goto IL_0fb2;
				}
				Vector3 right2 = CameraTransform.right;
				float num7 = num8 ^ -0f;
				float num9 = right2.z ^ -0f;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Com.LuisPedroFonseca.ProCamera2D.MoveInColliderBoundaries)+68]");
				num3 = 0f;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Com.LuisPedroFonseca.ProCamera2D.MoveInColliderBoundaries)+70]");
				object obj4 = 0;
				float x = right2.x;
				float num5 = -0f;
				num6 = num9;
			}
			num4 = TotalHorizontalRays;
		}
		_ = 0;
		bool flag5 = num4 <= 0;
		float result = deltaMovement;
		if (flag5)
		{
			goto IL_0fad;
		}
		object obj5 = 0;
		float num10 = -1f / 0f;
		float num11 = num3;
		float num12 = deltaMovement;
		bool flag6 = isHorizontal;
		object obj18 = default(object);
		int num25 = default(int);
		object obj20 = default(object);
		while (true)
		{
			Func<Vector3, float> vector3H = Vector3H;
			float num14;
			float num5;
			float num13;
			if (flag6)
			{
				if (Vector3H == null)
				{
					break;
				}
				object obj6 = vector - 128;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v303 @ rcx_v5 (System.Func`2<UnityEngine.Vector3, System.Single>)+18] (should have been resolved before IL gen)");
				Func<Vector3, float> vector3V = Vector3V;
				if (Vector3V == null)
				{
					break;
				}
				object obj7 = vector - 112;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v304 @ rcx_v42 (System.Func`2<UnityEngine.Vector3, System.Single>)+18] (should have been resolved before IL gen)");
				object obj8 = obj5 * _verticalDistanceBetweenRays;
				num5 = (float)obj8 + num11;
				if (obj3 != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Com.LuisPedroFonseca.ProCamera2D.MoveInColliderBoundaries)+7A]");
					if ((nint)0 != 0 && obj5 == null)
					{
						goto IL_0403;
					}
					num13 = num5;
					goto IL_0438;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Com.LuisPedroFonseca.ProCamera2D.MoveInColliderBoundaries)+78]");
				bool flag7 = (nint)0 == 0;
				num14 = num5;
				if (!flag7)
				{
					bool flag8 = obj5 != null;
					num14 = num5;
					if (!flag8)
					{
						goto IL_0403;
					}
				}
				goto IL_04bf;
			}
			if (Vector3H == null)
			{
				break;
			}
			object obj9 = vector - 96;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v303 @ rcx_v5 (System.Func`2<UnityEngine.Vector3, System.Single>)+18] (should have been resolved before IL gen)");
			Func<Vector3, float> vector3V2 = Vector3V;
			object obj10 = obj5 * _horizontalDistanceBetweenRays;
			float num15 = (float)obj10 + num11;
			if (Vector3V == null)
			{
				break;
			}
			object obj11 = vector - 80;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v305 @ rcx_v39 (System.Func`2<UnityEngine.Vector3, System.Single>)+18] (should have been resolved before IL gen)");
			if (obj3 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Com.LuisPedroFonseca.ProCamera2D.MoveInColliderBoundaries)+75]");
				if ((nint)0 != 0 && obj5 == null)
				{
					goto IL_06ab;
				}
				goto IL_06e0;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Com.LuisPedroFonseca.ProCamera2D.MoveInColliderBoundaries)+79]");
			bool flag9 = (nint)0 == 0;
			float num16 = num15;
			if (!flag9)
			{
				bool flag10 = obj5 != null;
				num16 = num15;
				if (!flag10)
				{
					goto IL_06ab;
				}
			}
			goto IL_0767;
			IL_052b:
			num13 = num14 + -0.2f;
			float num17 = num11;
			goto IL_107e;
			IL_0767:
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Com.LuisPedroFonseca.ProCamera2D.MoveInColliderBoundaries)+7B]");
			bool flag11 = (nint)0 == 0;
			num17 = num16;
			num13 = num11;
			if (!flag11)
			{
				object obj12 = num4 - 1;
				bool flag12 = obj5 != obj12;
				num15 = num16;
				num17 = num16;
				num13 = num11;
				if (!flag12)
				{
					goto IL_07e1;
				}
			}
			goto IL_107e;
			IL_0ca5:
			Func<Vector3, float> vector3V3 = Vector3V;
			bool flag13 = Vector3V == null;
			float num18;
			num11 = num18;
			if (flag13)
			{
				break;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v309 @ rcx_v27 (System.Func`2<UnityEngine.Vector3, System.Single>)+18]");
			nint num19 = 0;
			object obj13 = vector + 80;
			float num20 = (float)_raycastHit;
			_ = _raycastHit;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Com.LuisPedroFonseca.ProCamera2D.MoveInColliderBoundaries)+84]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v309 @ rcx_v27 (System.Func`2<UnityEngine.Vector3, System.Single>)+18] (should have been resolved before IL gen)");
			float num21 = num10;
			RaycastHit raycastHit = _raycastHit;
			bool flag14 = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num21) >= System.Runtime.CompilerServices.Unsafe.As<RaycastHit, UIntPtr>(ref raycastHit);
			num11 = (float)_raycastHit;
			if (!flag14)
			{
				goto IL_0d47;
			}
			goto IL_10a7;
			IL_07e1:
			num17 = num15 + -0.2f;
			num13 = num11;
			goto IL_107e;
			IL_0d47:
			_ = 1;
			if (flag6)
			{
				Func<Vector3, float> vector3H2 = Vector3H;
				bool flag15 = Vector3H == null;
				num11 = num20;
				if (flag15)
				{
					break;
				}
				object obj14 = vector + 96;
				num11 = (float)_raycastHit;
				_ = _raycastHit;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Com.LuisPedroFonseca.ProCamera2D.MoveInColliderBoundaries)+84]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v310 @ rcx_v21 (System.Func`2<UnityEngine.Vector3, System.Single>)+18] (should have been resolved before IL gen)");
				Func<Vector3, float> vector3H3 = Vector3H;
				if (Vector3H == null)
				{
					break;
				}
				object obj15 = vector + 112;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1235 @ rax_v9+8]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v311 @ rcx_v23 (System.Func`2<UnityEngine.Vector3, System.Single>)+18] (should have been resolved before IL gen)");
				float num22 = (float)_raycastHit - (float)_raycastHit;
				num11 = ((obj3 == null) ? 0.2f : (-0.2f));
				num12 = num22 + num11;
				Func<Vector3, float> vector3H4 = Vector3H;
				if (Vector3H == null)
				{
					break;
				}
				num11 = (float)_raycastHit;
				object obj16 = vector + 128;
				_ = _raycastHit;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Com.LuisPedroFonseca.ProCamera2D.MoveInColliderBoundaries)+84]");
				_ = 0;
			}
			else
			{
				Func<Vector3, float> vector3V4 = Vector3V;
				bool flag16 = Vector3V == null;
				num11 = num20;
				if (flag16)
				{
					break;
				}
				object obj17 = vector + 144;
				num11 = (float)_raycastHit;
				_ = _raycastHit;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Com.LuisPedroFonseca.ProCamera2D.MoveInColliderBoundaries)+84]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v312 @ rcx_v16 (System.Func`2<UnityEngine.Vector3, System.Single>)+18] (should have been resolved before IL gen)");
				Func<Vector3, float> vector3V5 = Vector3V;
				if (Vector3V == null)
				{
					break;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v313 @ rcx_v18 (System.Func`2<UnityEngine.Vector3, System.Single>)+18] (should have been resolved before IL gen)");
				float num23 = (float)_raycastHit - (float)_raycastHit;
				num11 = ((obj3 == null) ? 0.2f : (-0.2f));
				Func<Vector3, float> vector3H4 = Vector3V;
				num12 = num23 + num11;
				if (Vector3V == null)
				{
					break;
				}
				num11 = (float)_raycastHit;
				float num24 = (float)_raycastHit;
				object obj16 = (object)(&num24);
				float x = (float)obj18;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1594 @ rcx_v14 (System.Func`2<UnityEngine.Vector3, System.Single>)+18]");
			num19 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1594 @ rcx_v14 (System.Func`2<UnityEngine.Vector3, System.Single>)+18] (should have been resolved before IL gen)");
			num10 = num11;
			goto IL_10a7;
			IL_107e:
			Func<float, float, Vector3> vectorHV = VectorHV;
			if (VectorHV == null)
			{
				break;
			}
			object obj19 = vector + 176;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v225 @ rdx_v5 (System.Func`3<System.Single, System.Single, UnityEngine.Vector3>)+18] (should have been resolved before IL gen)");
			ref RaycastHit hitInfo = ref *(RaycastHit*)(this + 124);
			Vector3 direction = vector - 64;
			Vector3 origin = vector - 48;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1235 @ rax_v9+8]");
			_ = 0;
			bool flag17 = Physics.Raycast(origin, direction, out hitInfo, num2, num25);
			Color color = (Color)(vector + 160);
			num5 = (float)obj20 * num2;
			float num7 = num6 * num2;
			float num9;
			if (!flag17)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A124D0]");
				num9 = 0f;
				Vector3 dir = vector - 32;
				Vector3 start = vector - 16;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A124D0]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1235 @ rax_v9+8]");
				_ = 0;
				DrawRay(start, dir, color, num25);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v11 @ rbp_v1 (UnityEngine.Vector3)+1B0]");
				flag6 = false;
				num19 = (nint)color;
				num11 = 0f;
				goto IL_10a7;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A11F50]");
			num9 = 0f;
			((Vector3*)(nint)vector)->x = num8;
			Vector3 start2 = vector + 16;
			((Vector3*)(nint)vector)->z = num7;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A11F50]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1235 @ rax_v9+8]");
			_ = 0;
			DrawRay(start2, vector, color, num25);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v11 @ rbp_v1 (UnityEngine.Vector3)+1B0]");
			flag6 = false;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v11 @ rbp_v1 (UnityEngine.Vector3)+1B0]");
			nint num26 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v11 @ rbp_v1 (UnityEngine.Vector3)+1A8]");
			object obj21 = num26 & 0;
			bool flag18 = obj21 == null;
			float num27 = 0f;
			if (!flag18)
			{
				bool flag19 = obj3 == null;
				num27 = 0f;
				if (flag19)
				{
					goto IL_0af7;
				}
				Func<Vector3, float> vector3H5 = Vector3H;
				bool flag20 = Vector3H == null;
				num11 = 0f;
				if (flag20)
				{
					break;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v306 @ rcx_v36 (System.Func`2<UnityEngine.Vector3, System.Single>)+18]");
				num19 = 0;
				object obj22 = vector + 32;
				num27 = (float)_raycastHit;
				_ = _raycastHit;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Com.LuisPedroFonseca.ProCamera2D.MoveInColliderBoundaries)+84]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v306 @ rcx_v36 (System.Func`2<UnityEngine.Vector3, System.Single>)+18] (should have been resolved before IL gen)");
				bool flag21 = System.Runtime.CompilerServices.Unsafe.As<RaycastHit, UIntPtr>(ref _raycastHit) >= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num10);
				num11 = (float)_raycastHit;
				if (flag21)
				{
					goto IL_10a7;
				}
			}
			bool flag22 = obj3 != null;
			num18 = num27;
			if (!flag22)
			{
				goto IL_0af7;
			}
			goto IL_0b99;
			IL_10a7:
			obj5++;
			bool flag23 = (nint)obj5 < num4;
			result = num12;
			if (flag23)
			{
				continue;
			}
			goto IL_0fad;
			IL_06ab:
			num15 += 0.2f;
			bool flag24 = obj3 == null;
			num16 = num15;
			if (!flag24)
			{
				goto IL_06e0;
			}
			goto IL_0767;
			IL_0403:
			num13 = num5 + 0.2f;
			bool flag25 = obj3 == null;
			num14 = num13;
			if (!flag25)
			{
				goto IL_0438;
			}
			goto IL_04bf;
			IL_0438:
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Com.LuisPedroFonseca.ProCamera2D.MoveInColliderBoundaries)+76]");
			if ((nint)0 != 0)
			{
				object obj23 = num4 - 1;
				bool flag26 = obj5 == obj23;
				num14 = num13;
				if (flag26)
				{
					goto IL_052b;
				}
			}
			bool flag27 = obj3 != null;
			num14 = num13;
			num17 = num11;
			if (!flag27)
			{
				goto IL_04bf;
			}
			goto IL_107e;
			IL_0b99:
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v11 @ rbp_v1 (UnityEngine.Vector3)+1A8]");
			if ((nint)0 != 0)
			{
				if (obj3 == null)
				{
					goto IL_0ca5;
				}
				Func<Vector3, float> vector3V6 = Vector3V;
				bool flag28 = Vector3V == null;
				num11 = num18;
				if (flag28)
				{
					break;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v308 @ rcx_v30 (System.Func`2<UnityEngine.Vector3, System.Single>)+18]");
				num19 = 0;
				object obj24 = vector + 64;
				num18 = (float)_raycastHit;
				_ = _raycastHit;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Com.LuisPedroFonseca.ProCamera2D.MoveInColliderBoundaries)+84]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v308 @ rcx_v30 (System.Func`2<UnityEngine.Vector3, System.Single>)+18] (should have been resolved before IL gen)");
				bool flag29 = System.Runtime.CompilerServices.Unsafe.As<RaycastHit, UIntPtr>(ref _raycastHit) >= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num10);
				num11 = (float)_raycastHit;
				if (flag29)
				{
					goto IL_10a7;
				}
			}
			bool flag30 = obj3 != null;
			num20 = num18;
			if (!flag30)
			{
				goto IL_0ca5;
			}
			goto IL_0d47;
			IL_06e0:
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Com.LuisPedroFonseca.ProCamera2D.MoveInColliderBoundaries)+77]");
			if ((nint)0 != 0)
			{
				object obj25 = num4 - 1;
				if (obj5 == obj25)
				{
					goto IL_07e1;
				}
			}
			bool flag31 = obj3 != null;
			num16 = num15;
			num17 = num15;
			num13 = num11;
			if (!flag31)
			{
				goto IL_0767;
			}
			goto IL_107e;
			IL_04bf:
			bool flag32 = (object)_cameraCollisionState == null;
			num17 = num11;
			num13 = num14;
			if (!flag32)
			{
				object obj26 = num4 - 1;
				bool flag33 = obj5 != obj26;
				num17 = num11;
				num13 = num14;
				if (!flag33)
				{
					goto IL_052b;
				}
			}
			goto IL_107e;
			IL_0af7:
			Func<Vector3, float> vector3H6 = Vector3H;
			bool flag34 = Vector3H == null;
			num11 = num27;
			if (flag34)
			{
				break;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v307 @ rcx_v33 (System.Func`2<UnityEngine.Vector3, System.Single>)+18]");
			num19 = 0;
			object obj27 = vector + 48;
			num18 = (float)_raycastHit;
			_ = _raycastHit;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Com.LuisPedroFonseca.ProCamera2D.MoveInColliderBoundaries)+84]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v307 @ rcx_v33 (System.Func`2<UnityEngine.Vector3, System.Single>)+18] (should have been resolved before IL gen)");
			float num28 = num10;
			RaycastHit raycastHit2 = _raycastHit;
			bool flag35 = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num28) >= System.Runtime.CompilerServices.Unsafe.As<RaycastHit, UIntPtr>(ref raycastHit2);
			num11 = (float)_raycastHit;
			if (!flag35)
			{
				goto IL_0b99;
			}
			goto IL_10a7;
		}
		goto IL_0fb2;
		IL_0fad:
		return result;
		IL_0fb2:
		throw new NullReferenceException();
	}

	private unsafe void DrawRay(Vector3 start, Vector3 dir, Color color, float duration = 0f)
	{
		//IL_0081: Invalid comparison between F4 and I4
		//IL_0061: Expected O, but got Ref
		//IL_0069: Expected O, but got Ref
		//IL_00b6: Expected O, but got Ref
		//IL_0018: Expected F4, but got I4
		//IL_002d: Expected O, but got Ref
		//IL_0035: Expected O, but got Ref
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp near ptr 00000001851A7378h\"");
		float num = default(float);
		float duration2;
		float r;
		Vector3 dir2;
		object obj = default(object);
		Vector3 start2;
		object obj2 = default(object);
		if (num == 0f)
		{
			duration2 = 0f;
			r = color.r;
			dir2 = (Vector3)(&obj);
			start2 = (Vector3)(&obj2);
		}
		else
		{
			duration2 = num;
			r = color.r;
			dir2 = (Vector3)(&obj2);
			start2 = (Vector3)(&obj);
		}
		bool depthTest = default(bool);
		Debug.DrawRay(start2, dir2, (Color)(&r), duration2, depthTest);
	}
}
