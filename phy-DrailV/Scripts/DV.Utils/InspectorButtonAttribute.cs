using System;
using UnityEngine;

[AttributeUsage(AttributeTargets.Field)]
public class InspectorButtonAttribute : PropertyAttribute
{
	public static float kDefaultButtonWidth = 80f;

	public readonly string MethodName;

	public readonly bool enabledInEditMode;

	public readonly bool enabledInPlayMode;

	private float _buttonWidth = kDefaultButtonWidth;

	public float ButtonWidth
	{
		get
		{
			return _buttonWidth;
		}
		set
		{
			_buttonWidth = value;
		}
	}

	public InspectorButtonAttribute(string MethodName, bool edit = true, bool play = true)
	{
		this.MethodName = MethodName;
		enabledInEditMode = edit;
		enabledInPlayMode = play;
	}
}
