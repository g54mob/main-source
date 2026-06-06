using System;
using UnityEngine;
using UnityEngine.Localization;

[ExecuteAlways]
public abstract class LocalizeHandler<TValue, TReference> : MonoBehaviour where TReference : LocalizedReference, new()
{
	[SerializeField]
	protected TReference localizedAssetReference = new TReference();

	private bool _tracked;

	protected abstract UnityEngine.Object Target { get; }

	protected abstract string PropertyPath { get; }

	public TReference AssetReference
	{
		get
		{
			return localizedAssetReference;
		}
		set
		{
			UnregisterDrivenProperty();
			ClearChangeHandler();
			localizedAssetReference = value;
			if (base.isActiveAndEnabled)
			{
				RegisterChangeHandler();
			}
		}
	}

	private static bool IsPlaying => Application.isPlaying;

	private static bool IsChangingPlayMode
	{
		get
		{
			if (IsPlayingOrWillChangePlaymode)
			{
				return !IsPlaying;
			}
			return false;
		}
	}

	private static bool IsPlayingOrWillChangePlaymode => true;

	public event Action PropertyChanged;

	protected virtual void OnEnable()
	{
		if ((bool)Target)
		{
			RegisterChangeHandler();
		}
	}

	protected virtual void OnDisable()
	{
		UnregisterDrivenProperty();
		ClearChangeHandler();
	}

	protected virtual void OnDestroy()
	{
		UnregisterDrivenProperty();
		ClearChangeHandler();
	}

	protected abstract void RegisterChangeHandler();

	protected abstract void ClearChangeHandler();

	protected abstract void ApplyProperty(TValue value);

	protected abstract void RefreshProperty();

	protected virtual void UpdateValue(TValue value)
	{
		if ((bool)Target)
		{
			ApplyProperty(value);
			this.PropertyChanged?.Invoke();
		}
	}

	protected virtual void RegisterDrivenProperty()
	{
		if ((bool)Target)
		{
			_tracked = true;
			EditorPropertyDriver.RegisterProperty(Target, PropertyPath);
		}
	}

	protected virtual void UnregisterDrivenProperty()
	{
		if (_tracked && (bool)Target)
		{
			_tracked = false;
			EditorPropertyDriver.UnregisterProperty(Target, PropertyPath);
		}
	}

	protected virtual void RefreshDrivenProperty()
	{
	}
}
