using System;
using System.Collections.Generic;
using System.Xml.Linq;
using Assets.Scripts.Craft.Wings;
using Assets.Scripts.Craft.Wings.ControlSurfaces;
using Assets.Scripts.Craft.Wings.Runtime;
using Assets.Scripts.Design;
using Assets.Scripts.Design.PartProperties.Attributes;
using Assets.Scripts.Design.UI.PartProperties;
using Jundroo.Common.Pool;
using Jundroo.Common.Utils;
using Unity.Mathematics;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers
{
	[PartModifierDesignerHeader("Control Surface")]
	public class ControlSurfacePartData : PartModifierData
	{
		private float3 _centreOfMass;

		private ControlSurface _controlSurface;

		private ControlSurface _dummyControlSurface;

		[SerializeField]
		private float2 _dummyWingOffset;

		[SerializeField]
		private float2 _dummyWingScale;

		[SerializeField]
		private float _dummyWingSpan;

		[DesignerPropertyButton(Label = "Edit Shape", Style = ButtonStyle.Primary, Order = 0)]
		private bool _editShape;

		[SerializeField]
		private bool _isFlipped;

		private float _mass;

		public override bool AllowTransformation => base.Part.PartConnections.Count == 0;

		public override Vector3 CoM => _centreOfMass;

		public ControlSurface ControlSurface => _controlSurface;

		public ControlSurface DummyControlSurface => _dummyControlSurface;

		public float2 DummyWingOffset => _dummyWingOffset;

		public float2 DummyWingScale => _dummyWingScale;

		public float DummyWingSpan => _dummyWingSpan;

		public bool IsFlipped => _isFlipped;

		public override float Mass => _mass * 0.01f;

		public string Style { get; }

		public event Action<ControlSurfacePartData> OnDataChanged;

		public ControlSurfacePartData(XElement element)
			: base(element)
		{
			Style = element.GetStringAttribute("style");
			_controlSurface = ControlSurface.GetStyle(Style);
			_dummyControlSurface = ControlSurface.GetStyle(Style);
		}

		public override XElement GenerateStateXml()
		{
			XElement xElement = base.GenerateStateXml();
			_controlSurface.SaveToXml(xElement);
			if (_isFlipped)
			{
				xElement.Add(new XAttribute("dummyPartFlipped", _isFlipped));
			}
			JWingData firstConnectedWing = GetFirstConnectedWing();
			if (firstConnectedWing != null)
			{
				UpdateDummyWingParams(firstConnectedWing);
			}
			xElement.SetAttribute("dummyWingOffset", _dummyWingOffset);
			xElement.SetAttribute("dummyWingScale", _dummyWingScale);
			return xElement;
		}

		public JWingData GetFirstConnectedWing()
		{
			foreach (PartConnection partConnection in base.Part.PartConnections)
			{
				JWingData modifier = partConnection.GetOtherPart(base.Part).GetModifier<JWingData>();
				if (modifier != null)
				{
					return modifier;
				}
			}
			return null;
		}

		public override PartModifierScript Initialize(GameObject parentGameObject, PartData.PartCreationInfo partCreationInfo, AircraftScript aircraftScript)
		{
			ControlSurfacePartScript controlSurfacePartScript = parentGameObject.AddComponent<ControlSurfacePartScript>();
			controlSurfacePartScript.InitStyle(Style);
			return controlSurfacePartScript;
		}

		public override void OnGenericDesignerPropertyButtonClicked(IConfigurableProperty property)
		{
			base.OnGenericDesignerPropertyButtonClicked(property);
			if (property.Member.Name == "_editShape")
			{
				_ = Designer.Instance.DesignerScript.DesignerUI;
				Designer.Instance.Tools.SelectJWingAdjustmentTool();
			}
		}

		public void ResetToDummyCS()
		{
			_dummyControlSurface.CopySettingsTo(_controlSurface);
		}

		public override void RestoreFromState(XElement stateElement)
		{
			base.RestoreFromState(stateElement);
			_isFlipped = stateElement.GetBoolAttribute("dummyPartFlipped");
			_dummyWingOffset = stateElement.GetVector2Attribute("dummyWingOffset");
			_dummyWingScale = stateElement.GetVector2Attribute("dummyWingScale", Vector2.one);
			_controlSurface.Init(stateElement);
			_dummyWingSpan = _controlSurface.Range.y - _controlSurface.Range.x;
			_controlSurface.CopySettingsTo(_dummyControlSurface);
		}

		public void SetMassDefault()
		{
			_mass = 0f;
			_centreOfMass = default(float3);
		}

		public void SetMassProperties(Span<MassPropertiesOutput> massOut, Pose surfaceFromWing)
		{
			float3 float5 = 0f;
			float num = 0f;
			for (int i = 0; i < massOut.Length; i++)
			{
				MassPropertiesOutput massPropertiesOutput = massOut[i];
				num += massPropertiesOutput.Mass;
				float5 += num * massPropertiesOutput.CentreOfMass;
			}
			if (!(num <= 0f) && !float.IsNaN(num))
			{
				_mass = num;
				_centreOfMass = surfaceFromWing.TransformPoint(float5 / num);
			}
		}

		public void SynchronizeSymmetricParts(bool updateMeshes)
		{
			List<PartData> value;
			using (CollectionPool<List<PartData>, PartData>.Get(out value))
			{
				base.Part.PartScript.Aircraft.Aircraft.Assembly.GetOtherSymmetricParts(base.Part, value);
				bool isFlipped = ((value.Count == 1) ? (!_isFlipped) : _isFlipped);
				foreach (PartData item in value)
				{
					ControlSurfacePartData modifier = item.GetModifier<ControlSurfacePartData>();
					if (modifier == null)
					{
						Debug.LogError($"Control surface modifier not found on symmetric part {item.Id}");
						continue;
					}
					modifier._isFlipped = isFlipped;
					modifier._dummyWingOffset = _dummyWingOffset;
					modifier._dummyWingScale = _dummyWingScale;
					modifier._dummyWingSpan = _dummyWingSpan;
					_controlSurface.CopySettingsTo(modifier.ControlSurface);
					_dummyControlSurface.CopySettingsTo(modifier._dummyControlSurface);
					if (updateMeshes)
					{
						modifier.UpdateMeshes(updateSymmetricParts: false);
					}
				}
			}
		}

		public void UpdateDummyWingParams(JWingData wing)
		{
			if (wing != null)
			{
				float2 range = ControlSurface.Range;
				(float Offset, float Scale) interpolatedSlice = WingBuilder.GetInterpolatedSlice(range.x, wing.WingSlices);
				float item = interpolatedSlice.Offset;
				float item2 = interpolatedSlice.Scale;
				(float Offset, float Scale) interpolatedSlice2 = WingBuilder.GetInterpolatedSlice(range.y, wing.WingSlices);
				float item3 = interpolatedSlice2.Offset;
				float item4 = interpolatedSlice2.Scale;
				_dummyWingOffset = new float2(item, item3);
				_dummyWingScale = new float2(item2, item4);
				_dummyWingSpan = range.y - range.x;
				_isFlipped = wing.Flipped;
			}
			else
			{
				_dummyWingOffset = 0f;
				_dummyWingScale = 1f;
				_dummyWingSpan = 2f;
			}
			_controlSurface.CopySettingsTo(_dummyControlSurface);
		}

		public void UpdateMeshes(bool updateSymmetricParts = true)
		{
			this.OnDataChanged?.Invoke(this);
			if (updateSymmetricParts)
			{
				SynchronizeSymmetricParts(updateMeshes: true);
			}
		}

		protected override float CalculateMass()
		{
			return Mass;
		}
	}
}
