using UnityEngine;

namespace DV.ThingTypes
{
	[CreateAssetMenu(menuName = "DV/Object Model/Train Car - livery", fileName = "TrainCarLivery_")]
	public class TrainCarLivery : Thing_v2_from_v1_enum<TrainCarType>
	{
		public TrainCarType_v2 parentType;

		public GameObject prefab;

		[Header("Optional")]
		public GameObject interiorPrefab;

		public GameObject explodedInteriorPrefab;

		[Space]
		public GameObject externalInteractablesPrefab;

		public GameObject explodedExternalInteractablesPrefab;

		[Header("Info")]
		public Sprite icon;

		public string localizationKey;

		public GeneralLicenseType_v2 requiredLicense;

		public bool isHidden;

		protected override void PopulateErrors(ErrorPopulator AddError)
		{
			if (string.IsNullOrWhiteSpace(id))
			{
				AddError("id is empty");
			}
			if (v1 == TrainCarType.NotSet)
			{
				AddError("v1 is default");
			}
			if (parentType == null)
			{
				AddError("parentType is null");
			}
			else
			{
				TrainCarType_v2 trainCarType_v = parentType;
				if ((object)trainCarType_v != null && !trainCarType_v.liveries.Contains(this))
				{
					AddError("not in list of liveries of its parent type");
				}
			}
			if (prefab == null)
			{
				AddError("prefab is null");
			}
			else if (prefab.GetComponent("TrainCar") == null)
			{
				AddError("prefab doesn't have a TrainCar component");
			}
			if (icon == null)
			{
				AddError("icon is null");
			}
			if (string.IsNullOrWhiteSpace(localizationKey))
			{
				AddError("localizationKey is empty");
			}
		}
	}
}
