using System;
using System.Collections.Generic;
using System.Reflection;
using System.Xml.Linq;
using ModApi.Common.Extensions;
using ModApi.Planet.Modifiers.Attributes;
using ModApi.Ui.Inspector;
using UnityEngine;

namespace ModApi.Planet.Modifiers.VertexData
{
	[PlanetModifierInfo("Polar Cap Mask", "A planet modifier used to create a mask value for polar caps. The north pole mask is from zero to 1 and the south pole mask is from 0 to -1. This modifier has 3 sets of information for each pole. First, inner and outer angles and values are defined. The angles are based on a vector through the center of the pole. The values are applied for the inner/outer angles and interpolated between those. Next, an optional (but recommended) noise data input is added to the previous value. This noise input's strength is also defined by inner and outer angles. This is so that the noise can be smoothly faded out. Finally, the value is remapped in the range of zero to one (or -1 for the south pole) based on the specified linear remap range.")]
	public class PolarCapMask : VertexDataCommonPassPlanetModifier, IDataSlotConfiguration
	{
		[Serializable]
		public class Config
		{
			[SerializeField]
			[InspectorGroup("Output Value")]
			[InspectorProperty(null, false, Label = "Inner Value", Order = 10, Tooltip = "The output value (before noise and remapping) that is used leading up to and including the inner angle.")]
			private double _adjustmentValueInner = 2.0;

			[SerializeField]
			[Range(0f, 85f)]
			[InspectorProperty(null, false, Label = "Inner Angle", Order = 30, Tooltip = "The inner angle (in degrees) based on a vector through the center of the pole.")]
			private double _adjustmentValueInnerAngle = 5.0;

			private double _adjustmentValueInnerY;

			[SerializeField]
			[InspectorProperty(null, false, Label = "Outer Value", Order = 20, Tooltip = "The output value (before noise and remapping) that is used at the outer angle and beyond.")]
			private double _adjustmentValueOuter;

			[SerializeField]
			[Range(0f, 85f)]
			[InspectorProperty(null, false, Label = "Outer Angle", Order = 40, Tooltip = "The outer angle (in degrees) based on a vector through the center of the pole.")]
			private double _adjustmentValueOuterAngle = 20.0;

			private double _adjustmentValueOuterY;

			private double _adjustmentValueRangeFactor;

			[SerializeField]
			[Range(-1f, 9f)]
			[DataSlot(DataSlotType.Input, "Noise Input", true, true, Order = 1, Tooltip = "The input data value that provides noise to the polar cap mask.")]
			private int _dataIndexInputNoise = -1;

			[SerializeField]
			[InspectorProperty(null, false, Label = "Max Value", Order = 100, Tooltip = "The maximum value used to remap the output value in the range of zero to one.")]
			private double _linearRemapMax = 1.5;

			[SerializeField]
			[InspectorProperty(null, false, Label = "Clamped", Order = 110, Tooltip = "If enabled, the linear remapping will be clamped in the range of zero to one. If disabled, output values could exceed the zero to one range.")]
			private bool _linearRemapMaxClamped = true;

			[SerializeField]
			[InspectorGroup("Linear Remap")]
			[InspectorProperty(null, false, Label = "Min Value", Order = 90, Tooltip = "The minimum value used to remap the output value in the range of zero to one.")]
			private double _linearRemapMin = 1.25;

			[SerializeField]
			[InspectorGroup("Noise Strength")]
			[InspectorProperty(null, false, Label = "Inner Strength", Order = 50, Tooltip = "The noise strength that is used leading up to and including the inner angle.")]
			private double _noiseFadeInner;

			[SerializeField]
			[Range(0f, 85f)]
			[InspectorProperty(null, false, Label = "Inner Angle", Order = 70, Tooltip = "The inner angle (in degrees) based on a vector through the center of the pole.")]
			private double _noiseFadeInnerAngle = 5.0;

			private double _noiseFadeInnerY;

			[SerializeField]
			[InspectorProperty(null, false, Label = "Outer Strength", Order = 60, Tooltip = "The noise strength that is used at the outer angle and beyond.")]
			private double _noiseFadeOuter = 1.0;

			[SerializeField]
			[Range(0f, 85f)]
			[InspectorProperty(null, false, Label = "Outer Angle", Order = 80, Tooltip = "The outer angle (in degrees) based on a vector through the center of the pole.")]
			private double _noiseFadeOuterAngle = 20.0;

			private double _noiseFadeOuterY;

			private double _noiseFadeRangeFactor;

			private double _oneOverLinearRemapRange;

