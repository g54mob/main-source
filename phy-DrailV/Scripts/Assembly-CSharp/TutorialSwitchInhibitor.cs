using DV.CabControls;
using UnityEngine;

public class TutorialSwitchInhibitor : MonoBehaviour
{
	public JunctionSwitchRemoteControllable junctionSwitch;

	public ControlImplBase manualSwitchCtrlBase;

	private int trainCounter;

	public bool initialized;

	public float radius = 1f;

	public Vector3 overlapHalfExtents;

	private Vector3 overlapOrigin;

	private BoxCollider box;

	private Collider[] overlaps;

	public bool IsBlocked => trainCounter > 0;

	private void Start()
	{
		box = GetComponent<BoxCollider>();
		overlapHalfExtents = box.size;
		InvokeRepeating("FindJunction", 0.1f, 0.1f);
	}

	private void OnDestroy()
	{
		if (junctionSwitch != null)
		{
			junctionSwitch.enabled = true;
		}
	}

	private void FindJunction()
	{
		if (initialized)
		{
			return;
		}
		overlaps = Physics.OverlapBox(base.transform.position + box.center, overlapHalfExtents, base.transform.rotation, LayerMask.GetMask("Laser_Pointer_Target"), QueryTriggerInteraction.Collide);
		for (int i = 0; i < overlaps.Length; i++)
		{
			JunctionSwitchRemoteControllable component = overlaps[i].GetComponent<JunctionSwitchRemoteControllable>();
			if ((bool)component)
			{
				junctionSwitch = component;
				manualSwitchCtrlBase = junctionSwitch.transform.parent.GetComponentInChildren<ControlImplBase>();
				initialized = true;
				CancelInvoke();
				break;
			}
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		if (initialized && (bool)TrainCar.Resolve(other.transform.root))
		{
			junctionSwitch.enabled = false;
			if (manualSwitchCtrlBase != null)
			{
				manualSwitchCtrlBase.InteractionAllowed = false;
			}
			trainCounter++;
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (!initialized)
		{
			return;
		}
		if ((bool)TrainCar.Resolve(other.transform.root))
		{
			trainCounter--;
		}
		if (trainCounter == 0)
		{
			junctionSwitch.enabled = true;
			if (manualSwitchCtrlBase != null)
			{
				manualSwitchCtrlBase.InteractionAllowed = true;
			}
		}
	}
}
