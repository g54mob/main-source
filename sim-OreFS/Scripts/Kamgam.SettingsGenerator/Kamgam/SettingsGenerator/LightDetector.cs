using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Kamgam.SettingsGenerator
{
	public class LightDetector
	{
		public delegate void OnNewLightFoundDelegate(Light light);

		public static bool ScanAfterSceneLoad = true;

		public OnNewLightFoundDelegate OnNewLightFound;

		private static LightDetector _instance;

		protected List<Light> _lights = new List<Light>(20);

		private List<GameObject> _tmpRootGameObjects = new List<GameObject>(20);

		private List<Light> _tmpLights = new List<Light>(20);

		public static LightDetector Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = new LightDetector();
				}
				return _instance;
			}
		}

		public List<Light> Lights => _lights;

		private LightDetector()
		{
			if (ScanAfterSceneLoad)
			{
				ScanAllScenes();
			}
			SceneManager.sceneLoaded += onSceneLoaded;
		}

		private void onSceneLoaded(Scene scene, LoadSceneMode mode)
		{
			if (ScanAfterSceneLoad)
			{
				ScanScene(scene);
			}
		}

		public Light GetPrimaryLight()
		{
			if (_lights.Count > 0)
			{
				foreach (Light light in _lights)
				{
					if (!(light == null) && light.isActiveAndEnabled && light.gameObject.activeInHierarchy && light.type == LightType.Directional)
					{
						return light;
					}
				}
				foreach (Light light2 in _lights)
				{
					if (!(light2 == null) && light2.isActiveAndEnabled && light2.gameObject.activeInHierarchy)
					{
						return light2;
					}
				}
			}
			return null;
		}

		public void Add(Light light)
		{
			if (!(light == null) && !_lights.Contains(light))
			{
				_lights.Add(light);
				OnNewLightFound?.Invoke(light);
			}
		}

		public void ScanAllScenes()
		{
			int sceneCount = SceneManager.sceneCount;
			for (int i = 0; i < sceneCount; i++)
			{
				ScanScene(SceneManager.GetSceneAt(i));
			}
		}

		public void ScanActiveScene()
		{
			ScanScene(SceneManager.GetActiveScene());
		}

		public void ScanScene(Scene scene)
		{
			_tmpRootGameObjects.Clear();
			scene.GetRootGameObjects(_tmpRootGameObjects);
			foreach (GameObject tmpRootGameObject in _tmpRootGameObjects)
			{
				_tmpLights.Clear();
				tmpRootGameObject.GetComponentsInChildren(includeInactive: true, _tmpLights);
				foreach (Light tmpLight in _tmpLights)
				{
					if (!_lights.Contains(tmpLight))
					{
						_lights.Add(tmpLight);
						OnNewLightFound?.Invoke(tmpLight);
					}
				}
			}
			_tmpLights.Clear();
			_tmpRootGameObjects.Clear();
			Defrag();
		}

		public void Defrag()
		{
			for (int num = _lights.Count - 1; num >= 0; num--)
			{
				if (_lights[num] == null || _lights[num].gameObject == null)
				{
					_lights.RemoveAt(num);
				}
			}
		}
	}
}
