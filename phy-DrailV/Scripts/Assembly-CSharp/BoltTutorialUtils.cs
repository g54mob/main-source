using System.Collections;
using DV.UI;
using DV.Utils;

public static class BoltTutorialUtils
{
	public static IEnumerator WaitForPanelState(CanvasController.ElementType element, bool targetState, string stateMessage)
	{
		bool messageShown = false;
		if (SingletonBehaviour<ACanvasController<CanvasController.ElementType>>.Instance.IsOn(element) != targetState)
		{
			if (!string.IsNullOrEmpty(stateMessage))
			{
				messageShown = true;
				SingletonBehaviour<TutorialHelper>.Instance.ShowTutorialFloatie(stateMessage, null);
			}
			while (SingletonBehaviour<ACanvasController<CanvasController.ElementType>>.Instance.IsOn(element) != targetState)
			{
				yield return null;
			}
			if (messageShown)
			{
				SingletonBehaviour<TutorialHelper>.Instance.HideTutorialFloatie();
			}
		}
	}
}
