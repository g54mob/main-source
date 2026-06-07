using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public abstract class UIColorMapper : MonoBehaviour
{
	public bool obeysController;

	public string labels;

	public bool secondaryMap;

	private bool _enabled;

	protected abstract void RefreshColors(Holder holder, int stateToApply = 0);

	private IList<ValueDropdownItem<int>> ColorList()
	{
		return null;
	}

	public void Init()
	{
	}

	public void Enable()
	{
	}

	public void Disable()
	{
	}

	public void ApplyColors(Holder holder, bool force = false)
	{
	}

	private void OnValidate()
	{
	}

	private void Test()
	{
	}
}
