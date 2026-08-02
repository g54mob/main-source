using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Mirror;
using UnityEngine;

public class AdvancedSurroundSystem : NetworkBehaviour
{
	[Serializable]
	public class AttackSlot
	{
		public Vector3 localPosition;

		public float angle;

		public ZombieController occupant;

		public int ringIndex;

		public int slotIndex;

		public bool IsAvailable => occupant == null;

		public AttackSlot(Vector3 pos, float ang, int ring, int slot)
		{
			localPosition = pos;
			angle = ang;
			ringIndex = ring;
			slotIndex = slot;
			occupant = null;
		}
	}

	[Serializable]
	public class PatrolInfo
	{
		public float currentAngle;

		public float targetAngle;

		public float lastChangeTime;

		public bool movingClockwise;

		public float baseRadius;

		public int queueIndex;

		public PatrolInfo(float startAngle, float radius)
		{
			currentAngle = startAngle;
			targetAngle = startAngle + UnityEngine.Random.Range(-30f, 30f);
			lastChangeTime = Time.time;
			movingClockwise = UnityEngine.Random.value > 0.5f;
			baseRadius = radius;
			queueIndex = -1;
		}
	}

	[Header("Ring Configuration")]
	public int innerRingSlots = 6;

	public float innerRingRadius = 2f;

	public int outerRingSlots = 12;

	public float outerRingRadius = 4f;

	[Header("Attack Settings")]
	public float attackRange = 2.5f;

	public bool onlyInnerRingCanAttack = true;

	[Header("Promotion Settings")]
	public bool autoPromote = true;

	public float promotionDelay = 0.5f;

	[Header("Movement Settings")]
	public float slotReachDistance = 0.5f;

	[Header("Outer Ring Patrol")]
	public bool outerRingPatrol = true;

	public float patrolSpeed = 2f;

	public float patrolChangeInterval = 3f;

	public float patrolAngleRange = 60f;

	[Header("Queue Patrol")]
	public bool queuePatrol = true;

	public float queuePatrolRadius = 1f;

	public float queuePatrolSpeed = 1.5f;

	[Header("Rotation Settings")]
	public bool ignorePlayerRotation = true;

	[Header("Debug")]
	public bool showDebugGizmos = true;

	public bool showAttackRange = true;

	private List<AttackSlot> innerRing = new List<AttackSlot>();

	private List<AttackSlot> outerRing = new List<AttackSlot>();

	private Dictionary<ZombieController, AttackSlot> zombieSlotMap = new Dictionary<ZombieController, AttackSlot>();

	private List<ZombieController> waitingQueue = new List<ZombieController>();

	private Dictionary<ZombieController, PatrolInfo> patrolInfoMap = new Dictionary<ZombieController, PatrolInfo>();

	private static Dictionary<Transform, AdvancedSurroundSystem> allSystems = new Dictionary<Transform, AdvancedSurroundSystem>();

	private float lastInnerRadius = -1f;

	private float lastOuterRadius = -1f;

	private int lastInnerSlots = -1;

	private int lastOuterSlots = -1;

	private void Awake()
	{
		GenerateRings();
	}

	private new void OnValidate()
	{
		if (Application.isPlaying)
		{
			if (lastInnerRadius != innerRingRadius || lastOuterRadius != outerRingRadius || lastInnerSlots != innerRingSlots || lastOuterSlots != outerRingSlots)
			{
				GenerateRings();
				RedistributeZombies();
			}
		}
		else
		{
			GenerateRings();
		}
	}

	private void OnEnable()
	{
		if (!allSystems.ContainsKey(base.transform))
		{
			allSystems.Add(base.transform, this);
		}
	}

	private void OnDisable()
	{
		ReleaseAllSlots();
		allSystems.Remove(base.transform);
	}

	private void GenerateRings()
	{
		GenerateRing(innerRing, innerRingSlots, innerRingRadius, 0);
		GenerateRing(outerRing, outerRingSlots, outerRingRadius, 1);
		lastInnerRadius = innerRingRadius;
		lastOuterRadius = outerRingRadius;
		lastInnerSlots = innerRingSlots;
		lastOuterSlots = outerRingSlots;
	}

