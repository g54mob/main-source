using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	public abstract class TypeReference<T>
	{
		[SerializeField]
		private string m_TypeName;

		public Type Base => typeof(T);

		public Type Type => Type.GetType(m_TypeName, throwOnError: false);

		public override string ToString()
		{
			if (!(Type != null))
			{
				return "(none)";
			}
			return TextUtils.Humanize(Type.Name);
		}
	}
}
