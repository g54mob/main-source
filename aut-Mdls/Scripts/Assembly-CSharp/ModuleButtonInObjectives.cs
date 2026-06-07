using Presentation.FactoryFloor.Toolbar;
using Presentation.UI.Menus.HudPanelTabGroups;
using UnityEngine;

public class ModuleButtonInObjectives : ModuleButton
{
	[SerializeField]
	private ModuleChallengeSetView _challengeSetView;

	[SerializeField]
	private int _indexInSet;

	public int IndexInSet
	{
		set
		{
			_indexInSet = value;
		}
	}

	protected override void HandleClick()
	{
		_hoverGO.SetActive(value: false);
		_showHudPanelEvent.Fire(new ModuleViewerHudPanelData(_moduleViewerPanelSo, _challengeSetView.ChallengeSet.GetModuleViewerData, _indexInSet));
	}
}
