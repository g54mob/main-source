using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using UnityEngine;

namespace Rewired.Glyphs;

[Serializable]
public class SpriteGlyphSet : GlyphSet
{
	[Serializable]
	public class Entry : EntryBase<Sprite>
	{
	}

	private List<Entry> _glyphs;

	public List<Entry> glyphs
	{
		get
		{
			return _glyphs;
		}
		set
		{
			_glyphs = value;
		}
	}

	public override int glyphCount
	{
		get
		{
			if (_glyphs != null)
			{
				List<Entry> list = _glyphs;
				return list._size;
			}
			return 0;
		}
	}

	public override EntryBase GetEntry(int index)
	{
		if (_glyphs != null)
		{
			List<Entry> list = _glyphs;
			if (index < list._size)
			{
				return list.get_Item(index);
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802696E0");
			ArgumentOutOfRangeException ex = new ArgumentOutOfRangeException("index");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802696E0");
			throw ex;
		}
		return null;
	}
}
