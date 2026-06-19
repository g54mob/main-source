using UnityEngine;

public class SkinFoldHelper : MonoBehaviour
{
	private Transform frontTransform;

	private Transform backTransform;

	private Material skinMat;

	private void Awake()
	{
		frontTransform = GetComponent<LegController>().bodyFront.transform;
		backTransform = GetComponent<LegController>().bodyBack.transform;
	}

	private void Update()
	{
		if (skinMat == null)
		{
			FindSkinMat();
		}
		if (skinMat != null)
		{
			UpdateSkinVars();
		}
	}

	private void OnDrawGizmos()
	{
		Gizmos.color = Color.blue;
		Gizmos.DrawSphere(GetFrontCenter(), 0.25f);
		Gizmos.DrawSphere(GetBackCenter(), 0.25f);
	}

	private void FindSkinMat()
	{
		skinMat = GetComponent<DogLooks>().bodyRenderer.materials[2];
	}

	public Vector3 GetFrontCenter()
	{
		return frontTransform.position + frontTransform.localScale.x / 2f * -frontTransform.right;
	}

	public Vector3 GetBackCenter()
	{
		return backTransform.position + backTransform.localScale.x / 2f * backTransform.right;
	}

	private void UpdateSkinVars()
	{
		skinMat.SetVector("_FrontVector", -frontTransform.right);
		skinMat.SetVector("_BackVector", backTransform.right);
		skinMat.SetVector("_FrontPos", GetFrontCenter());
		skinMat.SetVector("_BackPos", GetBackCenter());
	}
}
