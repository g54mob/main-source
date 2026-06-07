using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets.Nimbatus.Scripts.Behaviours.CoreBehaviours;
using Assets.Nimbatus.Scripts.Behaviours.Health;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.WorldObjects;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.Missions
{
	public class MissionTargetManager : BaseSingleton<MissionTargetManager>
	{
		private List<InteractiveWorldObject> _activeTargets = new List<InteractiveWorldObject>();

		private List<InteractiveWorldObject> _registeredTargets = new List<InteractiveWorldObject>();

		private List<InteractiveWorldObject> _activeTargetLookup = new List<InteractiveWorldObject>();

		protected override void Awake()
		{
			base.Awake();
			Object.DontDestroyOnLoad(base.gameObject);
		}

		public void InitMission()
		{
			Reset();
			NimbatusMission activeMission = SerializableMonobehaviour<MissionManager, MissionData>.Instance.ActiveMission;
			if (activeMission != null && activeMission.HasMissionTargets)
			{
				_activeTargetLookup = activeMission.MissionTargets;
				StartCoroutine(CheckMissionTargets());
			}
		}

		public void Reset()
		{
			StopCoroutine(CheckMissionTargets());
			_activeTargets = new List<InteractiveWorldObject>();
			_activeTargetLookup = new List<InteractiveWorldObject>();
			_registeredTargets = new List<InteractiveWorldObject>();
		}

		public bool GetDirectionToNearestMissionTarget(Vector3 position, out Vector3 direction)
		{
			direction = Vector3.zero;
			if (_activeTargets.Count <= 0)
			{
				return false;
			}
			float num = float.MaxValue;
			foreach (InteractiveWorldObject activeTarget in _activeTargets)
			{
				if (!(activeTarget == null))
				{
					float num2 = Vector2.Distance(position, activeTarget.transform.position);
					if (num2 < num)
					{
						num = num2;
						direction = activeTarget.transform.position - position;
					}
				}
			}
			return true;
		}

		public bool IsDetectedAsMissionTarget(GameObject g)
		{
			return g.CompareTag("MissionTarget");
		}

		public void UpdateStatus(InteractiveWorldObject worldObject)
		{
			if (CheckIfTargetShouldBeActivated(worldObject))
			{
				Register(worldObject);
			}
			else
			{
				UnRegister(worldObject);
			}
		}

		public IEnumerator CheckMissionTargets()
		{
			while (true)
			{
				foreach (InteractiveWorldObject item in _registeredTargets.ToList())
				{
					if (CheckIfTargetShouldBeActivated(item))
					{
						if (!_activeTargets.Contains(item))
						{
							item.gameObject.tag = "MissionTarget";
							_activeTargets.Add(item);
						}
					}
					else if (_activeTargets.Contains(item))
					{
						_activeTargets.Remove(item);
						if (item != null && item.gameObject != null)
						{
							item.gameObject.tag = "Untagged";
						}
					}
					yield return true;
				}
				yield return new WaitForSeconds(1f);
			}
		}

		private bool CheckIfTargetShouldBeActivated(InteractiveWorldObject worldObject)
		{
			if (worldObject == null)
			{
				return false;
			}
			if (_activeTargetLookup.All((InteractiveWorldObject at) => at.UniqueId != worldObject.UniqueId))
			{
				return false;
			}
			NimbatusMission activeMission = SerializableMonobehaviour<MissionManager, MissionData>.Instance.ActiveMission;
			if (activeMission != null)
			{
				switch (activeMission.MissionType)
				{
				case EMissionType.FreezeVolcanos:
					if (worldObject.HealthPool.CurrentState == EChemicalState.Frozen)
					{
						return false;
					}
					return true;
				case EMissionType.DestroyLaboratory:
				{
					ShieldBehaviour coreBehaviour = worldObject.Behaviour.GetCoreBehaviour<ShieldBehaviour>();
					if (coreBehaviour != null && coreBehaviour.IsActive)
					{
						return false;
					}
					break;
				}
				case EMissionType.CollectJungleRelic:
					if (!worldObject.IsCollectable && worldObject.HealthPool.CurrentState == EChemicalState.Burning)
					{
						return false;
					}
					break;
				case EMissionType.AsteroidCorpFracking:
				{
					ShieldBehaviour coreBehaviour = worldObject.Behaviour.GetCoreBehaviour<ShieldBehaviour>();
					if (coreBehaviour != null && coreBehaviour.IsActive)
					{
						return false;
					}
					break;
				}
				}
			}
			return true;
		}

		public void Register(InteractiveWorldObject worldObject)
		{
			if (_activeTargetLookup.Any((InteractiveWorldObject at) => at.UniqueId == worldObject.UniqueId) && !_registeredTargets.Contains(worldObject))
			{
				_registeredTargets.Add(worldObject);
			}
		}

		public void UnRegister(InteractiveWorldObject worldObject)
		{
			if (_registeredTargets.Contains(worldObject))
			{
				_registeredTargets.Remove(worldObject);
			}
			if (_activeTargets.Contains(worldObject))
			{
				_activeTargets.Remove(worldObject);
				worldObject.gameObject.tag = "Untagged";
			}
		}
	}
}
