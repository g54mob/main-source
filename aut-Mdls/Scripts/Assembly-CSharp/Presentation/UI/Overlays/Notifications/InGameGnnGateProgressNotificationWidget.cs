using Data.Variables;
using TMPro;
using UnityEngine;

namespace Presentation.UI.Overlays.Notifications
{
	public class InGameGnnGateProgressNotificationWidget : InGameNotificationWidget
	{
		[Header("GNN Gate Progress UI")]
		[SerializeField]
		private TextMeshProUGUI _text;

		[SerializeField]
		private IntVariableSO _GNNGateCurrentFloorSO;

		[SerializeField]
		private IntVariableSO _GNNGateCurrentPhaseSO;

		protected override void UpdateNotification(InGameNotificationDto inGameNotificationDto)
		{
			int num = _GNNGateCurrentPhaseSO.Value;
			int num2 = _GNNGateCurrentFloorSO.Value;
			if (num2 == 0)
			{
				num2 = 5;
				num--;
			}
			_text.text = string.Format(LocalizationUtility.GetLocalizedText("GeneralProgression.GNNGateNotification"), $"<b>{num}</b>", $"<b>{num2}</b>");
			SetupTimer(inGameNotificationDto.Duration);
		}
	}
}
