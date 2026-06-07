using DG.Tweening;
using UnityEngine;
using VampireSurvivors.Graphics;

namespace VampireSurvivors.Objects.Stages
{
	public class Rune : GameMonoBehaviour
	{
		public SpriteRenderer SpriteRenderer { get; set; }

		public SpriteAnimation SpriteAnimation { get; set; }

		public Tween ZTween { get; set; }

		public Tween AlphaTween { get; set; }

		public float Z { get; set; }

		private void Awake()
		{
		}
	}
}
