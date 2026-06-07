using System;

[Serializable]
public struct ViewRegistry
{
	public DashboardView dashboard;

	public UpgradesView upgrades;

	public WorldView world;

	public DebuggerView debugger;

	public AuctionView auction;

	public SequelView sequel;

	public ResearchView research;
}
