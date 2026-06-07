using System;
using System.Collections.Generic;
using ManagementScripts;
using SettingScripts;
using UIScripts.SettingHandles.References;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;
using Utility;

namespace UIScripts.SettingHandles
{
	public class ZoneSettingsHandle : PoolableDictItem<ZoneSettings, ZoneSettingsHandle>, IPointerClickHandler, IEventSystemHandler
	{
		public ZoneSettings settings;

		[NonSerialized]
		public UnityEvent<ZoneSettingsHandle> onItemClicked = new UnityEvent<ZoneSettingsHandle>();

		[NonSerialized]
		public UnityEvent<ZoneSettingsHandle> onItemDelete = new UnityEvent<ZoneSettingsHandle>();

		[SerializeField]
		private ReorderableItem reorderer;

		[SerializeField]
		private GameObject orderButtonsHolder;

		[SerializeField]
		private GameObject deleteButton;

		[SerializeField]
		private List<GameObject> spawnRelated;

		[SerializeField]
		private List<GameObject> targetRelated;

		[SerializeField]
		private Transform movementLeftRow;

		[SerializeField]
		private Transform movementRightRow;

		[SerializeField]
		private Button openButton;

		[SerializeField]
		private Button closeButton;

		[SerializeField]
		private TextLineReference zoneNameRef;

		[SerializeField]
		private SettingDropdownReference materialDropdownRef;

		[SerializeField]
		private SettingDropdownReference distributionDropdownRef;

		[SerializeField]
		private SettingSliderReference fertilitySliderRef;

		[SerializeField]
		private SettingSliderReference biomassSliderRef;

		[SerializeField]
		private SettingSliderReference sizeSliderRef;

		[SerializeField]
		private SettingToggleReference renewToggleRef;

		[SerializeField]
		private SettingDropdownReference movementDropdownRef;

		[SerializeField]
		private SettingDropdownReference targetDropdownRef;

		[SerializeField]
		private SettingSliderReference speedSliderRef;

		[SerializeField]
		private SettingSliderReference posXSliderRef;

		[SerializeField]
		private SettingSliderReference posYSliderRef;

		[SerializeField]
		private SettingSliderReference radiusSliderRef;

		[SerializeField]
		private SettingSliderReference radiusAbsoluteSliderRef;

		[SerializeField]
		private SettingSliderReference widthSliderRef;

		[SerializeField]
		private SettingSliderReference widthAbsoluteSliderRef;

		[SerializeField]
		private SettingSliderReference heightSliderRef;

		[SerializeField]
		private SettingSliderReference heightAbsoluteSliderRef;

		[SerializeField]
		private SettingSliderReference insideRadiusSliderRef;

		[SerializeField]
		private SettingToggleReference radiusTypeToggleRef;

		private TextLineHandle zoneNameEdit = new TextLineHandle();

		private MatterMaterialDropdown spawnPelletDropdown = new MatterMaterialDropdown();

		private ChoiceSettingDropdown<ChoiceSetting<SpawnDistribution>, SpawnDistribution> distributionDropdown = new ChoiceSettingDropdown<ChoiceSetting<SpawnDistribution>, SpawnDistribution>();

		private LogFloatSettingSlider fertilitySlider = new LogFloatSettingSlider(10f);

		private LogFloatSettingSlider biomassSlider = new LogFloatSettingSlider(10f);

		private LogFloatSettingSlider sizeSlider = new LogFloatSettingSlider(10f);

		private SettingToggle renewToggle = new SettingToggle();

		private ChoiceSettingDropdown<ChoiceSetting<MovementType>, MovementType> movementDropdown = new ChoiceSettingDropdown<ChoiceSetting<MovementType>, MovementType>();

		private TargetZoneDropdown targetDropdown = new TargetZoneDropdown();

		private LogFloatSettingSlider speedSlider = new LogFloatSettingSlider(10f);

		private FloatSettingSlider posXSlider = new FloatSettingSlider();

		private FloatSettingSlider posYSlider = new FloatSettingSlider();

		private LogFloatSettingSlider radiusSlider = new LogFloatSettingSlider(10f, wholeNumbers: false, simple: false, 3f);

		private LogFloatSettingSlider radiusAbsoluteSlider = new LogFloatSettingSlider(10f, wholeNumbers: false, simple: false, 3f);

		private FloatSettingSlider insideRadiusSlider = new FloatSettingSlider();

		private LogFloatSettingSlider widthSlider = new LogFloatSettingSlider(10f, wholeNumbers: false, simple: false, 2f);

