using System;
using System.Collections.Generic;
using UnityEngine;

namespace Rewired.Glyphs.UnityUI;

public class UnityUIPlayerControllerElementGlyph : UnityUIPlayerControllerElementGlyphBase
{
	private int _playerId;

	private string _actionName;

	[NonSerialized]
	private int _actionId;

	[NonSerialized]
	private bool _actionIdCached;

	public override int playerId
	{
		get
		{
			return _playerId;
		}
		set
		{
			_playerId = value;
		}
	}

	public override int actionId
	{
		get
		{
			if (!_actionIdCached)
			{
				CacheActionId();
				return _actionId;
			}
			return _actionId;
		}
		set
		{
			if (ReInput.iDoaxepFyYCUwmDGjxXRIVvgLboF)
			{
				ReInput.MappingHelper mapping = ReInput.mapping;
				InputAction action = mapping.GetAction(value);
				if (action != null)
				{
					_actionName = action._name;
					CacheActionId();
				}
				else
				{
					int num = default(int);
					string text = num.ToString();
					string message = "Invalid Action id: " + text;
					Debug.LogError(message);
				}
			}
		}
	}

	public string actionName
	{
		get
		{
			return _actionName;
		}
		set
		{
			_actionName = value;
			CacheActionId();
		}
	}

	private void CacheActionId()
	{
		//IL_0072: Expected I4, but got I8
		if (ReInput.iDoaxepFyYCUwmDGjxXRIVvgLboF)
		{
			ReInput.MappingHelper mapping = ReInput.mapping;
			InputAction action = mapping.GetAction(_actionName);
			if (action != null)
			{
				_actionId = action._id;
				_actionIdCached = true;
			}
			else
			{
				_actionId = -1;
				_actionIdCached = true;
			}
		}
	}

	public UnityUIPlayerControllerElementGlyph()
	{
		//IL_000f: Expected I4, but got I8
		_actionId = -1;
		List<ActionElementMap> tempAems = new List<ActionElementMap>();
		base._tempAems = tempAems;
		base._tempCombinedElementAems = new List<ActionElementMap>();
		base._group1Objects = new List<GlyphOrTextObject>();
		base._group2Objects = new List<GlyphOrTextObject>();
		((UnityUIControllerElementGlyphBase)this)._002Ector();
	}
}
