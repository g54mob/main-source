using UnityEngine;

namespace Shapes
{
	[ExecuteAlways]
	public class ImmediateModePanel : MonoBehaviour
	{
		public bool drawRelativeToPanel = true;

		public bool useDrawingScope = true;

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

		internal void DrawPanel()
		{
			RectTransform rectTransform = base.transform as RectTransform;
			if (useDrawingScope)
			{
				Draw.Push();
			}
			if (drawRelativeToPanel)
			{
				Draw.PushMatrix();
				Draw.Matrix *= Matrix4x4.TRS(rectTransform.localPosition, rectTransform.localRotation, rectTransform.localScale);
			}
			DrawPanelShapes(rectTransform.rect);
			if (drawRelativeToPanel)
			{
				Draw.PopMatrix();
			}
			if (useDrawingScope)
			{
				Draw.Pop();
			}
		}

		public virtual void DrawPanelShapes(Rect rect)
		{
		}
	}
}
