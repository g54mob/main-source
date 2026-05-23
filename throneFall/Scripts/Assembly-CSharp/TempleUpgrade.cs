using UnityEngine;

public class TempleUpgrade : MonoBehaviour, DayNightCycle.IDaytimeSensitive, ISaveLoad
{
	public enum State
	{
		NotEnabledYet = 0,
		EnabledTonight = 1,
		NotEnabledAnymore = 2
	}

	[SerializeField]
	private BuildingInteractor buildingInteractor;

	[SerializeField]
	private GameObject activeIndicator;

	private State state;

	private bool effectCurrentlyEnabled;

	private bool hasLoadedDataFromSave;

	private void Start()
	{
		DayNightCycle.Instance.RegisterDaytimeSensitiveObject(this);
	}

	public void OnDawn_AfterSunrise()
	{
	}

	public void OnDawn_BeforeSunrise()
	{
		if (effectCurrentlyEnabled)
		{
			DisableEffectAtDawn();
			state = State.NotEnabledAnymore;
			activeIndicator.gameObject.SetActive(value: false);
			buildingInteractor.buildingIsCurrentlyBusyAndCantBeUpgraded = false;
			buildingInteractor.UpdateInteractionState();
			effectCurrentlyEnabled = false;
		}
	}

	public void OnDusk()
	{
		if (state == State.EnabledTonight)
		{
			effectCurrentlyEnabled = true;
			EnableEffectAtDusk();
		}
	}

	private void OnEnable()
	{
		ManualLoad(GetComponentInParent<SaveLoadEntity>().GUID);
		if (!hasLoadedDataFromSave && state == State.NotEnabledYet)
		{
			activeIndicator.SetActive(value: true);
			buildingInteractor.buildingIsCurrentlyBusyAndCantBeUpgraded = true;
			buildingInteractor.UpdateInteractionState();
			state = State.EnabledTonight;
			EnableEffectAtPurchase();
		}
		else
		{
			state = State.NotEnabledAnymore;
		}
	}

	public void OnSave(string guid)
	{
		State state = this.state;
		if (state == State.EnabledTonight)
		{
			state = State.NotEnabledAnymore;
		}
		MatchSaveLoadHandler.SaveValue(guid, base.transform.parent.gameObject.name + "_" + base.gameObject.name + "_state", (int)state);
	}

	private void ManualLoad(string guid)
	{
		if (MatchSaveLoadHandler.IsLoadingPermitted)
		{
			int value = -1;
			hasLoadedDataFromSave = MatchSaveLoadHandler.TryLoadValue(guid, base.transform.parent.gameObject.name + "_" + base.gameObject.name + "_state", ref value);
			if (hasLoadedDataFromSave)
			{
				state = (State)value;
			}
		}
	}

	public void OnDuskEarly()
	{
	}

	public void OnBeforeMainLoadPass(string guid)
	{
	}

	public void OnLoad(string guid)
	{
	}

	public void OnAfterMainLoadPass(string guid)
	{
	}

	public virtual void EnableEffectAtDusk()
	{
	}

	public virtual void DisableEffectAtDawn()
	{
	}

	public virtual void EnableEffectAtPurchase()
	{
	}
}
