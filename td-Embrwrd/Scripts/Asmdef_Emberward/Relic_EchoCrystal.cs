using System.Collections.Generic;

public class Relic_EchoCrystal : ARelicBase
{
	private List<ABaseBuffSettingData> list_EchoedBuffs;

	protected override void OnEnableProc()
	{
	}

	protected override void OnDisableProc()
	{
	}

	private void OnApplyBuffCard(ABaseBuffSettingData data, bool isFromPlayer, bool isPlayerAction)
	{
	}
}
