using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraphBuilderUnitTest : MonoBehaviour
{
	public UIGraphBuilder _ugbGraphTarget1;

	public UIGraphBuilder _ugbGraphTarget2;

	public PerformanceProfiler _prpProfilierTarget;

	[Button("SetupGraph", "")]
	public bool _bBuildGraphButton;

	[Button("RunProfling", "")]
	public bool _bRunProfilingButton;

	public bool _bRandomize;

	public void SetupGraph()
	{
		if (_bRandomize)
		{
			for (int i = 0; i < _ugbGraphTarget1._lstGraphYValues.Count; i++)
			{
				_ugbGraphTarget1._lstGraphYValues[i] = Random.Range(_ugbGraphTarget1._vecMinValues.y, _ugbGraphTarget1._vecMaxValues.y);
			}
		}
		_ugbGraphTarget1.SetupGraph();
	}

	public void RunProfling()
	{
		StartCoroutine(RunProfilingCoroutine());
	}

	public IEnumerator RunProfilingCoroutine()
	{
		yield return StartCoroutine(_prpProfilierTarget.RunProfile());
		_ugbGraphTarget1._lstGraphYValues = new List<float>(_prpProfilierTarget._lstTarget1FrameRate);
		_ugbGraphTarget2._lstGraphYValues = new List<float>(_prpProfilierTarget._lstTarget2FrameRate);
		_ugbGraphTarget1.SyncMinMaxValues(_ugbGraphTarget2);
		_ugbGraphTarget1.SetupGraph();
		_ugbGraphTarget2.SetupGraph();
	}
}
