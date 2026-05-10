using CTS.Core;
using UnityEngine;

namespace CTS
{
	[CreateAssetMenu(fileName = "ActorsColorData", menuName = "BBT/Data/ActorsColorData")]
	public class ActorsColorData : ScriptableObject
	{
		[field: SerializeField]
		public SerializableDictionary<EActors, Color> Actors { get; private set; } = new SerializableDictionary<EActors, Color>();
	}
}
