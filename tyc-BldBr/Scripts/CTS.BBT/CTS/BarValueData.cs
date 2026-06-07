using UnityEngine;

namespace CTS
{
	[CreateAssetMenu(fileName = "BarValueData", menuName = "BBT/Settings/BarValueData")]
	public class BarValueData : ScriptableObject
	{
		[field: SerializeField]
		public float ValuePerSquareMeter { get; private set; } = 10f;
	}
}
