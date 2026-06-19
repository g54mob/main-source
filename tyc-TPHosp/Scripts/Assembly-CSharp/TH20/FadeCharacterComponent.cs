using System;
using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class FadeCharacterComponent : EntityTickComponent
	{
		private float _alpha = 1f;

		private float _startAlpha = 1f;

		private float _endAlpha = 1f;

		private float _fadeTime;

		private float _startTime;

		private float _t;

		private Character _character;

		protected override Type ValidEntityType()
		{
			return typeof(Character);
		}

		internal override void InitializeComponent()
		{
			base.InitializeComponent();
			_character = GetOwner<Character>();
			_character.Visual.FadingModeEnable = true;
			base.Level.StatusIconManager.DestroyStatusIcon(_character);
		}

		public void FadeTo(float alpha, float time)
		{
			_endAlpha = alpha;
			_startAlpha = _alpha;
			_fadeTime = time;
			_startTime = GameTime.time;
		}

		public override void Tick()
		{
			base.Tick();
			_t = Mathf.Clamp((GameTime.time - _startTime) / _fadeTime, 0f, 1f);
			_alpha = Mathf.Lerp(_startAlpha, _endAlpha, _t);
			_character.Visual.SetFadingAlpha(_alpha);
		}
	}
}
