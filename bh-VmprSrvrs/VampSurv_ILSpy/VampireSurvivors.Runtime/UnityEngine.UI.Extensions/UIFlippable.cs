using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;

namespace UnityEngine.UI.Extensions;

public class UIFlippable : BaseMeshEffect
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
			m_Horizontal = value;
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
			m_Veritical = value;
		}
	}

	public unsafe override void ModifyMesh(VertexHelper verts)
	{
		//IL_0008: Expected O, but got Ref
		//IL_008b: Expected O, but got I4
		//IL_007d: Expected O, but got I
		//IL_018b: Expected O, but got Ref
		object obj2 = default(object);
		object obj = (object)(&obj2);
		Transform transform = base.transform;
		bool flag = (object)transform == null;
		RectTransform rectTransform = null;
		if (!flag)
		{
			bool flag2 = (object)transform.GetType() != typeof(RectTransform);
			rectTransform = null;
			if (!flag2)
			{
				rectTransform = (RectTransform)transform;
			}
		}
		int num = 0;
		int num2 = 0;
		UIVertex vertex = default(UIVertex);
		UIVertex uIVertex = default(UIVertex);
		while (true)
		{
			object obj3;
			if (verts.m_Positions != null)
			{
				List<Vector3> positions = verts.m_Positions;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v343 @ rax_v17 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+18]");
				obj3 = 0;
			}
			else
			{
				obj3 = 0;
			}
			if (num < (nint)obj3)
			{
				_ = 0;
				_ = 0;
				verts.PopulateUIVertex(ref vertex, num2);
				if (m_Horizontal)
				{
					Rect rect = rectTransform.rect;
				}
				if (m_Veritical)
				{
					Rect rect2 = rectTransform.rect;
				}
				UIVertex vertex2 = (UIVertex)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 112));
				_ = 0;
				_ = 0;
				_ = 0;
				_ = 0;
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-80]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-78]");
				_ = 0;
				verts.SetUIVertex(vertex2, num2);
				num2++;
				num = num2;
				vertex = uIVertex;
				continue;
			}
			break;
		}
	}

	public UIFlippable()
	{
		//IL_0015: Expected I, but got O
		nint num = (nint)typeof(Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
