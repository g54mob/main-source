using Restory.UserInterface.CommonElements;
using UnityEngine;

namespace Restory.UI.Views.DayEndWindow
{
	public class GUI_NewDayButton : MonoBehaviour
	{
		[SerializeField]
		private GUI_AnimatedButtonView newDayButtonView;

		[SerializeField]
		private GUI_DayEndStamp dayEndStamp;

		private void OnEnable()
		{
			newDayButtonView.OnAnimationStart += ResolveNewDayButtonClick;
		}

		private void OnDisable()
		{
			newDayButtonView.OnAnimationStart -= ResolveNewDayButtonClick;
		}

		private void ResolveNewDayButtonClick()
		{
			dayEndStamp.Activate();
		}
	}
}
