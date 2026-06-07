public class StartupStat
{
	public int enterMoney;

	public int exitMoney;

	public int daysUntilExit;

	public bool bankrupt;

	public StartupStat()
	{
		enterMoney = 0;
		exitMoney = 0;
		daysUntilExit = 0;
		bankrupt = false;
	}

	public StartupStat(int enterMoney = 0, int exitMoney = 0, int daysUntilExit = 0, bool bankrupt = false)
	{
		this.enterMoney = enterMoney;
		this.exitMoney = exitMoney;
		this.daysUntilExit = daysUntilExit;
		this.bankrupt = bankrupt;
	}

	public bool WasProfitable()
	{
		return exitMoney - enterMoney > 0;
	}
}
