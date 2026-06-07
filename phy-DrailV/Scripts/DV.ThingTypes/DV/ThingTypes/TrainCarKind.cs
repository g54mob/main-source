using UnityEngine;

namespace DV.ThingTypes
{
	[CreateAssetMenu(menuName = "DV/Object Model/Train Car - kind", fileName = "TrainCarKind_")]
	public class TrainCarKind : Thing_v2
	{
		public string localizationKey;

		protected override void PopulateErrors(ErrorPopulator AddError)
		{
			if (string.IsNullOrWhiteSpace(id))
			{
				AddError("id is null");
			}
			if (string.IsNullOrWhiteSpace(localizationKey))
			{
				AddError("localizationKey is empty");
			}
		}
	}
}
