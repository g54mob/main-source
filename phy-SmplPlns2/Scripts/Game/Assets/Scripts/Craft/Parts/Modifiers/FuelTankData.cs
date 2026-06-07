using System.Xml.Linq;
using Assets.Scripts.Design.PartProperties.Attributes;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers
{
	[PartModifierDesignerHeader("Fuel Tank")]
	public class FuelTankData : PartModifierData
	{
		private float _fuel;

		public float Capacity { get; set; }

		public float Fuel
		{
			get
			{
				return _fuel;
			}
			set
			{
				_fuel = value;
				RecalculateMass(recalculatePartMass: true);
			}
		}

		public override float Mass => base.Mass;

		public FuelTankData(XElement element)
			: base(element)
		{
			Capacity = float.Parse(element.Attribute("capacity").Value);
			Fuel = element.GetFloatAttribute("fuel", Capacity);
		}

		public override XElement GenerateStateXml()
		{
			XElement xElement = base.GenerateStateXml();
			xElement.Add(new XAttribute("fuel", Fuel));
			xElement.Add(new XAttribute("capacity", Capacity));
			return xElement;
		}

		public override PartModifierScript Initialize(GameObject parentGameObject, PartData.PartCreationInfo partCreationInfo, AircraftScript aircraftScript)
		{
			GameObject gameObject = new GameObject("FuelTank");
			gameObject.transform.parent = parentGameObject.transform;
			gameObject.transform.localPosition = default(Vector3);
			gameObject.transform.localRotation = Quaternion.identity;
			gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
			FuelTankScript fuelTankScript = gameObject.AddComponent<FuelTankScript>();
			fuelTankScript.FuelTank = this;
			return fuelTankScript;
		}

		public override void RestoreFromState(XElement stateElement)
		{
			base.RestoreFromState(stateElement);
			Capacity = float.Parse(stateElement.Attribute("capacity").Value);
			Fuel = ((float?)stateElement.Attribute("fuel")) ?? Capacity;
		}

		protected override float CalculateMass()
		{
			return Fuel * 0.804f * 0.01f;
		}
	}
}
