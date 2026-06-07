using UnityEngine;

namespace Gh.Tk.UI
{
	public class MaterialProgressBar3DUIView : BaseProgressBar3DUIView
	{
		[SerializeField]
		private Renderer _progressRenderer;

		[SerializeField]
		private float uvMin;

		[SerializeField]
		private float uvMax;

		protected override void Refresh()
		{
		}
	}
}