			public static Config CreateFromXml(XElement xml)
			{
				Config config = new Config();
				if (xml != null)
				{
					config._dataIndexInputNoise = ((int?)xml.Attribute("dataIndexInputNoise")).GetValueOrDefault();
					config._adjustmentValueInner = ((double?)xml.Attribute("adjustmentValueInner")).GetValueOrDefault();
					config._adjustmentValueOuter = ((double?)xml.Attribute("adjustmentValueOuter")).GetValueOrDefault();
					config._adjustmentValueInnerAngle = ((double?)xml.Attribute("adjustmentValueInnerAngle")).GetValueOrDefault();
					config._adjustmentValueOuterAngle = ((double?)xml.Attribute("adjustmentValueOuterAngle")).GetValueOrDefault();
					config._noiseFadeInner = ((double?)xml.Attribute("noiseFadeInner")).GetValueOrDefault();
					config._noiseFadeOuter = ((double?)xml.Attribute("noiseFadeOuter")).GetValueOrDefault();
					config._noiseFadeInnerAngle = ((double?)xml.Attribute("noiseFadeInnerAngle")).GetValueOrDefault();
					config._noiseFadeOuterAngle = ((double?)xml.Attribute("noiseFadeOuterAngle")).GetValueOrDefault();
					config._linearRemapMaxClamped = ((bool?)xml.Attribute("linearRemapMaxClamped")) ?? true;
					config._linearRemapMax = ((double?)xml.Attribute("linearRemapMax")).GetValueOrDefault();
					config._linearRemapMin = ((double?)xml.Attribute("linearRemapMin")).GetValueOrDefault();
				}
				config._adjustmentValueInnerY = System.Math.Cos(config._adjustmentValueInnerAngle * 0.01745329238474369);
				config._adjustmentValueOuterY = System.Math.Cos(config._adjustmentValueOuterAngle * 0.01745329238474369);
				config._noiseFadeInnerY = System.Math.Cos(config._noiseFadeInnerAngle * 0.01745329238474369);
				config._noiseFadeOuterY = System.Math.Cos(config._noiseFadeOuterAngle * 0.01745329238474369);
				config._adjustmentValueRangeFactor = (config._adjustmentValueInner - config._adjustmentValueOuter) / (config._adjustmentValueInnerY - config._adjustmentValueOuterY);
				config._noiseFadeRangeFactor = (config._noiseFadeInner - config._noiseFadeOuter) / (config._noiseFadeInnerY - config._noiseFadeOuterY);
				config._oneOverLinearRemapRange = 1.0 / (config._linearRemapMax - config._linearRemapMin);
				return config;
			}

			public void GetDataSlots(List<DataSlotField> dataSlots, string prefix)
			{
				FieldInfo field = Utilities.GetField(() => _dataIndexInputNoise);
				DataSlotAttribute customAttribute = field.GetCustomAttribute<DataSlotAttribute>();
				DataSlotAttribute dataSlotAttribute = new DataSlotAttribute(customAttribute.DataSlotType, prefix + " " + customAttribute.Name, customAttribute.Optional, customAttribute.UserEditable);
				dataSlotAttribute.Order = customAttribute.Order;
				dataSlotAttribute.Tooltip = customAttribute.Tooltip;
				dataSlots.Add(new DataSlotField(this, dataSlotAttribute, field));
			}

			public double GetResult(double y, double[] data)
			{
				double num = System.Math.Abs(y);
				double num2 = 0.0;
				num2 = ((num >= _adjustmentValueInnerY) ? _adjustmentValueInner : ((!(num < _adjustmentValueOuterY)) ? (_adjustmentValueOuter + (num - _adjustmentValueOuterY) * _adjustmentValueRangeFactor) : _adjustmentValueOuter));
				if (_dataIndexInputNoise != -1)
				{
					double num3 = 0.0;
					num3 = ((num >= _noiseFadeInnerY) ? _noiseFadeInner : ((!(num < _noiseFadeOuterY)) ? (_noiseFadeOuter + (num - _noiseFadeOuterY) * _noiseFadeRangeFactor) : _noiseFadeOuter));
					num2 += data[_dataIndexInputNoise] * num3;
				}
				if (num2 >= _linearRemapMax && _linearRemapMaxClamped)
				{
					return 1.0;
				}
				if (num2 < _linearRemapMin)
				{
					return 0.0;
				}
				return (num2 - _linearRemapMin) * _oneOverLinearRemapRange;
			}

