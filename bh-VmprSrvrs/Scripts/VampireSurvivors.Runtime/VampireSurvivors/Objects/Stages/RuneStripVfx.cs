using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using VampireSurvivors.Tools;

namespace VampireSurvivors.Objects.Stages
{
	public class RuneStripVfx : GameMonoBehaviour
	{
		private float _heightAlpha;

		private float _alpha;

		private List<Rune> _followers;

		private PhaserSpline _runeSpline;

		private Tween _alphaTween;

		private Transform _cachedTransform;

		private Camera MainCam => null;

		private Bounds CamBounds => default(Bounds);

		public static RuneStripVfx Create(float x, float duration, int flip = 1, float alphaStart = 1f, float alphaEnd = 0.5f)
		{
			return null;
		}

		public void InternalUpdate(float prop)
		{
		}

		private void Init(float x, float duration, int flip = 1, float alphaStart = 1f, float alphaEnd = 0.5f)
		{
		}

		private Rune CreateRune(float x, float y)
		{
			return null;
		}
	}
}
