using System;
using System.Collections.Generic;
using KitchenData;
using UnityEngine;

namespace Kitchen.Components
{
	[Serializable]
	public struct MusicTrackSet
	{
		public Season Season;

		public RestaurantSetting Setting;

		public bool IsMenuTrack;

		public AudioClip Intro;

		public AudioClip Outro;

		public List<AudioClip> Loops;
	}
}
