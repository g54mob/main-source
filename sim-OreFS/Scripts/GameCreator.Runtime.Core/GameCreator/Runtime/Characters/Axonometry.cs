using System;
using UnityEngine;

namespace GameCreator.Runtime.Characters
{
	[Serializable]
	public class Axonometry : ICloneable
	{
		[SerializeReference]
		private TAxonometry m_Axonometry = new AxonometryNone();

		public Vector3 ProcessTranslation(TUnitDriver driver, Vector3 movement)
		{
			return m_Axonometry?.ProcessTranslation(driver, movement) ?? movement;
		}

		public void ProcessPosition(TUnitDriver driver, Vector3 position)
		{
			m_Axonometry?.ProcessPosition(driver, position);
		}

		public Vector3 ProcessRotation(TUnitFacing facing, Vector3 direction)
		{
			return m_Axonometry?.ProcessRotation(facing, direction) ?? direction;
		}

		public object Clone()
		{
			return new Axonometry
			{
				m_Axonometry = (m_Axonometry.Clone() as TAxonometry)
			};
		}

		public override string ToString()
		{
			return m_Axonometry.ToString();
		}
	}
}
