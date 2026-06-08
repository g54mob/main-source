using System;
using Duskers.DroneStates;
using UnityEngine;

public class DroneBrain
{
	private const float PILOT_SPEEDUP_FACTOR = 1.5f;

	private const float PILOT_SLOWDOWN_FACTOR = 5f;

	private StateMachine _stateMachine;

	private SteeringBehaviors _steeringBehaviors;

	private Vector3 _forwardOverrideForce = Vector3.zero;

	private bool _playSound;

	private float _proximity;

	private float _startAngleRads;

	private float _desiredAngleRads;

	private float _rotateStep;

	private float _rotateSpeed;

	public string CurrentState
	{
		get
		{
			return _stateMachine.CurrentState;
		}
	}

	public SteeringBehaviors SteeringBehaviors
	{
		get
		{
			return _steeringBehaviors;
		}
	}

	public StateIdle StateIdle { get; private set; }

	public StateWaitingForDoorToOpen StateWaitingForDoorToOpen { get; private set; }

	public StateNavigatingPath StateNavigatingPath { get; private set; }

	public StateMoveToAndExecuteCommand StateMoveToAndExecuteCommand { get; private set; }

	public Drone ThisDrone { get; private set; }

	public bool WarnedAboutDoors { get; set; }

	public bool IsRotating { get; private set; }

	public bool PlayingSound
	{
		get
		{
			return _playSound;
		}
	}

	public GameObject Target
	{
		get
		{
			return _steeringBehaviors.Target;
		}
	}

	public float Proximity
	{
		get
		{
			return _proximity;
		}
	}

	public DroneBrain(Drone drone)
	{
		ThisDrone = drone;
		_steeringBehaviors = new SteeringBehaviors(drone);
		_stateMachine = new StateMachine();
		StateIdle = new StateIdle(this);
		StateWaitingForDoorToOpen = new StateWaitingForDoorToOpen(this);
		StateNavigatingPath = new StateNavigatingPath(this);
		StateMoveToAndExecuteCommand = new StateMoveToAndExecuteCommand(this);
	}

	public void Initialize()
	{
		_steeringBehaviors.AllOff();
		_stateMachine.ChangeState(StateIdle);
	}

	public void SetProximity(float proximity)
	{
		_proximity = proximity;
	}

	public void NavigateToRoom(Room room)
	{
		StopNavigating();
		Waypoint mainRoomWaypoint = NavigationHelper.GetMainRoomWaypoint(room);
		StateNavigatingPath.Initialize(mainRoomWaypoint);
		_stateMachine.ChangeState(StateNavigatingPath);
	}

	public void NavigateToObjectAndExecuteCommand(GameObject gameObject, ExecutedCommand commandToExecute, CollisionType collisionType)
	{
		StopNavigating();
		StateMoveToAndExecuteCommand.Initialize(gameObject, commandToExecute, collisionType);
		_stateMachine.ChangeState(StateMoveToAndExecuteCommand);
	}

	public void StopNavigating()
	{
		WarnedAboutDoors = false;
		_stateMachine.ChangeState(StateIdle);
	}

	public void SetAiIdle()
	{
		if (CurrentState != "Idle")
		{
			float currentRawSpeed = ThisDrone.CurrentRawSpeed;
			_stateMachine.ChangeState(StateIdle);
			ThisDrone.CurrentRawSpeed = currentRawSpeed;
			SteeringBehaviors.SeekOff();
			SteeringBehaviors.ArriveOff();
			SteeringBehaviors.ObstacleAvoidanceOff();
			SteeringBehaviors.LazyAvoidanceOff();
			SteeringBehaviors.WallAvoidanceOff();
		}
	}

	public void MoveForwardFull()
	{
		_steeringBehaviors.ClearTarget();
		_forwardOverrideForce = ThisDrone.GetVelocityVectorRawNoDelta(ThisDrone.CurrentMaxRawSpeed * 1.5f);
		if (!ThisDrone.IsUnderPlayerControl)
		{
			return;
		}
		Vector3 right = ThisDrone.transform.right;
		float num = 0f;
		if (ThisDrone.TraitVeer != 0f && ThisDrone.CurrentRawSpeed >= ThisDrone.CurrentMaxRawSpeed * 0.99f)
		{
			num = (ThisDrone.TotalHitpoints - ThisDrone.CurrentHitPoints) / ThisDrone.TotalHitpoints * ThisDrone.TraitVeer;
			if (ThisDrone.TraitPermVeer != 0f && Mathf.Abs(num) < Mathf.Abs(ThisDrone.TraitPermVeer))
			{
				num = ThisDrone.TraitPermVeer;
			}
		}
		if (num != 0f)
		{
			right *= num;
			_forwardOverrideForce += right;
		}
	}

