using System;
using UnityEngine;

public class FPSStat : MonoBehaviour
{
	[NonSerialized]
	private int[] _fpsCounts = new int[300];

	[NonSerialized]
	private float _accum;

	[NonSerialized]
	private float _last;

	[NonSerialized]
	private float _high = float.MinValue;

	[NonSerialized]
	private float _low = float.MaxValue;

	[NonSerialized]
	private int _frames;

	[NonSerialized]
	private float _timeleft = 0.25f;

	[NonSerialized]
	private float _d;

	[NonSerialized]
	private bool _first = true;

	private void OnPreRender()
	{
		float num = Time.realtimeSinceStartup - _d;
		_d = Time.realtimeSinceStartup;
		_timeleft -= num;
		if (_first)
		{
			_first = false;
			return;
		}
		_accum += num;
		_frames++;
		_last = 1f / num;
		_low = Mathf.Min(_low, _last);
		_high = Mathf.Max(_high, _last);
		int num2 = Mathf.Clamp(Mathf.RoundToInt(_last), 0, _fpsCounts.Length - 1);
		_fpsCounts[num2]++;
	}

	private void OnGUI()
	{
		GUI.Label(new Rect(0f, 0f, 256f, 48f), string.Format("FPS: {0:F0} ({1:F0} - {2:F0})\nAVG: {3:F0}", _last, _low, _high, (float)_frames / _accum));
		GUI.Box(new Rect(0f, 48f, 512f, 256f), "");
		float num = _fpsCounts.MaxSafe((int x) => x);
		float num2 = _fpsCounts.Length;
		for (int num3 = 0; num3 < _fpsCounts.Length; num3++)
		{
			float num4 = (float)_fpsCounts[num3] / num * 256f;
			GUI.Box(new Rect((float)num3 / num2 * 512f, 48f + (256f - num4), 512f / num2, num4), "");
		}
	}
}
