using System.Collections.Generic;
using UnityEngine;

public class PipeLine : MonoBehaviour
{
	public LineRenderer rendererRef;

	public Material backingMat;

	public List<Material> standardMaterials;

	public GameObject capPrefab;

	private GameObject endCap;

	private GameObject startCap;

	private int materialIndex;

	public void SetMaterialToBacking()
	{
		rendererRef.material = backingMat;
	}

	public void SetMaterialIndex(int i)
	{
		materialIndex = MathUtil.Mod(i, standardMaterials.Count);
		rendererRef.material = standardMaterials[materialIndex];
	}

	public void CreateCaps(Vector3 startPos, Vector3 endPos)
	{
		endCap = CreateCap(endPos);
		startCap = CreateCap(startPos);
	}

	public GameObject DuplicateStartCap()
	{
		return CreateCap(startCap.transform.localPosition);
	}

	public GameObject DuplicateEndCap()
	{
		return CreateCap(endCap.transform.localPosition);
	}

	private GameObject CreateCap(Vector3 pos)
	{
		GameObject obj = Object.Instantiate(capPrefab);
		obj.transform.SetParent(base.transform);
		obj.transform.localPosition = pos;
		obj.transform.GetChild(0).GetComponent<SpriteRenderer>().color = standardMaterials[materialIndex].color;
		return obj;
	}
}
