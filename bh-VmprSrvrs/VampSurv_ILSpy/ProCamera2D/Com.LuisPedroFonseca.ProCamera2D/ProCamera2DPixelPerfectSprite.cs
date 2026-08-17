using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using UnityEngine;

namespace Com.LuisPedroFonseca.ProCamera2D;

public class ProCamera2DPixelPerfectSprite : BasePC2D, IPostMover
{
	public bool IsAMovingObject;

	public bool IsAChildSprite;

	public Vector2 LocalPosition;

	public int SpriteScale;

	private Sprite _sprite;

	private ProCamera2DPixelPerfect _pixelPerfectPlugin;

	private Vector3 _initialScale;

	private int _prevSpriteScale;

	private int _pmOrder;

	public int PMOrder
	{
		get
		{
			return _pmOrder;
		}
		set
		{
			_pmOrder = value;
		}
	}

	protected override void Awake()
	{
		base.Awake();
		ProCamera2D proCamera2D = base.ProCamera2D;
		if ((object)proCamera2D != null && ((UnityEngine.Object)proCamera2D).m_CachedPtr != (IntPtr)0)
		{
			ProCamera2D proCamera2D2 = base.ProCamera2D;
			ProCamera2DPixelPerfect component = proCamera2D2.GetComponent<ProCamera2DPixelPerfect>();
			_pixelPerfectPlugin = component;
			SpriteRenderer component2 = GetComponent<SpriteRenderer>();
			if ((object)component2 != null && ((UnityEngine.Object)component2).m_CachedPtr != (IntPtr)0)
			{
				Sprite sprite = component2.sprite;
				_sprite = sprite;
			}
			ProCamera2D proCamera2D3 = base.ProCamera2D;
			proCamera2D3.AddPostMover(this);
		}
		else
		{
			base.enabled = false;
		}
	}

	private void Start()
	{
		SetAsPixelPerfect();
	}

	public void PostMove(float deltaTime)
	{
		//IL_00cd: Expected O, but got I4
		bool flag = ((UnityEngine.Object)this).m_CachedPtr == (IntPtr)0;
		object obj = Behaviour.get_enabled_Injected(((UnityEngine.Object)this).m_CachedPtr);
		if (obj == null)
		{
			return;
		}
		ProCamera2DPixelPerfect pixelPerfectPlugin = _pixelPerfectPlugin;
		if ((object)_pixelPerfectPlugin != null && ((UnityEngine.Object)pixelPerfectPlugin).m_CachedPtr != (IntPtr)0 && _pixelPerfectPlugin.enabled)
		{
			if (IsAMovingObject)
			{
				SetAsPixelPerfect();
			}
			_prevSpriteScale = SpriteScale;
		}
	}

	private void Step()
	{
		ProCamera2DPixelPerfect pixelPerfectPlugin = _pixelPerfectPlugin;
		if ((object)_pixelPerfectPlugin != null && ((UnityEngine.Object)pixelPerfectPlugin).m_CachedPtr != (IntPtr)0 && _pixelPerfectPlugin.enabled)
		{
			if (IsAMovingObject)
			{
				SetAsPixelPerfect();
			}
			_prevSpriteScale = SpriteScale;
		}
	}

	private void GetPixelPerfectPlugin()
	{
		ProCamera2D proCamera2D = base.ProCamera2D;
		ProCamera2DPixelPerfect component = proCamera2D.GetComponent<ProCamera2DPixelPerfect>();
		_pixelPerfectPlugin = component;
	}

	private void GetSprite()
	{
		SpriteRenderer component = GetComponent<SpriteRenderer>();
		if ((object)component != null && ((UnityEngine.Object)component).m_CachedPtr != (IntPtr)0)
		{
			Sprite sprite = component.sprite;
			_sprite = sprite;
		}
	}

