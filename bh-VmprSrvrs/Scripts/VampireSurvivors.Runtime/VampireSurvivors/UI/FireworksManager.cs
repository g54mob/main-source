using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using VampireSurvivors.Framework.Particles;

namespace VampireSurvivors.UI
{
	public class FireworksManager : MonoBehaviour
	{
		[SerializeField]
		private Camera _RenderCam;

		[SerializeField]
		private RawImage _RenderImage;

		[SerializeField]
		private RectTransform _CanvasRect;

		private ParticleEmitterManager _particles;

		private List<ParticleSystem> _fwEmitters;

		private GravityWell _well;

		private float _viewportMin;

		private float _viewPortMax;

		private float _viewportScale;

		private int index;

		private static FireworksManager Instance;

		private List<GravityWell> _wells;

		private List<ParticleSystem> _particleSpawned;

		private RenderTexture _currentRT;

		private void Awake()
		{
		}

		private void Start()
		{
		}

		public static ParticleSystem CreateRandomFirework(int _index, List<string> frames, RectTransform _origin, float scale = 1f)
		{
			return null;
		}

		public static ParticleSystem CreateFireworkAtPosition(int _index, List<string> frames, Vector2 viewportPos, float scale = 1f)
		{
			return null;
		}

		private void SpawnFirework()
		{
		}

		private float GetRTScale()
		{
			return 0f;
		}

		private ParticleSystem MakeFireworkAtPosition(int _index, List<string> frames, Vector2 viewportPos, float scale = 1f)
		{
			return null;
		}

		private ParticleSystem MakeRandomFirework(int _index, List<string> frames, RectTransform _origin, float scale = 1f)
		{
			return null;
		}

		public static GravityWell CreateGravityWell(Vector2 viewportPosition, GravityWellConfig conf = null)
		{
			return null;
		}

		private GravityWell SpawnGravityWell(Vector2 viewportPosition, GravityWellConfig conf = null)
		{
			return null;
		}

		public static void Clear()
		{
		}

		public static Vector2 GetViewportPosition(RectTransform rTrans)
		{
			return default(Vector2);
		}
	}
}