	private void GenerateRing(List<AttackSlot> ring, int slotCount, float radius, int ringIndex)
	{
		ring.Clear();
		float num = 360f / (float)slotCount;
		for (int i = 0; i < slotCount; i++)
		{
			float num2 = (float)i * num;
			float f = num2 * (MathF.PI / 180f);
			Vector3 pos = new Vector3(Mathf.Sin(f) * radius, 0f, Mathf.Cos(f) * radius);
			ring.Add(new AttackSlot(pos, num2, ringIndex, i));
		}
	}

	private void RedistributeZombies()
	{
		List<ZombieController> list = zombieSlotMap.Keys.ToList();
		zombieSlotMap.Clear();
		foreach (ZombieController item in list)
		{
			if (item != null && !item.isDeath)
			{
				RequestSlot(item);
			}
		}
	}

	public ZombiePositionInfo GetPositionInfo(ZombieController zombie)
	{
		ZombiePositionInfo info = new ZombiePositionInfo();
		if (zombieSlotMap.TryGetValue(zombie, out var value))
		{
			if (value.ringIndex == 1 && outerRingPatrol)
			{
				UpdatePatrolPosition(zombie, value, ref info);
			}
			else if (value.ringIndex == 0)
			{
				Vector3 b = (info.targetPosition = GetWorldPosition(value));
				info.canAttack = true;
				info.shouldMove = Vector3.Distance(zombie.transform.position, b) > slotReachDistance;
				info.isInPosition = !info.shouldMove;
				info.attackPosition = base.transform.position;
			}
			else
			{
				Vector3 worldPosition = GetWorldPosition(value);
				info.targetPosition = worldPosition;
				info.canAttack = false;
				info.shouldMove = true;
				info.isInPosition = false;
			}
			return info;
		}
		if (waitingQueue.Contains(zombie))
		{
			UpdateQueuePatrol(zombie, ref info);
			return info;
		}
		RequestSlot(zombie);
		if (zombieSlotMap.ContainsKey(zombie))
		{
			return GetPositionInfo(zombie);
		}
		UpdateQueuePatrol(zombie, ref info);
		return info;
	}

	private void UpdatePatrolPosition(ZombieController zombie, AttackSlot slot, ref ZombiePositionInfo info)
	{
		if (!patrolInfoMap.ContainsKey(zombie))
		{
			float angle = slot.angle;
			patrolInfoMap[zombie] = new PatrolInfo(angle, outerRingRadius);
		}
		PatrolInfo patrolInfo = patrolInfoMap[zombie];
		if (Time.time - patrolInfo.lastChangeTime > patrolChangeInterval)
		{
			float num = UnityEngine.Random.Range(20f, patrolAngleRange);
			patrolInfo.targetAngle = patrolInfo.currentAngle + (patrolInfo.movingClockwise ? num : (0f - num));
			patrolInfo.lastChangeTime = Time.time;
			if (UnityEngine.Random.value < 0.3f)
			{
				patrolInfo.movingClockwise = !patrolInfo.movingClockwise;
			}
		}
		float num2 = Mathf.DeltaAngle(patrolInfo.currentAngle, patrolInfo.targetAngle);
		patrolInfo.currentAngle += num2 * Time.deltaTime * patrolSpeed;
		float f = patrolInfo.currentAngle * (MathF.PI / 180f);
		float num3 = Mathf.Sin(Time.time * patrolSpeed) * 0.2f;
		float num4 = outerRingRadius + num3;
		Vector3 vector = new Vector3(Mathf.Sin(f) * num4, 0f, Mathf.Cos(f) * num4);
		info.targetPosition = base.transform.position + vector;
		info.canAttack = false;
		info.shouldMove = true;
		info.isInPosition = false;
	}

