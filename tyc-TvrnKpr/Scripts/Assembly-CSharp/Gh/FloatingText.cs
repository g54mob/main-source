using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

namespace Gh
{
	public class FloatingText : FloatingSolidText
	{
		private static GameObject _floatingTextUIPrefab;

		private float lifeTime;

		public bool unscaled;

		private float alpha;

		public Vector2 velocity;

		public Ease easing;

		private List<Tween> _tweens;

		public static Color NegativeTextColor => default(Color);

		public static Color PositiveTextColor => default(Color);

		public static Color MoneyTextColor => default(Color);

		public static FloatingText SpawnFromWorldPosition(string textKey, Vector3 worldPosition, Color? color = null, bool unscaled = false)
		{
			return null;
		}

		public static FloatingText SpawnUI(string textKey, Vector2 screenPoint, Color? color = null, bool unscaled = false)
		{
			return null;
		}

		private static GameObject SpawnFloatingText(string textKey, Vector3 spawnPosition, Color? color, bool unscaled)
		{
			return null;
		}

		private void Start()
		{
		}

		public void InitTween()
		{
		}

		protected override void OnDestroy()
		{
		}
	}
}
