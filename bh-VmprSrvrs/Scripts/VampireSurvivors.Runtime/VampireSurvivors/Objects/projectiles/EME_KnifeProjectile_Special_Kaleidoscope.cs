using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class EME_KnifeProjectile_Special_Kaleidoscope : Projectile
	{
		private MultiTargetTween _scaleTween;

		private MultiTargetTween _despawnTween;

		[SerializeField]
		private List<Texture> _textures;

		[SerializeField]
		private MeshRenderer _meshRenderer;

		[SerializeField]
		private SortingGroup meshSortingGroup;

		private static readonly int _texture;

		private static readonly int _AlphaMul;

		protected override void Awake()
		{
		}

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}
	}
}
