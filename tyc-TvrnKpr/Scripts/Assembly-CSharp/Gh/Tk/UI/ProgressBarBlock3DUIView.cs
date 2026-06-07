using UnityEngine;

namespace Gh.Tk.UI
{
	public class ProgressBarBlock3DUIView : BaseBlock3DUIView, BaseBlock3DUIView.IFullWidthResizeable
	{
		[SerializeField]
		private ObjectProgressBar3DUIView _progressBar;

		private BoxCollider _ourCollider;

		public override void SetBlockData(string data)
		{
		}

		public void ResizeToWidth(float width)
		{
		}
	}
}
