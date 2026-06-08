using System.Collections.Generic;
using KitchenData;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Kitchen.Components
{
	[CreateAssetMenu(fileName = "Music Track", menuName = "Kitchen/Music Track")]
	public class MusicTrack : SerializedScriptableObject
	{
		public Season Season;

		public List<RestaurantSetting> Settings;

		public bool IsMenuTrack;

		public bool IsGameplayTrack = true;

		public AudioClip Intro;

		public AudioClip Outro;

		public List<AudioClip> Loops;
	}
}
