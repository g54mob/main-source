using UnityEngine;
using UnityEngine.Localization;

public abstract class LocalizeAssetHandler<TObject, TReference> : LocalizeHandler<TObject, TReference> where TObject : Object where TReference : LocalizedAsset<TObject>, new()
{
	private LocalizedAsset<TObject>.ChangeHandler _changeHandler;

	protected override void RegisterChangeHandler()
	{
		if (base.AssetReference != null)
		{
			if (_changeHandler == null)
			{
				_changeHandler = UpdateValue;
			}
			base.AssetReference.AssetChanged += _changeHandler;
		}
	}

	protected override void ClearChangeHandler()
	{
		if (base.AssetReference != null)
		{
			base.AssetReference.AssetChanged -= _changeHandler;
		}
	}
}
