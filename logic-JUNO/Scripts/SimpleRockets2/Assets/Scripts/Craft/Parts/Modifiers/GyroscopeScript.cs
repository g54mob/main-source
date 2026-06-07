using System;
using Assets.Scripts.Craft.Parts.Modifiers.Fuselage;
using Assets.Scripts.Craft.Parts.Modifiers.Propulsion;
using ModApi;
using ModApi.Craft;
using ModApi.Craft.Parts;
using ModApi.Craft.Parts.Input;
using ModApi.Craft.Propulsion;
using ModApi.GameLoop;
using ModApi.GameLoop.Interfaces;
using ModApi.Math;
using ModApi.Scripts.State.Validation;
using ModApi.Ui.Inspector;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers
{
	public class GyroscopeScript : PartModifierScript<GyroscopeData>, IAnalyzePerformance, IFlightStart, IGameLoopItem, IFlightFixedUpdate
	{
		private IFuelSource _battery;

		private FuselageScript _fuselage;

		private IInputController _inputPitch;

		private IInputController _inputRoll;

		private IInputController _inputYaw;

		private GameObject _internalGyro;

		private float _powerConsumption;

		private Vector3 _torqueScale = Vector3.one;

		private Vector3 _worldTorque;

		public float PowerConsumption => _powerConsumption;

		public bool UsesMachNumber => false;

		public void CalculateMassAndPowerFromFuselage()
		{
			if (_fuselage != null)
			{
				if (base.Data.Utilization >= 0f)
				{
					float num = _fuselage.Data.Volume * base.Data.Utilization * 226.666f * 0.01f;
					float power = num * 325f;
					base.Data.SetBasePowerAndMass(power, num);
					return;
				}
				float maximumGyroRadius = GetMaximumGyroRadius(_fuselage.Data);
				SetInternalRadius(maximumGyroRadius);
				float num2 = maximumGyroRadius;
				float num3 = maximumGyroRadius * 1.2f;
				float mass = MathF.PI * (num3 * num3) * num2 * 226.666f * 0.01f;
				base.Data.SetBasePowerAndMass(maximumGyroRadius * maximumGyroRadius * maximumGyroRadius * 3340f, mass);
			}
		}

		void IFlightFixedUpdate.FlightFixedUpdate(in FlightFrameData frame)
		{
			if (base.PartScript.Data.Activated && base.PartScript.CommandPod != null)
			{
				IFuelSource battery = _battery;
				if (battery != null && !battery.IsEmpty)
				{
					Vector3 direction = new Vector3(_inputPitch.Value, _inputYaw.Value, 0f - _inputRoll.Value);
					direction.Scale(_torqueScale);
					Vector3 vector = base.PartScript.CraftScript.CenterOfMass.TransformDirection(direction);
					if (base.Data.MaxAcceleration > 0f)
					{
						_worldTorque = vector;
					}
					else
					{
						_worldTorque = Vector3.Lerp(_worldTorque, vector, base.Data.SpoolUpRatio * frame.DeltaTime);
					}
					float sqrMagnitude = _worldTorque.sqrMagnitude;
					if (sqrMagnitude > 0f)
					{
						_powerConsumption = base.Data.ElectricalConsumption * base.Data.Power * Mathf.Clamp01(sqrMagnitude);
						base.PartScript.BodyScript.RigidBody.AddTorque(_worldTorque * base.Data.Power);
						_battery.RemoveFuel((double)_powerConsumption * frame.DeltaTimeWorld);
					}
					else
					{
						_powerConsumption = 0f;
					}
					return;
				}
			}
			_powerConsumption = 0f;
			_worldTorque = Vector3.zero;
		}

		void IFlightStart.FlightStart(in FlightFrameData frame)
		{
			_inputPitch = GetInputController((CraftControls x) => x.Pitch);
			_inputRoll = GetInputController((CraftControls x) => x.Roll);
			_inputYaw = GetInputController((CraftControls x) => x.Yaw);
		}

		public void HideInternal()
		{
			if (_internalGyro != null)
			{
				_internalGyro.SetActive(value: false);
			}
		}

		public override void OnCraftLoaded(ICraftScript craftScript, bool movedToNewCraft)
		{
			base.OnCraftLoaded(craftScript, movedToNewCraft);
			OnCraftStructureChanged(craftScript);
		}

		public override void OnCraftStructureChanged(ICraftScript craftScript)
		{
			base.OnCraftStructureChanged(craftScript);
			_battery = base.PartScript.BatteryFuelSource;
			if (Game.InFlightScene)
			{
				CalculateTorqueScale();
			}
		}

		public override void OnGenerateInspectorModel(PartInspectorModel model)
		{
			base.OnGenerateInspectorModel(model);
			GroupModel groupModel = new GroupModel("Gyroscope");
			model.AddGroup(groupModel);
			groupModel.Add(new TextModel("Power Consumption", () => Units.GetPowerString(_powerConsumption * 1000f)));
		}

		public void OnGeneratePerformanceAnalysisModel(GroupModel groupModel)
		{
			groupModel.Add(new TextModel("Power Consumption", () => Units.GetPowerString(base.Data.ElectricalConsumption * base.Data.Power * 1000f), null, "The power consumption of the gyroscope."));
		}

		public override void OnPartDestroyed()
		{
			base.OnPartDestroyed();
			if (Game.Instance.Designer != null)
			{
				if (_fuselage != null)
				{
					_fuselage.MeshesUpdated -= UpdatedFuselage;
				}
				Game.Instance.Designer.SelectedPartChanged -= Designer_SelectedPartChanged;
			}
		}

		public void ShowInternal()
		{
			if (_internalGyro != null)
			{
				_internalGyro.SetActive(value: true);
			}
		}

		public override void ValidatePart(ValidationResult result)
		{
			float num = base.Data.ElectricalConsumption * base.Data.Power;
			if (num > 0f)
			{
				result.ValidatFuel(this, _battery ?? EmptyFuelSource.GetOrCreate(FuelType.Battery), 100f * num);
			}
		}

		private void CalculateTorqueScale()
		{
			if (base.Data.MaxAcceleration > 0f)
			{
				float num = MathF.PI / 6f * base.Data.MaxAcceleration;
				Vector3 inertiaTensor = base.PartScript.CraftScript.InertiaTensor;
				_torqueScale.x = Mathf.Clamp01(inertiaTensor.x / base.Data.Power * num);
				_torqueScale.y = Mathf.Clamp01(inertiaTensor.y / base.Data.Power * num);
				_torqueScale.z = Mathf.Clamp01(inertiaTensor.z / base.Data.Power * num);
			}
			else
			{
				_torqueScale = Vector3.one;
			}
		}

		private void Designer_SelectedPartChanged(IPartScript oldPart, IPartScript newPart)
		{
			if (base.PartScript == oldPart)
			{
				HideInternal();
			}
			else if (base.PartScript == newPart)
			{
				ShowInternal();
			}
		}

		private float GetMaximumGyroRadius(FuselageData fuselage)
		{
			return Mathf.Min(Mathf.Min(Mathf.Min(fuselage.BottomScale.x, fuselage.BottomScale.y), Mathf.Min(fuselage.TopScale.x, fuselage.TopScale.y)), fuselage.Offset.y) - 0.023561945f;
		}

		private void SetInternalRadius(float radius)
		{
			if (_internalGyro != null)
			{
				_internalGyro.transform.localScale = new Vector3(radius, radius, radius);
			}
		}

		private void Start()
		{
			_fuselage = base.PartScript.GetModifier<FuselageScript>();
			if (!(_fuselage != null))
			{
				return;
			}
			bool flag = true;
			if (Game.Instance.Designer != null)
			{
				_fuselage.MeshesUpdated += UpdatedFuselage;
				Game.Instance.Designer.SelectedPartChanged += Designer_SelectedPartChanged;
				if (Game.Instance.Designer.SelectedPart == base.PartScript)
				{
					flag = false;
				}
			}
			_internalGyro = Utilities.FindFirstGameObjectMyselfOrChildren("InternalGyro", base.gameObject);
			SetInternalRadius(GetMaximumGyroRadius(_fuselage.Data));
			if (flag)
			{
				HideInternal();
			}
		}

		private void UpdatedFuselage(FuselageScript fuselageScript)
		{
			CalculateMassAndPowerFromFuselage();
		}
	}
}
