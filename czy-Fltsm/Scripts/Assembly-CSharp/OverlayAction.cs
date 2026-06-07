using UnityEngine;

[CreateAssetMenu(fileName = "Overlay Action", menuName = "Flotsam/Actions/Overlay")]
public class OverlayAction : SimpleAction
{
	[Header("Overlay")]
	[SerializeField]
	private Overlays.Type _overlay;

	[SerializeField]
	private PanelID _architectPanelId = PanelID.ArchitectBottomBar;

	[SerializeField]
	private RequirementBase[] _requirments;

	public override bool IsInteractable
	{
		get
		{
			if (_requirments.IsNullOrEmpty())
			{
				return true;
			}
			RequirementBase[] requirments = _requirments;
			for (int i = 0; i < requirments.Length; i++)
			{
				if (!requirments[i].IsMet())
				{
					return false;
				}
			}
			return true;
		}
	}

	public override bool IsSelected => Overlays.OverlayType == _overlay;

	public override void Trigger()
	{
		Overlays.OverlayType = _overlay;
		if (_overlay == Overlays.Type.Architect)
		{
			GameManager.UIManager.DisplayPanel(_architectPanelId);
		}
	}
}
