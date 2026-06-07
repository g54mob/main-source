#define ENABLE_DEBUG_LOGS
using UnityEngine;
using Utils;

[CreateAssetMenu(fileName = "TestGeneralRankUpBehavior", menuName = "Rank System/Behaviors/TestGeneralRankUpBehavior")]
public class TestGeneralRankUpBehavior : AbstractRankUpBehavior
{
	public override void Execute()
	{
		this.Log("You Ranked Up!", "Execute", 9);
	}
}
