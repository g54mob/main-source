using System.Collections.Generic;
using Aggro.Core;
using Aggro.Core.Networking;
using TMPro;

public class TotalBellCountUI : EntityBehaviourBase
{
	private TextMeshProUGUI _text;

	private List<ContractObject> _contracts = new List<ContractObject>();

	private int _total;

	protected override void OnEntityCreated()
	{
		_text = GetComponent<TextMeshProUGUI>();
		_contracts.Clear();
	}

	protected override void OnUpdatePresentation()
	{
		_total = NetworkAggroManagerBase<LobbyManager>.instance.hostTotalBells;
		_text.text = _total.ToString();
	}
}
