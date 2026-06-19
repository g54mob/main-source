using System;
using Aggro.Core;
using Mirror;

public struct ActivationContext
{
	public ActivationContextType type;

	public Entity causer;

	[NonSerialized]
	public NetworkConnectionToClient connection;

	public ActivationContextSubType subType;

	public ActivationContext(ActivationContextType type)
	{
		this.type = type;
		causer = Entity.invalid;
		connection = null;
		subType = ActivationContextSubType.None;
	}

	public ActivationContext(ActivationContextType type, ActivationContextSubType subType)
	{
		this.type = type;
		causer = Entity.invalid;
		connection = null;
		this.subType = subType;
	}
}
