using System.Collections.Generic;
using UnityEngine.UI;

public class StepByStepView : BaseGUIView
{
	public const string ResetEvent = "StepByStepView.ResetEvent";

	private StepByStepSlot stepByStepSlot;

	private Button resetButton;

	private List<VideoPlayerFixer> videoPlayers;

	public override void Initialize()
	{
		stepByStepSlot = mainPanel.transform.FindComponent<StepByStepSlot>("StepByStepWindow", isRecursively: true);
		stepByStepSlot.ParentCanvas = base.ParentCanvas;
		stepByStepSlot.SaveWindowPosition();
		resetButton = mainPanel.transform.FindComponent<Button>("ResetButton", isRecursively: true);
		resetButton.onClick.AddListener(delegate
		{
			NotifyChange("StepByStepView.ResetEvent");
		});
		videoPlayers = new List<VideoPlayerFixer>();
		mainPanel.GetComponentsInChildren(includeInactive: true, videoPlayers);
		Util.AddMouseOverUIEvents(mainPanel, base.OnMouseOverUIHandler);
	}

	public override void SetVisibility(bool isVisible)
	{
		base.SetVisibility(isVisible);
		for (int i = 0; i < videoPlayers.Count; i++)
		{
			if (videoPlayers[i].gameObject.activeInHierarchy)
			{
				if (isVisible)
				{
					videoPlayers[i].PlayVideo();
				}
				else
				{
					videoPlayers[i].StopVideo();
				}
			}
		}
	}

	public void SetTutorialPage(string levelId)
	{
		stepByStepSlot.SetTutorialPage(levelId);
	}

	public void SetStepPage(int pageNumber)
	{
		stepByStepSlot.SetStepPage(pageNumber);
	}

	public void ResetWindowPosition()
	{
		stepByStepSlot.ResetWindowPosition();
	}
}
