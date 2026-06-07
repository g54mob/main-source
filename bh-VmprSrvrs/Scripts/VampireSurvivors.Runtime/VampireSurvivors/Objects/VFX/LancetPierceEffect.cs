using DG.Tweening;
using QFSW.MOP2;
using UnityEngine;
using VampireSurvivors.Graphics;

namespace VampireSurvivors.Objects.VFX
{
	public class LancetPierceEffect : PoolableMonoBehaviour
	{
		[SerializeField]
		private SpriteRenderer _PierceRenderer;

		[SerializeField]
		private SpriteAnimation _PierceAnimator;

		private Tween _imageTween;

		public void Play()
		{
		}
	}
}
