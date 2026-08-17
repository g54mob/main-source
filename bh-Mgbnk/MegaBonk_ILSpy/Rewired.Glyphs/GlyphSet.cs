using System;
using Cpp2ILInjected;
using UnityEngine;

namespace Rewired.Glyphs;

[Serializable]
public abstract class GlyphSet : ScriptableObject
{
	[Serializable]
	public abstract class EntryBase
	{
		private string _key;

		public string key
		{
			get
			{
				return _key;
			}
			set
			{
				_key = value;
			}
		}

		public abstract object GetValue();
	}

	[Serializable]
	public abstract class EntryBase<TValue> : EntryBase
	{
		private TValue _value;

		public TValue value
		{
			get
			{
				//IL_000d: Expected O, but got I
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Rewired.Glyphs.GlyphSet+EntryBase`1<TValue>)+18]");
				return (TValue)0;
			}
			set
			{
			}
		}

		public override object GetValue()
		{
			//IL_000d: Expected O, but got I
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Rewired.Glyphs.GlyphSet+EntryBase`1<TValue>)+18]");
			return 0;
		}
	}

	private string[] _baseKeys;

	public string[] baseKeys
	{
		get
		{
			return _baseKeys;
		}
		set
		{
			_baseKeys = value;
		}
	}

	public abstract int glyphCount { get; }

	public abstract EntryBase GetEntry(int index);
}
