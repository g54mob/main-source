using CTS.Core;
using UnityEngine;

namespace CTS
{
	public class UnityUnscaledTime : IUpdatable
	{
		private static UnityUnscaledTime _instance;

		private static readonly int UnscaledTime = Shader.PropertyToID("_UnscaledTime");

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
		private static void Init()
		{
			Application.quitting -= OnApplicationQuit;
			Application.quitting += OnApplicationQuit;
			_instance = new UnityUnscaledTime();
			UpdateSpreader.AddUpdate(_instance);
		}

		private static void OnApplicationQuit()
		{
			Application.quitting -= OnApplicationQuit;
			UpdateSpreader.RemoveUpdate(_instance);
			_instance = null;
		}

		void IUpdatable.OnUpdate()
		{
			Update();
		}

		private static void Update()
		{
			Shader.SetGlobalVector(UnscaledTime, new Vector4(Time.unscaledTime / 20f, Time.unscaledTime, Time.unscaledTime * 2f, Time.unscaledTime * 3f));
		}
	}
}
