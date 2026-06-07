using UnityEngine;

[CreateAssetMenu(fileName = "Panel Action", menuName = "Flotsam/Actions/Panel Action")]
public class DisplayPanelAction : SimpleAction
{
	[SerializeField]
	private PanelID _panelID;

	[SerializeField]
	[Tooltip("Should the panel state be toggled between open and closed?")]
	private bool _toggle;

	[Header("Requirements")]
	[SerializeField]
	private BuildableProperties[] _requiredBuildables;

	public override bool IsInteractable => AreRequirementsMet();

	public override bool IsSelected
	{
		get
		{
			if ((bool)GameManager.UIManager)
			{
				return GameManager.UIManager.IsPanelOpen(_panelID);
			}
			return false;
		}
	}

	public override void Trigger()
	{
		UIManager uIManager = GameManager.UIManager;
		if (!(uIManager == null) && (!_toggle || !uIManager.ClosePanel(_panelID)))
		{
			uIManager.DisplayPanel(_panelID);
		}
	}

	private bool AreRequirementsMet()
	{
		if (GameManager.UIManager.CanDisplayPanel(_panelID))
		{
			if (_requiredBuildables.IsNullOrEmpty())
			{
				return true;
			}
			BuildableProperties[] requiredBuildables = _requiredBuildables;
			foreach (BuildableProperties buildableProperties in requiredBuildables)
			{
				if (Community.PlayerCommunity.ReturnHasBuildable(buildableProperties))
				{
					return true;
				}
			}
		}
		return false;
	}
}
