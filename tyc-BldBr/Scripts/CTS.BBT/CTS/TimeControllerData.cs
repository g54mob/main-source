using CTS.BBT;
using CTS.Core;
using UnityEngine;

namespace CTS
{
	[CreateAssetMenu(fileName = "Time Controller Data", menuName = "BBT/Data/Time Controller Data")]
	public class TimeControllerData : ScriptableObject
	{
		[field: SerializeField]
		public SerializableDictionary<ETimeModes, float> TimeModesScales { get; private set; } = new SerializableDictionary<ETimeModes, float>();
	}
}
