using Unity.Netcode.Components;

public class ClientNetworkAnimator : NetworkAnimator
{
	protected override bool OnIsServerAuthoritative()
	{
		return false;
	}

	public void ReinitializeAfterRebind()
	{
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
