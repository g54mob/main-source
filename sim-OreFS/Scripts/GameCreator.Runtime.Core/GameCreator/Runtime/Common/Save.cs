using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	public class Save
	{
		[SerializeField]
		protected bool m_Save;

		public bool Value => m_Save;

		public Save()
		{
			m_Save = false;
		}

		public Save(bool mSave)
			: this()
		{
			m_Save = mSave;
		}
	}
}
