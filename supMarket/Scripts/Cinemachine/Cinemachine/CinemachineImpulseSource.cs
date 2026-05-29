using UnityEngine;

namespace Cinemachine
{
	[DocumentationSorting(DocumentationSortingAttribute.Level.UserRef)]
	[SaveDuringPlay]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.cinemachine@2.9/manual/CinemachineImpulseSourceOverview.html")]
	public class CinemachineImpulseSource : MonoBehaviour
	{
		public CinemachineImpulseDefinition m_ImpulseDefinition;

		[Header("Default Invocation")]
		[Tooltip("The default direction and force of the Impulse Signal in the absense of any specified overrides.  Overrides can be specified by calling the appropriate GenerateImpulse method in the API.")]
		public Vector3 m_DefaultVelocity;

		private void OnValidate()
		{
		}

		private void Reset()
		{
		}

		public void GenerateImpulseAtPositionWithVelocity(Vector3 position, Vector3 velocity)
		{
		}

		public void GenerateImpulseWithVelocity(Vector3 velocity)
		{
		}

		public void GenerateImpulseWithForce(float force)
		{
		}

		public void GenerateImpulse()
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
	}
}
