using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace ModIOBrowser
{
	public class TagJumpToSelection : MonoBehaviour, ISelectHandler, IEventSystemHandler
	{
		public Selectable selection;

		public static List<TagJumpToSelection> selections;

		private static TagJumpToSelection currentCategory;

		public static void ClearCache()
		{
		}

		public void Setup()
		{
		}

		public static void GoToPreviousSelection()
		{
		}

		public static void GoToNextSelection()
		{
		}

		private static int CurrentIndex()
		{
			return 0;
		}

		private static int NextIndex()
		{
			return 0;
		}

		private static int PreviousIndex()
		{
			return 0;
		}

		public static bool CanTabLeft()
		{
			return false;
		}

		public static bool CanTabRight()
		{
			return false;
		}

		public void OnSelect(BaseEventData eventData)
		{
		}
	}
}
