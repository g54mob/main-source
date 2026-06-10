using NSEipix.Base;
using NSEipix.View.UI;
using UnityEngine;

namespace NSMedieval.UI
{
	public class OverviewPanelManager : PopupView
	{
		[SerializeField]
		private GameObject content;

		[SerializeField]
		private SoundButton[] closeButtons;

		[SerializeField]
		private UIView[] panels;

		[SerializeField]
		private CustomGrouppedToggle[] tabs;

		private int currentTab;

		public void SetDataAndShow()
		{
			if (!IsShowing())
			{
				Show();
				MonoSingleton<UIController>.Instance.LinkClickedEvent += OnLinkClicked;
			}
		}

		public void Close()
		{
			if (IsShowing())
			{
				Hide();
				MonoSingleton<UIController>.Instance.LinkClickedEvent -= OnLinkClicked;
			}
		}

		private void OnLinkClicked(string obj)
		{
			Close();
		}

		protected override void OnShow()
		{
			base.OnShow();
			OnTabValueChanged(currentTab);
		}

		private void Awake()
		{
			MainView = content;
			SoundButton[] array = closeButtons;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].onClick.AddListener(Close);
			}
			for (int j = 0; j < tabs.Length; j++)
			{
				int index = j;
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
