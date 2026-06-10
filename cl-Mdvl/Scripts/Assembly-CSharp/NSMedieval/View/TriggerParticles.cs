using System.Collections;
using NSEipix.Base;
using NSMedieval.EnvironmentEffects;
using NSMedieval.Goap;
using NSMedieval.Scripts.Pooler;
using NSMedieval.State;
using UnityEngine;

namespace NSMedieval.View
{
	public class TriggerParticles : MonoBehaviour
	{
		[SerializeField]
		private ParticleSystemForceField forceField;

		public void PlayParticle(string particleID)
		{
			if (!MonoSingleton<SceneController>.IsInstantiated() || !MonoSingleton<SceneController>.Instance.enabled || this == null || base.transform == null)
			{
				return;
			}
			Vector3? vector = Vector3.zero;
			Vector3 position = Vector3.zero;
			HumanoidInstance humanoidInstance = base.transform.GetComponent<HumanoidView>()?.HumanoidInstance;
			if (humanoidInstance == null)
			{
				return;
			}
			if (humanoidInstance.WorkerBehaviour != null)
			{
				vector = humanoidInstance.GetAgentView<WorkerView>()?.GetCurrentTool()?.GetComponent<ToolHelper>()?.ParticlePosition;
			}
			else if (humanoidInstance.IsNpc())
			{
				vector = humanoidInstance.GetAgentView<NPCView>()?.GetCurrentTool()?.GetComponent<ToolHelper>()?.ParticlePosition;
			}
			if (vector.HasValue)
			{
				position = vector.Value;
			}
			MonoSingleton<ParticleSystemPool>.Instance.PlayParticles(particleID, position);
			if (humanoidInstance.GetGoapAgent()?.CurrentGoalName != null && humanoidInstance.GetGoapAgent().CurrentGoalName.Equals("ChopTreeGoal"))
			{
				PlantMapResourceInstance objectAs = humanoidInstance.GetGoapAgent().GetCurrentGoal().GetTarget(TargetIndex.A)
					.GetObjectAs<PlantMapResourceInstance>();
				objectAs?.GetTransform()?.GetComponent<Shaker>()?.Shake(objectAs);
				GameObject gameObject = objectAs?.GetTransform()?.gameObject;
				if (!(gameObject == null) && gameObject.TryGetComponent<BirdsScare>(out var component))
				{
					component.LaunchParticlesConditions(objectAs);
				}
			}
		}

		public void ShakeCamera()
		{
			MonoSingleton<CameraManager>.Instance.OnCameraShakeEvent(base.transform.position, CameraShakeStrength.Weak);
		}

		public void AddForceToParticles()
		{
			if (!(forceField == null))
			{
				forceField.gameObject.SetActive(value: true);
				StartCoroutine(StartForce());
			}
		}

		private IEnumerator StartForce()
		{
			yield return new WaitForSeconds(1f);
			forceField.gameObject.SetActive(value: false);
		}
	}
}
