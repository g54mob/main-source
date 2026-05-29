using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Placemaker.Ui
{
	public class SunButtonGamepad : UIBehaviour, UiMaster.IUiSetup
	{
		[SerializeField]
		public UiMaster master;

		[SerializeField]
		private UpdateState focusedState;

		[SerializeField]
		private Transform sideMenuTransform;

		[SerializeField]
		private Transform translateTransform;

		[SerializeField]
		private Graphic selector;

		[SerializeField]
		private AudioClip openClip;

		[SerializeField]
		private AudioClip closeClip;

		void UiMaster.IUiSetup.OnSetup(UiMaster master)
		{
		}

		void UiMaster.IUiSetup.OnStart(UiMaster master)
		{
		}

		public void Toggle()
		{
		}

		private void Update()
		{
		}
	}
}
