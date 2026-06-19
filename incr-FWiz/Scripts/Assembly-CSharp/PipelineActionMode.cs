using UnityEngine;

public class PipelineActionMode : PlayerActionMode
{
	public UIPipe InitialSelectedPipeUI;

	[SerializeField]
	private DefaultCustomCursor _baseCursor;

	public PipelineCanvas PipelineCanvas;

	public PipelineTutorialBook TutorialBookPrefab;

	public override bool PlayerCanMove => false;

	public override void OnInitiate()
	{
	}

	private void OnDestroy()
	{
	}

	public void OnCreatePipeWithConnection()
	{
	}

	public void OnSelectPipeUI(UIPipe uiPipe)
	{
	}

	protected override void OnActivate()
	{
	}

	protected override void OnDeactivate()
	{
	}

	public void OnCancel()
	{
	}
}