	private void UpdateQueuePatrol(ZombieController zombie, ref ZombiePositionInfo info)
	{
		if (!waitingQueue.Contains(zombie))
		{
			waitingQueue.Add(zombie);
		}
		int num = waitingQueue.IndexOf(zombie);
		if (!patrolInfoMap.ContainsKey(zombie))
		{
			float startAngle = Mathf.Atan2(zombie.transform.position.z - base.transform.position.z, zombie.transform.position.x - base.transform.position.x) * 57.29578f;
			patrolInfoMap[zombie] = new PatrolInfo(startAngle, outerRingRadius + 2f + (float)num * 1.5f);
			patrolInfoMap[zombie].queueIndex = num;
		}
		PatrolInfo patrolInfo = patrolInfoMap[zombie];
		patrolInfo.baseRadius = outerRingRadius + 2f + (float)num * 1.5f;
		if (queuePatrol)
		{
			if (Time.time - patrolInfo.lastChangeTime > patrolChangeInterval * 1.5f)
			{
				float num2 = UnityEngine.Random.Range(15f, 45f);
				patrolInfo.targetAngle = patrolInfo.currentAngle + (patrolInfo.movingClockwise ? num2 : (0f - num2));
				patrolInfo.lastChangeTime = Time.time;
				if (UnityEngine.Random.value < 0.4f)
				{
					patrolInfo.movingClockwise = !patrolInfo.movingClockwise;
				}
			}
			float num3 = Mathf.DeltaAngle(patrolInfo.currentAngle, patrolInfo.targetAngle);
			patrolInfo.currentAngle += num3 * Time.deltaTime * queuePatrolSpeed;
			float num4 = Mathf.Sin(Time.time * queuePatrolSpeed + (float)num) * queuePatrolRadius;
			float num5 = patrolInfo.baseRadius + num4;
			float f = patrolInfo.currentAngle * (MathF.PI / 180f);
			info.targetPosition = base.transform.position + new Vector3(Mathf.Sin(f) * num5, 0f, Mathf.Cos(f) * num5);
		}
		else
		{
			float f2 = patrolInfo.currentAngle * (MathF.PI / 180f);
			info.targetPosition = base.transform.position + new Vector3(Mathf.Sin(f2) * patrolInfo.baseRadius, 0f, Mathf.Cos(f2) * patrolInfo.baseRadius);
		}
		info.canAttack = false;
		info.shouldMove = true;
		info.isInPosition = false;
	}

	private Vector3 GetWorldPosition(AttackSlot slot)
	{
		if (ignorePlayerRotation)
		{
			float f = slot.angle * (MathF.PI / 180f);
			float num = ((slot.ringIndex == 0) ? innerRingRadius : outerRingRadius);
			return base.transform.position + new Vector3(Mathf.Sin(f) * num, 0f, Mathf.Cos(f) * num);
		}
		return base.transform.TransformPoint(slot.localPosition);
	}

	public void RequestSlot(ZombieController zombie)
	{
		if (!zombieSlotMap.ContainsKey(zombie))
		{
			AttackSlot attackSlot = FindAvailableSlot(zombie);
			if (attackSlot != null)
			{
				AssignSlot(zombie, attackSlot);
			}
			else if (!waitingQueue.Contains(zombie))
			{
				waitingQueue.Add(zombie);
			}
		}
	}

	private AttackSlot FindAvailableSlot(ZombieController zombie)
	{
		foreach (AttackSlot item in innerRing)
		{
			if (item.IsAvailable)
			{
				return item;
			}
		}
		foreach (AttackSlot item2 in outerRing)
		{
			if (item2.IsAvailable)
			{
				return item2;
			}
		}
		return null;
	}

	private void AssignSlot(ZombieController zombie, AttackSlot slot)
	{
		ReleaseSlot(zombie);
		slot.occupant = zombie;
		zombieSlotMap[zombie] = slot;
		waitingQueue.Remove(zombie);
		if (patrolInfoMap.ContainsKey(zombie) && slot.ringIndex != 1)
		{
			patrolInfoMap.Remove(zombie);
		}
	}

	public void ReleaseSlot(ZombieController zombie)
	{
		if (zombieSlotMap.TryGetValue(zombie, out var value))
		{
			value.occupant = null;
			zombieSlotMap.Remove(zombie);
			if (autoPromote && value.ringIndex == 0)
			{
				StartCoroutine(PromoteFromOuterRing(value));
			}
		}
		if (patrolInfoMap.ContainsKey(zombie))
		{
			patrolInfoMap.Remove(zombie);
		}
	}

