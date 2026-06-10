using NaughtyAttributes;
using UnityEngine;

public class MaterialCreator : MonoBehaviour
{
	[Tooltip("Removes the mesh collider")]
	public bool removeCollider;

	[Tooltip("If true then add an interactable controller to this object")]
	public bool addInteractableController;

	[Tooltip("Duplicate the diffuse map as a normal map. This will not happen if a separate normal map is found.")]
	public bool duplicateDiffuseAndUseAsNormal;

	[Tooltip("Force the 'Colour' shader (alternate colour options and grub texture features). If false this may use the default unity 'Lit' shader if there isn't a colour or grub map...")]
	public bool forceColourShader;

	[Button(null, EButtonEnableMode.Always)]
	public void CreateMaterial()
	{
	}

	public static void SetTextureImporterFormat(Texture2D texture, bool isReadable)
	{
	}

	private float GetPixel(Texture2D tex, int x, int y)
	{
		return 0f;
	}

	public T SafeDestroyGameObject<T>(T component) where T : Component
	{
		return null;
	}

	public T SafeDestroy<T>(T obj) where T : Object
	{
		return null;
	}
}
