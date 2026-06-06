using TMPro;
using UnityEngine;
using UnityEngine.Localization;

[RequireComponent(typeof(TMP_Text))]
public class LocalizeFontHandler : LocalizeAssetHandler<TMP_FontAsset, LocalizedTmpFont>
{
	private TMP_Text _target;

	protected override Object Target => _target;

	protected override string PropertyPath => "m_fontAsset";

	private void Awake()
	{
		_target = GetComponent<TMP_Text>();
	}

	protected override void ApplyProperty(TMP_FontAsset value)
	{
		if ((bool)_target)
		{
			_target.font = value;
		}
	}

	protected override void RefreshProperty()
	{
		_target.SetAllDirty();
	}
}
