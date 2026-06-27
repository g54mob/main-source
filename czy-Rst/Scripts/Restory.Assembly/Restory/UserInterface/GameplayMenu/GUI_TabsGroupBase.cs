using System;
using System.Collections.Generic;
using UnityEngine;

namespace Restory.UserInterface.GameplayMenu
{
	public abstract class GUI_TabsGroupBase<T> : MonoBehaviour where T : GUI_Tab
	{
		[Header("General settings")]
		[SerializeField]
		protected T defaultTab;

		[SerializeField]
		protected Transform tabsContainer;

		[SerializeField]
		protected bool isCarousel;

		[SerializeField]
		protected List<T> tabsList = new List<T>();

		protected T activeTab;

		public virtual T ActiveTab
		{
			get
			{
				return activeTab;
			}
			protected set
			{
				SetActiveTab(value);
			}
		}

		public bool IsCarousel => isCarousel;

		public IReadOnlyList<T> TabsList => tabsList;

		public event Action<GUI_TabsGroupBase<T>, T> ActiveTabChanged;

		public event Action<GUI_TabsGroupBase<T>> TabsChanged;

		public void OpenDefaultTab()
		{
			ActiveTab = defaultTab;
		}

		public void DeselectAll(bool silently = false)
		{
			SetActiveTab(null, silently);
		}

		public virtual void SetCurrentTab(int targetTabID = 0)
		{
			ActiveTab = tabsList[targetTabID];
		}

		public virtual void NextTab(int currentTabID = -1)
		{
			if (currentTabID == -1)
			{
				currentTabID = tabsList.IndexOf(ActiveTab);
			}
			if (currentTabID >= tabsList.Count - 1 && !isCarousel)
			{
				return;
			}
			for (int i = 0; i < tabsList.Count; i++)
			{
				currentTabID++;
				if (currentTabID >= tabsList.Count)
				{
					currentTabID = 0;
				}
				if (tabsList[currentTabID].IsAvailable)
				{
					ActiveTab = tabsList[currentTabID];
					break;
				}
			}
		}

		public virtual void PreviousTab()
		{
			int num = tabsList.IndexOf(ActiveTab);
			if (num == 0 && !isCarousel)
			{
				return;
			}
			for (int i = 0; i < tabsList.Count; i++)
			{
				num--;
				if (num < 0)
				{
					num = tabsList.Count - 1;
				}
				if (tabsList[num].IsAvailable)
				{
					ActiveTab = tabsList[num];
					break;
				}
			}
		}

		protected virtual void UpdateView()
		{
		}

		protected virtual void SetActiveTab(T value, bool silently = false)
		{
			activeTab = value;
			foreach (T tabs in tabsList)
			{
				tabs.IsChosen = tabs == ActiveTab;
			}
			if (!silently)
			{
				this.ActiveTabChanged?.Invoke(this, activeTab);
			}
			UpdateView();
		}

		protected void ClearActiveTabChanged()
		{
			this.ActiveTabChanged = null;
		}

		protected void OnActiveTabChanged()
		{
			this.ActiveTabChanged?.Invoke(this, activeTab);
		}

		protected void OnTabsChanged()
		{
			this.TabsChanged?.Invoke(this);
		}
	}
}
