#define LOG_LEVEL_VERBOSE
using System;
using UnityEngine;
using UnityEngine.AI;

namespace TH20
{
	public class NavPath : MustCallDestroy
	{
		public enum EState
		{
			Idle = 0,
			Running = 1
		}

		private class NavMeshAgentSettings
		{
			private bool enabled;

			private bool updatePosition;

			private bool updateRotation;

			private float speed;

			private float angularSpeed;

			private float acceleration;

			private float stoppingDistance;

			private bool autoBraking;

			private float radius;

			private bool autoTraverseOffMeshLink;

			private ObstacleAvoidanceType obstacleAvoidanceType;

			private float baseOffset;

			private int avoidancePriority;

			public NavMeshAgentSettings(NavMeshAgent agent)
			{
				enabled = agent.enabled;
				updatePosition = agent.updatePosition;
				updateRotation = agent.updateRotation;
				speed = agent.speed;
				angularSpeed = agent.angularSpeed;
				acceleration = agent.acceleration;
				stoppingDistance = agent.stoppingDistance;
				autoBraking = agent.autoBraking;
				radius = agent.radius;
				autoTraverseOffMeshLink = agent.autoTraverseOffMeshLink;
				obstacleAvoidanceType = agent.obstacleAvoidanceType;
				baseOffset = agent.baseOffset;
				avoidancePriority = agent.avoidancePriority;
			}

			public void Restore(NavMeshAgent agent)
			{
				agent.enabled = enabled;
				agent.updatePosition = updatePosition;
				agent.updateRotation = updateRotation;
				agent.speed = speed;
				agent.angularSpeed = angularSpeed;
				agent.acceleration = acceleration;
				agent.stoppingDistance = stoppingDistance;
				agent.autoBraking = autoBraking;
				agent.radius = radius;
				agent.autoTraverseOffMeshLink = autoTraverseOffMeshLink;
				agent.obstacleAvoidanceType = obstacleAvoidanceType;
				agent.baseOffset = baseOffset;
				agent.avoidancePriority = avoidancePriority;
			}
		}

		private static float IGNORE_ROTATION = float.PositiveInfinity;

		private readonly Character _character;

		private readonly ObstacleAvoidanceType _obstacleAvoidanceType;

		[DontSave]
		private NavMeshAgent _navMeshAgent;

		private NavMeshAgentSettings _navMeshAgentSettings;

		private Vector3 _endPosition;

		private float _endRotation;

		private EState _state;

		private INavPathResult _completeCallback;

		private float _arrivalDistance;

		private float _lastRequestTime;

		private float _rotationArriving;

		private bool _rotatingToArrivalRotation;

		private float _arrivalTime;

		private float _timeToRotate;

		private float _blockedByCrowdTime;

		private static float TimeBeforeEnteringGhostMode = 3f;

		private float _ghostTimeLeft;

		private static float TimeToStayInGhostMode = 3f;

		private float _stuckTime;

		private static float TimeBeforeConsideredStuck = 10f;

		private float _maxSpeed;

		private static Vector3[] _cornersCache = new Vector3[64];

		[DontSave]
		private static GUIStyle _debugGUIStyle;

		public EState State => _state;

		public bool IsKinematic => !_navMeshAgent.updatePosition;

		public NavPath(Character character, bool startDisabled)
		{
			_state = EState.Idle;
			_character = character;
			_obstacleAvoidanceType = character.Definition.ObstacleAvoidanceType;
			_maxSpeed = _character.GetMaxMovementSpeed();
			_navMeshAgent = _character.GameObject.AddComponent<NavMeshAgent>();
			_navMeshAgent.updatePosition = true;
			_navMeshAgent.updateRotation = true;
			_navMeshAgent.speed = _maxSpeed;
			_navMeshAgent.angularSpeed = _character.Definition._turnSpeed * 360f;
			_navMeshAgent.acceleration = _character.Definition._accelerationSpeed;
			_navMeshAgent.stoppingDistance = 0.5f;
			_navMeshAgent.autoBraking = true;
			_navMeshAgent.radius = 0.25f;
			_navMeshAgent.autoTraverseOffMeshLink = false;
			_navMeshAgent.obstacleAvoidanceType = _obstacleAvoidanceType;
			if (startDisabled)
			{
				RemoveFromNavWorld();
			}
			else
			{
				WarpInternal(character.Position);
			}
			_navMeshAgent.baseOffset = -0.04166669f;
			if (_obstacleAvoidanceType == ObstacleAvoidanceType.NoObstacleAvoidance)
			{
				_navMeshAgent.avoidancePriority = 99;
			}
		}

