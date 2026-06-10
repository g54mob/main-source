using System.Collections.Generic;
using UnityEngine;

public class BugController : MonoBehaviour
{
	public NewRoom room;

	private List<NewNode> nodes;

	public float speed;

	public float turnSpeed;

	private bool newJourney;

	private NewNode destinationNode;

	private Vector3 destinationPos;

	public void Setup(NewRoom newRoom)
	{
	}

	private void Update()
	{
	}
}
