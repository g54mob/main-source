using UnityEngine;
using Zenject;

namespace Restory.Gameplay.Common
{
	public class ScreenSizeCacheService : IInitializable
	{
		private int cachedScreenWidth;

		private int cachedScreenHeight;

		private float cachedScreenDistanceNormalizer;

		public int ScreenWidth => Screen.width;

		public int ScreenHeight => Screen.height;

		public float ScreenDistanceNormalizer
		{
			get
			{
				if (CheckScreenSizeChanges())
				{
					CacheScreenSize();
				}
				return cachedScreenDistanceNormalizer;
			}
		}

		public void Initialize()
		{
			CacheScreenSize();
		}

		private void CacheScreenSize()
		{
			cachedScreenWidth = Screen.width;
			cachedScreenHeight = Screen.height;
			float num = Mathf.Sqrt(Screen.width * Screen.width + Screen.height * Screen.height);
			cachedScreenDistanceNormalizer = 1f / num;
		}

		private bool CheckScreenSizeChanges()
		{
			if (cachedScreenWidth == Screen.width)
			{
				return cachedScreenHeight != Screen.height;
			}
			return true;
		}
	}
}
