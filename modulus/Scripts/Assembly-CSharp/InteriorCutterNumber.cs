using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InteriorCutterNumber : MonoBehaviour
{
	[SerializeField]
	private List<GameObject> _cutIntervalGameObjects = new List<GameObject>();

	[SerializeField]
	private TMP_Text _cutIntervalText;

	[SerializeField]
	private CutterUIInterval _cutterUIInterval;

	private void Awake()
	{
		CutterUIInterval cutterUIInterval = _cutterUIInterval;
		cutterUIInterval.OnCutsChanged = (Action<IReadOnlyList<int>>)Delegate.Combine(cutterUIInterval.OnCutsChanged, new Action<IReadOnlyList<int>>(UpdateDecals));
	}

	private void OnDestroy()
	{
		CutterUIInterval cutterUIInterval = _cutterUIInterval;
		cutterUIInterval.OnCutsChanged = (Action<IReadOnlyList<int>>)Delegate.Remove(cutterUIInterval.OnCutsChanged, new Action<IReadOnlyList<int>>(UpdateDecals));
	}

	private void UpdateDecals(IReadOnlyList<int> cuts)
	{
		for (int i = 0; i < _cutIntervalGameObjects.Count; i++)
		{
			_cutIntervalGameObjects[i].SetActive(i + 1 == _cutterUIInterval.CutInterval);
		}
		_cutIntervalText.SetText(_cutterUIInterval.CutInterval.ToString());
	}
}
