using UnityEngine;
using UnityEngine.AI;

namespace FIMSpace.FOptimizing
{
	public static class LODInstanceGenerator
	{
		public enum ESearchMode
		{
			JustUnityComponents = 0,
			JustCustomComponents = 1,
			AllComponents = 2
		}

		public static ILODInstance GenerateInstanceOutOf(Optimizer2 callFrom, Component component, bool deepSearch = true, ESearchMode toIdentify = ESearchMode.AllComponents)
		{
			if (OptimUtils.ShouldBeIgnored(component))
			{
				return null;
			}
			if (toIdentify != ESearchMode.JustCustomComponents)
			{
				if (!Optimizer_Base._editor_DragAndDropOptim && (bool)callFrom && (bool)callFrom.OptimizationTypes && !callFrom.OptimizationTypes.IsTypeAllowed(component))
				{
					return null;
				}
				if (component is MeshRenderer)
				{
					return GenerateInstanceOutOf(component as MeshRenderer);
				}
				if (component is SkinnedMeshRenderer)
				{
					return GenerateInstanceOutOf(component as SkinnedMeshRenderer);
				}
				if (component is Light)
				{
					return GenerateInstanceOutOf(component as Light);
				}
				if (component is ParticleSystem)
				{
					return GenerateInstanceOutOf(component as ParticleSystem);
				}
				if (Optimizer_Base._HandleUnityLODWithReload && component is LODGroup)
				{
					return GenerateInstanceOutOf(component as LODGroup);
				}
				if (component is NavMeshAgent)
				{
					return GenerateInstanceOutOf(component as NavMeshAgent);
				}
				if (component is AudioSource)
				{
					return GenerateInstanceOutOf(component as AudioSource);
				}
				if (deepSearch && component is Rigidbody)
				{
					return GenerateInstanceOutOf(component as Rigidbody);
				}
			}
			if (toIdentify != ESearchMode.JustUnityComponents && component is MonoBehaviour)
			{
				return GenerateInstanceOutOf(component as MonoBehaviour);
			}
			return null;
		}

		public static ILODInstance GenerateInstanceOutOf(SkinnedMeshRenderer component)
		{
			return new LODI_Renderer();
		}

		public static ILODInstance GenerateInstanceOutOf(MeshRenderer component)
		{
			return new LODI_Renderer();
		}

		public static ILODInstance GenerateInstanceOutOf(Light component)
		{
			return new LODI_Light();
		}

		public static ILODInstance GenerateInstanceOutOf(ParticleSystem component)
		{
			return new LODI_ParticleSystem();
		}

		public static ILODInstance GenerateInstanceOutOf(AudioSource component)
		{
			return new LODI_AudioSource();
		}

		public static ILODInstance GenerateInstanceOutOf(MonoBehaviour component)
		{
			return new LODI_MonoBehaviour();
		}

		public static ILODInstance GenerateInstanceOutOf(Rigidbody component)
		{
			return new LODI_Rigidbody();
		}

		public static ILODInstance GenerateInstanceOutOf(Terrain component)
		{
			return new LODI_Terrain();
		}

		public static ILODInstance GenerateInstanceOutOf(LODGroup component)
		{
			return new LODI_UnityLOD();
		}

		public static ILODInstance GenerateInstanceOutOf(NavMeshAgent component)
		{
			return new LODI_NavMeshAgent();
		}
	}
}
