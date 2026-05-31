using System;
using System.Collections.Generic;
using Photon.Realtime;
using UnityEngine;

namespace Photon.Pun
{
	public class PhotonStream
	{
		private List<object> writeData;

		private object[] readData;

		private int currentItem;

		public bool IsWriting { get; private set; }

		public bool IsReading => false;

		public int Count => 0;

		public bool HasNext()
		{
			return false;
		}

		public PhotonStream(bool write, object[] incomingData)
		{
		}

		public void SetReadStream(object[] incomingData, int pos = 0)
		{
		}

		internal void SetWriteStream(List<object> newWriteData, int pos = 0)
		{
		}

		internal List<object> GetWriteStream()
		{
			return null;
		}

		[Obsolete("Either SET the writeData with an empty List or use Clear().")]
		internal void ResetWriteStream()
		{
		}

		public object ReceiveNext()
		{
			return null;
		}

		public object PeekNext()
		{
			return null;
		}

		public void SendNext(object obj)
		{
		}

		[Obsolete("writeData is a list now. Use and re-use it directly.")]
		public bool CopyToListAndClear(List<object> target)
		{
			return false;
		}

		public object[] ToArray()
		{
			return null;
		}

		public void Serialize(ref bool myBool)
		{
		}

		public void Serialize(ref int myInt)
		{
		}

		public void Serialize(ref string value)
		{
		}

		public void Serialize(ref char value)
		{
		}

		public void Serialize(ref byte value)
		{
		}

		public void Serialize(ref short value)
		{
		}

		public void Serialize(ref float obj)
		{
		}

		public void Serialize(ref Player obj)
		{
		}

		public void Serialize(ref Vector3 obj)
		{
		}

		public void Serialize(ref Vector2 obj)
		{
		}

		public void Serialize(ref Quaternion obj)
		{
		}
	}
}
