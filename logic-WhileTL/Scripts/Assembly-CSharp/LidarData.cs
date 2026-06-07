using System;
using App.Data;

public class LidarData : BaseKeyData, ICloneable
{
	public int Front;

	public int Side;

	public int Behind;

	public string ReqUnlock;

	public int Servers;

	public bool Extra;

	public bool CanBuy;

	public int MoneyCost;

	public LidarData()
	{
	}

	public LidarData(int front, int side, int behind, string reqUnlock, int servers, bool extra, bool canBuy, int moneyCost)
	{
		Front = front;
		Side = side;
		Behind = behind;
		ReqUnlock = reqUnlock;
		Servers = servers;
		Extra = extra;
		CanBuy = canBuy;
		MoneyCost = moneyCost;
	}

	public object Clone()
	{
		return new LidarData(Front, Side, Behind, (string)ReqUnlock.Clone(), Servers, Extra, CanBuy, MoneyCost)
		{
			KeyName = ((KeyName == null) ? null : ((string)KeyName.Clone()))
		};
	}
}
