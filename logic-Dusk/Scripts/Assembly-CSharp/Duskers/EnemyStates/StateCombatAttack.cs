using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Duskers.EnemyStates
{
	public class StateCombatAttack : BaseEnemyState
	{
		private bool _loggedError;

		private float _generalAttackDamage;

		public override string StateId
		{
			get
			{
				return "CombatAttack";
			}
		}

		public override event ChangeStateDelegate ChangeState;

		public StateCombatAttack(BaseEnemyBrain brain)
			: base(brain)
		{
		}

		public override void Update()
		{
			MonoBehaviour monoBehaviour = _brain.CombatTarget as MonoBehaviour;
			if (_brain.CombatTarget == null || (monoBehaviour != null && monoBehaviour.gameObject == null))
			{
				if (!_loggedError)
				{
					_loggedError = true;
					Debug.LogWarning("StateCombatAttack - target is null???");
				}
				return;
			}
			bool flag = _brain.ThisEnemy.TargetIsInSameRoom(_brain.CombatTarget);
			bool flag2 = false;
			if (_brain.ThisEnemy.CurrentRoom != null && (!flag || _brain.CombatTarget.CurrentCorridor != null))
			{
				flag2 = _brain.ThisEnemy.LineOfSightThroughDoor(_brain.CombatTarget.Position);
				if (flag2)
				{
					flag = true;
				}
			}
			if (!flag)
			{
				Waypoint waypoint = null;
				IEnumerable<AdjacentRoomData> enumerable = from x in NavigationHelper.GetAllAdjacentRoomData(_brain.ThisEnemy.CurrentRoom)
					where _brain.ThisEnemy.AdjacentRoomCanBeEntered(x)
					select x;
				foreach (AdjacentRoomData item in enumerable)
				{
					Room room = ((!(item.Room1 == _brain.ThisEnemy.CurrentRoom)) ? item.Room1 : item.Room2);
					if (_brain.CombatTarget.CurrentRoom == room)
					{
						waypoint = NavigationHelper.GetMainRoomWaypoint(room);
						break;
					}
				}
				if (waypoint != null)
				{
					_brain.StateCombatNavigate.Initialize(waypoint, _brain.CombatTarget);
					ChangeState(_brain.StateCombatNavigate);
				}
			}
			else if (!_brain.RotatesBeforeAttack || !_brain.RotateWhileNotLookingAtTarget())
			{
				MoveToAndAttackTarget(_brain.CombatTarget, flag2);
			}
		}

		public override void EnterState()
		{
			if (_brain.CombatTarget == null)
			{
				Debug.LogWarning("CombatTarget must be set before entering " + StateId);
			}
			_loggedError = false;
			if (_brain.ThisEnemy != null)
			{
				_generalAttackDamage = _brain.ThisEnemy.AttackDamage;
			}
			_brain.InitializeRotation(_brain.CombatTarget.Position);
			_brain.StartAttackAnimation();
		}

		public override void ExitState()
		{
		}

		private void MoveToAndAttackTarget(ICombatTarget combatTarget, bool doNotCheckRoom)
		{
			Vector3 vector = combatTarget.Position;
			bool flag = false;
			if (!doNotCheckRoom && _brain.ThisEnemy.CurrentRoom != combatTarget.CurrentRoom && _brain.ThisEnemy.CurrentCorridor != combatTarget.CurrentCorridor)
			{
				Vector3 overrideDestination;
				flag = GetOverrideDestination(_brain.ThisEnemy, combatTarget, out overrideDestination);
				if (flag)
				{
					vector = overrideDestination;
				}
			}
			else if (_brain.ThisEnemy.HasBehavior(EnemyAiBehaviors.ChargesTarget) && _brain.ChargeCooldownTimer <= 0f)
			{
				ChangeState(_brain.StateCombatCharge);
				if (GlobalSettings.cameraMode == CameraMode.Drone && _brain.ThisEnemy is BruteEnemy)
				{
					int num = Random.Range(0, 4);
					GameAudio.SoundEnum key = GameAudio.SoundEnum.None;
					switch (num)
					{
					case 0:
						key = GameAudio.SoundEnum.Remote_BruteScream1;
						break;
					case 1:
						key = GameAudio.SoundEnum.Remote_BruteScream2;
						break;
					case 2:
						key = GameAudio.SoundEnum.Remote_BruteScream3;
						break;
					case 3:
						key = GameAudio.SoundEnum.Remote_BruteScream4;
						break;
					}
					((BruteEnemy)_brain.ThisEnemy).bruteScreamSound.clip = GameAudio.GetClip(key);
					((BruteEnemy)_brain.ThisEnemy).bruteScreamSound.volume = GameAudio.VolumeMultiplier(key, ((BruteEnemy)_brain.ThisEnemy).bruteScreamSound.volume);
					((BruteEnemy)_brain.ThisEnemy).bruteScreamSound.Play();
				}
				return;
			}
			float num2 = Vector3.Distance(_brain.ThisEnemy.transform.position, vector);
			float num3 = _brain.ThisEnemy.AttackRadius / 2f;
			if (flag)
			{
				num3 = 0.2f;
			}
			if (num2 > num3)
			{
				_brain.ThisEnemy.DisconnectOverlay();
				_brain.ThisEnemy.LookAt(vector);
				_brain.ThisEnemy.ReconnectOverlay();
				_brain.ThisEnemy.moveForward();
			}
			if (_generalAttackDamage != 0f)
			{
				float num4 = Vector3.Distance(_brain.ThisEnemy.transform.position, combatTarget.Position);
				if (num4 < _brain.ThisEnemy.AttackRadius && Time.time - _brain.LastAttackTimestamp >= _brain.ThisEnemy.AttackSpeed)
				{
					_brain.LastAttackTimestamp = Time.time;
					_brain.ThisEnemy.AttackTarget(combatTarget);
				}
			}
		}

		public static bool GetOverrideDestination(ICombatTarget thisEnemy, ITargetLocation combatTargetLocation, out Vector3 overrideDestination)
		{
			bool result = false;
			overrideDestination = Vector3.zero;
			Waypoint bestDoorWaypoint = GetBestDoorWaypoint(thisEnemy, combatTargetLocation);
			if (bestDoorWaypoint != null)
			{
				if (combatTargetLocation.CurrentRoom != null && thisEnemy.CurrentCorridor != null)
				{
					if (thisEnemy.CurrentCorridor.door.IsHorizontal)
					{
						overrideDestination = new Vector3(combatTargetLocation.CurrentRoom.transform.position.x, bestDoorWaypoint.transform.position.y, bestDoorWaypoint.transform.position.z);
					}
					else
					{
						overrideDestination = new Vector3(bestDoorWaypoint.transform.position.x, combatTargetLocation.CurrentRoom.transform.position.y, bestDoorWaypoint.transform.position.z);
					}
				}
				else
				{
					overrideDestination = bestDoorWaypoint.transform.position;
				}
				result = true;
			}
			return result;
		}

		private static Waypoint GetBestDoorWaypoint(ICombatTarget thisEnemy, ITargetLocation combatTargetLocation)
		{
			Waypoint waypoint = null;
			if (thisEnemy.CurrentRoom != null && combatTargetLocation.CurrentCorridor != null)
			{
				AdjacentRoomData adjacentRoomData = NavigationHelper.GetAdjacentRoomData(combatTargetLocation.CurrentCorridor.door);
				if (adjacentRoomData != null)
				{
					float num = 0f;
					foreach (Waypoint connectingWaypoint in adjacentRoomData.ConnectingWaypoints)
					{
						if (!(connectingWaypoint.Door == null))
						{
							float num2 = Vector3.Distance(thisEnemy.Position, connectingWaypoint.transform.position);
							if (waypoint == null || num2 < num)
							{
								num = num2;
								waypoint = connectingWaypoint;
							}
						}
					}
				}
			}
			else if (thisEnemy.CurrentCorridor != null && combatTargetLocation.CurrentRoom != null)
			{
				AdjacentRoomData adjacentRoomData2 = NavigationHelper.GetAdjacentRoomData(thisEnemy.CurrentCorridor.door);
				float num3 = 0f;
				foreach (Waypoint connectingWaypoint2 in adjacentRoomData2.ConnectingWaypoints)
				{
					if (!(connectingWaypoint2.Door == null))
					{
						float num4 = Vector3.Distance(combatTargetLocation.Position, connectingWaypoint2.transform.position);
						if (waypoint == null || num4 < num3)
						{
							num3 = num4;
							waypoint = connectingWaypoint2;
						}
					}
				}
			}
			return waypoint;
		}
	}
}
