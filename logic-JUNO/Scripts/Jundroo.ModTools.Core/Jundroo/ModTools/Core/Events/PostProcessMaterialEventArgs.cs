using UnityEngine;

namespace Jundroo.ModTools.Core.Events
{
	public class PostProcessMaterialEventArgs : PostProcessEventArgs
	{
		public Component AssociatedComponent { get; private set; }

		public GameObject AssociatedGameObject { get; private set; }

		public Material Material { get; private set; }

		public PostProcessMaterialEventArgs(ModInfo mod, IModResourceLoader resourceLoader, Material material, GameObject associatedGameObject, Component associatedComponent)
			: base(mod, resourceLoader)
		{
			AssociatedGameObject = associatedGameObject;
			Material = material;
		}
	}
}