		public override void Destroy()
		{
			_completeCallback = null;
			base.Destroy();
		}

		public void OnBeforeSave()
		{
			if (_navMeshAgent != null)
			{
				_navMeshAgentSettings = new NavMeshAgentSettings(_navMeshAgent);
			}
		}

		public override void RestoreFromSave()
		{
			base.RestoreFromSave();
			Vector3 position = _character.Position;
			_navMeshAgent = _character.GameObject.AddComponent<NavMeshAgent>();
			if (_navMeshAgentSettings != null)
			{
				_navMeshAgentSettings.Restore(_navMeshAgent);
			}
			else
			{
				Logging.Error(LogChannels.SaveDebug, "Restoring a NavPath that has no _navMeshAgentSettings - must have been destroyed before saving, so didn't get an OnBeforeSave call.");
			}
			_character.Position = position;
			if (_state == EState.Running)
			{
				_lastRequestTime = GameTime.unscaledTime;
				_navMeshAgent.SetDestination(_endPosition);
			}
			if (_maxSpeed <= 0f)
			{
				_maxSpeed = _character.GetMaxMovementSpeed();
			}
		}

		public bool IsNavigating()
		{
			return _state != EState.Idle;
		}

		private bool IsRotationValid()
		{
			return !_endRotation.Equals(IGNORE_ROTATION);
		}

		private void CallCompleteCallback(EPathStatus status)
		{
			if (_completeCallback != null)
			{
				INavPathResult completeCallback = _completeCallback;
				_completeCallback = null;
				completeCallback.OnPathComplete(status);
			}
		}

		public void ClearExistingCallback(INavPathResult callback)
		{
			if (_completeCallback == callback)
			{
				_completeCallback = null;
			}
		}

		public void MoveTo(Vector3 position, INavPathResult callback, float arrivalDistance = 0f)
		{
			MoveTo(position, IGNORE_ROTATION, callback, arrivalDistance);
		}

		public void MoveTo(Vector3 position, float rotation, INavPathResult callback, float arrivalDistance = 0f)
		{
			if (IsNavigating())
			{
				CallCompleteCallback(EPathStatus.Interrupted);
			}
			_endPosition = position;
			_endRotation = rotation;
			_completeCallback = callback;
			_arrivalDistance = arrivalDistance;
			_rotationArriving = _character.RotationY;
			_rotatingToArrivalRotation = false;
			_navMeshAgent.updateRotation = true;
			_navMeshAgent.stoppingDistance = _arrivalDistance;
			if (!_navMeshAgent.enabled)
			{
				Logging.Warning(_navMeshAgent, LogChannels.Pathfinding, "Failed to set nav agent destination for {0} as the nav agent is disabled", _character);
				CallCompleteCallback(EPathStatus.Failure);
				return;
			}
			_lastRequestTime = GameTime.unscaledTime;
			if (!_navMeshAgent.isOnNavMesh || !_navMeshAgent.SetDestination(_endPosition))
			{
				Logging.Warning(_navMeshAgent, LogChannels.Pathfinding, "Failed to set nav agent destination for {0}", _character);
				CallCompleteCallback(EPathStatus.Failure);
				return;
			}
			if (IsKinematic)
			{
				Logging.Warning(_navMeshAgent, LogChannels.Pathfinding, "Failed to set nav agent destination for {0} as the nav agent is kinematic", _character);
				CallCompleteCallback(EPathStatus.Failure);
				return;
			}
			if (_completeCallback != null)
			{
				_completeCallback.OnStartPath();
			}
			_stuckTime = 0f;
			_state = EState.Running;
			float num = Vector3.Distance(_character.Position, _endPosition);
			if (num <= _arrivalDistance || num <= 0.5f)
			{
				UpdateFinalRotation();
			}
			if (DebugVars.ShowNavMeshUpdateDebug.Value)
			{
				DebugDrawUtils.Arrow(_endPosition + Vector3.up * 0.5f, IsRotationValid() ? _endRotation : _character.RotationY, Color.cyan, 10f);
			}
		}

