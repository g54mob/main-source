using System;
using System.ComponentModel;
using System.Threading;
using Assets.Nimbatus.Scripts.Common.Helpers;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.Persistence.Achievements;
using Unity.Collections;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.Common.MiniMap
{
	public class MinimapPlanet : MonoBehaviour
	{
		public UITexture PlanetTexture;

		private Texture2D _texture;

		public static readonly ConcurrentQueue<Action> MainThreadQueue = new ConcurrentQueue<Action>();

		private bool _stopThreads;

		private Minimap _miniMap;

		private int _startPixelCount;

		private int _currentPixelCount;

		public void Init(Minimap minimap)
		{
			_miniMap = minimap;
			_texture = new Texture2D(220, 220);
			_texture.filterMode = FilterMode.Bilinear;
			_texture.wrapMode = TextureWrapMode.Clamp;
			_texture.Apply();
			PlanetTexture.mainTexture = _texture;
			_startPixelCount = 0;
			_currentPixelCount = 0;
		}

		public void OnEnable()
		{
			MainThreadQueue.Clear();
			_stopThreads = false;
			BackgroundWorker backgroundWorker = new BackgroundWorker();
			backgroundWorker.DoWork += RegenerateTexture;
			backgroundWorker.RunWorkerAsync();
		}

		public void OnDisable()
		{
			_stopThreads = true;
		}

		public void OnApplicationQuit()
		{
			_stopThreads = true;
		}

		private void RegenerateTexture(object sender, DoWorkEventArgs e)
		{
			while (!_stopThreads)
			{
				try
				{
					if (RuntimeGlobals.WorldController != null && RuntimeGlobals.WorldController.ForeGroundTerrain != null && !RuntimeGlobals.IsGameLoading)
					{
						Color[] textureData = RuntimeGlobals.WorldController.GenerateActivePlanetImage();
						if (_startPixelCount <= 0)
						{
							_startPixelCount = CountTerrainPixels(textureData);
							if (BaseSingleton<AchievementManager>.Instance.IsAchievementUnlocked(EAchievement.WorldSlayer))
							{
								BaseSingleton<AchievementManager>.Instance.UnlockAchievement(EAchievement.WorldSlayer);
							}
						}
						else if (!BaseSingleton<AchievementManager>.Instance.IsAchievementUnlocked(EAchievement.WorldSlayer))
						{
							int num = CountTerrainPixels(textureData);
							if (100f / (float)_startPixelCount * (float)num < 10f)
							{
								BaseSingleton<AchievementManager>.Instance.UnlockAchievement(EAchievement.WorldSlayer);
							}
						}
						MainThreadQueue.Enqueue(delegate
						{
							UpdatePlanetTexture(textureData);
						});
					}
				}
				catch (Exception message)
				{
					Debug.Log(message);
				}
				Thread.Sleep(100);
			}
		}

		private int CountTerrainPixels(Color[] terrain)
		{
			int num = 0;
			for (int i = 0; i < 220; i++)
			{
				for (int j = 0; j < 220; j++)
				{
					if (terrain[j * 220 + i].a > 0f)
					{
						num++;
					}
				}
			}
			return num;
		}

		public void Update()
		{
			int num = 0;
			while (MainThreadQueue.Count > 0 && num <= 15)
			{
				Action value;
				if (MainThreadQueue.TryDequeue(out value) && value != null)
				{
					try
					{
						value();
					}
					catch (Exception exception)
					{
						Debug.LogException(exception);
					}
				}
				num++;
			}
		}

		private void UpdatePlanetTexture(Color[] textureData)
		{
			NativeArray<Color32> rawTextureData = _texture.GetRawTextureData<Color32>();
			for (int i = 0; i < 220; i++)
			{
				for (int j = 0; j < 220; j++)
				{
					rawTextureData[j * 220 + i] = textureData[j * 220 + i];
				}
			}
			_texture.Apply();
		}

		public void UpdateRadius(Minimap map)
		{
			int num = 220;
			PlanetTexture.SetDimensions(num, num);
		}
	}
}
