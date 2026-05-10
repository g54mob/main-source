using UnityEngine;

public class PlacementComponentMainMenu : PlacementComponent
{
	[SerializeField]
	private float autoPlaceDelay;

	protected override void Start()
	{
		autoCallPlace = true;
		Invoke("DelayedStart", autoPlaceDelay);
	}

	private void DelayedStart()
	{
		base.Start();
	}
}
