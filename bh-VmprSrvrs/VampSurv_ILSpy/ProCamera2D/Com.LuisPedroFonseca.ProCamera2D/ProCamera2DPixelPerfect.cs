using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using UnityEngine;

namespace Com.LuisPedroFonseca.ProCamera2D;

public class ProCamera2DPixelPerfect : BasePC2D, IPositionOverrider
{
	public static string ExtensionName = "Pixel Perfect";

	public float PixelsPerUnit;

	public AutoScaleMode ViewportAutoScale;

	public Vector2 TargetViewportSizeInPixels;

	private int _zoom;

	public bool SnapMovementToGrid;

	public bool SnapCameraToGrid;

	public bool DrawGrid;

	public Color GridColor;

	public float GridDensity;

	private float _003CViewportScale_003Ek__BackingField;

	private float _pixelStep;

	private Transform _parent;

	private int _poOrder;

	public int Zoom
	{
		get
		{
			return _zoom;
		}
		set
		{
			_zoom = value;
			ResizeCameraToPixelPerfect();
		}
	}

	public float ViewportScale
	{
		get
		{
			return _003CViewportScale_003Ek__BackingField;
		}
		private set
		{
			_003CViewportScale_003Ek__BackingField = value;
		}
	}

	public float PixelStep => _pixelStep;

	public int POOrder
	{
		get
		{
			return _poOrder;
		}
		set
		{
			_poOrder = value;
		}
	}

	protected override void Awake()
	{
		//IL_00eb: Expected O, but got I4
		//IL_0098->IL00b4: Incompatible stack heights: 1 vs 0
		base.Awake();
		ProCamera2D proCamera2D = base.ProCamera2D;
		if ((object)proCamera2D != null)
		{
			Camera gameCamera = proCamera2D.GameCamera;
			if ((object)proCamera2D.GameCamera != null)
			{
				bool flag = ((UnityEngine.Object)gameCamera).m_CachedPtr == (IntPtr)0;
				object obj = Camera.get_orthographic_Injected(((UnityEngine.Object)gameCamera).m_CachedPtr);
				if (obj == null)
				{
					base.enabled = false;
					return;
				}
				ResizeCameraToPixelPerfect();
				ProCamera2D proCamera2D2 = base.ProCamera2D;
				if ((object)proCamera2D2 != null)
				{
					proCamera2D2.AddPositionOverrider(this);
					return;
				}
			}
		}
		throw new NullReferenceException();
	}

	protected override void OnDestroy()
	{
		Disable();
		ProCamera2D proCamera2D = base.ProCamera2D;
		if ((object)proCamera2D != null && ((UnityEngine.Object)proCamera2D).m_CachedPtr != (IntPtr)0)
		{
			ProCamera2D proCamera2D2 = base.ProCamera2D;
			bool flag = ((List<object>)(object)proCamera2D2._positionOverriders).Remove((object)this);
		}
	}

