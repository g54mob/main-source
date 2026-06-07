using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Design.UI.Paint
{
	public class ColorButtonMeshModifier : BaseMeshEffect
	{
		public override void ModifyMesh(VertexHelper vh)
		{
			if (IsActive())
			{
				UIVertex vertex = default(UIVertex);
				Vector2 size = base.graphic.rectTransform.rect.size;
				int currentVertCount = vh.currentVertCount;
				for (int i = 0; i < currentVertCount; i++)
				{
					vh.PopulateUIVertex(ref vertex, i);
					vertex.uv1 = new Vector4(vertex.position.x / size.x + 0.5f, vertex.position.y / size.y + 0.5f, 0f, 0f);
					vh.SetUIVertex(vertex, i);
				}
			}
		}
	}
}
