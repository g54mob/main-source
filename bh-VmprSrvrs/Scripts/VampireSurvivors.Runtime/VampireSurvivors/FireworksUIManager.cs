using System.Collections.Generic;
using UnityEngine;
using VampireSurvivors.Framework.Particles;
using Zenject;

namespace VampireSurvivors
{
	public class FireworksUIManager : MonoBehaviour
	{
		[SerializeField]
		private ParticleEmitterManager _Fireworks;

		[SerializeField]
		private RectTransform _ScreenRect;

		[SerializeField]
		private RectTransform _Target;

		private SignalBus _signalBus;

		private static FireworksUIManager Instance;

		private List<ParticleSystem> _particles;

		private GravityWell _well;

		[Inject]
		private void Construct(SignalBus signalBus)
		{
		}

		private void Awake()
		{
		}

		private void Test()
		{
		}

		private void PlayFirework(Vector2 screenPos, List<string> frames, int i, Transform parent)
		{
		}

		public static void AddGravityWell(GravityWellConfig conf, Vector3 pos, Transform parent)
		{
		}

		public static Vector2 GetPositionFromCanvas(Vector3 position)
		{
			return default(Vector2);
		}
	}
}
