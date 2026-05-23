using MG_BlocksEngine2.Block.Instruction;
using UnityEngine;

public class Block_WhenRocketLaunched : BE2_InstructionBase, I_BE2_Instruction
{
	protected override void OnAwake()
	{
		base.BlocksStack.OnStackLastBlockExecuted.AddListener(EndExecution);
	}

	private void OnEnable()
	{
		GameManager.S.OnRocketLaunch -= S_OnRocketLaunch;
		GameManager.S.OnRocketLaunch += S_OnRocketLaunch;
	}

	private void S_OnRocketLaunch(int obj)
	{
		Debug.Log("RocketLaunched");
		base.BlocksStack.IsActive = true;
	}

	private void EndExecution()
	{
		base.BlocksStack.IsActive = false;
	}

	private void OnDestroy()
	{
		GameManager.S.OnRocketLaunch -= S_OnRocketLaunch;
	}

	public new void Function()
	{
		ExecuteSection(0);
	}
}
