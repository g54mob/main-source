using System;
using UnityEngine;

namespace PajamaLlama.Flotsam.World
{
	[Serializable]
	internal class LandmarkBehaviourDistributer
	{
		[Flags]
		public enum Sizes
		{
			None = 0,
			Small = 0x20,
			Medium = 0x400,
			Large = 0x8000
		}

		[SerializeField]
		private Sizes _size;

		public Sizes Size => _size;
	}
}
