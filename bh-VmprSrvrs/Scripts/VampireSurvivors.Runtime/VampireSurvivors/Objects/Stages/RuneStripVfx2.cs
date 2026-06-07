using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using VampireSurvivors.Tools;

namespace VampireSurvivors.Objects.Stages
{
	public class RuneStripVfx2 : GameMonoBehaviour
	{
		private float _heightAlpha;

		private float _alpha;

		private List<RuneText> _followers;

		private PhaserSpline _runeSpline;

		private Tween _alphaTween;

		private Transform _cachedTransform;

		private GameObject _runeTextPrefab;

		private Camera MainCam => null;

		private Bounds CamBounds => default(Bounds);

		public static RuneStripVfx2 Create(float x, float durationMillis, int flip = 1, float alphaStart = 1f, float alphaEnd = 0.5f)
		{
			return null;
		}

		public void InternalUpdate(float prop)
		{
		}

		private void Init(float x, float durationMillis, int flip = 1, float alphaStart = 1f, float alphaEnd = 0.5f)
		{
		}

		private RuneText CreateRune(float x, float y, string text)
		{
			return null;
		}
	}
}
