using UnityEngine;
using UnityEngine.UI;

namespace Placemaker.Ui
{
	public class SavingIndicator : MonoBehaviour, UiMaster.IUiSetup
	{
		[SerializeField]
		private float alpha;

		[SerializeField]
		private Transform anchor;

		[SerializeField]
		private Graphic graphic;

		[SerializeField]
		private bool on;

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
