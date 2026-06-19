using System.Collections.Generic;
using UnityEngine;

public class ScreenSpaceBillboard : MonoBehaviour
{
	public Transform mainTransform;

	public Vector3 worldspaceOffset;

	public Vector3 screenSpaceOffset;

	public float cameraDistLow = 1f;

	public float cameraDistHigh = 25f;

	public float maxCameraDistance = 45f;

	public float scaleLow;

	public float scaleHigh = 1f;

	private float defaultScale;

	private bool hasAwoken;

	private Vector3? followPos;

	public Transform followTransform;

	private Vector3[] billboardCornersTemp = new Vector3[4];

	private List<RectTransform> referenceTransforms = new List<RectTransform>();

	private Camera cameraRef;

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
		defaultScale = mainTransform.localScale.x;
		AssignCamera();
		hasAwoken = true;
		UpdateBillboard();
	}

	private void AssignCamera()
	{
		cameraRef = Camera.main;
	}

	protected virtual void StartBehavior()
	{
		UpdateBillboard();
	}

	private void FixedUpdate()
	{
		FixedUpdateBehavior();
	}

	protected virtual void FixedUpdateBehavior()
	{
		UpdateBillboard();
	}

	public void SetFollowTransform(Transform newTransform)
	{
		if (!hasAwoken)
		{
			AssignCamera();
		}
		followPos = null;
		followTransform = newTransform;
		UpdateBillboard(force: true);
	}

	public virtual void SetFollowPosition(Vector3 pos)
	{
		if (!hasAwoken)
		{
			AssignCamera();
		}
		followPos = pos;
		followTransform = null;
		UpdateBillboard(force: true);
	}

	public Vector3 GetAssociatedPosition()
	{
		if (!followPos.HasValue)
		{
			Debug.LogError("No follow position set.");
			return Vector3.zero;
		}
		return followPos.Value;
	}

	public virtual void UpdateBillboard(bool force = false)
	{
		if (!(followTransform == null) || followPos.HasValue)
		{
			Vector3 vector = ((!(followTransform != null)) ? followPos.Value : followTransform.position);
			Vector3 position = vector;
			position += worldspaceOffset;
			position = cameraRef.WorldToScreenPoint(position);
			mainTransform.position = position + screenSpaceOffset;
			float num = Vector3.Distance(cameraRef.transform.position, vector);
			if (num > maxCameraDistance)
			{
				mainTransform.gameObject.SetActive(value: false);
			}
			else
			{
				mainTransform.gameObject.SetActive(value: true);
			}
			float val = Mathf.Clamp(num, cameraDistLow, cameraDistHigh);
			float percentage = 1f - MathUtil.GetPercentageOfRange(val, cameraDistLow, cameraDistHigh);
			float num2 = defaultScale + MathUtil.GetValueOfRangePercentage(percentage, scaleLow, scaleHigh) * defaultScale;
			mainTransform.localScale = new Vector3(num2, num2, num2);
			LockToScreen();
		}
	}

	public void ClearReferenceTransforms()
	{
		referenceTransforms.Clear();
	}

	public void AddReferenceTransform(RectTransform newTransform)
	{
		referenceTransforms.Add(newTransform);
	}

	public void LockToScreen()
	{
		if (referenceTransforms.Count == 0)
		{
			return;
		}
		Vector3 position = mainTransform.position;
		float num = 0f;
		float num2 = 0f;
		float num3 = Screen.width;
		float num4 = Screen.height;
		float num5 = float.PositiveInfinity;
		float num6 = float.NegativeInfinity;
		float num7 = float.PositiveInfinity;
		float num8 = float.NegativeInfinity;
		bool flag = false;
		for (int i = 0; i < referenceTransforms.Count; i++)
		{
			if (referenceTransforms[i] == null || !referenceTransforms[i].gameObject.activeInHierarchy)
			{
				continue;
			}
			flag = true;
			referenceTransforms[i].GetWorldCorners(billboardCornersTemp);
			for (int j = 0; j < billboardCornersTemp.Length; j++)
			{
				if (billboardCornersTemp[j].x < num5)
				{
					num5 = billboardCornersTemp[j].x;
				}
				if (billboardCornersTemp[j].x > num6)
				{
					num6 = billboardCornersTemp[j].x;
				}
				if (billboardCornersTemp[j].y < num7)
				{
					num7 = billboardCornersTemp[j].y;
				}
				if (billboardCornersTemp[j].y > num8)
				{
					num8 = billboardCornersTemp[j].y;
				}
			}
		}
		if (flag)
		{
			if (num5 < num)
			{
				position.x += num - num5;
			}
			else if (num6 > num3)
			{
				position.x -= num6 - num3;
			}
			if (num7 < num2)
			{
				position.y += num2 - num7;
			}
			else if (num8 > num4)
			{
				position.y -= num8 - num4;
			}
			mainTransform.position = position;
		}
	}
}
