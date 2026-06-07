using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace UIScripts
{
	public abstract class TabsManager : MonoBehaviour
	{
		[FormerlySerializedAs("panels")]
		[SerializeField]
		protected List<UIPanel> tabs = new List<UIPanel>();

		[SerializeField]
		protected List<TabsButton> tabButtons = new List<TabsButton>();

		protected int selectedIndex;

		protected virtual void Awake()
		{
			tabs.ForEach(delegate(UIPanel p)
			{
				p.InitPanel();
			});
			int i = 0;
			tabButtons.ForEach(delegate(TabsButton p)
			{
				p.index = i;
				p.manager = this;
				p.Reset();
				i++;
			});
			tabButtons[0].Select();
		}

		public virtual void OpenPanel(int index)
		{
			selectedIndex = index;
			CloseAllPanels(index);
			for (int num = tabButtons.Count - 1; num >= 0; num--)
			{
				if (num != index)
				{
					tabButtons[num].Reset();
				}
			}
			tabs[index].OpenPanel();
		}

		public void CloseAllPanels(int? except = null)
		{
			for (int num = tabButtons.Count - 1; num >= 0; num--)
			{
				if (num != except)
				{
					tabButtons[num].Reset();
					tabs[num].ClosePanel();
				}
			}
		}
	}
}
