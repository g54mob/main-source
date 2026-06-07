using System.Collections.Generic;
using UnityEngine;
using VolumetricLines;

public class LineComponent : MonoBehaviour
{
	private class LineBodyWrapper
	{
		private readonly GameObject lineObject;

		private readonly VolumetricLineBehavior volumetricLine;

		private readonly LineRenderer lineRenderer;

		private Vector3 startPosition;

		private Vector3 endPosition;

		public Vector3 StartPosition
		{
			set
			{
				startPosition = value;
				if (volumetricLine != null)
				{
					volumetricLine.StartPos = volumetricLine.transform.InverseTransformPoint(value);
				}
				else if (lineRenderer != null)
				{
					lineRenderer.SetPosition(0, value);
				}
				else
				{
					CylinderPosition(startPosition, endPosition);
				}
			}
		}

		public Vector3 EndPosition
		{
			set
			{
				endPosition = value;
				if (volumetricLine != null)
				{
					volumetricLine.EndPos = volumetricLine.transform.InverseTransformPoint(value);
				}
				else if (lineRenderer != null)
				{
					lineRenderer.SetPosition(1, value);
				}
				else
				{
					CylinderPosition(startPosition, endPosition);
				}
			}
		}

		public LineBodyWrapper(GameObject lineObject)
		{
			this.lineObject = lineObject;
			volumetricLine = lineObject.GetComponent<VolumetricLineBehavior>();
			if (volumetricLine == null)
			{
				lineRenderer = lineObject.GetComponent<LineRenderer>();
			}
		}

		private void CylinderPosition(Vector3 startPos, Vector3 endPos)
		{
			lineObject.transform.position = startPos;
			lineObject.transform.LookAt(endPos);
			lineObject.transform.SetLocalScaleZ(Vector3.Distance(startPos, endPosition));
		}
	}

	[SerializeField]
	private bool useVolumetricLine = true;

	[SerializeField]
	private bool useLineRenderer;

	[SerializeField]
	private bool useSolidLine;

	private Transform genericLineObject;

	private Transform volumetricLineObject;

	private Transform lineRendererObject;

	private Transform solidLineObject;

	private GameObject lineStartObject;

	private GameObject lineEndObject;

	private List<LineBodyWrapper> lines;

	public void Initialize(Transform parentFolder, Transform objectToLook = null)
	{
		lines = new List<LineBodyWrapper>();
		genericLineObject = base.transform.Find("LineBody");
		volumetricLineObject = base.transform.Find("VolumetricLine");
		solidLineObject = base.transform.Find("SolidLine");
		if (genericLineObject != null)
		{
			genericLineObject.gameObject.SetActive(value: true);
			lines.Add(new LineBodyWrapper(genericLineObject.gameObject));
		}
		if (volumetricLineObject != null)
		{
			if (useVolumetricLine)
			{
				volumetricLineObject.gameObject.SetActive(value: true);
				lines.Add(new LineBodyWrapper(volumetricLineObject.gameObject));
			}
			else
			{
				volumetricLineObject.gameObject.SetActive(value: false);
			}
		}
		if (solidLineObject != null)
		{
			if (useSolidLine)
			{
				solidLineObject.gameObject.SetActive(value: true);
				lines.Add(new LineBodyWrapper(solidLineObject.gameObject));
			}
			else
			{
				solidLineObject.gameObject.SetActive(value: false);
			}
		}
		lineStartObject = base.transform.Find("StartLinePoint").gameObject;
		lineEndObject = base.transform.Find("EndLinePoint").gameObject;
		LookToObject component = lineStartObject.GetComponent<LookToObject>();
		if (component != null && objectToLook != null)
		{
			component.objectToLook = objectToLook;
		}
		component = lineEndObject.GetComponent<LookToObject>();
		if (component != null && objectToLook != null)
		{
			component.objectToLook = objectToLook;
		}
		base.transform.SetParent(parentFolder);
	}

	public void SetVisibility(bool isVisible)
	{
		base.gameObject.SetActive(isVisible);
	}

	public void SetPositions(Vector3 startPosition, Vector3 endPosition)
	{
		lineStartObject.transform.position = startPosition;
		lineEndObject.transform.position = endPosition;
		foreach (LineBodyWrapper line in lines)
		{
			line.StartPosition = startPosition;
			line.EndPosition = endPosition;
		}
	}
}
