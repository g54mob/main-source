using Rewired.Utils.Classes.Data;

internal class nZeIQQWnQohhanyhWEOObGRunlRc : QTwvMqRjxXBwLOoUpuezGnwheUbM
{
	public int UPILHvpUhOboiCfuxrRyJmdvexgX;

	public double JvQpIjDMGtWARQTgLxRmOGCfXPOS;

	public readonly int QkBbJvDkbaJPvEsdFqAXIABEPXngA;

	public readonly int RaIsqvtUKEOHIIQKwKVozEaykull;

	public readonly bool ATSDTmhniXiOXMRSFkzPApXlVtPu;

	public readonly int mVdSJpTizCPSmELauptBNeePhIst;

	public readonly int jJXhScDwWWqSiwEYNxvKhkaRKcBL;

	public readonly int zcdcXFyICVBJwnswcJcxcrWiFuR;

	public nZeIQQWnQohhanyhWEOObGRunlRc(byte P_0, HIDInfo P_1, bool P_2, int P_3)
		: base(P_0, P_1)
	{
		QkBbJvDkbaJPvEsdFqAXIABEPXngA = ((P_1.bitSize > 0) ? ((P_1.bitSize + 8 - 1) / 8) : 0);
		RaIsqvtUKEOHIIQKwKVozEaykull = P_1.dataIndex;
		ATSDTmhniXiOXMRSFkzPApXlVtPu = P_2;
		mVdSJpTizCPSmELauptBNeePhIst = P_1.logicalMin;
		jJXhScDwWWqSiwEYNxvKhkaRKcBL = P_1.logicalMax;
		zcdcXFyICVBJwnswcJcxcrWiFuR = P_3;
	}

	public virtual void fgIIGdaocgEdOQdxJEoFEWaiiWcAc(NativeBuffer P_0, double P_1)
	{
		if (P_0 == null || P_0[0] != ojLWWKRknmirMQCCbmKCWZUFqDzy)
		{
			return;
		}
		JvQpIjDMGtWARQTgLxRmOGCfXPOS = P_1;
		int num = 0;
		if (QkBbJvDkbaJPvEsdFqAXIABEPXngA > 1)
		{
			for (int i = 0; i < QkBbJvDkbaJPvEsdFqAXIABEPXngA; i++)
			{
				num |= P_0[RaIsqvtUKEOHIIQKwKVozEaykull + i] << 8 * i;
			}
		}
		else
		{
			num = P_0[RaIsqvtUKEOHIIQKwKVozEaykull];
		}
		UPILHvpUhOboiCfuxrRyJmdvexgX = num;
	}
}
