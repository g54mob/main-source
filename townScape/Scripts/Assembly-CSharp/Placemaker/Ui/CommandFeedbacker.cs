using UnityEngine;
using UnityEngine.EventSystems;

namespace Placemaker.Ui
{
	public class CommandFeedbacker : UIBehaviour, UiMaster.IUiSetup
	{
		[SerializeField]
		private UiMaster master;

		private float lastFeedbackTime;

		private float enableTime;

		private CanvasGroup canvasGroup;

		[SerializeField]
		private Transform scaler;

		private float scaleAmount;

		private float alphaAmount;

		void UiMaster.IUiSetup.OnStart(UiMaster master)
		{
		}

		void UiMaster.IUiSetup.OnSetup(UiMaster master)
		{
		}

		private void Update()
		{
		}

		public void Feedback()
		{
		}
	}
}
