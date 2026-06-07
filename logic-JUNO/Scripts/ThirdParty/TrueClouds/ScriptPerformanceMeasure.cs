using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

namespace TrueClouds
{
	internal class ScriptPerformanceMeasure : MonoBehaviour
	{
		public MonoBehaviour Target;

		public int BatchDurationInFrames = 10;

		public int BatchCount = 40;

		private string _testResult = "Not measured";

		private List<bool> _isScriptEnabled = new List<bool>();

		private float[] _enabledTimes;

		private float[] _disabledlTimes;

		private GUIStyle _labelStyle;

		private bool _wasMeasureLaunched;

		private static System.Random rnd = new System.Random();

		private void Start()
		{
			_labelStyle = new GUIStyle("label")
			{
				fontSize = 20
			};
			_enabledTimes = new float[BatchCount];
			_disabledlTimes = new float[BatchCount];
			for (int i = 0; i < BatchCount; i++)
			{
				_isScriptEnabled.Add(item: true);
				_isScriptEnabled.Add(item: false);
			}
			Shuffle(_isScriptEnabled);
		}

		private IEnumerator MeasureCoroutine()
		{
			int enabledId = 0;
			int disabledId = 0;
			for (int i = 0; i < BatchCount * 2; i++)
			{
				float num = 100 * i / (BatchCount * 2);
				_testResult = $"Measured {num}%";
				Target.enabled = _isScriptEnabled[i];
				yield return null;
				float time = Time.unscaledTime;
				yield return WaitForFrames(BatchDurationInFrames);
				time = (Time.unscaledTime - time) * 1000f / (float)BatchDurationInFrames;
				if (_isScriptEnabled[i])
				{
					_enabledTimes[enabledId++] = time;
				}
				else
				{
					_disabledlTimes[disabledId++] = time;
				}
			}
			SetTimeString();
			Target.enabled = true;
		}

		private void SetTimeString()
		{
			Array.Sort(_enabledTimes);
			Array.Sort(_disabledlTimes);
			float[] array = new float[BatchCount];
			for (int i = 0; i < BatchCount; i++)
			{
				array[i] = _enabledTimes[i] - _disabledlTimes[i];
			}
			Array.Sort(array);
			float num = array[BatchCount * 50 / 100];
			float num2 = array[BatchCount * 90 / 100];
			_testResult = string.Format("3d Cloud rendering takes {0} ms per frame. 90% of time rendering was faster than {1} ms", num.ToString("F4"), num2.ToString("F4"));
		}

		private IEnumerator WaitForFrames(int frames)
		{
			for (int i = 0; i < frames; i++)
			{
				Thread.Sleep(16);
				yield return null;
			}
		}

		private void OnGUI()
		{
			GUILayout.BeginArea(new Rect(10f, 40f, 1000f, 30f));
			if (_wasMeasureLaunched)
			{
				GUILayout.Label(_testResult, _labelStyle);
			}
			else if (GUILayout.Button("Measure Performance", GUILayout.Width(150f)))
			{
				StartCoroutine(MeasureCoroutine());
				_wasMeasureLaunched = true;
			}
			GUILayout.EndArea();
		}

		private static void Shuffle<T>(List<T> list)
		{
			int num = list.Count;
			while (num > 1)
			{
				num--;
				int index = rnd.Next(num + 1);
				T value = list[index];
				list[index] = list[num];
				list[num] = value;
			}
		}
	}
}
