using System;
using System.Collections.Generic;
using System.Linq;
using Data.Variables;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SciencePointUI : MonoBehaviour
{
	[SerializeField]
	private SciencePointLibrarySO _sciencePointLibrary;

	[SerializeField]
	private Transform _sciencePointParentUI;

	private void Awake()
	{
		SciencePointLibrarySO sciencePointLibrary = _sciencePointLibrary;
		sciencePointLibrary.OnSciencePointAdded = (Action<Color, int>)Delegate.Combine(sciencePointLibrary.OnSciencePointAdded, new Action<Color, int>(SciencePointAdded));
	}

	private void OnDestroy()
	{
		SciencePointLibrarySO sciencePointLibrary = _sciencePointLibrary;
		sciencePointLibrary.OnSciencePointAdded = (Action<Color, int>)Delegate.Remove(sciencePointLibrary.OnSciencePointAdded, new Action<Color, int>(SciencePointAdded));
	}

	private void SciencePointAdded(Color color, int amount)
	{
		UpdateUI();
	}

	private void UpdateUI()
	{
		for (int i = _sciencePointParentUI.childCount; i < _sciencePointLibrary.SciencePoints.Count; i++)
		{
			UnityEngine.Object.Instantiate(_sciencePointParentUI.GetChild(0), _sciencePointParentUI);
		}
		for (int j = 0; j < _sciencePointLibrary.SciencePoints.Count; j++)
		{
			KeyValuePair<Color, int> keyValuePair = _sciencePointLibrary.SciencePoints.ElementAt(j);
			Transform child = _sciencePointParentUI.GetChild(j);
			child.gameObject.SetActive(value: true);
			child.GetComponentInChildren<Image>().color = keyValuePair.Key;
			child.GetComponentInChildren<TextMeshProUGUI>().SetText(keyValuePair.Value.ToString());
		}
		for (int k = _sciencePointLibrary.SciencePoints.Count; k < _sciencePointParentUI.childCount; k++)
		{
			_sciencePointParentUI.GetChild(k).gameObject.SetActive(value: false);
		}
	}
}
