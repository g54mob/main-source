using UnityEngine;
using UnityEngine.UI;

[ExecuteAlways]
[RequireComponent(typeof(Graphic))]
[DisallowMultipleComponent]
public class InverseMasked : MonoBehaviour
{
	private Graphic graphic;

	private static Material inverseMaskedMaterial;

	private void OnEnable()
	{
		graphic = GetComponent<Graphic>();
		if (inverseMaskedMaterial == null)
		{
			Shader shader = Shader.Find("UI/InverseMasked");
			if (!(shader != null))
			{
				Debug.LogError("[InverseMasked] UI/InverseMasked shader bulunamadı!");
				return;
			}
			inverseMaskedMaterial = new Material(shader);
			inverseMaskedMaterial.name = "InverseMasked (Generated)";
		}
		graphic.material = inverseMaskedMaterial;
	}

	private void OnDisable()
	{
		if (graphic != null)
		{
			graphic.material = null;
		}
	}
}
