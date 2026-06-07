using System.Collections.Generic;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.Loot;

namespace VampireSurvivors.Objects.Characters.Enemies
{
	public class EnemyGemstone : EnemyDiamond
	{
		[SerializeField]
		private GameObject _MeshContainer;

		[SerializeField]
		private List<MeshRenderer> _GemMeshes;

		[SerializeField]
		protected Transform gemTransform;

		[SerializeField]
		protected MeshRenderer gemMesh;

		private static WeightedStore WEIGHTEDSTORE;

		private Tween _angleTween;

		private uint[] _initialTints;

		private TweenerCore<Vector3, Vector3, VectorOptions> _scaleTween;

		private const float MinRotateDuration = 2f;

		private const float MaxRotateDuration = 3f;

		protected override bool UseStandardLootTable => false;

		protected override float InvulDelay => 0f;

		protected override float ItemChance => 0f;

		protected override float Volume_breaking => 0f;

		protected override float Volume_gotHit => 0f;

		protected override SfxType Sfx_breaking => default(SfxType);

		protected override SfxType Sfx_gotHit => default(SfxType);

		protected override bool ChangeFramesOnHit => false;

		protected override bool DoBaseUpdate => false;

		protected override bool IsImmovable => false;

		protected virtual bool IsAxe => false;

		protected virtual bool IsSnake => false;

		protected virtual uint[] TintProgression => null;

		public void InitRotation()
		{
		}

		public void RandomColor()
		{
		}

		public override void InitEnemy(EnemyType enemyType, bool asRemote)
		{
		}

		public override void OnSpawnDone()
		{
		}

		public override void Disappear()
		{
		}

		protected override void ChangeFrame()
		{
		}

		protected override void OnUpdate()
		{
		}

		protected override void CustomLoot()
		{
		}
	}
}
