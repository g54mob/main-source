using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace VampireSurvivors
{
	public class TreasureFireworksManager : MonoBehaviour
	{
		[SerializeField]
		private GameObject _ParticlePrefab;

		[SerializeField]
		private Material _BaseParticleMaterial;

		[SerializeField]
		private List<Sprite> _Sprites;

		[SerializeField]
		private Image _WhiteBackground;

		[SerializeField]
		private float _MaxOffsetX;

		[SerializeField]
		private float _MaxOffsetY;

		[SerializeField]
		private ParticleSystemForceField _ForceField;

		[SerializeField]
		private GameObject _FireworksRenderTextureView;

		private List<KeyValuePair<ParticleSystem, int>> _fireworks;

		private List<Material> _materials;

		private void Start()
		{
		}

		public void PlayFireWorks()
		{
		}

		public int OrderInLayer()
		{
			return 0;
		}

		public void OrderInLayer(int newLayer)
		{
		}

		private void DoFlash()
		{
		}
	}
}
