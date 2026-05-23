using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Rendering;

namespace Battle
{
	public class LastStageGimmick : BaseStageGimmick
	{
		[SerializeField]
		private List<SimpleAnimation> cystals;

		[SerializeField]
		private SpriteRenderer wall;

		[SerializeField]
		private float zoomOutLensGoalDuration;

		[SerializeField]
		private float zoomOutLensReturnDuration;

		[SerializeField]
		private SkeletonAnimationController avatorSpine;

		[SerializeField]
		private LoopEffect fog;

		[SerializeField]
		private GameObject lastLoadLayout;

		[SerializeField]
		private GameObject lastBattleLayout;

		[SerializeField]
		private ParticleSystem[] batsEffect;

		[SerializeField]
		private float interval;

		private double _effectTimer;

		private void Update()
		{
		}

		public override SortingGroup[] GetDecorationPoints()
		{
			return null;
		}

		public override void SetFirstGimmick()
		{
		}

		public override Sequence PlayBattleGimmick()
		{
			return null;
		}

		public override Sequence PreMoveBossBattleGimmick()
		{
			return null;
		}

		public override Sequence PlayBossBattleGimmick()
		{
			return null;
		}

		public Sequence EndingExitDecorations()
		{
			return null;
		}

		private void PlayMoveCystal()
		{
		}
	}
}
