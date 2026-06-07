using System;
using UnityEngine;

namespace Dhs5.Utility.Databases
{
	public abstract class BaseDataContainerScriptableElement : ScriptableObject, IDataContainerElement
	{
		[SerializeField]
		[ReadOnly(false, false)]
		protected int m_uid;

		public int UID => m_uid;

		string IDataContainerElement.name
		{
			get
			{
				return base.name;
			}
			set
			{
				base.name = value;
			}
		}

		Type IDataContainerElement.GetType()
		{
			return GetType();
		}
	}
}
