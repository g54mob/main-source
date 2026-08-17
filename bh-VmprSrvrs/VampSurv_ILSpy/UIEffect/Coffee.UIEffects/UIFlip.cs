using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.UI;

namespace Coffee.UIEffects;

public class UIFlip : BaseMeshEffect
{
	private bool m_Horizontal;

	private bool m_Veritical;

	public bool horizontal
	{
		get
		{
			return m_Horizontal;
		}
		set
		{
			if (m_Horizontal != value)
			{
				m_Horizontal = value;
				base.SetEffectParamsDirty();
			}
		}
	}

	public bool vertical
	{
		get
		{
			return m_Veritical;
		}
		set
		{
			if (m_Veritical != value)
			{
				m_Veritical = value;
				base.SetEffectParamsDirty();
			}
		}
	}

	public unsafe override void ModifyMesh(VertexHelper vh, Graphic graphic)
	{
		//IL_0008: Expected O, but got Ref
		//IL_00bf: Expected O, but got I4
		//IL_0080: Expected O, but got I4
		//IL_0072: Expected O, but got I
		//IL_014b: Expected O, but got Ref
		object obj2 = default(object);
		object obj = (object)(&obj2);
		bool flag = ((UnityEngine.Object)this).m_CachedPtr == (IntPtr)0;
		UIVertex vertex = default(UIVertex);
		while (true)
		{
			object obj3 = Behaviour.get_isActiveAndEnabled_Injected(((UnityEngine.Object)this).m_CachedPtr);
			if (obj3 == null)
			{
				break;
			}
			_ = 0;
			_ = 0;
			int num = 0;
			int num2 = 0;
			while (true)
			{
				object obj4;
				if (vh.m_Positions != null)
				{
					List<Vector3> positions = vh.m_Positions;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v374 @ rax_v17 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+18]");
					obj4 = 0;
				}
				else
				{
					obj4 = 0;
				}
				if (num < (nint)obj4)
				{
					vh.PopulateUIVertex(ref vertex, num2);
					if (m_Horizontal)
					{
						break;
					}
					if (!m_Veritical)
					{
						UIVertex vertex2 = (UIVertex)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 112));
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-78]");
						_ = 0;
						_ = 0;
						_ = 0;
						_ = 0;
						_ = 0;
						_ = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-80]");
						_ = 0;
						vh.SetUIVertex(vertex2, num2);
						num2++;
						num = num2;
					}
					continue;
				}
				return;
			}
		}
	}
}
