using Aggro.Core;
using Aggro.Core.Networking;
using TMPro;
using UnityEngine;

public class MoneyUI : EntityBehaviourBase
{
	public GameObject container;

	public TextMeshProUGUI text;

	private int _prevMoney = -1;

	protected override void OnUpdatePresentation()
	{
		container.SetActive(!GameUtil.isLobby && !GameUtil.isTutorial);
		if (!GameUtil.isLobby)
		{
			int money = NetworkAggroManagerBase<ShiftManager>.instance.GetMoney();
			if (_prevMoney != money)
			{
				_prevMoney = money;
				text.text = "$" + NetworkAggroManagerBase<ShiftManager>.instance.GetMoney();
			}
		}
	}
}
