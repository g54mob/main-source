using UnityEngine;

namespace Restory.UI.Presenters.PC.Apps.Hacking.Lines
{
	public class GUI_TypingTutorialLine : MonoBehaviour
	{
		[SerializeField]
		private GUI_LineOutputHandler outputHandler;

		public void PerformOutput(float outputProgress, out bool outputComplete)
		{
			outputHandler.PerformOutput(outputProgress, out outputComplete);
		}
	}
}
