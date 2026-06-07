using UnityEngine;
using UnityEngine.UI;

[ExecuteAlways]
[RequireComponent(typeof(Image))]
[DisallowMultipleComponent]
public class InverseMask : MonoBehaviour
{
	private Image image;

	private static Material inverseMaskMaterial;

	private void OnEnable()
	{
		image = GetComponent<Image>();
		if (inverseMaskMaterial == null)
		{
			Shader shader = Shader.Find("UI/InverseMask");
			if (!(shader != null))
			{
				Debug.LogError("[InverseMask] UI/InverseMask shader bulunamadı!");
				return;
			}
			inverseMaskMaterial = new Material(shader);
			inverseMaskMaterial.name = "InverseMask (Generated)";
		}
		image.material = inverseMaskMaterial;
	}

	private void OnDisable()
	{
		if (image != null)
		{
			image.material = null;
		}
	}
}
