using System;
using System.Collections.Generic;
using UnityEngine;

namespace DistantLands.Cozy.Data
{
	[Serializable]
	[CreateAssetMenu(menuName = "Distant Lands/Cozy/ReSound/Track", order = 361)]
	public class ReSoundTrack : ScriptableObject
	{
		public enum ClipType
		{
			singleClip = 0,
			playlist = 1
		}

		[Tooltip("Multiplier for the computational chance that this track will play; 0 being never, and 2 being twice as likely as the average.")]
		[Range(0f, 2f)]
		public float likelihood = 1f;

		public ClipType clipType;

		[Tooltip("Animation curves that increase or decrease weather chance based on time, temprature, etc.")]
		public List<ChanceEffector> chances = new List<ChanceEffector>();

		public AudioClip clip;

		public AudioClip[] playlist;

		[Range(0f, 1f)]
		public float volume = 1f;

		public float GetChance(CozyWeather weather, float inTime)
		{
			float num = likelihood;
			foreach (ChanceEffector chance in chances)
			{
				num *= chance.GetChanceAtTime(weather, inTime);
			}
			if (!(num > 0f))
			{
				return 0f;
			}
			return num;
		}

		public float GetChance(CozyWeather weather)
		{
			float num = likelihood;
			foreach (ChanceEffector chance in chances)
			{
				num *= chance.GetChance(weather);
			}
			if (!(num > 0f))
			{
				return 0f;
			}
			return num;
		}
	}
}