		private void OnReachedTarget()
		{
			if (Math.Abs(_arrivalDistance) < 0.001f)
			{
				if (_character.Position.SquareDistance2D(_endPosition) > (float)MathUtils.Square(2))
				{
					Logging.Info(_navMeshAgent, LogChannels.Pathfinding, "Snapping {0} position from {1} to {2} (nav agent dest = {3})", _character, _character.Position, _endPosition, _navMeshAgent.destination);
				}
				_character.Position = _endPosition;
				if (IsRotationValid())
				{
					_character.RotationY = _endRotation;
				}
			}
			CallCompleteCallback(EPathStatus.Success);
			_state = EState.Idle;
			Halt();
		}

		private void OnPathfindFailed()
		{
			Logging.Warning(_navMeshAgent, LogChannels.Pathfinding, "Failed to generate path for character {0}.", _character);
			_character.Level.CharacterEvents.OnCharacterNavFailure.InvokeSafe(_character, _endPosition);
			CallCompleteCallback(EPathStatus.Failure);
			_state = EState.Idle;
			Halt();
		}

		public void Halt()
		{
			bool num = IsNavigating();
			_state = EState.Idle;
			if (num)
			{
				CallCompleteCallback(EPathStatus.Interrupted);
			}
			if (_navMeshAgent.enabled && _navMeshAgent.isOnNavMesh)
			{
				_navMeshAgent.isStopped = true;
				_navMeshAgent.ResetPath();
				_navMeshAgent.velocity = Vector3.zero;
			}
			_completeCallback = null;
			_character.MovementSpeed = 0f;
		}

		public void RemoveFromNavWorld()
		{
			_navMeshAgent.enabled = false;
		}

		public void PutBackInNavWorld()
		{
			_navMeshAgent.enabled = true;
			WarpInternal(_character.Position);
		}

		public void BecomeKinematic()
		{
			if (_navMeshAgent.isOnNavMesh)
			{
				_navMeshAgent.updatePosition = false;
				_navMeshAgent.avoidancePriority = 0;
				_navMeshAgent.isStopped = true;
				_navMeshAgent.ResetPath();
				_navMeshAgent.velocity = Vector3.zero;
			}
			else
			{
				Logging.Warning(_navMeshAgent, LogChannels.Pathfinding, "Failed to become kinematic ({0}) because agent is off the nav mesh", _character);
			}
		}

		public void StopBeingKinematic()
		{
			WarpInternal(_character.Position);
			if (_navMeshAgent.isOnNavMesh)
			{
				_navMeshAgent.updatePosition = true;
				_navMeshAgent.isStopped = false;
				_navMeshAgent.avoidancePriority = 50;
			}
			else
			{
				Logging.Warning(_navMeshAgent, LogChannels.Pathfinding, "Failed to stop being kinematic ({0}) because agent is off the nav mesh", _character);
			}
		}

		public void Warp(Vector3 position)
		{
			Halt();
			if (DebugVars.ShowPathfindingDebug.Value)
			{
				DebugDrawUtils.Marker(position, Color.yellow, 5f);
			}
			WarpInternal(position);
		}

		private void WarpInternal(Vector3 position)
		{
			bool flag = _navMeshAgent.Warp(position);
			if (!flag)
			{
				Logging.Warning(_navMeshAgent, LogChannels.Pathfinding, "Failed to warp ({0}) to ({1}) attempting to move on to nav mesh...", _character, position);
				if (UnityEngine.AI.NavMesh.SamplePosition(position, out var hit, 20f, -1))
				{
					flag = _navMeshAgent.Warp(hit.position);
				}
				if (!flag)
				{
					Logging.Error(_navMeshAgent, LogChannels.Pathfinding, "Completely failed to warp ({0}) to ({1})", _character, position);
				}
			}
		}

