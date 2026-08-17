using System;

namespace JetBrains.Annotations;

internal sealed class ContractAnnotationAttribute : Attribute
{
	private string _003CContract_003Ek__BackingField;

	private bool _003CForceFullStates_003Ek__BackingField;

	public string Contract
	{
		get
		{
			return _003CContract_003Ek__BackingField;
		}
		private set
		{
			_003CContract_003Ek__BackingField = value;
		}
	}

	public bool ForceFullStates
	{
		get
		{
			return _003CForceFullStates_003Ek__BackingField;
		}
		private set
		{
			_003CForceFullStates_003Ek__BackingField = value;
		}
	}

	public ContractAnnotationAttribute(string contract)
	{
		_003CContract_003Ek__BackingField = contract;
		_003CForceFullStates_003Ek__BackingField = false;
	}

	public ContractAnnotationAttribute(string contract, bool forceFullStates)
	{
		_003CContract_003Ek__BackingField = contract;
		_003CForceFullStates_003Ek__BackingField = forceFullStates;
	}
}
