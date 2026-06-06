using System;
using PajamaLlama;
using TMPro;
using UnityEngine;
using UnityEngine.PajamaLlama;
using UnityEngine.UI;

public class TechTreePanelInfoUnlockable : MonoBehaviour
{
	[Serializable]
	private class Settings
	{
		[SerializeField]
		[TypesDerivedFrom(typeof(ResearchUnlockable))]
		private string _type;

		public Color BackgroundColor;

		private Type _unlockableType;

		public bool IsSettingsOf(Type type)
		{
			if (_unlockableType == null)
			{
				_unlockableType = Type.GetType(_type);
			}
			return type == _unlockableType;
		}
	}

	[SerializeField]
	private Image _background;

	[SerializeField]
	private Image _icon;

	[SerializeField]
	private TextMeshProUGUI _title;

	[SerializeField]
	private TextMeshProUGUI _description;

	[SerializeField]
	private BuildablePropertiesBar _properties;

	[SerializeField]
	[NamedArrayElement(new string[] { "_type" })]
	private Settings[] _settings;

	private Color _backgroundColor;

	private void Awake()
	{
		_backgroundColor = _background.color;
	}

	public void Initialize(ResearchUnlockable unlockable)
	{
		_icon.sprite = unlockable.GetIcon();
		_title.text = unlockable.GetName();
		_description.text = unlockable.GetDescription();
		if (TryGetUnlockableSettings(out var settings, unlockable))
		{
			_background.color = settings.BackgroundColor;
		}
		else
		{
			_background.color = _backgroundColor;
		}
		if (unlockable is BuildableProperties properties)
		{
			_properties.Initialize(properties);
		}
		else
		{
			_properties.gameObject.SetActive(value: false);
		}
	}

	private bool TryGetUnlockableSettings(out Settings settings, ResearchUnlockable unlockable)
	{
		if (unlockable is ResearchUnlockableGroup { Unlockables: var unlockables })
		{
			foreach (ResearchUnlockable unlockable2 in unlockables)
			{
				if (TryGetUnlockableSettings(out settings, unlockable2))
				{
					return true;
				}
			}
			settings = null;
			return false;
		}
		for (int j = 0; j < _settings.Length; j++)
		{
			settings = _settings[j];
			if (settings.IsSettingsOf(unlockable.GetType()))
			{
				return true;
			}
		}
		settings = null;
		return false;
	}
}
