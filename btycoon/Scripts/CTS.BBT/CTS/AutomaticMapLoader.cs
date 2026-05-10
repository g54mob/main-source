using System;
using System.Collections;
using CTS.Core;
using NaughtyAttributes;
using UnityEngine;

namespace CTS
{
	public class AutomaticMapLoader : MonoBehaviour
	{
		[SerializeField]
		private float LoadDelay = 0.2f;

		[SerializeField]
		private string _mapToLoad;

		[SerializeField]
		private GameObject[] _additionnalObjects = Array.Empty<GameObject>();

		private LoadingScreen _loadingScreen;

		private readonly LockToggle _lockToggle = new LockToggle();

		public bool MapIsLoaded { get; private set; }

		public static bool IsLoading { get; private set; }

		public static event Action MapLoaded;

		public void SetMapToLoad(string mapToLoad)
		{
			_mapToLoad = mapToLoad;
		}

		private void Awake()
		{
			_loadingScreen = UnityEngine.Object.FindObjectOfType<LoadingScreen>();
			if ((bool)_loadingScreen)
			{
				_lockToggle.Add(_loadingScreen);
			}
			_lockToggle.Lock();
			IsLoading = true;
		}

		private IEnumerator Start()
		{
			yield return Coroutines.WaitForSecondsUnscaled(LoadDelay);
			if (!string.IsNullOrEmpty(_mapToLoad))
			{
				yield return MapLoader.LoadMap(_mapToLoad);
				GameObject[] additionnalObjects = _additionnalObjects;
				for (int i = 0; i < additionnalObjects.Length; i++)
				{
					additionnalObjects[i].SetActive(value: true);
				}
			}
			yield return Coroutines.WaitForSecondsUnscaled(1f);
			IsLoading = false;
			_lockToggle.Unlock();
			if ((bool)_loadingScreen)
			{
				yield return _loadingScreen.WaitForUnlock();
				yield return _loadingScreen.WaitForTransition();
			}
			MapIsLoaded = true;
			AutomaticMapLoader.MapLoaded?.Invoke();
		}

		private void OnDestroy()
		{
			IsLoading = false;
		}

		[Button(null, EButtonEnableMode.Always)]
		private void LoadMap()
		{
			MapLoader.LoadMap(_mapToLoad);
		}
	}
}
