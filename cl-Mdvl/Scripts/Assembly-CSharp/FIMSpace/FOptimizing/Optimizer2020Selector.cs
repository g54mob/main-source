using UnityEngine;
using UnityEngine.AI;

namespace FIMSpace.FOptimizing
{
	[CreateAssetMenu(menuName = "Optimizer 2019_4+ Types Setup")]
	public class Optimizer2020Selector : ScriptableObject
	{
		public bool Light = true;

		public bool Particle = true;

		public bool Renderer = true;

		public bool SkinnedRenderer = true;

		public bool MonoBehaviour = true;

		public bool AudioSource;

		public bool NavMeshAgent;

		public bool Rigidbody;

		public bool IsTypeAllowed(Component type)
		{
			if (type is ParticleSystem)
			{
				return Particle;
			}
			if (type is Light)
			{
				return Light;
			}
			if (type is SkinnedMeshRenderer)
			{
				return SkinnedRenderer;
			}
			if (type is Renderer)
			{
				return Renderer;
			}
			if (type is MonoBehaviour)
			{
				return MonoBehaviour;
			}
			if (type is AudioSource)
			{
				return AudioSource;
			}
			if (type is NavMeshAgent)
			{
				return NavMeshAgent;
			}
			if (type is Rigidbody)
			{
				return Rigidbody;
			}
			return false;
		}
	}
}
