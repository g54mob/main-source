using CTS.Core;
using Eflatun.SceneReference;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace CTS.Utilities
{
	public class StartupScene : CTSBehaviour
	{
		[SerializeField]
		private SceneReference _scene;

		protected override void OnAwake()
		{
			base.OnAwake();
			Addressables.LoadSceneAsync(_scene.Address);
		}
	}
}
