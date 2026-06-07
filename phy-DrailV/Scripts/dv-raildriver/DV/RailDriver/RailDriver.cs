#define UNITY_EDITOR_WIN
using System;
using System.Collections.Generic;
using System.Diagnostics;
using DV.Utils;
using PIEHid64Net;
using UnityEngine;

namespace DV.RailDriver
{
	public class RailDriver : SingletonBehaviour<RailDriver>
	{
		public class Wrapper : IDisposable
		{
			public bool[] ButtonsCurrentState;

			public bool[] ButtonsPreviousState;

			private readonly PIEDevice device;

			private byte[] readData;

			private byte[] writeData;

			private DisplayBuffer lastWrittenBuffer;

			public float Reverser { get; private set; }

			public float Throttle { get; private set; }

			public float DynBrake { get; private set; }

			public float AutoBrake { get; private set; }

			public float IndBrake { get; private set; }

			public float BailOff { get; private set; }

			public float Wiper { get; private set; }

			public float Lights { get; private set; }

			public event Action Disconnected;

			public Wrapper(PIEDevice device)
			{
				this.device = device;
				readData = new byte[device.ReadLength];
				writeData = new byte[device.WriteLength];
				ButtonsCurrentState = new bool[44];
				ButtonsPreviousState = new bool[44];
				device.SetupInterface();
				device.callNever = true;
				lastWrittenBuffer = DisplayBuffer.ON;
				WriteDisplay(DisplayBuffer.EMPTY);
			}

			public void Update()
			{
				device.ReadData(ref readData);
				float num = 255f;
				Reverser = (float)(int)readData[1] / num;
				float num2 = (float)(int)readData[2] / num;
				Throttle = Mathf.Clamp01(num2 * 2f - 1f);
				DynBrake = 1f - Mathf.Clamp01(num2 * 2f);
				AutoBrake = (float)(int)readData[3] / num;
				IndBrake = (float)(int)readData[4] / num;
				BailOff = (float)(int)readData[5] / num;
				Wiper = (float)(int)readData[6] / num;
				Lights = (float)(int)readData[7] / num;
				DoButtonRange(0);
				DoButtonRange(1);
				DoButtonRange(2);
				DoButtonRange(3);
				DoButtonRange(4);
				DoButtonRange(5);
				void DoButtonRange(int dataIndex)
				{
					byte b = readData[dataIndex + 8];
					for (int i = 0; i < 8; i++)
					{
						bool flag = (b & (1 << i)) != 0;
						int num3 = dataIndex * 8 + i;
						if (num3 >= ButtonsPreviousState.Length)
						{
							break;
						}
						ButtonsPreviousState[num3] = ButtonsCurrentState[num3];
						ButtonsCurrentState[num3] = flag;
					}
				}
			}

			public bool WriteDisplay(DisplayBuffer displayBuffer)
			{
				if (lastWrittenBuffer.Equals(displayBuffer))
				{
					return false;
				}
				for (int i = 0; i < device.WriteLength; i++)
				{
					writeData[i] = 0;
				}
				writeData[1] = 134;
				writeData[2] = (byte)displayBuffer.thirdLetter;
				writeData[3] = (byte)displayBuffer.secondLetter;
				writeData[4] = (byte)displayBuffer.firstLetter;
				int num = 404;
				while (true)
				{
					switch (num)
					{
					case 404:
						break;
					default:
						Debug.LogError("Write Fail: " + num);
						return false;
					case 0:
						return true;
					}
					num = device.WriteData(writeData);
				}
			}

			public void Dispose()
			{
				this.Disconnected?.Invoke();
				device.CloseInterface();
			}
		}

		[Serializable]
		public struct DisplayBuffer : IEquatable<DisplayBuffer>
		{
			public static readonly DisplayBuffer EMPTY = new DisplayBuffer(SegmentDisplayLetter.None, SegmentDisplayLetter.None, SegmentDisplayLetter.None);

			public static readonly DisplayBuffer ON = new DisplayBuffer(SegmentDisplayLetter.None, SegmentDisplayLetter.O, SegmentDisplayLetter.N);

			public static readonly DisplayBuffer OFF = new DisplayBuffer(SegmentDisplayLetter.O, SegmentDisplayLetter.F, SegmentDisplayLetter.F);

			public static readonly DisplayBuffer UP = new DisplayBuffer(SegmentDisplayLetter.None, SegmentDisplayLetter.U, SegmentDisplayLetter.P);

			public static readonly DisplayBuffer DN = new DisplayBuffer(SegmentDisplayLetter.None, SegmentDisplayLetter.D, SegmentDisplayLetter.N);

			public static readonly DisplayBuffer DV = new DisplayBuffer(SegmentDisplayLetter.D, SegmentDisplayLetter.VLeft, SegmentDisplayLetter.VRight);

