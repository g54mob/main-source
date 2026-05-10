using System;
using CTS.Core;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CTS
{
	public class SelectionMapManagerScore : MonoSingleton<SelectionMapManagerScore>
	{
		private MapInfoSO _city;

		[field: SerializeField]
		[field: Scene]
		public int SelectionMapScene { get; private set; }

		public static event Action<MapInfoSO> OnMapWinStars;

		protected override void OnSingletonDestroy()
		{
			MapInfoSO.MapWinScore -= CityWinStars;
		}

		protected override void SingletonAwake()
		{
			MapInfoSO.MapWinScore += CityWinStars;
		}

		public void CityWinStars(MapInfoSO City)
		{
			_city = City;
			LoadingScreen.EndLoadingScreen += EndLoadingScreen;
		}

		private void EndLoadingScreen()
		{
			if (SceneManager.GetActiveScene().buildIndex == SelectionMapScene)
			{
				SelectionMapManagerScore.OnMapWinStars?.Invoke(_city);
				LoadingScreen.EndLoadingScreen -= EndLoadingScreen;
			}
		}
	}
}
