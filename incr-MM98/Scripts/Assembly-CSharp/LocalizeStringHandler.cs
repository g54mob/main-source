using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.SmartFormat.PersistentVariables;

[RequireComponent(typeof(TMP_Text))]
public class LocalizeStringHandler : LocalizeHandler<string, LocalizedString>
{
	private TMP_Text _target;

	private LocalizedString.ChangeHandler _changeHandler;

	private Dictionary<string, object> _arguments;

	protected override Object Target => _target;

	protected override string PropertyPath => "m_text";

	public TMP_Text Text => _target;

	protected virtual void Awake()
	{
		_target = GetComponent<TMP_Text>();
	}

	protected override void ApplyProperty(string value)
	{
		if ((bool)_target)
		{
			_target.text = value;
		}
	}

	protected override void RefreshProperty()
	{
		_target.SetAllDirty();
	}

	protected override void RegisterChangeHandler()
	{
		if (base.AssetReference != null)
		{
			if (_changeHandler == null)
			{
				_changeHandler = UpdateValue;
			}
			base.AssetReference.StringChanged += _changeHandler;
		}
	}

	protected override void ClearChangeHandler()
	{
		if (base.AssetReference != null)
		{
			base.AssetReference.StringChanged -= _changeHandler;
		}
	}

	public void RefreshString()
	{
		base.AssetReference?.RefreshString();
	}

	public void SetLocalizedString(LocalizedString localized)
	{
		base.AssetReference = localized;
	}

	public void SetValue<T>(T value)
	{
		SetValue("value", value);
	}

	public void SetValue<T>(string key, T value)
	{
		if (base.AssetReference[key] is Variable<T> variable)
		{
			variable.Value = value;
		}
	}

	public void SetVariable(string key, IVariable variable)
	{
		base.AssetReference[key] = variable;
	}

	public T GetVariable<T>(string key) where T : class, IVariable
	{
		return base.AssetReference[key] as T;
	}
}
