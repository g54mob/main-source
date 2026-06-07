using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Craft.Parts.Modifiers.Propulsion;
using Assets.Scripts.Design;
using ModApi;
using ModApi.Craft;
using ModApi.Craft.Parts;
using ModApi.Craft.Parts.Input;
using ModApi.Craft.Parts.Styles;
using ModApi.Design;
using ModApi.GameLoop;
using ModApi.GameLoop.Interfaces;
using ModApi.Math;
using ModApi.Scripts.State.Validation;
using ModApi.Ui.Inspector;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers.LandingGear
{
	public class LandingGearScript : PartModifierScript<LandingGearData>, IAnalyzePerformance, IFlightUpdate, IGameLoopItem, IDesignerStart, IFlightPostStart
	{
		private AudioSource _audioMotor;

		private AudioSource _audioRollingFast;

		private AudioSource _audioRollingOffroad;

		private AudioSource _audioRollingRoad;

		private IFuelSource _battery;

		private Collider _bayCollider;

		private Transform _bayParent;

		private IInputController _brakeInput;

		private LandingGearScriptConfig _configScript;

		private ConfigurableGearScript _configurableGearScript;

		private Transform _doorParent;

		private bool _doubleWheel;

		private GameObject _loadedWheelStyle;

		private IInputController _motorInput;

		[SerializeField]
		private float _motorTorqueAverage;

		private Transform _scalePivotTrans;

		private Transform _suspensionTransform;

		private IInputController _turnInput;

		private WheelStyleTransformDataScript _wheelStyleDataScript;

		public bool UsesMachNumber => false;

		private float MaxPowerConsumption => base.Data.Torque * (float)((base.Data.Version < 4) ? 29 : 350);

		void IDesignerStart.DesignerStart(in DesignerFrameData frame)
		{
			CommonStart();
			base.Data.GearParametersChanged += GearParametersChanged;
			_turnInput = GetInputController("Turn");
			_motorInput = GetInputController("Motor");
			VisibilityMotor(base.Data.TorqueUnscaled > 0f);
			VisibilityTurn(base.Data.MaxTurningAngle > 0f);
			if (!base.Data.StartExtended)
			{
				_configurableGearScript.SetExtended(base.Data.StartExtended, snapToPosition: true);
			}
		}

		void IFlightPostStart.FlightPostStart(in FlightFrameData frame)
		{
			base.Data.LoadFlagsInFlight();
			CommonStart();
			if (base.Data.StartExtended)
			{
				base.Data.Part.Activated = true;
				_configurableGearScript.SetExtended(extended: true, snapToPosition: false);
				base.Data.StartExtended = false;
				base.Data.Extended = true;
				base.Data.ExtensionPercent = 1f;
			}
			else if (!base.Data.Extended.Value)
			{
				_configurableGearScript.SetExtended(extended: false, snapToPosition: false);
				base.Data.ExtensionPercent = 0f;
			}
			_configurableGearScript.SnapToExtensionPercent(base.Data.ExtensionPercent);
			_turnInput = GetInputController("Turn");
			_motorInput = GetInputController("Motor");
			_brakeInput = GetInputController("Brake");
			_configurableGearScript.BrakeTorque = base.Data.BrakeTorque;
			_configurableGearScript.MotorTorque = base.Data.Torque;
			_configurableGearScript.GearRatio = base.Data.GearRatio;
			_configurableGearScript.RetractionSpeedModifier = base.Data.RetractionSpeed;
			AudioSource[] components = base.transform.GetComponents<AudioSource>();
			_audioMotor = components[0];
			_audioMotor.time = UnityEngine.Random.Range(0f, _audioMotor.clip.length);
			_audioRollingFast = components[1];
			_audioRollingFast.time = UnityEngine.Random.Range(0f, _audioRollingFast.clip.length);
			_audioRollingOffroad = components[2];
			_audioRollingOffroad.time = UnityEngine.Random.Range(0f, _audioRollingOffroad.clip.length);
			_audioRollingRoad = components[3];
			_audioRollingRoad.time = UnityEngine.Random.Range(0f, _audioRollingRoad.clip.length);
		}

		void IFlightUpdate.FlightUpdate(in FlightFrameData frame)
		{
			_configurableGearScript.SetExtended(base.Data.Part.Activated, snapToPosition: false);
			_configurableGearScript.WheelTurnAngle = _turnInput.Value * base.Data.MaxTurningAngle;
			base.Data.Extended = _configurableGearScript.Extended;
			base.Data.ExtensionPercent = _configurableGearScript.ExtendedPercent;
			_motorTorqueAverage = Mathf.Lerp(_motorTorqueAverage, Mathf.Abs(_configurableGearScript.MotorTorque), 10f * frame.DeltaTime / base.Data.Scale);
			if (_audioMotor != null && base.Data.SoundVolume > 0f)
			{
				_audioMotor.pitch = Mathf.Clamp(0.0025f * Mathf.Abs(_configurableGearScript.RPM) * Time.timeScale, 0.1f, 20f);
				PartConnection partConnection = ((base.PartScript.Data.PartConnections.Count > 0) ? base.PartScript.Data.PartConnections[0] : null);
				float a = ((partConnection == null || partConnection.IsDestroyed) ? 0f : (0.25f * base.Data.Scale * Mathf.Abs(_configurableGearScript.RPM) / 5000f));
				float b = Mathf.Pow(0.1f * _motorTorqueAverage, 0.25f);
				b = Mathf.Clamp01(Mathf.Max(a, b)) * base.Data.SoundVolume;
				_audioMotor.volume = b;
				if (b > 0.01f)
				{
					if (!_audioMotor.isPlaying)
					{
						_audioMotor.Play();
					}
				}
				else if (_audioMotor.isPlaying)
				{
					_audioMotor.Stop();
				}
			}
			if (_audioRollingFast != null && _audioRollingOffroad != null && _audioRollingRoad != null)
			{
				if (_configurableGearScript.Grounded)
				{
					float sqrMagnitude = base.PartScript.CraftScript.SurfaceVelocity.sqrMagnitude;
					float num = Mathf.Clamp01(sqrMagnitude * 0.001f - 0.5f);
					_audioRollingFast.volume = num * base.Data.Scale * 0.25f;
					float offroadPercentage = _configurableGearScript.OffroadPercentage;
					float num2 = base.Data.Scale * 0.1f * Mathf.Clamp01(sqrMagnitude * 0.1f) * (1f - num);
					_audioRollingOffroad.volume = offroadPercentage * num2;
					_audioRollingRoad.volume = (1f - offroadPercentage) * num2;
					float num3 = sqrMagnitude * 0.001f * 2.5f + 0.5f;
					_audioRollingFast.pitch = 0.1f * num3;
					_audioRollingOffroad.pitch = num3;
					_audioRollingRoad.pitch = num3;
					if (_audioRollingFast.volume > 0.001f)
					{
						if (!_audioRollingFast.isPlaying)
						{
							_audioRollingFast.Play();
						}
					}
					else if (_audioRollingFast.isPlaying)
					{
						_audioRollingFast.Stop();
					}
					if (offroadPercentage * num2 > 0.001f)
					{
						if (!_audioRollingOffroad.isPlaying)
						{
							_audioRollingOffroad.Play();
						}
					}
					else if (_audioRollingOffroad.isPlaying)
					{
						_audioRollingOffroad.Stop();
					}
					if ((1f - offroadPercentage) * num2 > 0.001f)
					{
						if (!_audioRollingRoad.isPlaying)
						{
							_audioRollingRoad.Play();
						}
					}
					else if (_audioRollingRoad.isPlaying)
					{
						_audioRollingRoad.Stop();
					}
				}
				else
				{
					if (_audioRollingFast.isPlaying)
					{
						_audioRollingFast.Stop();
					}
					if (_audioRollingOffroad.isPlaying)
					{
						_audioRollingOffroad.Stop();
					}
					if (_audioRollingRoad.isPlaying)
					{
						_audioRollingRoad.Stop();
					}
				}
			}
			if (base.Data.Part.Activated)
			{
				ICommandPod commandPod = base.PartScript.CommandPod;
				if (_brakeInput != null)
				{
					_configurableGearScript.Brake = Mathf.Clamp01(_brakeInput.Value);
				}
				else if (commandPod != null)
				{
					_configurableGearScript.Brake = base.PartScript.CommandPod.Controls.Brake;
				}
				else
				{
					_configurableGearScript.Brake = 0f;
				}
				IFuelSource battery = _battery;
				if (battery != null && !battery.IsEmpty)
				{
					_configurableGearScript.MotorThrottle = _motorInput.Value;
					float num4 = 0.001f * Mathf.Abs(_motorInput.Value) * MaxPowerConsumption * frame.DeltaTime;
					if (num4 > 0f)
					{
						_battery.RemoveFuel(num4);
					}
				}
				else
				{
					_configurableGearScript.MotorThrottle = 0f;
				}
			}
			else
			{
				_configurableGearScript.Brake = 0f;
				_configurableGearScript.MotorThrottle = 0f;
			}
		}

		public override void OnCraftLoaded(ICraftScript craftScript, bool movedToNewCraft)
		{
			base.OnCraftLoaded(craftScript, movedToNewCraft);
			_battery = base.PartScript.BatteryFuelSource;
			if (movedToNewCraft)
			{
				_configurableGearScript.OnCraftStructureChanged(craftScript);
			}
		}

		public override void OnCraftStructureChanged(ICraftScript craftScript)
		{
			base.OnCraftStructureChanged(craftScript);
			_battery = base.PartScript.BatteryFuelSource;
			_configurableGearScript.OnCraftStructureChanged(craftScript);
		}

		public override void OnGenerateInspectorModel(PartInspectorModel model)
		{
			base.OnGenerateInspectorModel(model);
			_configurableGearScript.GenerateInspectorModel(model);
		}

		public void OnGeneratePerformanceAnalysisModel(GroupModel groupModel)
		{
			groupModel.Add(new TextModel("Top Speed", () => Units.GetVelocityString(1333f / base.Data.GearRatio * base.Data.Scale * 0.59f * MathF.PI / 30f), null, "The ideal top speed achievable with the wheel based on its radius and rpm."));
			groupModel.Add(new TextModel("Max RPM", () => Mathf.Round(1333f / base.Data.GearRatio).ToString(), null, "The max amount of revolutions per minute the wheel can achieve."));
			groupModel.Add(new TextModel("Power Consumption", () => Units.GetPowerString(MaxPowerConsumption), null, "The max power consumption of the wheel."));
			groupModel.Add(new TextModel("Concrete Friction", () => "100%", null, "The amount of friction on structures."));
			groupModel.Add(new TextModel("Offroad Friction", () => "100%", null, "The amount of friction on the terrain."));
		}

		public override void OnSymmetry(SymmetryMode mode, IPartScript originalPart, bool created)
		{
			HandleDirectionFromSymmetry(mode, created);
			if (!created)
			{
				UpdateGearShape();
			}
			_configurableGearScript.RetractionSpeedModifier = base.Data.RetractionSpeed;
			if (_configurableGearScript.Extended != base.Data.StartExtended)
			{
				_configurableGearScript.SetExtended(base.Data.StartExtended, snapToPosition: false);
			}
		}

		public override void PrepareForPartIcon()
		{
			RebuildGear();
		}

		public override void RecalculateFrameState(Vector3 positionDelta, Vector3 velocityDelta)
		{
			base.RecalculateFrameState(positionDelta, velocityDelta);
			_configurableGearScript.RecalculateFrameState(positionDelta, velocityDelta);
		}

		public void Start()
		{
			if (!Game.InDesignerScene && !Game.InFlightScene)
			{
				CommonStart();
				_configurableGearScript.SetExtended(base.Data.Extended.Value, snapToPosition: false);
				_configurableGearScript.SnapToExtensionPercent(base.Data.ExtensionPercent);
			}
		}

		public void UpdateRetractionSpeed()
		{
			Symmetry.SynchronizePartModifiers(base.PartScript);
			_configurableGearScript.RetractionSpeedModifier = base.Data.RetractionSpeed;
		}

		public void UpdateShapeAndSync()
		{
			UpdateGearShape();
			Symmetry.SynchronizePartModifiers(base.PartScript);
		}

		public void UpdateStartExtended(bool startExtended)
		{
			_configurableGearScript.SetExtended(startExtended, snapToPosition: false);
			Symmetry.SynchronizePartModifiers(base.PartScript);
		}

		public override void ValidatePart(ValidationResult result)
		{
			result.ValidatFuel(this, _battery, MaxPowerConsumption / 1000f);
		}

		public void VisibilityMotor(bool visible)
		{
			if (_motorInput != null && _motorInput.Visible != visible)
			{
				_motorInput.Visible = visible;
			}
		}

		public void VisibilityTurn(bool visible)
		{
			if (_turnInput != null && _turnInput.Visible != visible)
			{
				_turnInput.Visible = visible;
			}
		}

		protected override void OnInitialized()
		{
			base.OnInitialized();
			_suspensionTransform = Utilities.FindFirstGameObjectMyselfOrChildren("Suspension", base.gameObject).transform;
			int childCount = _suspensionTransform.childCount;
			for (int i = 0; i < childCount; i++)
			{
				DeleteAndRemoveRenderers(_suspensionTransform.GetChild(i).gameObject);
			}
			if (!base.Data.Extended.HasValue)
			{
				base.Data.Extended = base.Data.StartExtended;
			}
			_bayParent = Utilities.FindFirstGameObjectMyselfOrChildren("InternalBay", base.gameObject).transform;
			_bayCollider = _bayParent.GetComponent<Collider>();
			_configurableGearScript = base.transform.GetComponent<ConfigurableGearScript>();
		}

		private void ActivateBayStyle(string name)
		{
			foreach (IPartStyle style in Game.Instance.PartStyleManager.GetStyles(base.PartScript.Data.PartType.Id, 2))
			{
				string id = style.Id;
				GameObject gameObject = Utilities.FindFirstGameObjectMyselfOrChildren(id, base.PartScript.GameObject);
				if (gameObject == null && name == id)
				{
					gameObject = UnityEngine.Object.Instantiate(Resources.Load("Craft/Parts/Prefabs/LandingGear/" + id)) as GameObject;
					gameObject.transform.SetParent(_bayParent, worldPositionStays: false);
					gameObject.layer = _bayParent.gameObject.layer;
					gameObject.transform.localPosition = Vector3.zero;
					gameObject.name = id;
					MeshRenderer[] componentsInChildren = gameObject.GetComponentsInChildren<MeshRenderer>();
					foreach (MeshRenderer meshRenderer in componentsInChildren)
					{
						meshRenderer.gameObject.layer = _suspensionTransform.gameObject.layer;
						base.PartScript.PartMaterialScript.AddRenderer(meshRenderer, true);
					}
				}
				if (gameObject != null)
				{
					if (name == id)
					{
						gameObject.SetActive(value: true);
					}
					else if (Game.InDesignerScene)
					{
						gameObject.SetActive(value: false);
					}
					else
					{
						MeshRenderer[] componentsInChildren = gameObject.GetComponentsInChildren<MeshRenderer>();
						foreach (MeshRenderer renderer in componentsInChildren)
						{
							base.PartScript.PartMaterialScript.RemoveRenderer(renderer);
						}
						UnityEngine.Object.DestroyImmediate(gameObject);
					}
				}
				_configurableGearScript.OnGearRebuilt(_wheelStyleDataScript);
			}
		}

		private void ActivateDoorStyle(string doorName, string bayName)
		{
			string fullDoorStyleName = GetFullDoorStyleName(doorName, bayName);
			IPartStyleManager partStyleManager = Game.Instance.PartStyleManager;
			IReadOnlyList<IPartStyle> styles = partStyleManager.GetStyles(base.PartScript.Data.PartType.Id, 2);
			foreach (IPartStyle style in partStyleManager.GetStyles(base.PartScript.Data.PartType.Id, 3))
			{
				foreach (IPartStyle item in styles)
				{
					string fullDoorStyleName2 = GetFullDoorStyleName(style.Id, item.Id);
					GameObject gameObject = Utilities.FindFirstGameObjectMyselfOrChildren(fullDoorStyleName2, base.PartScript.GameObject);
					if (gameObject == null && fullDoorStyleName == fullDoorStyleName2)
					{
						gameObject = UnityEngine.Object.Instantiate(Resources.Load("Craft/Parts/Prefabs/LandingGear/" + fullDoorStyleName)) as GameObject;
						gameObject.transform.SetParent(_bayParent, worldPositionStays: false);
						gameObject.layer = _bayParent.gameObject.layer;
						gameObject.transform.localPosition = Vector3.zero;
						gameObject.name = fullDoorStyleName;
						MeshRenderer[] componentsInChildren = gameObject.GetComponentsInChildren<MeshRenderer>();
						foreach (MeshRenderer meshRenderer in componentsInChildren)
						{
							meshRenderer.gameObject.layer = _suspensionTransform.gameObject.layer;
							base.PartScript.PartMaterialScript.AddRenderer(meshRenderer, true);
						}
						_doorParent = gameObject.transform;
					}
					if (!(gameObject != null))
					{
						continue;
					}
					if (fullDoorStyleName == fullDoorStyleName2)
					{
						gameObject.SetActive(value: true);
						_doorParent = gameObject.transform;
						string[] array = base.PartScript.Data.Styles[3].Style.GetData("FlipTransforms", string.Empty).Split(';');
						if (array.Length == 0 || string.IsNullOrEmpty(array[0]))
						{
							continue;
						}
						Vector3 localScale = gameObject.transform.localScale;
						int num = 1;
						localScale.x = num;
						localScale.y = num;
						if (base.Data.Flipped)
						{
							localScale.x *= -1f;
						}
						string[] array2 = array;
						foreach (string value in array2)
						{
							if (!string.IsNullOrEmpty(value))
							{
								Transform transform = Utilities.FindFirstGameObjectMyselfOrChildren(value, gameObject)?.transform;
								if (transform != null)
								{
									transform.localScale = localScale;
								}
							}
						}
					}
					else if (Game.InDesignerScene)
					{
						gameObject.SetActive(value: false);
					}
					else
					{
						MeshRenderer[] componentsInChildren = gameObject.GetComponentsInChildren<MeshRenderer>();
						foreach (MeshRenderer renderer in componentsInChildren)
						{
							base.PartScript.PartMaterialScript.RemoveRenderer(renderer);
						}
						UnityEngine.Object.DestroyImmediate(gameObject);
					}
				}
			}
		}

		private void ActivateWheelStyle(string name)
		{
			if (_loadedWheelStyle != null)
			{
				DeleteAndRemoveRenderers(_loadedWheelStyle);
			}
			_loadedWheelStyle = UnityEngine.Object.Instantiate(Resources.Load("Craft/Parts/Prefabs/LandingGear/" + name)) as GameObject;
			_loadedWheelStyle.transform.SetParent(_suspensionTransform, worldPositionStays: false);
			_loadedWheelStyle.layer = _suspensionTransform.gameObject.layer;
			_loadedWheelStyle.transform.localPosition = Vector3.zero;
			_loadedWheelStyle.name = name;
			MeshRenderer[] componentsInChildren = _loadedWheelStyle.GetComponentsInChildren<MeshRenderer>();
			foreach (MeshRenderer meshRenderer in componentsInChildren)
			{
				meshRenderer.gameObject.layer = _suspensionTransform.gameObject.layer;
				base.PartScript.PartMaterialScript.AddRenderer(meshRenderer, true);
			}
			_doubleWheel = name == "Wheel-Double";
			_wheelStyleDataScript = _loadedWheelStyle.GetComponent<WheelStyleTransformDataScript>();
			_configurableGearScript.OnGearRebuilt(_wheelStyleDataScript);
			_loadedWheelStyle.SetActive(value: true);
			string[] array = base.PartScript.Data.Styles[1].Style.GetData("FlipTransforms", string.Empty).Split(';');
			if (array.Length != 0 && !string.IsNullOrEmpty(array[0]))
			{
				Vector3 localScale = _loadedWheelStyle.transform.localScale;
				int num = 1;
				localScale.x = num;
				localScale.y = num;
				if (base.Data.Flipped)
				{
					localScale.x *= -1f;
				}
				string[] array2 = array;
				foreach (string value in array2)
				{
					if (!string.IsNullOrEmpty(value))
					{
						Utilities.FindFirstGameObjectMyselfOrChildren(value, _loadedWheelStyle).transform.localScale = localScale;
					}
				}
			}
			RecalculateCom();
		}

		private void CommonStart()
		{
			_configScript = GetComponent<LandingGearScriptConfig>();
			RebuildGear();
			_configurableGearScript.Initialize(Game.InFlightScene, suspensionEnabled: true, base.Data.SpringForceScale, base.Data.DamperScale, base.Data.TractionForward, base.Data.TractionSideways, _doubleWheel);
		}

		private void DeleteAndRemoveRenderers(GameObject root)
		{
			MeshRenderer[] componentsInChildren = root.GetComponentsInChildren<MeshRenderer>();
			foreach (MeshRenderer renderer in componentsInChildren)
			{
				base.PartScript.PartMaterialScript.RemoveRenderer(renderer);
			}
			UnityEngine.Object.DestroyImmediate(root);
		}

		private void GearParametersChanged(object sender, EventArgs e)
		{
			RebuildGear();
			base.PartScript.CraftScript.SetStructureChanged();
		}

		private string GetFullDoorStyleName(string doorName, string bayName)
		{
			string text = bayName;
			int num = bayName.IndexOf('-') + 1;
			string text2 = text.Substring(num, text.Length - num);
			text = doorName;
			num = doorName.IndexOf('-') + 1;
			string text3 = text.Substring(num, text.Length - num);
			if (text2 == "None" || text3 == "None")
			{
				return "Door-None";
			}
			return "Door-" + text2 + "-" + text3;
		}

		private IPartStyle GetSelectedStyle(string name)
		{
			int index = base.PartScript.Data.PartType.Subparts.ToList().FindIndex((SubpartType x) => x.DisplayName == name);
			return base.PartScript.Data.Styles[index].Style;
		}

		private void HandleDirectionFromSymmetry(SymmetryMode mode, bool created)
		{
			if ((uint)(mode - 1) > 1u)
			{
				return;
			}
			IPartScript partScript = Symmetry.GetSymmetricPartScripts(base.PartScript).FirstOrDefault((IPartScript x) => x != base.PartScript);
			if (partScript != null && (base.Data.Part.Mirrored || mode == SymmetryMode.Radial2) && Game.InDesignerScene)
			{
				LandingGearScript modifier = partScript.GetModifier<LandingGearScript>();
				base.Data.Flipped = !modifier.Data.Flipped;
			}
			else if (partScript != null && partScript.Data.Mirrored && Game.InDesignerScene)
			{
				LandingGearScript modifier2 = partScript.GetModifier<LandingGearScript>();
				if (modifier2.Data.Flipped == base.Data.Flipped)
				{
					base.Data.Flipped = !modifier2.Data.Flipped;
				}
			}
			else if (created && mode == SymmetryMode.Mirror)
			{
				base.Data.Flipped = !base.Data.Flipped;
			}
			else
			{
				Debug.Log("Unsupported mirror/symmetry configuration.", this);
			}
		}

		private void RebuildGear()
		{
			IPartStyle selectedStyle = GetSelectedStyle("Wheel");
			ActivateWheelStyle(selectedStyle.Id);
			IPartStyle selectedStyle2 = GetSelectedStyle("Bay");
			ActivateBayStyle(selectedStyle2.Id);
			IPartStyle selectedStyle3 = GetSelectedStyle("Door");
			ActivateDoorStyle(selectedStyle3.Id, selectedStyle2.Id);
			if (base.PartScript.SymmetrySlice?.SymmetryGroup != null)
			{
				HandleDirectionFromSymmetry(base.PartScript.SymmetrySlice.SymmetryGroup.SymmetryMode, created: false);
			}
			if (selectedStyle3.Data.TryGetValue("OpenRotations", out var value))
			{
				try
				{
					Vector3 vector = Vector3.zero;
					Transform transform;
					if (selectedStyle2.Id == "Bay-None")
					{
						base.Data.HasBay = false;
						base.Data.HasDoor = false;
						_configurableGearScript.SetLandingGearDoors(null, null);
						transform = _configurableGearScript.AttachPointWithoutBay;
						if (base.Data.Version > 3)
						{
							vector = new Vector3(0f, -0.295f, 0f);
						}
					}
					else
					{
						base.Data.HasBay = true;
						base.Data.HasDoor = selectedStyle3.Id != "Door-None";
						if (base.Data.HasDoor)
						{
							List<Vector3> openRotations = (from x in value.Split('|')
								select Utilities.ParseVector3(x)).ToList();
							_configurableGearScript.SetLandingGearDoors(_doorParent, openRotations);
						}
						else
						{
							_configurableGearScript.SetLandingGearDoors(null, null);
						}
						transform = _configurableGearScript.AttachPointWithBay;
					}
					_configurableGearScript.LandingGearRoot.transform.localPosition = vector - transform.localPosition;
					_bayCollider.isTrigger = !base.Data.HasBay;
					if (Game.InDesignerScene)
					{
						base.Data.SetLandingLegRestrictionsEnabled(base.Data.HasBay);
					}
				}
				catch (Exception ex)
				{
					Debug.LogError("Could not initialize landing gear bay door rotaion information: " + ex.Message);
				}
			}
			UpdateGearShape();
			if (!base.Data.StartExtended)
			{
				_configurableGearScript.SetExtended(extended: false, snapToPosition: true);
			}
		}

		private void RecalculateCom()
		{
			float num = 0.5f;
			if (!base.Data.HasBay)
			{
				num *= 1.2f;
			}
			base.PartScript.Data.Config.CenterOfMass = base.transform.InverseTransformPoint(_wheelStyleDataScript.ColliderTransform.position) * num;
			base.PartScript.CraftScript.SetStructureChanged();
		}

		private void UpdateBaySize()
		{
			if (_scalePivotTrans == null)
			{
				_scalePivotTrans = new GameObject("PivotTrans").transform;
				_scalePivotTrans.parent = base.transform;
			}
			float num = ((base.Data.ForwardOffset > 0f) ? (0.5f * base.Data.ForwardOffset) : 0f);
			float num2 = base.Data.BayLength - 1f;
			float num3 = num + num2;
			if (!(_configurableGearScript != null) || !(_bayParent != null) || !(_configScript != null))
			{
				return;
			}
			if (!Utilities.CompareFloats(num3, 0f))
			{
				List<Transform> list = new List<Transform>();
				foreach (Transform item in _configScript.TransformsToScaleWithBay)
				{
					list.Add(item.parent);
					item.SetParent(_bayParent, worldPositionStays: true);
				}
				_bayParent.localPosition = Vector3.zero;
				_bayParent.localScale = Vector3.one;
				Vector3 scale = new Vector3(base.Data.BayWidth, 1f, 1f + num3);
				Vector3 position = (_configurableGearScript.BackOfBay.position * num + _configurableGearScript.FrontOfBay.position * num2) / num3;
				_scalePivotTrans.SetPositionAndRotation(position, _bayParent.rotation);
				Utilities.UnityTransform.ScaleAroundPivot(_bayParent, _scalePivotTrans, scale);
				for (int i = 0; i < list.Count; i++)
				{
					_configScript.TransformsToScaleWithBay[i].SetParent(list[i], worldPositionStays: true);
				}
			}
			else
			{
				_bayParent.localPosition = Vector3.zero;
				_bayParent.localScale = new Vector3(base.Data.BayWidth, 1f, 1f);
			}
		}

		private void UpdateGearShape()
		{
			foreach (AttachPointScript attachPointScript in base.PartScript.AttachPointScripts)
			{
				attachPointScript.AttachPoint.Scale = 2f * base.Data.Scale;
			}
			base.PartScript.Transform.localScale = Vector3.one * base.Data.Scale;
			_configurableGearScript.SlantAngle = base.Data.SlantAngle;
			_configurableGearScript.ForwardOffset = base.Data.ForwardOffset;
			_configurableGearScript.SuspensionTravel = base.Data.SuspensionTravel;
			_configurableGearScript.HeightOffset = base.Data.HeightOffset;
			_configurableGearScript.LengthScale = base.Data.LengthScale;
			_configurableGearScript.Scale = base.Data.Scale;
			_configurableGearScript.SupportArmEnabled = base.Data.SupportArmEnabled;
			_configurableGearScript.ShowUpperBraces = base.Data.ShowUpperBraces;
			int num = ((!base.Data.Flipped) ? 1 : (-1));
			_configurableGearScript.SideOffset = base.Data.SideOffset * (float)num;
			_configurableGearScript.VerticalAngleOffset = base.Data.VerticalAngleOffset * (float)num;
			UpdateBaySize();
			RecalculateCom();
		}
	}
}