	public void Update()
	{
		_stateMachine.Update();
		bool flag = ThisDrone.CurrentRawSpeed > 0.001f;
		bool playSound = _playSound;
		_playSound = true;
		bool isBraking = false;
		Vector3 vector = _steeringBehaviors.Calculate(_forwardOverrideForce);
		if (vector == Vector3.zero && flag)
		{
			vector = -ThisDrone.GetVelocityVectorRawNoDelta(ThisDrone.CurrentRawSpeed) * 5f;
			_playSound = false;
			isBraking = true;
		}
		if (vector != Vector3.zero)
		{
			ThisDrone.ApplyForce(vector, _playSound, isBraking);
			if (ThisDrone.ItemBeingTowed != null && GlobalSettings.cameraMode == CameraMode.Drone && !ThisDrone.towMoveSound.isPlaying && !ThisDrone.IsBraking)
			{
				ThisDrone.towMoveSound.Play();
				ThisDrone.towMoveSound.volume = GameAudio.RemoteVolume * 1f;
			}
		}
		else if (ThisDrone.IsBraking)
		{
			ThisDrone.ClearBraking();
		}
		if (_forwardOverrideForce != Vector3.zero)
		{
			_forwardOverrideForce = Vector3.zero;
			_steeringBehaviors.ObstacleAvoidanceOff();
			_steeringBehaviors.LazyAvoidanceOff();
			_steeringBehaviors.WallAvoidanceOff();
		}
		if (!_playSound && playSound)
		{
			ThisDrone.PostMovement();
		}
	}

	public bool ReachedTargetPosition(Vector3 targetPos)
	{
		float num = Vector3.Distance(ThisDrone.transform.position, targetPos);
		if (num <= 0.75f)
		{
			return true;
		}
		int count = ThisDrone.CollidingObjects.Count;
		for (int i = 0; i < count; i++)
		{
			GameObject gameObject = ThisDrone.CollidingObjects[i];
			num = Vector3.Distance(gameObject.transform.position, targetPos);
			float num2 = Vector3.Distance(gameObject.transform.position, ThisDrone.transform.position);
			if (num <= 0.75f && num2 <= 1.5f)
			{
				return true;
			}
		}
		return false;
	}

	public void InitializeRotation(Vector3 targetPos)
	{
		_startAngleRads = (float)Math.PI / 180f * ThisDrone.transform.rotation.eulerAngles.z;
		Vector3 vector = targetPos - ThisDrone.transform.position;
		Quaternion quaternion = Quaternion.LookRotation(vector, Vector3.back);
		quaternion.x = 0f;
		quaternion.y = 0f;
		_desiredAngleRads = (float)Math.PI / 180f * quaternion.eulerAngles.z;
		float num = Vector3.Angle(ThisDrone.transform.up, vector);
		if (num > 0f)
		{
			_rotateSpeed = 180f / num;
		}
		else
		{
			_rotateSpeed = 0f;
		}
		_rotateStep = 0f;
		if (_rotateSpeed != 0f)
		{
			IsRotating = true;
		}
	}

	public bool RotateWhileNotLookingAtTarget()
	{
		if (ThisDrone.CurrentRawSpeed < 0.001f && IsRotating && _rotateStep < 1f)
		{
			_rotateStep += Time.deltaTime * _rotateSpeed;
			_rotateStep = Mathf.Min(_rotateStep, 1f);
			float num = CommonMethods.CurveAngle(_startAngleRads, _desiredAngleRads, _rotateStep);
			ThisDrone.PreRotation();
			ThisDrone.transform.rotation = Quaternion.AngleAxis(num * 57.29578f, new Vector3(0f, 0f, 1f));
			ThisDrone.PostRotation();
			ThisDrone.PostMoveStep();
			return true;
		}
		IsRotating = false;
		return false;
	}

	public void ClearRotating()
	{
		IsRotating = false;
	}
}
