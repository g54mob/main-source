using UnityEngine;

namespace DV.ThingTypes
{
	[CreateAssetMenu(menuName = "DV/Object Model/Resource", fileName = "Resource_")]
	public class ResourceType_v2 : Thing_v2_from_v1_enum<ResourceType>
	{
		public string localizationKeyFull;

		public string localizationKeyShort;

		public Sprite resourceIcon;

		public bool isTaxable;

		public bool isConsumable;

		public bool canBeDamaged;

		public bool canDamageEnvironment;

		public float price;

		protected override void PopulateErrors(ErrorPopulator AddError)
		{
			if (string.IsNullOrWhiteSpace(id))
			{
				AddError("id is empty");
			}
			if (v1 == (ResourceType)0)
			{
				AddError("v1 is default");
			}
			if (string.IsNullOrWhiteSpace(localizationKeyFull))
			{
				AddError("localizationKeyFull is empty");
			}
			if (resourceIcon == null)
			{
				AddError("resourceIcon is null");
			}
			if (price <= 0f)
			{
				AddError("price is not set");
			}
		}
	}
}
