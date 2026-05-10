using UnityEngine;

namespace CTS
{
	[CreateAssetMenu(fileName = "PowerFeatureTable", menuName = "Worker/PowerFeatureTable")]
	public class PowerFeatureTable : ScriptableObject
	{
		[field: SerializeField]
		public PowerFeatureElement[] powerFeatureElements { get; private set; }

		public PowerFeatureElement? GetElement(WorkerPowerFeature.e_PowerFeatures p_feature)
		{
			for (int i = 0; i < powerFeatureElements.Length; i++)
			{
				if (powerFeatureElements[i].PowerFeatureID == p_feature)
				{
					return powerFeatureElements[i];
				}
			}
			return null;
		}
	}
}
