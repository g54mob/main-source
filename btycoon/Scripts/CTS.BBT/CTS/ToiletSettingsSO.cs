using UnityEngine;

namespace CTS
{
	[CreateAssetMenu(fileName = "New Toilet Settings", menuName = "BBT/New Toilet Settings", order = 0)]
	public class ToiletSettingsSO : ScriptableObject
	{
		[SerializeField]
		public float executionDuration;
	}
}
