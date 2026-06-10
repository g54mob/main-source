using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class STMSampleLink : MonoBehaviour
{
	public string linkName = "Sample Website";

	public void OnMouseDown()
	{
		Debug.Log("I was clicked!! Going to: " + linkName);
	}

	public STMSampleLink(string linkName)
	{
		this.linkName = linkName;
	}
}
