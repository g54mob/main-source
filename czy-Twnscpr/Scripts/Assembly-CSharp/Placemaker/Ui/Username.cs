using TMPro;
using UnityEngine;

namespace Placemaker.Ui
{
	public class Username : MonoBehaviour, UiMaster.IUiSetup
	{
		private UiMaster master;

		[SerializeField]
		private TextMeshProUGUI userNameText;

		public void OnSetup(UiMaster master)
		{
		}

		private void Update()
		{
		}

		public void OnStart(UiMaster master)
		{
		}
	}
}