		private LogFloatSettingSlider widthAbsoluteSlider = new LogFloatSettingSlider(10f, wholeNumbers: false, simple: false, 2f);

		private LogFloatSettingSlider heightSlider = new LogFloatSettingSlider(10f, wholeNumbers: false, simple: false, 2f);

		private LogFloatSettingSlider heightAbsoluteSlider = new LogFloatSettingSlider(10f, wholeNumbers: false, simple: false, 2f);

		private SettingToggle radiusTypeToggle = new SettingToggle();

		private List<ISettingHandle> settingsHandles;

		[SerializeField]
		private GameObject editSection;

		public override void Initialize()
		{
			base.Initialize();
			zoneNameEdit.LinkToRef(zoneNameRef);
			spawnPelletDropdown.LinkToRef(materialDropdownRef);
			distributionDropdown.LinkToRef(distributionDropdownRef);
			fertilitySlider.LinkToRef(fertilitySliderRef);
			biomassSlider.LinkToRef(biomassSliderRef);
			sizeSlider.LinkToRef(sizeSliderRef);
			renewToggle.LinkToRef(renewToggleRef);
			movementDropdown.LinkToRef(movementDropdownRef);
			speedSlider.LinkToRef(speedSliderRef);
			targetDropdown.LinkToRef(targetDropdownRef);
			posXSlider.LinkToRef(posXSliderRef);
			posYSlider.LinkToRef(posYSliderRef);
			radiusSlider.LinkToRef(radiusSliderRef);
			radiusAbsoluteSlider.LinkToRef(radiusAbsoluteSliderRef);
			widthSlider.LinkToRef(widthSliderRef);
			widthAbsoluteSlider.LinkToRef(widthAbsoluteSliderRef);
			heightSlider.LinkToRef(heightSliderRef);
			heightAbsoluteSlider.LinkToRef(heightAbsoluteSliderRef);
			insideRadiusSlider.LinkToRef(insideRadiusSliderRef);
			radiusTypeToggle.LinkToRef(radiusTypeToggleRef);
			if (openButton != null)
			{
				openButton.onClick.AddListener(SelectItem);
			}
			if (closeButton != null)
			{
				closeButton.onClick.AddListener(CloseEditSection);
			}
			settingsHandles = new List<ISettingHandle>
			{
				spawnPelletDropdown, distributionDropdown, fertilitySlider, biomassSlider, sizeSlider, renewToggle, movementDropdown, speedSlider, targetDropdown, radiusSlider,
				radiusAbsoluteSlider, radiusTypeToggle, insideRadiusSlider, widthSlider, widthAbsoluteSlider, heightSlider, heightAbsoluteSlider
			};
		}

		public override void WakeUp()
		{
			base.WakeUp();
			CloseEditSection();
		}

		public override void Retire()
		{
			base.Retire();
			settings.zoneName?.UnSubscribe(ChangeName);
			settings.movement.UnSubscribe(ChangeMovementType);
			settings.distribution.UnSubscribe(ChangeZoneShape);
			settings.onSizeChange.RemoveListener(OnChangeSize);
			settings.sizeScalesWithSim.UnSubscribe(OnChangeSizeType);
			settingsHandles.ForEach(delegate(ISettingHandle h)
			{
				h.ReleaseDependencies();
			});
			settings.onSizeChange.RemoveListener(OnChangeSize);
			if (settings.zoneName != null)
			{
				settingsHandles.Remove(zoneNameEdit);
			}
			if (settings.posX != null)
			{
				settingsHandles.Remove(posXSlider);
			}
			if (settings.posY != null)
			{
				settingsHandles.Remove(posYSlider);
			}
			ScenarioIndependentSettings.Instance.SimulationSize.UnSubscribe(OnChangeSimSize);
			settings = null;
		}

		public override void AssignKey(ZoneSettings zoneSettings)
		{
			AssignSetting(zoneSettings);
		}

