using System;
using System.Runtime.CompilerServices;
using Rewired;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;
using Rewired.Utils.Classes.Utility;

internal class hwDBnDzZlOwqwaLOCXGWdEQuXFFf : tNSBtIwTqUeWpGtNoXsrdaEOoFDcA
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

	private class YWjnFfDSPdcGdhUVRdaxfQHLRRtN
	{
		public readonly TouchData[] DjqbdBcoyTissRxzgxHGEzMedIZb;

		public YWjnFfDSPdcGdhUVRdaxfQHLRRtN(int P_0)
		{
			DjqbdBcoyTissRxzgxHGEzMedIZb = new TouchData[P_0];
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

	private TouchpadInfo rivQBCKcBuUyvlyVdHDJkIGSOVas;

	private RingBuffer<YWjnFfDSPdcGdhUVRdaxfQHLRRtN> HAhkxeQJisRDhILcbxhHAHzndYXM;

	private TouchData[] VoMYFxBDSutHVBdEMtPiBoJPnYPK;

	private Action<NativeBuffer, TouchData[]> CcFowitgFtQFZdxhruRzhSQzomcr;

	public TouchData[] iVNpVhZhCmFMvyxmNYTLNjsnDNML;

	private ObjectPool<YWjnFfDSPdcGdhUVRdaxfQHLRRtN> sVlJPueGFPovybvOuMABWbLCXbnM;

	public hwDBnDzZlOwqwaLOCXGWdEQuXFFf(byte P_0, TouchpadInfo P_1, HIDInfo P_2, int P_3, Action<NativeBuffer, TouchData[]> P_4)
		: base(P_0, P_2)
	{
		rivQBCKcBuUyvlyVdHDJkIGSOVas = P_1;
		CcFowitgFtQFZdxhruRzhSQzomcr = P_4;
		HAhkxeQJisRDhILcbxhHAHzndYXM = new RingBuffer<YWjnFfDSPdcGdhUVRdaxfQHLRRtN>(P_3);
		VoMYFxBDSutHVBdEMtPiBoJPnYPK = new TouchData[P_1.maxTouches];
		iVNpVhZhCmFMvyxmNYTLNjsnDNML = new TouchData[P_1.maxTouches];
		for (int i = 0; i < iVNpVhZhCmFMvyxmNYTLNjsnDNML.Length; i++)
		{
			iVNpVhZhCmFMvyxmNYTLNjsnDNML[i].Clear();
		}
		sVlJPueGFPovybvOuMABWbLCXbnM = new ObjectPool<YWjnFfDSPdcGdhUVRdaxfQHLRRtN>(P_3, () => new YWjnFfDSPdcGdhUVRdaxfQHLRRtN(rivQBCKcBuUyvlyVdHDJkIGSOVas.maxTouches));
	}

	public virtual void MeYIhXvtWPaYfAISnwAjlBZgsaWO(NativeBuffer P_0, double P_1)
	{
		if (CcFowitgFtQFZdxhruRzhSQzomcr == null)
		{
			return;
		}
		CcFowitgFtQFZdxhruRzhSQzomcr(P_0, VoMYFxBDSutHVBdEMtPiBoJPnYPK);
		lock (HAhkxeQJisRDhILcbxhHAHzndYXM)
		{
			YWjnFfDSPdcGdhUVRdaxfQHLRRtN yWjnFfDSPdcGdhUVRdaxfQHLRRtN = sVlJPueGFPovybvOuMABWbLCXbnM.Get();
			for (int i = 0; i < rivQBCKcBuUyvlyVdHDJkIGSOVas.maxTouches; i++)
			{
				yWjnFfDSPdcGdhUVRdaxfQHLRRtN.DjqbdBcoyTissRxzgxHGEzMedIZb[i] = VoMYFxBDSutHVBdEMtPiBoJPnYPK[i];
			}
			CollectionTools.Enqueue(sVlJPueGFPovybvOuMABWbLCXbnM, HAhkxeQJisRDhILcbxhHAHzndYXM, yWjnFfDSPdcGdhUVRdaxfQHLRRtN, out var _);
		}
		rKPqwDExlZHRvxoOOXlwGCYlxwrU();
	}

	public void rKPqwDExlZHRvxoOOXlwGCYlxwrU()
	{
		for (int i = 0; i < iVNpVhZhCmFMvyxmNYTLNjsnDNML.Length; i++)
		{
			iVNpVhZhCmFMvyxmNYTLNjsnDNML[i].Clear();
		}
		lock (HAhkxeQJisRDhILcbxhHAHzndYXM)
		{
			int num = HAhkxeQJisRDhILcbxhHAHzndYXM.Count;
			while (num > 0)
			{
				YWjnFfDSPdcGdhUVRdaxfQHLRRtN yWjnFfDSPdcGdhUVRdaxfQHLRRtN = HAhkxeQJisRDhILcbxhHAHzndYXM.Dequeue();
				num--;
				for (int j = 0; j < yWjnFfDSPdcGdhUVRdaxfQHLRRtN.DjqbdBcoyTissRxzgxHGEzMedIZb.Length; j++)
				{
					rivQBCKcBuUyvlyVdHDJkIGSOVas.CalculateTouch(ref yWjnFfDSPdcGdhUVRdaxfQHLRRtN.DjqbdBcoyTissRxzgxHGEzMedIZb[j]);
					iVNpVhZhCmFMvyxmNYTLNjsnDNML[j] = yWjnFfDSPdcGdhUVRdaxfQHLRRtN.DjqbdBcoyTissRxzgxHGEzMedIZb[j];
				}
				sVlJPueGFPovybvOuMABWbLCXbnM.Return(yWjnFfDSPdcGdhUVRdaxfQHLRRtN);
			}
		}
	}

	public bool tMXqrOzATSzAqZvTXLlZBoUVnLGs(int P_0)
	{
		for (int i = 0; i < iVNpVhZhCmFMvyxmNYTLNjsnDNML.Length; i++)
		{
			if (iVNpVhZhCmFMvyxmNYTLNjsnDNML[i].isTouching && iVNpVhZhCmFMvyxmNYTLNjsnDNML[i].touchId == P_0)
			{
				return true;
			}
		}
		return false;
	}

	[CompilerGenerated]
	private YWjnFfDSPdcGdhUVRdaxfQHLRRtN oFvzIZegwSYhjplzSSGzjYUtGCjM()
	{
		return new YWjnFfDSPdcGdhUVRdaxfQHLRRtN(rivQBCKcBuUyvlyVdHDJkIGSOVas.maxTouches);
	}
}
