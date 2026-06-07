using System.Diagnostics;
using UnityEngine;

namespace TrueClouds
{
	public class FPSDisplay : MonoBehaviour
	{
		private string _text;

		private Stopwatch _stopwatch;

		private float _delta;

		private void Update()
		{
			_delta = Mathf.Lerp(_delta, Time.unscaledDeltaTime, 1f);
			float num = 1f / _delta;
			_text = $"{_delta * 1000f:0.0} ms ({num:0.} fps)";
		}

		private void OnGUI()
		{
			GUILayout.BeginArea(new Rect(10f, 10f, 300f, 20f));
			GUILayout.Label(_text);
			GUILayout.EndArea();
		}
	}
}
