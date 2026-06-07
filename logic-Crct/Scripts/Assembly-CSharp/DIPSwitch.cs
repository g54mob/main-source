using Simulation;
using UnityEngine;

public class DIPSwitch : PinComponent
{
	public DipswitchSize size;

	public DIPSwitchElement switchElm;

	public bool[] positions;

	public Vector3[] switchPositions;

	public Transform[] switchTransforms;

	private DIPSwitchSingle[] switches;

	private int pairs;

	public override void FinishPlacement()
	{
	}

	public override void AttachToSim()
	{
	}

	public override void ReattachToSim()
	{
	}

	public override void DetachFromSim()
	{
	}

	private void UpdateSwitchTransforms()
	{
	}

	public void SwitchClicked(int i)
	{
	}

	public override object[] VarData()
	{
		return null;
	}

	public override object[] ReturnSaveData()
	{
		return null;
	}

	public override void ProcessVarData(object[] data)
	{
	}

	public override void ProcessSaveData(object[] data)
	{
	}
}
