using UnityEngine;

public class SetBasedOnNode : MonoBehaviour
{
	public NodeScript Node;

	public GameObject Object;

	private MapMarkerScript Marker;

	public bool Reverse;

	private void Start()
	{
		Marker = Node.MyMarker;
	}

	private void Update()
	{
	}

	private void FixedUpdate()
	{
		if (!Reverse)
		{
			Object.SetActive(Marker.CheckStatus());
		}
		else
		{
			Object.SetActive(!Marker.CheckStatus());
		}
	}
}
