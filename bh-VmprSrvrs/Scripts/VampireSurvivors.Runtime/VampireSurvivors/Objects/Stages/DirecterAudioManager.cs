using System.Collections.Generic;
using UnityEngine;
using VampireSurvivors.Data;

namespace VampireSurvivors.Objects.Stages
{
	public class DirecterAudioManager : MonoBehaviour
	{
		public Dictionary<BgmType, AudioClip> _clips;

		public void GetAudioClips()
		{
		}

		public AudioSource Add(BgmType phase)
		{
			return null;
		}
	}
}
