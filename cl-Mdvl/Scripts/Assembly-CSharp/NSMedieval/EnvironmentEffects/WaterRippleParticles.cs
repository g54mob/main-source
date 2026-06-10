using NSEipix.Base;
using NSMedieval.Map;
using NSMedieval.Scripts.Pooler;
using NSMedieval.State;
using NSMedieval.View;
using NSMedieval.Village.Map;
using UnityEngine;

namespace NSMedieval.EnvironmentEffects
{
	public class WaterRippleParticles : MonoBehaviour
	{
		[SerializeField]
		private EmitParticleOnAnimationTrigger transforms;

		private CreatureBase creature;

		public void EmmitRipple(Limbs limb)
		{
			if (transforms == null)
			{
				return;
			}
			switch (limb)
			{
			case Limbs.LeftArm:
				if (!(transforms.LeftArm == null))
				{
					EmmitParticle(transforms.LeftArm);
				}
				break;
			case Limbs.RightArm:
				if (!(transforms.RightArm == null))
				{
					EmmitParticle(transforms.RightArm);
				}
				break;
			case Limbs.LeftFoot:
				if (!(transforms.LeftFoot == null))
				{
					EmmitParticle(transforms.LeftFoot);
				}
				break;
			case Limbs.RightFoot:
				if (!(transforms.RightFoot == null))
				{
					EmmitParticle(transforms.RightFoot);
				}
				break;
			case Limbs.Pelvis:
				if (!(transforms.Pelvis == null))
				{
					EmmitParticle(transforms.Pelvis);
				}
				break;
			}
		}

		private void EmmitParticle(Transform tfm)
		{
			if (creature != null && !creature.HasDisposed && creature.Map != null)
			{
				MapNode node = creature.Map.GetNode(creature.GetGridPosition());
				if (node != null)
				{
					Vector3 position = tfm.position;
					Vector3 position2 = new Vector3(position.x, node.WorldPosition.y + GetWaterLevel(node) + 0.01f, position.z);
					MonoSingleton<ParticleSystemPool>.Instance.PlayParticles("water_ripple", position2);
				}
			}
		}

		private float GetWaterLevel(MapNode node)
		{
			if (node?.Map?.WaterManager != null)
			{
				return node.Map.WaterManager.GetWaterLevel(node.Index) * (float)World.MapBlockHeight;
			}
			return 0f;
		}

		private void Start()
		{
			if (base.gameObject.TryGetComponent<AnimatedAgentView>(out var component))
			{
				creature = component.GetAsCreature();
			}
		}
	}
}
