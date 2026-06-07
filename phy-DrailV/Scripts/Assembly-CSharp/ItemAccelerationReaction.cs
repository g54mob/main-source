using System.Collections;
using DV;
using DV.CabControls;
using DV.Utils;
using DV.VRTK_Extensions;
using UnityEngine;
using VRTK;

public class ItemAccelerationReaction : MonoBehaviour
{
	public bool canReactToAcceleration = true;

	public float accelerationThreshold = 100f;

	protected VRTK_VelocityEstimator_DV velocityEstimator;

	private ItemBase item;

	private int skipFrames;

	protected virtual void Awake()
	{
		if (!VRManager.IsVREnabled())
		{
			Object.Destroy(this);
		}
	}

	protected virtual void Start()
	{
		SingletonBehaviour<CoroutineManager>.Instance.Run(SetupInteractable());
	}

	private IEnumerator SetupInteractable()
	{
		VRTK_InteractableObject component;
		while ((component = GetComponent<VRTK_InteractableObject>()) == null)
		{
			yield return null;
		}
		component.InteractableObjectGrabbed += OnGrabbed;
		component.InteractableObjectUngrabbed += OnUngrabbed;
	}

	private void OnGrabbed(object sender, InteractableObjectEventArgs e)
	{
		velocityEstimator = e.interactingObject.GetComponentInParent<VRTK_VelocityEstimator_DV>();
		if ((bool)velocityEstimator)
		{
			skipFrames = velocityEstimator.velocityAverageFrames * 2;
		}
		else
		{
			Debug.LogError("ItemAccelerationReaction couldn't find controller's velocity estimator for '" + base.gameObject.name + "'", this);
		}
	}

	private void OnUngrabbed(object sender, InteractableObjectEventArgs e)
	{
		velocityEstimator = null;
	}

	private void Update()
	{
		if (!velocityEstimator)
		{
			return;
		}
		if (skipFrames > 0)
		{
			skipFrames--;
			return;
		}
		if (!item)
		{
			item = base.gameObject.GetComponent<ItemBase>();
		}
		if (canReactToAcceleration && (bool)item && item.IsGrabbed() && !SingletonBehaviour<AppUtil>.Instance.IsTimePaused)
		{
			TryReactToAcceleration();
		}
	}

	protected virtual void TryReactToAcceleration()
	{
	}
}
