using System;
using System.Collections.Generic;
using Factory;
using Motorways.UI;
using UnityEngine;

public class LocaleDatabase : IReleasedFromScopeHandler
{
	public enum LocaleId
	{
		Unknown = 0,
		en_US = 1,
		ar = 2,
		bg = 3,
		ca = 4,
		cs = 5,
		cy = 6,
		da = 7,
		de = 8,
		el = 9,
		en_AU = 10,
		en_GB = 11,
		eo = 12,
		es_ES = 13,
		es_MX = 14,
		fi = 15,
		fr = 16,
		ga_IE = 17,
		hi = 18,
		hr = 19,
		hu = 20,
		id = 21,
		it = 22,
		ja = 23,
		ko = 24,
		mi = 25,
		ms = 26,
		nl = 27,
		nn_NO = 28,
		no = 29,
		pl = 30,
		pt_BR = 31,
		pt_PT = 32,
		ru = 33,
		sk = 34,
		sr = 35,
		sr_CS = 36,
		sr_Latin = 37,
		sv_SE = 38,
		sv_FI = 39,
		tr = 40,
		tg = 41,
		th = 42,
		uk = 43,
		zh_CN = 44,
		zh_HK = 45,
		zh_TW = 46
	}

	public static Diagnostics.Log.Channel Log = new Diagnostics.Log.Channel("Localization");

	public const LocaleId DefaultLocaleId = LocaleId.en_US;

	[Dependency]
	private IScope _scope;

	[Dependency]
	private IActivePlayer _player;

	[Dependency]
	private ISoftwareCapabilities _softwareCapabilities;

	[Dependency]
	private SupportedLocaleDatabase _supportedLocaleDatabase;

	private List<Locale> _locales = new List<Locale>();

	private Locale _currentLocale;

	private Locale _fallbackLocale;

	private List<WeakReference> _localizedObjects = new List<WeakReference>();

	public int LocaleCount => _locales.Count;

	public Locale CurrentLocale => _currentLocale;

	public Locale FallbackLocale => _fallbackLocale;

	public LocaleId CurrentLocaleId
	{
		get
		{
			if (_currentLocale == null)
			{
				return LocaleId.Unknown;
			}
			return _currentLocale.Id;
		}
		protected set
		{
			Locale locale = GetLocale(value);
			if (locale == null || _currentLocale == locale)
			{
				return;
			}
			_currentLocale = locale;
			int num = 0;
			while (num < _localizedObjects.Count)
			{
				if (!_localizedObjects[num].IsAlive)
				{
					_localizedObjects.RemoveAt(num);
					continue;
				}
				if (_localizedObjects[num].Target is ILocalized localized)
				{
					localized.HandleLocaleChanged(locale);
				}
				num++;
			}
		}
	}

	public Locale GetLocale(int index)
	{
		return _locales[index];
	}

	public Locale GetLocale(LocaleId localeId)
	{
		for (int i = 0; i < _locales.Count; i++)
		{
			if (_locales[i].Id == localeId)
			{
				return _locales[i];
			}
		}
		return null;
	}

	public Locale GetLocale(string localeIdString)
	{
		LocaleId result = LocaleId.Unknown;
		if (Enum.TryParse<LocaleId>(localeIdString, ignoreCase: false, out result))
		{
			return GetLocale(result);
		}
		return null;
	}

	public bool IsLocaleSelectable(LocaleId localeId)
	{
		return GetLocale(localeId)?.IsSelectable ?? false;
	}

	public int GetIndex(Locale locale)
	{
		for (int i = 0; i < _locales.Count; i++)
		{
			if (_locales[i] == locale)
			{
				return i;
			}
		}
		return -1;
	}

