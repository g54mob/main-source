using System;

public class UncoupleEventArgs : EventArgs
{
	public Coupler thisCoupler;

	public Coupler otherCoupler;

	public bool viaChainInteraction;

	public bool dueToBrokenCouple;

	public UncoupleEventArgs(Coupler thisCoupler, Coupler otherCoupler, bool viaChainInteraction, bool dueToBrokenCouple)
	{
		this.thisCoupler = thisCoupler;
		this.otherCoupler = otherCoupler;
		this.viaChainInteraction = viaChainInteraction;
		this.dueToBrokenCouple = dueToBrokenCouple;
	}
}
