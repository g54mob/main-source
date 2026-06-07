using System.Reflection;
using System.Xml.Linq;
using Assets.Scripts.Design.PartProperties.Attributes;
using Jundroo.Common.Utils;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers
{
	[Obfuscation(Exclude = true)]
	[PartModifierDesignerHeader("Winch")]
	public class WinchData : PartModifierData
	{
		public const float BaseRange = 20f;

		public const float BaseSpeed = 1f;

		private float _breakScale = 1f;

		[DesignerPropertySlider(0.1f, 2.5f, 25, Label = "Max Range", Order = 1)]
		private float _range;

		private WinchScript _script;

		[DesignerPropertySlider(0.1f, 2.5f, 25, Label = "Speed", Order = 3)]
		private float _speed;

		[DesignerPropertySlider(0f, 1f, 21, Label = "Start Range", Order = 2)]
		private float _startRange;

		private float _volume = 1f;

		public int AttachPointIndex { get; private set; }

		public float BreakScale => _breakScale;

		public float MinRange => 0.1f + _startRange * (Range - 0.1f);

		public float Range => _range * 20f;

		public float Speed => _speed * 1f;

		public float StartRange => _startRange;

		public float Volume => _volume;

		public WinchData(XElement element)
			: base(element)
		{
			AttachPointIndex = element.GetIntAttribute("attachPoint");
		}

		public override XElement GenerateStateXml()
		{
			XElement xElement = base.GenerateStateXml();
			xElement.Add(new XAttribute("startRange", _startRange.ToString()), new XAttribute("range", _range.ToString()), new XAttribute("volume", _volume.ToString()), new XAttribute("speed", _speed.ToString()));
			if (_breakScale != 1f)
			{
				xElement.Add(new XAttribute("breakScale", _breakScale));
			}
			return xElement;
		}

		public override string GetGenericDesignerPropertySliderValueLabel(string propertyName, float sliderValue)
		{
			switch (propertyName)
			{
			case "_startRange":
			case "_range":
			case "_speed":
				return Utilities.FormatPercentage(sliderValue);
			default:
				return base.GetGenericDesignerPropertySliderValueLabel(propertyName, sliderValue);
			}
		}

		public override PartModifierScript Initialize(GameObject parentGameObject, PartData.PartCreationInfo partCreationInfo, AircraftScript aircraftScript)
		{
			GameObject gameObject = new GameObject("Winch");
			gameObject.transform.parent = parentGameObject.transform;
			gameObject.transform.localPosition = default(Vector3);
			gameObject.transform.localRotation = Quaternion.identity;
			gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
			WinchScript winchScript = gameObject.AddComponent<WinchScript>();
			winchScript.Winch = this;
			_script = winchScript;
			return winchScript;
		}

		public override void OnGenericDesignerPropertyChanged(string propertyName, string value)
		{
			base.OnGenericDesignerPropertyChanged(propertyName, value);
			if (propertyName == "_startRange" || propertyName == "_range")
			{
				UpdateAttachPoint();
			}
		}

		public override void RestoreFromState(XElement stateElement)
		{
			base.RestoreFromState(stateElement);
			_range = stateElement.GetFloatAttribute("range", 1f);
			_startRange = stateElement.GetFloatAttribute("startRange");
			_speed = stateElement.GetFloatAttribute("speed", 1f);
			_volume = stateElement.GetFloatAttribute("volume", 1f);
			_breakScale = stateElement.GetFloatAttribute("breakScale", 1f);
			UpdateAttachPoint();
		}

		private void UpdateAttachPoint()
		{
			if (AttachPointIndex < base.Part.AttachPoints.Count)
			{
				AttachPointData attachPointData = base.Part.AttachPoints[AttachPointIndex];
				attachPointData.Position = new Vector3(0f, attachPointData.JointPosition.Value.y + MinRange, 0f);
				_script?.OnAttachPointMoved(attachPointData);
			}
		}
	}
}
