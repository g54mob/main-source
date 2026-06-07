using System;
using System.Collections;
using UnityEngine;

namespace ModApi.Planet
{
	[Serializable]
	public class PlanetCubemap
	{
		private Coroutine _asyncLoadCoroutine;

		private MonoBehaviour _asyncLoadCoroutineManager;

		private IEnumerator _asyncLoadEnumerator;

		private bool _unloading;

		[field: SerializeField]
		public Cubemap CubemapColor { get; private set; }

		[field: SerializeField]
		public Cubemap CubemapNormals { get; private set; }

		[field: SerializeField]
		public IPlanetData PlanetData { get; }

		[field: SerializeField]
		public int Size { get; }

		[field: SerializeField]
		public PlanetCubemapLoadState State { get; private set; }

		public PlanetCubemap(IPlanetData planetData, int size)
		{
			PlanetData = planetData;
			Size = size;
			State = PlanetCubemapLoadState.Unloaded;
			CubemapColor = null;
			CubemapNormals = null;
		}

		public void LoadCubemaps()
		{
			CubemapColor = PlanetCubemapUtility.LoadCubemap(PlanetData, PlanetCubemapType.Color, Size, create: true);
			CubemapNormals = PlanetCubemapUtility.LoadCubemap(PlanetData, PlanetCubemapType.Normal, Size, create: true);
			State = PlanetCubemapLoadState.Loaded;
			if (PlanetCubemapManager.EnableLogging)
			{
				Debug.Log($"Loaded cubemaps {PlanetData.Name} ({Size})");
			}
		}

		public void LoadCubemapsAsync(PlanetCubemapSet set)
		{
			Action<Cubemap, Cubemap> onCubemapsLoaded = delegate(Cubemap cubemapColor, Cubemap cubemapNormals)
			{
				_asyncLoadEnumerator = null;
				_asyncLoadCoroutine = null;
				_asyncLoadCoroutineManager = null;
				CubemapColor = cubemapColor;
				CubemapNormals = cubemapNormals;
				State = PlanetCubemapLoadState.Loaded;
				if (PlanetCubemapManager.EnableLogging)
				{
					Debug.Log($"Async cubemap load complete {PlanetData.Name} ({Size})");
				}
				if (!_unloading)
				{
					set.RequestsUpdated = true;
					set.ProcessRequests();
				}
			};
			if (PlanetCubemapManager.EnableLogging)
			{
				Debug.Log($"Async cubemap load started {PlanetData.Name} ({Size})");
			}
			State = PlanetCubemapLoadState.Loading;
			_asyncLoadCoroutineManager = set.Manager;
			_asyncLoadEnumerator = PlanetCubemapUtility.LoadCubemapsCoroutine(PlanetData, Size, onCubemapsLoaded);
			_asyncLoadCoroutine = _asyncLoadCoroutineManager.StartCoroutine(_asyncLoadEnumerator);
		}

		public void UnloadCubemaps()
		{
			_unloading = true;
			try
			{
				if (PlanetCubemapManager.EnableLogging)
				{
					if (State == PlanetCubemapLoadState.Loading)
					{
						Debug.Log($"Unloading cubemaps {PlanetData.Name} ({Size}) - Forcing asynchronous load to complete first");
					}
					else if (CubemapColor != null || CubemapNormals != null)
					{
						Debug.Log($"Unloading cubemaps {PlanetData.Name} ({Size})");
					}
				}
				if (State == PlanetCubemapLoadState.Loading)
				{
					if (_asyncLoadCoroutineManager != null)
					{
						_asyncLoadCoroutineManager.StopCoroutine(_asyncLoadCoroutine);
					}
					IEnumerator asyncLoadEnumerator;
					do
					{
						asyncLoadEnumerator = _asyncLoadEnumerator;
					}
					while (asyncLoadEnumerator != null && asyncLoadEnumerator.MoveNext());
				}
				State = PlanetCubemapLoadState.Unloaded;
				if (CubemapColor != null)
				{
					UnityEngine.Object.Destroy(CubemapColor);
					CubemapColor = null;
				}
				if (CubemapNormals != null)
				{
					UnityEngine.Object.Destroy(CubemapNormals);
					CubemapNormals = null;
				}
			}
			finally
			{
				_unloading = false;
			}
		}
	}
}