	public unsafe void SetAsPixelPerfect()
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		//IL_078e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0793: Expected O, but got Unknown
		//IL_0287: Unknown result type (might be due to invalid IL or missing references)
		//IL_028c: Expected O, but got Unknown
		//IL_06df: Unknown result type (might be due to invalid IL or missing references)
		//IL_06e4: Expected O, but got Unknown
		//IL_01dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e2: Expected O, but got Unknown
		//IL_07fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_07ff: Expected O, but got Unknown
		//IL_022e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0233: Expected O, but got Unknown
		//IL_0390: Unknown result type (might be due to invalid IL or missing references)
		//IL_0395: Expected O, but got Unknown
		//IL_073f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0744: Expected I, but got Unknown
		//IL_0869: Unknown result type (might be due to invalid IL or missing references)
		//IL_086e: Expected O, but got Unknown
		//IL_0499: Unknown result type (might be due to invalid IL or missing references)
		//IL_049e: Expected O, but got Unknown
		//IL_04ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_04ef: Expected O, but got Unknown
		//IL_08c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_08ce: Expected O, but got Unknown
		//IL_0ac3: Expected O, but got I
		//IL_0637: Expected O, but got I
		//IL_0b2d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b32: Expected O, but got Unknown
		//IL_0b59: Expected O, but got I
		//IL_0aed: Unknown result type (might be due to invalid IL or missing references)
		//IL_0af2: Expected O, but got Unknown
		//IL_0954: Unknown result type (might be due to invalid IL or missing references)
		//IL_0959: Expected O, but got Unknown
		//IL_09f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_09f7: Expected O, but got Unknown
		//IL_0a1c: Expected O, but got I
		//IL_0a72: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a77: Expected O, but got Unknown
		//IL_0ba4: Expected O, but got I
		//IL_05c5: Expected O, but got I
		//IL_0aa9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0aae: Expected O, but got Unknown
		//IL_07bf->IL0665: Incompatible stack heights: 1 vs 0
		//IL_02d4->IL0665: Incompatible stack heights: 1 vs 0
		//IL_0378->IL0665: Incompatible stack heights: 1 vs 0
		//IL_0713->IL0665: Incompatible stack heights: 1 vs 0
		//IL_0220->IL0665: Incompatible stack heights: 1 vs 0
		//IL_082e->IL0665: Incompatible stack heights: 2 vs 0
		//IL_03dd->IL0665: Incompatible stack heights: 2 vs 0
		//IL_0481->IL0665: Incompatible stack heights: 2 vs 0
		//IL_075b->IL066c: Incompatible stack heights: 3 vs 0
		//IL_089d->IL0665: Incompatible stack heights: 3 vs 0
		//IL_04dc->IL0665: Incompatible stack heights: 3 vs 0
		//IL_0656->IL0665: Incompatible stack heights: 4 vs 0
		//IL_0919->IL0665: Incompatible stack heights: 4 vs 0
		//IL_056d->IL0665: Incompatible stack heights: 4 vs 0
		//IL_0bd4->IL0bd4: Incompatible stack heights: 6 vs 5
		//IL_0597->IL0665: Incompatible stack heights: 4 vs 0
		//IL_09b7->IL0665: Incompatible stack heights: 5 vs 0
		//IL_0b8f->IL0665: Incompatible stack heights: 6 vs 0
		//IL_0ab3->IL0bc5: Incompatible stack heights: 8 vs 6
		object obj2 = default(object);
		object obj = obj2 - 95;
		if (IsAChildSprite)
		{
			ProCamera2DPixelPerfect pixelPerfectPlugin = _pixelPerfectPlugin;
			Transform transform = _transform;
			Func<float, float, float, Vector3> vectorHVD = VectorHVD;
			if ((object)_pixelPerfectPlugin != null)
			{
				float num = (float)LocalPosition / pixelPerfectPlugin._pixelStep;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049A960");
				float num2 = num * pixelPerfectPlugin._pixelStep;
				float num3 = num2 / pixelPerfectPlugin._pixelStep;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049A960");
				ProCamera2DPixelPerfect pixelPerfectPlugin2 = _pixelPerfectPlugin;
				float num4 = num3 * pixelPerfectPlugin._pixelStep;
				if ((object)_pixelPerfectPlugin != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Com.LuisPedroFonseca.ProCamera2D.ProCamera2DPixelPerfectSprite)+68]");
					float num5 = 0f / pixelPerfectPlugin2._pixelStep;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049A960");
					float num6 = num5 * pixelPerfectPlugin2._pixelStep;
					float num7 = num6 / pixelPerfectPlugin2._pixelStep;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049A960");
					object obj3 = _transform;
					Transform vector3D = (Transform)(object)Vector3D;
					float num8 = num7 * pixelPerfectPlugin2._pixelStep;
					if ((object)_transform != null)
					{
						_ = 0;
						_ = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v82 @ r14_v36 (System.Object)+10]");
						bool flag = (nint)0 == 0;
						object obj4 = obj - 57;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v82 @ r14_v36 (System.Object)+10]");
						Transform.get_localPosition_Injected((IntPtr)0, out *(Vector3*)obj4);
						if (Vector3D != null)
						{
							object obj5 = obj - 41;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v15 @ rbp_v1-39]");
							_ = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v15 @ rbp_v1-31]");
							_ = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v78 @ r15_v31 (UnityEngine.Transform)+18] (should have been resolved before IL gen)");
							if (VectorHVD != null)
							{
								object obj6 = obj - 57;
								Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v35 @ rdi_v38 (System.Func`4<System.Single, System.Single, System.Single, UnityEngine.Vector3>)+18] (should have been resolved before IL gen)");
								bool flag2 = (object)_transform == null;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1095 @ rax_v169+8]");
								_ = 0;
								bool flag3 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
								nint num9 = (nint)(obj - 41);
								Transform.set_localPosition_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref *(Vector3*)num9);
								goto IL_066c;
							}
						}
					}
				}
			}
			goto IL_0665;
		}
		goto IL_066c;
		IL_066c:
		Transform transform2 = _transform;
		Func<float, float, float, Vector3> vectorHVD2 = VectorHVD;
		Transform vector3H = (Transform)(object)Vector3H;
		if ((object)_transform != null)
		{
			_ = 0;
			_ = 0;
			bool flag4 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
			object obj7 = obj - 57;
			Transform.get_position_Injected(((UnityEngine.Object)transform2).m_CachedPtr, out *(Vector3*)obj7);
			if (Vector3H != null)
			{
				object obj8 = obj - 41;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v15 @ rbp_v1-39]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v15 @ rbp_v1-31]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v117 @ rsi_v28 (UnityEngine.Transform)+18] (should have been resolved before IL gen)");
				ProCamera2DPixelPerfect pixelPerfectPlugin3 = _pixelPerfectPlugin;
				if ((object)_pixelPerfectPlugin != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v15 @ rbp_v1-39]");
					float num10 = 0f / pixelPerfectPlugin3._pixelStep;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049A960");
					float num11 = num10 * pixelPerfectPlugin3._pixelStep;
					float num12 = num11 / pixelPerfectPlugin3._pixelStep;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049A960");
					Func<float, float, float, Vector3> func = (Func<float, float, float, Vector3>)(object)_transform;
					object vector3V = Vector3V;
					float num13 = num12 * pixelPerfectPlugin3._pixelStep;
					if ((object)_transform != null)
					{
						_ = 0;
						_ = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v234 @ rdi_v28 (System.Func`4<System.Single, System.Single, System.Single, UnityEngine.Vector3>)+10]");
						bool flag5 = (nint)0 == 0;
						object obj9 = obj - 57;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v234 @ rdi_v28 (System.Func`4<System.Single, System.Single, System.Single, UnityEngine.Vector3>)+10]");
						Transform.get_position_Injected((IntPtr)0, out *(Vector3*)obj9);
						if (Vector3V != null)
						{
							object obj10 = obj - 41;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v15 @ rbp_v1-39]");
							_ = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v15 @ rbp_v1-31]");
							_ = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v206 @ r14_v29 (System.Object)+18] (should have been resolved before IL gen)");
							ProCamera2DPixelPerfect pixelPerfectPlugin4 = _pixelPerfectPlugin;
							if ((object)_pixelPerfectPlugin != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v15 @ rbp_v1-39]");
								float num14 = 0f / pixelPerfectPlugin4._pixelStep;
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049A960");
								float num15 = num14 * pixelPerfectPlugin4._pixelStep;
								float num16 = num15 / pixelPerfectPlugin4._pixelStep;
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049A960");
								Func<float, float, float, Vector3> func2 = (Func<float, float, float, Vector3>)(object)_transform;
								Transform vector3D2 = (Transform)(object)Vector3D;
								float num17 = num16 * pixelPerfectPlugin4._pixelStep;
								if ((object)_transform != null)
								{
									_ = 0;
									_ = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v235 @ rdi_v29 (System.Func`4<System.Single, System.Single, System.Single, UnityEngine.Vector3>)+10]");
									bool flag6 = (nint)0 == 0;
									object obj11 = obj - 57;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v235 @ rdi_v29 (System.Func`4<System.Single, System.Single, System.Single, UnityEngine.Vector3>)+10]");
									Transform.get_position_Injected((IntPtr)0, out *(Vector3*)obj11);
									if (Vector3D != null)
									{
										object obj12 = obj - 41;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v15 @ rbp_v1-39]");
										_ = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v15 @ rbp_v1-31]");
										_ = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v241 @ rsi_v30 (UnityEngine.Transform)+18] (should have been resolved before IL gen)");
										if (VectorHVD != null)
										{
											object obj13 = obj - 57;
											Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v116 @ r13_v27 (System.Func`4<System.Single, System.Single, System.Single, UnityEngine.Vector3>)+18] (should have been resolved before IL gen)");
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1448 @ rax_v95+8]");
											_ = 0;
											bool flag7 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
											object obj14 = obj - 41;
											Transform.set_position_Injected(((UnityEngine.Object)transform2).m_CachedPtr, ref *(Vector3*)obj14);
											if (SpriteScale != 0)
											{
												if (SpriteScale < 0)
												{
												}
												if ((object)_sprite != null)
												{
													float pixelsPerUnit = _sprite.pixelsPerUnit;
													if ((object)_pixelPerfectPlugin != null)
													{
														object obj15 = _transform;
														if ((object)_transform != null)
														{
															_ = 0;
															_ = 0;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v208 @ r14_v34 (System.Object)+10]");
															bool flag8 = (nint)0 == 0;
															object obj16 = obj - 57;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v208 @ r14_v34 (System.Object)+10]");
															Transform.get_localScale_Injected((IntPtr)0, out *(Vector3*)obj16);
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v15 @ rbp_v1-39]");
															if ((nint)0 >= (nint)0)
															{
															}
															Func<float, float, float, Vector3> func3 = (Func<float, float, float, Vector3>)(object)_transform;
															if ((object)_transform != null)
															{
																_ = 0;
																_ = 0;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v237 @ rdi_v35 (System.Func`4<System.Single, System.Single, System.Single, UnityEngine.Vector3>)+10]");
																bool flag9 = (nint)0 == 0;
																object obj17 = obj - 41;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v237 @ rdi_v35 (System.Func`4<System.Single, System.Single, System.Single, UnityEngine.Vector3>)+10]");
																Transform.get_localScale_Injected((IntPtr)0, out *(Vector3*)obj17);
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v15 @ rbp_v1-25]");
																Vector3 vector = (Vector3)0;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v15 @ rbp_v1-25]");
																ProCamera2DPixelPerfectSprite proCamera2DPixelPerfectSprite = default(ProCamera2DPixelPerfectSprite);
																if ((nint)0 >= (nint)0)
																{
																	proCamera2DPixelPerfectSprite = (ProCamera2DPixelPerfectSprite)(object)_transform;
																	if ((object)_transform == null)
																	{
																		goto IL_0665;
																	}
																}
																_ = 0;
																_ = 0;
																bool flag10 = ((UnityEngine.Object)proCamera2DPixelPerfectSprite).m_CachedPtr == (IntPtr)0;
																object obj18 = obj - 57;
																Transform.get_localScale_Injected(((UnityEngine.Object)proCamera2DPixelPerfectSprite).m_CachedPtr, out *(Vector3*)obj18);
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v15 @ rbp_v1-31]");
																_ = 0;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v208 @ r14_v34 (System.Object)+10]");
																ProCamera2DPixelPerfectSprite proCamera2DPixelPerfectSprite2 = (ProCamera2DPixelPerfectSprite)0;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v208 @ r14_v34 (System.Object)+10]");
																bool flag11 = (nint)0 == 0;
																object obj19 = 0;
																object obj20 = obj - 41;
																goto IL_0bc5;
															}
														}
													}
												}
											}
											else
											{
												bool flag12 = _prevSpriteScale == 0;
												Func<float, float, float, Vector3> func4 = (Func<float, float, float, Vector3>)(object)_transform;
												if (!flag12)
												{
													bool flag13 = (object)_transform == null;
													Vector3 vector = _initialScale;
													_ = _initialScale;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Com.LuisPedroFonseca.ProCamera2D.ProCamera2DPixelPerfectSprite)+88]");
													_ = 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v238 @ rdi_v34 (System.Func`4<System.Single, System.Single, System.Single, UnityEngine.Vector3>)+10]");
													ProCamera2DPixelPerfectSprite proCamera2DPixelPerfectSprite2 = (ProCamera2DPixelPerfectSprite)0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v238 @ rdi_v34 (System.Func`4<System.Single, System.Single, System.Single, UnityEngine.Vector3>)+10]");
													bool flag14 = (nint)0 == 0;
													object obj19 = 0;
													object obj20 = obj - 57;
													goto IL_0bc5;
												}
												if ((object)_transform != null)
												{
													_ = 0;
													_ = 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v238 @ rdi_v34 (System.Func`4<System.Single, System.Single, System.Single, UnityEngine.Vector3>)+10]");
													bool flag15 = (nint)0 == 0;
													object obj21 = obj - 57;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v238 @ rdi_v34 (System.Func`4<System.Single, System.Single, System.Single, UnityEngine.Vector3>)+10]");
													Transform.get_localScale_Injected((IntPtr)0, out *(Vector3*)obj21);
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v15 @ rbp_v1-39]");
													_initialScale = (Vector3)0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v15 @ rbp_v1-31]");
													_ = 0;
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
		goto IL_0665;
		IL_0bc5:
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v2162 @ rax_v102 (should have been resolved before IL gen)");
		return;
		IL_0665:
		throw new NullReferenceException();
	}

	protected override void OnDestroy()
	{
		Disable();
		ProCamera2D proCamera2D = base.ProCamera2D;
		if ((object)proCamera2D != null && ((UnityEngine.Object)proCamera2D).m_CachedPtr != (IntPtr)0)
		{
			ProCamera2D proCamera2D2 = base.ProCamera2D;
			bool flag = ((List<object>)(object)proCamera2D2._postMovers).Remove((object)this);
		}
	}

	public ProCamera2DPixelPerfectSprite()
	{
		//IL_0015: Expected I, but got O
		//IL_005b: Expected I, but got O
		nint num = (nint)typeof(Vector3);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ rax_v2 (Il2CppClass<UnityEngine.Vector3>)+B8]");
		nint num2 = 0;
		_initialScale = Vector3.oneVector;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rdx_v1 (Il2CppStaticFields<UnityEngine.Vector3>)+14]");
		_ = 0;
		_pmOrder = 2000;
		nint num3 = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v51 @ rcx_v3 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
