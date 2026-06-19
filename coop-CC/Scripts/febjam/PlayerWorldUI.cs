using Aggro.Core.Networking;
using UnityEngine;

public class PlayerWorldUI : NetworkEntityBehaviourBase
{
	public GameObject selfCareIndicator;

	public VehicleController vehicleController;

	public PlayerStress playerStress;

	protected override void OnUpdatePresentation()
	{
		selfCareIndicator.SetActive(value: false);
		_ = base.isLocalPlayer;
	}

	public override bool Weaved()
	{
		return true;
	}
}
