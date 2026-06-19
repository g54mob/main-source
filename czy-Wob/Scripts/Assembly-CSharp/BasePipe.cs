using System.Collections.Generic;
using UnityEngine;

public class BasePipe : MonoBehaviour
{
	public GameObject connectorFront;

	public GameObject connectorBack;

	public GameObject flyZone;

	public GameObject triggerExit;

	public GameObject triggerEntry;

	public MeshRenderer mainRenderer;

	public List<Material> potentialMaterials;

	private void Awake()
	{
		mainRenderer.material = ListUtil.GetRandomElement(potentialMaterials);
	}
}
