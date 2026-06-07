using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class TraitFilterWindow : MonoBehaviour
{
	public GUIWindow Window;

	public UITrait TraitPrefabl;

	public GridLayoutGroup TraitPanel;

	public GameObject RequirePanel;

	public Toggle All;

	public Toggle Any;

	public float XMargin;

	public float YMargin;

	public int PreferredColumns = 7;

	[NonSerialized]
	private Action<Employee.Trait, Employee.Trait> _onOK;

	[NonSerialized]
	private Dictionary<Employee.Trait, UITrait> _traits;

	[NonSerialized]
	private List<Employee.Trait> _active = new List<Employee.Trait>();

	[NonSerialized]
	private List<Employee.Trait> _inactive = new List<Employee.Trait>();

	[NonSerialized]
	private int _maxActive;

	[NonSerialized]
	private int _maxInactive;

	private void Init(Employee.Trait active, Employee.Trait inactive, bool require)
	{
		if (_traits == null)
		{
			_traits = new Dictionary<Employee.Trait, UITrait>();
			foreach (Employee.Trait t in Enum.GetValues(typeof(Employee.Trait)).OfType<Employee.Trait>().OrderBy(Employee.TraitOrder))
			{
				if (t != Employee.Trait.None && !Employee.Trait.OldSole.HasFlag(t))
				{
					UITrait uITrait = UnityEngine.Object.Instantiate(TraitPrefabl);
					uITrait.SetTrait(t);
					uITrait.OnToggle.AddListener(delegate(UITrait.ToggleState x)
					{
						OnTraitToggle(t, x);
					});
					uITrait.transform.SetParent(TraitPanel.transform, false);
					_traits[t] = uITrait;
				}
			}
		}
		int preferredColumns = PreferredColumns;
		int num = Mathf.CeilToInt((float)_traits.Count / (float)preferredColumns);
		Window.rectTransform.sizeDelta = new Vector2((float)preferredColumns * (TraitPanel.cellSize.x + TraitPanel.spacing.x) + XMargin, (float)num * (TraitPanel.cellSize.y + TraitPanel.spacing.y) + YMargin + (float)(require ? 26 : 0));
		_active.Clear();
		_inactive.Clear();
		foreach (KeyValuePair<Employee.Trait, UITrait> trait in _traits)
		{
			trait.Value.CanRightClick = _maxInactive > 0;
			if (active.HasBits(trait.Key))
			{
				_active.Add(trait.Key);
				trait.Value.SetToggle(UITrait.ToggleState.On);
			}
			else if (inactive.HasBits(trait.Key))
			{
				_inactive.Add(trait.Key);
				trait.Value.SetToggle(UITrait.ToggleState.Off);
			}
			else
			{
				trait.Value.SetToggle(UITrait.ToggleState.None);
			}
		}
		All.isOn = false;
		Any.isOn = true;
		RequirePanel.SetActive(require);
	}

	private void OnTraitToggle(Employee.Trait t, UITrait.ToggleState s)
	{
		switch (s)
		{
		case UITrait.ToggleState.On:
			if (_active.Count >= _maxActive)
			{
				Employee.Trait key2 = _active[0];
				_traits[key2].SetToggle(UITrait.ToggleState.None);
				_active.RemoveAt(0);
			}
			_active.Add(t);
			_inactive.Remove(t);
			break;
		case UITrait.ToggleState.Off:
			if (_inactive.Count >= _maxInactive)
			{
				Employee.Trait key = _inactive[0];
				_traits[key].SetToggle(UITrait.ToggleState.None);
				_inactive.RemoveAt(0);
			}
			_inactive.Add(t);
			_active.Remove(t);
			break;
		case UITrait.ToggleState.None:
			_inactive.Remove(t);
			_active.Remove(t);
			break;
		}
	}

	public void Show(Employee.Trait active, Action<Employee.Trait, bool> onOK)
	{
		Show(active, Employee.Trait.None, int.MaxValue, 0, delegate(Employee.Trait x, Employee.Trait y)
		{
			onOK(x, All.isOn);
		}, true);
	}

	public void Show(Employee.Trait active, Employee.Trait inactive, int maxActive, int maxInactive, Action<Employee.Trait, Employee.Trait> onOK, bool require = false)
	{
		_maxActive = maxActive;
		_maxInactive = maxInactive;
		Init(active, inactive, require);
		_onOK = onOK;
		Window.Show();
	}

	public void OK()
	{
		if (_onOK != null)
		{
			_onOK((_active.Count == 0) ? Employee.Trait.None : _active.Aggregate((Employee.Trait x, Employee.Trait y) => x | y), (_inactive.Count == 0) ? Employee.Trait.None : _inactive.Aggregate((Employee.Trait x, Employee.Trait y) => x | y));
		}
		Window.Close();
	}
}
