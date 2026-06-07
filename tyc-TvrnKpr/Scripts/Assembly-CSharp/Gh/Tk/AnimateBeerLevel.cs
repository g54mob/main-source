using System;
using UnityEngine;

namespace Gh.Tk
{
	public class AnimateBeerLevel : MonoBehaviour
	{
		public float beerLevel;

		private float horizontalAnimationSpeed;

		private Material _beerIconMat;

		private bool _hasAlbedoTextureSlot;

		private Vector2 _textureOffset;

		private float _textureLevel;

		private float levelRangeMin;

		private float levelRangeMax;

		private Tap tap;

		public void Awake()
		{
		}

		private void OnInventoryChanged(object sender, EventArgs e)
		{
		}

		private void CalculateBeerTextureLevel()
		{
		}

		public void Start()
		{
		}

		public void Update()
		{
		}

		public void OnDestroy()
		{
		}
	}
}
