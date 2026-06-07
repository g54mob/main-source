using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Craft.Parts;
using Assets.Scripts.Craft.Parts.Modifiers;
using Assets.Scripts.Craft.Parts.Modifiers.Car;
using Assets.Scripts.Craft.Parts.Modifiers.CarverParts;
using Assets.Scripts.Craft.Parts.Modifiers.Character;
using Assets.Scripts.Craft.Parts.Modifiers.Mfd;
using Assets.Scripts.Craft.Parts.Modifiers.Powertrain;
using Assets.Scripts.Craft.Parts.Modifiers.Propulsion.Jet;
using Assets.Scripts.Craft.Parts.Modifiers.Propulsion.Propeller;
using Assets.Scripts.Craft.Parts.Modifiers.Weapons;
using Assets.Scripts.Craft.Parts.Modifiers.XR;
using Assets.Scripts.UI;
using Jundroo.Common.Math;
using Jundroo.Juicy.Widgets;
using UnityEngine;

namespace Assets.Scripts.Design.UI.PartProperties
{
	public class PartPropertiesPanelScript : DesignerPanelScript
	{
		private Widget _commonPartProperties;

		private PartScript _designerSelectedPart;

		private TextWidget _partMassText;

		private InputWidget _partNameInput;

		private List<GenericPartPropertiesScript> _partProperties;

		private bool _structureChanged;

		public static GenericPartPropertiesScript GetPropertiesByType(Type partModifierType)
		{
			IDesignerFlyouts designerFlyouts = Designer.Instance?.DesignerScript?.DesignerUI?.Flyouts;
			if (designerFlyouts == null)
			{
				Debug.LogError("Unable to find the designer UI flyouts script when attempting to get generic part properties script for type '" + partModifierType.FullName + "'");
				return null;
			}
			PartPropertiesPanelScript componentInChildren = designerFlyouts.PartProperties.Widget.GetComponentInChildren<PartPropertiesPanelScript>(includeInactive: true);
			if (componentInChildren == null)
			{
				Debug.LogError("Unable to find the part properties panel script when attempting to get generic part properties script for type '" + partModifierType.FullName + "'");
				return null;
			}
			foreach (GenericPartPropertiesScript partProperty in componentInChildren._partProperties)
			{
				if (partProperty.ModifierType == partModifierType)
				{
					return partProperty;
				}
			}
			return null;
		}

		public static GenericPartPropertiesScript GetPropertiesByType<T>() where T : PartModifierData
		{
			return GetPropertiesByType(typeof(T));
		}

