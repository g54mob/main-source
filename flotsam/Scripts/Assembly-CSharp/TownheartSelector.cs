using System.Collections.Generic;
using PajamaLlama.Fltsm.UI;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class TownheartSelector : MonoBehaviour
{
	[SerializeField]
	private TownheartToggle[] _toggles;

	[SerializeField]
	private TownheartToggle _defaultTownheartToggle;

	[SerializeField]
	private TextMeshProUGUI _labelName;

	[SerializeField]
	private TextMeshProUGUI _labelDescription;

	public UnityAction TownheartSelected;

	private TownheartToggle _toggleThatIsOn;

	private bool _changed;

	private Dictionary<TownheartToggle, Buildable> _spawnedTownhearts = new Dictionary<TownheartToggle, Buildable>();

	private void LateUpdate()
	{
		if (_changed)
		{
			SetToggleThatIsOn(GetToggleThatIsOn());
		}
	}

	public bool Activate()
	{
		int num = 0;
		TownheartToggle[] toggles = _toggles;
		foreach (TownheartToggle townheartToggle in toggles)
		{
			if (townheartToggle.Activate())
			{
				num++;
				townheartToggle.onValueChanged.AddListener(OnTownheartChanged);
				if (townheartToggle.isOn)
				{
					SetToggleThatIsOn(townheartToggle);
				}
			}
		}
		if (num > 1)
		{
			base.gameObject.SetActive(value: true);
			return true;
		}
		if (num > 0 && (bool)_toggleThatIsOn)
		{
			InitializeTownheart(_toggleThatIsOn);
		}
		else
		{
			InitializeTownheart(_defaultTownheartToggle);
		}
		base.gameObject.SetActive(value: false);
		return false;
	}

	private void SetToggleThatIsOn(TownheartToggle toggle)
	{
		if (!(toggle == null) && !(_toggleThatIsOn == toggle))
		{
			if ((bool)_toggleThatIsOn && _spawnedTownhearts.TryGetValue(_toggleThatIsOn, out var value))
			{
				value.gameObject.SetActive(value: false);
			}
			_toggleThatIsOn = toggle;
			_labelName.text = toggle.TownheartProperties.Name;
			_labelDescription.text = TextManager.ReplaceVariables(toggle.TownheartProperties.Description, toggle.TownheartProperties);
			value = GetTownheart(_toggleThatIsOn);
			value.gameObject.SetActive(value: true);
		}
	}

	private void InitializeTownheart(TownheartToggle toggle)
	{
		Buildable townheart = GetTownheart(_toggleThatIsOn);
		townheart.Initialize(Community.PlayerCommunity, 0);
		townheart.FinishBuilding();
		List<CountedItemProperty> startingResources = GameManager.Settings.SessionSettings.StartingScenario.StartingResources;
		for (int i = 0; i < startingResources.Count; i++)
		{
			CountedItemProperty countedItemProperty = startingResources[i];
			for (int j = 0; j < countedItemProperty.Amount; j++)
			{
				Community.PlayerCommunity.SpawnItemToAvailableStorage(countedItemProperty.ItemProperties);
			}
		}
		Construction.Townheart = townheart.ReturnExtendable<Construction>();
		if (townheart.TryReturnBuildableExtendable<MooringPoint>(out var buildableExtendable))
		{
			buildableExtendable.SpawnStartingBoat();
		}
		DestroyNonSelectedTownhearts(townheart);
	}

	private void DestroyNonSelectedTownhearts(Buildable selectedTownheart)
	{
		foreach (Buildable value in _spawnedTownhearts.Values)
		{
			if (!(value == selectedTownheart))
			{
				Object.Destroy(value.gameObject);
			}
		}
	}

	private void OnTownheartChanged(bool value)
	{
		_changed = true;
	}

	public void Confirm()
	{
		InitializeTownheart(_toggleThatIsOn);
		TownheartSelected?.Invoke();
		base.gameObject.SetActive(value: false);
	}

	private TownheartToggle GetToggleThatIsOn()
	{
		TownheartToggle[] toggles = _toggles;
		foreach (TownheartToggle townheartToggle in toggles)
		{
			if (townheartToggle.gameObject.activeInHierarchy && townheartToggle.isOn)
			{
				return townheartToggle;
			}
		}
		return null;
	}

	private Buildable GetTownheart(TownheartToggle toggle)
	{
		if (_spawnedTownhearts.TryGetValue(toggle, out var value))
		{
			return value;
		}
		value = SpawnTownheart(toggle);
		_spawnedTownhearts.Add(toggle, value);
		return value;
	}

	private Buildable SpawnTownheart(TownheartToggle toggle)
	{
		Buildable buildable = Object.Instantiate(toggle.TownheartProperties.Prefab, Vector2.zero, Quaternion.identity);
		buildable.InitializeVisual(0);
		return buildable;
	}
}
