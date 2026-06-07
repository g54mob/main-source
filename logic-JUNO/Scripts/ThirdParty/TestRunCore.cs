using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestRunCore : MonoBehaviour
{
	public UIGraphBuilder _ugbGraphTarget1;

	public UIGraphBuilder _ugbGraphTarget2;

	public List<PerformanceProfiler> _prpProfilierTarget;

	public List<string> _strProfileDescription;

	public Text _uitDescriptionTextLabel;

	public bool _bNormalizeData;

	public bool _bProfileInProgress;

	public int _iProfileIndex;

	public void NextProfile()
	{
		if (_bProfileInProgress)
		{
			return;
		}
		_iProfileIndex++;
		_iProfileIndex %= _prpProfilierTarget.Count;
		for (int i = 0; i < _prpProfilierTarget.Count; i++)
		{
			if (!_prpProfilierTarget[_iProfileIndex]._bSkip)
			{
				break;
			}
			_iProfileIndex++;
			_iProfileIndex %= _prpProfilierTarget.Count;
		}
		_uitDescriptionTextLabel.text = _strProfileDescription[_iProfileIndex];
		StartCoroutine(RunProfile(_iProfileIndex));
	}

	private IEnumerator RunProfile(int iProfile)
	{
		_bProfileInProgress = true;
		yield return StartCoroutine(_prpProfilierTarget[iProfile].RunProfile());
		_ugbGraphTarget1._lstGraphYValues = new List<float>(_prpProfilierTarget[iProfile]._lstTarget1FrameRate);
		_ugbGraphTarget2._lstGraphYValues = new List<float>(_prpProfilierTarget[iProfile]._lstTarget2FrameRate);
		if (_bNormalizeData)
		{
			_ugbGraphTarget1.SyncMinMaxValues(_ugbGraphTarget2);
		}
		_ugbGraphTarget1.SetupGraph();
		_ugbGraphTarget2.SetupGraph();
		_bProfileInProgress = false;
	}
}
