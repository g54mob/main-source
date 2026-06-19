using System.Collections.Generic;
using UnityEngine;

public class WorldSpaceBillboard : MonoBehaviour
{
	public Vector3 worldspaceOffset;

	public List<GameObject> yOnlyBillboards;

	public Transform holderTransform;

	public Transform followTransform;

	private Camera mainCam;

	private bool hasAwoken;

	private void Awake()
	{
		AwakeBehavior();
	}

	private void Start()
	{
		StartBehavior();
	}

	protected virtual void AwakeBehavior()
	{
		if (hasAwoken)
		{
			UpdateBillboard();
			return;
		}
		AssignMainCam();
		hasAwoken = true;
		UpdateBillboard();
	}

	private void AssignMainCam()
	{
		mainCam = Camera.main;
	}

	protected virtual void StartBehavior()
	{
		UpdateBillboard();
	}

	private void LateUpdate()
	{
		if (Time.timeScale == 0f)
		{
			UpdateBillboard();
		}
	}

	private void FixedUpdate()
	{
		UpdateBillboard();
	}

	public void SetFollowTransform(Transform newTransform)
	{
		if (!hasAwoken)
		{
			AssignMainCam();
		}
		followTransform = newTransform;
		UpdateBillboard();
	}

	public virtual void UpdateBillboard()
	{
		Transform transform = base.transform;
		if (holderTransform != null)
		{
			transform = holderTransform;
		}
		if (followTransform != null)
		{
			Vector3 vector = Vector3.Normalize(followTransform.position - mainCam.transform.position);
			transform.position = followTransform.position;
			transform.position += vector * worldspaceOffset.z;
			transform.position += new Vector3(worldspaceOffset.x, (worldspaceOffset.y > -10000f && worldspaceOffset.y < 10000f) ? worldspaceOffset.y : 0f, 0f);
		}
		transform.rotation = Quaternion.LookRotation(transform.position - mainCam.transform.position);
		transform.rotation = transform.rotation;
		Vector3 eulerAngles = transform.rotation.eulerAngles;
		for (int i = 0; i < yOnlyBillboards.Count; i++)
		{
			yOnlyBillboards[i].transform.rotation = Quaternion.Euler(0f, eulerAngles.y, 0f);
		}
	}
}
