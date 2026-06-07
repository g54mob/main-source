using System;
using System.Collections.Generic;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;

namespace Rewired.HID
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal class HIDTouchpad : HIDControllerElement
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

			public TouchpadInfo(int maxTouches, int minX, int maxX, int minY, int maxY, bool invertY, bool reverseY)
			{
				this.maxTouches = maxTouches;
				this.minX = minX;
				this.maxX = maxX;
				this.minY = minY;
				this.maxY = maxY;
				this.invertY = invertY;
				this.reverseY = reverseY;
			}

			public void CalculateTouch(ref TouchData data)
			{
				if (!reverseY)
				{
					goto IL_000b;
				}
				int num = maxY - data.positionRawY;
				goto IL_0124;
				IL_0124:
				int num2 = num;
				data.positionX = MathTools.ValueInNewRange(data.positionRawX, minX, maxX, 0f, 1f);
				data.positionY = MathTools.ValueInNewRange(num2, minY, maxY, 0f, 1f);
				data.positionAbsX = data.positionRawX;
				int num3 = -233159967;
				goto IL_0010;
				IL_000b:
				num3 = -233159963;
				goto IL_0010;
				IL_0010:
				while (true)
				{
					switch (num3 ^ -233159968)
					{
					case 4:
						break;
					default:
						return;
					case 6:
						if (invertY)
						{
							data.positionY *= -1f;
							data.positionAbsY *= -1;
							num3 = -233159965;
							continue;
						}
						return;
					case 7:
						if (data.positionAbsY > maxY)
						{
							data.positionAbsY = maxY;
							num3 = -233159968;
							continue;
						}
						goto case 0;
					case 0:
						if (data.positionAbsX < minX)
						{
							data.positionAbsX = minX;
							num3 = -233159966;
							continue;
						}
						goto case 2;
					case 2:
						if (data.positionAbsY < minY)
						{
							data.positionAbsY = minY;
							num3 = -233159962;
							continue;
						}
						goto case 6;
					case 1:
						data.positionAbsY = num2;
						if (data.positionAbsX > maxX)
						{
							data.positionAbsX = maxX;
							num3 = -233159961;
							continue;
						}
						goto case 7;
					case 5:
						goto IL_010f;
					case 3:
						return;
					}
					break;
				}
				goto IL_000b;
				IL_010f:
				num = data.positionRawY;
				goto IL_0124;
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
				while (true)
				{
					int num = 1262784141;
					while (true)
					{
						switch (num ^ 0x4B448E8C)
						{
						case 3:
							break;
						default:
							return;
						case 1:
							positionRawY = 0;
							positionX = 0f;
							positionY = 0f;
							num = 1262784140;
							continue;
						case 0:
							positionAbsX = 0;
							positionAbsY = 0;
							num = 1262784142;
							continue;
						case 2:
							return;
						}
						break;
					}
				}
			}
		}

		private TouchpadInfo fFQCPNPdMdiPQyrPqNFBMjfHDtl;

		private Queue<TouchData> bEvDFXEWIHgxdFzQnFIMRnEBzKV;

		private TouchData[] MlXyknHndHgSktxZzcTUaFvsJsn;

		private Action<NativeBuffer, TouchData[]> mrYChTVqXTCVxhzNiXVDRNAiSmHs;

		public TouchData[] values;

		public HIDTouchpad(byte reportId, TouchpadInfo info, HIDInfo hidInfo, Action<NativeBuffer, TouchData[]> calcValueDelegate)
			: base(reportId, hidInfo)
		{
			int num2 = default(int);
			while (true)
			{
				int num = 1584128944;
				while (true)
				{
					switch (num ^ 0x5E6BE3B3)
					{
					case 5:
						break;
					default:
						return;
					case 1:
						values[num2].Clear();
						num2++;
						num = 1584128945;
						continue;
					case 0:
						mrYChTVqXTCVxhzNiXVDRNAiSmHs = calcValueDelegate;
						bEvDFXEWIHgxdFzQnFIMRnEBzKV = new Queue<TouchData>(10);
						MlXyknHndHgSktxZzcTUaFvsJsn = new TouchData[info.maxTouches];
						values = new TouchData[info.maxTouches];
						num2 = 0;
						num = 1584128945;
						continue;
					case 2:
					{
						int num3;
						if (num2 < values.Length)
						{
							num = 1584128946;
							num3 = num;
						}
						else
						{
							num = 1584128951;
							num3 = num;
						}
						continue;
					}
					case 3:
						fFQCPNPdMdiPQyrPqNFBMjfHDtl = info;
						num = 1584128947;
						continue;
					case 4:
						return;
					}
					break;
				}
			}
		}

		public override void UpdateValue(NativeBuffer inputReport, float timestamp)
		{
			if (mrYChTVqXTCVxhzNiXVDRNAiSmHs == null)
			{
				while (true)
				{
					switch (-1912227683 ^ -1912227681)
					{
					case 0:
						continue;
					case 2:
						return;
					}
					break;
				}
			}
			mrYChTVqXTCVxhzNiXVDRNAiSmHs(inputReport, MlXyknHndHgSktxZzcTUaFvsJsn);
			lock (bEvDFXEWIHgxdFzQnFIMRnEBzKV)
			{
				int num = 0;
				while (true)
				{
					IL_009a:
					int num2;
					int num3;
					if (num < fFQCPNPdMdiPQyrPqNFBMjfHDtl.maxTouches)
					{
						num2 = -1912227684;
						num3 = num2;
					}
					else
					{
						num2 = -1912227682;
						num3 = num2;
					}
					while (true)
					{
						switch (num2 ^ -1912227681)
						{
						case 0:
							num2 = -1912227684;
							continue;
						default:
							goto end_IL_0056;
						case 3:
							bEvDFXEWIHgxdFzQnFIMRnEBzKV.Enqueue(MlXyknHndHgSktxZzcTUaFvsJsn[num]);
							num++;
							num2 = -1912227683;
							continue;
						case 2:
							break;
						case 1:
							goto end_IL_0056;
						}
						goto IL_009a;
						continue;
						end_IL_0056:
						break;
					}
					break;
				}
			}
			ProcessQueue();
		}

		public void ProcessQueue()
		{
			int num = 0;
			int num3 = default(int);
			TouchData data = default(TouchData);
			while (true)
			{
				int num2 = -204800857;
				while (true)
				{
					switch (num2 ^ -204800860)
					{
					case 0:
						break;
					case 3:
						num3 = 0;
						num2 = -204800858;
						continue;
					case 1:
						values[num3].Clear();
						num3++;
						num2 = -204800858;
						continue;
					default:
						if (num3 >= values.Length)
						{
							lock (bEvDFXEWIHgxdFzQnFIMRnEBzKV)
							{
								int num4 = bEvDFXEWIHgxdFzQnFIMRnEBzKV.Count;
								while (true)
								{
									int num5;
									int num6;
									if (num4 > 0)
									{
										num5 = -204800859;
										num6 = num5;
									}
									else
									{
										num5 = -204800857;
										num6 = num5;
									}
									while (true)
									{
										switch (num5 ^ -204800860)
										{
										case 0:
											num5 = -204800859;
											continue;
										default:
											return;
										case 1:
											data = bEvDFXEWIHgxdFzQnFIMRnEBzKV.Dequeue();
											num4--;
											num5 = -204800858;
											continue;
										case 4:
											break;
										case 2:
											fFQCPNPdMdiPQyrPqNFBMjfHDtl.CalculateTouch(ref data);
											values[num] = data;
											num++;
											num5 = -204800864;
											continue;
										case 3:
											return;
										}
										break;
									}
								}
							}
						}
						goto case 1;
					}
					break;
				}
			}
		}

		public bool IsTouching(int touchId)
		{
			int num = 0;
			while (num < values.Length)
			{
				while (true)
				{
					if (values[num].isTouching && values[num].touchId == touchId)
					{
						return true;
					}
					num++;
					int num2 = -296334559;
					while (true)
					{
						switch (num2 ^ -296334557)
						{
						case 0:
							num2 = -296334558;
							continue;
						case 1:
							break;
						default:
							goto end_IL_0022;
						}
						break;
					}
					continue;
					end_IL_0022:
					break;
				}
			}
			return false;
		}
	}
}
