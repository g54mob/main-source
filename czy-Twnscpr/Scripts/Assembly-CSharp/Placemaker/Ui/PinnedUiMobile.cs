using UnityEngine;
using UnityEngine.EventSystems;

namespace Placemaker.Ui
{
	public class PinnedUiMobile : UIBehaviour, UiMaster.IUiSetup
	{
		[SerializeField]
		private UiMaster master;

		[SerializeField]
		private GameObject palettePinTarget;

		[SerializeField]
		private PinnedUi palettePin;

		[SerializeField]
		private SideMenu sideMenu;

		[SerializeField]
		private PinnedUi sidePin;

		[SerializeField]
		private GameObject undoRedoPinTarget;

		private const float PIN_UI_SECONDS = 3f;

		public float pinUiTimer;

		public void OnStart(UiMaster master)
		{
		}

		public void OnSetup(UiMaster master)
		{
		}

		private void Update()
		{
		}

		private void SetPinnedUi(bool pinned)
		{
		}

		private bool isInputReceived()
		{
			return false;
		}
	}
}
