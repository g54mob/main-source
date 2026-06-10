using UnityEngine;

namespace FIMSpace.FOptimizing
{
	[CreateAssetMenu(menuName = "Essential Types Setup")]
	public class EssentialOptimizerSelector : ScriptableObject
	{
		public bool Light = true;

		public bool Particle = true;

		public bool Renderer = true;

		public bool MonoBehaviour = true;

		public bool AudioSource;

		public bool NavMeshAgent;

		public bool Rigidbody;

		public bool IsTypeAllowed(EssentialLODsController.EEssType type)
		{
			switch (type)
			{
			case EssentialLODsController.EEssType.Particle:
				if (Particle)
				{
					return true;
				}
				break;
			case EssentialLODsController.EEssType.Light:
				if (Light)
				{
					return true;
				}
				break;
			case EssentialLODsController.EEssType.MonoBehaviour:
				if (MonoBehaviour)
				{
					return true;
				}
				break;
			case EssentialLODsController.EEssType.Renderer:
				if (Renderer)
				{
					return true;
				}
				break;
			case EssentialLODsController.EEssType.NavMeshAgent:
				if (NavMeshAgent)
				{
					return true;
				}
				break;
			case EssentialLODsController.EEssType.AudioSource:
				if (AudioSource)
				{
					return true;
				}
				break;
			case EssentialLODsController.EEssType.Rigidbody:
				if (Rigidbody)
				{
					return true;
				}
				break;
			}
			return false;
		}
	}
}
