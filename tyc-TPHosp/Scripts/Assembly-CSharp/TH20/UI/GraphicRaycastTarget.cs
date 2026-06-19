using UnityEngine;
using UnityEngine.UI;

namespace TH20.UI
{
	[AddComponentMenu("UI/Graphic Raycast Target", 103)]
	public class GraphicRaycastTarget : Graphic
	{
		public override bool raycastTarget
		{
			get
			{
				return true;
			}
			set
			{
			}
		}

		public override void Rebuild(CanvasUpdate update)
		{
		}
	}
}
