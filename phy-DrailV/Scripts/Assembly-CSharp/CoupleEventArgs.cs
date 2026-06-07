using System;

public class CoupleEventArgs : EventArgs
{
	public Coupler thisCoupler;

	public Coupler otherCoupler;

	public bool viaChainInteraction;

	public CoupleEventArgs(Coupler thisCoupler, Coupler otherCoupler, bool viaChainInteraction)
	{
		this.thisCoupler = thisCoupler;
		this.otherCoupler = otherCoupler;
		this.viaChainInteraction = viaChainInteraction;
	}
}
