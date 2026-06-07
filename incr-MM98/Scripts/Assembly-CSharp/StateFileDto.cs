using MessagePack;

[MessagePackObject(false)]
public class StateFileDto
{
	[Key(0)]
	public int Version = 3;

	[Key(1)]
	public long SavedAtUnixSecondsUtc;

	[Key(2)]
	public StudioStateDto Studio = new StudioStateDto();

	[Key(3)]
	public GameStateDto Game = new GameStateDto();

	[Key(4)]
	public SequelStateDto Sequel = new SequelStateDto();

	[Key(5)]
	public HistoryStateDto History = new HistoryStateDto();

	[Key(6)]
	public ResourceStateDto Resources = new ResourceStateDto();

	[Key(7)]
	public PrestigeStateDto Prestige = new PrestigeStateDto();

	[Key(8)]
	public GnormanStateDto Gnorman = new GnormanStateDto();

	[Key(9)]
	public UpgradeStateDto Upgrades = new UpgradeStateDto();

	[Key(10)]
	public ResearchStateDto Research = new ResearchStateDto();

	[Key(11)]
	public OperationStateDto Operations = new OperationStateDto();

	[Key(12)]
	public DebuggerStateDto Debugger = new DebuggerStateDto();

	[Key(13)]
	public DatacenterStateDto Datacenters = new DatacenterStateDto();

	[Key(14)]
	public CustomizationStateDto Customization = new CustomizationStateDto();

	[Key(15)]
	public MetricsStateDto Metrics = new MetricsStateDto();

	[Key(16)]
	public AchievementStateDto Achievements = new AchievementStateDto();

	[Key(17)]
	public IRCStateDto IRC = new IRCStateDto();

	[Key(18)]
	public AuctionStateDto Auction = new AuctionStateDto();
}
