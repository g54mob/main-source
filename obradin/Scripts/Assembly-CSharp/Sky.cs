using UnityEngine;

public class Sky : MonoBehaviour
{
	[Readonly]
	public OneBit oneBit;

	private Material oceanMaterial;

	private void Start()
	{
		GameObject gameObject = base.transform.FindDescendant("ocean").gameObject;
		oceanMaterial = gameObject.GetComponent<Renderer>().material;
	}

	private void LateUpdate()
	{
		Vector3 vector = oneBit.sourceCamera.WorldToViewportPoint(base.transform.right * -1000f);
		oceanMaterial.SetFloat("_MoonViewportX", vector.x);
	}
}
