using System;
using UnityEngine;

namespace Rewired.Glyphs;

public abstract class ControllerElementGlyph : ControllerElementGlyphBase
{
	[NonSerialized]
	private ActionElementMap _actionElementMap;

	[NonSerialized]
	private ControllerElementIdentifier _controllerElementIdentifier;

	[NonSerialized]
	private AxisRange _axisRange;

	public ActionElementMap actionElementMap
	{
		get
		{
			return _actionElementMap;
		}
		set
		{
			_actionElementMap = value;
		}
	}

	public ControllerElementIdentifier controllerElementIdentifier
	{
		get
		{
			return _controllerElementIdentifier;
		}
		set
		{
			_controllerElementIdentifier = value;
		}
	}

	public AxisRange axisRange
	{
		get
		{
			return _axisRange;
		}
		set
		{
			_axisRange = value;
		}
	}

	protected override void Update()
	{
		if (ReInput.iDoaxepFyYCUwmDGjxXRIVvgLboF)
		{
			GameObject glyphOrTextPrefabOrDefault = base.GetGlyphOrTextPrefabOrDefault();
			if (base._lastGlyphOrTextPrefab != glyphOrTextPrefabOrDefault)
			{
				GameObject glyphOrTextPrefabOrDefault2 = base.GetGlyphOrTextPrefabOrDefault();
				base._lastGlyphOrTextPrefab = glyphOrTextPrefabOrDefault2;
				base.RequireRebuild();
			}
		}
		if (!ReInput.iDoaxepFyYCUwmDGjxXRIVvgLboF)
		{
			return;
		}
		if (_actionElementMap == null)
		{
			if (_controllerElementIdentifier == null)
			{
				base.Hide();
				return;
			}
			if (_actionElementMap == null)
			{
				if (_controllerElementIdentifier != null)
				{
					int num = base.ShowGlyphsOrText(_controllerElementIdentifier, _axisRange);
				}
				goto IL_0176;
			}
		}
		int num2 = base.ShowGlyphsOrText(_actionElementMap);
		goto IL_0176;
		IL_0176:
		base.EvaluateObjectVisibility();
	}
}
