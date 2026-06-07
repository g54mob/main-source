using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RadiusResizer : CounterBase
{
	[SerializeField]
	private List<Toggle> _toggles;

	private void Awake()
	{
		foreach (AnimatedToggle toggle in _toggles)
		{
			toggle.onValueChanged.AddListener(OnToggleValueChanged);
		}
	}

	public void Initialize(int count)
	{
		Initialize(0, _toggles.Count - 1, count);
	}

	protected override void UpdateState()
	{
		for (int i = 0; i < _toggles.Count; i++)
		{
			_toggles[i].SetIsOnWithoutNotify(i <= base.Count);
		}
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
