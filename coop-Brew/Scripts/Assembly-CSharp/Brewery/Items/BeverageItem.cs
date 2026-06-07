using Brewery.Core;
using UnityEngine;

namespace Brewery.Items
{
	public abstract class BeverageItem : BreweryItem
	{
		[Header("Beverage Properties")]
		[SerializeField]
		protected BaseType baseType;

		[SerializeField]
		protected float baseValue;

		[Header("Visual Configuration")]
		[Tooltip("Visual-only prefab for display purposes (NPCs holding drinks, etc). No scripts, just the model.")]
		[SerializeField]
		protected GameObject visualPrefab;

		public BaseType BaseType => default(BaseType);

		public float BaseValue => 0f;

		public GameObject VisualPrefab => null;

		protected virtual void OnEnable()
		{
		}

		public override bool CanBeUsedInStation(StationType stationType)
		{
			return false;
		}
	}
}
