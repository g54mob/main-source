using System;
using MalbersAnimations.Scriptables;

namespace MalbersAnimations
{
	[Serializable]
	public class EffectType
	{
		public SurfaceID surface;

		public AudioClipReference sound;

		public GameObjectReference effect;
	}
}
