using DV.CabControls;
using DV.Teleporters;
using UnityEngine;

public class MapMarker : MonoBehaviour
{
	[Tooltip("The Transform that should be rotated on the map. This is separate, but can be the same, as the root which is moved by position")]
	public Transform rotationVisuals;

	private FastTravelDestination fastTravelDestination;

	public ControlImplBase Button { get; private set; }

	public FastTravelDestination.MarkerType MarkerType => fastTravelDestination.markerType;

	public virtual void Init(FastTravelDestination fastTravelDestination)
	{
		this.fastTravelDestination = fastTravelDestination;
	}

	private void Start()
	{
		ControlImplBase controlImplBase = (Button = GetComponentInChildren<ControlImplBase>());
		if ((bool)controlImplBase)
		{
			Button.Used += OnUsed;
			MapMarkersController.UpdateMapMarkerInteractionState(this);
		}
	}

	private void OnUsed()
	{
		MapMarkersController.InvokeMarkerUsed(fastTravelDestination);
	}
}
