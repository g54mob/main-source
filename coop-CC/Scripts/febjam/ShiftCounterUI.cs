using Aggro.Core;
using Aggro.Core.Networking;
using TMPro;
using UnityEngine;

public class ShiftCounterUI : EntityBehaviourBase
{
	public TextMeshProUGUI shiftCounterText;

	public Transform container;

	private int _prevShift = -1;

	protected override void OnUpdatePresentation()
	{
		container.gameObject.SetActive(!GameUtil.isLobby && !GameUtil.isTutorial);
		if (!GameUtil.isLobby)
		{
			int currentShift = NetworkAggroManagerBase<ShiftManager>.instance.GetCurrentShift();
			if (_prevShift != currentShift)
			{
				_prevShift = currentShift;
				shiftCounterText.text = currentShift.ToString();
			}
		}
	}
}
