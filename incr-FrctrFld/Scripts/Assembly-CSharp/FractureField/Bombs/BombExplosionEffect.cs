using System;
using UnityEngine;

namespace FractureField.Bombs
{
	public class BombExplosionEffect : MonoBehaviour
	{
		[Header("Animation Settings")]
		[SerializeField]
		private SpriteRenderer _spriteRenderer;

		[SerializeField]
		private Sprite[] explosionSprites;

		[SerializeField]
		private float frameRate;

		private int currentFrame;

		private float timer;

		public Action OnAnimationComplete { get; set; }

		private void Start()
		{
		}

		private void OnEnable()
		{
		}

		private void Update()
		{
		}
	}
}
