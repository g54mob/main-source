using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using Dreamteck.Splines;
using UnityEngine;

public class EME_Ribbon : MonoBehaviour
{
	private SplineRenderer _SplineRenderer;

	private SplineComputer _SplineComputer;

	private Vector2 LerpDistanceMinMax;

	private float _SpineRendererMinSize;

	private float _SpineRendererMaxSize;

	public Transform Target;

	private Transform ChildTransform;

	private Transform MidpointTransform;

	public float AdditionalHeight;

	public float LerpDistance;

	private float FadeIn;

	private float FadeOut;

	private ColorModifier _colorModifier;

	public unsafe void SetStartPosition(Vector3 position)
	{
		Transform childTransform = ChildTransform;
		bool flag = ((UnityEngine.Object)childTransform).m_CachedPtr == (IntPtr)0;
		float value = default(float);
		Transform.set_position_Injected(((UnityEngine.Object)childTransform).m_CachedPtr, ref *(Vector3*)(&value));
	}

	public unsafe void SetEndPosition(Vector3 position)
	{
		Transform target = Target;
		bool flag = ((UnityEngine.Object)target).m_CachedPtr == (IntPtr)0;
		float value = default(float);
		Transform.set_position_Injected(((UnityEngine.Object)target).m_CachedPtr, ref *(Vector3*)(&value));
	}

	public void SetFadeIn(float value)
	{
		//IL_0009: Invalid comparison between I4 and F4
		//IL_0018: Expected F4, but got I4
		bool flag = 0f > value;
		float fadeIn = 0f;
		if (!flag)
		{
			bool flag2 = value > 1f;
			fadeIn = 1f;
			if (!flag2)
			{
				FadeIn = value;
				return;
			}
		}
		FadeIn = fadeIn;
	}

	public void SetFadeOut(float value)
	{
		//IL_0009: Invalid comparison between I4 and F4
		//IL_0018: Expected F4, but got I4
		bool flag = 0f > value;
		float fadeOut = 0f;
		if (!flag)
		{
			bool flag2 = value > 1f;
			fadeOut = 1f;
			if (!flag2)
			{
				FadeOut = value;
				return;
			}
		}
		FadeOut = fadeOut;
	}

	private void Start()
	{
		SplineRenderer splineRenderer = _SplineRenderer;
		if ((object)_SplineRenderer != null && ((UnityEngine.Object)splineRenderer).m_CachedPtr != (IntPtr)0)
		{
			SplineRenderer splineRenderer2 = _SplineRenderer;
			_colorModifier = ((SplineUser)splineRenderer2)._colorModifier;
		}
	}

