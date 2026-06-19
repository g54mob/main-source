using System;
using UnityEngine;
using UnityHFSM;

public class AggressionState : StateBase
{
	private readonly AirplaneWaypointMover mover;

	private readonly AirplaneBombDropper bombDropper;

	private readonly AirToGroundMissileLauncher missileLauncher;

	private readonly AttackMode attackMode;

	private readonly Transform self;

	private readonly Transform player;

	private readonly Rigidbody selfRb;

	public float maxAttackAltitude = 200f;

	public float minAttackAltitude = 80f;

	public float waypointSmoothSpeed = 15f;

	private Vector3 dropWaypoint;

	private bool dropWaypointReady;

	private Vector3 committedTargetXZ;

	private bool committed;

	private float recalcTimer;

	private const float RecalcInterval = 0.15f;

	private bool salvoFiredThisState;

	public Vector3 DropWaypoint => dropWaypoint;

	public bool DropWaypointReady => dropWaypointReady;

	public event Action OnSalvoFired;

	public AggressionState(AirplaneWaypointMover mover, AirplaneBombDropper bombDropper, AirToGroundMissileLauncher missileLauncher, AttackMode attackMode, Transform self, Transform player, Rigidbody selfRb)
		: base(needsExitTime: false)
	{
		this.mover = mover;
		this.bombDropper = bombDropper;
		this.missileLauncher = missileLauncher;
		this.attackMode = attackMode;
		this.self = self;
		this.player = player;
		this.selfRb = selfRb;
	}

	public override void OnEnter()
	{
		dropWaypointReady = false;
		recalcTimer = 0f;
		salvoFiredThisState = false;
		committed = false;
		mover.ResetPIDs();
		Debug.Log($"[AirplaneAI] -> Aggression  mode={attackMode}");
	}

	public override void OnLogic()
	{
		if (!(player == null))
		{
			recalcTimer -= Time.deltaTime;
			if (recalcTimer <= 0f)
			{
				UpdateDropWaypoint();
				recalcTimer = 0.15f;
			}
			if (dropWaypointReady)
			{
				mover.OverrideTarget = dropWaypoint;
			}
			bool flag = false;
			switch (attackMode)
			{
			case AttackMode.BombDropper:
				flag = bombDropper != null && bombDropper.TryDropAndReport(dropWaypoint, dropWaypointReady);
				break;
			case AttackMode.AirToGroundMissile:
				flag = missileLauncher != null && missileLauncher.TryFireAndReport(dropWaypoint, dropWaypointReady);
				break;
			}
			if (flag && !salvoFiredThisState)
			{
				salvoFiredThisState = true;
				this.OnSalvoFired?.Invoke();
			}
		}
	}

	public override void OnExit()
	{
		mover.OverrideTarget = null;
		bombDropper?.ResetTimer();
		missileLauncher?.ResetTimer();
		committed = false;
		Debug.Log("[AirplaneAI] -> Patrol");
	}

	private void UpdateDropWaypoint()
	{
		Vector3 b = CalculateIdealAttackXZ();
		if (!committed)
		{
			committedTargetXZ = b;
			committed = true;
		}
		else
		{
			committedTargetXZ = Vector3.Lerp(committedTargetXZ, b, waypointSmoothSpeed * 0.15f);
		}
		float y = self.position.y;
		float y2 = player.position.y;
		y = Mathf.Clamp(y, y2 + minAttackAltitude, y2 + maxAttackAltitude);
		dropWaypoint = new Vector3(committedTargetXZ.x, y, committedTargetXZ.z);
		dropWaypointReady = true;
		Debug.Log($"[Aggression] dropWP={dropWaypoint}  alt={y - y2:F0}m над гравцем");
	}

	private Vector3 CalculateIdealAttackXZ()
	{
		return attackMode switch
		{
			AttackMode.BombDropper => CalcBombXZ(), 
			AttackMode.AirToGroundMissile => CalcMissileXZ(), 
			_ => player.position, 
		};
	}

	private Vector3 CalcBombXZ()
	{
		if (bombDropper == null)
		{
			return player.position;
		}
		Vector3 dropOrigin = bombDropper.DropOrigin;
		Vector3 linearVelocity = selfRb.linearVelocity;
		Vector3 vector = SimulateLanding(dropOrigin, linearVelocity, player.position.y);
		Vector3 vector2 = player.position - vector;
		vector2.y = 0f;
		Vector3 vector3 = dropOrigin - self.position;
		Vector3 result = dropOrigin + vector2 - vector3;
		result.y = self.position.y;
		return result;
	}

	private Vector3 CalcMissileXZ()
	{
		Vector3 vector = ((missileLauncher != null) ? missileLauncher.LaunchOrigin : self.position) - self.position;
		Vector3 result = player.position - vector;
		result.y = self.position.y;
		return result;
	}

	private Vector3 SimulateLanding(Vector3 startPos, Vector3 startVel, float targetY)
	{
		Vector3 vector = startPos;
		Vector3 vector2 = startVel;
		float num = 0.05f;
		for (int i = 0; i < 600; i++)
		{
			vector2 += Physics.gravity * num;
			Vector3 vector3 = vector + vector2 * num;
			if (vector3.y <= targetY)
			{
				float t = Mathf.InverseLerp(vector.y, vector3.y, targetY);
				return Vector3.Lerp(vector, vector3, t);
			}
			vector = vector3;
		}
		return vector;
	}
}
