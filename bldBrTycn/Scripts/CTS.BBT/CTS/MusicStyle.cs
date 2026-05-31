using UnityEngine;

namespace CTS
{
	[CreateAssetMenu(fileName = "New MusicStyle", menuName = "Audio/Music Style")]
	public class MusicStyle : ScriptableObject
	{
		public EBarStyle style;

		public MusicLayer[] layers;

		[Tooltip("Critère de recherche des noms d'AudioClip (par exemple : 'MUS_Bar01')")]
		public string filter = "MUS_Bar0";
	}
}
