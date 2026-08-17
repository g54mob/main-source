using System;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using UnityEngine;

namespace VampireSurvivors.Framework.Geom;

public class PolygonGroupComponent : MonoBehaviour
{
	private Rect? _computedBounds;

	public unsafe Rect Bounds
	{
		get
		{
			//IL_0259: Expected O, but got I4
			//IL_023a: Expected F4, but got I
			//IL_0235: Expected native int or pointer, but got O
			//IL_0015: Expected O, but got I4
			//IL_0024: Expected O, but got I4
			//IL_004b: Expected O, but got I4
			//IL_0078: Expected O, but got I4
			//IL_014f: Expected O, but got I4
			//IL_01d6: Unknown result type (might be due to invalid IL or missing references)
			//IL_01db: Expected O, but got Unknown
			//IL_038e: Invalid comparison between F4 and O
			//IL_02ff: Invalid comparison between O and F4
			//IL_03ae: Unknown result type (might be due to invalid IL or missing references)
			//IL_03b3: Expected O, but got Unknown
			//IL_01bb: Expected F4, but got O
			//IL_01c8: Expected F4, but got O
			//IL_00d5->IL023f: Incompatible stack heights: 1 vs 0
			//IL_0108->IL023f: Incompatible stack heights: 1 vs 0
			//IL_02d3->IL023f: Incompatible stack heights: 2 vs 0
			//IL_0141->IL023f: Incompatible stack heights: 2 vs 0
			//IL_01e8->IL033d: Incompatible stack heights: 2 vs 0
			object obj = Application.isPlaying;
			if (obj == null)
			{
				_computedBounds = (Rect?)(object)0;
				_ = 0;
				Rect? rect = (Rect?)(object)0;
			}
			object obj6 = default(object);
			object obj7 = default(object);
			object obj8 = default(object);
			Rect? computedBounds = default(Rect?);
			Rect rect2 = default(Rect);
			while (true)
			{
				if ((object)_computedBounds == null)
				{
					PolygonComponent[] componentsInChildren = GetComponentsInChildren<PolygonComponent>();
					bool flag = componentsInChildren == null;
					object obj2 = 0;
					float num = -3.4028235E+38f;
					float num2 = 3.4028235E+38f;
					float num3 = -3.4028235E+38f;
					float num4 = 3.4028235E+38f;
					object obj3 = 0;
					if (flag)
					{
						break;
					}
					while ((nint)obj3 < componentsInChildren.Length)
					{
						bool flag2 = (nint)obj2 >= componentsInChildren.Length;
						PolygonComponent polygonComponent = componentsInChildren[obj2];
						if ((object)componentsInChildren[obj2] == null)
						{
							goto end_IL_0364;
						}
						Transform transform = componentsInChildren[obj2].transform;
						if ((object)transform == null)
						{
							goto end_IL_0364;
						}
						bool flag3 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
						Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 ret);
						Polygon polygon = polygonComponent._polygon;
						if (polygonComponent._polygon == null)
						{
							goto end_IL_0364;
						}
						Transform points = (Transform)(object)polygon._points;
						if (polygon._points == null)
						{
							goto end_IL_0364;
						}
						object obj4 = 0;
						while (true)
						{
							object obj5 = obj4;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v490 @ rdi_v10 (UnityEngine.Transform)+18]");
							if ((nint)obj5 >= 0)
							{
								break;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049D650");
							float num5 = (float)ret + (float)obj6;
							Rect? rect = (Rect?)(obj7 + obj8);
							if (num4 > num5)
							{
								num4 = num5;
							}
							if (num5 > num3)
							{
								num3 = num5;
							}
							if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num2) > System.Runtime.CompilerServices.Unsafe.As<Rect?, UIntPtr>(ref rect))
							{
								num2 = (float)rect;
							}
							if (System.Runtime.CompilerServices.Unsafe.As<Rect?, UIntPtr>(ref rect) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num))
							{
								num = (float)rect;
							}
							obj4++;
						}
						obj2++;
						obj3 = obj2;
					}
					float num6 = num - num2;
					_computedBounds = computedBounds;
					if ((object)_computedBounds == null)
					{
						System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_NoValue();
						continue;
					}
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rdx (VampireSurvivors.Framework.Geom.PolygonGroupComponent)+24]");
				((Rect*)(nint)rect2)->m_XMin = 0f;
				return rect2;
				continue;
				end_IL_0364:
				break;
			}
			throw new NullReferenceException();
		}
	}

	public PolygonGroupComponent()
	{
		//IL_0015: Expected I, but got O
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