		public void AssignSetting(ZoneSettings zoneSettings)
		{
			settings = zoneSettings;
			if (settings.zoneName != null)
			{
				settingsHandles.Add(zoneNameEdit);
			}
			if (settings.zoneName != null)
			{
				zoneNameEdit.setting = settings.zoneName;
			}
			spawnPelletDropdown.setting = settings.spawnMaterial;
			distributionDropdown.setting = settings.distribution;
			fertilitySlider.setting = settings.fertility;
			biomassSlider.setting = settings.biomassDensity;
			sizeSlider.setting = settings.pelletSize;
			renewToggle.setting = settings.renewBiomass;
			movementDropdown.setting = settings.movement;
			speedSlider.setting = settings.speed;
			targetDropdown.setting = settings.target;
			if (settings.posX != null)
			{
				settingsHandles.Add(posXSlider);
			}
			if (settings.posY != null)
			{
				settingsHandles.Add(posYSlider);
			}
			if (settings.posX != null)
			{
				posXSlider.setting = settings.posX;
			}
			if (settings.posY != null)
			{
				posYSlider.setting = settings.posY;
			}
			radiusSlider.setting = settings.radiusRelative;
			radiusAbsoluteSlider.setting = settings.radiusAbsolute;
			widthSlider.setting = settings.widthRelative;
			widthAbsoluteSlider.setting = settings.widthAbsolute;
			heightSlider.setting = settings.heightRelative;
			heightAbsoluteSlider.setting = settings.heightAbsolute;
			insideRadiusSlider.setting = settings.insideRadius;
			radiusTypeToggle.setting = settings.sizeScalesWithSim;
			settingsHandles.ForEach(delegate(ISettingHandle h)
			{
				h.InitUIElement();
			});
			settings.zoneName?.Subscribe(ChangeName);
			settings.spawnMaterial.Subscribe(ChangePelletType);
			settings.movement.Subscribe(ChangeMovementType);
			settings.distribution.Subscribe(ChangeZoneShape);
			settings.onSizeChange.AddListener(OnChangeSize);
			settings.sizeScalesWithSim.Subscribe(OnChangeSizeType);
			ScenarioIndependentSettings.Instance.SimulationSize.Subscribe(OnChangeSimSize);
			ChangeZoneShape(settings.distribution.val);
			ChangeMovementType(settings.movement.val);
			OnChangeSimSize(ScenarioIndependentSettings.Instance.SimulationSize.val);
		}

		public void ChangeName(string newName)
		{
			ScenarioSettings.zoneNameChanged.Invoke(settings.zoneID, newName);
		}

		public void ChangePelletType()
		{
			bool willSpawn = settings.spawnMaterial.val != null;
			spawnRelated.ForEach(delegate(GameObject g)
			{
				g.SetActive(willSpawn);
			});
		}

		public void ChangeZoneShape(SpawnDistribution shape)
		{
			ShowCorrectSizeSliders(settings.sizeScalesWithSim.val);
		}

		public void ChangeMovementType(MovementType movementType)
		{
			bool active = movementType == MovementType.Free;
			bool canHaveTarget = movementType == MovementType.Orbit || movementType == MovementType.Attached;
			if (!canHaveTarget)
			{
				settings.target.SetValue(null);
			}
			speedSliderRef.transform.SetParent(canHaveTarget ? movementLeftRow : movementRightRow);
			speedSliderRef.gameObject.SetActive(active);
			targetRelated.ForEach(delegate(GameObject g)
			{
				g.SetActive(canHaveTarget);
			});
		}

		public void OnChangeSizeType(bool val)
		{
			ShowCorrectSizeSliders(val);
			if (!val)
			{
				LogFloatSettingSlider logFloatSettingSlider = radiusAbsoluteSlider;
				float? max = ScenarioIndependentSettings.Instance.SimulationSize.val;
				logFloatSettingSlider.SetMinMax(null, max);
				LogFloatSettingSlider logFloatSettingSlider2 = widthAbsoluteSlider;
				max = ScenarioIndependentSettings.Instance.SimulationSize.val * 2f;
				logFloatSettingSlider2.SetMinMax(null, max);
				LogFloatSettingSlider logFloatSettingSlider3 = heightAbsoluteSlider;
				max = ScenarioIndependentSettings.Instance.SimulationSize.val * 2f;
				logFloatSettingSlider3.SetMinMax(null, max);
			}
		}

