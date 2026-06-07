using System.Collections.Generic;
using UnityEngine;

namespace Placemaker.Audio
{
	public class ManySoundsManager : MonoBehaviour
	{
		public enum SoundType
		{
			None = 0,
			Prop = 1,
			Plant = 2,
			Tile = 3,
			Propeller = 4,
			ItalianWire = 5,
			Lighthouse = 6,
			BirdAppear = 7,
			BirdTakeoff = 8,
			BirdTakeoff1 = 9,
			Window = 10,
			Debris = 11,
			DebrisSplash = 12,
			Spire = 13
		}

		public struct SingleSound
		{
			public string audioClip;

			public Vector3 pos;
		}

		[SerializeField]
		private WorldMaster master;

		[SerializeField]
		private List<SingleSound> soundQueue;

		private Dictionary<SoundType, ManySound> soundDict;

		private int counter;

		public void PlaySound(SoundType soundType, Vector3 pos, float pitch = 0f, float volume = 1f)
		{
		}

		private void OnEnable()
		{
		}

		public void OnUpdate()
		{
		}
	}
}
