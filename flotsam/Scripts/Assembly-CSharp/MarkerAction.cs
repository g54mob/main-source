using I2.Loc;
using UnityEngine;

[CreateAssetMenu(fileName = "Marker Action", menuName = "Flotsam/Actions/Marker Action")]
public class MarkerAction : SimpleAction
{
	[Header("Marker Action")]
	[SerializeField]
	private MarkerCursorProperties _markerCursorProperties;

	[SerializeField]
	private BoatType _boatTypeRequired;

	[SerializeField]
	private LocalizedString _nonInteractableDescrpition;

	public override bool IsInteractable
	{
		get
		{
			if (_boatTypeRequired != BoatType.None)
			{
				return Community.PlayerCommunity.ReturnHasBoatOfType(_boatTypeRequired);
			}
			return true;
		}
	}

	public override void Trigger()
	{
		if (IsInteractable)
		{
			GameManager.CursorManager.Activate(_markerCursorProperties);
		}
	}

	public override LocalizedString GetDescription()
	{
		if (IsInteractable)
		{
			return base.GetDescription();
		}
		return _nonInteractableDescrpition;
	}
}
