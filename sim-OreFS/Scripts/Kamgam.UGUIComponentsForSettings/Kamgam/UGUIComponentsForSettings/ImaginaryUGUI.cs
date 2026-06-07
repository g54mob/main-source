using UnityEngine;
using UnityEngine.UI;

namespace Kamgam.UGUIComponentsForSettings
{
	public class ImaginaryUGUI : MaskableGraphic
	{
		[Tooltip("Enable to change to a circular hit area.")]
		public bool Circular;

		public float Radius;

		public override bool Raycast(Vector2 sp, Camera eventCamera)
		{
			bool flag = base.Raycast(sp, eventCamera);
			if (Circular && flag)
			{
				RectTransformUtility.ScreenPointToLocalPointInRectangle(base.rectTransform, sp, eventCamera, out var localPoint);
				float num = Radius;
				if (Radius <= 0f)
				{
					num = Mathf.Min(base.rectTransform.rect.width * 0.5f, base.rectTransform.rect.height * 0.5f);
				}
				return localPoint.sqrMagnitude < num * num;
			}
			return flag;
		}

		protected override void OnPopulateMesh(VertexHelper vh)
		{
			vh.Clear();
		}
	}
}