		public override void InitializeDesignerPanel(DesignerUIScript designerUI)
		{
			base.InitializeDesignerPanel(designerUI);
			base.Flyout.Closed += OnFlyoutClosed;
			base.Flyout.Opened += OnFlyoutOpened;
			base.Designer.CraftLoaded += OnCraftLoaded;
			_partProperties = new List<GenericPartPropertiesScript>();
			AddGenericPartPropertyScript(typeof(ControlSurfacePartData));
			AddGenericPartPropertyScript(typeof(HeliMainRotorData));
			AddGenericPartPropertyScript(typeof(HeliTailRotorData));
			AddGenericPartPropertyScript(typeof(BombData));
			AddGenericPartPropertyScript(typeof(MissileData));
			AddGenericPartPropertyScript(typeof(GunData));
			AddGenericPartPropertyScript(typeof(RocketPodData));
			AddGenericPartPropertyScript(typeof(RocketWeaponData));
			AddGenericPartPropertyScript(typeof(CannonData));
			AddGenericPartPropertyScript(typeof(CounterMeasureDispenserData));
			AddGenericPartPropertyScript(typeof(PistonData));
			AddGenericPartPropertyScript(typeof(ReactionControlNozzleData));
			AddGenericPartPropertyScript(typeof(ResizableWheelData));
			AddGenericPartPropertyScript(typeof(JWheelData));
			AddGenericPartPropertyScript(typeof(JWheelSuspensionData));
			AddGenericPartPropertyScript(typeof(JEngineData));
			AddGenericPartPropertyScript(typeof(JDriveShaftData));
			AddGenericPartPropertyScript(typeof(JDriveHubData));
			AddGenericPartPropertyScript(typeof(JGearboxData));
			AddGenericPartPropertyScript(typeof(JDifferentialData));
			AddGenericPartPropertyScript(typeof(JTransmissionData));
			AddGenericPartPropertyScript(typeof(PropEngineAdvancedData));
			AddGenericPartPropertyScript(typeof(GyroscopeData));
			AddGenericPartPropertyScript(typeof(ResizableShapeData));
			AddGenericPartPropertyScript(typeof(ArrestingHookData));
			AddGenericPartPropertyScript(typeof(CatapultConnectorData));
			AddGenericPartPropertyScript(typeof(SuspensionData));
			AddGenericPartPropertyScript(typeof(CarEngineData));
			AddGenericPartPropertyScript(typeof(BeaconLightData));
			AddGenericPartPropertyScript(typeof(ParachuteData));
			AddGenericPartPropertyScript(typeof(RetractableLandingGearData));
			AddGenericPartPropertyScript(typeof(WheelData));
			AddGenericPartPropertyScript(typeof(WinchData));
			AddGenericPartPropertyScript(typeof(MagnetData));
			AddGenericPartPropertyScript(typeof(WingLandingGearData));
			AddGenericPartPropertyScript(typeof(DetacherData));
			AddGenericPartPropertyScript(typeof(GaugeData));
			AddGenericPartPropertyScript(typeof(AttitudeBallData));
			AddGenericPartPropertyScript(typeof(CockpitButtonData));
			AddGenericPartPropertyScript(typeof(CockpitSwitchData));
			AddGenericPartPropertyScript(typeof(CanopyData));
			AddGenericPartPropertyScript(typeof(PosedGripData));
			AddGenericPartPropertyScript(typeof(ControlBaseData));
			AddGenericPartPropertyScript(typeof(RefuelDrogueData));
			AddGenericPartPropertyScript(typeof(AdjustableJoystickData));
			AddGenericPartPropertyScript(typeof(AdaptiveNoseConeData));
			AddGenericPartPropertyScript(typeof(JointRotatorData));
			AddGenericPartPropertyScript(typeof(CockpitData));
			AddGenericPartPropertyScript(typeof(WingData));
			AddGenericPartPropertyScript(typeof(FuselageData));
			AddGenericPartPropertyScript(typeof(TransparencyData));
			AddGenericPartPropertyScript(typeof(TargetingPodData));
			AddGenericPartPropertyScript(typeof(JetEngineData));
			AddGenericPartPropertyScript(typeof(JetEngineShroudData));
			AddGenericPartPropertyScript(typeof(JWingData));
			AddGenericPartPropertyScript(typeof(SeatData));
			AddGenericPartPropertyScript(typeof(TextureDecalData));
			AddGenericPartPropertyScript(typeof(TextDecalData));
			AddGenericPartPropertyScript(typeof(IKSeatData));
			AddGenericPartPropertyScript(typeof(IKTargetData));
			AddGenericPartPropertyScript(typeof(ProceduralMissileData));
			AddGenericPartPropertyScript(typeof(ProceduralMissileSubPartData));
			AddGenericPartPropertyScript(typeof(PropellerAssemblyData));
			AddGenericPartPropertyScript(typeof(LabelData));
			AddGenericPartPropertyScript(typeof(CameraVantageData));
			AddGenericPartPropertyScript(typeof(InputControllerData));
			AddGenericPartPropertyScript(typeof(JFuselageData));
			AddGenericPartPropertyScript(typeof(CockpitSoundData));
			AddGenericPartPropertyScript(typeof(MfdData));
			AddGenericPartPropertyScript(typeof(PedalData));
			AddGenericPartPropertyScript(typeof(ProceduralBayData));
			AddGenericPartPropertyScript(typeof(ProceduralWindowData));
			AddGenericPartPropertyScript(typeof(PartTargetingData));
			AddGenericPartPropertyScript(typeof(ResizableFuelTankData));
			foreach (Type distinctModModifierType in Game.Instance.PartTypes.GetDistinctModModifierTypes())
			{
				if (GenericPartPropertiesScript.NeedsPartPropertiesScript(distinctModModifierType))
				{
					AddGenericPartPropertyScript(distinctModModifierType);
				}
			}
			_partProperties = (from x in _partProperties
				orderby x.PanelOrder, x.transform.GetSiblingIndex()
				select x).ToList();
			for (int num = 0; num < _partProperties.Count; num++)
			{
				_partProperties[num].Designer = base.Designer.DesignerScript;
				_partProperties[num].Widget.SetIndex(num);
			}
			_commonPartProperties = base.Widget.FindWidget("common-part-properties");
			_commonPartProperties.SetIndex(0);
			_partNameInput = base.Widget.FindWidget<InputWidget>("part-name");
			_partNameInput.Input.onEndEdit.AddListener(delegate(string s)
			{
				OnPartNameInputChanged(s);
				base.Designer.CreateUndoStepForSelectedPart("Name");
			});
			_partMassText = base.Widget.FindWidget<TextWidget>("part-mass");
			SetSelectedPart(null);
			base.Designer.AircraftStructureChangedEvent += OnAircraftStructureChanged;
		}

