using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BrewedInk.CRT
{
	public class CRTDemoBehaviour : MonoBehaviour
	{
		[Header("Scene References")]
		public CRTCameraBehaviour crtCamera;

		public List<Transform> spin;

		[Header("Asset References")]
		public CRTDataObject[] demoValues;

		[Header("Runtime data")]
		public int currentDemoIndex;

		[ContextMenu("Next Demo")]
		public void GotoNextDemo()
		{
			CRTDataObject curr = demoValues[currentDemoIndex];
			currentDemoIndex = (currentDemoIndex + 1) % demoValues.Length;
			CRTDataObject next = demoValues[currentDemoIndex];
			float duration = 1f;
			StartCoroutine(Animation());
			IEnumerator Animation()
			{
				crtCamera.data = curr.data;
				float realtimeSinceStartup = Time.realtimeSinceStartup;
				float endTime = realtimeSinceStartup + duration;
				while (Time.realtimeSinceStartup < endTime)
				{
					float t = 1f - (endTime - Time.realtimeSinceStartup) / duration;
					CRTData data = CRTData.Lerp(curr.data, next.data, t);
					crtCamera.data = data;
					yield return null;
				}
				crtCamera.data = next.data;
			}
		}

		[ContextMenu("Zoom in!")]
		public void ZoomIn()
		{
			float duration = 2f;
			float startZoom = 2f;
			float endZoom = 1.1f;
			StartCoroutine(Animation());
			IEnumerator Animation()
			{
				crtCamera.data.zoom = startZoom;
				float realtimeSinceStartup = Time.realtimeSinceStartup;
				float endTime = realtimeSinceStartup + duration;
				while (Time.realtimeSinceStartup < endTime)
				{
					float t = 1f - (endTime - Time.realtimeSinceStartup) / duration;
					float zoom = Mathf.Lerp(startZoom, endZoom, t);
					crtCamera.data.zoom = zoom;
					yield return null;
				}
				crtCamera.data.zoom = endZoom;
			}
		}

		private void Start()
		{
			if (crtCamera == null)
			{
				Debug.LogWarning("The crtCamera field hasn't been assigned! Null references will likely abound in short order... :(");
			}
			ZoomIn();
		}

		private void Update()
		{
			if (Input.GetKeyDown(KeyCode.Space))
			{
				GotoNextDemo();
			}
			foreach (Transform item in spin)
			{
				item.Rotate(10f * Time.deltaTime, 0f, 0f, Space.Self);
			}
		}
	}
}