	private IEnumerator PromoteFromOuterRing(AttackSlot emptySlot)
	{
		yield return new WaitForSeconds(promotionDelay);
		AttackSlot attackSlot = FindNearestOccupiedSlotInOuterRing(emptySlot);
		if (attackSlot != null && attackSlot.occupant != null)
		{
			ZombieController occupant = attackSlot.occupant;
			attackSlot.occupant = null;
			emptySlot.occupant = occupant;
			zombieSlotMap[occupant] = emptySlot;
			if (patrolInfoMap.ContainsKey(occupant))
			{
				patrolInfoMap.Remove(occupant);
			}
		}
		ProcessWaitingQueue();
	}

	private AttackSlot FindNearestOccupiedSlotInOuterRing(AttackSlot targetSlot)
	{
		AttackSlot result = null;
		float num = float.MaxValue;
		foreach (AttackSlot item in outerRing)
		{
			if (item.occupant != null)
			{
				float num2 = Mathf.Abs(Mathf.DeltaAngle(item.angle, targetSlot.angle));
				if (num2 < num)
				{
					num = num2;
					result = item;
				}
			}
		}
		return result;
	}

	private void ProcessWaitingQueue()
	{
		if (waitingQueue.Count == 0)
		{
			return;
		}
		List<AttackSlot> list = new List<AttackSlot>();
		list.AddRange(innerRing.Where((AttackSlot s) => s.IsAvailable));
		list.AddRange(outerRing.Where((AttackSlot s) => s.IsAvailable));
		if (list.Count == 0)
		{
			return;
		}
		List<(ZombieController, AttackSlot, float)> list2 = new List<(ZombieController, AttackSlot, float)>();
		for (int num = 0; num < waitingQueue.Count && num < list.Count; num++)
		{
			ZombieController zombieController = waitingQueue[num];
			if (zombieController == null || zombieController.isDeath)
			{
				continue;
			}
			AttackSlot attackSlot = null;
			float num2 = float.MaxValue;
			foreach (AttackSlot slot in list)
			{
				if (!list2.Any<(ZombieController, AttackSlot, float)>(((ZombieController zombie, AttackSlot slot, float distance) a) => a.slot == slot))
				{
					Vector3 worldPosition = GetWorldPosition(slot);
					float num3 = Vector3.Distance(zombieController.transform.position, worldPosition);
					if (num3 < num2)
					{
						num2 = num3;
						attackSlot = slot;
					}
				}
			}
			if (attackSlot != null)
			{
				list2.Add((zombieController, attackSlot, num2));
			}
		}
		foreach (var (zombieController2, slot2, _) in list2.OrderBy<(ZombieController, AttackSlot, float), float>(((ZombieController zombie, AttackSlot slot, float distance) a) => a.distance))
		{
			waitingQueue.Remove(zombieController2);
			AssignSlot(zombieController2, slot2);
		}
		waitingQueue.RemoveAll((ZombieController z) => z == null || z.isDeath);
	}

	public void ForceRedistribute()
	{
		List<ZombieController> list = new List<ZombieController>();
		list.AddRange(zombieSlotMap.Keys);
		list.AddRange(waitingQueue);
		zombieSlotMap.Clear();
		waitingQueue.Clear();
		patrolInfoMap.Clear();
		foreach (AttackSlot item in innerRing)
		{
			item.occupant = null;
		}
		foreach (AttackSlot item2 in outerRing)
		{
			item2.occupant = null;
		}
		foreach (ZombieController item3 in (from z in list
			where z != null && !z.isDeath
			orderby Vector3.Distance(z.transform.position, base.transform.position)
			select z).ToList())
		{
			RequestSlot(item3);
		}
	}

	private void Update()
	{
		CleanupDeadZombies();
		if (Time.frameCount % 30 == 0)
		{
			ProcessWaitingQueue();
		}
		if (Time.frameCount % 300 == 0)
		{
			CheckForStuckZombies();
		}
	}

	private void CheckForStuckZombies()
	{
		int num = innerRing.Count((AttackSlot s) => s.IsAvailable);
		int num2 = outerRing.Count((AttackSlot s) => s.IsAvailable);
		if ((num > 0 || num2 > 0) && waitingQueue.Count > 0)
		{
			Debug.Log($"Stuck zombies detected! Empty slots: Inner={num}, Outer={num2}, Queue={waitingQueue.Count}");
			ForceRedistribute();
		}
	}

