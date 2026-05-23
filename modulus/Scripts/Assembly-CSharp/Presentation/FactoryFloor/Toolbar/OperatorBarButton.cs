using Presentation.UI;
using UnityEngine;

namespace Presentation.FactoryFloor.Toolbar
{
	public class OperatorBarButton : BaseOperatorBarButton
	{
		[SerializeField]
		private TextInfoPanelContent _inactiveInfoPanel;

		[SerializeField]
		private BarInfoContent _barInfoContent;

		[SerializeField]
		private FactoryLockedView _lockedView;

		protected override void Initialized()
		{
			_inactiveInfoPanel.enabled = false;
		}

		public void SetActive(bool isActive)
		{
			_lockedView.IsForcedLock = !isActive;
			if (_barInfoContent != null)
			{
				_barInfoContent.enabled = isActive;
			}
			_inactiveInfoPanel.enabled = !isActive;
		}
	}
}
