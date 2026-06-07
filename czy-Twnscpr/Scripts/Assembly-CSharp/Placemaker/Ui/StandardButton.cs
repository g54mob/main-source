using UnityEngine;

namespace Placemaker.Ui
{
	public class StandardButton : MonoBehaviour, UiMaster.IUiSetup
	{
		public UpdateState scaleZ;

		public UpdateState scaleXY;

		void UiMaster.IUiSetup.OnStart(UiMaster master)
		{
		}

		void UiMaster.IUiSetup.OnSetup(UiMaster master)
		{
		}
	}
}
