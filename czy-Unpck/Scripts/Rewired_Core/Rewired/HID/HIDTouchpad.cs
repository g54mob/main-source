using System;
using System.Collections.Generic;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;

namespace Rewired.HID
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
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
				int num = (reverseY ? (maxY - data.positionRawY) : data.positionRawY);
				while (true)
				{
					int num2 = 95798121;
					while (true)
					{
						switch (num2 ^ 0x5B5C36A)
						{
						case 11:
							break;
						default:
							return;
						case 3:
							data.positionX = MathTools.ValueInNewRange(data.positionRawX, minX, maxX, 0f, 1f);
							data.positionY = MathTools.ValueInNewRange(num, minY, maxY, 0f, 1f);
							num2 = 95798125;
							continue;
						case 6:
							data.positionY *= -1f;
							data.positionAbsY *= -1;
							num2 = 95798114;
							continue;
						case 4:
							data.positionAbsY = minY;
							num2 = 95798127;
							continue;
						case 5:
						{
							int num6;
							if (invertY)
							{
								num2 = 95798124;
								num6 = num2;
							}
							else
							{
								num2 = 95798114;
								num6 = num2;
							}
							continue;
						}
						case 7:
						{
							data.positionAbsX = data.positionRawX;
							data.positionAbsY = num;
							int num3;
							if (data.positionAbsX <= maxX)
							{
								num2 = 95798122;
								num3 = num2;
							}
							else
							{
								num2 = 95798112;
								num3 = num2;
							}
							continue;
						}
						case 0:
						{
							int num5;
							if (data.positionAbsY > maxY)
							{
								num2 = 95798115;
								num5 = num2;
							}
							else
							{
								num2 = 95798120;
								num5 = num2;
							}
							continue;
						}
						case 10:
							data.positionAbsX = maxX;
							num2 = 95798122;
							continue;
						case 1:
						{
							int num4;
							if (data.positionAbsY >= minY)
							{
								num2 = 95798127;
								num4 = num2;
							}
							else
							{
								num2 = 95798126;
								num4 = num2;
							}
							continue;
						}
						case 2:
							if (data.positionAbsX < minX)
							{
								data.positionAbsX = minX;
								num2 = 95798123;
								continue;
							}
							goto case 1;
						case 9:
							data.positionAbsY = maxY;
							num2 = 95798120;
							continue;
						case 8:
							return;
						}
						break;
					}
				}
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

		private TouchpadInfo GHCGdCDbjrofHQLylQoSJOXGrsCj;

		private Queue<TouchData> OLpvkYwRnPnxseGQqAwRRkBOkmv;

		private TouchData[] heRVAoxSFVDdjGgqmuOPFGVhetK;

		private Action<NativeBuffer, TouchData[]> PqMrIShMeNFMoGUmfXsQkHylWpwc;

		public TouchData[] values;

		public HIDTouchpad(byte reportId, TouchpadInfo info, HIDInfo hidInfo, Action<NativeBuffer, TouchData[]> calcValueDelegate)
			: base(reportId, hidInfo)
		{
			int num2 = default(int);
			while (true)
			{
				int num = -1501417994;
				while (true)
				{
					switch (num ^ -1501417996)
					{
					case 3:
						break;
					default:
						return;
					case 2:
						GHCGdCDbjrofHQLylQoSJOXGrsCj = info;
						PqMrIShMeNFMoGUmfXsQkHylWpwc = calcValueDelegate;
						OLpvkYwRnPnxseGQqAwRRkBOkmv = new Queue<TouchData>(10);
						heRVAoxSFVDdjGgqmuOPFGVhetK = new TouchData[info.maxTouches];
						values = new TouchData[info.maxTouches];
						num = -1501417995;
						continue;
					case 5:
						values[num2].Clear();
						num2++;
						num = -1501418000;
						continue;
					case 1:
						num2 = 0;
						num = -1501418000;
						continue;
					case 4:
					{
						int num3;
						if (num2 < values.Length)
						{
							num = -1501417999;
							num3 = num;
						}
						else
						{
							num = -1501417996;
							num3 = num;
						}
						continue;
					}
					case 0:
						return;
					}
					break;
				}
			}
		}

		public override void UpdateValue(NativeBuffer inputReport, double timestamp)
		{
			if (PqMrIShMeNFMoGUmfXsQkHylWpwc == null)
			{
				return;
			}
			while (true)
			{
				PqMrIShMeNFMoGUmfXsQkHylWpwc(inputReport, heRVAoxSFVDdjGgqmuOPFGVhetK);
				int num = -782332072;
				while (true)
				{
					switch (num ^ -782332070)
					{
					case 0:
						goto IL_0009;
					case 1:
						break;
					default:
						lock (OLpvkYwRnPnxseGQqAwRRkBOkmv)
						{
							int num2 = 0;
							while (true)
							{
								IL_009a:
								int num3;
								int num4;
								if (num2 < GHCGdCDbjrofHQLylQoSJOXGrsCj.maxTouches)
								{
									num3 = -782332071;
									num4 = num3;
								}
								else
								{
									num3 = -782332069;
									num4 = num3;
								}
								while (true)
								{
									switch (num3 ^ -782332070)
									{
									case 0:
										num3 = -782332071;
										continue;
									default:
										goto end_IL_0056;
									case 3:
										OLpvkYwRnPnxseGQqAwRRkBOkmv.Enqueue(heRVAoxSFVDdjGgqmuOPFGVhetK[num2]);
										num2++;
										num3 = -782332072;
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
						return;
					}
					break;
					IL_0009:
					num = -782332069;
				}
			}
		}

		public void ProcessQueue()
		{
			int num = 0;
			int num2 = 0;
			TouchData data = default(TouchData);
			while (true)
			{
				int num3 = -835079380;
				while (true)
				{
					switch (num3 ^ -835079384)
					{
					case 3:
						break;
					case 4:
						num3 = -835079382;
						continue;
					case 0:
						num2++;
						num3 = -835079382;
						continue;
					case 1:
						values[num2].Clear();
						num3 = -835079384;
						continue;
					default:
						if (num2 >= values.Length)
						{
							lock (OLpvkYwRnPnxseGQqAwRRkBOkmv)
							{
								int num4 = OLpvkYwRnPnxseGQqAwRRkBOkmv.Count;
								while (true)
								{
									int num5 = -835079383;
									while (true)
									{
										switch (num5 ^ -835079384)
										{
										case 7:
											break;
										case 3:
											GHCGdCDbjrofHQLylQoSJOXGrsCj.CalculateTouch(ref data);
											num5 = -835079382;
											continue;
										case 2:
											values[num] = data;
											num5 = -835079379;
											continue;
										case 6:
											num4--;
											num5 = -835079381;
											continue;
										case 1:
											num5 = -835079380;
											continue;
										case 5:
											num++;
											num5 = -835079380;
											continue;
										case 0:
											data = OLpvkYwRnPnxseGQqAwRRkBOkmv.Dequeue();
											num5 = -835079378;
											continue;
										default:
											if (num4 <= 0)
											{
												return;
											}
											goto case 0;
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
					int num2 = 1222061273;
					while (true)
					{
						switch (num2 ^ 0x48D72CD9)
						{
						case 2:
							num2 = 1222061272;
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
