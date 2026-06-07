using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class InteriorCutterRedLine : MonoBehaviour
{
	[SerializeField]
	private List<DecalProjector> _decalLines = new List<DecalProjector>();

	[SerializeField]
	private CutterUIInterval _cutterUIInterval;

	[SerializeField]
	private Material _defaultMaterial;

	[SerializeField]
	private Material _highlightMaterial;

	private readonly List<bool> _decalStates = new List<bool>();

	private void Awake()
	{
		CutterUIInterval cutterUIInterval = _cutterUIInterval;
		cutterUIInterval.OnCutsChanged = (Action<IReadOnlyList<int>>)Delegate.Combine(cutterUIInterval.OnCutsChanged, new Action<IReadOnlyList<int>>(UpdateDecals));
		_cutterUIInterval.OnCutHighlight += HighlightCut;
	}

	private void OnDestroy()
	{
		CutterUIInterval cutterUIInterval = _cutterUIInterval;
		cutterUIInterval.OnCutsChanged = (Action<IReadOnlyList<int>>)Delegate.Remove(cutterUIInterval.OnCutsChanged, new Action<IReadOnlyList<int>>(UpdateDecals));
		_cutterUIInterval.OnCutHighlight -= HighlightCut;
	}

	private void UpdateDecals(IReadOnlyList<int> cuts)
	{
		_decalStates.Clear();
		foreach (DecalProjector decalLine in _decalLines)
		{
			decalLine.enabled = false;
			_decalStates.Add(item: false);
		}
		foreach (int cut in cuts)
		{
			int index = cut + _decalLines.Count / 2;
			_decalLines[index].enabled = true;
			_decalStates[index] = true;
		}
	}

	private void HighlightCut(int index, bool toggle)
	{
		_decalLines[index].enabled = toggle || _decalStates[index];
		_decalLines[index].material = (toggle ? _highlightMaterial : _defaultMaterial);
	}
}
