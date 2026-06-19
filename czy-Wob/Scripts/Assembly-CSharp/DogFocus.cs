using UnityEngine;
using UnityStandardAssets.ImageEffects;

public class DogFocus : MonoBehaviour
{
	public DepthOfField DOFRef;

	private GameObject selectedDog;

	private GameObject newFocusDog;

	private GameObject customFocusObj;

	private float targetAperture = 0.5f;

	private float apertureAttackTime = 1f;

	private float apertureDecayTime = 0.5f;

	private float currentTimer;

	private bool DOFOptionEnabled = true;

	private bool frozen;

	private PenFocus penFocusRef;

	private ObjectGrabber grabberRef;

	private void Awake()
	{
		DOFRef.aperture = 0f;
		penFocusRef = GetComponent<PenFocus>();
		grabberRef = ObjectRegistration.GetRegistrationScript().GetGlobalComponent<ObjectGrabber>(GlobalObject.OBJECT_GRABBER);
	}

	private void Update()
	{
		if (!frozen)
		{
			UpdateFocus();
			UpdateDOF();
		}
	}

	public void SetDOFOptionEnabled(bool val)
	{
		DOFOptionEnabled = val;
	}

	public bool IsDOFOptionEnabled()
	{
		return DOFOptionEnabled;
	}

	public void Freeze()
	{
		frozen = true;
		currentTimer = 0f;
	}

	public void Unfreeze()
	{
		frozen = false;
	}

	private void UpdateFocus()
	{
		if (penFocusRef == null || customFocusObj != null)
		{
			return;
		}
		if (!DOFOptionEnabled)
		{
			ClearDog();
			return;
		}
		Transform followTarget = penFocusRef.GetFollowTarget();
		if (selectedDog != null && !grabberRef.IsHoldingDog() && followTarget == null)
		{
			ClearDog();
		}
		else if (followTarget != null)
		{
			SelectNewDog(followTarget.root.gameObject);
		}
		else if (grabberRef.IsHoldingDog())
		{
			SelectNewDog(grabberRef.GetGrabbedObject());
		}
	}

	public void SetCustomFocusTarget(GameObject newTarget)
	{
		SelectNewDog(newTarget);
		customFocusObj = newTarget;
	}

	public void ClearCustomFocusTarget()
	{
		customFocusObj = null;
	}

	private void SelectNewDog(GameObject dog)
	{
		if (dog == null)
		{
			return;
		}
		LegController component = dog.GetComponent<LegController>();
		GameObject gameObject = dog;
		if (component != null)
		{
			gameObject = component.bodyFront;
		}
		else
		{
			Cocoon component2 = dog.GetComponent<Cocoon>();
			if (component2 != null)
			{
				gameObject = component2.rigidbodyRef.gameObject;
			}
			else
			{
				Rigidbody componentInChildren = dog.GetComponentInChildren<Rigidbody>();
				if (componentInChildren != null)
				{
					gameObject = componentInChildren.gameObject;
				}
			}
		}
		if (selectedDog != gameObject)
		{
			if (selectedDog != null)
			{
				newFocusDog = dog;
				ClearDog();
				return;
			}
			newFocusDog = null;
			DOFRef.focalTransform = gameObject.transform;
			selectedDog = gameObject;
			penFocusRef.SetStartingAperture(targetAperture);
		}
	}

	private void ClearDog()
	{
		float num = currentTimer / apertureAttackTime;
		currentTimer = apertureDecayTime * num;
		selectedDog = null;
		penFocusRef.SetStartingAperture(0f);
	}

	private void UpdateDOF()
	{
		if (penFocusRef.IsInPhotoMode())
		{
			if (selectedDog == null)
			{
				DOFRef.focalTransform = null;
			}
		}
		else if (selectedDog == null)
		{
			if (DOFRef.aperture > 0f)
			{
				DecayDOF();
			}
		}
		else if (DOFRef.aperture < targetAperture)
		{
			AttackDOF();
		}
	}

	public void DisableDOFImmediate()
	{
		if (!penFocusRef.IsInPhotoMode())
		{
			currentTimer = Time.unscaledDeltaTime / 2f;
			DecayDOF();
		}
	}

	private void DecayDOF()
	{
		if (currentTimer <= 0f)
		{
			if (DOFRef.aperture > 0f)
			{
				DOFRef.aperture = 0f;
			}
			return;
		}
		currentTimer -= Time.unscaledDeltaTime;
		DOFRef.aperture = Mathf.Max(targetAperture * (currentTimer / apertureDecayTime), 0f);
		if (currentTimer <= 0f)
		{
			DOFRef.focalTransform = null;
			if (newFocusDog != null)
			{
				SelectNewDog(newFocusDog);
			}
		}
	}

	private void AttackDOF()
	{
		if (currentTimer >= apertureAttackTime)
		{
			currentTimer = apertureAttackTime;
			return;
		}
		currentTimer += Time.unscaledDeltaTime;
		DOFRef.aperture = Mathf.Min(targetAperture * (currentTimer / apertureAttackTime), targetAperture);
	}
}
