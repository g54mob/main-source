using System;
using UnityEngine;

namespace GameCreator.Runtime.Characters
{
	[Serializable]
	public class UnitFacing
	{
		[SerializeReference]
		private TUnitFacing m_Facing = new UnitFacingPivot();

		public TUnitFacing Wrapper => m_Facing;

		public UnitFacing()
		{
		}

		public UnitFacing(TUnitFacing unit)
		{
			m_Facing = unit;
		}

		public override string ToString()
		{
			if (m_Facing == null)
			{
				return "(none)";
			}
			return m_Facing.ToString();
		}
	}
}
