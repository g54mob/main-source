using Rewired.Utils;

internal class cihSdumOkhfHwMqEzvWBvPwoPMhj : STIUvPhIyXcNOxWuVdBheFCenUKz
{
	public readonly int sXxDDehzEYcvRSSypalSjuieoQjcB;

	public readonly int BpxqbnpHKJiiCcOLkrNWWjkwUCDm;

	public readonly int heXAeokyuQqSMjZWGbHvhtVkrwAxB;

	public readonly int KpZpPlUIMjnZPKDjkeekGRImhSdGb;

	public readonly uint rVlNXVZzMSKDRWVRIHCUpFETvSYO;

	public readonly uint ortDPxhyLCNkkbCoCpxyGjcrDrXiA;

	public readonly int gAwOVmblNMZwmuDUfSxbGsVhDjTS;

	private readonly int KDgfIRDYfaiGnPWUgHIODfKlasTFb;

	public uint oKfisTfEqiofzjYiNjpRWiReMqMP;

	public int IRKkxyDBNjFhSckgwDTBFLfLEaxhA
	{
		get
		{
			if (oKfisTfEqiofzjYiNjpRWiReMqMP < sXxDDehzEYcvRSSypalSjuieoQjcB || oKfisTfEqiofzjYiNjpRWiReMqMP > BpxqbnpHKJiiCcOLkrNWWjkwUCDm)
			{
				return -1;
			}
			int num = (int)((oKfisTfEqiofzjYiNjpRWiReMqMP - sXxDDehzEYcvRSSypalSjuieoQjcB) / KDgfIRDYfaiGnPWUgHIODfKlasTFb * 4500);
			if (num >= 36000)
			{
				num = 0;
			}
			return num;
		}
	}

	public cihSdumOkhfHwMqEzvWBvPwoPMhj(byte P_0, ushort P_1, ushort P_2, int P_3, int P_4, int P_5, int P_6, int P_7, int P_8, uint P_9, uint P_10, int P_11)
		: base(P_0, P_1, P_2, P_3, P_4)
	{
		sXxDDehzEYcvRSSypalSjuieoQjcB = P_5;
		BpxqbnpHKJiiCcOLkrNWWjkwUCDm = P_6;
		rVlNXVZzMSKDRWVRIHCUpFETvSYO = P_9;
		ortDPxhyLCNkkbCoCpxyGjcrDrXiA = P_10;
		gAwOVmblNMZwmuDUfSxbGsVhDjTS = P_11;
		heXAeokyuQqSMjZWGbHvhtVkrwAxB = P_5 - 1;
		if (heXAeokyuQqSMjZWGbHvhtVkrwAxB < 0)
		{
			heXAeokyuQqSMjZWGbHvhtVkrwAxB = P_6 + 1;
		}
		KpZpPlUIMjnZPKDjkeekGRImhSdGb = -1;
		int num = P_6 - P_5 + 1;
		KDgfIRDYfaiGnPWUgHIODfKlasTFb = MathTools.Clamp(num / 8, 1, int.MaxValue);
		kYYZoFOujeTfgNBlwBPSkFgjuooMA();
	}

	public virtual void qWZkYFmlqkiLyAcLgoMQvgzjAlEz()
	{
		oKfisTfEqiofzjYiNjpRWiReMqMP = (uint)heXAeokyuQqSMjZWGbHvhtVkrwAxB;
	}
}
