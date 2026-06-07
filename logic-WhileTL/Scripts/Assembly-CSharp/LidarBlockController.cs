using System;

public class LidarBlockController : ActiveComponent
{
	private LidarData lidarData;

	public string LidarName { get; private set; }

	public LidarData LidarData => lidarData ?? (lidarData = (LidarData)Logic.GetLidarDataByKeyName(LidarName).Clone());

	public override void Init()
	{
		throw new NotImplementedException("Use Init(string LidarKeyName)");
	}

	public void Init(string LidarKeyName)
	{
		if (!base.IsInited)
		{
			LidarName = LidarKeyName;
			base.OnInit();
		}
	}
}
