using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Lightbug.Utilities
{
	public class FpsCounter : MonoBehaviour
	{
		[SerializeField]
		private float refreshTime = 0.2f;

		[SerializeField]
		private Text text;

		[SerializeField]
		private bool limitToRefreshRate = true;

		private int samples;

		private string output = "FPS : ";

		private float fps = 60f;

		private Dictionary<float, string> frames = new Dictionary<float, string>();

		private float time;

		public float Fps => fps;

		private float GetRefreshRateValue()
		{
			return (float)Screen.currentResolution.refreshRateRatio.value;
		}

		private void Awake()
		{
			fps = GetRefreshRateValue();
			for (int i = 0; i < 100000; i++)
			{
				float num = (float)i / 100f;
				frames.Add(i, num.ToString("F2"));
			}
			if (text != null)
			{
				StartCoroutine(UpdateFPS());
			}
		}

		private void Update()
		{
			time += Time.unscaledDeltaTime;
			samples++;
			if (time >= refreshTime)
			{
				fps = (float)samples / time;
				PrintData();
				time -= refreshTime;
				samples = 0;
			}
		}

		private IEnumerator UpdateFPS()
		{
			WaitForSecondsRealtime waitInstruction = new WaitForSecondsRealtime(refreshTime);
			while (true)
			{
				yield return waitInstruction;
				PrintData();
			}
		}

		private void PrintData()
		{
			if (limitToRefreshRate && QualitySettings.vSyncCount != 0)
			{
				fps = Mathf.Min(fps, GetRefreshRateValue());
			}
			else
			{
				fps = Mathf.Min(fps, 1000f);
			}
			output = frames[(int)(fps * 100f)];
			text.text = $"{output}\n time = {1000f * time / (float)samples} ms";
		}
	}
}
