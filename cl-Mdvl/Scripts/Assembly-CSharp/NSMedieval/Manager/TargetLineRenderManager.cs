using System;
using NSEipix.Base;
using UnityEngine;

namespace NSMedieval.Manager
{
	[Serializable]
	public class TargetLineRenderManager : MonoSingleton<TargetLineRenderManager>
	{
		[SerializeField]
		private GameObject lineRenderObjectInstance;

		private LineRenderer lineRenderer;

		public void ShowLine(Vector3 start, Vector3 end)
		{
			if (lineRenderObjectInstance == null)
			{
				return;
			}
			if (lineRenderer == null)
			{
				lineRenderer = lineRenderObjectInstance.GetComponentInChildren<LineRenderer>();
				if (lineRenderer == null)
				{
					return;
				}
				lineRenderer.positionCount = 2;
			}
			lineRenderer.SetPosition(0, start);
			lineRenderer.SetPosition(1, end);
			lineRenderObjectInstance.SetActive(value: true);
		}

		public void HideLine()
		{
			lineRenderObjectInstance.SetActive(value: false);
		}

		private void Start()
		{
			lineRenderObjectInstance.SetActive(value: false);
		}
	}
}
