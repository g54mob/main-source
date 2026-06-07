using System.Collections.Generic;

public class Achievement_ElectricCurrent : AAchievementDetector
{
	private int currentConnected;

	protected override void IngameDetectStartProc()
	{
	}

	protected override void IngameDetectStopProc()
	{
	}

	private void OnAncientCircuitUpdated(List<Obj_ElectricCircuit.ElectricCircuitNode> list_Nodes, List<Obj_AncientMech_Base> list_AncientMechs)
	{
	}

	private void OnPlayerVictory()
	{
	}

	protected override void InstantCheckProc()
	{
	}
}
