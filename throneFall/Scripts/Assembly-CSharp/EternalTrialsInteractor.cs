using UnityEngine;

public class EternalTrialsInteractor : InteractorBase
{
	[SerializeField]
	private GameObject focusPanel;

	public Transform banner;

	public override string ReturnTooltip()
	{
		return TextTranslator.Translate("Menu/Level Interactor Cue");
	}

	public override void Focus(PlayerInteraction player)
	{
		focusPanel.SetActive(value: true);
	}

	public override void Unfocus(PlayerInteraction player)
	{
		focusPanel.SetActive(value: false);
	}

	public override void InteractionBegin(PlayerInteraction player)
	{
		if (!InGamePopUpHelper.instance || !InGamePopUpHelper.instance.PopEternalTrials())
		{
			UIFrameManager.TryOpenEternalTrialsSelect();
		}
	}
}
