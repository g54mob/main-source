using System;

namespace JetBrains.Annotations;

internal sealed class MacroAttribute : Attribute
{
	private string _003CExpression_003Ek__BackingField;

	private int _003CEditable_003Ek__BackingField;

	private string _003CTarget_003Ek__BackingField;

	public string Expression
	{
		get
		{
			return _003CExpression_003Ek__BackingField;
		}
		set
		{
			_003CExpression_003Ek__BackingField = value;
		}
	}

	public int Editable
	{
		get
		{
			return _003CEditable_003Ek__BackingField;
		}
		set
		{
			_003CEditable_003Ek__BackingField = value;
		}
	}

	public string Target
	{
		get
		{
			return _003CTarget_003Ek__BackingField;
		}
		set
		{
			_003CTarget_003Ek__BackingField = value;
		}
	}
}
