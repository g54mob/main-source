using System;
using QFSW.MOP2;
using UnityEngine;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;

namespace VampireSurvivors.Objects.VFX
{
	public class KarmaCoinVFX : PoolableMonoBehaviour
	{
		[SerializeField]
		private float AngelStartSize;

		[SerializeField]
		private float KarmaCoinDamageDelay;

		public MeshRenderer AngelRenderer;

		public ParticleSystem AngelFeathersFX;

		[SerializeField]
		private float AngelFeathersFXDelay;

		public ParticleSystem HeadsFX;

		public ParticleSystem TailsFX;

		public ParticleSystem FlareFX;

		[SerializeField]
		private float HoldTime;

		private Timer _holdTimer;

		private Timer _karmaTimer;

		private Timer _featherDelayTimer;

		private MultiTargetTween _tweenMaterialAnim;

		private MultiTargetTween _tweenScale;

		public float _animT;

		private Action _callback;

		public void PlaySequence(Action action, float pLuck)
		{
		}

		protected override void OnDestroy()
		{
		}
	}
}
