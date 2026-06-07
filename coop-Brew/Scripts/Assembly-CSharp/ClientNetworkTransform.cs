using Unity.Netcode.Components;

public class ClientNetworkTransform : NetworkTransform
{
	protected override bool OnIsServerAuthoritative()
	{
		return false;
	}

	protected override void __initializeVariables()
	{
	}

	protected override void __initializeRpcs()
	{
	}

	protected internal override string __getTypeName()
	{
		return null;
	}
}
