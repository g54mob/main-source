using System;
using UnityEngine;

namespace Simulator
{
	[Serializable]
	public class StackableBoxSaveState : BoxSaveState
	{
		public int productUID;

		public int quantity;

		public StackableBoxSaveState(int uid, bool grabbed, bool open, int productUID, int quantity, Vector3 position, Quaternion rotation)
			: base(uid, grabbed, open, position, rotation)
		{
			this.productUID = productUID;
			this.quantity = quantity;
		}
	}
}