		public void Update()
		{
			if (_navMeshAgent == null)
			{
				return;
			}
			if (_state == EState.Running && !_navMeshAgent.pathPending && _navMeshAgent.enabled)
			{
				if (_navMeshAgent.pathStatus == NavMeshPathStatus.PathInvalid || _navMeshAgent.pathStatus == NavMeshPathStatus.PathPartial)
				{
					OnPathfindFailed();
				}
				else if (_navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance || _rotatingToArrivalRotation)
				{
					if (_navMeshAgent.destination.SquareDistance2D(_endPosition) > (float)MathUtils.Square(2))
					{
						UnstickCharacter();
					}
					else if (!IsRotationValid())
					{
						OnReachedTarget();
					}
					else
					{
						UpdateFinalRotation();
					}
				}
				else if (_navMeshAgent.velocity.magnitude <= 0f || _navMeshAgent.path.GetCornersNonAlloc(_cornersCache) == 0)
				{
					if (Time.timeScale > 0f)
					{
						_stuckTime += Time.unscaledDeltaTime;
						if (_stuckTime >= TimeBeforeConsideredStuck)
						{
							Logging.Info(_navMeshAgent, LogChannels.Pathfinding, "Agent {0} seems to be stuck pathing to destination", _character);
							UnstickCharacter();
						}
					}
				}
				else
				{
					_stuckTime = 0f;
				}
			}
			if (_ghostTimeLeft > 0f)
			{
				_ghostTimeLeft -= Time.deltaTime;
				if (_ghostTimeLeft <= 0f)
				{
					_ghostTimeLeft = 0f;
					_navMeshAgent.obstacleAvoidanceType = _obstacleAvoidanceType;
				}
			}
			if (_state == EState.Running && !_rotatingToArrivalRotation)
			{
				if (_navMeshAgent.velocity.magnitude < _character.WalkSpeed && Math.Abs(_ghostTimeLeft) < 0.01f)
				{
					_blockedByCrowdTime += Time.deltaTime;
					if (_blockedByCrowdTime > TimeBeforeEnteringGhostMode)
					{
						_navMeshAgent.obstacleAvoidanceType = ObstacleAvoidanceType.NoObstacleAvoidance;
						_ghostTimeLeft = TimeToStayInGhostMode;
						_blockedByCrowdTime = 0f;
					}
				}
				else
				{
					_blockedByCrowdTime = 0f;
				}
				if (IsRotationValid())
				{
					float num = 0.5f;
					float num2 = Vector3.Distance(_character.Position, _endPosition);
					if (num2 <= num + _navMeshAgent.stoppingDistance)
					{
						float t = Mathf.Max(num2 - _navMeshAgent.stoppingDistance, 0f) / num;
						_navMeshAgent.updateRotation = false;
						_character.RotationY = Mathf.LerpAngle(_endRotation, _rotationArriving, t);
					}
					else
					{
						_navMeshAgent.updateRotation = true;
						_rotationArriving = _character.RotationY;
					}
				}
			}
			CalculateMaxSpeed();
			_character.MovementSpeed = _navMeshAgent.velocity.magnitude / _character.WalkSpeed;
		}

		private void CalculateMaxSpeed()
		{
			if (_character.GameObject != null)
			{
				Transform transform = _character.GameObject.transform;
				if (transform != null)
				{
					float num = 1f - 0.9f * Vector3.Angle(transform.forward, _navMeshAgent.steeringTarget - transform.position) / 180f;
					_navMeshAgent.speed = _maxSpeed * num;
				}
			}
		}

		private void UnstickCharacter()
		{
			_stuckTime = 0f;
			_lastRequestTime = GameTime.unscaledTime;
			_navMeshAgent.isStopped = true;
			_navMeshAgent.ResetPath();
			_navMeshAgent.velocity = Vector3.zero;
			_navMeshAgent.SetDestination(_endPosition);
		}

