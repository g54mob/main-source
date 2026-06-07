using System;
using UnityEngine;

namespace PajamaLlama.Flotsam.Landmarks.Generator
{
	[Serializable]
	public struct LandmarkTilesetPrefab
	{
		public GameObject[] Prefabs;

		public int Width;

		public int Length;

		public GameObject ReturnRandomPrefab()
		{
			return Prefabs[UnityEngine.Random.Range(0, Prefabs.Length)];
		}
	}
}
