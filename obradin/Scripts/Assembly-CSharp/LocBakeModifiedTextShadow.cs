using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LocBakeModifiedTextShadow : Shadow
{
	public override void ModifyMesh(VertexHelper vh)
	{
		if (IsActive())
		{
			List<UIVertex> list = LocBakeListPool<UIVertex>.Get();
			vh.GetUIVertexStream(list);
			ModifyVertices(list);
			vh.Clear();
			vh.AddUIVertexTriangleStream(list);
			LocBakeListPool<UIVertex>.Release(list);
		}
	}

	public virtual void ModifyVertices(List<UIVertex> verts)
	{
	}
}
