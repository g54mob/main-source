using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DrifterCounter : CounterBase
{
	[SerializeField]
	private ChildBehaviourCache<Toggle> _toggleCache;

	[SerializeField]
	private Sprite _isOnSprite;

	private List<Toggle> _toggles = new List<Toggle>(8);

	protected override void UpdateState()
	{
		foreach (Toggle toggle2 in _toggles)
		{
			toggle2.onValueChanged.RemoveListener(OnToggleValueChanged);
		}
		_toggles.Clear();
		_toggleCache.Reset();
		for (int i = base.Min; i <= base.Max; i++)
		{
			Toggle toggle = _toggleCache.Get(active: true);
			toggle.isOn = i <= base.Count;
			toggle.onValueChanged.AddListener(OnToggleValueChanged);
			if (toggle.targetGraphic is Image image)
			{
				image.overrideSprite = (toggle.isOn ? _isOnSprite : null);
			}
			_toggles.Add(toggle);
		}
		_toggleCache.Trim();
	}

	private void OnToggleValueChanged(bool value)
	{
		int num = base.Min;
		foreach (Toggle toggle in _toggles)
		{
			if (toggle.isOn != num <= base.Count)
			{
				if (num == base.Count)
				{
					UpdateState();
				}
				else
				{
					SetCount(num);
				}
				break;
			}
			num++;
		}
	}
}