		protected virtual void Update()
		{
			if ((object)base.Designer.SelectedPart != _designerSelectedPart)
			{
				SetSelectedPart(base.Designer.SelectedPart);
			}
			if (_structureChanged)
			{
				_structureChanged = false;
				if (_designerSelectedPart != null)
				{
					UpdateCommonPartProperties();
				}
			}
		}

		private GenericPartPropertiesScript AddGenericPartPropertyScript(Type modifierType)
		{
			Widget parent = base.Widget.FindWidget("items-parent");
			Widget widget = base.Widget.Context.CreateWidgetFromTemplate("generic-part-properties", parent);
			GenericPartPropertiesScript genericPartPropertiesScript = GenericPartPropertiesScript.AddComponent(widget.gameObject, modifierType);
			genericPartPropertiesScript.name = "PartProperties_" + modifierType.Name;
			genericPartPropertiesScript.Initialize(widget);
			genericPartPropertiesScript.gameObject.SetActive(value: false);
			_partProperties.Add(genericPartPropertiesScript);
			return genericPartPropertiesScript;
		}

		private void OnAircraftStructureChanged()
		{
			_structureChanged = true;
		}

		private void OnCraftLoaded()
		{
			SetSelectedPart(null);
		}

		private void OnFlyoutClosed(IFlyout flyout)
		{
			foreach (GenericPartPropertiesScript partProperty in _partProperties)
			{
				partProperty.OnPropertiesClosed();
			}
		}

		private void OnFlyoutOpened(IFlyout flyout)
		{
			foreach (GenericPartPropertiesScript partProperty in _partProperties)
			{
				partProperty.OnPropertiesOpened();
			}
			Update();
		}

		private void OnPartNameInputChanged(string name)
		{
			if (!(_designerSelectedPart != null))
			{
				return;
			}
			_designerSelectedPart.Part.Name = name;
			foreach (PartModifierData modifier in _designerSelectedPart.Part.Modifiers)
			{
				modifier.OnPartNameChanged(name);
			}
		}

		private void SetSelectedPart(PartScript selectedPart)
		{
			if (_designerSelectedPart != null)
			{
				foreach (GenericPartPropertiesScript partProperty in _partProperties)
				{
					try
					{
						partProperty.OnPartDeselected(_designerSelectedPart);
					}
					catch (Exception exception)
					{
						Debug.LogException(exception, partProperty);
					}
				}
			}
			_designerSelectedPart = selectedPart;
			if (_designerSelectedPart != null)
			{
				_commonPartProperties.SetVisible(visible: true);
				List<GenericPartPropertiesScript> list = new List<GenericPartPropertiesScript>();
				foreach (PartModifierScript modifier in _designerSelectedPart.Modifiers)
				{
					if (!modifier.PartModifier.IsGenericDesignerPropertiesVisible)
					{
						continue;
					}
					bool flag = false;
					foreach (GenericPartPropertiesScript partProperty2 in _partProperties)
					{
						if (!list.Contains(partProperty2) && partProperty2.OnPartSelected(_designerSelectedPart, modifier))
						{
							list.Add(partProperty2);
							flag = true;
							break;
						}
					}
					if (!flag)
					{
						Type type = modifier.PartModifier.GetType();
						if (GenericPartPropertiesScript.AlreadyHasPartPropertiesScripts(type))
						{
							GenericPartPropertiesScript genericPartPropertiesScript = AddGenericPartPropertyScript(type);
							genericPartPropertiesScript.Designer = base.Designer.DesignerScript;
							list.Add(genericPartPropertiesScript);
							_partProperties.Add(genericPartPropertiesScript);
							genericPartPropertiesScript.OnPartSelected(_designerSelectedPart, modifier);
							genericPartPropertiesScript.RefreshUI();
						}
					}
				}
				GenericPartPropertiesScript genericPartPropertiesScript2 = null;
				foreach (GenericPartPropertiesScript partProperty3 in _partProperties)
				{
					bool flag2 = list.Contains(partProperty3);
					partProperty3.gameObject.SetActive(flag2);
					if (flag2)
					{
						if (genericPartPropertiesScript2 == null)
						{
							partProperty3.MarkAsFirst(first: true);
							genericPartPropertiesScript2 = partProperty3;
						}
						else
						{
							partProperty3.MarkAsFirst(first: false);
						}
					}
				}
				UpdateCommonPartProperties();
				return;
			}
			_commonPartProperties.SetVisible(visible: false);
			foreach (GenericPartPropertiesScript partProperty4 in _partProperties)
			{
				partProperty4.gameObject.SetActive(value: false);
			}
		}

		private void UpdateCommonPartProperties()
		{
			_partNameInput.Text = _designerSelectedPart.Part.Name;
			_partMassText.Text = (_designerSelectedPart.Part.LoadedMass / 0.01f).Format(UnitType.Mass);
		}
	}
}
