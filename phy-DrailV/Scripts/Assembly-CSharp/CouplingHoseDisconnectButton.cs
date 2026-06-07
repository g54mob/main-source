using DV.CabControls;
using UnityEngine;

public class CouplingHoseDisconnectButton : MonoBehaviour
{
	public CouplingHoseRopeInstance ropeInstance;

	public GameObject buttonGO;

	private ButtonBase button;

	private void OnEnable()
	{
		if ((bool)button)
		{
			button.Used += RequestDisconnect;
		}
	}

	private void Start()
	{
		button = buttonGO.GetComponent<ButtonBase>();
		button.Used += RequestDisconnect;
	}

	private void OnDisable()
	{
		if (!UnloadWatcher.isUnloading && (bool)button)
		{
			button.Used -= RequestDisconnect;
		}
	}

	public void OnAboutToTakeFromPool()
	{
		buttonGO.transform.SetParent(WorldMover.OriginShiftParent);
	}

	public void OnReturnedToPool()
	{
		buttonGO.transform.SetParent(ropeInstance.transform);
	}

	private void RequestDisconnect()
	{
		button.ForceEndInteraction();
		ropeInstance.rig.RequestDisconnect();
	}
}
