using System.Xml.Linq;
using Assets.Scripts.Design.PartProperties.Attributes;
using Assets.Scripts.Design.UI.PartProperties;
using Jundroo.Common.Extensions;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers.Character
{
	[PartModifierDesignerHeader("IK Target")]
	public class IKTargetData : PartModifierData
	{
		private Vector3 _offset = Vector3.zero;

		private float _positionWeight = 1f;

		[DesignerPropertySpinner(0f, 10000f, 1f, AllowManualEntry = true, Label = "Priority", Order = 6, Tooltip = "Used when automatically assigning IK targets, lower numbers are higher priority.")]
		private int _priority = 10;

		private float _rotationWeight = 1f;

		private bool? _useThighs;

		private bool? _useThighsPartType;

		public Vector3 Offset => _offset;

		public string Path { get; set; }

		public float PositionWeight
		{
			get
			{
				return _positionWeight;
			}
			set
			{
				_positionWeight = Mathf.Clamp01(value);
			}
		}

		public int Priority => _priority;

		public float RotationWeight
		{
			get
			{
				return _rotationWeight;
			}
			set
			{
				_rotationWeight = Mathf.Clamp01(value);
			}
		}

		public IKTargetScript Script { get; private set; }

		public IKTargetType Type { get; set; }

		public bool? UseThighs => _useThighs;

		public IKTargetData(XElement element)
			: base(element)
		{
			Path = element.GetStringAttribute("path");
			Type = element.GetEnumAttribute("type", IKTargetType.Body);
			_priority = element.GetIntAttribute("priority", 10);
			_offset = element.GetVector3Attribute("offset", _offset);
			_useThighs = element.GetBoolAttributeOrNull("useThighs");
			_useThighsPartType = _useThighs;
		}

		public override XElement GenerateStateXml()
		{
			XElement xElement = base.GenerateStateXml();
			xElement.Add(new XAttribute("path", Path));
			xElement.Add(new XAttribute("type", Type.ToString()));
			xElement.Add(new XAttribute("priority", _priority));
			if (PositionWeight != 1f)
			{
				xElement.Add(new XAttribute("positionWeight", PositionWeight));
			}
			if (RotationWeight != 1f)
			{
				xElement.Add(new XAttribute("rotationWeight", RotationWeight));
			}
			if (_useThighs.HasValue && _useThighs != _useThighsPartType)
			{
				xElement.Add(new XAttribute("useThighs", _useThighs.Value));
			}
			if (Vector3.Distance(Vector3.zero, _offset) > 1E-05f)
			{
				xElement.Add(new XAttribute("offset", _offset.ToXAttributeValue()));
			}
			return xElement;
		}

		public override PartModifierScript Initialize(GameObject parentGameObject, PartData.PartCreationInfo partCreationInfo, AircraftScript aircraftScript)
		{
			Transform transform = parentGameObject.transform.Find(Path);
			if (transform == null)
			{
				Debug.LogError($"Part-{base.Part.Id} IKTargetData-{Type} target not found at path {Path}.");
				return null;
			}
			transform.localPosition += _offset;
			IKTargetScript iKTargetScript = (Script = transform.gameObject.AddComponent<IKTargetScript>());
			iKTargetScript.Initialize(this);
			return iKTargetScript;
		}

		public override void OnGenericDesignerPropertiesVisible(IGenericPartProperties genericPartPropertiesScript)
		{
			genericPartPropertiesScript.SetModifierHeaderText(Type.DisplayName() + " Target");
		}

		public override void RestoreFromState(XElement stateElement)
		{
			base.RestoreFromState(stateElement);
			Path = stateElement.GetStringAttribute("path");
			Type = stateElement.GetEnumAttribute("type", IKTargetType.Body);
			_priority = stateElement.GetIntAttribute("priority", _priority);
			PositionWeight = stateElement.GetFloatAttribute("positionWeight", 1f);
			RotationWeight = stateElement.GetFloatAttribute("rotationWeight", 1f);
			_offset = stateElement.GetVector3Attribute("offset", _offset);
			_useThighs = stateElement.GetBoolAttributeOrNull("useThighs") ?? _useThighs;
		}
	}
}
