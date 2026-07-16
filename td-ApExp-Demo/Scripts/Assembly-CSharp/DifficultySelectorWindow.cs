using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DifficultySelectorWindow : Menu
{
	[SerializeField]
	private RectTransform barFill;

	[SerializeField]
	private TextMeshProUGUI coresGain;

	[SerializeField]
	private TextMeshProUGUI currentWeightTxt;

	[SerializeField]
	private TextMeshProUGUI unlocksTxt;

	[SerializeField]
	public TextMeshProUGUI conditionDescriptionTxt;

	[SerializeField]
	private GameObject contentHolder;

	[SerializeField]
	private GameObject theBox;

	[SerializeField]
	private RectTransform theBoxUI;

	[SerializeField]
	private RectTransform junkSpawnPos;

	[SerializeField]
	private List<GameObject> junkPrefabs;

	private List<DifficultyJunk> spawnedJunkObjects;

	[NonSerialized]
	public int startingJunkObjectCount;

	private bool firstLockedTreshold = true;

	private ControllerType _currentControllerType;

	[field: SerializeField]
	public List<ScalingCondition> scalingConditions { get; private set; }

	[field: SerializeField]
	public List<ToggleCondition> toggledConditions { get; private set; }

	[field: SerializeField]
	public List<Image> Tresholds { get; private set; }

	[field: SerializeField]
	public Sprite TresholdAchieved { get; private set; }

	[field: SerializeField]
	public Sprite TresholdUnachieved { get; private set; }

	[field: SerializeField]
	public Sprite TresholdNext { get; private set; }

	[field: SerializeField]
	public UnitAudioController UnitAudioController { get; private set; }

	public event Action WeightUpdated;

	private void Start()
	{
		for (int i = 0; i < DifficultyManager.Instance.WeightTresholds.Count; i++)
		{
			if (DifficultyManager.Instance.WeightTresholds[i] < DifficultyManager.Instance.maxAllowedWeight)
			{
				Tresholds[i].sprite = TresholdAchieved;
			}
			else if (firstLockedTreshold)
			{
				Tresholds[i].sprite = TresholdNext;
				firstLockedTreshold = false;
			}
			else
			{
				Tresholds[i].sprite = TresholdUnachieved;
			}
		}
		spawnedJunkObjects = new List<DifficultyJunk>();
		for (int j = 0; j < startingJunkObjectCount - 1; j++)
		{
			SpawnJunk(muteSfx: true);
		}
	}

	private void Update()
	{
		Physics2D.Simulate(Time.unscaledDeltaTime);
	}

	protected override void OnOpen()
	{
		base.OnOpen();
		InputHandler.OnAnyInputDetected = (Action<int, ControllerType>)Delegate.Combine(InputHandler.OnAnyInputDetected, new Action<int, ControllerType>(HandleDeviceChanged));
		theBox.SetActive(value: true);
		Vector3 position = Camera.main.ScreenToWorldPoint(theBoxUI.position);
		position.z = 0f;
		theBox.transform.position = position;
	}

	public void SpawnJunk(bool muteSfx = false)
	{
		Vector3 position = Camera.main.ScreenToWorldPoint(junkSpawnPos.position);
		position.z = 0f;
		position.x += UnityEngine.Random.Range(-0.5f, 0.5f);
		GameObject gameObject = junkPrefabs[UnityEngine.Random.Range(0, junkPrefabs.Count)];
		DifficultyJunk component = UnityEngine.Object.Instantiate(gameObject, position, gameObject.transform.rotation, theBox.transform.GetChild(0)).GetComponent<DifficultyJunk>();
		spawnedJunkObjects.Add(component);
		if (!muteSfx)
		{
			UnitAudioController.PlayOnChannel(UnityEngine.Random.Range(0, 3));
		}
	}

	public void DespawnJunk()
	{
		if (spawnedJunkObjects.Count != 0)
		{
			DifficultyJunk difficultyJunk = spawnedJunkObjects[UnityEngine.Random.Range(0, spawnedJunkObjects.Count)];
			spawnedJunkObjects.Remove(difficultyJunk);
			difficultyJunk.Disappear();
		}
	}

	protected override void OnClose()
	{
		base.OnClose();
		InputHandler.OnAnyInputDetected = (Action<int, ControllerType>)Delegate.Remove(InputHandler.OnAnyInputDetected, new Action<int, ControllerType>(HandleDeviceChanged));
		theBox.SetActive(value: false);
	}

	private void HandleDeviceChanged(int playerIndex, ControllerType controllerType)
	{
		if (_currentControllerType != controllerType)
		{
			_currentControllerType = controllerType;
			SetUpForControllerType(controllerType);
		}
	}

	private void SetUpForControllerType(ControllerType controllerType)
	{
	}

	public void UpdateWeightBar(float value)
	{
		DifficultyManager.Instance.UpdateWeight(value);
		float x = 133f * (DifficultyManager.Instance.CurrentWeight / DifficultyManager.Instance.MaxWeight);
		Vector2 sizeDelta = barFill.sizeDelta;
		sizeDelta.x = x;
		barFill.sizeDelta = sizeDelta;
		coresGain.text = "+ " + DifficultyManager.Instance.ShowRewards();
		currentWeightTxt.text = DifficultyManager.Instance.CurrentWeight.ToString();
		if (DifficultyManager.Instance.CurrentWeight == DifficultyManager.Instance.MaxWeight)
		{
			unlocksTxt.text = "If you survive this, which I don't think you will, you will be considered a deity of the Wasteland, statues will be raised in your name, rulers will bend the knee to you... ";
		}
		else if (DifficultyManager.Instance.CurrentWeight == DifficultyManager.Instance.maxAllowedWeight)
		{
			unlocksTxt.text = "You are at maximum capacity, beat the final boss at this threshold to increase weight capacity.";
		}
		else if (DifficultyManager.Instance.CurrentWeight > DifficultyManager.Instance.WeightTresholds[0])
		{
			unlocksTxt.text = "You have reached a weight threshold, you will be granted additional cores during your run. Increase weight to push to the next threshold to increase weight capacity";
		}
		else if (DifficultyManager.Instance.CurrentWeight < DifficultyManager.Instance.maxAllowedWeight)
		{
			unlocksTxt.text = "Add modifiers to increases weight, the more weight you have the more cores you earn. Beat the final boss at certain thresholds, to increases weight capacity.";
		}
		this.WeightUpdated?.Invoke();
	}

	public void MaxAllowedWeightReached()
	{
		foreach (ScalingCondition scalingCondition in scalingConditions)
		{
			scalingCondition.TurnOnButton(scalingCondition.increaseButton, on: false);
			scalingCondition.GreyOut(greyOut: true);
		}
	}
}
