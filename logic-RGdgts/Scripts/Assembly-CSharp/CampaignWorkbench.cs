using System.Collections;

public class CampaignWorkbench : Workbench
{
	public EndDayTool endDayTool;

	private bool lockEndDay;

	public override void UpdateGameplayInteractions()
	{
	}

	public override void OnDestroyGadget()
	{
	}

	public override void SpawnModule(SpawnModuleEventArgs spawnModuleArgs)
	{
	}

	public override void CancelMoveModule()
	{
	}

	public override void SolderModule()
	{
	}

	public override void SpawnMotherboard(SpawnMotherboardEventArgs spawnMotherboardArgs)
	{
	}

	public override void DropMotherboard()
	{
	}

	public override IEnumerator DestroyMotherboard()
	{
		return null;
	}
}
