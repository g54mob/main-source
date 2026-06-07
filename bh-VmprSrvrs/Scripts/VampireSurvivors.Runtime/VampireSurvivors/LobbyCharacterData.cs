using Coherence.Connection;
using Coherence.Toolkit;
using UnityEngine;

namespace VampireSurvivors
{
	public class LobbyCharacterData : MonoBehaviour
	{
		public static LobbyCharacterData Instance { get; private set; }

		[Sync]
		public int RnjNameIndex { get; set; }

		[Sync]
		public string RnjSpriteName { get; set; }

		[Sync]
		public int RnjStartingWeapon { get; set; }

		[Sync]
		public uint MissingNoSeed { get; set; }

		private void Awake()
		{
		}

		private void OnDestroy()
		{
		}

		private void OnDisconnected(CoherenceBridge _, ConnectionCloseReason __)
		{
		}
	}
}
