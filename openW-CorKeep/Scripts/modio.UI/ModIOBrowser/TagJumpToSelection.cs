using System.Collections.Generic;
using ModIO.Util;
using ModIOBrowser.Implementation;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace ModIOBrowser
{
	public class TagJumpToSelection : MonoBehaviour, ISelectHandler, IEventSystemHandler
	{
		public Selectable selection;

		public static List<TagJumpToSelection> selections = new List<TagJumpToSelection>();

		private static TagJumpToSelection currentCategory;

		public static void ClearCache()
		{
			selections.Clear();
			currentCategory = null;
		}

		public void Setup()
		{
			selections.Add(this);
			if (currentCategory == null)
			{
				currentCategory = this;
			}
		}

		public static void GoToPreviousSelection()
		{
			SelfInstancingMonoSingleton<InputNavigation>.Instance.Select(selections[PreviousIndex()].selection);
		}

		public static void GoToNextSelection()
		{
			SelfInstancingMonoSingleton<InputNavigation>.Instance.Select(selections[NextIndex()].selection);
		}

		private static int CurrentIndex()
		{
			if (currentCategory == null || !selections.Contains(currentCategory))
			{
				return 0;
			}
			return selections.IndexOf(currentCategory);
		}

		private static int NextIndex()
		{
			if (CurrentIndex() + 1 >= selections.Count)
			{
				return CurrentIndex();
			}
			return CurrentIndex() + 1;
		}

		private static int PreviousIndex()
		{
			if (CurrentIndex() - 1 < 0)
			{
				return CurrentIndex();
			}
			return CurrentIndex() - 1;
		}

		public static bool CanTabLeft()
		{
			if (CurrentIndex() == 0)
			{
				return false;
			}
			return true;
		}

		public static bool CanTabRight()
		{
			if (CurrentIndex() + 1 >= selections.Count)
			{
				return false;
			}
			return true;
		}

		public void OnSelect(BaseEventData eventData)
		{
			currentCategory = this;
			SelfInstancingMonoSingleton<SearchPanel>.Instance.UpdateBumperIcons();
		}
	}
}
