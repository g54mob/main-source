using System.Collections.Generic;

public class Relic_BomberPackage : ARelicBase
{
	private int triggerCountInThisRound;

	private List<CardData> list_TriggeredCard;

	protected override void OnEnableProc()
	{
	}

	protected override void OnDisableProc()
	{
	}

	private void OnHandCardChanged(List<CardData> list)
	{
	}

	private void OnRequestMulligan()
	{
	}

	private void OnRoundEnd()
	{
	}
}
