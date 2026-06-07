using System.Collections;
using UnityEngine;

public class SpriteLightRenderer : MonoBehaviour
{
	public MeshRenderer meshRenderer;

	public Material hdrMaterial;

	public Material ldrMaterial;

	private bool lastHDRState;

	private void Awake()
	{
		meshRenderer = GetComponent<MeshRenderer>();
		StartCoroutine(SetMaterial());
	}

	private IEnumerator SetMaterial()
	{
		while (Camera.main == null || !Camera.main.enabled)
		{
			yield return null;
		}
		lastHDRState = Camera.main.allowHDR;
		meshRenderer.material = (lastHDRState ? hdrMaterial : ldrMaterial);
	}
}
