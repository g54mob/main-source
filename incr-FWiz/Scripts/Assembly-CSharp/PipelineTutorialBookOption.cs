using System;
using OUSystems.Basics.UI;
using UnityEngine;
using UnityEngine.UI;

public class PipelineTutorialBookOption : ClickListener
{
	public PipelineTutorial PipelineTutorial;

	public Action<PipelineTutorialBookOption> AnnounceSelect;

	public Image IconImage;

	public Image ButtonImage;

	public Sprite SelectedSprite;

	public Sprite UnselectedSprite;

	public BuildingTooltipTrigger BuildingTooltipTrigger;

	public void Initiate(PipelineTutorial pipelineTutorial)
	{
	}

	public override void Click()
	{
	}

	public void SetSelected()
	{
	}

	public void SetUnselected()
	{
	}
}