	private void LateUpdate()
	{
		//IL_019e: Expected O, but got I4
		//IL_01a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ab: Expected O, but got Unknown
		//IL_0b42: Expected O, but got I4
		//IL_0b4a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b4f: Expected O, but got Unknown
		//IL_01dc: Expected O, but got I4
		//IL_01e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e9: Expected O, but got Unknown
		//IL_0392: Expected O, but got I4
		//IL_039a: Unknown result type (might be due to invalid IL or missing references)
		//IL_039f: Expected O, but got Unknown
		//IL_020a: Expected F8, but got I4
		//IL_0bd5: Expected O, but got I4
		//IL_0bdd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0be2: Expected O, but got Unknown
		//IL_03d0: Expected O, but got I4
		//IL_03d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_03dd: Expected O, but got Unknown
		//IL_03fe: Expected F8, but got I4
		//IL_055e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0563: Expected O, but got Unknown
		//IL_0649: Invalid comparison between I4 and F4
		//IL_0658: Expected F4, but got I4
		//IL_0c68->IL0a26: Incompatible stack heights: 1 vs 0
		//IL_08ec->IL0a26: Incompatible stack heights: 2 vs 0
		//IL_078e->IL0a26: Incompatible stack heights: 2 vs 0
		//IL_0d3c->IL0a26: Incompatible stack heights: 2 vs 0
		//IL_058c->IL0a26: Incompatible stack heights: 2 vs 0
		//IL_0967->IL0a26: Incompatible stack heights: 2 vs 0
		//IL_0d13->IL0a26: Incompatible stack heights: 2 vs 0
		//IL_05bb->IL0a26: Incompatible stack heights: 2 vs 0
		//IL_0809->IL0a26: Incompatible stack heights: 2 vs 0
		//IL_09b7->IL0a26: Incompatible stack heights: 3 vs 0
		//IL_060b->IL0a26: Incompatible stack heights: 3 vs 0
		//IL_0859->IL0a26: Incompatible stack heights: 3 vs 0
		//IL_0a0e->IL0a26: Incompatible stack heights: 4 vs 0
		//IL_0cea->IL0a26: Incompatible stack heights: 4 vs 0
		//IL_0a26->IL0a60: Incompatible stack heights: 4 vs 0
		//IL_08b0->IL0a26: Incompatible stack heights: 4 vs 0
		//IL_0708->IL0a26: Incompatible stack heights: 4 vs 0
		//IL_08c8->IL0a60: Incompatible stack heights: 4 vs 0
		//IL_076a->IL0a60: Incompatible stack heights: 4 vs 0
		//IL_074d->IL0a60: Incompatible stack heights: 4 vs 0
		Transform target = Target;
		if ((object)Target == null || ((UnityEngine.Object)target).m_CachedPtr == (IntPtr)0)
		{
			return;
		}
		Transform childTransform = ChildTransform;
		if ((object)ChildTransform == null || ((UnityEngine.Object)childTransform).m_CachedPtr == (IntPtr)0)
		{
			return;
		}
		Transform midpointTransform = MidpointTransform;
		if ((object)MidpointTransform == null || ((UnityEngine.Object)midpointTransform).m_CachedPtr == (IntPtr)0)
		{
			return;
		}
		UpdateMidpointPosition();
		SplineRenderer splineRenderer = _SplineRenderer;
		object obj = (object)_SplineRenderer ^ (object)_SplineRenderer;
		object obj2 = (object)_SplineRenderer & obj;
		bool flag = (nint)obj2 < 0;
		bool flag2 = (nint)_SplineRenderer < 0;
		bool flag3 = (object)_SplineRenderer == null;
		if (flag3)
		{
			goto IL_0a26;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"ucomisd xmm0,xmm1\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 000000018693CDE7h\"");
		if (!flag3)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"ucomisd xmm1,xmm0\"");
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 000000018693CDFEh\"");
			if (!flag3)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"comisd xmm1,xmm7\"");
				((SplineUser)splineRenderer).animClipFrom = (float)((SplineUser)splineRenderer)._clipFrom;
				bool flag4 = flag2 == flag;
				object obj3 = !flag3;
				object obj4 = flag4 & obj3;
				double num;
				if (obj4 == null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"comisd xmm6,xmm1\"");
					bool flag5 = flag2 == flag;
					object obj5 = !flag5;
					object obj6 = obj5 | flag3;
					num = FadeIn;
					if (obj6 == null)
					{
						num = 0.0;
					}
				}
				else
				{
					num = 1.0;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"comisd xmm1,qword ptr [rax+80h]\"");
				((SplineUser)splineRenderer)._clipFrom = num;
				bool flag6 = flag2 == flag;
				object obj7 = !flag6;
				object obj8 = obj7 | flag3;
				if (obj8 == null)
				{
					SplineComputer spline = ((SplineUser)splineRenderer)._spline;
					if ((object)((SplineUser)splineRenderer)._spline != null)
					{
						Spline spline2 = spline.spline;
						if (spline.spline != null)
						{
							if (spline2.closed)
							{
								SplinePoint[] points = spline2.points;
								if (spline2.points == null)
								{
									goto IL_0a26;
								}
								if (points.Length >= 4)
								{
									goto IL_0b5d;
								}
							}
							((SplineUser)splineRenderer)._clipTo = num;
							goto IL_0b5d;
						}
					}
					goto IL_0a26;
				}
				goto IL_0b5d;
			}
		}
		goto IL_0aa9;
		IL_0aa9:
		SplineRenderer splineRenderer2 = _SplineRenderer;
		object obj9 = (object)_SplineRenderer ^ (object)_SplineRenderer;
		object obj10 = (object)_SplineRenderer & obj9;
		bool flag7 = (nint)obj10 < 0;
		bool flag8 = (nint)_SplineRenderer < 0;
		bool flag9 = (object)_SplineRenderer == null;
		if (flag9)
		{
			goto IL_0a26;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"ucomisd xmm0,xmm1\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 000000018693CEADh\"");
		double num2 = FadeOut;
		if (!flag9)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"ucomisd xmm1,xmm0\"");
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 000000018693CEC4h\"");
			num2 = FadeOut;
			if (!flag9)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"comisd xmm1,xmm7\"");
				((SplineUser)splineRenderer2).animClipTo = (float)((SplineUser)splineRenderer2)._clipTo;
				bool flag10 = flag8 == flag7;
				object obj11 = !flag9;
				object obj12 = flag10 & obj11;
				if (obj12 == null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"comisd xmm6,xmm1\"");
					bool flag11 = flag8 == flag7;
					object obj13 = !flag11;
					object obj14 = obj13 | flag9;
					num2 = FadeOut;
					if (obj14 == null)
					{
						num2 = 0.0;
					}
				}
				else
				{
					num2 = 1.0;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"comisd xmm0,xmm1\"");
				((SplineUser)splineRenderer2)._clipTo = num2;
				bool flag12 = flag8 == flag7;
				object obj15 = !flag12;
				object obj16 = obj15 | flag9;
				if (obj16 == null)
				{
					SplineComputer spline3 = ((SplineUser)splineRenderer2)._spline;
					if ((object)((SplineUser)splineRenderer2)._spline != null)
					{
						Spline spline4 = spline3.spline;
						if (spline3.spline != null)
						{
							if (spline4.closed)
							{
								SplinePoint[] points2 = spline4.points;
								if (spline4.points == null)
								{
									goto IL_0a26;
								}
								if (points2.Length >= 4)
								{
									goto IL_0bf0;
								}
							}
							((SplineUser)splineRenderer2)._clipFrom = num2;
							goto IL_0bf0;
						}
					}
					goto IL_0a26;
				}
				goto IL_0bf0;
			}
		}
		goto IL_0b7b;
		IL_0bf0:
		((SplineUser)splineRenderer2).getSamples = true;
		_SplineRenderer.Rebuild();
		goto IL_0b7b;
		IL_0b5d:
		((SplineUser)splineRenderer).getSamples = true;
		_SplineRenderer.Rebuild();
		goto IL_0aa9;
		IL_0a26:
		throw new NullReferenceException();
		IL_0b7b:
		object target2 = Target;
		if ((object)Target != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v524 @ rdi_v13 (System.Object)+10]");
			bool flag13 = (nint)0 == 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v524 @ rdi_v13 (System.Object)+10]");
			Transform.get_position_Injected((IntPtr)0, out Vector3 ret);
			Transform childTransform2 = ChildTransform;
			if ((object)ChildTransform != null)
			{
				bool flag14 = ((UnityEngine.Object)childTransform2).m_CachedPtr == (IntPtr)0;
				Transform.get_position_Injected(((UnityEngine.Object)childTransform2).m_CachedPtr, out Vector3 _);
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181BA2DA0");
				Vector2 lerpDistanceMinMax = LerpDistanceMinMax;
				if (System.Runtime.CompilerServices.Unsafe.As<Vector2, UIntPtr>(ref lerpDistanceMinMax) < System.Runtime.CompilerServices.Unsafe.As<Vector3, UIntPtr>(ref ret))
				{
					Vector3 vector = ret;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (EME_Ribbon)+34]");
					if ((nint)vector < 0)
					{
						ColorModifier colorModifier = _colorModifier;
						object obj17 = (object)ret - (object)LerpDistanceMinMax;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (EME_Ribbon)+34]");
						object obj18 = 0 - LerpDistanceMinMax;
						float num3 = (float)obj17 / (float)obj18;
						if (_colorModifier != null)
						{
							List<ColorModifier.ColorKey> keys = colorModifier.keys;
							if (colorModifier.keys != null)
							{
								bool flag15 = keys._size <= 0;
								ColorModifier.ColorKey[] items = keys._items;
								if (keys._items != null)
								{
									bool flag16 = items.Length <= 0;
									ColorModifier.ColorKey colorKey = items[0];
									bool flag17 = 0f > num3;
									float num4 = 0f;
									if (!flag17)
									{
										num4 = ((num3 > 1f) ? 1f : num3);
									}
									if (items[0] != null)
									{
										float num5 = num4 * -1f;
										float blend = num5 + 1f;
										colorKey.blend = blend;
										SplineRenderer splineRenderer3 = _SplineRenderer;
										float num6 = Mathf.Lerp(_SpineRendererMinSize, _SpineRendererMaxSize, num3);
										if ((object)_SplineRenderer != null)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 000000018693D167h\"");
											if (num6 == ((MeshGenerator)splineRenderer3)._size)
											{
												((MeshGenerator)splineRenderer3)._size = num6;
												return;
											}
											((MeshGenerator)splineRenderer3)._size = num6;
											_SplineRenderer.Rebuild();
											return;
										}
									}
								}
							}
						}
					}
					else
					{
						SplineRenderer splineRenderer4 = _SplineRenderer;
						if ((object)_SplineRenderer != null)
						{
							bool flag18 = _SpineRendererMaxSize == ((MeshGenerator)splineRenderer4)._size;
							((MeshGenerator)splineRenderer4)._size = _SpineRendererMaxSize;
							Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 000000018693D1AAh\"");
							if (!flag18)
							{
								_SplineRenderer.Rebuild();
							}
							ColorModifier colorModifier2 = _colorModifier;
							if (_colorModifier != null)
							{
								List<ColorModifier.ColorKey> keys2 = colorModifier2.keys;
								if (colorModifier2.keys != null)
								{
									bool flag19 = keys2._size <= 0;
									ColorModifier.ColorKey[] items2 = keys2._items;
									if (keys2._items != null)
									{
										bool flag20 = items2.Length <= 0;
										ColorModifier.ColorKey colorKey2 = items2[0];
										if (items2[0] != null)
										{
											colorKey2.blend = 0f;
											return;
										}
									}
								}
							}
						}
					}
				}
				else
				{
					SplineRenderer splineRenderer5 = _SplineRenderer;
					if ((object)_SplineRenderer != null)
					{
						bool flag21 = _SpineRendererMinSize == ((MeshGenerator)splineRenderer5)._size;
						((MeshGenerator)splineRenderer5)._size = _SpineRendererMinSize;
						Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 000000018693D22Fh\"");
						if (!flag21)
						{
							_SplineRenderer.Rebuild();
						}
						ColorModifier colorModifier3 = _colorModifier;
						if (_colorModifier != null)
						{
							List<ColorModifier.ColorKey> keys3 = colorModifier3.keys;
							if (colorModifier3.keys != null)
							{
								bool flag22 = keys3._size <= 0;
								ColorModifier.ColorKey[] items3 = keys3._items;
								if (keys3._items != null)
								{
									bool flag23 = items3.Length <= 0;
									ColorModifier.ColorKey colorKey3 = items3[0];
									if (items3[0] != null)
									{
										colorKey3.blend = 1f;
										return;
									}
								}
							}
						}
					}
				}
			}
		}
		goto IL_0a26;
	}

	private void UpdateMidpointPosition()
	{
		//IL_01c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c9: Expected O, but got Unknown
		//IL_01e3: Invalid comparison between I4 and F4
		//IL_007e: Expected F4, but got I4
		//IL_0200: Invalid comparison between I4 and F4
		//IL_00ba: Expected F4, but got I4
		//IL_0124->IL00c9: Incompatible stack heights: 1 vs 0
		//IL_017f->IL00c9: Incompatible stack heights: 2 vs 0
		Transform target = Target;
		if ((object)Target != null)
		{
			bool flag = ((UnityEngine.Object)target).m_CachedPtr == (IntPtr)0;
			Transform.get_position_Injected(((UnityEngine.Object)target).m_CachedPtr, out Vector3 ret);
			Transform childTransform = ChildTransform;
			if ((object)ChildTransform != null)
			{
				bool flag2 = ((UnityEngine.Object)childTransform).m_CachedPtr == (IntPtr)0;
				Transform.get_position_Injected(((UnityEngine.Object)childTransform).m_CachedPtr, out Vector3 ret2);
				Transform target2 = Target;
				if ((object)Target != null)
				{
					bool flag3 = ((UnityEngine.Object)target2).m_CachedPtr == (IntPtr)0;
					Transform.get_localPosition_Injected(((UnityEngine.Object)target2).m_CachedPtr, out ret);
					Vector3 vector = ret;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12890]");
					object obj = vector & 0;
					float num = (float)obj / LerpDistance;
					if (!(0f > num))
					{
						if (num > 1f)
						{
							num = 1f;
						}
					}
					else
					{
						num = 0f;
					}
					if (!(0f > num))
					{
						if (num > 1f)
						{
							num = 1f;
						}
					}
					else
					{
						num = 0f;
					}
					EME_Ribbon midpointTransform = (EME_Ribbon)(object)MidpointTransform;
					bool flag4 = (object)MidpointTransform == null;
					bool flag5 = ((UnityEngine.Object)midpointTransform).m_CachedPtr == (IntPtr)0;
					Transform.set_position_Injected(((UnityEngine.Object)midpointTransform).m_CachedPtr, ref ret2);
					return;
				}
			}
		}
		throw new NullReferenceException();
	}

	public EME_Ribbon()
	{
		//IL_000b: Expected O, but got I4
		//IL_003c: Expected I, but got O
		LerpDistanceMinMax = (Vector2)1084227584;
		_ = 1092616192;
		AdditionalHeight = 1f;
		LerpDistance = 5f;
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