			public XElement SaveToXml(XElement xml)
			{
				xml.SetAttributeValue("dataIndexInputNoise", _dataIndexInputNoise);
				xml.SetAttributeValue("adjustmentValueInner", _adjustmentValueInner);
				xml.SetAttributeValue("adjustmentValueOuter", _adjustmentValueOuter);
				xml.SetAttributeValue("adjustmentValueInnerAngle", _adjustmentValueInnerAngle);
				xml.SetAttributeValue("adjustmentValueOuterAngle", _adjustmentValueOuterAngle);
				xml.SetAttributeValue("noiseFadeInner", _noiseFadeInner);
				xml.SetAttributeValue("noiseFadeOuter", _noiseFadeOuter);
				xml.SetAttributeValue("noiseFadeInnerAngle", _noiseFadeInnerAngle);
				xml.SetAttributeValue("noiseFadeOuterAngle", _noiseFadeOuterAngle);
				xml.SetAttributeValue("linearRemapMaxClamped", _linearRemapMaxClamped);
				xml.SetAttributeValue("linearRemapMax", _linearRemapMax);
				xml.SetAttributeValue("linearRemapMin", _linearRemapMin);
				return xml;
			}
		}

		[SerializeField]
		[Range(0f, 9f)]
		[DataSlot(DataSlotType.Output, "Output", false, true, Order = 2, Tooltip = "The output data value that represents the polar caps. The north pole mask is from zero to 1 and the south pole mask is from 0 to -1.")]
		private int _dataIndexOutput;

		private bool _hasRotation;

		[SerializeField]
		[InspectorProperty(null, false, Order = 10)]
		private Config _northPole;

		[SerializeField]
		[InspectorProperty(null, false, Label = "Rotation", Order = 5, Tooltip = "The rotation in degrees about the X, Y, and Z axis to be applied to the input position.")]
		private Vector3 _rotation = Vector3.zero;

		private Quaterniond _rotationQuaternion;

		[SerializeField]
		[InspectorProperty(null, false, Order = 20)]
		private Config _southPole;

		public override VertexDataType VertexDataType => VertexDataType.Both;

		public void GetDataSlots(List<DataSlotField> dataSlots)
		{
			FieldInfo field = Utilities.GetField(() => _dataIndexOutput);
			dataSlots.Add(new DataSlotField(this, field.GetCustomAttribute<DataSlotAttribute>(), field));
			_northPole.GetDataSlots(dataSlots, "North Pole");
			_southPole.GetDataSlots(dataSlots, "South Pole");
		}

		public override void GetVertexData(PlanetVertexDataInput input, PlanetVertexData data)
		{
			double num = (_hasRotation ? (_rotationQuaternion * input.Position).y : input.Position.y);
			data.Data[_dataIndexOutput] = ((num >= 0.0) ? _northPole.GetResult(num, data.Data) : (0.0 - _southPole.GetResult(num, data.Data)));
		}

		public override void GetVertexData(PlanetVertexDataInput input, PlanetBiomeVertexData data)
		{
			double num = (_hasRotation ? (_rotationQuaternion * input.Position).y : input.Position.y);
			data.Data[_dataIndexOutput] = ((num >= 0.0) ? _northPole.GetResult(num, data.Data) : (0.0 - _southPole.GetResult(num, data.Data)));
		}

		public override void Initialize(IPlanetData planetData)
		{
			base.Initialize(planetData);
			_hasRotation = !Utilities.CompareVector3s(_rotation, Vector3.zero);
			_rotationQuaternion = (_hasRotation ? Quaterniond.Euler(_rotation.x, _rotation.y, _rotation.z) : Quaterniond.identity);
		}

		public override void OnCreatingInPlanetStudio(PlanetTerrainDataScript terrainData, VertexDataPlanetModifier parentModifier)
		{
			base.OnCreatingInPlanetStudio(terrainData, parentModifier);
			_northPole = new Config();
			_southPole = new Config();
		}

		public override void SaveXml(XElement xml)
		{
			base.SaveXml(xml);
			xml.SetAttributeValue("dataIndexOutput", _dataIndexOutput);
			xml.SetAttribute("rotation", _rotation);
			xml.Add(_southPole.SaveToXml(new XElement("SouthPole")));
			xml.Add(_northPole.SaveToXml(new XElement("NorthPole")));
		}

		protected override void RestoreXml(XElement xml)
		{
			base.RestoreXml(xml);
			_dataIndexOutput = ((int?)xml.Attribute("dataIndexOutput")).GetValueOrDefault();
			_rotation = xml.GetVector3AttributeOrNull("rotation") ?? Vector3.zero;
			_northPole = Config.CreateFromXml(xml.Element("NorthPole"));
			_southPole = Config.CreateFromXml(xml.Element("SouthPole"));
		}
	}
}
