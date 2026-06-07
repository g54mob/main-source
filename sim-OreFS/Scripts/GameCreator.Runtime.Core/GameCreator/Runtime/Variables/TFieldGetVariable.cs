using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Variables
{
	[Serializable]
	public abstract class TFieldGetVariable
	{
		[SerializeField]
		protected IdString m_TypeID = ValueNull.TYPE_ID;

		public T Get<T>(Args args)
		{
			object obj = Get(args);
			if (obj == null)
			{
				return default(T);
			}
			if (!(obj is T result))
			{
				return (Convert.ChangeType(obj, typeof(T)) is T val) ? val : default(T);
			}
			return result;
		}

		public abstract object Get(Args args);

		public abstract override string ToString();
	}
}
