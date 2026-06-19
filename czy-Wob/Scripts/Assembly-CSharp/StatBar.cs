using UnityEngine;
using UnityEngine.UI;

public class StatBar : MonoBehaviour
{
	public Need needType;

	public Color fullColorBar;

	public Color midColorBar;

	public Color emptyColorBar;

	public Color fullColorBarUnderlay;

	public Color midColorBarUnderlay;

	public Color emptyColorBarUnderlay;

	public Image overlay;

	public Image underlay;

	public GameObject overlayScaler;

	private float updateRate = 2f;

	private float currentStatValue = 1f;

	private float currentTargetStatValue = 1f;

	private DoggyBrain activeBrainRef;

	private SaveableDog saveableDogRef;

	private MaterialPropertyBlock propertyBlock;

	private void Awake()
	{
		propertyBlock = new MaterialPropertyBlock();
	}

	private void Update()
	{
		if (activeBrainRef == null)
		{
			return;
		}
		UpdateTargetStatValue();
		if (currentStatValue == currentTargetStatValue)
		{
			return;
		}
		if (currentStatValue < currentTargetStatValue)
		{
			currentStatValue += Time.deltaTime * updateRate;
			if (currentStatValue > currentTargetStatValue)
			{
				currentStatValue = currentTargetStatValue;
			}
		}
		else
		{
			currentStatValue -= Time.deltaTime * updateRate;
			if (currentStatValue < currentTargetStatValue)
			{
				currentStatValue = currentTargetStatValue;
			}
		}
		UpdateVisuals();
	}

	private void UpdateVisuals()
	{
		overlayScaler.transform.localScale = new Vector3(currentStatValue / 1f, 1f, 1f);
		UpdateBarColors();
	}

	public void SetBrainRef(DoggyBrain newBrain)
	{
		activeBrainRef = newBrain;
		if (newBrain == null)
		{
			currentStatValue = 1f;
			currentTargetStatValue = 1f;
			UpdateVisuals();
		}
		else
		{
			UpdateTargetStatValue();
			currentStatValue = currentTargetStatValue;
			UpdateVisuals();
		}
	}

	public void SetSaveableDogRef(SaveableDog newDog)
	{
		saveableDogRef = newDog;
		if (newDog != null)
		{
			UpdateTargetStatValue();
			currentStatValue = currentTargetStatValue;
			UpdateVisuals();
		}
	}

	private void UpdateTargetStatValue()
	{
		if (activeBrainRef != null)
		{
			currentTargetStatValue = activeBrainRef.GetPercentageValueForNeed(needType);
		}
		else if (saveableDogRef != null)
		{
			switch (needType)
			{
			case Need.Energy:
				currentTargetStatValue = saveableDogRef.brain.energy;
				break;
			case Need.Hunger:
				currentTargetStatValue = saveableDogRef.brain.hunger;
				break;
			case Need.Stress:
				currentTargetStatValue = saveableDogRef.brain.stress;
				break;
			case Need.Boredom:
				currentTargetStatValue = saveableDogRef.brain.boredom;
				break;
			case Need.None:
			case Need.Random:
			case Need.Anger:
				break;
			}
		}
		else
		{
			currentTargetStatValue = currentStatValue;
		}
	}

	private void UpdateBarColors()
	{
		if (currentStatValue <= 0.33f)
		{
			overlay.color = emptyColorBar;
			underlay.color = emptyColorBarUnderlay;
		}
		else if (currentStatValue <= 0.66f)
		{
			overlay.color = midColorBar;
			underlay.color = midColorBarUnderlay;
		}
		else
		{
			overlay.color = fullColorBar;
			underlay.color = fullColorBarUnderlay;
		}
	}
}
