using MalbersAnimations.Scriptables;
using UnityEngine;

namespace MalbersAnimations.Utilities
{
	[AddComponentMenu("Malbers/Utilities/Effects - Audio/Effect By Material")]
	public class EffectByMaterial : MonoBehaviour
	{
		public SurfaceID surface;

		public AudioClipReference sound;

		public GameObjectReference effect;
	}
}
