using UnityEngine;

namespace Placemaker.Ui
{
	public class Dim : MonoBehaviour, UiMaster.IUiSetup
	{
		public enum State
		{
			Clear = 0,
			Dim = 1,
			Dark = 2
		}

		[SerializeField]
		private UiMaster master;

		[SerializeField]
		public UpdateState alphaState;

		[SerializeField]
		public UpdateState dimOrDark;

		[SerializeField]
		public UpdateState blurState;

		[SerializeField]
		private Color dimColor;

		[SerializeField]
		private Color darkColor;

		public bool awaitingDarkDim => false;

		public void SetState(State state)
		{
		}

		void UiMaster.IUiSetup.OnStart(UiMaster master)
		{
		}

		void UiMaster.IUiSetup.OnSetup(UiMaster master)
		{
		}
	}
}
