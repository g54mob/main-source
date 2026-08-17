using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Rewired.Utils.Libraries.TinyJson;
using UnityEngine;

namespace Rewired.Localization;

public class LocalizedStringProvider : LocalizedStringProviderBase
{
	private TextAsset _localizedStringsFile;

	[NonSerialized]
	private Dictionary<string, string> _dictionary;

	[NonSerialized]
	private bool _initialized;

	protected virtual Dictionary<string, string> dictionary
	{
		get
		{
			return _dictionary;
		}
		set
		{
			_dictionary = value;
		}
	}

	public virtual TextAsset localizedStringsFile
	{
		get
		{
			return _localizedStringsFile;
		}
		set
		{
			_localizedStringsFile = value;
			base.Reload();
		}
	}

	protected override bool initialized => _initialized;

	protected override bool Initialize()
	{
		return _initialized = TryLoadLocalizedStringData();
	}

	protected virtual bool TryLoadLocalizedStringData()
	{
		//IL_0121: Expected I4, but got O
		_dictionary.Clear();
		if (_localizedStringsFile != null)
		{
			if ((object)_localizedStringsFile == null)
			{
				NullReferenceException ex = new NullReferenceException();
				return (byte)(int)ex != 0;
			}
			string text = _localizedStringsFile.text;
			Dictionary<string, string> dictionary = JsonParser.FromJson<Dictionary<string, string>>(text);
			_dictionary = dictionary;
		}
		int count = _dictionary.Count;
		int num = count ^ count;
		int num2 = count & num;
		bool flag = num2 < 0;
		bool flag2 = count < 0;
		bool flag3 = count == 0;
		bool flag4 = flag2 == flag;
		bool flag5 = !flag3;
		return flag5 & flag4;
	}

	protected unsafe override bool TryGetLocalizedString(string key, out string result)
	{
		//IL_005d: Expected I4, but got O
		if (_initialized)
		{
			if (_dictionary != null)
			{
				return ((Dictionary<object, object>)(object)_dictionary).TryGetValue((object)key, out System.Runtime.CompilerServices.Unsafe.As<string, object>(ref result));
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
		ref string reference = ref *(string*)null;
		return false;
	}

	public LocalizedStringProvider()
	{
		Dictionary<string, string> dictionary = new Dictionary<string, string>();
		_dictionary = dictionary;
		((MonoBehaviour)this)._002Ector();
	}
}
