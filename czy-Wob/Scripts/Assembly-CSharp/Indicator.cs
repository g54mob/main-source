using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Indicator : MonoBehaviour
{
	public List<TextMeshPro> baseText;

	public List<SpriteRenderer> baseGraphics;

	private int defaultDepth = 1;

	protected float yOffset = 3f;

	private ScalableUIComponent uiComponentRef;

	private Camera uiCam;

	private Camera mainCam;

	private GameObject holderRef;

	private Transform followTransform;

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
		mainCam = Camera.main;
		holderRef = base.transform.GetChild(0).gameObject;
		uiComponentRef = GetComponent<ScalableUIComponent>();
		uiCam = ObjectRegistration.GetRegistrationScript().GetGlobalComponent<Camera>(GlobalObject.UI_CAMERA);
	}

	protected virtual void StartBehavior()
	{
		base.transform.root.position = new Vector3(base.transform.root.position.x, base.transform.root.position.y, -100f);
	}

	private void Update()
	{
		UpdateIndicator();
	}

	public virtual void UpdateIndicator()
	{
		FollowTransform();
	}

	public void SetFollowTarget(Transform newTransform)
	{
		followTransform = newTransform;
		uiComponentRef.refTransform = newTransform;
		base.transform.localPosition = new Vector3(base.transform.localPosition.x, base.transform.localPosition.y, defaultDepth);
		FollowTransform();
	}

	public void SetInitialPos()
	{
		FollowTransform();
		UpdateDepth();
	}

	private void FollowTransform()
	{
		if (followTransform == null)
		{
			Object.Destroy(base.gameObject);
			return;
		}
		Vector3 vector = mainCam.WorldToViewportPoint(followTransform.position + new Vector3(0f, yOffset, 0f));
		if (vector.z <= 0f)
		{
			holderRef.SetActive(value: false);
			return;
		}
		holderRef.SetActive(value: true);
		Vector3 vector2 = vector;
		Vector3 vector3 = uiCam.WorldToViewportPoint(base.transform.root.position);
		vector2 -= vector3;
		float distanceScale = uiComponentRef.GetDistanceScale();
		base.transform.localPosition = new Vector3(vector2.x * distanceScale, vector2.y * distanceScale, base.transform.localPosition.z);
		UpdateDepth();
	}

	protected int GetDepth()
	{
		return Mathf.RoundToInt((0f - uiComponentRef.GetDistanceScale()) * 100f);
	}

	protected virtual void UpdateDepth()
	{
		int depth = GetDepth();
		for (int i = 0; i < baseGraphics.Count; i++)
		{
			baseGraphics[i].sortingOrder = depth;
		}
		for (int j = 0; j < baseText.Count; j++)
		{
			baseText[j].sortingOrder = depth + 1;
		}
	}
}
