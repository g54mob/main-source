using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.Controllers;
using NSMedieval.Goap;
using NSMedieval.Model;
using NSMedieval.Repository;
using UnityEngine;

namespace NSMedieval.Manager
{
	public class CombatTargetIndicatorManager : MonoSingleton<CombatTargetIndicatorManager>
	{
		private GameObject targetIndicatorGameObject;

		private IDamageDealAgent selected;

		private GameObject TargetIndicatorGameObject
		{
			get
			{
				if (targetIndicatorGameObject == null)
				{
					targetIndicatorGameObject = Object.Instantiate(MonoRepository<PrefabRepository, KeyGameObjectPair>.Instance.GetByAddress("target_indicator"));
					targetIndicatorGameObject.SetActive(value: false);
				}
				return targetIndicatorGameObject;
			}
			set
			{
				targetIndicatorGameObject = value;
			}
		}

		public void ShowIndicator(IDamageTakingAgent agent)
		{
			if (CombatUtils.IsAlive(agent))
			{
				if (!TargetIndicatorGameObject.activeSelf)
				{
					TargetIndicatorGameObject.SetActive(value: true);
				}
				TargetIndicatorGameObject.transform.SetParent(agent.GetTransform());
				TargetIndicatorGameObject.transform.localPosition = Vector3.zero;
			}
		}

		public void HideIndicator()
		{
			if (!LoadingController.IsSceneTransition && !(targetIndicatorGameObject == null) && targetIndicatorGameObject.activeSelf)
			{
				targetIndicatorGameObject.SetActive(value: false);
				targetIndicatorGameObject.transform.SetParent(null);
			}
		}

		private void AgentSelected(Agent agent)
		{
			if (agent == null)
			{
				return;
			}
			if (!(agent.AgentOwner is IDamageDealAgent damageDealAgent))
			{
				HideIndicator();
			}
			else if (selected != agent.AgentOwner)
			{
				selected = damageDealAgent;
				IDamageTakingAgent preferredTarget = MonoSingleton<CombatTargetManager>.Instance.GetPreferredTarget(selected);
				if (preferredTarget == null)
				{
					HideIndicator();
				}
				else
				{
					ShowIndicator(preferredTarget);
				}
			}
		}

		private void AgentDeselected(Agent agent)
		{
			if (selected != null && agent != null && agent.AgentOwner is IDamageDealAgent)
			{
				HideIndicator();
				selected = null;
			}
		}

		private void PreferedTargetUpdated(IDamageDealAgent deal, IDamageTakingAgent newTarget, IDamageTakingAgent oldTarget)
		{
			if (deal == selected)
			{
				if (newTarget == null)
				{
					HideIndicator();
				}
				else
				{
					ShowIndicator(newTarget);
				}
			}
		}

		private void Start()
		{
			MonoSingleton<GoapController>.Instance.AgentDeselectedEvent += AgentDeselected;
			MonoSingleton<GoapController>.Instance.AgentSelectedEvent += AgentSelected;
			MonoSingleton<CombatController>.Instance.PreferedTargetUpdateEvent += PreferedTargetUpdated;
		}

		private void LateUpdate()
		{
			if (!(targetIndicatorGameObject == null) && targetIndicatorGameObject.activeInHierarchy)
			{
				targetIndicatorGameObject.transform.rotation = Quaternion.identity;
			}
		}
	}
}
