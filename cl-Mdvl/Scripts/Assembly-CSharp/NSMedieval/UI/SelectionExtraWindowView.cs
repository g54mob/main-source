using NSEipix.View.UI;
using UnityEngine;

namespace NSMedieval.UI
{
	public abstract class SelectionExtraWindowView : UIView
	{
		[SerializeField]
		private CustomGrouppedToggle[] tabs;

		[SerializeField]
		private SelectionExtraPanelBase[] panels;

		private int selectedPanel;

		public int SelectedPanel
		{
			get
			{
				return selectedPanel;
			}
			set
			{
				selectedPanel = value;
			}
		}

		public virtual void Initialize()
		{
			for (int i = 0; i < tabs.Length; i++)
			{
				int index = i;
				tabs[index].onValueChanged.AddListener(delegate(bool call)
				{
					SetPanelActive(index, call);
				});
			}
			for (int num = 0; num < panels.Length; num++)
			{
				panels[num].Show();
				panels[num].Hide();
			}
			Hide();
		}

		public override void Hide()
		{
			for (int i = 0; i < panels.Length; i++)
			{
				panels[i].Hide();
			}
			base.Hide();
		}

		public void UpdateData()
		{
			SelectionExtraPanelBase[] array = panels;
			foreach (SelectionExtraPanelBase selectionExtraPanelBase in array)
			{
				if (selectionExtraPanelBase.gameObject.activeInHierarchy)
				{
					selectionExtraPanelBase.UpdateData();
				}
			}
		}

		protected void ShowPanel()
		{
			Show();
			selectedPanel = ((selectedPanel > 0) ? selectedPanel : 0);
			for (int i = 0; i < panels.Length; i++)
			{
				bool flag = i == selectedPanel;
				tabs[i].SetIsOnWithoutNotify(flag);
				panels[i].SetActive(flag);
				if (flag)
				{
					panels[i].Show();
				}
				else
				{
					panels[i].Hide();
				}
			}
		}

		private void SetPanelActive(int index, bool active)
		{
			selectedPanel = index;
			panels[index].SetActive(active);
			if (active)
			{
				panels[index].Show();
			}
			else
			{
				panels[index].Hide();
			}
		}

		private void Reset()
		{
			for (int i = 0; i < panels.Length; i++)
			{
				tabs[i].isOn = false;
				panels[i].SetActive(active: false);
				panels[i].Hide();
			}
			selectedPanel = -1;
		}
	}
}