	public unsafe Vector3 OverridePosition(float deltaTime, Vector3 originalPosition)
	{
		//IL_0008: Expected O, but got Ref
		//IL_0589: Expected O, but got I4
		//IL_0564: Expected native int or pointer, but got O
		//IL_083c: Expected native int or pointer, but got O
		//IL_0084: Unknown result type (might be due to invalid IL or missing references)
		//IL_0089: Expected O, but got Unknown
		//IL_03ca: Expected O, but got Ref
		//IL_0479: Expected O, but got Ref
		//IL_051e: Expected O, but got Ref
		//IL_0538: Expected F4, but got I
		//IL_0545: Expected F4, but got O
		//IL_0540: Expected native int or pointer, but got O
		//IL_065f: Expected O, but got Ref
		//IL_086e: Expected I, but got O
		//IL_0895: Unknown result type (might be due to invalid IL or missing references)
		//IL_089a: Expected O, but got Unknown
		//IL_08aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_08af: Expected O, but got Unknown
		//IL_08cc: Expected O, but got I
		//IL_0689: Expected O, but got I
		//IL_06c9: Expected O, but got Ref
		//IL_01ad: Expected O, but got Ref
		//IL_0738: Expected O, but got Ref
		//IL_0279: Expected O, but got Ref
		//IL_07a7: Expected O, but got Ref
		//IL_0345: Expected O, but got Ref
		//IL_0396: Expected O, but got Ref
		//IL_080a: Expected O, but got Ref
		//IL_05c0->IL056e: Incompatible stack heights: 1 vs 0
		//IL_061f->IL056e: Incompatible stack heights: 1 vs 0
		//IL_0466->IL056e: Incompatible stack heights: 1 vs 0
		//IL_0149->IL056e: Incompatible stack heights: 1 vs 0
		//IL_050b->IL056e: Incompatible stack heights: 1 vs 0
		//IL_068e->IL05f1: Incompatible stack heights: 2 vs 1
		//IL_0190->IL056e: Incompatible stack heights: 2 vs 0
		//IL_06f8->IL056e: Incompatible stack heights: 3 vs 0
		//IL_025c->IL056e: Incompatible stack heights: 3 vs 0
		//IL_0767->IL056e: Incompatible stack heights: 4 vs 0
		//IL_0328->IL056e: Incompatible stack heights: 4 vs 0
		//IL_07d6->IL056e: Incompatible stack heights: 5 vs 0
		//IL_0383->IL056e: Incompatible stack heights: 5 vs 0
		//IL_0834->IL0679: Incompatible stack heights: 6 vs 2
		object obj2 = default(object);
		object obj = (object)(&obj2);
		float z;
		Vector3 vector2 = default(Vector3);
		float num;
		Vector3 vector3;
		if ((object)this != null)
		{
			bool flag = ((UnityEngine.Object)this).m_CachedPtr == (IntPtr)0;
			object obj3 = Behaviour.get_enabled_Injected(((UnityEngine.Object)this).m_CachedPtr);
			Vector3 vector = default(Vector3);
			if (obj3 == null)
			{
				z = vector.z;
				((Vector3*)(nint)vector2)->x = vector.x;
				goto IL_0834;
			}
			bool flag2 = !SnapMovementToGrid;
			num = _pixelStep;
			if (!flag2 && !SnapCameraToGrid)
			{
				object obj4 = _zoom + _003CViewportScale_003Ek__BackingField;
				float num2 = (float)obj4 - 1f;
				float num3 = num2 * PixelsPerUnit;
				num = 1f / num3;
			}
			if ((object)_transform != null)
			{
				Transform parent = _transform.parent;
				_parent = parent;
				Transform parent2 = _parent;
				bool flag3 = (object)_parent == null;
				vector3 = vector;
				if (!flag3)
				{
					bool flag4 = ((UnityEngine.Object)parent2).m_CachedPtr == (IntPtr)0;
					vector3 = vector;
					if (!flag4)
					{
						object parent3 = _parent;
						if ((object)_parent != null)
						{
							_ = 0;
							_ = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v183 @ rdi_v20 (System.Object)+10]");
							bool flag5 = (nint)0 == 0;
							object obj5 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 49));
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v183 @ rdi_v20 (System.Object)+10]");
							Transform.get_position_Injected((IntPtr)0, out *(Vector3*)obj5);
							nint num4 = (nint)typeof(Vector3);
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v196 @ rax_v66 (Il2CppClass<UnityEngine.Vector3>)+B8]");
							nint num5 = 0;
							_ = Vector3.zeroVector;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-31]");
							object obj6 = 0 - Vector3.zeroVector;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-2D]");
							object obj8 = default(object);
							object obj7 = 0 - obj8;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-29]");
							nint num6 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v209 @ rcx_v54 (Il2CppStaticFields<UnityEngine.Vector3>)+8]");
							object obj9 = num6 - 0;
							object obj10 = obj7 * obj7;
							float num7 = (float)obj6 * (float)obj6;
							object obj11 = obj9 * obj9;
							float num8 = (float)obj10 + num7;
							float num9 = num8 + (float)obj11;
							if (9.9999994E-11f > num9)
							{
								goto IL_0679;
							}
							object parent4 = _parent;
							Func<float, float, float, Vector3> vectorHVD = VectorHVD;
							Func<Vector3, float> vector3H = Vector3H;
							if ((object)_parent != null)
							{
								_ = 0;
								_ = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v141 @ r12_v18 (System.Object)+10]");
								bool flag6 = (nint)0 == 0;
								object obj12 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 33));
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v141 @ r12_v18 (System.Object)+10]");
								Transform.get_position_Injected((IntPtr)0, out *(Vector3*)obj12);
								if (Vector3H != null)
								{
									object obj13 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 49));
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-21]");
									_ = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-19]");
									_ = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v133 @ r14_v18 (System.Func`2<UnityEngine.Vector3, System.Single>)+18] (should have been resolved before IL gen)");
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-21]");
									float num10 = 0f / num;
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049A960");
									float num11 = num10 * num;
									float num12 = num11 / num;
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049A960");
									object parent5 = _parent;
									Func<Vector3, float> vector3V = Vector3V;
									float num13 = num12 * num;
									if ((object)_parent != null)
									{
										_ = 0;
										_ = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v184 @ rdi_v22 (System.Object)+10]");
										bool flag7 = (nint)0 == 0;
										object obj14 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 33));
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v184 @ rdi_v22 (System.Object)+10]");
										Transform.get_position_Injected((IntPtr)0, out *(Vector3*)obj14);
										if (Vector3V != null)
										{
											object obj15 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 49));
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-21]");
											_ = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-19]");
											_ = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v134 @ r14_v19 (System.Func`2<UnityEngine.Vector3, System.Single>)+18] (should have been resolved before IL gen)");
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-21]");
											float num14 = 0f / num;
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049A960");
											float num15 = num14 * num;
											float num16 = num15 / num;
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049A960");
											Vector3 parent6 = (Vector3)_parent;
											object vector3D = Vector3D;
											float num17 = num16 * num;
											if ((object)_parent != null)
											{
												_ = 0;
												_ = 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v231 @ rsi_v23 (UnityEngine.Vector3)+10]");
												bool flag8 = (nint)0 == 0;
												object obj16 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 33));
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v231 @ rsi_v23 (UnityEngine.Vector3)+10]");
												Transform.get_position_Injected((IntPtr)0, out *(Vector3*)obj16);
												if (Vector3D != null)
												{
													object obj17 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 49));
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-21]");
													_ = 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-19]");
													_ = 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v185 @ rdi_v23 (System.Object)+18] (should have been resolved before IL gen)");
													if (VectorHVD != null)
													{
														object obj18 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 49));
														Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v138 @ r13_v18 (System.Func`4<System.Single, System.Single, System.Single, UnityEngine.Vector3>)+18] (should have been resolved before IL gen)");
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1590 @ rax_v94+8]");
														_ = 0;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v141 @ r12_v18 (System.Object)+10]");
														bool flag9 = (nint)0 == 0;
														object obj19 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 33));
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v141 @ r12_v18 (System.Object)+10]");
														Transform.set_position_Injected((IntPtr)0, ref *(Vector3*)obj19);
														num7 = num13;
														num9 = num17;
														goto IL_0679;
													}
												}
											}
										}
									}
								}
							}
						}
						goto IL_056e;
					}
				}
				goto IL_05f1;
			}
		}
		goto IL_056e;
		IL_0834:
		((Vector3*)(nint)vector2)->z = z;
		return vector2;
		IL_0679:
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+77]");
		vector3 = (Vector3)0;
		goto IL_05f1;
		IL_05f1:
		Func<Vector3, float> vector3H2 = Vector3H;
		object vectorHVD2 = VectorHVD;
		if (Vector3H != null)
		{
			object obj20 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 33));
			_ = vector3.x;
			_ = vector3.z;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v216 @ rcx_v44 (System.Func`2<UnityEngine.Vector3, System.Single>)+18] (should have been resolved before IL gen)");
			float num18 = vector3.x / num;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049A960");
			float num19 = num18 * num;
			float num20 = num19 / num;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049A960");
			Func<Vector3, float> vector3V2 = Vector3V;
			float num21 = num20 * num;
			if (Vector3V != null)
			{
				object obj21 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 33));
				_ = vector3.x;
				_ = vector3.z;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v213 @ rcx_v46 (System.Func`2<UnityEngine.Vector3, System.Single>)+18] (should have been resolved before IL gen)");
				float num22 = vector3.x / num;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049A960");
				float num23 = num22 * num;
				float num24 = num23 / num;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049A960");
				float num25 = num24 * num;
				if (VectorHVD != null)
				{
					object obj22 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 33));
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v186 @ rdi_v19 (System.Object)+18] (should have been resolved before IL gen)");
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1278 @ rax_v57+8]");
					z = 0f;
					object obj23 = default(object);
					((Vector3*)(nint)vector2)->x = (float)obj23;
					goto IL_0834;
				}
			}
		}
		goto IL_056e;
		IL_056e:
		throw new NullReferenceException();
	}

	public void ResizeCameraToPixelPerfect()
	{
		//IL_0084: Unknown result type (might be due to invalid IL or missing references)
		//IL_0089: Expected I4, but got Unknown
		//IL_03d3: Expected O, but got I4
		//IL_03f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_03f5: Expected O, but got Unknown
		//IL_0322: Expected O, but got I4
		//IL_020c: Invalid comparison between F4 and I4
		//IL_0141: Unknown result type (might be due to invalid IL or missing references)
		//IL_0146: Expected O, but got Unknown
		//IL_0364: Expected F4, but got I4
		//IL_01c7: Invalid comparison between F4 and I4
		//IL_0234: Expected F4, but got I4
		//IL_034e: Expected F4, but got I4
		//IL_01ef: Expected F4, but got I4
		//IL_0187: Invalid comparison between F4 and I4
		//IL_0338: Expected F4, but got I4
		//IL_01af: Expected F4, but got I4
		//IL_0445->IL030b: Incompatible stack heights: 1 vs 0
		int num2;
		float num3;
		float num5;
		float num4;
		if (ViewportAutoScale != AutoScaleMode.None)
		{
			ProCamera2D proCamera2D = base.ProCamera2D;
			if ((object)proCamera2D != null && (object)proCamera2D.GameCamera != null)
			{
				int pixelWidth = proCamera2D.GameCamera.pixelWidth;
				int num = (int)(pixelWidth / TargetViewportSizeInPixels);
				ProCamera2D proCamera2D2 = base.ProCamera2D;
				if ((object)proCamera2D2 != null && (object)proCamera2D2.GameCamera != null)
				{
					int pixelHeight = proCamera2D2.GameCamera.pixelHeight;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Com.LuisPedroFonseca.ProCamera2D.ProCamera2DPixelPerfect)+6C]");
					num2 = (int)((nint)pixelHeight / (nint)0);
					bool flag = num2 == num;
					if (num2 > num)
					{
						num2 = num;
					}
					object obj = ViewportAutoScale - 1;
					if (!flag)
					{
						object obj2 = obj - 1;
						if (!flag)
						{
							if ((nint)obj2 != 1)
							{
								goto IL_0203;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049A960");
							bool flag2 = !(1f < (float)num2);
							num3 = 1f;
							if (!flag2)
							{
								num3 = num2;
							}
							num4 = num2;
							num5 = 1f;
						}
						else
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E0DC");
							bool flag3 = !(1f < (float)num2);
							num3 = 1f;
							if (!flag3)
							{
								num3 = num2;
							}
							num4 = num2;
							num5 = 1f;
						}
						goto IL_044a;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6F7E8");
					goto IL_0203;
				}
			}
			goto IL_030b;
		}
		num3 = 1f;
		num5 = 1f;
		goto IL_044a;
		IL_044a:
		bool flag4 = !SnapMovementToGrid;
		_003CViewportScale_003Ek__BackingField = num3;
		float pixelStep;
		if (!flag4)
		{
			pixelStep = num5 / PixelsPerUnit;
		}
		else
		{
			float num6 = (float)_zoom + num3;
			float num7 = num6 - num5;
			num4 = num7 * PixelsPerUnit;
			pixelStep = num5 / num4;
		}
		_pixelStep = pixelStep;
		ProCamera2D proCamera2D3 = base.ProCamera2D;
		if ((object)proCamera2D3 != null)
		{
			Camera gameCamera = proCamera2D3.GameCamera;
			if ((object)proCamera2D3.GameCamera != null)
			{
				bool flag5 = ((UnityEngine.Object)gameCamera).m_CachedPtr == (IntPtr)0;
				object obj3 = Camera.get_pixelHeight_Injected(((UnityEngine.Object)gameCamera).m_CachedPtr);
				float num8 = num5 / PixelsPerUnit;
				object obj4 = _zoom + _003CViewportScale_003Ek__BackingField;
				float num9 = (float)obj4 - num5;
				float num10 = (float)obj3 * 0.5f;
				float num11 = num8 * num10;
				ProCamera2D proCamera2D4 = base.ProCamera2D;
				if ((object)proCamera2D4 != null)
				{
					float newSize = num11 / num9;
					proCamera2D4.UpdateScreenSize(newSize);
					return;
				}
			}
		}
		goto IL_030b;
		IL_0203:
		bool flag6 = !(1f < (float)num2);
		num3 = 1f;
		if (!flag6)
		{
			num3 = num2;
		}
		num4 = num2;
		num5 = 1f;
		goto IL_044a;
		IL_030b:
		throw new NullReferenceException();
	}

	public float CalculateViewportScale()
	{
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_004f: Expected I4, but got Unknown
		//IL_0170: Expected O, but got I4
		//IL_00c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cd: Expected O, but got Unknown
		//IL_0187: Invalid comparison between F4 and I4
		//IL_0155: Expected F4, but got I4
		int num2;
		if (ViewportAutoScale != AutoScaleMode.None)
		{
			ProCamera2D proCamera2D = base.ProCamera2D;
			int pixelWidth = proCamera2D.GameCamera.pixelWidth;
			int num = (int)(pixelWidth / TargetViewportSizeInPixels);
			ProCamera2D proCamera2D2 = base.ProCamera2D;
			int pixelHeight = proCamera2D2.GameCamera.pixelHeight;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Com.LuisPedroFonseca.ProCamera2D.ProCamera2DPixelPerfect)+6C]");
			num2 = (int)((nint)pixelHeight / (nint)0);
			bool flag = num2 == num;
			if (num2 > num)
			{
				num2 = num;
			}
			object obj = ViewportAutoScale - 1;
			int num3;
			if (!flag)
			{
				object obj2 = obj - 1;
				if (!flag)
				{
					if ((nint)obj2 != 1)
					{
						goto IL_017e;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049A960");
					num3 = num2;
				}
				else
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E0DC");
					num3 = num2;
				}
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6F7E8");
				num3 = num2;
			}
			num2 = num3;
			goto IL_017e;
		}
		return 1f;
		IL_017e:
		bool flag2 = !(1f < (float)num2);
		float result = 1f;
		if (!flag2)
		{
			result = num2;
		}
		return result;
	}

	private float CalculatePixelStep(float viewportScale)
	{
		if (SnapMovementToGrid)
		{
			return 1f / PixelsPerUnit;
		}
		float num = (float)_zoom + viewportScale;
		float num2 = num - 1f;
		float num3 = num2 * PixelsPerUnit;
		return 1f / num3;
	}

	public ProCamera2DPixelPerfect()
	{
		//IL_0012: Expected O, but got I
		//IL_0033: Expected O, but got I4
		//IL_007a: Expected I, but got O
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A11D20]");
		GridColor = (Color)0;
		PixelsPerUnit = 32f;
		ViewportAutoScale = AutoScaleMode.Round;
		TargetViewportSizeInPixels = (Vector2)1117782016;
		_ = 1112014848;
		_zoom = 1;
		SnapCameraToGrid = true;
		_pixelStep = -1f;
		_poOrder = 2000;
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
