using UnityEngine;

public class DogIndicatorController : MonoBehaviour
{
	public GameObject dogIndicatorPrefab;

	private bool mouseOver;

	private bool isSelected;

	private bool nameTagEnabled;

	private DogIndicatorPens currentIndicator;

	private void Start()
	{
		CreateIndicator();
	}

	private void OnDestroy()
	{
		if (currentIndicator != null)
		{
			Object.Destroy(currentIndicator.transform.root.gameObject);
			currentIndicator = null;
		}
	}

	public DogIndicatorPens GetIndicatorRef()
	{
		return currentIndicator;
	}

	public void OnPropertyReinforced(string property, float oldPercentage, float newPercentage)
	{
		currentIndicator.OnPropertyReinforced(property, oldPercentage, newPercentage);
	}

	public void OnCommandObeyed(string commandName, Vector3? location = null)
	{
		currentIndicator.ShowActionSucceededUI(commandName, location);
	}

	public void OnCommandIgnored(string customString = "")
	{
		currentIndicator.ShowActionFailedUI(customString);
	}

	public void OnCommandFinished()
	{
		currentIndicator.OnBehaviorFinished();
	}

	public void ReportMouseOver()
	{
		mouseOver = true;
		if (!isSelected)
		{
			EnableDogNameTag();
		}
	}

	public void ReportMouseOff()
	{
		mouseOver = false;
		if (!isSelected)
		{
			DisableDogNameTag();
		}
	}

	public void EnableDogNameTag()
	{
		nameTagEnabled = true;
		if (currentIndicator != null)
		{
			currentIndicator.ShowNameTag();
		}
	}

	public void DisableDogNameTag()
	{
		nameTagEnabled = false;
		if (currentIndicator != null)
		{
			currentIndicator.HideNameTag();
		}
	}

	public void EnableEntireIndicator()
	{
		if (currentIndicator != null)
		{
			currentIndicator.UnlockUI();
		}
	}

	public void DisableEntireIndicator()
	{
		if (currentIndicator != null)
		{
			currentIndicator.LockUI();
		}
	}

	public bool GetIndicatorStatus()
	{
		return nameTagEnabled;
	}

	public void OnDogSelected()
	{
		isSelected = true;
		if (currentIndicator != null)
		{
			currentIndicator.OnDogSelected();
		}
		EnableDogNameTag();
	}

	public void OnDogDeselected(bool forceDisableTag = false)
	{
		isSelected = false;
		if (currentIndicator != null)
		{
			currentIndicator.OnDogDeselected();
		}
		if (!mouseOver || forceDisableTag)
		{
			DisableDogNameTag();
		}
	}

	public void UpdateName(string newName)
	{
		currentIndicator.SetName(newName);
	}

	public void UpdateAge()
	{
		currentIndicator.UpdateDogAge(GetComponent<DoggyBrain>());
	}

	private void CreateIndicator()
	{
		if (currentIndicator == null)
		{
			currentIndicator = Object.Instantiate(dogIndicatorPrefab).GetComponent<DogIndicatorPens>();
		}
		SaveableDog saveableDogFromDog = ObjectRegistration.GetRegistrationScript().GetGlobalComponent<DogRegistration>(GlobalObject.DOG_REGISTRATION).GetSaveableDogFromDog(base.gameObject);
		if (saveableDogFromDog != null)
		{
			currentIndicator.SetName(saveableDogFromDog.dogName);
		}
		currentIndicator.SetBrainRef(GetComponent<DoggyBrain>());
		currentIndicator.transform.localScale = Vector3.one;
		currentIndicator.transform.localPosition = Vector3.zero;
		currentIndicator.GetComponent<WorldSpaceBillboard>().SetFollowTransform(GetComponent<LegController>().bodyFront.transform);
		if (isSelected)
		{
			currentIndicator.OnDogSelected();
		}
		if (!nameTagEnabled)
		{
			DisableDogNameTag();
		}
	}
}
