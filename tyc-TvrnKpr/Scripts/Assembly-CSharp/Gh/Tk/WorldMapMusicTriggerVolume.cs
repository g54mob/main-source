using System.Collections.Generic;
using UnityEngine;

namespace Gh.Tk
{
	public class WorldMapMusicTriggerVolume : MonoBehaviour
	{
		public static List<WorldMapMusicTriggerVolume> AllVolumes;

		[DropDownChoice(typeof(Music.WorldMapMusicVariant), "GetAllVariants")]
		public string musicVariant;

		private void Awake()
		{
		}

		private void OnDestroy()
		{
		}
	}
}
