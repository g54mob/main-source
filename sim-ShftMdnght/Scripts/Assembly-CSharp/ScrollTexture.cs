using System.Collections;
using UnityEngine;

public class ScrollTexture : MonoBehaviour
{
	public Material overrideMaterial;

	public Renderer[] objectsToScroll;

	public float scrollSpeedX = 0.5f;

	public float scrollSpeedY = 0.5f;

	public Material[] materials;

	private float offsetX;

	private float offsetY;

	private void Start()
	{
		if ((bool)overrideMaterial)
		{
			for (int i = 0; i < materials.Length; i++)
			{
				Material[] array = objectsToScroll[i].materials;
				array[0] = overrideMaterial;
				objectsToScroll[i].materials = array;
			}
		}
		materials = new Material[objectsToScroll.Length];
		for (int j = 0; j < objectsToScroll.Length; j++)
		{
			materials[j] = objectsToScroll[j].material;
		}
	}

	private void OnEnable()
	{
		StartCoroutine(ScrollRoutine());
	}

	private IEnumerator ScrollRoutine()
	{
		while (true)
		{
			offsetX += scrollSpeedX * 0.05f;
			offsetY += scrollSpeedY * 0.05f;
			for (int i = 0; i < materials.Length; i++)
			{
				materials[i].mainTextureOffset = new Vector2(offsetX, offsetY);
			}
			yield return new WaitForSeconds(0.05f);
		}
	}
}
