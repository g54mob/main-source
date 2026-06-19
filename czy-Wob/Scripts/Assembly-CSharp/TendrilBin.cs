using System.Collections;
using System.Collections.Generic;
using HighlightingSystem;
using UnityEngine;

public class TendrilBin : MonoBehaviour
{
	public Color highlightColor;

	public GameObject tendrilPrefab;

	public GameObject attachmentParticlePrefab;

	public GameObject finalAttachmentParticlePrefab;

	public Transform tendrilStartTransform;

	public List<TagsEnum> allowedTags = new List<TagsEnum>();

	private List<Highlighter> highlighters = new List<Highlighter>();

	private float attachRate = 100f;

	private float dustScale = 0.25f;

	private float ascensionRate = 45f;

	private List<AttachmentStruct> attachmentStructs = new List<AttachmentStruct>();

	private float tendrilCurveDist = 0.5f;

	private float tendrilCurveAmount = 0.25f;

	private float tendrilLineEndWidth = 0.15f;

	private float tendrilLineStartWidth = 0.75f;

	private bool inSelectionMode;

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.S))
		{
			if (!inSelectionMode)
			{
				EnterSelectionMode();
			}
			else
			{
				ExitSelectionMode();
			}
		}
	}

	private void EnterSelectionMode()
	{
		inSelectionMode = true;
		HighlightTaggedObjects();
		for (int i = 0; i < highlighters.Count; i++)
		{
			AttachTendrilToObjet(highlighters[i].gameObject);
		}
	}

	private void ExitSelectionMode()
	{
		inSelectionMode = false;
		RemoveHighlights();
	}

	private void CreateTendrilLine(AttachmentStruct structRef, Vector3 lineEnd, float pMod)
	{
		Vector3 position = tendrilStartTransform.position;
		List<Vector3> list = new List<Vector3>();
		list.Add(position);
		float num = Vector3.Distance(position, lineEnd);
		for (float num2 = 1f; num2 < num - 1f; num2 += tendrilCurveDist)
		{
			Vector3 pointAlongLine = MathUtil.GetPointAlongLine(position, lineEnd, num2 / num);
			float num3 = num2;
			num3 = ((pMod != -1f) ? (num3 + num * pMod) : (num3 + num));
			Vector3 vector = Vector3.Normalize(Vector3.Cross(lineEnd - position, Vector3.up)) * Mathf.Sin(num3);
			Vector3 item = pointAlongLine + vector * tendrilCurveAmount;
			list.Add(item);
		}
		list.Add(lineEnd);
		float num4 = 0f;
		structRef.tendrilLine.positionCount = list.Count;
		for (int i = 0; i < list.Count; i++)
		{
			if (i > 0)
			{
				num4 += Vector3.Distance(list[i - 1], list[i]);
			}
			structRef.tendrilLine.SetPosition(i, list[i]);
		}
		if (pMod == -1f)
		{
			structRef.tendrilLineStartLength = num4;
		}
		structRef.tendrilLine.endWidth = tendrilLineEndWidth;
		structRef.tendrilLine.startWidth = tendrilLineStartWidth;
	}

	private void UpdateTendrilLine(AttachmentStruct structRef, Vector3 lineEnd)
	{
		structRef.tendrilLine.SetPosition(structRef.tendrilLine.positionCount - 1, lineEnd);
		UpdateTendrilWidth(structRef);
	}

	private float GetTendrilLenPercentage(AttachmentStruct structRef)
	{
		float num = 0f;
		for (int i = 1; i < structRef.tendrilLine.positionCount; i++)
		{
			num += Vector3.Distance(structRef.tendrilLine.GetPosition(i - 1), structRef.tendrilLine.GetPosition(i));
		}
		return num / structRef.tendrilLineStartLength;
	}

	private void UpdateTendrilWidth(AttachmentStruct structRef)
	{
		float valueOfRangePercentage = MathUtil.GetValueOfRangePercentage(GetTendrilLenPercentage(structRef), tendrilLineEndWidth, tendrilLineStartWidth);
		structRef.tendrilLine.startWidth = valueOfRangePercentage;
	}

	private void AttachTendrilToObjet(GameObject obj)
	{
		AttachmentStruct attachmentStruct = new AttachmentStruct();
		attachmentStruct.targetObject = obj;
		if (obj.CompareTag(Tags.DOG))
		{
			attachmentStruct.targetRB = obj.GetComponent<LegController>().bodyFront.GetComponent<Rigidbody>();
		}
		else
		{
			attachmentStruct.targetRB = obj.GetComponentInChildren<Rigidbody>();
		}
		attachmentStruct.attachRoutine = StartCoroutine(TendrilAttachRoutine(attachmentStruct));
	}

	private IEnumerator TendrilAttachRoutine(AttachmentStruct structRef)
	{
		yield return new WaitForSeconds(Random.Range(0f, 0.25f));
		structRef.tendrilLine = Object.Instantiate(tendrilPrefab, tendrilStartTransform.position, Quaternion.identity).GetComponent<LineRenderer>();
		structRef.attachmentPoint = structRef.targetRB.position;
		float dist = Vector3.Distance(tendrilStartTransform.position, structRef.attachmentPoint);
		float lastDist = 0f;
		while (lastDist < dist)
		{
			lastDist += Time.deltaTime * attachRate;
			lastDist = Mathf.Min(lastDist, dist);
			float distanceRatio = lastDist / dist;
			Vector3 pointAlongLine = MathUtil.GetPointAlongLine(tendrilStartTransform.position, structRef.attachmentPoint, distanceRatio);
			CreateTendrilLine(structRef, pointAlongLine, -1f);
			yield return new WaitForEndOfFrame();
		}
		structRef.attachRoutine = null;
		structRef.returnRoutine = StartCoroutine(TendrilReturnRoutine(structRef));
	}

	private IEnumerator TendrilReturnRoutine(AttachmentStruct structRef)
	{
		Object.Instantiate(finalAttachmentParticlePrefab, structRef.attachmentPoint, Quaternion.identity).transform.localScale = new Vector3(dustScale, dustScale, dustScale) * 2f;
		structRef.CreateAttachmentJoint(tendrilStartTransform.position);
		structRef.attachmentJoint.xMotion = ConfigurableJointMotion.Limited;
		structRef.attachmentJoint.yMotion = ConfigurableJointMotion.Limited;
		structRef.attachmentJoint.zMotion = ConfigurableJointMotion.Limited;
		SoftJointLimitSpring linearLimitSpring = new SoftJointLimitSpring
		{
			spring = 5000f
		};
		float limit = Vector3.Distance(tendrilStartTransform.position, structRef.attachmentPoint);
		SoftJointLimit linearLimit = new SoftJointLimit
		{
			limit = limit,
			bounciness = 0.5f
		};
		structRef.attachmentJoint.linearLimit = linearLimit;
		structRef.attachmentJoint.linearLimitSpring = linearLimitSpring;
		float totalTime = 0f;
		while (structRef.attachmentJoint != null)
		{
			totalTime += Time.deltaTime * 2f;
			float rate = Mathf.Abs(ascensionRate * Mathf.Cos(totalTime));
			structRef.UpdateAttachmentPoint(rate);
			float limit2 = 0.1f;
			SoftJointLimit linearLimit2 = new SoftJointLimit
			{
				limit = limit2,
				bounciness = structRef.attachmentJoint.linearLimit.bounciness
			};
			structRef.attachmentJoint.linearLimit = linearLimit2;
			CreateTendrilLine(structRef, structRef.GetAttachmentPoint(), GetTendrilLenPercentage(structRef));
			UpdateTendrilWidth(structRef);
			yield return new WaitForEndOfFrame();
		}
		Object.Destroy(structRef.tendrilLine.gameObject);
		structRef.returnRoutine = null;
		attachmentStructs.Remove(structRef);
	}

	private void HighlightTaggedObjects()
	{
		if (highlighters.Count > 0)
		{
			RemoveHighlights();
		}
		ulong uID = base.transform.root.GetComponent<BuildObjectInfo>().GetUID();
		ObjectRegistration registrationScript = ObjectRegistration.GetRegistrationScript();
		List<GameObject> list = new List<GameObject>();
		for (int i = 0; i < allowedTags.Count; i++)
		{
			list.AddRange(registrationScript.GetAllObjectsForTag(allowedTags[i]));
		}
		for (int j = 0; j < list.Count; j++)
		{
			if (list[j].GetComponent<BoundingBoxComponent>().GetRoomUID() == uID)
			{
				Highlighter highlighter = list[j].GetComponent<Highlighter>();
				if (highlighter == null)
				{
					highlighter = list[j].AddComponent<Highlighter>();
				}
				highlighter.ConstantOnImmediate(highlightColor);
				highlighters.Add(highlighter);
			}
		}
	}

	private void RemoveHighlights()
	{
		for (int i = 0; i < highlighters.Count; i++)
		{
			if (!(highlighters[i] == null))
			{
				highlighters[i].ConstantOffImmediate();
			}
		}
		highlighters.Clear();
	}
}
