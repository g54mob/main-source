using System;
using System.Collections.Generic;
using Rewired.Utils.Classes.Data;

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

			public TouchpadInfo(int maxTouches, int minX, int maxX, int minY, int maxY, bool invertY, bool reverseY)
			{
			}

			public void CalculateTouch(ref TouchData data)
			{
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
			}
		}

		private TouchpadInfo qWXBasNzAUolgETIjekTSIPhoqs;

		private Queue<TouchData> sqsnCsKsQcnNXdByuwhCHHPpdsZ;

		private TouchData[] JyMkAEBcbcQBYVtAcJaAXxJEtVs;

		private Action<NativeBuffer, TouchData[]> vrTNvuHNfsMeNBJMfsKFDavSbwO;

		public TouchData[] values;

		public HIDTouchpad(byte reportId, TouchpadInfo info, HIDInfo hidInfo, Action<NativeBuffer, TouchData[]> calcValueDelegate)
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
