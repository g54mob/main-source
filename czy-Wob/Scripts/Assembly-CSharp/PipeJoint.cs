using System.Collections.Generic;
using UnityEngine;

public class PipeJoint : MonoBehaviour
{
	public GameObject frontConnector;

	public GameObject backConnector;

	public GameObject rotationObject;

	public GameObject flyZone;

	public MeshRenderer mainRenderer;

	public List<Material> potentialMaterials;

	private void Awake()
	{
		mainRenderer.material = ListUtil.GetRandomElement(potentialMaterials);
	}
}