	private void LateUpdate()
	{
		if (ignorePlayerRotation)
		{
			base.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
		}
	}

	private void CleanupDeadZombies()
	{
		foreach (ZombieController item in zombieSlotMap.Keys.Where((ZombieController z) => z == null || z.isDeath).ToList())
		{
			ReleaseSlot(item);
		}
		waitingQueue.RemoveAll((ZombieController z) => z == null || z.isDeath);
	}

	private void ReleaseAllSlots()
	{
		foreach (KeyValuePair<ZombieController, AttackSlot> item in zombieSlotMap)
		{
			if (item.Value != null)
			{
				item.Value.occupant = null;
			}
		}
		zombieSlotMap.Clear();
		patrolInfoMap.Clear();
		waitingQueue.Clear();
	}

	public static AdvancedSurroundSystem GetSystem(Transform target)
	{
		allSystems.TryGetValue(target, out var value);
		return value;
	}

	private void OnDrawGizmos()
	{
		if (showDebugGizmos)
		{
			if (innerRing.Count == 0 || lastInnerRadius != innerRingRadius || lastOuterRadius != outerRingRadius || lastInnerSlots != innerRingSlots || lastOuterSlots != outerRingSlots)
			{
				GenerateRings();
			}
			Gizmos.color = new Color(1f, 0f, 0f, 0.3f);
			DrawCircle(base.transform.position, innerRingRadius, 30);
			Gizmos.color = new Color(0f, 1f, 0f, 0.3f);
			DrawCircle(base.transform.position, outerRingRadius, 40);
			DrawSlots(innerRing, Color.red, 0.15f);
			DrawSlots(outerRing, Color.green, 0.12f);
			if (showAttackRange)
			{
				Gizmos.color = new Color(1f, 0.5f, 0f, 0.1f);
				DrawCircle(base.transform.position, attackRange, 20);
			}
			DrawQueuedZombies();
		}
	}

	private void DrawCircle(Vector3 center, float radius, int segments)
	{
		Vector3 vector = center + new Vector3(radius, 0f, 0f);
		for (int i = 1; i <= segments; i++)
		{
			float f = (float)i / (float)segments * 2f * MathF.PI;
			Vector3 vector2 = center + new Vector3(Mathf.Cos(f) * radius, 0f, Mathf.Sin(f) * radius);
			Gizmos.DrawLine(vector, vector2);
			vector = vector2;
		}
	}

	private void DrawSlots(List<AttackSlot> ring, Color color, float size)
	{
		foreach (AttackSlot item in ring)
		{
			Vector3 worldPosition = GetWorldPosition(item);
			if (item.occupant != null)
			{
				Gizmos.color = Color.red;
				Gizmos.DrawSphere(worldPosition, size * 1.5f);
				Gizmos.color = new Color(1f, 1f, 1f, 0.5f);
				Gizmos.DrawLine(worldPosition, item.occupant.transform.position);
			}
			else
			{
				Gizmos.color = color;
				Gizmos.DrawSphere(worldPosition, size);
			}
		}
	}

	private void DrawQueuedZombies()
	{
		int num = 0;
		foreach (ZombieController item in waitingQueue)
		{
			if (item != null)
			{
				Gizmos.color = Color.cyan;
				if (patrolInfoMap.ContainsKey(item))
				{
					PatrolInfo patrolInfo = patrolInfoMap[item];
					float f = patrolInfo.currentAngle * (MathF.PI / 180f);
					Gizmos.DrawSphere(base.transform.position + new Vector3(Mathf.Sin(f) * patrolInfo.baseRadius, 0f, Mathf.Cos(f) * patrolInfo.baseRadius), 0.1f);
				}
				else
				{
					float f2 = Mathf.Atan2(item.transform.position.z - base.transform.position.z, item.transform.position.x - base.transform.position.x);
					float num2 = outerRingRadius + 2f + (float)num * 1.5f;
					Gizmos.DrawSphere(base.transform.position + new Vector3(Mathf.Cos(f2) * num2, 0f, Mathf.Sin(f2) * num2), 0.08f);
				}
				num++;
			}
		}
	}

	public override bool Weaved()
	{
		return true;
	}
}
