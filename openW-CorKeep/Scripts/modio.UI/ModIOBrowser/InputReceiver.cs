using ModIO.Util;
using ModIOBrowser.Implementation;

namespace ModIOBrowser
{
	public static class InputReceiver
	{
		internal static InputFieldCoadjutant currentSelectedInputField;

		public static void OnCancel()
		{
			if (Browser.IsOpen)
			{
				SelfInstancingMonoSingleton<InputNavigation>.Instance.SetToController();
				Navigating.Cancel();
			}
		}

		public static void OnAlternate()
		{
			if (Browser.IsOpen)
			{
				SelfInstancingMonoSingleton<InputNavigation>.Instance.SetToController();
				Navigating.Alternate();
			}
		}

		public static void OnOptions()
		{
			if (Browser.IsOpen)
			{
				SelfInstancingMonoSingleton<InputNavigation>.Instance.SetToController();
				Navigating.Options();
			}
		}

		public static void OnTabRight()
		{
			if (Browser.IsOpen)
			{
				SelfInstancingMonoSingleton<InputNavigation>.Instance.SetToController();
				Navigating.TabRight();
			}
		}

		public static void OnTabLeft()
		{
			if (Browser.IsOpen)
			{
				SelfInstancingMonoSingleton<InputNavigation>.Instance.SetToController();
				Navigating.TabLeft();
			}
		}

		public static void OnSearch()
		{
			if (Browser.IsOpen)
			{
				SelfInstancingMonoSingleton<InputNavigation>.Instance.SetToController();
				SelfInstancingMonoSingleton<SearchPanel>.Instance.ToggleState();
			}
		}

		public static void OnMenu()
		{
			if (Browser.IsOpen)
			{
				SelfInstancingMonoSingleton<InputNavigation>.Instance.SetToController();
				Navigating.MenuInput();
			}
		}

		public static void OnControllerScroll(float direction)
		{
			if (Browser.IsOpen)
			{
				SelfInstancingMonoSingleton<InputNavigation>.Instance.SetToController();
				Navigating.Scroll(direction);
			}
		}

		public static void OnSetToControllerNavigation()
		{
			if (Browser.IsOpen)
			{
				SelfInstancingMonoSingleton<InputNavigation>.Instance.SetToController();
			}
		}

		public static void OnSetToMouseNavigation(bool force = false)
		{
			if (Browser.IsOpen || force)
			{
				SelfInstancingMonoSingleton<InputNavigation>.Instance.SetToMouse();
			}
		}
	}
}
