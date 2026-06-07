using System.Collections.Generic;

public class Relic_StaticShocker : ARelicBase
{
	private class AppliedMonsterData
	{
		public AMonsterBase monster;

		public float lastTriggerTime;
	}

	private List<AppliedMonsterData> list_AppliedMonsters;

	protected override void OnEnableProc()
	{
	}

	protected override void OnDisableProc()
	{
	}

	private void Update()
	{
	}

	private void OnMonsterTriggerElectricEffect(AMonsterBase monster)
	{
	}
}
