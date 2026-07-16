using System.Collections.Generic;
using UnityEngine;

public class CameraFader : MonoBehaviour
{
	[SerializeField]
	private LayerMask layerMask;

	[SerializeField]
	private Camera mainCamera;

	private Transform player;

	private List<ObjectFader> faders = new List<ObjectFader>();

	private void Start()
	{
		player = GlobalReferences.GetCharacterController().transform;
	}

	private void Update()
	{
		if (CameraManager.GetActiveCamera() != mainCamera)
		{
			Shader.SetGlobalVector("_PlayerPosition", new Vector3(-250f, -250f, -250f));
		}
		else
		{
			Shader.SetGlobalVector("_PlayerPosition", player.transform.position);
		}
	}
}