			public SegmentDisplayLetter firstLetter;

			public SegmentDisplayLetter secondLetter;

			public SegmentDisplayLetter thirdLetter;

			public SegmentDisplayLetter this[int index]
			{
				get
				{
					switch (index)
					{
					case 0:
						return firstLetter;
					case 1:
						return secondLetter;
					case 2:
						return thirdLetter;
					default:
						throw new IndexOutOfRangeException();
					}
				}
				set
				{
					switch (index)
					{
					case 0:
						firstLetter = value;
						break;
					case 1:
						secondLetter = value;
						break;
					case 2:
						thirdLetter = value;
						break;
					default:
						throw new IndexOutOfRangeException();
					}
				}
			}

			public DisplayBuffer(int number)
			{
				int key = number % 10;
				int key2 = number / 10 % 10;
				int key3 = number / 100;
				this = new DisplayBuffer(intToLetter[key3], intToLetter[key2], intToLetter[key]);
			}

			public DisplayBuffer(SegmentDisplayLetter a, SegmentDisplayLetter b, SegmentDisplayLetter c)
			{
				this = default(DisplayBuffer);
				this[0] = a;
				this[1] = b;
				this[2] = c;
			}

			public bool Equals(DisplayBuffer other)
			{
				if (firstLetter == other.firstLetter && secondLetter == other.secondLetter)
				{
					return thirdLetter == other.thirdLetter;
				}
				return false;
			}

			public override bool Equals(object obj)
			{
				if (obj is DisplayBuffer other)
				{
					return Equals(other);
				}
				return false;
			}

			public override int GetHashCode()
			{
				return (int)(((uint)((int)firstLetter * 397) ^ (uint)secondLetter) * 397) ^ (int)thirdLetter;
			}
		}

		[Flags]
		public enum SegmentDisplayLetter : byte
		{
			None = 0,
			TopMiddle = 1,
			TopRight = 2,
			BottomRight = 4,
			BottomMiddle = 8,
			BottomLeft = 0x10,
			TopLeft = 0x20,
			Middle = 0x40,
			Dot = 0x80,
			Zero = 0x3F,
			One = 6,
			Two = 0x5B,
			Three = 0x4F,
			Four = 0x66,
			Five = 0x6D,
			Six = 0x7D,
			Seven = 7,
			Eight = 0x7F,
			Nine = 0x67,
			O = 0x5C,
			N = 0x54,
			F = 0x71,
			D = 0x5E,
			U = 0x1C,
			P = 0x73,
			VLeft = 0x24,
			VRight = 0x12
		}

		private static readonly Dictionary<int, SegmentDisplayLetter> intToLetter = new Dictionary<int, SegmentDisplayLetter>
		{
			{
				0,
				SegmentDisplayLetter.Zero
			},
			{
				1,
				SegmentDisplayLetter.One
			},
			{
				2,
				SegmentDisplayLetter.Two
			},
			{
				3,
				SegmentDisplayLetter.Three
			},
			{
				4,
				SegmentDisplayLetter.Four
			},
			{
				5,
				SegmentDisplayLetter.Five
			},
			{
				6,
				SegmentDisplayLetter.Six
			},
			{
				7,
				SegmentDisplayLetter.Seven
			},
			{
				8,
				SegmentDisplayLetter.Eight
			},
			{
				9,
				SegmentDisplayLetter.Nine
			}
		};

		public static bool IsConnected { get; private set; }

		public Wrapper activeWrapper { get; private set; }

		public static event Action<bool> ConnectedStatusChanged;

		public event Action<Wrapper> WrapperCreated;

		public new static string AllowAutoCreate()
		{
			return null;
		}

		private void Start()
		{
			SetupDevices();
		}

		private void Update()
		{
			activeWrapper?.Update();
		}

		protected override void OnDestroy()
		{
			base.OnDestroy();
			Dispose();
		}

		[Conditional("UNITY_EDITOR_WIN")]
		[Conditional("UNITY_STANDALONE_WIN")]
		private void Dispose()
		{
			activeWrapper?.Dispose();
			activeWrapper = null;
			IsConnected = false;
			RailDriver.ConnectedStatusChanged?.Invoke(IsConnected);
		}

		[Conditional("UNITY_EDITOR_WIN")]
		[Conditional("UNITY_STANDALONE_WIN")]
		public void SetupDevices()
		{
			Dispose();
			PIEDevice[] array = PIEDevice.EnumeratePIE();
			for (int i = 0; i < array.Length; i++)
			{
				if (array[i].Pid == 210)
				{
					activeWrapper = new Wrapper(array[i]);
					IsConnected = true;
					this.WrapperCreated?.Invoke(activeWrapper);
					RailDriver.ConnectedStatusChanged?.Invoke(IsConnected);
					break;
				}
			}
		}
	}
}
