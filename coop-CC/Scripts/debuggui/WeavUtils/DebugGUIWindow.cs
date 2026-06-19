using UnityEngine;

namespace WeavUtils
{
	public class DebugGUIWindow : MonoBehaviour
	{
		protected const int outOfScreenClampPadding = 30;

		protected readonly Vector2 Padding = new Vector2(5f, 5f);

		private static bool dragInProgress;

		private bool dragged;

		protected Rect rect;

		private Vector3 lastMousePos;

		private static Material drawMat;

		private GUIContent tmpGuiContent = new GUIContent();

		private Material CreateMaterial()
		{
			Material material = new Material(Shader.Find("Hidden/Internal-Colored"));
			material.hideFlags = HideFlags.HideAndDontSave;
			material.SetInt("_SrcBlend", 5);
			material.SetInt("_DstBlend", 10);
			material.SetInt("_Cull", 0);
			material.SetInt("_ZWrite", 0);
			return material;
		}

		public virtual Rect GetDraggableRect()
		{
			return new Rect(rect.position, rect.size + Padding * 2f);
		}

		public virtual void Init()
		{
			if (drawMat == null)
			{
				drawMat = CreateMaterial();
			}
		}

		private void Update()
		{
			Vector3 mousePosition = Input.mousePosition;
			mousePosition.y = (float)Screen.height - mousePosition.y;
			if (Input.GetMouseButtonDown(2))
			{
				if (!dragInProgress && GetDraggableRect().Contains(mousePosition))
				{
					dragged = true;
					dragInProgress = true;
				}
			}
			else if (Input.GetMouseButtonUp(2))
			{
				if (dragged)
				{
					dragInProgress = false;
				}
				dragged = false;
			}
			if (dragged)
			{
				Vector3 vector = mousePosition - lastMousePos;
				Move(vector);
			}
			lastMousePos = mousePosition;
		}

		protected void Move(Vector2 delta = default(Vector2))
		{
			this.rect.position += delta;
			Rect rect = new Rect(Vector2.zero, new Vector2(Screen.width, Screen.height));
			Vector2 vector = -GetDraggableRect().size + Vector2.one * 30f;
			Vector2 vector2 = rect.size - Vector2.one * 30f;
			this.rect.position = new Vector2(Mathf.Clamp(this.rect.position.x, vector.x, vector2.x), Mathf.Clamp(this.rect.position.y, vector.y, vector2.y));
		}

		protected virtual void OnGUI()
		{
			if (Event.current.type == EventType.Repaint)
			{
				drawMat.SetPass(0);
			}
		}

		protected Vector2 GetMultilineStringSize(GUIStyle style, in string str)
		{
			tmpGuiContent.text = str;
			style.CalcMinMaxWidth(tmpGuiContent, out var _, out var maxWidth);
			float y = style.CalcHeight(tmpGuiContent, maxWidth);
			return new Vector2(maxWidth, y);
		}

		protected void DrawRect(Rect rect, Color color, Vector2 padding = default(Vector2))
		{
			rect.position += this.rect.position;
			rect.size += padding * 2f;
			GL.Begin(7);
			GL.Color(color);
			GL.Vertex3(rect.x, rect.y, 0f);
			GL.Vertex3(rect.x, rect.y + rect.height, 0f);
			GL.Vertex3(rect.x + rect.width, rect.y + rect.height, 0f);
			GL.Vertex3(rect.x + rect.width, rect.y, 0f);
			GL.End();
		}

		protected void DrawLine(Vector2 start, Vector2 end, Color color)
		{
			start += rect.position;
			end += rect.position;
			GL.Begin(1);
			GL.Color(color);
			GL.Vertex(start);
			GL.Vertex(end);
			GL.End();
		}

		protected void DrawLabel(Vector2 pos, string label, Vector2 padding = default(Vector2), GUIStyle style = null)
		{
			DrawLabel(new Rect(pos, GetMultilineStringSize(GUIStyle.none, in label)), label, padding, style);
		}

		protected void DrawLabel(Rect rect, string label, Vector2 padding = default(Vector2), GUIStyle style = null)
		{
			rect.position += this.rect.position;
			tmpGuiContent.text = label;
			GUI.Label(new Rect(rect.position + padding, rect.size + padding), tmpGuiContent, style ?? GUIStyle.none);
		}
	}
}
