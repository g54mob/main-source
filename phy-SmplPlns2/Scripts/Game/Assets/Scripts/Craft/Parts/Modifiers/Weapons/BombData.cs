using System;
using System.Xml.Linq;
using Assets.Scripts.Design.PartProperties.Attributes;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers.Weapons
{
	[PartModifierDesignerHeader("Bomb")]
	public class BombData : ExplosiveWeaponBaseData, IModifierWithOutputs
	{
		public Type ModifierScriptType => typeof(BombScript);

		protected override float DefaultFiringDelay => 1f;

		public BombData(XElement element)
			: base(element)
		{
		}

		public override PartModifierScript Initialize(GameObject parentGameObject, PartData.PartCreationInfo partCreationInfo, AircraftScript aircraftScript)
		{
			return parentGameObject.AddComponent<BombScript>();
		}
	}
}
