using System;
using System.Collections.Generic;
using UnityEngine;

public class InGameButtonHintsUI : MonoBehaviour
{
	[Serializable]
	public class InGameHintButtons
	{
		public List<IngameButtonHint> buttons;
	}

	private const int BUTTONS_PER_UPDATE = int.MaxValue;

	public GameObject container;

	public List<InGameHintButtons> hintButtonRows;

	private int _nextButtonIndexToUpdate;

	private bool _hasInitialized;

	private void LateUpdate()
	{
		container.SetActive(Manager.prefs.showKeyHints);
		if (!container.activeInHierarchy)
		{
			return;
		}
		int num = 0;
		int num2 = 0;
		int num3 = (_hasInitialized ? int.MaxValue : int.MaxValue);
		foreach (InGameHintButtons hintButtonRow in hintButtonRows)
		{
			List<IngameButtonHint> buttons = hintButtonRow.buttons;
			if (buttons.Count == 0)
			{
				continue;
			}
			Vector3 localPosition = buttons[0].transform.localPosition;
			foreach (IngameButtonHint item in buttons)
			{
				if (num >= _nextButtonIndexToUpdate && num2 < num3)
				{
					item.UpdateVisuals();
					num2++;
					_nextButtonIndexToUpdate = num + 1;
				}
				num++;
				if (item.isButtonActive)
				{
					item.transform.localPosition = localPosition;
					localPosition -= new Vector3(1.5f, 0f, 0f);
				}
			}
		}
		if (_nextButtonIndexToUpdate >= num)
		{
			_nextButtonIndexToUpdate = 0;
		}
		_hasInitialized = true;
	}
}
