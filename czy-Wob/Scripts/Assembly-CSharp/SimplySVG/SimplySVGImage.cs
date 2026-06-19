using UnityEngine;
using UnityEngine.UI;

namespace SimplySVG
{
	[DisallowMultipleComponent]
	[AddComponentMenu("UI/SimplySVG Image")]
	public class SimplySVGImage : MaskableGraphic, ILayoutElement, ICanvasRaycastFilter
	{
		public Mesh graphicMesh;

		public bool preserveAspectRatio;

		public bool useComplexHitCheck = true;

		public float flexibleHeight => -1f;

		public float flexibleWidth => -1f;

		public int layoutPriority => 0;

		public float minHeight => 0f;

		public float minWidth => 0f;

		public float preferredHeight
		{
			get
			{
				if (graphicMesh != null)
				{
					return graphicMesh.bounds.size.y;
				}
				return 100f;
			}
		}

		public float preferredWidth
		{
			get
			{
				if (graphicMesh != null)
				{
					return graphicMesh.bounds.size.x;
				}
				return 100f;
			}
		}

		public void CalculateLayoutInputHorizontal()
		{
		}

		public void CalculateLayoutInputVertical()
		{
		}

		public bool IsRaycastLocationValid(Vector2 sp, Camera eventCamera)
		{
			if (!useComplexHitCheck)
			{
				return true;
			}
			RectTransformUtility.ScreenPointToLocalPointInRectangle(base.rectTransform, sp, eventCamera, out var localPoint);
			Vector2 p = new Vector2(localPoint.x / base.rectTransform.rect.width * graphicMesh.bounds.size.x, localPoint.y / base.rectTransform.rect.height * graphicMesh.bounds.size.y);
			bool result = false;
			int[] triangles = graphicMesh.triangles;
			Vector3[] vertices = graphicMesh.vertices;
			for (int i = 0; i < triangles.Length; i += 3)
			{
				if (GeneralUtilities.PointInsideTriangle(p, vertices[triangles[i]], vertices[triangles[i + 1]], vertices[triangles[i + 2]]))
				{
					result = true;
					break;
				}
			}
			return result;
		}

		protected override void OnEnable()
		{
			SetAllDirty();
			Canvas.ForceUpdateCanvases();
			base.OnEnable();
		}

		protected override void OnPopulateMesh(VertexHelper vh)
		{
			vh.Clear();
			if (graphicMesh == null)
			{
				return;
			}
			Vector2 vector = new Vector2(base.rectTransform.rect.width, base.rectTransform.rect.height);
			Vector2 vector2 = graphicMesh.bounds.size;
			Vector2 vector3 = new Vector2(vector.x / vector2.x, vector.y / vector2.y);
			if (preserveAspectRatio)
			{
				vector3.y = (vector3.x = Mathf.Min(vector3.x, vector3.y));
			}
			Vector3[] vertices = graphicMesh.vertices;
			Color32[] colors = graphicMesh.colors32;
			int[] triangles = graphicMesh.triangles;
			for (int i = 0; i < triangles.Length; i += 3)
			{
				for (int j = 0; j < 3; j++)
				{
					Vector3 position = vertices[i + j] - graphicMesh.bounds.center;
					position.x *= vector3.x;
					position.y *= vector3.y;
					vh.AddVert(position, colors[i + j], Vector2.zero);
				}
				vh.AddTriangle(triangles[i], triangles[i + 1], triangles[i + 2]);
			}
		}

		public void UpdateMaterialProperties()
		{
			if (!color.Equals(base.canvasRenderer.GetColor()))
			{
				base.canvasRenderer.SetColor(color);
			}
		}

		private void Update()
		{
			UpdateMaterialProperties();
		}
	}
}
