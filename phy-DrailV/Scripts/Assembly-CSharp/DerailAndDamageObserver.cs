using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DV;
using DV.Damage;
using DV.ThingTypes;
using DV.UI;
using DV.UIFramework;
using DV.Utils;
using UnityEngine;

public class DerailAndDamageObserver : MonoBehaviour
{
	private enum PopupType
	{
		Derail = 0,
		Damage = 1
	}

	private struct PopupData
	{
		public readonly string textLocKey;

		public readonly string saveGameKey;

		public readonly bool alreadyShown;

		public PopupData(string textLocKey, string saveGameKey, bool alreadyShown = false)
		{
			this.textLocKey = textLocKey;
			this.saveGameKey = saveGameKey;
			this.alreadyShown = alreadyShown;
		}

		public PopupData UpdateShown(bool shown)
		{
			return new PopupData(textLocKey, saveGameKey, shown);
		}
	}

	private const float MAX_DERAIL_POPUP_WAIT = 20f;

	private const float MAX_DAMAGE_POPUP_WAIT = 20f;

	private const int STATIONARY_FRAME_LIMIT = 5;

	private const float POPUP_DELAY = 3f;

	private const float SPEED_THRESHOLD = 0.1f;

	private HashSet<TrainCar> observedCars = new HashSet<TrainCar>();

	private bool popupRequested;

	private readonly Dictionary<PopupType, PopupData> popupDataDictionary = new Dictionary<PopupType, PopupData>
	{
		{
			PopupType.Derail,
			new PopupData("tutorial/derail", "Derail_Popup_Shown")
		},
		{
			PopupType.Damage,
			new PopupData("tutorial/crash", "Damage_Popup_Shown")
		}
	};

	private float derailStartTime;

	private float damageStartTime;

	private int derailFramesCountdown = 5;

	private int damageFramesCountdown = 5;

	private HashSet<TrainCar> derailedCars = new HashSet<TrainCar>();

	private HashSet<TrainCar> damagedCars = new HashSet<TrainCar>();

	private void Start()
	{
		if (TutorialHelper.InRestrictedMode)
		{
			Object.Destroy(base.gameObject);
		}
		else
		{
			StartCoroutine(Initialize());
		}
	}

	private IEnumerator Initialize()
	{
		while (SingletonBehaviour<SaveGameManager>.Instance.data == null)
		{
			yield return null;
		}
		bool flag = true;
		foreach (PopupType item in popupDataDictionary.Keys.ToList())
		{
			bool? flag2 = SingletonBehaviour<SaveGameManager>.Instance.data.GetBool(popupDataDictionary[item].saveGameKey);
			if (flag2.HasValue && flag2.Value)
			{
				popupDataDictionary[item] = popupDataDictionary[item].UpdateShown(shown: true);
			}
			else
			{
				flag = false;
			}
		}
		if (flag)
		{
			Object.Destroy(base.gameObject);
		}
		else
		{
			SetupListeners(on: true);
		}
	}

	private void OnDestroy()
	{
		if (!UnloadWatcher.isUnloading)
		{
			SetupListeners(on: false);
		}
	}

	private void SetupListeners(bool on)
	{
		if (on)
		{
			SingletonBehaviour<CarSpawner>.Instance.CarSpawned += OnCarSpawned;
			SingletonBehaviour<CarSpawner>.Instance.CarAboutToBeDeleted += OnCarAboutToBeDeleted;
			return;
		}
		SingletonBehaviour<CarSpawner>.Instance.CarSpawned -= OnCarSpawned;
		SingletonBehaviour<CarSpawner>.Instance.CarAboutToBeDeleted -= OnCarAboutToBeDeleted;
		UnsubDerail();
		UnsubDamage();
	}

	private void UnsubDerail()
	{
		foreach (TrainCar observedCar in observedCars)
		{
			if (observedCar != null)
			{
				observedCar.OnDerailed -= OnDerailed;
			}
		}
	}

	private void UnsubDamage()
	{
		foreach (TrainCar observedCar in observedCars)
		{
			if (!(observedCar == null))
			{
				DamageController component = observedCar.GetComponent<DamageController>();
				if (component != null)
				{
					component.MechanicalPTOffDueCollision -= OnDamaged;
				}
			}
		}
	}

