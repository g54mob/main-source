using System;
using UnityEngine;

namespace CTS.Core
{
	[Serializable]
	public struct ReceiverReference<TObject>
	{
		[SerializeField]
		private UnityEngine.Object _receiver;

		public void Give(TObject obj)
		{
			if (!(_receiver == null))
			{
				((IReceive<TObject>)_receiver).OnReceive(obj);
			}
		}
	}
}
