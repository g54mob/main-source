using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CineMachineArea : MonoBehaviour
{
	[SerializeField]
	private bool followCharacter;

	[SerializeField]
	private bool lookAtCharacter;

	[SerializeField]
	private List<GameObject> objectsToHide;

	[SerializeField]
	private List<GameObject> objectsToShow;

	private CinemachineVirtualCamera areaCamera;

	public CinemachineVirtualCamera AreaCamera => areaCamera;

	public List<GameObject> ObjectsToHide => objectsToHide;

	public List<GameObject> ObjectsToShow => objectsToShow;

	public bool FollowCharacter => followCharacter;

	public bool LookAtCharacter => lookAtCharacter;

	private void Awake()
	{
		areaCamera = GetComponentInChildren<CinemachineVirtualCamera>();
		Collider[] componentsInChildren = GetComponentsInChildren<Collider>();
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			componentsInChildren[i].isTrigger = true;
		}
	}
}
