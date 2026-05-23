using System;
using System.Runtime.CompilerServices;
using Rewired;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;
using Rewired.Utils.Classes.Utility;

internal class SRlmwzCpkDCiOPGALkZGROsZKGfx : QTwvMqRjxXBwLOoUpuezGnwheUbM
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

	private class vaLjcBabAsuqFUxKQFyzZZlwGuXG
	{
		public readonly TouchData[] sBMYjxRrLSUCGkDabhPNwjLLapsh;

		public vaLjcBabAsuqFUxKQFyzZZlwGuXG(int P_0)
		{
			sBMYjxRrLSUCGkDabhPNwjLLapsh = new TouchData[P_0];
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

	private TouchpadInfo YPZfcgprSxaOHAQSkaNHGRineUYw;

	private RingBuffer<vaLjcBabAsuqFUxKQFyzZZlwGuXG> eELDGRzlMzvRaxxNolNKqHCWLzmb;

	private TouchData[] cgkCaHFgPrwbtLuZXvFqUhrorXnbA;

	private Action<NativeBuffer, TouchData[]> rpnKPGEFMwRhvKhimBFthXyAqzGaA;

	public TouchData[] NjrKDEoRljbTLZdbSWZHjMXESqOB;

	private ObjectPool<vaLjcBabAsuqFUxKQFyzZZlwGuXG> VONNmENWIEULKQnRnuWXeThfxaHs;

	public SRlmwzCpkDCiOPGALkZGROsZKGfx(byte P_0, TouchpadInfo P_1, HIDInfo P_2, int P_3, Action<NativeBuffer, TouchData[]> P_4)
		: base(P_0, P_2)
	{
		YPZfcgprSxaOHAQSkaNHGRineUYw = P_1;
		rpnKPGEFMwRhvKhimBFthXyAqzGaA = P_4;
		eELDGRzlMzvRaxxNolNKqHCWLzmb = new RingBuffer<vaLjcBabAsuqFUxKQFyzZZlwGuXG>(P_3);
		cgkCaHFgPrwbtLuZXvFqUhrorXnbA = new TouchData[P_1.maxTouches];
		NjrKDEoRljbTLZdbSWZHjMXESqOB = new TouchData[P_1.maxTouches];
		for (int i = 0; i < NjrKDEoRljbTLZdbSWZHjMXESqOB.Length; i++)
		{
			NjrKDEoRljbTLZdbSWZHjMXESqOB[i].Clear();
		}
		VONNmENWIEULKQnRnuWXeThfxaHs = new ObjectPool<vaLjcBabAsuqFUxKQFyzZZlwGuXG>(P_3, () => new vaLjcBabAsuqFUxKQFyzZZlwGuXG(YPZfcgprSxaOHAQSkaNHGRineUYw.maxTouches));
	}

	public virtual void bKkVQtUnJUEkZjEDowOpDTxJBnkP(NativeBuffer P_0, double P_1)
	{
		if (rpnKPGEFMwRhvKhimBFthXyAqzGaA == null)
		{
			return;
		}
		rpnKPGEFMwRhvKhimBFthXyAqzGaA(P_0, cgkCaHFgPrwbtLuZXvFqUhrorXnbA);
		lock (eELDGRzlMzvRaxxNolNKqHCWLzmb)
		{
			vaLjcBabAsuqFUxKQFyzZZlwGuXG vaLjcBabAsuqFUxKQFyzZZlwGuXG2 = VONNmENWIEULKQnRnuWXeThfxaHs.Get();
			for (int i = 0; i < YPZfcgprSxaOHAQSkaNHGRineUYw.maxTouches; i++)
			{
				vaLjcBabAsuqFUxKQFyzZZlwGuXG2.sBMYjxRrLSUCGkDabhPNwjLLapsh[i] = cgkCaHFgPrwbtLuZXvFqUhrorXnbA[i];
			}
			CollectionTools.Enqueue(VONNmENWIEULKQnRnuWXeThfxaHs, eELDGRzlMzvRaxxNolNKqHCWLzmb, vaLjcBabAsuqFUxKQFyzZZlwGuXG2, out var _);
		}
		YntEPhrwgOcpBCvTVSdqcJkCfbDgA();
	}

	public void YntEPhrwgOcpBCvTVSdqcJkCfbDgA()
	{
		for (int i = 0; i < NjrKDEoRljbTLZdbSWZHjMXESqOB.Length; i++)
		{
			NjrKDEoRljbTLZdbSWZHjMXESqOB[i].Clear();
		}
		lock (eELDGRzlMzvRaxxNolNKqHCWLzmb)
		{
			int num = eELDGRzlMzvRaxxNolNKqHCWLzmb.Count;
			while (num > 0)
			{
				vaLjcBabAsuqFUxKQFyzZZlwGuXG vaLjcBabAsuqFUxKQFyzZZlwGuXG2 = eELDGRzlMzvRaxxNolNKqHCWLzmb.Dequeue();
				num--;
				for (int j = 0; j < vaLjcBabAsuqFUxKQFyzZZlwGuXG2.sBMYjxRrLSUCGkDabhPNwjLLapsh.Length; j++)
				{
					YPZfcgprSxaOHAQSkaNHGRineUYw.CalculateTouch(ref vaLjcBabAsuqFUxKQFyzZZlwGuXG2.sBMYjxRrLSUCGkDabhPNwjLLapsh[j]);
					NjrKDEoRljbTLZdbSWZHjMXESqOB[j] = vaLjcBabAsuqFUxKQFyzZZlwGuXG2.sBMYjxRrLSUCGkDabhPNwjLLapsh[j];
				}
				VONNmENWIEULKQnRnuWXeThfxaHs.Return(vaLjcBabAsuqFUxKQFyzZZlwGuXG2);
			}
		}
	}

	public bool KezhOiULMJFiOJiOOejHvhuyqIuIA(int P_0)
	{
		for (int i = 0; i < NjrKDEoRljbTLZdbSWZHjMXESqOB.Length; i++)
		{
			if (NjrKDEoRljbTLZdbSWZHjMXESqOB[i].isTouching && NjrKDEoRljbTLZdbSWZHjMXESqOB[i].touchId == P_0)
			{
				return true;
			}
		}
		return false;
	}

	[CompilerGenerated]
	private vaLjcBabAsuqFUxKQFyzZZlwGuXG ZUTazngDpJrVNaWqXwQvAPoKUTVBA()
	{
		return new vaLjcBabAsuqFUxKQFyzZZlwGuXG(YPZfcgprSxaOHAQSkaNHGRineUYw.maxTouches);
	}
}
