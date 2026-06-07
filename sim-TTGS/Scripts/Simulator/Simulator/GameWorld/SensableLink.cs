using System;
using UnityEngine;

namespace Simulator.GameWorld
{
	public class SensableLink : MonoBehaviour, ISensable
	{
		[SerializeField]
		private Component m_sensable;

		private ISensable m_cachedSensable;

		public bool HasSensable(out ISensable sensable)
		{
			sensable = m_cachedSensable;
			if (sensable != null)
			{
				return sensable.CanBeSensed();
			}
			return false;
		}

		private void Awake()
		{
			m_cachedSensable = m_sensable as ISensable;
		}

		public bool CanBeSensed()
		{
			return false;
		}

		public void OnSensed()
		{
			throw new NotImplementedException();
		}

		public void OnUnsensed()
		{
			throw new NotImplementedException();
		}
	}
}
