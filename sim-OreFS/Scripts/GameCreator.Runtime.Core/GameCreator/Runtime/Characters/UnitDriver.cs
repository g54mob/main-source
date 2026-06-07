using System;
using UnityEngine;

namespace GameCreator.Runtime.Characters
{
	[Serializable]
	public class UnitDriver
	{
		[SerializeReference]
		private TUnitDriver m_Driver = new UnitDriverController();

		public TUnitDriver Wrapper => m_Driver;

		public UnitDriver()
		{
		}

		public UnitDriver(TUnitDriver unit)
		{
			m_Driver = unit;
		}

		public override string ToString()
		{
			if (m_Driver == null)
			{
				return "(none)";
			}
			return m_Driver.ToString();
		}
	}
}
