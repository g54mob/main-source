using System.Collections.Generic;
using UnityEngine;

namespace GameCreator.Runtime.Cameras
{
	internal abstract class TCameraShake : ICameraShake
	{
		protected readonly List<ShakeSystem> m_ShakeSystems = new List<ShakeSystem>();

		public Vector3 AdditivePosition { get; private set; }

		public Vector3 AdditiveRotation { get; private set; }

		public void Update(TCamera camera)
		{
			AdditivePosition = Vector3.zero;
			AdditiveRotation = Vector3.zero;
			for (int num = m_ShakeSystems.Count - 1; num >= 0; num--)
			{
				m_ShakeSystems[num].Update(camera);
				AdditivePosition += m_ShakeSystems[num].ValuePosition;
				AdditiveRotation += m_ShakeSystems[num].ValueRotation;
				if (m_ShakeSystems[num].IsComplete)
				{
					OnComplete(m_ShakeSystems[num]);
					m_ShakeSystems.RemoveAt(num);
				}
			}
		}

		protected virtual void OnComplete(ShakeSystem shakeSystem)
		{
		}
	}
}
