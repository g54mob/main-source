using UnityEngine;

namespace Placemaker.Ui
{
	public class ActionInputManager : MonoBehaviour, UiMaster.IUiSetup
	{
		[SerializeField]
		private UiMaster master;

		void UiMaster.IUiSetup.OnSetup(UiMaster master)
		{
		}

		void UiMaster.IUiSetup.OnStart(UiMaster master)
		{
		}

		private void Update()
		{
		}
	}
}
