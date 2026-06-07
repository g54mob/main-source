using UnityEngine;

namespace Assets.Scripts.Mods.Events
{
	public class PostProcessMissingShaderMaterialEventArgs : PostProcessEventArgs
	{
		public Component AssociatedComponent { get; private set; }

		public GameObject AssociatedGameObject { get; private set; }

		public Material Material { get; private set; }

		public PostProcessMissingShaderMaterialEventArgs(ModInfo mod, IModResourceLoader resourceLoader, Material material, GameObject associatedGameObject, Component associatedComponent)
			: base(mod, resourceLoader)
		{
			Material = material;
			AssociatedGameObject = associatedGameObject;
			AssociatedComponent = associatedComponent;
		}
	}
}
