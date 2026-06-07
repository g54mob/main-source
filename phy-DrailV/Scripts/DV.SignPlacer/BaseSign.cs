using TMPro;
using UnityEngine;

public class BaseSign : MonoBehaviour
{
	private void Start()
	{
		Object.Destroy(this);
	}

	public TextMeshPro GetTextObject()
	{
		return GetComponentInChildren<TextMeshPro>();
	}

	public float GetHeight()
	{
		return GetComponent<MeshRenderer>().bounds.size.y;
	}
}
