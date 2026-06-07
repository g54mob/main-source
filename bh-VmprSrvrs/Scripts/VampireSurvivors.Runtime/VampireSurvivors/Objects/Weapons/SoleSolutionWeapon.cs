using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Objects.Characters;

namespace VampireSurvivors.Objects.Weapons
{
	[DefaultExecutionOrder(860)]
	public class SoleSolutionWeapon : Weapon
	{
		[SerializeField]
		private Mesh _quadMesh;

		[SerializeField]
		private RenderTexture _renderTexture;

		[SerializeField]
		private MeshRenderer _galaxyMesh;

		[SerializeField]
		private MeshRenderer _blitRenderer;

		public float _LayersAlpha;

		public float _GalaxyAlpha;

		public float _GalaxyScale;

		public float _GalaxyForce;

		private List<Tilemap> _layers;

		private bool _canFire;

		private bool _initialised;

		private SpriteRenderer _background;

		private Material _galaxyRTMaterial;

		private bool _particlesGenerated;

		private ParticleEmitterManager _particlesManager;

		private ParticleSystem _pfxEmitter;

		private GravityWell _well;

		private Camera _mainCam;

		private bool _canFadeTilemaps;

		private void LateUpdate()
		{
		}

		public override float PInterval()
		{
			return 0f;
		}

		public override void OnWeaponAdded()
		{
		}

		public override float PPower()
		{
			return 0f;
		}

		public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
		{
		}

		private void KillTilemapFade()
		{
		}

		protected override void OnDestroy()
		{
		}

		public override void ParadoxFire()
		{
		}

		public override void Fire(bool skipTriggers = false)
		{
		}

		protected override void OnPause()
		{
		}

		protected override void OnResume()
		{
		}

		protected override void MakeLevelOne()
		{
		}

		private void GenerateParticleSystems()
		{
		}

		private void InitialiseRT()
		{
		}

		private void FadeOutLayers()
		{
		}

		private void RestoreLayers()
		{
		}

		private void SetLayersAlpha(float alpha)
		{
		}

		private void Motion1()
		{
		}

		private void Motion2()
		{
		}

		private void UpdateGalaxy()
		{
		}
	}
}
