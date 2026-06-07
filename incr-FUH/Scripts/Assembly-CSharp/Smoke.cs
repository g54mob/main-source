using System.Collections.Generic;

public class Smoke : BaseBuildingWorker
{
	public class MyGlobalInfo : BaseGlobalInfo
	{
		public BaseShardYLevelAttribute LevelUpAttribute = new BaseShardYLevelAttribute("LevelUp", 10, (int l) => l + 999, () => true);

		public override List<BaseSavableAttribute> GetStaticAttributes()
		{
			return new List<BaseSavableAttribute> { LevelUpAttribute };
		}

		public override bool CanBuild()
		{
			return LevelUpAttribute.IsEnabled;
		}

		public override int MaxBuilding()
		{
			return LevelUpAttribute.Level;
		}
	}

	public static MyGlobalInfo GlobalInfo = new MyGlobalInfo();

	public override BaseGlobalInfo GetGlobalInfo()
	{
		return GlobalInfo;
	}

	public override List<BaseSavableAttribute> GetInstanceAttributes()
	{
		return new List<BaseSavableAttribute>();
	}
}
