using System;
using CTS.Core;

namespace CTS.BBT
{
	public class SceneReset : MonoSingleton<SceneReset>
	{
		public static event Action Reset;

		protected override void SingletonAwake()
		{
		}

		protected override void OnSingletonDestroy()
		{
		}

		private void Start()
		{
			SceneReset.Reset?.Invoke();
		}
	}
}