		private void UpdateFinalRotation()
		{
			if (!_rotatingToArrivalRotation && IsRotationValid())
			{
				_arrivalTime = GameTime.time;
				_rotationArriving = _character.RotationY;
				_timeToRotate = Mathf.Abs(Mathf.DeltaAngle(_rotationArriving, _endRotation)) / 180f;
				if (_timeToRotate < 0.001f)
				{
					OnReachedTarget();
				}
				else
				{
					_timeToRotate *= 0.75f;
					_rotatingToArrivalRotation = true;
					_navMeshAgent.updateRotation = false;
				}
			}
			if (_rotatingToArrivalRotation)
			{
				float num = (GameTime.time - _arrivalTime) / _timeToRotate;
				if (num >= 1f)
				{
					_rotatingToArrivalRotation = false;
					_navMeshAgent.updateRotation = true;
					OnReachedTarget();
				}
				else
				{
					_character.RotationY = Mathf.LerpAngle(_rotationArriving, _endRotation, num);
				}
			}
		}

		public void DrawPath()
		{
			NavMeshPath path = _navMeshAgent.path;
			if (path.corners.Length >= 2)
			{
				int i = 1;
				Vector3 start = path.corners[0];
				for (; i < path.corners.Length; i++)
				{
					Vector3 vector = path.corners[i];
					DebugDrawUtils.Line(start, vector, Color.cyan);
					start = vector;
				}
			}
		}

		public void SetMaxSpeed(float maxSpeed)
		{
			maxSpeed *= RandomUtils.GlobalRandomInstance.NextFloat(0.9f, 1.1f);
			_maxSpeed = maxSpeed;
		}

		public Vector3 PathEndPosition()
		{
			return _endPosition;
		}

		public void SetAcceleration(float acceleration)
		{
			if (_navMeshAgent != null)
			{
				_navMeshAgent.acceleration = acceleration;
			}
		}

		public static void DebugGUI(CharacterManager characterManager)
		{
			if (!DebugVars.ShowNavPathInfo.Value)
			{
				return;
			}
			if (_debugGUIStyle == null)
			{
				_debugGUIStyle = new GUIStyle(GUI.skin.box)
				{
					alignment = TextAnchor.UpperLeft,
					font = Font.CreateDynamicFontFromOSFont("Consolas", 12),
					fontStyle = FontStyle.Bold
				};
			}
			string empty = string.Empty;
			int count = characterManager.AllCharacters.Count;
			int numActiveAgents = 0;
			int numCalculating = 0;
			int numNavigating = 0;
			int numRequestsPerSecond = 0;
			foreach (Character allCharacter in characterManager.AllCharacters)
			{
				allCharacter.NavPath.GetDebugStats(ref numActiveAgents, ref numCalculating, ref numNavigating, ref numRequestsPerSecond);
			}
			empty += "NAVIGATION DETAILS\n";
			empty += $"\n         Num Agents = {count,8}";
			empty += $"\n  Num Active Agents = {numActiveAgents,8}";
			empty += $"\n    Num Calculating = {numCalculating,8}";
			empty += $"\n     Num Navigating = {numNavigating,8}";
			empty += $"\n   Paths Per Second = {numRequestsPerSecond,8}";
			Vector2 vector = _debugGUIStyle.CalcSize(new GUIContent(empty));
			GUI.Box(new Rect(0f, 0f, vector.x, vector.y), empty, _debugGUIStyle);
		}

		private void GetDebugStats(ref int numActiveAgents, ref int numCalculating, ref int numNavigating, ref int numRequestsPerSecond)
		{
			if (_navMeshAgent.enabled)
			{
				numActiveAgents++;
			}
			if (_state == EState.Running && _navMeshAgent.pathPending && _navMeshAgent.enabled)
			{
				numCalculating++;
			}
			if (_state == EState.Running && !_navMeshAgent.pathPending && _navMeshAgent.enabled)
			{
				numNavigating++;
			}
			if (GameTime.unscaledTime - _lastRequestTime < 1f)
			{
				numRequestsPerSecond++;
			}
		}
	}
}
