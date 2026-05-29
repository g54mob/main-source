using System.Collections.Generic;
using I2.Loc;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Placemaker.Ui
{
	public class ScaleUiButtons : UIBehaviour, UiMaster.IUiSetup
	{
		[SerializeField]
		private UiMaster master;

		[SerializeField]
		private LocalizationParamsManager localizationParamsManager;

		[SerializeField]
		private Localize localize;

		[SerializeField]
		private TextMeshProUGUI buttonText;

		[SerializeField]
		private BaseButton leftArrow;

		[SerializeField]
		private BaseButton rightArrow;

		[SerializeField]
		private List<byte> scaleList;

		[SerializeField]
		private int selectedIndex;

		void UiMaster.IUiSetup.OnStart(UiMaster master)
		{
		}

		void UiMaster.IUiSetup.OnSetup(UiMaster master)
		{
		}

		public void Button_Left()
		{
		}

		public void Button_Right()
		{
		}

		private void ChangeScale(bool left)
		{
		}

		private void SetNewScale(byte scaleMultiplier)
		{
		}
	}
}
