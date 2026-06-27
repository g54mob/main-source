using System;
using System.Runtime.CompilerServices;
using Rewired;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;
using Rewired.Utils.Classes.Utility;

internal class YbNvcxfeAOXeGxhYaCCOmgMgdTsT : QAOlVgyStIKpRmoWAGbpIzIYHZwjA
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
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

	private class lRjXfVVJAfcxJcoOnFbfoGNFzZQq
	{
		public readonly TouchData[] oPgHNjagvTDRSCicMkxZRdhienjN;

		public lRjXfVVJAfcxJcoOnFbfoGNFzZQq(int P_0)
		{
			oPgHNjagvTDRSCicMkxZRdhienjN = new TouchData[P_0];
		}
	}

	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
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

	private TouchpadInfo SgvwboGTKagJFmhMFMUVjCCCIBNjA;

	private RingBuffer<lRjXfVVJAfcxJcoOnFbfoGNFzZQq> iGxEESUnvskrDNgxLyLPNzUbMicF;

	private TouchData[] spOLfNLZDkhwbIXPgcWkGmJTiKkP;

	private Action<NativeBuffer, TouchData[]> pCFYWYnaGvLonajoBPGpyPQvtmFO;

	public TouchData[] XBRNyXRXsysdNperzXpLQXmtHcpj;

	private ObjectPool<lRjXfVVJAfcxJcoOnFbfoGNFzZQq> ZItanYEyGNvGWWaFUrHDLNDKZfQNA;

	public YbNvcxfeAOXeGxhYaCCOmgMgdTsT(byte P_0, TouchpadInfo P_1, HIDInfo P_2, int P_3, Action<NativeBuffer, TouchData[]> P_4)
		: base(P_0, P_2)
	{
		SgvwboGTKagJFmhMFMUVjCCCIBNjA = P_1;
		pCFYWYnaGvLonajoBPGpyPQvtmFO = P_4;
		iGxEESUnvskrDNgxLyLPNzUbMicF = new RingBuffer<lRjXfVVJAfcxJcoOnFbfoGNFzZQq>(P_3);
		spOLfNLZDkhwbIXPgcWkGmJTiKkP = new TouchData[P_1.maxTouches];
		XBRNyXRXsysdNperzXpLQXmtHcpj = new TouchData[P_1.maxTouches];
		for (int i = 0; i < XBRNyXRXsysdNperzXpLQXmtHcpj.Length; i++)
		{
			XBRNyXRXsysdNperzXpLQXmtHcpj[i].Clear();
		}
		ZItanYEyGNvGWWaFUrHDLNDKZfQNA = new ObjectPool<lRjXfVVJAfcxJcoOnFbfoGNFzZQq>(P_3, () => new lRjXfVVJAfcxJcoOnFbfoGNFzZQq(SgvwboGTKagJFmhMFMUVjCCCIBNjA.maxTouches));
	}

	public virtual void tjCDJrfSHFxtTReJVJLfmKBknevr(NativeBuffer P_0, double P_1)
	{
		if (pCFYWYnaGvLonajoBPGpyPQvtmFO == null)
		{
			return;
		}
		pCFYWYnaGvLonajoBPGpyPQvtmFO(P_0, spOLfNLZDkhwbIXPgcWkGmJTiKkP);
		lock (iGxEESUnvskrDNgxLyLPNzUbMicF)
		{
			lRjXfVVJAfcxJcoOnFbfoGNFzZQq lRjXfVVJAfcxJcoOnFbfoGNFzZQq2 = ZItanYEyGNvGWWaFUrHDLNDKZfQNA.Get();
			for (int i = 0; i < SgvwboGTKagJFmhMFMUVjCCCIBNjA.maxTouches; i++)
			{
				lRjXfVVJAfcxJcoOnFbfoGNFzZQq2.oPgHNjagvTDRSCicMkxZRdhienjN[i] = spOLfNLZDkhwbIXPgcWkGmJTiKkP[i];
			}
			CollectionTools.Enqueue(ZItanYEyGNvGWWaFUrHDLNDKZfQNA, iGxEESUnvskrDNgxLyLPNzUbMicF, lRjXfVVJAfcxJcoOnFbfoGNFzZQq2, out var _);
		}
		SDBxWnUAaHWaBwJNgfcwLrWfEiIEA();
	}

	public void SDBxWnUAaHWaBwJNgfcwLrWfEiIEA()
	{
		for (int i = 0; i < XBRNyXRXsysdNperzXpLQXmtHcpj.Length; i++)
		{
			XBRNyXRXsysdNperzXpLQXmtHcpj[i].Clear();
		}
		lock (iGxEESUnvskrDNgxLyLPNzUbMicF)
		{
			int num = iGxEESUnvskrDNgxLyLPNzUbMicF.Count;
			while (num > 0)
			{
				lRjXfVVJAfcxJcoOnFbfoGNFzZQq lRjXfVVJAfcxJcoOnFbfoGNFzZQq2 = iGxEESUnvskrDNgxLyLPNzUbMicF.Dequeue();
				num--;
				for (int j = 0; j < lRjXfVVJAfcxJcoOnFbfoGNFzZQq2.oPgHNjagvTDRSCicMkxZRdhienjN.Length; j++)
				{
					SgvwboGTKagJFmhMFMUVjCCCIBNjA.CalculateTouch(ref lRjXfVVJAfcxJcoOnFbfoGNFzZQq2.oPgHNjagvTDRSCicMkxZRdhienjN[j]);
					XBRNyXRXsysdNperzXpLQXmtHcpj[j] = lRjXfVVJAfcxJcoOnFbfoGNFzZQq2.oPgHNjagvTDRSCicMkxZRdhienjN[j];
				}
				ZItanYEyGNvGWWaFUrHDLNDKZfQNA.Return(lRjXfVVJAfcxJcoOnFbfoGNFzZQq2);
			}
		}
	}

	public bool GsLURatUIUplCESYptaZWyOBgXfU(int P_0)
	{
		for (int i = 0; i < XBRNyXRXsysdNperzXpLQXmtHcpj.Length; i++)
		{
			if (XBRNyXRXsysdNperzXpLQXmtHcpj[i].isTouching && XBRNyXRXsysdNperzXpLQXmtHcpj[i].touchId == P_0)
			{
				return true;
			}
		}
		return false;
	}

	[CompilerGenerated]
	private lRjXfVVJAfcxJcoOnFbfoGNFzZQq ZXplinkmlObOFdgockTlkiMjzEWbA()
	{
		return new lRjXfVVJAfcxJcoOnFbfoGNFzZQq(SgvwboGTKagJFmhMFMUVjCCCIBNjA.maxTouches);
	}
}
