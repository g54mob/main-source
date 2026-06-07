using System;
using UnityEngine;

namespace Dhs5.Utility.Databases
{
	public abstract class BaseEnumDatabaseElement : BaseDataContainerScriptableElement, IEnumDatabaseElement, IDataContainerElement
	{
		[SerializeField]
		[ReadOnly(false, false)]
		protected int m_enumIndex;

		public int EnumIndex => m_enumIndex;

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
