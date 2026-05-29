using I2.Loc;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Placemaker.Ui
{
	public class MaxSavesCounter : UIBehaviour
	{
		[SerializeField]
		private LocalizationParamsManager localizationParamsManagerTop;

		[SerializeField]
		private Localize localizeTop;

		[SerializeField]
		private LocalizationParamsManager localizationParamsManagerChild;

		[SerializeField]
		private Localize localizeChild;

		public void UpdateCountText(string current, string max)
		{
		}
	}
}
