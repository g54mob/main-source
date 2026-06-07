using System;
using DG.Tweening;
using VampireSurvivors.Data.Characters;

namespace VampireSurvivors.Objects
{
	public class SineBonus : IDisposable
	{
		private float _sine;

		private Tween _sineTween;

		private SineBonusData _sineBonusData;

		public float Value => 0f;

		public void Start(SineBonusData data)
		{
		}

		public void Dispose()
		{
		}
	}
}