	private void OnCarSpawned(TrainCar car)
	{
		if (car == null || car.carType != TrainCarType.LocoShunter || observedCars.Contains(car) || car.uniqueCar || car.playerSpawnedCar)
		{
			return;
		}
		observedCars.Add(car);
		if (!popupDataDictionary[PopupType.Derail].alreadyShown)
		{
			car.OnDerailed += OnDerailed;
		}
		if (!popupDataDictionary[PopupType.Damage].alreadyShown)
		{
			DamageController component = car.GetComponent<DamageController>();
			if (component != null)
			{
				component.MechanicalPTOffDueCollision += OnDamaged;
			}
			else
			{
				Debug.LogError(string.Format("Unexpected state: {0} could not find {1} attached to the car: {2}.", "DerailAndDamageObserver", "DamageController", car), car);
			}
		}
	}

	private void OnDerailed(TrainCar derailedCar)
	{
		if (TutorialHelper.InRestrictedMode)
		{
			return;
		}
		if (derailedCars.Count == 0)
		{
			derailStartTime = Time.time;
		}
		foreach (TrainCar car in derailedCar.trainset.cars)
		{
			derailedCars.Add(car);
		}
	}

	private void OnDamaged(TrainCar affectedCar)
	{
		if (!TutorialHelper.InRestrictedMode)
		{
			if (damagedCars.Count == 0)
			{
				damageStartTime = Time.time;
			}
			damagedCars.Add(affectedCar);
		}
	}

	private void OnCarAboutToBeDeleted(TrainCar car)
	{
		if (observedCars.Remove(car))
		{
			derailedCars.Remove(car);
			damagedCars.Remove(car);
			car.OnDerailed -= OnDerailed;
			DamageController component = car.GetComponent<DamageController>();
			if (component != null)
			{
				component.MechanicalPTOffDueCollision -= OnDamaged;
			}
		}
	}

	private bool ShowPopup(PopupType popupType)
	{
		popupRequested = true;
		StartCoroutine(ShowPopupDelayed(popupType));
		return true;
	}

	private IEnumerator ShowPopupDelayed(PopupType popupType)
	{
		yield return WaitFor.Seconds(3f);
		while (SingletonBehaviour<ACanvasController<CanvasController.ElementType>>.Instance.IsOn(CanvasController.ElementType.Blockers))
		{
			yield return null;
		}
		switch (popupType)
		{
		case PopupType.Derail:
			derailedCars.Clear();
			UnsubDerail();
			break;
		case PopupType.Damage:
			damagedCars.Clear();
			UnsubDamage();
			break;
		}
		PopupData popupData = popupDataDictionary[popupType];
		popupDataDictionary[popupType] = popupData.UpdateShown(shown: true);
		SingletonBehaviour<SaveGameManager>.Instance.data.SetBool(popupData.saveGameKey, value: true);
		SingletonBehaviour<ACanvasController<CanvasController.ElementType>>.Instance.PopupManager.ShowPopup(SingletonBehaviour<ACanvasController<CanvasController.ElementType>>.Instance.uiReferences.popupOk, new PopupLocalizationKeys
		{
			labelKey = popupData.textLocKey,
			positiveKey = "ok"
		});
		bool flag = true;
		foreach (KeyValuePair<PopupType, PopupData> item in popupDataDictionary)
		{
			if (!item.Value.alreadyShown)
			{
				flag = false;
				break;
			}
		}
		popupRequested = false;
		if (flag)
		{
			Object.Destroy(base.gameObject);
		}
	}

	private void Update()
	{
		if (TutorialHelper.InRestrictedMode || popupRequested || !TimeUtil.IsFlowing)
		{
			return;
		}
		if (derailedCars.Count > 0 && !popupDataDictionary[PopupType.Derail].alreadyShown)
		{
			bool flag = true;
			if (derailStartTime + 20f > Time.time)
			{
				foreach (TrainCar derailedCar in derailedCars)
				{
					if (derailedCar != null && derailedCar.GetAbsSpeed() > 0.1f)
					{
						flag = false;
						break;
					}
				}
			}
			if (flag)
			{
				if (derailFramesCountdown <= 0)
				{
					ShowPopup(PopupType.Derail);
					return;
				}
				derailFramesCountdown--;
			}
		}
		if (damagedCars.Count <= 0 || popupDataDictionary[PopupType.Damage].alreadyShown)
		{
			return;
		}
		bool flag2 = true;
		if (damageStartTime + 20f > Time.time)
		{
			foreach (TrainCar damagedCar in damagedCars)
			{
				if (damagedCar != null && damagedCar.GetAbsSpeed() > 0.1f)
				{
					flag2 = false;
					break;
				}
			}
		}
		if (flag2)
		{
			if (damageFramesCountdown > 0)
			{
				damageFramesCountdown--;
			}
			else
			{
				ShowPopup(PopupType.Damage);
			}
		}
	}
}