		public void ShowCorrectSizeSliders(bool isRelative)
		{
			if (!settings.isRect)
			{
				IForceUpdateSetting forceUpdateSetting;
				if (!isRelative)
				{
					IForceUpdateSetting radiusAbsolute = settings.radiusAbsolute;
					forceUpdateSetting = radiusAbsolute;
				}
				else
				{
					IForceUpdateSetting radiusAbsolute = settings.radiusRelative;
					forceUpdateSetting = radiusAbsolute;
				}
				forceUpdateSetting.ForceUpdate();
				radiusSliderRef.gameObject.SetActive(isRelative);
				radiusAbsoluteSliderRef.gameObject.SetActive(!isRelative);
				insideRadiusSliderRef.gameObject.SetActive(settings.isRing);
				widthSliderRef.gameObject.SetActive(value: false);
				heightSliderRef.gameObject.SetActive(value: false);
				widthAbsoluteSliderRef.gameObject.SetActive(value: false);
				heightAbsoluteSliderRef.gameObject.SetActive(value: false);
				return;
			}
			IForceUpdateSetting forceUpdateSetting2;
			if (!isRelative)
			{
				IForceUpdateSetting radiusAbsolute = settings.widthAbsolute;
				forceUpdateSetting2 = radiusAbsolute;
			}
			else
			{
				IForceUpdateSetting radiusAbsolute = settings.widthRelative;
				forceUpdateSetting2 = radiusAbsolute;
			}
			forceUpdateSetting2.ForceUpdate();
			IForceUpdateSetting forceUpdateSetting3;
			if (!isRelative)
			{
				IForceUpdateSetting radiusAbsolute = settings.heightAbsolute;
				forceUpdateSetting3 = radiusAbsolute;
			}
			else
			{
				IForceUpdateSetting radiusAbsolute = settings.heightRelative;
				forceUpdateSetting3 = radiusAbsolute;
			}
			forceUpdateSetting3.ForceUpdate();
			widthSliderRef.gameObject.SetActive(isRelative);
			heightSliderRef.gameObject.SetActive(isRelative);
			widthAbsoluteSliderRef.gameObject.SetActive(!isRelative);
			heightAbsoluteSliderRef.gameObject.SetActive(!isRelative);
			radiusSliderRef.gameObject.SetActive(value: false);
			radiusAbsoluteSliderRef.gameObject.SetActive(value: false);
			insideRadiusSliderRef.gameObject.SetActive(value: false);
		}

		public void OnChangeSimSize(float value)
		{
			if (settings != null && !settings.sizeScalesWithSim.val)
			{
				LogFloatSettingSlider logFloatSettingSlider = radiusAbsoluteSlider;
				float? max = ScenarioIndependentSettings.Instance.SimulationSize.val;
				logFloatSettingSlider.SetMinMax(null, max, forceInBounds: true);
				LogFloatSettingSlider logFloatSettingSlider2 = widthAbsoluteSlider;
				max = ScenarioIndependentSettings.Instance.SimulationSize.val * 2f;
				logFloatSettingSlider2.SetMinMax(null, max, forceInBounds: true);
				LogFloatSettingSlider logFloatSettingSlider3 = heightAbsoluteSlider;
				max = ScenarioIndependentSettings.Instance.SimulationSize.val * 2f;
				logFloatSettingSlider3.SetMinMax(null, max, forceInBounds: true);
				OnChangeSize();
			}
		}

		public void OnChangeSize()
		{
			float num;
			float num2;
			if (settings.isRect)
			{
				num = Mathf.Clamp01(1f - settings.relativeWidth / 2f);
				num2 = Mathf.Clamp01(1f - settings.relativeHeight / 2f);
			}
			else
			{
				num = (num2 = Mathf.Clamp01(1f - settings.relativeRadius));
			}
			if (settings.posX != null)
			{
				posXSlider.SetMinMax(0f - num, num);
			}
			if (settings.posY != null)
			{
				posYSlider.SetMinMax(0f - num2, num2);
			}
		}

		public void DeleteZone()
		{
			PopupManager.DisplayChoiceDialog("Delete Zone", "Are you sure you want to delete " + settings.zoneName.val + "?\nYou will lose all data", "Cancel", "YES", null, ActuallyDeleteZone);
		}

		private void ActuallyDeleteZone()
		{
			onItemDelete.Invoke(this);
		}

		public void SelectItem()
		{
			orderButtonsHolder.SetActive(value: true);
			reorderer.UpdateButtons();
			editSection.SetActive(value: true);
			deleteButton.SetActive(value: true);
			openButton.gameObject.SetActive(value: false);
			closeButton.gameObject.SetActive(value: true);
		}

		public void CloseEditSection()
		{
			orderButtonsHolder.SetActive(value: false);
			openButton.gameObject.SetActive(value: true);
			closeButton.gameObject.SetActive(value: false);
			deleteButton.SetActive(value: false);
			editSection.SetActive(value: false);
		}

		public void OnPointerClick(PointerEventData eventData)
		{
			if (!editSection.activeSelf)
			{
				onItemClicked.Invoke(this);
			}
		}

		private void OnDestroy()
		{
			ScenarioIndependentSettings.Instance.SimulationSize.OnValueChange.RemoveListener(OnChangeSimSize);
		}
	}
}
