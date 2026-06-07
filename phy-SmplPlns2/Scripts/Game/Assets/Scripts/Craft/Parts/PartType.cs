using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
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
using Assets.Scripts.Mods;
using Jundroo.Common.Pool;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts
{
	public class PartType
	{
		private XElement _attachPointsElement;

		private XElement _modifiersElement;

		private Dictionary<string, Type> _modModifiers;

		public bool CanExplode => ExplodeForce > 0f;

		public Vector3 CenterOfMass { get; private set; }

		public bool CollideConnected { get; private set; }

		public bool CombineMeshes { get; set; }

		public float ConstantDrag { get; private set; }

		public float CullScale { get; }

		public bool DamageDisconnect { get; private set; }

		public List<int> DefaultMaterialIds { get; private set; }

		public float DisconnectForce { get; set; }

		public PartDragType DragType { get; }

		public bool DynamicMaterialIds { get; set; }

		public float ExplodeForce { get; set; }

		public bool HasAttachPointAtPartOrigin { get; }

		public float Health { get; private set; }

		public bool IgnoreSharesRigidBody { get; }

		public float Mass { get; set; }

		public Vector3 MirrorRotationOffset { get; set; }

		public LoadedMod Mod { get; set; }

		public List<Type> ModModifierTypes => _modModifiers.Values.ToList();

		public string ModPrefabPath { get; set; }

		public string Name { get; set; }

		public string PartTypeId { get; set; }

		public float PerformanceCost { get; set; }

		public string PrefabId { get; set; }

		public IReadOnlyList<string> RedirectedPartTypes { get; }

		public CraftLoadContext? RequiredLoadContext { get; }

		public bool RequiresPrimaryPartCollider { get; private set; }

		public bool SharesRigidBody { get; set; }

		public float UnderwaterDragScalar { get; set; }

		public PartType(XElement element)
			: this(element, null)
		{
		}

		public PartType(XElement element, LoadedMod mod)
		{
			Mod = mod;
			_attachPointsElement = element.Element("AttachPoints");
			_modifiersElement = element.Element("Modifiers");
			PartTypeId = element.Attribute("id").Value;
			Name = element.Attribute("name").Value;
			PrefabId = (string)element.Attribute("prefabId");
			ModPrefabPath = (string)element.Attribute("modPrefabPath");
			Mass = float.Parse(element.Attribute("mass").Value) * 0.01f;
			DragType = element.GetEnumAttributeOrNull<PartDragType>("dragType") ?? PartDragType.Standard;
			SharesRigidBody = bool.Parse(element.Attribute("sharesRigidBody").Value);
			IgnoreSharesRigidBody = (bool?)element.Attribute("ignoreSharesRigidBody") == true;
			MirrorRotationOffset = element.GetVector3Attribute("mirrorRotationOffset", Vector3.zero);
			CombineMeshes = element.GetBoolAttribute("combineMeshes", defaultValue: true);
			UnderwaterDragScalar = element.GetFloatAttribute("underwaterDragScalar", 30f);
			DisconnectForce = element.GetFloatAttribute("disconnectForce", 12.5f);
			ExplodeForce = element.GetFloatAttribute("explodeForce", 15f);
			Health = element.GetFloatAttribute("health", 100f);
			DamageDisconnect = element.GetBoolAttribute("damageDisconnect", defaultValue: true);
			CenterOfMass = element.GetVector3Attribute("centerOfMass", Vector3.zero);
			CollideConnected = element.GetBoolAttribute("collideConnected");
			RedirectedPartTypes = element.GetStringListAttribute("redirectedPartTypes");
			PerformanceCost = element.GetFloatAttribute("performanceCost");
			RequiredLoadContext = element.GetEnumAttributeOrNull<CraftLoadContext>("loadContext");
			CullScale = element.GetFloatAttribute("cullScale", 1f);
			RequiresPrimaryPartCollider = element.GetBoolAttribute("requiresPrimaryPartCollider", defaultValue: true);
			float constantDrag = -1f;
			if (element.Attribute("constantDrag") != null)
			{
				constantDrag = float.Parse(element.Attribute("constantDrag").Value);
			}
			DynamicMaterialIds = element.GetBoolAttribute("dynamicMaterialCount");
			DefaultMaterialIds = new List<int>();
			DefaultMaterialIds.AddRange(element.GetIntListAttribute("defaultMaterials"));
			if (DefaultMaterialIds.Count == 0)
			{
				DefaultMaterialIds.Add(0);
			}
			ConstantDrag = constantDrag;
			foreach (XElement item in _attachPointsElement.Elements("AttachPoint"))
			{
				Vector3? vector3AttributeOrNull = item.GetVector3AttributeOrNull("position");
				if (vector3AttributeOrNull.HasValue && vector3AttributeOrNull.Value == Vector3.zero)
				{
					HasAttachPointAtPartOrigin = true;
					break;
				}
			}
			_modModifiers = new Dictionary<string, Type>();
			if (mod == null || _modifiersElement == null)
			{
				return;
			}
			foreach (XElement item2 in _modifiersElement.Elements())
			{
				if (item2.Name.LocalName == "ModModifier")
				{
					string text = (string)item2.Attribute("id");
					string text2 = (string)item2.Attribute("type");
					Type type = Type.GetType(text2, throwOnError: false);
					if (type != null)
					{
						_modModifiers.Add(text, type);
						continue;
					}
					Debug.LogErrorFormat("Modifier '{0}' defined in mod '{1}' could not be loaded because the modifier type '{2}' could not be found.", text, mod.ModInfo.Name, text2);
				}
			}
		}

		public List<AttachPointData> CreateAttachPoints()
		{
			List<AttachPointData> list = new List<AttachPointData>();
			if (_attachPointsElement != null)
			{
				IEnumerable<XElement> source = _attachPointsElement.Elements("AttachPoint");
				for (int i = 0; i < source.Count(); i++)
				{
					XElement element = source.ElementAt(i);
					AttachPointData item = new AttachPointData(i, element);
					list.Add(item);
				}
			}
			return list;
		}

		public void CreateModifiers(PartData part, XElement partElement, int aircraftXmlVersion, List<PartModifierData> modifiers)
		{
			Dictionary<string, int> value;
			using (CollectionPool<Dictionary<string, int>, KeyValuePair<string, int>>.Get(out value))
			{
				if (_modifiersElement != null)
				{
					foreach (XElement item in _modifiersElement.Elements())
					{
						PartModifierData partModifierData = null;
						switch (item.Name.ToString())
						{
						case "Wing":
							partModifierData = new WingData(item);
							break;
						case "CarEngine":
							partModifierData = new CarEngineData(item);
							break;
						case "Engine":
							partModifierData = new EngineData(item);
							break;
						case "Inlet":
							partModifierData = new InletData(item);
							break;
						case "BeaconLight":
							partModifierData = new BeaconLightData(item);
							break;
						case "AdaptiveBlock":
							partModifierData = new AdaptiveBlockData(item);
							break;
						case "AdaptiveNoseCone":
							partModifierData = new AdaptiveNoseConeData(item);
							break;
						case "Fuselage":
							partModifierData = new FuselageData(item);
							break;
						case "FuelTank":
							partModifierData = new FuelTankData(item);
							break;
						case "Wheel":
							partModifierData = new WheelData(item);
							break;
						case "ResizableWheel":
							partModifierData = new ResizableWheelData(item);
							break;
						case "RetractableLandingGear":
							partModifierData = new RetractableLandingGearData(item);
							break;
						case "WingLandingGear":
							partModifierData = new WingLandingGearData(item);
							break;
						case "Rotator":
							partModifierData = new RotatorData(item);
							break;
						case "EngineThrustPort":
							partModifierData = new EngineThrustPortData(item);
							break;
						case "ReactionControlNozzle":
							partModifierData = new ReactionControlNozzleData(item);
							break;
						case "Detacher":
							partModifierData = new DetacherData(item);
							break;
						case "JointMotor":
							partModifierData = new JointMotorData(item);
							break;
						case "JointRotator":
							partModifierData = new JointRotatorData(item);
							break;
						case "InputController":
							partModifierData = new InputControllerData(item);
							break;
						case "AirBrake":
							partModifierData = new AirBrakeData(item);
							break;
						case "FloatingPart":
							partModifierData = new FloatingPartData(item);
							break;
						case "ModModifier":
							TodoException<PartType>.ThrowOnce("Mod part modifiers are not currently supported");
							break;
						case "PropEngineAdvanced":
							partModifierData = new PropEngineAdvancedData(item);
							break;
						case "HeliMainRotor":
							partModifierData = new HeliMainRotorData(item);
							break;
						case "RotorPerfScalars":
							partModifierData = new RotorPerfScalarsData(item);
							break;
						case "HeliTailRotor":
							partModifierData = new HeliTailRotorData(item);
							break;
						case "Piston":
							partModifierData = new PistonData(item);
							break;
						case "Suspension":
							partModifierData = new SuspensionData(item);
							break;
						case "CowlFlaps":
							partModifierData = new CowlFlapsData(item);
							break;
						case "EngineNozzleFlaps":
							partModifierData = new EngineNozzleFlapsData(item);
							break;
						case "CameraVantage":
							partModifierData = new CameraVantageData(item);
							break;
						case "Cockpit":
							partModifierData = new CockpitData(item);
							break;
						case "Gun":
							partModifierData = new GunData(item);
							break;
						case "Bomb":
							partModifierData = new BombData(item);
							break;
						case "Missile":
							partModifierData = new MissileData(item);
							break;
						case "RocketPod":
							partModifierData = new RocketPodData(item);
							break;
						case "RocketWeapon":
							partModifierData = new RocketWeaponData(item);
							break;
						case "Cannon":
							partModifierData = new CannonData(item);
							break;
						case "Parachute":
							partModifierData = new ParachuteData(item);
							break;
						case "Gyroscope":
							partModifierData = new GyroscopeData(item);
							break;
						case "Torpedo":
							partModifierData = new TorpedoData(item);
							break;
						case "ResizableShape":
							partModifierData = new ResizableShapeData(item);
							break;
						case "CounterMeasureDispenser":
							partModifierData = new CounterMeasureDispenserData(item);
							break;
						case "ArrestingHook":
							partModifierData = new ArrestingHookData(item);
							break;
						case "CatapultConnector":
							partModifierData = new CatapultConnectorData(item);
							break;
						case "Winch":
							partModifierData = new WinchData(item);
							break;
						case "Magnet":
							partModifierData = new MagnetData(item);
							break;
						case "Transparency":
							partModifierData = new TransparencyData(item);
							break;
						case "ControlBase":
							partModifierData = new ControlBaseData(item);
							break;
						case "PosedGrip":
							partModifierData = new PosedGripData(item);
							break;
						case "Gauge":
							partModifierData = new GaugeData(item);
							break;
						case "AttitudeBall":
							partModifierData = new AttitudeBallData(item);
							break;
						case "Button":
							partModifierData = new CockpitButtonData(item);
							break;
						case "Switch":
							partModifierData = new CockpitSwitchData(item);
							break;
						case "Canopy":
							partModifierData = new CanopyData(item);
							break;
						case "Label":
							partModifierData = new LabelData(item);
							break;
						case "RefuelDrogue":
							partModifierData = new RefuelDrogueData(item);
							break;
						case "RefuelProbe":
							partModifierData = new RefuelProbeData(item);
							break;
						case "AdjustableJoystick":
							partModifierData = new AdjustableJoystickData(item);
							break;
						case "DesignerSelectionPreview":
							partModifierData = new DesignerSelectionPreviewData(item);
							break;
						case "TargetingPod":
							partModifierData = new TargetingPodData(item);
							break;
						case "Mfd":
							partModifierData = new MfdData(item);
							break;
						case "JetEngine":
							partModifierData = new JetEngineData(item);
							break;
						case "JetEngineShroud":
							partModifierData = new JetEngineShroudData(item);
							break;
						case "JWing":
							partModifierData = new JWingData(item);
							break;
						case "ControlSurfacePart":
							partModifierData = new ControlSurfacePartData(item);
							break;
						case "Seat":
							partModifierData = new SeatData(item);
							break;
						case "IKSeat":
							partModifierData = new IKSeatData(item);
							break;
						case "IKTarget":
							partModifierData = new IKTargetData(item);
							break;
						case "TextureDecal":
							partModifierData = new TextureDecalData(item);
							break;
						case "TextDecal":
							partModifierData = new TextDecalData(item);
							break;
						case "JWheel":
							partModifierData = new JWheelData(item);
							break;
						case "ProceduralMissile":
							partModifierData = new ProceduralMissileData(item);
							break;
						case "PropellerAssembly":
							partModifierData = new PropellerAssemblyData(item);
							break;
						case "JWheelSuspension":
							partModifierData = new JWheelSuspensionData(item);
							break;
						case "JEngine":
							partModifierData = new JEngineData(item);
							break;
						case "JDifferential":
							partModifierData = new JDifferentialData(item);
							break;
						case "JDriveShaft":
							partModifierData = new JDriveShaftData(item);
							break;
						case "JDriveHub":
							partModifierData = new JDriveHubData(item);
							break;
						case "JGearbox":
							partModifierData = new JGearboxData(item);
							break;
						case "JTransmission":
							partModifierData = new JTransmissionData(item);
							break;
						case "ProceduralMissileSubPart":
							partModifierData = new ProceduralMissileSubPartData(item);
							break;
						case "JFuselage":
							partModifierData = new JFuselageData(item);
							break;
						case "ProceduralBay":
							partModifierData = new ProceduralBayData(item);
							break;
						case "ProceduralWindow":
							partModifierData = new ProceduralWindowData(item);
							break;
						case "CockpitSound":
							partModifierData = new CockpitSoundData(item);
							break;
						case "Pedal":
							partModifierData = new PedalData(item);
							break;
						case "PartTargeting":
							partModifierData = new PartTargetingData(item);
							break;
						case "ResizableFuelTank":
							partModifierData = new ResizableFuelTankData(item);
							break;
						default:
							Debug.LogWarning("Unknown modifier: " + item.Name);
							break;
						}
						if (partModifierData == null)
						{
							continue;
						}
						partModifierData.Part = part;
						if (value.ContainsKey(partModifierData.StateElementName))
						{
							value[partModifierData.StateElementName]++;
						}
						else
						{
							value.Add(partModifierData.StateElementName, 1);
						}
						int num = value[partModifierData.StateElementName] - 1;
						modifiers.Add(partModifierData);
						IEnumerable<XElement> enumerable = partElement.Elements(partModifierData.StateElementName);
						if (enumerable != null && enumerable.Any())
						{
							List<XElement> list = enumerable.ToList();
							if (num >= 0 && num < list.Count)
							{
								partModifierData.RestoreFromState(list[num]);
							}
						}
					}
				}
				foreach (XElement item2 in (from x in partElement.Elements()
					where x.Name.LocalName.EndsWith("UniversalState")
					select x).ToList())
				{
					if (item2.Name.LocalName.Substring(0, item2.Name.LocalName.LastIndexOf(".")) == "CameraVantage")
					{
						CameraVantageData cameraVantageData = new CameraVantageData();
						modifiers.Add(cameraVantageData);
						cameraVantageData.RestoreFromState(item2);
					}
				}
			}
		}
	}
}
