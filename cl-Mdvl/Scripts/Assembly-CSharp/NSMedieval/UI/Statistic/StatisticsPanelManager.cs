using NSEipix.View.UI;
using UnityEngine;

namespace NSMedieval.UI.Statistic
{
	public class StatisticsPanelManager : PanelBase
	{
		[SerializeField]
		private SoundButton closeButton;

		[SerializeField]
		private UIView[] panels;

		[SerializeField]
		private CustomGrouppedToggle[] tabs;

		private int currentTab;

		protected override PanelGroupType GetGroupType()
		{
			return PanelGroupType.UpperRight;
		}

		protected override void UpdatePanel()
		{
		}

		public override void ShowTab(int tabIndex)
		{
			base.Show();
			tabs[tabIndex].isOn = true;
		}

		public override void Show()
		{
			base.Show();
			OnTabValueChanged(currentTab);
		}

		private void Awake()
		{
			closeButton.onClick.AddListener(Hide);
			for (int i = 0; i < tabs.Length; i++)
			{
				int index = i;
				tabs[index].onValueChanged.AddListener(delegate
				{
					OnTabValueChanged(index);
				});
			}
		}

		private void OnTabValueChanged(int index)
		{
			currentTab = index;
			for (int i = 0; i < panels.Length; i++)
			{
				if (i == index)
				{
					panels[i].Show();
				}
				else
				{
					panels[i].Hide();
				}
			}
		}
	}
}
