using System;
using System.Xml.Linq;
using Assets.Scripts.Design;
using Assets.Scripts.Design.PartProperties.Attributes;
using Assets.Scripts.Design.UI.PartProperties;
using Jundroo.Common.Utils;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers
{
	[PartModifierDesignerHeader("Wheel")]
	public class ResizableWheelData : PartModifierData, IModifierWithOutputs
	{
		public class TireTypes
		{
			public const string ATV = "ATV";

			public const string Futuristic = "Futuristic";

			public const string LandingGear = "LandingGear";

			public const string Normal = "Normal";

			public const string Offroad = "Offroad";

			public const string Performance = "Performance";

			public const string Racing = "Racing";

			public const string Rugged = "Rugged";

			public const string Street = "Street";

			public const string Tractor = "Tractor";

			public const string Tractor2 = "Tractor2";
		}

		private const float DefaultDamper = 1f;

		private const string DefaultDirection = "Normal";

		private const float DefaultSize = 1.5f;

		private const float DefaultSpring = 1f;

		private const float DefaultWidth = 1f;

		[DesignerPropertySlider(0f, 2.5f, 26, Label = "Damper", Order = 11)]
		private float _damper = 1f;

		[DesignerPropertyToggleButton(new string[] { "Normal", "Reversed" }, Label = "Engine Direction", Order = 5)]
		private string _direction = "Normal";

		[DesignerPropertyToggleButton(new string[] { "Manual", "Auto" }, Label = "Traction", Order = 6, Header = "Advanced")]
		private bool _enableAutoTraction;

		[DesignerPropertyToggleButton(new string[] { "Disabled", "Enabled" }, Label = "Suspension", Order = 9)]
		private bool _enableSuspension;

		[DesignerPropertyPartId(Label = "Engine", Order = 4, RequiredPartTypeId = "Car-Engine-1", MustBeConnected = true, StartMessage = "Select an engine to power this wheel.", NoOptionsMessage = "No Car Engines are available for this wheel.")]
		private int _engineId;

		[DesignerPropertySlider(1f, 5f, 41, Label = "Size", Order = 0)]
		private float _size = 1.5f;

		[DesignerPropertySlider(0.5f, 2.5f, 21, Label = "Suspension Strength", Order = 10)]
		private float _spring = 1f;

		[DesignerPropertyToggleButton(new string[]
		{
			"ATV", "Futuristic", "LandingGear", "Normal", "Street", "Offroad", "Performance", "Racing", "Rugged", "Tractor",
			"Tractor2"
		}, Label = "Tire Style", Order = 3)]
		private string _tire = "Normal";

		[DesignerPropertySlider(0.5f, 1.5f, 11, Label = "Forward Traction", Order = 7)]
		private float _tractionForward = 1f;

		[DesignerPropertySlider(0.5f, 1.5f, 11, Label = "Sideways Traction", Order = 8)]
		private float _tractionSideways = 1f;

		[DesignerPropertySlider(0f, 45f, 10, Label = "Turning Angle", Order = 2)]
		private float _turningAngle;

		[DesignerPropertySlider(0.5f, 1.5f, 11, Label = "Width", Order = 1)]
		private float _width = 1f;

		public float BrakeTorque { get; set; }

		public float Damper => _damper;

		public string Direction
		{
			get
			{
				return _direction;
			}
			set
			{
				_direction = value;
			}
		}

		public bool EnableSuspension => _enableSuspension;

		public int EngineId => _engineId;

		public float FrictionScale
		{
			get
			{
				float num = Mathf.Sqrt(_size) * Mathf.Sqrt(_width);
				if (num < 1f)
				{
					num = 1f;
				}
				return num;
			}
		}

		public bool HideRims { get; private set; }

		public override float Mass => base.Mass;

		public float MaxAngularVelocity { get; private set; }

		public Type ModifierScriptType => typeof(ResizableWheelScript);

		public float Radius => _size * 0.25f;

		public float SlipForwardAsymptote { get; set; }

		public float SlipForwardExtremum { get; set; }

		public float SlipSidewaysAsymptote { get; set; }

		public float SlipSidewaysExtremum { get; set; }

		public float Spring => _spring;

		public float SuspensionDistance => Mathf.Clamp(Radius * 0.35f, 0.05f, 0.25f);

		public float SuspensionStiffness { get; set; }

		public float ThicknessScale => _width * _size;

		public string Tire => _tire;

		public float TractionForward => _tractionForward;

		public float TractionSideways => _tractionSideways;

		public float TurningAngle => _turningAngle;

		public float TurningRate { get; private set; }

		public event EventHandler<EventArgs> WheelParametersChanged;

		public ResizableWheelData(XElement partType)
			: base(partType)
		{
			SuspensionStiffness = 0.65f;
			BrakeTorque = 50f;
		}

		public override XElement GenerateStateXml()
		{
			XElement xElement = base.GenerateStateXml();
			xElement.Add(new XAttribute("turningAngle", _turningAngle));
			xElement.Add(new XAttribute("engineId", _engineId));
			xElement.Add(new XAttribute("direction", _direction));
			xElement.Add(new XAttribute("size", _size));
			xElement.Add(new XAttribute("width", _width));
			xElement.Add(new XAttribute("tire", _tire));
			xElement.Add(new XAttribute("damper", _damper));
			xElement.Add(new XAttribute("spring", _spring));
			xElement.Add(new XAttribute("enableSuspension", _enableSuspension));
			xElement.Add(new XAttribute("enableAutoTraction", _enableAutoTraction));
			xElement.Add(new XAttribute("turningRate", TurningRate));
			if (HideRims)
			{
				xElement.Add(new XAttribute("hideRims", HideRims));
			}
			if (EngineId > 0)
			{
				xElement.Add(new XAttribute("maxAngularVelocity", MaxAngularVelocity));
			}
			xElement.Add(new XAttribute("brakeTorque", BrakeTorque));
			xElement.Add(new XAttribute("slipForwardExtremum", SlipForwardExtremum));
			xElement.Add(new XAttribute("slipForwardAsymptote", SlipForwardAsymptote));
			xElement.Add(new XAttribute("slipSidewaysExtremum", SlipSidewaysExtremum));
			xElement.Add(new XAttribute("slipSidewaysAsymptote", SlipSidewaysAsymptote));
			xElement.Add(new XAttribute("tractionForward", _tractionForward));
			xElement.Add(new XAttribute("tractionSideways", _tractionSideways));
			return xElement;
		}

		public override string GetGenericDesignerPropertySliderValueLabel(string propertyName, float sliderValue)
		{
			switch (propertyName)
			{
			case "_width":
			case "_damper":
			case "_spring":
			case "_tractionForward":
			case "_tractionSideways":
				return Utilities.FormatPercentage(sliderValue);
			case "_turningAngle":
			{
				int num = (int)sliderValue;
				if (num == 0)
				{
					return "None";
				}
				return num + "°";
			}
			default:
				return base.GetGenericDesignerPropertySliderValueLabel(propertyName, sliderValue);
			}
		}

		public override object GetSymmetricValue(string propertyName, int symmetricPartCount, PartModifierData sourceModifier, object sourceValue)
		{
			if (symmetricPartCount == 2 && propertyName == "_direction")
			{
				if (!((string)sourceValue == "Normal"))
				{
					return "Normal";
				}
				return "Reversed";
			}
			return base.GetSymmetricValue(propertyName, symmetricPartCount, sourceModifier, sourceValue);
		}

		public override PartModifierScript Initialize(GameObject parentGameObject, PartData.PartCreationInfo partCreationInfo, AircraftScript aircraftScript)
		{
			GameObject gameObject = new GameObject(typeof(ResizableWheelData).Name);
			gameObject.transform.parent = parentGameObject.transform;
			gameObject.transform.localPosition = Vector3.zero;
			gameObject.transform.localRotation = Quaternion.identity;
			ResizableWheelScript resizableWheelScript = gameObject.AddComponent<ResizableWheelScript>();
			resizableWheelScript.ResizableWheel = this;
			if (partCreationInfo.CreateRigidBody)
			{
				Transform transform = resizableWheelScript.transform.GetComponentInParent<PartScript>(includeInactive: true).transform.Find("EditorColliders");
				if (transform != null)
				{
					UnityEngine.Object.Destroy(transform.gameObject);
				}
			}
			resizableWheelScript.Initialize(this);
			return resizableWheelScript;
		}

		public override void OnGenericDesignerPropertiesUpdate(IGenericPartProperties genericPartProperties)
		{
			bool flag = false;
			if (_engineId != 0 && Designer.Instance.Aircraft.GetPartById(_engineId) != null)
			{
				flag = true;
			}
			if (flag)
			{
				genericPartProperties.SetPropertyStatus("_direction", IGenericPartProperties.PropertyStatus.Visible);
			}
			else
			{
				genericPartProperties.SetPropertyStatus("_direction", IGenericPartProperties.PropertyStatus.Hidden);
			}
			if (_enableAutoTraction)
			{
				genericPartProperties.SetPropertyStatus("_tractionForward", IGenericPartProperties.PropertyStatus.Hidden);
				genericPartProperties.SetPropertyStatus("_tractionSideways", IGenericPartProperties.PropertyStatus.Hidden);
			}
			else
			{
				genericPartProperties.SetPropertyStatus("_tractionForward", IGenericPartProperties.PropertyStatus.Visible);
				genericPartProperties.SetPropertyStatus("_tractionSideways", IGenericPartProperties.PropertyStatus.Visible);
			}
			if (EnableSuspension)
			{
				genericPartProperties.SetPropertyStatus("_spring", IGenericPartProperties.PropertyStatus.Visible);
				genericPartProperties.SetPropertyStatus("_damper", IGenericPartProperties.PropertyStatus.Visible);
			}
			else
			{
				genericPartProperties.SetPropertyStatus("_spring", IGenericPartProperties.PropertyStatus.Hidden);
				genericPartProperties.SetPropertyStatus("_damper", IGenericPartProperties.PropertyStatus.Hidden);
			}
		}

		public override void OnGenericDesignerPropertyChanged(string propertyName, string value)
		{
			switch (propertyName)
			{
			case "_enableAutoTraction":
				_tractionForward = 1f;
				_tractionSideways = 1f;
				break;
			case "_size":
			case "_width":
			case "_tire":
			case "_direction":
				if (this.WheelParametersChanged != null)
				{
					this.WheelParametersChanged(this, new EventArgs());
				}
				break;
			}
		}

		public override void RestoreFromState(XElement stateElement)
		{
			base.RestoreFromState(stateElement);
			_turningAngle = stateElement.GetFloatAttribute("turningAngle");
			_engineId = stateElement.GetIntAttribute("engineId");
			_direction = stateElement.GetStringAttribute("direction", "Normal");
			_size = stateElement.GetFloatAttribute("size", 1.5f);
			_width = stateElement.GetFloatAttribute("width", 1f);
			_tire = stateElement.GetStringAttribute("tire", "Normal");
			_spring = stateElement.GetFloatAttribute("spring", 1f);
			_damper = stateElement.GetFloatAttribute("damper", 1f);
			_enableSuspension = stateElement.GetBoolAttribute("enableSuspension");
			_enableAutoTraction = stateElement.GetBoolAttribute("enableAutoTraction");
			TurningRate = stateElement.GetFloatAttribute("turningRate", 150f);
			HideRims = stateElement.GetBoolAttribute("hideRims");
			_tractionForward = stateElement.GetFloatAttribute("tractionForward", 1f);
			_tractionSideways = stateElement.GetFloatAttribute("tractionSideways", 1f);
			MaxAngularVelocity = stateElement.GetFloatAttribute("maxAngularVelocity", 300f);
			BrakeTorque = stateElement.GetFloatAttribute("brakeTorque", 50f);
			SlipForwardExtremum = stateElement.GetFloatAttribute("slipForwardExtremum");
			SlipForwardAsymptote = stateElement.GetFloatAttribute("slipForwardAsymptote");
			SlipSidewaysExtremum = stateElement.GetFloatAttribute("slipSidewaysExtremum");
			SlipSidewaysAsymptote = stateElement.GetFloatAttribute("slipSidewaysAsymptote");
			if (SlipForwardExtremum <= 0.1f)
			{
				SlipForwardExtremum = 8f;
			}
			if (SlipForwardAsymptote <= 0.1f)
			{
				SlipForwardAsymptote = 10f;
			}
			if (SlipSidewaysExtremum <= 0.1f)
			{
				SlipSidewaysExtremum = 15f;
			}
			if (SlipSidewaysAsymptote <= 0.1f)
			{
				SlipSidewaysAsymptote = 20f;
			}
			if (_tractionForward < 0f)
			{
				_tractionForward = 0f;
			}
			if (_tractionSideways < 0f)
			{
				_tractionSideways = 0f;
			}
			if (_spring < 0f)
			{
				_spring = 0.01f;
			}
			if (_damper < 0f)
			{
				_damper = 0f;
			}
			if (_turningAngle < 0f)
			{
				_turningAngle = 0f;
			}
			if (_size < 0.1f)
			{
				_size = 0.1f;
			}
			if (_width < 0.1f)
			{
				_width = 0.1f;
			}
		}

		protected override float CalculateMass()
		{
			return CalculateMass(Radius, ThicknessScale * 0.25f);
		}

		private static float CalculateMass(float radius, float width)
		{
			float num = MathF.PI * radius * radius * width;
			float num2 = radius * 0.5f;
			float num3 = MathF.PI * num2 * num2 * width;
			float num4 = (num - num3) * 0.25f + num3 * 0.5f;
			if (num4 < 0.01f)
			{
				num4 = 0.01f;
			}
			return num4;
		}
	}
}
