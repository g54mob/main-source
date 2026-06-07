using System;
using System.Runtime.CompilerServices;
using Rewired;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;
using Rewired.Utils.Classes.Utility;

internal class ECuuExxPnMTpiDfXAPmQzhehTPKT : OYzieseEeYXDrIqXsZAdwVmBBsCg
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

	private class vRIaOTRFFjdNzDUHDiFbZhpWsFqaA
	{
		public readonly TouchData[] qRZUynsOoXhswwahkgUPQzVrDxPq;

		public vRIaOTRFFjdNzDUHDiFbZhpWsFqaA(int P_0)
		{
			qRZUynsOoXhswwahkgUPQzVrDxPq = new TouchData[P_0];
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

	private TouchpadInfo OGAIImOYBqvjlSEXlePNeLyNJgdF;

	private RingBuffer<vRIaOTRFFjdNzDUHDiFbZhpWsFqaA> qaKdbOeMewbWpevynwQXzMFiXWWW;

	private TouchData[] ajbYXmNWxiSFQqCsEmuULvKUSQyA;

	private Action<NativeBuffer, TouchData[]> bAcDxClLZrQWXGKfpkkvfSqslwlr;

	public TouchData[] RFuDyXZFSuwShPfcFbhPdVCqtPBKA;

	private ObjectPool<vRIaOTRFFjdNzDUHDiFbZhpWsFqaA> PEIIQKqtTBulqAQIohpHYrzZpYaF;

	public ECuuExxPnMTpiDfXAPmQzhehTPKT(byte P_0, TouchpadInfo P_1, HIDInfo P_2, int P_3, Action<NativeBuffer, TouchData[]> P_4)
		: base(P_0, P_2)
	{
		OGAIImOYBqvjlSEXlePNeLyNJgdF = P_1;
		bAcDxClLZrQWXGKfpkkvfSqslwlr = P_4;
		qaKdbOeMewbWpevynwQXzMFiXWWW = new RingBuffer<vRIaOTRFFjdNzDUHDiFbZhpWsFqaA>(P_3);
		ajbYXmNWxiSFQqCsEmuULvKUSQyA = new TouchData[P_1.maxTouches];
		RFuDyXZFSuwShPfcFbhPdVCqtPBKA = new TouchData[P_1.maxTouches];
		for (int i = 0; i < RFuDyXZFSuwShPfcFbhPdVCqtPBKA.Length; i++)
		{
			RFuDyXZFSuwShPfcFbhPdVCqtPBKA[i].Clear();
		}
		PEIIQKqtTBulqAQIohpHYrzZpYaF = new ObjectPool<vRIaOTRFFjdNzDUHDiFbZhpWsFqaA>(P_3, () => new vRIaOTRFFjdNzDUHDiFbZhpWsFqaA(OGAIImOYBqvjlSEXlePNeLyNJgdF.maxTouches));
	}

	public virtual void lUnesttWFRNYlfYOlrHvrDltqLTJ(NativeBuffer P_0, double P_1)
	{
		if (bAcDxClLZrQWXGKfpkkvfSqslwlr == null)
		{
			return;
		}
		bAcDxClLZrQWXGKfpkkvfSqslwlr(P_0, ajbYXmNWxiSFQqCsEmuULvKUSQyA);
		lock (qaKdbOeMewbWpevynwQXzMFiXWWW)
		{
			vRIaOTRFFjdNzDUHDiFbZhpWsFqaA vRIaOTRFFjdNzDUHDiFbZhpWsFqaA2 = PEIIQKqtTBulqAQIohpHYrzZpYaF.Get();
			for (int i = 0; i < OGAIImOYBqvjlSEXlePNeLyNJgdF.maxTouches; i++)
			{
				vRIaOTRFFjdNzDUHDiFbZhpWsFqaA2.qRZUynsOoXhswwahkgUPQzVrDxPq[i] = ajbYXmNWxiSFQqCsEmuULvKUSQyA[i];
			}
			CollectionTools.Enqueue(PEIIQKqtTBulqAQIohpHYrzZpYaF, qaKdbOeMewbWpevynwQXzMFiXWWW, vRIaOTRFFjdNzDUHDiFbZhpWsFqaA2, out var _);
		}
		SeglKdSgtXCAjEjCIQQsOcyoYsgx();
	}

	public void SeglKdSgtXCAjEjCIQQsOcyoYsgx()
	{
		for (int i = 0; i < RFuDyXZFSuwShPfcFbhPdVCqtPBKA.Length; i++)
		{
			RFuDyXZFSuwShPfcFbhPdVCqtPBKA[i].Clear();
		}
		lock (qaKdbOeMewbWpevynwQXzMFiXWWW)
		{
			int num = qaKdbOeMewbWpevynwQXzMFiXWWW.Count;
			while (num > 0)
			{
				vRIaOTRFFjdNzDUHDiFbZhpWsFqaA vRIaOTRFFjdNzDUHDiFbZhpWsFqaA2 = qaKdbOeMewbWpevynwQXzMFiXWWW.Dequeue();
				num--;
				for (int j = 0; j < vRIaOTRFFjdNzDUHDiFbZhpWsFqaA2.qRZUynsOoXhswwahkgUPQzVrDxPq.Length; j++)
				{
					OGAIImOYBqvjlSEXlePNeLyNJgdF.CalculateTouch(ref vRIaOTRFFjdNzDUHDiFbZhpWsFqaA2.qRZUynsOoXhswwahkgUPQzVrDxPq[j]);
					RFuDyXZFSuwShPfcFbhPdVCqtPBKA[j] = vRIaOTRFFjdNzDUHDiFbZhpWsFqaA2.qRZUynsOoXhswwahkgUPQzVrDxPq[j];
				}
				PEIIQKqtTBulqAQIohpHYrzZpYaF.Return(vRIaOTRFFjdNzDUHDiFbZhpWsFqaA2);
			}
		}
	}

	public bool YpmgwwjwNILOgscVHbQZZLkGyLXu(int P_0)
	{
		for (int i = 0; i < RFuDyXZFSuwShPfcFbhPdVCqtPBKA.Length; i++)
		{
			if (RFuDyXZFSuwShPfcFbhPdVCqtPBKA[i].isTouching && RFuDyXZFSuwShPfcFbhPdVCqtPBKA[i].touchId == P_0)
			{
				return true;
			}
		}
		return false;
	}

	[CompilerGenerated]
	private vRIaOTRFFjdNzDUHDiFbZhpWsFqaA LGHLjqPgCkgnMmlYCvnvwekcAeBA()
	{
		return new vRIaOTRFFjdNzDUHDiFbZhpWsFqaA(OGAIImOYBqvjlSEXlePNeLyNJgdF.maxTouches);
	}
}
