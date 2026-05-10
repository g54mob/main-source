using CTS.Core;
using Eflatun.SceneReference;
using UnityEngine;

namespace CTS
{
	[CreateAssetMenu(menuName = "CTS/Level Loader")]
	public class LevelLoader : ScriptableObject
	{
		[field: SerializeField]
		public SceneReference Scene { get; private set; }

		public void LoadScene(bool unloadActive)
		{
			if (MonoSingleton<MenusManager>.TryGetInstance(out var outInstance))
			{
				if (unloadActive)
				{
					outInstance.SwitchScene(Scene);
				}
				else
				{
					outInstance.SwitchScene(Scene);
				}
			}
		}
	}
}
