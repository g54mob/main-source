using UnityEngine;
using UnityEngine.UI;

namespace Placemaker.Ui
{
	public class DisableableButton : MonoBehaviour, UiMaster.IUiSetup
	{
		[SerializeField]
		private DistanceFieldSettings icon;

		[SerializeField]
		private Graphic text;

		[SerializeField]
		private Graphic background;

		public UpdateState disabledState;

		private Color bgColor0;

		private Color bgColor1;

		void UiMaster.IUiSetup.OnStart(UiMaster master)
		{
		}

		void UiMaster.IUiSetup.OnSetup(UiMaster master)
		{
		}
	}
}
