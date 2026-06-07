using I18n;
using UnityEngine;

namespace Gh.Tk.UI.InfoPanels
{
	public class SlotMachineInfoPanel : PropInfoPanel
	{
		[SerializeField]
		private TextMeshProI18n _totalProfitText;

		[SerializeField]
		private TextMeshProI18n _totalProfitValueText;

		[SerializeField]
		private TextMeshProI18n _currentJackpotText;

		[SerializeField]
		private TextMeshProI18n _currentJackpotValueText;

		public override void Refresh()
		{
		}
	}
}
