using UnityEngine;

namespace Shapes
{
	[ExecuteAlways]
	public class ImmediateModePanel : MonoBehaviour
	{
		private ImmediateModeCanvas imCanvas;

		private ImmediateModeCanvas ImCanvas
		{
			get
			{
				if (!(imCanvas != null))
				{
					return imCanvas = GetComponentInParent<ImmediateModeCanvas>();
				}
				return imCanvas;
			}
		}

		public bool Valid => ImCanvas != null;

		public virtual void OnEnable()
		{
			if (Valid)
			{
				ImCanvas.Add(this);
			}
			else
			{
				Debug.LogWarning("ImmediateModePanel attached to " + base.gameObject.name + " is missing an ImmediateModeCanvas component on its canvas", this);
			}
		}

		public virtual void OnDisable()
		{
			if (Valid)
			{
				ImCanvas.Remove(this);
			}
		}

		internal void DrawPanel(ImCanvasContext ctx)
		{
			RectTransform rectTransform = base.transform as RectTransform;
			DrawPanelShapes(rectTransform.rect, ctx);
		}

		public virtual void DrawPanelShapes(Rect rect, ImCanvasContext ctx)
		{
		}
	}
}
