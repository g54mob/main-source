using UnityEngine;

namespace VampireSurvivors.Objects.Stages
{
	public class PolusBackgroundStars : GameMonoBehaviour
	{
		[SerializeField]
		private Vector2 _DefaultPosition;

		[SerializeField]
		private Vector2 _InversePosition;

		[SerializeField]
		private Material _DefaultStarsMaterial;

		[SerializeField]
		private Material _InvertedStarsMaterial;

		private SpriteRenderer _starsRenderer;

		private SpriteRenderer StarsRenderer => null;

		protected override void OnEnable()
		{
		}

		protected override void OnDisable()
		{
		}

		private void OnGameInitialized()
		{
		}
	}
}
