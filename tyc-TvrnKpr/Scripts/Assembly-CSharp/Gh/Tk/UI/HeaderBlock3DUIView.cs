using UnityEngine;

namespace Gh.Tk.UI
{
	public class HeaderBlock3DUIView : TextBlock3DUIView, BaseBlock3DUIView.IEarlyRectResizable, BaseBlock3DUIView.IRectResizable, BaseBlock3DUIView.IFullWidthResizeable
	{
		private float _defaultWidth;

		public bool changeColorOfFirstLetter;

		public string firstLetterWrap;

		[SerializeField]
		private Transform _background;

		[SerializeField]
		private Transform _backgroundScaler;

		[SerializeField]
		private Transform _rightEdge;

		public Vector3 colliderPadding;

		public Vector3 colliderOffset;

		private GameObject _icon;

		private string _iconId;

		[SerializeField]
		private Transform _iconSocket;

		protected void Awake()
		{
		}

		protected override void ApplyText(string text)
		{
		}

		public override void ResizeToContent(float maxWidth)
		{
		}

		public override void ResizeToWidth(float width)
		{
		}

		public override void ResizeColliderToContent()
		{
		}

		private void ResizeBackground(float newWidth)
		{
		}

		public void SetIcon(string iconId)
		{
		}

		public override void SetBlockData(string data)
		{
		}
	}
}
