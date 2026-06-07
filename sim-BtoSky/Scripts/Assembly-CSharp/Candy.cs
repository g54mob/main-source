using UnityEngine;

public class Candy : MonoBehaviour
{
	[SerializeField]
	private Color[] colors;

	private static MaterialPropertyBlock mpb;

	private void Awake()
	{
		if (colors.Length != 0)
		{
			MeshRenderer component = GetComponent<MeshRenderer>();
			SetColor(component, colors[Random.Range(0, colors.Length - 1)]);
		}
		Quaternion rotation = Random.rotation;
		base.transform.rotation = rotation;
	}

	private void Start()
	{
	}

	private void Update()
	{
	}

	private void SetColor(Renderer r, Color color)
	{
		if (mpb == null)
		{
			mpb = new MaterialPropertyBlock();
		}
		mpb.SetColor("_BaseColor", color);
		r.SetPropertyBlock(mpb);
	}
}
