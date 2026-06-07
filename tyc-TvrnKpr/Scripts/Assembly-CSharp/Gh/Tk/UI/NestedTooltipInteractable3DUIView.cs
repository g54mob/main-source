using UnityEngine;

namespace Gh.Tk.UI
{
	public class NestedTooltipInteractable3DUIView : TextBlockTooltipInteractable3DUIView, INestedTooltipProvider, ITooltipProvider
	{
		private Tooltip3DUIView _parent;

		public int GetId()
		{
			return 0;
		}

		public Tooltip3DUIView GetParent()
		{
			return null;
		}

		public void SetParent(Tooltip3DUIView parent)
		{
		}

		public new Vector3 GetTooltipPosition()
		{
			return default(Vector3);
		}

		public override float GetTooltipDelay()
		{
			return 0f;
		}
	}
}
