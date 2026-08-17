using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Bindings;

namespace VampireSurvivors.Framework.Geom;

public class PolygonComponent : MonoBehaviour
{
	public Polygon _polygon;

	public float _rotationAngle;

	public bool _fallRegion;

	public Polygon GetWorldSpacePolygon()
	{
		//IL_0073: Expected O, but got I4
		//IL_007d: Expected O, but got I4
		//IL_013d: Expected O, but got I
		//IL_0332: Unknown result type (might be due to invalid IL or missing references)
		//IL_0337: Expected O, but got Unknown
		//IL_0347: Unknown result type (might be due to invalid IL or missing references)
		//IL_034c: Expected O, but got Unknown
		//IL_0199: Expected O, but got I
		//IL_01a9: Expected O, but got I
		//IL_022b: Expected O, but got I
		//IL_037c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0381: Expected O, but got Unknown
		//IL_015d->IL026e: Incompatible stack heights: 1 vs 0
		//IL_02ed->IL026e: Incompatible stack heights: 2 vs 0
		//IL_0364->IL026e: Incompatible stack heights: 3 vs 0
		//IL_01c9->IL026e: Incompatible stack heights: 3 vs 0
		//IL_039b->IL026e: Incompatible stack heights: 3 vs 0
		//IL_0252->IL03a0: Incompatible stack heights: 3 vs 0
		Polygon polygon = _polygon;
		if (_polygon != null)
		{
			List<float2> points = polygon._points;
			if (polygon._points != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v58 @ rbx_v8 (System.Collections.Generic.List`1<Unity.Mathematics.float2>)+18]");
				List<float2> list = new List<float2>(0);
				Polygon polygon2 = _polygon;
				bool flag = _polygon == null;
				object obj = 0;
				object obj2 = 0;
				if (!flag)
				{
					object obj7 = default(object);
					float2 float6 = default(float2);
					while (true)
					{
						List<float2> points2 = polygon2._points;
						if (polygon2._points == null)
						{
							break;
						}
						object obj3 = obj;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v137 @ rax_v22 (System.Collections.Generic.List`1<Unity.Mathematics.float2>)+18]");
						if ((nint)obj3 < 0)
						{
							Polygon polygon3 = _polygon;
							if (_polygon == null)
							{
								break;
							}
							List<float2> points3 = polygon3._points;
							if (polygon3._points == null)
							{
								break;
							}
							object obj4 = obj2;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v145 @ rcx_v26 (System.Collections.Generic.List`1<Unity.Mathematics.float2>)+18]");
							bool flag2 = (nint)obj4 >= 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v145 @ rcx_v26 (System.Collections.Generic.List`1<Unity.Mathematics.float2>)+10]");
							object obj5 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v145 @ rcx_v26 (System.Collections.Generic.List`1<Unity.Mathematics.float2>)+10]");
							if ((nint)0 == 0)
							{
								break;
							}
							bool flag3 = ((UnityEngine.Object)this).m_CachedPtr == (IntPtr)0;
							IntPtr gcHandlePtr = Component.get_transform_Injected(((UnityEngine.Object)this).m_CachedPtr);
							Transform transform = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr);
							if ((object)transform == null)
							{
								break;
							}
							bool flag4 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
							Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 ret);
							Vector3 vector = ret;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v146 @ rcx_v27+20+v129 @ rbx_v11*8]");
							float2 float5 = (float2)(vector + 0);
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v146 @ rcx_v27+24+v129 @ rbx_v11*8]");
							object obj6 = obj7 + 0;
							if (list == null)
							{
								break;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v264 @ rax_v19 (System.Collections.Generic.List`1<Unity.Mathematics.float2>)+1C]");
							_ = (nint)0 + (nint)1;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v264 @ rax_v19 (System.Collections.Generic.List`1<Unity.Mathematics.float2>)+10]");
							object obj8 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v264 @ rax_v19 (System.Collections.Generic.List`1<Unity.Mathematics.float2>)+18]");
							object obj9 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v264 @ rax_v19 (System.Collections.Generic.List`1<Unity.Mathematics.float2>)+10]");
							if ((nint)0 == 0)
							{
								break;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v264 @ rax_v19 (System.Collections.Generic.List`1<Unity.Mathematics.float2>)+18]");
							nint num = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v148 @ rcx_v35+18]");
							if (num >= 0)
							{
								list.AddWithResize(float6);
								float5 = float6;
							}
							else
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v264 @ rax_v19 (System.Collections.Generic.List`1<Unity.Mathematics.float2>)+18]");
								object obj10 = (nint)0 + (nint)1;
							}
							polygon2 = _polygon;
							obj2++;
							if (_polygon == null)
							{
								break;
							}
							obj = obj2;
							continue;
						}
						Polygon polygon4 = null;
						polygon4._points = list;
						return polygon4;
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	public PolygonComponent()
	{
		//IL_0015: Expected I, but got O
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
