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
				goto IL_010d;
				IL_010d:
				int num2 = num;
				data.positionX = MathTools.ValueInNewRange(data.positionRawX, minX, maxX, 0f, 1f);
				int num3 = 683535904;
				goto IL_0010;
				IL_000b:
				num3 = 683535907;
				goto IL_0010;
				IL_0010:
				while (true)
				{
					switch (num3 ^ 0x28BDEE26)
					{
					case 8:
						break;
					default:
						return;
					case 1:
						if (data.positionAbsY < minY)
						{
							data.positionAbsY = minY;
							num3 = 683535910;
							continue;
						}
						goto case 0;
					case 0:
						if (invertY)
						{
							data.positionY *= -1f;
							data.positionAbsY *= -1;
							num3 = 683535906;
							continue;
						}
						return;
					case 3:
						if (data.positionAbsY > maxY)
						{
							data.positionAbsY = maxY;
							num3 = 683535908;
							continue;
						}
						goto case 2;
					case 7:
						data.positionAbsX = data.positionRawX;
						data.positionAbsY = num2;
						if (data.positionAbsX > maxX)
						{
							data.positionAbsX = maxX;
							num3 = 683535909;
							continue;
						}
						goto case 3;
					case 5:
						goto IL_00f8;
					case 2:
						if (data.positionAbsX < minX)
						{
							data.positionAbsX = minX;
							num3 = 683535911;
							continue;
						}
						goto case 1;
					case 6:
						data.positionY = MathTools.ValueInNewRange(num2, minY, maxY, 0f, 1f);
						num3 = 683535905;
						continue;
					case 4:
						return;
					}
					break;
				}
				goto IL_000b;
				IL_00f8:
				num = data.positionRawY;
				goto IL_010d;
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
				while (true)
				{
					int num = 1130671628;
					while (true)
					{
						switch (num ^ 0x4364AE0E)
						{
						case 0:
							break;
						case 2:
							goto IL_0037;
						default:
							positionAbsX = 0;
							positionAbsY = 0;
							return;
						}
						break;
						IL_0037:
						positionRawX = 0;
						positionRawY = 0;
						positionX = 0f;
						positionY = 0f;
						num = 1130671631;
					}
				}
			}
		}

		private TouchpadInfo YrINEQzKlfFBbUSiOJDTprrZsWe;

		private Queue<TouchData> KSfAqSqKULLUOnebTLQOitlZurF;

		private TouchData[] nYDFhaKzpXphFXTOJIPMyXzgvfc;

		private Action<NativeBuffer, TouchData[]> LpQqRQdQRXwpWRSAKJEFyQEozHE;

		public TouchData[] values;

		public HIDTouchpad(byte reportId, TouchpadInfo info, HIDInfo hidInfo, Action<NativeBuffer, TouchData[]> calcValueDelegate)
			: base(reportId, hidInfo)
		{
			int num2 = default(int);
			while (true)
			{
				int num = 1882005520;
				while (true)
				{
					switch (num ^ 0x702D2013)
					{
					case 2:
						break;
					case 3:
						YrINEQzKlfFBbUSiOJDTprrZsWe = info;
						num = 1882005525;
						continue;
					case 1:
						KSfAqSqKULLUOnebTLQOitlZurF = new Queue<TouchData>(10);
						nYDFhaKzpXphFXTOJIPMyXzgvfc = new TouchData[info.maxTouches];
						values = new TouchData[info.maxTouches];
						num2 = 0;
						num = 1882005526;
						continue;
					case 0:
						values[num2].Clear();
						num2++;
						num = 1882005527;
						continue;
					case 6:
						LpQqRQdQRXwpWRSAKJEFyQEozHE = calcValueDelegate;
						num = 1882005522;
						continue;
					case 5:
						num = 1882005527;
						continue;
					default:
						if (num2 >= values.Length)
						{
							return;
						}
						goto case 0;
					}
					break;
				}
			}
		}

		public override void UpdateValue(NativeBuffer inputReport, float timestamp)
		{
			if (LpQqRQdQRXwpWRSAKJEFyQEozHE == null)
			{
				return;
			}
			while (true)
			{
				LpQqRQdQRXwpWRSAKJEFyQEozHE(inputReport, nYDFhaKzpXphFXTOJIPMyXzgvfc);
				int num = -1858475702;
				while (true)
				{
					switch (num ^ -1858475702)
					{
					case 2:
						goto IL_0009;
					case 1:
						break;
					default:
						lock (KSfAqSqKULLUOnebTLQOitlZurF)
						{
							int num2 = 0;
							while (true)
							{
								IL_004f:
								int num3 = -1858475703;
								while (true)
								{
									switch (num3 ^ -1858475702)
									{
									case 4:
										break;
									default:
										goto end_IL_0054;
									case 3:
										num3 = -1858475701;
										continue;
									case 0:
										KSfAqSqKULLUOnebTLQOitlZurF.Enqueue(nYDFhaKzpXphFXTOJIPMyXzgvfc[num2]);
										num2++;
										num3 = -1858475701;
										continue;
									case 1:
									{
										int num4;
										if (num2 >= YrINEQzKlfFBbUSiOJDTprrZsWe.maxTouches)
										{
											num3 = -1858475704;
											num4 = num3;
										}
										else
										{
											num3 = -1858475702;
											num4 = num3;
										}
										continue;
									}
									case 2:
										goto end_IL_0054;
									}
									goto IL_004f;
									continue;
									end_IL_0054:
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
					num = -1858475701;
				}
			}
		}

		public void ProcessQueue()
		{
			int num = 0;
			int num3 = default(int);
			while (true)
			{
				int num2 = -1908971652;
				while (true)
				{
					switch (num2 ^ -1908971651)
					{
					case 0:
						break;
					case 1:
						num3 = 0;
						num2 = -1908971649;
						continue;
					case 3:
						values[num3].Clear();
						num3++;
						num2 = -1908971649;
						continue;
					default:
						if (num3 >= values.Length)
						{
							lock (KSfAqSqKULLUOnebTLQOitlZurF)
							{
								int num4 = KSfAqSqKULLUOnebTLQOitlZurF.Count;
								while (true)
								{
									int num5 = -1908971650;
									while (true)
									{
										switch (num5 ^ -1908971651)
										{
										case 0:
											break;
										default:
											return;
										case 3:
											num5 = -1908971652;
											continue;
										case 1:
										{
											int num6;
											if (num4 <= 0)
											{
												num5 = -1908971655;
												num6 = num5;
											}
											else
											{
												num5 = -1908971649;
												num6 = num5;
											}
											continue;
										}
										case 2:
										{
											TouchData data = KSfAqSqKULLUOnebTLQOitlZurF.Dequeue();
											num4--;
											YrINEQzKlfFBbUSiOJDTprrZsWe.CalculateTouch(ref data);
											values[num] = data;
											num++;
											num5 = -1908971652;
											continue;
										}
										case 4:
											return;
										}
										break;
									}
								}
							}
						}
						goto case 3;
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
					int num2 = 888778113;
					while (true)
					{
						switch (num2 ^ 0x34F9AD81)
						{
						case 2:
							num2 = 888778112;
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
