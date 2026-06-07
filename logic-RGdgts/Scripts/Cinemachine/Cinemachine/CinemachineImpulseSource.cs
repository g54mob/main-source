using UnityEngine;

namespace Cinemachine
{
	[SaveDuringPlay]
	public class CinemachineImpulseSource : MonoBehaviour
	{
		[CinemachineImpulseDefinitionProperty]
		public CinemachineImpulseDefinition m_ImpulseDefinition;

		private void OnValidate()
		{
		}

		public void GenerateImpulseAt(Vector3 position, Vector3 velocity)
		{
		}

		public void GenerateImpulse(Vector3 velocity)
		{
		}

		public void GenerateImpulse(float force)
		{
		}

		public void GenerateImpulse()
		{
		}
	}
}
