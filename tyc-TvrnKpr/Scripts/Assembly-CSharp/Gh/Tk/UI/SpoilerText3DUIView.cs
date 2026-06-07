using UnityEngine;

namespace Gh.Tk.UI
{
	public class SpoilerText3DUIView : NestedTooltipButton3DUIView
	{
		private BoxCollider _col;

		private bool _isTextVisible;

		[SerializeField]
		private GameObject _spoilerTextObj;

		public string LinkId { get; private set; }

		protected override void Awake()
		{
		}

		public void Init()
		{
		}

		protected override void OnClickedInternal()
		{
		}

		public void ShowText()
		{
		}

		public void HideText()
		{
		}

		public void SetLinkId(string getLinkID)
		{
		}
	}
}
