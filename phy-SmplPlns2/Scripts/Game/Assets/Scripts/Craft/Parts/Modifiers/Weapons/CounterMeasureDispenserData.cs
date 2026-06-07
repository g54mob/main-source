using System;
using System.Xml.Linq;
using Assets.Scripts.Design.PartProperties.Attributes;
using Assets.Scripts.Design.UI.PartProperties;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers.Weapons
{
	[PartModifierDesignerHeader("Countermeasure Dispenser")]
	public class CounterMeasureDispenserData : PartModifierData, IModifierWithOutputs
	{
		private float _autoDispenseDelay = 1f;

		[DesignerPropertyToggleButton(new string[] { "All", "1", "2", "3", "4", "5", "6", "7", "8" }, Label = "Armed Group", Order = 1, AllowFunkyInput = true)]
		private string _designerActivationGroup = "All";

		[DesignerPropertySlider(MinValue = 5f, MaxValue = 50f, NumberOfSteps = 10, Label = "Launch Force", Order = 15)]
		private float _launchForce = 25f;

		[DesignerPropertyToggleButton(new string[] { }, Label = "Type", Order = 10)]
		private CounterMeasureType _type = CounterMeasureType.Chaff;

		public int ActivationGroup { get; private set; }

		public int Ammo { get; set; }

		public float AutoDispenseDelay => _autoDispenseDelay;

		public float BreakLockChance { get; private set; }

		public CounterMeasureType CountermeasureType => _type;

		public float EvadeLockChance { get; private set; }

		public float LaunchForce => _launchForce;

		public Type ModifierScriptType => typeof(CounterMeasureDispenserScript);

		public CounterMeasureDispenserData(XElement element)
			: base(element)
		{
			ActivationGroup = element.GetIntAttribute("activationGroup");
			EvadeLockChance = element.GetFloatAttribute("evadeLockChance", 0.5f);
			BreakLockChance = element.GetFloatAttribute("breakLockChance", 0.25f);
			_designerActivationGroup = ((ActivationGroup == 0) ? "All" : ActivationGroup.ToString());
			_type = element.GetEnumAttribute("type", _type);
		}

		public override XElement GenerateStateXml()
		{
			XElement xElement = base.GenerateStateXml();
			xElement.Add(new XAttribute("activationGroup", ActivationGroup));
			xElement.Add(new XAttribute("type", _type));
			xElement.Add(new XAttribute("launchForce", _launchForce));
			if (Ammo != 16)
			{
				xElement.Add(new XAttribute("ammo", Ammo));
			}
			if (!Mathf.Approximately(_autoDispenseDelay, 1f))
			{
				xElement.Add(new XAttribute("autoDispenseDelay", _autoDispenseDelay));
			}
			return xElement;
		}

		public override PartModifierScript Initialize(GameObject parentGameObject, PartData.PartCreationInfo partCreationInfo, AircraftScript aircraftScript)
		{
			CounterMeasureDispenserScript counterMeasureDispenserScript = parentGameObject.AddComponent<CounterMeasureDispenserScript>();
			counterMeasureDispenserScript.Initialize(this);
			return counterMeasureDispenserScript;
		}

		public override void OnGenericDesignerPropertiesUpdate(IGenericPartProperties genericPartProperties)
		{
			bool flag = _type == CounterMeasureType.Flares;
			genericPartProperties.SetPropertyStatus("_launchForce", (!flag) ? IGenericPartProperties.PropertyStatus.Hidden : IGenericPartProperties.PropertyStatus.Visible);
		}

		public override void OnGenericDesignerPropertyChanged(string propertyName, string value)
		{
			if (propertyName == "_designerActivationGroup")
			{
				ActivationGroup = ((!(value == "All")) ? int.Parse(value) : 0);
			}
		}

		public override void RestoreFromState(XElement stateElement)
		{
			if (stateElement == null)
			{
				return;
			}
			base.RestoreFromState(stateElement);
			ActivationGroup = stateElement.GetIntAttribute("activationGroup");
			_designerActivationGroup = ((ActivationGroup == 0) ? "All" : ActivationGroup.ToString());
			_launchForce = stateElement.GetFloatAttribute("launchForce", 25f);
			Ammo = stateElement.GetIntAttribute("ammo", 16);
			_autoDispenseDelay = stateElement.GetFloatAttribute("autoDispenseDelay", 1f);
			try
			{
				_type = stateElement.GetEnumAttribute("type", _type);
			}
			catch (Exception)
			{
				_type = CounterMeasureType.None;
			}
		}
	}
}
