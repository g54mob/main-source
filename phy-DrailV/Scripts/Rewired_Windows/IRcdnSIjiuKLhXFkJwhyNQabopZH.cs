using System;
using System.Runtime.CompilerServices;
using Rewired;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;
using Rewired.Utils.Classes.Utility;

internal class IRcdnSIjiuKLhXFkJwhyNQabopZH : YszNVDBZreQueMHaxAPTEUkXgqRz
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal class TouchpadInfo
	{
		public int maxTouches;

		public int minX;

		public int maxX;

		public int minY;

		public int maxY;

		public bool invertY;

		public bool reverseY;

		public TouchpadInfo(int P_0, int P_1, int P_2, int P_3, int P_4, bool P_5, bool P_6)
		{
			maxTouches = P_0;
			minX = P_1;
			maxX = P_2;
			minY = P_3;
			maxY = P_4;
			invertY = P_5;
			reverseY = P_6;
		}

		public void CalculateTouch(ref TouchData data)
		{
			int num = (reverseY ? (maxY - data.positionRawY) : data.positionRawY);
			data.positionX = MathTools.ValueInNewRange(data.positionRawX, minX, maxX, 0f, 1f);
			data.positionY = MathTools.ValueInNewRange(num, minY, maxY, 0f, 1f);
			data.positionAbsX = data.positionRawX;
			data.positionAbsY = num;
			if (data.positionAbsX > maxX)
			{
				data.positionAbsX = maxX;
			}
			if (data.positionAbsY > maxY)
			{
				data.positionAbsY = maxY;
			}
			if (data.positionAbsX < minX)
			{
				data.positionAbsX = minX;
			}
			if (data.positionAbsY < minY)
			{
				data.positionAbsY = minY;
			}
			if (invertY)
			{
				data.positionY *= -1f;
				data.positionAbsY *= -1;
			}
		}
	}

	private class hdGfjeIuYHIwiYMsCTPDLRrKFcdbb
	{
		public readonly TouchData[] mOMEUBQyWiiPqJDJTDuPNharRHPG;

		public hdGfjeIuYHIwiYMsCTPDLRrKFcdbb(int P_0)
		{
			mOMEUBQyWiiPqJDJTDuPNharRHPG = new TouchData[P_0];
		}
	}

	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal struct TouchData
	{
		public int touchId;

		public float timeStamp;

		public bool isTouching;

		public int positionRawX;

		public int positionRawY;

		public float positionX;

		public float positionY;

		public int positionAbsX;

		public int positionAbsY;

		public void Clear()
		{
			touchId = -1;
			timeStamp = 0f;
			isTouching = false;
			positionRawX = 0;
			positionRawY = 0;
			positionX = 0f;
			positionY = 0f;
			positionAbsX = 0;
			positionAbsY = 0;
		}
	}

	private TouchpadInfo wdbQxUuPsPgPKZuWmNEeMjEvEqweA;

	private RingBuffer<hdGfjeIuYHIwiYMsCTPDLRrKFcdbb> WjLgfAcHoXHXYREFYbYbCZhhucBMB;

	private TouchData[] NzqLOkePVnpisQEWrERvBZOIliyJ;

	private Action<NativeBuffer, TouchData[]> zovEYMDwzpRetqGCitWoSXfGWxUAA;

	public TouchData[] vdoCmmimVgkttAEVHxTdgHVkQBPMb;

	private ObjectPool<hdGfjeIuYHIwiYMsCTPDLRrKFcdbb> ulXkTabQRWckjSFcHnujbnTnEhSh;

	public IRcdnSIjiuKLhXFkJwhyNQabopZH(byte P_0, TouchpadInfo P_1, HIDInfo P_2, int P_3, Action<NativeBuffer, TouchData[]> P_4)
		: base(P_0, P_2)
	{
		wdbQxUuPsPgPKZuWmNEeMjEvEqweA = P_1;
		zovEYMDwzpRetqGCitWoSXfGWxUAA = P_4;
		WjLgfAcHoXHXYREFYbYbCZhhucBMB = new RingBuffer<hdGfjeIuYHIwiYMsCTPDLRrKFcdbb>(P_3);
		NzqLOkePVnpisQEWrERvBZOIliyJ = new TouchData[P_1.maxTouches];
		vdoCmmimVgkttAEVHxTdgHVkQBPMb = new TouchData[P_1.maxTouches];
		for (int i = 0; i < vdoCmmimVgkttAEVHxTdgHVkQBPMb.Length; i++)
		{
			vdoCmmimVgkttAEVHxTdgHVkQBPMb[i].Clear();
		}
		ulXkTabQRWckjSFcHnujbnTnEhSh = new ObjectPool<hdGfjeIuYHIwiYMsCTPDLRrKFcdbb>(P_3, () => new hdGfjeIuYHIwiYMsCTPDLRrKFcdbb(wdbQxUuPsPgPKZuWmNEeMjEvEqweA.maxTouches));
	}

	public override void trsfRiBFSIjLrLMemKcGjgULCoSi(NativeBuffer P_0, double P_1)
	{
		if (zovEYMDwzpRetqGCitWoSXfGWxUAA == null)
		{
			return;
		}
		zovEYMDwzpRetqGCitWoSXfGWxUAA(P_0, NzqLOkePVnpisQEWrERvBZOIliyJ);
		lock (WjLgfAcHoXHXYREFYbYbCZhhucBMB)
		{
			hdGfjeIuYHIwiYMsCTPDLRrKFcdbb hdGfjeIuYHIwiYMsCTPDLRrKFcdbb2 = ulXkTabQRWckjSFcHnujbnTnEhSh.Get();
			for (int i = 0; i < wdbQxUuPsPgPKZuWmNEeMjEvEqweA.maxTouches; i++)
			{
				hdGfjeIuYHIwiYMsCTPDLRrKFcdbb2.mOMEUBQyWiiPqJDJTDuPNharRHPG[i] = NzqLOkePVnpisQEWrERvBZOIliyJ[i];
			}
			CollectionTools.Enqueue(ulXkTabQRWckjSFcHnujbnTnEhSh, WjLgfAcHoXHXYREFYbYbCZhhucBMB, hdGfjeIuYHIwiYMsCTPDLRrKFcdbb2, out var _);
		}
		CCRGreCdBnGxIDSgMvEofGuaWJnEA();
	}

	public void CCRGreCdBnGxIDSgMvEofGuaWJnEA()
	{
		for (int i = 0; i < vdoCmmimVgkttAEVHxTdgHVkQBPMb.Length; i++)
		{
			vdoCmmimVgkttAEVHxTdgHVkQBPMb[i].Clear();
		}
		lock (WjLgfAcHoXHXYREFYbYbCZhhucBMB)
		{
			int num = WjLgfAcHoXHXYREFYbYbCZhhucBMB.Count;
			while (num > 0)
			{
				hdGfjeIuYHIwiYMsCTPDLRrKFcdbb hdGfjeIuYHIwiYMsCTPDLRrKFcdbb2 = WjLgfAcHoXHXYREFYbYbCZhhucBMB.Dequeue();
				num--;
				for (int j = 0; j < hdGfjeIuYHIwiYMsCTPDLRrKFcdbb2.mOMEUBQyWiiPqJDJTDuPNharRHPG.Length; j++)
				{
					wdbQxUuPsPgPKZuWmNEeMjEvEqweA.CalculateTouch(ref hdGfjeIuYHIwiYMsCTPDLRrKFcdbb2.mOMEUBQyWiiPqJDJTDuPNharRHPG[j]);
					vdoCmmimVgkttAEVHxTdgHVkQBPMb[j] = hdGfjeIuYHIwiYMsCTPDLRrKFcdbb2.mOMEUBQyWiiPqJDJTDuPNharRHPG[j];
				}
				ulXkTabQRWckjSFcHnujbnTnEhSh.Return(hdGfjeIuYHIwiYMsCTPDLRrKFcdbb2);
			}
		}
	}

	public bool zDrAPvbHymMENazrJhImBDpGdtFiA(int P_0)
	{
		for (int i = 0; i < vdoCmmimVgkttAEVHxTdgHVkQBPMb.Length; i++)
		{
			if (vdoCmmimVgkttAEVHxTdgHVkQBPMb[i].isTouching && vdoCmmimVgkttAEVHxTdgHVkQBPMb[i].touchId == P_0)
			{
				return true;
			}
		}
		return false;
	}

	[CompilerGenerated]
	private hdGfjeIuYHIwiYMsCTPDLRrKFcdbb vnTTaxvfallYIxZsIuTDQJyUYEfk()
	{
		return new hdGfjeIuYHIwiYMsCTPDLRrKFcdbb(wdbQxUuPsPgPKZuWmNEeMjEvEqweA.maxTouches);
	}
}