	public Locale MatchLocale(string locale)
	{
		Log.Info("Attempting to matching locale {0}.", locale);
		locale = locale.Replace("-", "_");
		string[] array = locale.Split('_');
		if (array.Length == 0)
		{
			return null;
		}
		string text = array[0];
		string text2 = text;
		if (text == "nb")
		{
			text = "no";
			text2 = "no";
		}
		if (array.Length > 1)
		{
			text2 = text + "_" + array[1];
		}
		if (text2 == "zh_Hant")
		{
			text2 = ((array.Length <= 2 || !(array[2] == "HK")) ? "zh_TW" : "zh_HK");
		}
		else if (text2 == "zh_Hans")
		{
			text2 = "zh_CN";
		}
		Locale locale2 = GetLocale(text2);
		if (locale2 != null)
		{
			return locale2;
		}
		text2 = text switch
		{
			"en" => "en_GB", 
			"es" => (array.Length <= 1) ? "es_ES" : "es_MX", 
			"ga" => "ga_IE", 
			"nn" => "nn_NO", 
			"pt" => "pt_BR", 
			"sv" => "sv_SE", 
			"zh" => (array.Length <= 2 || !(array[1] == "Hant")) ? "zh_CN" : ((!(array[2] == "HK")) ? "zh_HK" : "zh_TW"), 
			_ => text, 
		};
		Log.Info("Checking again with locale id {0}.", text2);
		locale2 = GetLocale(text2);
		if (locale2 != null)
		{
			return locale2;
		}
		if (text == "en")
		{
			locale2 = GetLocale(LocaleId.en_US);
			if (locale2 != null)
			{
				return locale2;
			}
		}
		return null;
	}

	public void AddLocalizedObject(ILocalized localizedObject)
	{
		_localizedObjects.Add(new WeakReference(localizedObject));
	}

	public void RemoveLocalizedObject(ILocalized localizedObject)
	{
		for (int i = 0; i < _localizedObjects.Count; i++)
		{
			if (_localizedObjects[i].Target == localizedObject)
			{
				_localizedObjects.RemoveAt(i);
				break;
			}
		}
	}

	private void OnPlayerDataChanged()
	{
		LocaleId localeId = _player.LocaleId;
		if (localeId == LocaleId.Unknown || GetLocale(localeId) == null)
		{
			LocaleId localeId2 = _softwareCapabilities.PreferredLocaleId;
			if (GetLocale(localeId2) == null)
			{
				Log.Warn("The preferred locale {0} is not a supported locale. Falling back to {1}.", localeId2, LocaleId.en_US);
				localeId2 = LocaleId.en_US;
			}
			_player.LocaleId = localeId2;
		}
		else
		{
			Log.Info("Using previously-configured locale {0}.", localeId);
		}
		CurrentLocaleId = _player.LocaleId;
	}

	public bool Load()
	{
		_locales.Clear();
		float realtimeSinceStartup = Time.realtimeSinceStartup;
		IContentProfile contentProfile = _scope.Get<IContentProfile>();
		new List<LocaleId>(contentProfile.SupportedLocales);
		bool canUseIncompleteLocales = contentProfile.CanUseIncompleteLocales;
		foreach (LocaleId supportedLocale in _supportedLocaleDatabase.SupportedLocales)
		{
			string text = "Locales/" + supportedLocale;
			JSON.Dictionary dictionary = (JSON.Dictionary)JSON.Load(text);
			if (dictionary == null)
			{
				Log.Error("LocaleDatabase: Failed to load JSON for locale '{0}'.", text);
				continue;
			}
			Locale locale = Locale.FromJSON(dictionary, this, _scope);
			if (locale == null)
			{
				Log.Error("LocaleDatabase: Failed to parse JSON for locale '{0}'.", text);
				continue;
			}
			if (!locale.IsComplete && !canUseIncompleteLocales)
			{
				Log.Error("LocaleDatabase: Skipping incomplete locale '{0}'.", locale.Id);
				continue;
			}
			int i;
			for (i = 0; i < _locales.Count && _locales[i].Id < locale.Id; i++)
			{
			}
			_locales.Insert(i, locale);
		}
		_player.DataChanged += OnPlayerDataChanged;
		LocaleId currentLocaleId = LocaleId.en_US;
		CurrentLocaleId = currentLocaleId;
		_fallbackLocale = CurrentLocale;
		float realtimeSinceStartup2 = Time.realtimeSinceStartup;
		Log.Info("Loaded locales in {0}s.", realtimeSinceStartup2 - realtimeSinceStartup);
		return true;
	}

	public void OnReleasedFromScope(IScope scope)
	{
		_player.DataChanged -= OnPlayerDataChanged;
	}
}
