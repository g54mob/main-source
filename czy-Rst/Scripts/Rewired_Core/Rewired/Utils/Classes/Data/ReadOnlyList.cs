using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Rewired.Utils.Interfaces;

namespace Rewired.Utils.Classes.Data
{
	[DefaultMember("Item")]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal sealed class ReadOnlyList<T> : Rewired.Utils.Interfaces.IReadOnlyList<T>, IReadOnlyList, IEnumerable<T>, IEnumerable
	{
		private readonly IList<T> aQjeojwMQPalyalwhOdeOiHvQdxlA;

		int IReadOnlyList.Count => aQjeojwMQPalyalwhOdeOiHvQdxlA.Count;

		T Rewired.Utils.Interfaces.IReadOnlyList<T>.this[int index] => aQjeojwMQPalyalwhOdeOiHvQdxlA[index];

		object IReadOnlyList.this[int P_0] => (this as IList)[P_0];

		public ReadOnlyList(IList<T> P_0)
		{
			if (P_0 == null)
			{
				throw new ArgumentNullException();
			}
			aQjeojwMQPalyalwhOdeOiHvQdxlA = P_0;
		}

		public ReadOnlyList(ReadOnlyList<T> P_0)
		{
			if (P_0 == null)
			{
				throw new ArgumentNullException();
			}
			aQjeojwMQPalyalwhOdeOiHvQdxlA = new List<T>(P_0.aQjeojwMQPalyalwhOdeOiHvQdxlA);
		}

		public bool Contains(T value)
		{
			return aQjeojwMQPalyalwhOdeOiHvQdxlA.Contains(value);
		}

		bool Rewired.Utils.Interfaces.IReadOnlyList<T>.Contains(T value)
		{
			//ILSpy generated this explicit interface implementation from .override directive in Contains
			return this.Contains(value);
		}

		public int IndexOf(T value)
		{
			return aQjeojwMQPalyalwhOdeOiHvQdxlA.IndexOf(value);
		}

		int Rewired.Utils.Interfaces.IReadOnlyList<T>.IndexOf(T value)
		{
			//ILSpy generated this explicit interface implementation from .override directive in IndexOf
			return this.IndexOf(value);
		}

		public void CopyTo(IList<T> destination)
		{
			if (destination == null)
			{
				throw new ArgumentNullException();
			}
			for (int i = 0; i < aQjeojwMQPalyalwhOdeOiHvQdxlA.Count; i++)
			{
				destination.Add(aQjeojwMQPalyalwhOdeOiHvQdxlA[i]);
			}
		}

		private int lumBAOCTPOUTlisegSeqAzvzwPuSA(object P_0)
		{
			return (this as IList).IndexOf(P_0);
		}

		int IReadOnlyList.IndexOf(object P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in lumBAOCTPOUTlisegSeqAzvzwPuSA
			return this.lumBAOCTPOUTlisegSeqAzvzwPuSA(P_0);
		}

		private bool ujJEfUCZFhEywBBhjwzEnOtspfLrA(object P_0)
		{
			return (this as IList).Contains(P_0);
		}

		bool IReadOnlyList.Contains(object P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in ujJEfUCZFhEywBBhjwzEnOtspfLrA
			return this.ujJEfUCZFhEywBBhjwzEnOtspfLrA(P_0);
		}

		private IEnumerator<T> YFpfRCzUwLGhoNJGXXWWKNCmOecR()
		{
			return aQjeojwMQPalyalwhOdeOiHvQdxlA.GetEnumerator();
		}

		IEnumerator<T> IEnumerable<T>.GetEnumerator()
		{
			//ILSpy generated this explicit interface implementation from .override directive in YFpfRCzUwLGhoNJGXXWWKNCmOecR
			return this.YFpfRCzUwLGhoNJGXXWWKNCmOecR();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return aQjeojwMQPalyalwhOdeOiHvQdxlA.GetEnumerator();
		}
	}
}
