using UnityEngine;

namespace Assets.Scripts.Mods.Events
{
	public class PostProcessGameObjectEventArgs : PostProcessEventArgs
	{
		public GameObject GameObject { get; set; }

		public PostProcessGameObjectEventArgs(ModInfo mod, IModResourceLoader resourceLoader, GameObject gameObject)
			: base(mod, resourceLoader)
		{
			GameObject = gameObject;
		}
	}
}
