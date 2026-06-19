using UnityEngine;
using UnityEngine.Serialization;

namespace TH20
{
	[CreateAssetMenu(menuName = "TH20/Configs/Siren Character Component", order = 1113)]
	public class SirenCharacterComponentConfig : ScriptableObjectWithID
	{
		[FormerlySerializedAs("Siren")]
		public GameObject SirenPrefab;
	}
}
