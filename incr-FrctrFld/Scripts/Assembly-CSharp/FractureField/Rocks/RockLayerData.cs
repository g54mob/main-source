using FractureField.Shared.Enums;
using UnityEngine;

namespace FractureField.Rocks
{
	[CreateAssetMenu(fileName = "RockLayerData", menuName = "ScriptableObjects/RockLayerData")]
	public class RockLayerData : ScriptableObject
	{
		public RockLayerType Type;

		public Sprite RockSprite;

		public Sprite CurrencySprite;

		public float MaxHealth;

		public float Hardness;

		public CurrencyType CurrencyType;

		public float BaseTotalCurrency;

		public float BaseDust;
	}
}
