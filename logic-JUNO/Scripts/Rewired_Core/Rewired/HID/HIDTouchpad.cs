using System;
using System.Runtime.CompilerServices;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;
using Rewired.Utils.Classes.Utility;

namespace Rewired.HID
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal class HIDTouchpad : HIDControllerElement
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

		private class PAOlFXScTbBHABKfKrTrQpndbgeN
		{
			public readonly TouchData[] UgZbNxbbeRCvRafBDnENmnNMWQRbb;

			public PAOlFXScTbBHABKfKrTrQpndbgeN(int P_0)
			{
				UgZbNxbbeRCvRafBDnENmnNMWQRbb = new TouchData[P_0];
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

		private TouchpadInfo qKCjOsNqJqpGETFzuHyHHmkckarU;

		private RingBuffer<PAOlFXScTbBHABKfKrTrQpndbgeN> UVIuGMTTawEOCmgMwSYPvcVHizQK;

		private TouchData[] CfdzRVKCouIXspucXwkmyfIphfEF;

		private Action<NativeBuffer, TouchData[]> ZsuYpEixHfKXaLEHwiArQAoNGXlQ;

		public TouchData[] values;

		private ObjectPool<PAOlFXScTbBHABKfKrTrQpndbgeN> hnGxjYxWDXmhZFQwxjQNhKnaGIyh;

		public HIDTouchpad(byte P_0, TouchpadInfo P_1, HIDInfo P_2, int P_3, Action<NativeBuffer, TouchData[]> P_4)
			: base(P_0, P_2)
		{
			qKCjOsNqJqpGETFzuHyHHmkckarU = P_1;
			ZsuYpEixHfKXaLEHwiArQAoNGXlQ = P_4;
			UVIuGMTTawEOCmgMwSYPvcVHizQK = new RingBuffer<PAOlFXScTbBHABKfKrTrQpndbgeN>(P_3);
			CfdzRVKCouIXspucXwkmyfIphfEF = new TouchData[P_1.maxTouches];
			values = new TouchData[P_1.maxTouches];
			for (int i = 0; i < values.Length; i++)
			{
				values[i].Clear();
			}
			hnGxjYxWDXmhZFQwxjQNhKnaGIyh = new ObjectPool<PAOlFXScTbBHABKfKrTrQpndbgeN>(P_3, () => new PAOlFXScTbBHABKfKrTrQpndbgeN(qKCjOsNqJqpGETFzuHyHHmkckarU.maxTouches));
		}

		public override void UpdateValue(NativeBuffer inputReport, double timestamp)
		{
			if (ZsuYpEixHfKXaLEHwiArQAoNGXlQ == null)
			{
				return;
			}
			ZsuYpEixHfKXaLEHwiArQAoNGXlQ(inputReport, CfdzRVKCouIXspucXwkmyfIphfEF);
			lock (UVIuGMTTawEOCmgMwSYPvcVHizQK)
			{
				PAOlFXScTbBHABKfKrTrQpndbgeN pAOlFXScTbBHABKfKrTrQpndbgeN = hnGxjYxWDXmhZFQwxjQNhKnaGIyh.Get();
				for (int i = 0; i < qKCjOsNqJqpGETFzuHyHHmkckarU.maxTouches; i++)
				{
					pAOlFXScTbBHABKfKrTrQpndbgeN.UgZbNxbbeRCvRafBDnENmnNMWQRbb[i] = CfdzRVKCouIXspucXwkmyfIphfEF[i];
				}
				CollectionTools.Enqueue(hnGxjYxWDXmhZFQwxjQNhKnaGIyh, UVIuGMTTawEOCmgMwSYPvcVHizQK, pAOlFXScTbBHABKfKrTrQpndbgeN, out var _);
			}
			ProcessQueue();
		}

		public void ProcessQueue()
		{
			for (int i = 0; i < values.Length; i++)
			{
				values[i].Clear();
			}
			lock (UVIuGMTTawEOCmgMwSYPvcVHizQK)
			{
				int num = UVIuGMTTawEOCmgMwSYPvcVHizQK.Count;
				while (num > 0)
				{
					PAOlFXScTbBHABKfKrTrQpndbgeN pAOlFXScTbBHABKfKrTrQpndbgeN = UVIuGMTTawEOCmgMwSYPvcVHizQK.Dequeue();
					num--;
					for (int j = 0; j < pAOlFXScTbBHABKfKrTrQpndbgeN.UgZbNxbbeRCvRafBDnENmnNMWQRbb.Length; j++)
					{
						qKCjOsNqJqpGETFzuHyHHmkckarU.CalculateTouch(ref pAOlFXScTbBHABKfKrTrQpndbgeN.UgZbNxbbeRCvRafBDnENmnNMWQRbb[j]);
						values[j] = pAOlFXScTbBHABKfKrTrQpndbgeN.UgZbNxbbeRCvRafBDnENmnNMWQRbb[j];
					}
					hnGxjYxWDXmhZFQwxjQNhKnaGIyh.Return(pAOlFXScTbBHABKfKrTrQpndbgeN);
				}
			}
		}

		public bool IsTouching(int touchId)
		{
			for (int i = 0; i < values.Length; i++)
			{
				if (values[i].isTouching && values[i].touchId == touchId)
				{
					return true;
				}
			}
			return false;
		}

		[CompilerGenerated]
		private PAOlFXScTbBHABKfKrTrQpndbgeN thUwVdrwtEgIULBkPvnbYgiVjByc()
		{
			return new PAOlFXScTbBHABKfKrTrQpndbgeN(qKCjOsNqJqpGETFzuHyHHmkckarU.maxTouches);
		}
	}
}
