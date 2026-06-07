using System;
using System.Collections.Generic;
using Rewired.Utils.Classes.Data;

namespace Rewired.HID
{
	[CustomObfuscation]
	[CustomClassObfuscation]
	internal class HIDTouchpad : HIDControllerElement
	{
		[CustomObfuscation]
		[CustomClassObfuscation]
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
			}

			public void CalculateTouch(ref TouchData data)
			{
			}
		}

		[CustomClassObfuscation]
		[CustomObfuscation]
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
			}
		}

		private TouchpadInfo sgVxbuDAuevAQEggkQAcSuZkVnGc;

		private Queue<TouchData> mDqiKvMaAIvunncObOPHDSgwZkMf;

		private TouchData[] DNCCJTDFxIJHgCLqGnKRlJgQRYjTB;

		private Action<NativeBuffer, TouchData[]> beJEcrXOTGYSxTusyERABNLRUOHi;

		public TouchData[] values;

		public HIDTouchpad(byte P_0, TouchpadInfo P_1, HIDInfo P_2, Action<NativeBuffer, TouchData[]> P_3)
			: base(0, null)
		{
		}

		public override void UpdateValue(NativeBuffer inputReport, double timestamp)
		{
		}

		public void ProcessQueue()
		{
		}

		public bool IsTouching(int touchId)
		{
			return false;
		}
	}
}
