using System;
using System.Collections.Generic;
using System.Reflection;
using System.Xml.Linq;
using ModApi.Planet.CustomData;
using ModApi.Ui.Inspector;
using UnityEngine;

namespace ModApi.Planet.Modifiers.VertexData.CustomData
{
	public abstract class UpdateCustomData<T> : VertexDataCommonPassPlanetModifier, ICustomInspectorFields where T : CustomPlanetVertexData
	{
		[SerializeField]
		[InspectorProperty(null, false, Label = "Data Id", Order = 0, Tooltip = "The ID of the custom data to be updated.")]
		private string _customDataId;

		private int _customDataIndex = -1;

		public override VertexDataType VertexDataType => VertexDataType.Both;

		public virtual List<FieldInfo> GetInspectorFields()
		{
			return new List<FieldInfo> { typeof(UpdateCustomData<T>).GetField("_customDataId", BindingFlags.Instance | BindingFlags.NonPublic) };
		}

		public override void GetVertexData(PlanetVertexDataInput input, PlanetVertexData data)
		{
			T customData = (T)data.CustomData[_customDataIndex];
			GetVertexData(data.Data, customData);
		}

		public override void GetVertexData(PlanetVertexDataInput input, PlanetBiomeVertexData data)
		{
			T customData = (T)data.CustomData[_customDataIndex];
			GetVertexData(data.Data, customData);
		}

		public override void Initialize(IPlanetData planetData)
		{
			base.Initialize(planetData);
			if (IsSupported())
			{
				_customDataIndex = CustomPlanetVertexData.GetIndex(_customDataId);
				if (_customDataIndex < 0)
				{
					throw new Exception("Unable to find the custom planet vertex data with the specified id: " + (_customDataId ?? "null"));
				}
			}
		}

		public override bool IsSupported()
		{
			if (!string.IsNullOrWhiteSpace(_customDataId))
			{
				return CustomPlanetVertexData.IsRegistered(_customDataId);
			}
			return false;
		}

		public override void SaveXml(XElement xml)
		{
			base.SaveXml(xml);
			xml.SetAttributeValue("customDataId", _customDataId);
		}

		protected abstract void GetVertexData(double[] data, T customData);

		protected override void RestoreXml(XElement xml)
		{
			base.RestoreXml(xml);
			_customDataId = (string)xml.Attribute("customDataId");
		}
	}
}
