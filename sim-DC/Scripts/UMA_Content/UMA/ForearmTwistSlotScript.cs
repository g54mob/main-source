using UnityEngine;

namespace UMA
{
	public class ForearmTwistSlotScript : MonoBehaviour
	{
		public string LeftHandBoneName;

		public string RightHandBoneName;

		public string LeftForeArmTwistBoneName;

		public string RightForeArmTwistBoneName;

		private static int leftHandHash;

		private static int rightHandHash;

		private static int leftTwistHash;

		private static int rightTwistHash;

		private static bool hashesFound;

		public void OnDnaApplied(UMAData umaData)
		{
		}
	}
}
