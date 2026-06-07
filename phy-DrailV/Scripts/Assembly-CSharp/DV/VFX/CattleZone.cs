using System;
using System.Collections;
using System.Collections.Generic;
using DV.TerrainSystem;
using DV.Utils;
using DV.WeatherSystem;
using DV.WorldTools;
using UnityEngine;

namespace DV.VFX
{
	[RequireComponent(typeof(BoxCollider))]
	public class CattleZone : MonoBehaviour
	{
		public enum HeightCorrectionMode
		{
			None = 0,
			Raycast = 1,
			Heightmap = 2
		}

		[Serializable]
		public class PrefabEntry
		{
			public GameObject prefab;

			public float distributionWeight = 1f;

			public float movementSpeed = 1f;

			public float animationSpeedScale = 1f;

			public float radius = 1f;

			public float actionDuration = 2f;

			public float endTransition = 0.5f;

			public float maxTilt = 20f;

			public Vector3 soundPosition = Vector3.up;

			public AudioClip[] actionSounds;

			public AudioClip[] idleSounds;
		}

		private struct AgentState
		{
			public float actionBlock;

			public float actionCooldown;

			public float initialActionCooldown;

			public int lastDirectionIndex;

			public GameObject gameObject;

			public Animator animator;

			public PrefabEntry definition;

			public Vector3 currentPosition;

			public float currentAngle;

			public Vector2Int currentCell;

			public Vector2 cellOffset;

			public Vector3 nextPosition;

			public float nextAngle;

			public Vector2Int nextCell;

			public Vector2 nextCellOffset;

			public bool moving;

			public float movementPhase;

			public float movementMultiplier;
		}

		[Header("Distribution")]
		public float cellSize = 5f;

		public HeightCorrectionMode initialHeight = HeightCorrectionMode.Raycast;

		[Header("Agents")]
		[Range(0f, 1f)]
		public float areaCoverPercentage = 0.2f;

		public PrefabEntry[] agentPrefabs;

		[Header("Movement")]
		public Vector2 averageMovementInterval = new Vector2(5f, 10f);

		public AnimationCurve movementCurve = AnimationCurve.Linear(0f, 0f, 1f, 1f);

		[Header("Action")]
		public Vector2 actionCooldown = new Vector2(5f, 10f);

		public Vector2 postMovementCooldown = new Vector2(2f, 5f);

		public Vector2 idleSoundCooldown = new Vector2(5f, 10f);

		[Header("LODs")]
		public float fineCorrectionDistance = 100f;

		public float movementUpdateDistance = 250f;

		public float hideDistance = 500f;

		private const float MAX_CELL_OFFSET = 0.44710678f;

		private const float LOOK_AHEAD_FACTOR = 0.05f;

		private const float PITCH_VARIATION_RANGE = 0.1f;

		private BoxCollider areaCollider;

		private bool initialized;

		private float sphereRadius;

		private Vector3 rightVector;

		private Vector3 forwardVector;

		private Vector3[,] cellPositions;

		private float[,] verticalCorrection;

		private int[,] cellAgents;

		private AgentState[] agents;

		private HashSet<Collider> agentColliders = new HashSet<Collider>();

		private static RaycastHit[] raycastResultsCache = new RaycastHit[16];

		private int layerMask;

		private int agentRobin;

		private float timeToNextMove = 1f;

		private float initialTimeToNextMove = 1f;

		private bool lastAnimatorState = true;

		private bool timeJumping;

		private float timeToIdleSound;

		private float initialTimeToIdleSound;

		private bool hidden;

		private static readonly int ap_Action = Animator.StringToHash("Action");

		private static readonly int ap_Move = Animator.StringToHash("Move");

		private static readonly int ap_Speed = Animator.StringToHash("Speed");

		private static readonly int as_Idle = Animator.StringToHash("Base Layer.Idle");

		private Vector2Int[] directions = new Vector2Int[8]
		{
			new Vector2Int(-1, -1),
			new Vector2Int(0, -1),
			new Vector2Int(1, -1),
			new Vector2Int(1, 0),
			new Vector2Int(1, 1),
			new Vector2Int(0, 1),
			new Vector2Int(-1, 1),
			new Vector2Int(-1, 0)
		};

		private float[] directionAngle = new float[8] { 135f, 90f, 45f, 0f, 315f, 270f, 225f, 180f };

		private float lastManagedTime;

		private bool timeJumpRegistered;

		private Vector3 lastWorldPosition = Vector3.zero;

		private int CellsX => cellPositions?.GetLength(0) ?? 0;

		private int CellsZ => cellPositions?.GetLength(1) ?? 0;

		private int CellCount => CellsX * CellsZ;

		private float BaselineDayLength => Globals.G.GameParams.DayLengthInMinutes;

		private bool ShouldPlaySounds
		{
			get
			{
				if ((bool)SingletonBehaviour<WeatherDriver>.Instance)
				{
					if ((float)SingletonBehaviour<WeatherDriver>.Instance.RainValue > 0.25f)
					{
						return false;
					}
					float num = Mathf.Repeat(SingletonBehaviour<WeatherDriver>.Instance.ManagedDateTime, 1f);
					if (num < 5f / 24f || num > 0.875f)
					{
						return false;
					}
					return true;
				}
				return true;
			}
		}

		private IEnumerator Start()
		{
			layerMask = LayerMask.GetMask("Terrain", "Default");
			if (initialHeight == HeightCorrectionMode.Raycast && !CheckIfTerrainIsLoaded())
			{
				while (!CheckIfTerrainIsLoaded())
				{
					yield return null;
				}
				yield return null;
			}
			Reinitialize();
			if ((bool)SingletonBehaviour<WeatherDriver>.Instance && !timeJumpRegistered)
			{
				timeJumpRegistered = true;
				SingletonBehaviour<WeatherDriver>.Instance.manager.TimeJump += OnTimeJump;
			}
		}

		private bool CheckIfTerrainIsLoaded()
		{
			if (FastTravelController.IsFastTravelling)
			{
				return false;
			}
			TerrainGrid instance = SingletonBehaviour<TerrainGrid>.Instance;
			if ((bool)instance)
			{
				if (areaCollider == null)
				{
					areaCollider = GetComponent<BoxCollider>();
				}
				if ((bool)areaCollider)
				{
					Bounds bounds = areaCollider.bounds;
					Vector3 center = bounds.center;
					Vector3 worldPosition = center - Vector3.right * (bounds.size.x * 0.5f) - Vector3.forward * (bounds.size.z * 0.5f);
					Vector3 worldPosition2 = center + Vector3.right * (bounds.size.x * 0.5f) - Vector3.forward * (bounds.size.z * 0.5f);
					Vector3 worldPosition3 = center - Vector3.right * (bounds.size.x * 0.5f) + Vector3.forward * (bounds.size.z * 0.5f);
					Vector3 worldPosition4 = center + Vector3.right * (bounds.size.x * 0.5f) + Vector3.forward * (bounds.size.z * 0.5f);
					if (instance.IsInLoadedCell(worldPosition) && instance.IsInLoadedCell(worldPosition2) && instance.IsInLoadedCell(worldPosition3))
					{
						return instance.IsInLoadedCell(worldPosition4);
					}
					return false;
				}
			}
			return true;
		}

		private void OnDestroy()
		{
			if ((bool)SingletonBehaviour<WeatherDriver>.Instance && timeJumpRegistered)
			{
				timeJumpRegistered = false;
				SingletonBehaviour<WeatherDriver>.Instance.manager.TimeJump -= OnTimeJump;
			}
		}

		private void OnTimeJump()
		{
			float f = (SingletonBehaviour<WeatherDriver>.Instance.ManagedDateTime - lastManagedTime) * (BaselineDayLength * 60f);
			int num = (int)Mathf.Sign(f);
			int num2 = Mathf.FloorToInt(Mathf.Abs(f) / 10f);
			float deltaTime = (Mathf.Abs(f) - (float)num2 * 10f) * (float)num;
			float timeScale = BaselineDayLength / (float)SingletonBehaviour<WeatherDriver>.Instance.manager.DayLengthInMinutes;
			timeJumping = true;
			if (num2 == 0)
			{
				UpdateAgents(deltaTime, timeScale, initialHeight);
			}
			else if (num2 <= 10)
			{
				for (int i = 0; i < num2; i++)
				{
					UpdateAgents((float)num * 10f, 1f, HeightCorrectionMode.None);
				}
				UpdateAgents(deltaTime, timeScale, initialHeight);
			}
			else
			{
				for (int j = 0; j < CellsX; j++)
				{
					for (int k = 0; k < CellsZ; k++)
					{
						cellAgents[j, k] = -1;
					}
				}
				InitializeAgents(reInstantiateAgents: false);
				agentRobin = UnityEngine.Random.Range(0, agents.Length);
				TryToMoveAgent(agentRobin, num >= 0);
				agents[agentRobin].movementPhase = UnityEngine.Random.value;
				agentRobin = (agentRobin + 1) % agents.Length;
			}
			timeJumping = false;
		}

		private void Reinitialize()
		{
			initialized = false;
			timeToNextMove = (initialTimeToNextMove = UnityEngine.Random.Range(averageMovementInterval.x, averageMovementInterval.y));
			timeToIdleSound = (initialTimeToIdleSound = UnityEngine.Random.Range(idleSoundCooldown.x, idleSoundCooldown.y));
			if (InitializeCells() && InitializeAgents(reInstantiateAgents: true))
			{
				initialized = true;
			}
		}

		private bool InitializeCells()
		{
			if (areaCollider == null)
			{
				areaCollider = GetComponent<BoxCollider>();
				if (!areaCollider)
				{
					Debug.LogError("There's no BoxCollider attached to this object! This is needed to mark the area.");
					return false;
				}
			}
			rightVector = base.transform.right;
			forwardVector = base.transform.forward;
			if (!Mathf.Approximately(Vector3.Dot(rightVector, forwardVector), 0f))
			{
				Debug.LogWarning("Axes aren't orthogonal, there's some weird skew going on, check scaling and rotation.");
			}
			_ = areaCollider.size;
			Vector3 vector = base.transform.TransformPoint(areaCollider.center - areaCollider.size * 0.5f);
			Vector3 b = vector + base.transform.TransformDirection(Vector3.right * areaCollider.size.x);
			Vector3 b2 = vector + base.transform.TransformDirection(Vector3.forward * areaCollider.size.z);
			sphereRadius = Mathf.Sqrt(areaCollider.size.x * areaCollider.size.z / (float)Math.PI);
			float num = Vector3.Distance(vector, b);
			float num2 = Vector3.Distance(vector, b2);
			if (num < cellSize)
			{
				cellSize = num;
			}
			if (num2 < cellSize)
			{
				cellSize = num2;
			}
			int num3 = Mathf.FloorToInt(num / cellSize);
			int num4 = Mathf.FloorToInt(num2 / cellSize);
			cellPositions = new Vector3[num3, num4];
			verticalCorrection = new float[num3, num4];
			cellAgents = new int[num3, num4];
			for (int i = 0; i < num3; i++)
			{
				for (int j = 0; j < num4; j++)
				{
					cellAgents[i, j] = -1;
					cellPositions[i, j] = vector + ((float)i + 0.5f) * rightVector * cellSize + ((float)j + 0.5f) * forwardVector * cellSize;
					CorrectVerticalPosition(initialHeight, ref cellPositions[i, j]);
				}
			}
			lastWorldPosition = base.transform.position;
			return true;
		}

		private float CorrectVerticalPosition(HeightCorrectionMode mode, ref Vector3 input)
		{
			float y = input.y;
			switch (mode)
			{
			case HeightCorrectionMode.Heightmap:
				input.y = HeightMapProvider.GetInterpolated(input);
				break;
			case HeightCorrectionMode.Raycast:
			{
				float y2 = areaCollider.size.y;
				Vector3 origin = input + Vector3.up * y2;
				int num = Physics.RaycastNonAlloc(origin, Vector3.down, raycastResultsCache, y2, layerMask, QueryTriggerInteraction.Ignore);
				float num2 = float.PositiveInfinity;
				for (int i = 0; i < num; i++)
				{
					if (raycastResultsCache[i].distance < num2 && !agentColliders.Contains(raycastResultsCache[i].collider))
					{
						num2 = raycastResultsCache[i].distance;
					}
				}
				if (num2 < float.PositiveInfinity)
				{
					input.y = origin.y - num2;
				}
				break;
			}
			}
			return input.y - y;
		}

		private bool InitializeAgents(bool reInstantiateAgents)
		{
			if (reInstantiateAgents)
			{
				if (agents != null)
				{
					for (int i = 0; i < agents.Length; i++)
					{
						if ((bool)agents[i].gameObject)
						{
							UnityEngine.Object.Destroy(agents[i].gameObject);
						}
					}
					agentColliders.Clear();
				}
				agentRobin = 0;
			}
			int num = ((!reInstantiateAgents) ? agents.Length : ((areaCoverPercentage > 0f) ? Mathf.CeilToInt(areaCoverPercentage * (float)CellCount) : 0));
			if (num == 0)
			{
				return true;
			}
			if (reInstantiateAgents)
			{
				agents = new AgentState[num];
				PrefabEntry[] weightedPicks = agentPrefabs.GetWeightedPicks((PrefabEntry entry) => entry.distributionWeight, num);
				for (int num2 = 0; num2 < num; num2++)
				{
					agents[num2].definition = weightedPicks[num2];
					agents[num2].gameObject = UnityEngine.Object.Instantiate(agents[num2].definition.prefab, base.transform);
					agents[num2].gameObject.name = "Agent_" + num2.ToString("D3") + "_" + agents[num2].definition.prefab.name;
					Collider[] componentsInChildren = agents[num2].gameObject.GetComponentsInChildren<Collider>();
					foreach (Collider item in componentsInChildren)
					{
						agentColliders.Add(item);
					}
				}
				lastAnimatorState = true;
			}
			Vector2Int[] array = new Vector2Int[CellCount];
			for (int num4 = 0; num4 < CellCount; num4++)
			{
				array[num4] = new Vector2Int(num4 % CellsX, num4 / CellsX);
			}
			array.Shuffle();
			hidden = false;
			if (PlayerManager.ActiveCamera != null)
			{
				float sqrMagnitude = (PlayerManager.ActiveCamera.transform.position - areaCollider.transform.TransformPoint(areaCollider.center)).sqrMagnitude;
				hidden = sqrMagnitude > (hideDistance + sphereRadius) * (hideDistance + sphereRadius);
			}
			for (int num5 = 0; num5 < num; num5++)
			{
				agents[num5].currentCell = array[num5];
				cellAgents[agents[num5].currentCell.x, agents[num5].currentCell.y] = num5;
				agents[num5].cellOffset = UnityEngine.Random.insideUnitCircle * (0.44710678f - agents[num5].definition.radius / cellSize);
				agents[num5].currentPosition = GetWorldPosition(agents[num5].currentCell, agents[num5].cellOffset);
				agents[num5].gameObject.transform.position = agents[num5].currentPosition;
				agents[num5].gameObject.SetActive(!hidden);
				agents[num5].animator = agents[num5].gameObject.GetComponent<Animator>();
				if (!hidden)
				{
					agents[num5].animator.Play(as_Idle);
					agents[num5].animator.Update(agents[num5].animator.GetCurrentAnimatorStateInfo(0).length * UnityEngine.Random.value);
				}
				agents[num5].lastDirectionIndex = UnityEngine.Random.Range(0, directionAngle.Length);
				agents[num5].currentAngle = directionAngle[agents[num5].lastDirectionIndex] + UnityEngine.Random.Range(-30f, 30f);
				agents[num5].gameObject.transform.rotation = Quaternion.Euler(0f, agents[num5].currentAngle + 90f, 0f);
				agents[num5].actionCooldown = UnityEngine.Random.Range(actionCooldown.x, actionCooldown.y);
				agents[num5].moving = false;
				if (!reInstantiateAgents && !hidden)
				{
					agents[num5].animator.SetBool(ap_Move, value: false);
				}
			}
			return true;
		}

		private Vector3 GetWorldPosition(Vector2Int cell, Vector2 offset)
		{
			if (cellPositions == null)
			{
				return Vector3.zero;
			}
			cell.x = Mathf.Clamp(cell.x, 0, CellsX);
			cell.y = Mathf.Clamp(cell.y, 0, CellsZ);
			return cellPositions[cell.x, cell.y] + offset.x * cellSize * rightVector + offset.y * cellSize * forwardVector;
		}

		private bool CheckForOriginShift()
		{
			if (lastWorldPosition != base.transform.position)
			{
				Vector3 vector = base.transform.position - lastWorldPosition;
				for (int i = 0; i < agents.Length; i++)
				{
					agents[i].currentPosition += vector;
					agents[i].nextPosition += vector;
				}
				float num = 0f;
				for (int j = 0; j < CellsX; j++)
				{
					for (int k = 0; k < CellsZ; k++)
					{
						cellPositions[j, k] += vector;
						verticalCorrection[j, k] = CorrectVerticalPosition(initialHeight, ref cellPositions[j, k]);
						if (Mathf.Abs(verticalCorrection[j, k]) > num)
						{
							num = verticalCorrection[j, k];
						}
					}
				}
				for (int l = 0; l < agents.Length; l++)
				{
					agents[l].currentPosition += Vector3.up * verticalCorrection[agents[l].currentCell.x, agents[l].currentCell.y];
					agents[l].gameObject.transform.position += Vector3.up * verticalCorrection[agents[l].currentCell.x, agents[l].currentCell.y];
					if (agents[l].moving)
					{
						agents[l].nextPosition += Vector3.up * verticalCorrection[agents[l].nextCell.x, agents[l].nextCell.y];
					}
				}
				lastWorldPosition = base.transform.position;
				if (!CheckIfTerrainIsLoaded())
				{
					initialized = false;
					StartCoroutine(Start());
					return true;
				}
			}
			return false;
		}

		private void Update()
		{
			if (!initialized || agents == null || agents.Length == 0 || CheckForOriginShift() || PlayerManager.ActiveCamera == null)
			{
				return;
			}
			float sqrMagnitude = (PlayerManager.ActiveCamera.transform.position - areaCollider.transform.TransformPoint(areaCollider.center)).sqrMagnitude;
			if (hideDistance > 0f)
			{
				if (!hidden && sqrMagnitude > (hideDistance + sphereRadius) * (hideDistance + sphereRadius))
				{
					hidden = true;
					for (int i = 0; i < agents.Length; i++)
					{
						agents[i].gameObject.SetActive(value: false);
					}
				}
				else if (hidden && sqrMagnitude < (hideDistance + sphereRadius) * (hideDistance + sphereRadius))
				{
					hidden = false;
					for (int j = 0; j < agents.Length; j++)
					{
						agents[j].gameObject.SetActive(value: true);
					}
				}
			}
			if (hidden)
			{
				return;
			}
			if (sqrMagnitude > (movementUpdateDistance + sphereRadius) * (movementUpdateDistance + sphereRadius))
			{
				if (lastAnimatorState)
				{
					for (int k = 0; k < agents.Length; k++)
					{
						if ((bool)agents[k].animator)
						{
							agents[k].animator.enabled = false;
						}
					}
					lastAnimatorState = false;
				}
				lastManagedTime = SingletonBehaviour<WeatherDriver>.Instance.ManagedDateTime;
				return;
			}
			if (!lastAnimatorState)
			{
				for (int l = 0; l < agents.Length; l++)
				{
					if ((bool)agents[l].animator)
					{
						agents[l].animator.enabled = true;
					}
				}
				lastAnimatorState = true;
			}
			float smoothDeltaTime = Time.smoothDeltaTime;
			if (!(smoothDeltaTime <= 0f) && !(Time.timeScale < 0.001f))
			{
				lastManagedTime = SingletonBehaviour<WeatherDriver>.Instance.ManagedDateTime;
				float num = SingletonBehaviour<WeatherDriver>.Instance.manager.DayLengthInMinutes;
				if (float.IsNaN(num) || float.IsInfinity(num))
				{
					num = BaselineDayLength;
				}
				float num2 = BaselineDayLength / num;
				smoothDeltaTime *= num2;
				HeightCorrectionMode heightMode = ((sqrMagnitude < fineCorrectionDistance * fineCorrectionDistance) ? initialHeight : HeightCorrectionMode.None);
				UpdateAgents(smoothDeltaTime, num2, heightMode);
			}
		}

		private void UpdateAgents(float deltaTime, float timeScale, HeightCorrectionMode heightMode)
		{
			UpdateMovingAgents(deltaTime, timeScale, heightMode);
			timeToNextMove -= deltaTime;
			if (timeToNextMove < 0f || timeToNextMove > initialTimeToNextMove)
			{
				initialTimeToNextMove = UnityEngine.Random.Range(averageMovementInterval.x, averageMovementInterval.y);
				timeToNextMove = ((deltaTime >= 0f) ? initialTimeToNextMove : 1E-05f);
				if (!agents[agentRobin].moving && (double)agents[agentRobin].actionBlock <= 0.0)
				{
					TryToMoveAgent(agentRobin, deltaTime >= 0f);
				}
				agentRobin = (agentRobin + 1) % agents.Length;
			}
			if (timeJumping)
			{
				return;
			}
			timeToIdleSound -= deltaTime;
			if (!(timeToIdleSound < 0f) && !(timeToIdleSound > initialTimeToIdleSound))
			{
				return;
			}
			initialTimeToIdleSound = UnityEngine.Random.Range(idleSoundCooldown.x, idleSoundCooldown.y);
			timeToIdleSound = ((deltaTime >= 0f) ? initialTimeToIdleSound : 1E-05f);
			int num = UnityEngine.Random.Range(0, agents.Length);
			for (int i = 0; i < agents.Length; i++)
			{
				int num2 = (num + i) % agents.Length;
				if (agents[num2].definition.idleSounds.Length != 0 && ShouldPlaySounds)
				{
					agents[num2].definition.idleSounds.Play(agents[num2].gameObject.transform.TransformPoint(agents[num2].definition.soundPosition), 1f, parent: agents[num2].gameObject.transform, pitch: UnityEngine.Random.Range(0.9f, 1.1f));
					break;
				}
			}
		}

		private void UpdateMovingAgents(float deltaTime, float timeScale, HeightCorrectionMode heightMode)
		{
			for (int i = 0; i < agents.Length; i++)
			{
				if (agents[i].moving)
				{
					Vector3 position = agents[i].gameObject.transform.position;
					agents[i].movementPhase = Mathf.Clamp01(agents[i].movementPhase + agents[i].movementMultiplier * deltaTime);
					float phase = movementCurve.Evaluate(agents[i].movementPhase);
					Vector3 right = agents[i].gameObject.transform.right;
					right.y = 0f;
					right.Normalize();
					Vector3 curvePosition = GetCurvePosition(agents[i].currentPosition, agents[i].currentAngle, agents[i].nextPosition, agents[i].nextAngle, phase, 1f, heightMode);
					float num = Vector3.Distance(position, curvePosition) / deltaTime * agents[i].definition.animationSpeedScale;
					agents[i].animator.SetBool(ap_Move, value: true);
					agents[i].animator.SetFloat(ap_Speed, Mathf.Max(0.1f, num));
					agents[i].gameObject.transform.position = curvePosition;
					float time = agents[i].movementPhase + 0.05f;
					float phase2 = movementCurve.Evaluate(time);
					Vector3 vector = GetCurvePosition(agents[i].currentPosition, agents[i].currentAngle, agents[i].nextPosition, agents[i].nextAngle, phase2, 1f, HeightCorrectionMode.None) - curvePosition;
					vector.y = 0f;
					Quaternion quaternion = ((!(vector != Vector3.zero)) ? agents[i].gameObject.transform.rotation : Quaternion.LookRotation(vector, Vector3.up));
					Quaternion b = Quaternion.Euler(0f, agents[i].currentAngle + 90f, 0f);
					Quaternion b2 = Quaternion.Euler(0f, agents[i].nextAngle + 90f, 0f);
					if (agents[i].movementPhase < 0.1f)
					{
						quaternion = Quaternion.Slerp(quaternion, b, 1f - Mathf.Clamp01(agents[i].movementPhase * 10f));
					}
					else if (agents[i].movementPhase > 0.9f)
					{
						quaternion = Quaternion.Slerp(quaternion, b2, Mathf.Clamp01((agents[i].movementPhase - 0.9f) * 10f));
					}
					Vector3 rhs = quaternion * Vector3.forward;
					rhs.y = 0f;
					rhs.Normalize();
					float num2 = Vector3.Dot(right, rhs);
					num2 *= agents[i].definition.maxTilt;
					num2 *= -20f;
					num2 = Mathf.Clamp(num2, 0f - agents[i].definition.maxTilt, agents[i].definition.maxTilt);
					quaternion *= Quaternion.AngleAxis(num2, Vector3.forward);
					agents[i].gameObject.transform.rotation = quaternion;
					float num3 = 1f - agents[i].definition.endTransition * agents[i].movementMultiplier;
					if (agents[i].movementPhase > num3)
					{
						float t = Mathf.InverseLerp(num3, 1f, agents[i].movementPhase);
						agents[i].animator.SetFloat(ap_Speed, Mathf.Max(0.1f, Mathf.Lerp(num, 1f, t)));
						agents[i].animator.SetBool(ap_Move, value: false);
					}
					if (deltaTime >= 0f)
					{
						if (agents[i].movementPhase >= 1f)
						{
							agents[i].currentPosition = agents[i].nextPosition;
							agents[i].currentCell = agents[i].nextCell;
							agents[i].currentAngle = agents[i].nextAngle;
							agents[i].cellOffset = agents[i].nextCellOffset;
							agents[i].moving = false;
							agents[i].animator.SetBool(ap_Move, value: false);
							agents[i].actionBlock = UnityEngine.Random.Range(postMovementCooldown.x, postMovementCooldown.y);
						}
					}
					else if (agents[i].movementPhase <= 0f)
					{
						agents[i].moving = false;
						agents[i].animator.SetBool(ap_Move, value: false);
						cellAgents[agents[i].currentCell.x, agents[i].currentCell.y] = i;
						cellAgents[agents[i].nextCell.x, agents[i].nextCell.y] = -1;
					}
				}
				else if (agents[i].actionBlock > 0f)
				{
					agents[i].actionBlock = Mathf.Clamp01(agents[i].actionBlock - Mathf.Abs(deltaTime));
				}
				else if (agents[i].actionCooldown > 0f)
				{
					agents[i].actionCooldown -= deltaTime;
					if (agents[i].actionCooldown <= 0f || agents[i].actionCooldown > agents[i].initialActionCooldown)
					{
						agents[i].initialActionCooldown = UnityEngine.Random.Range(actionCooldown.x, actionCooldown.y);
						agents[i].actionCooldown = ((deltaTime >= 0f) ? agents[i].initialActionCooldown : 1E-05f);
						agents[i].actionBlock = agents[i].definition.actionDuration;
						agents[i].animator.SetTrigger(ap_Action);
						if (!timeJumping && agents[i].definition.actionSounds.Length != 0 && ShouldPlaySounds)
						{
							agents[i].definition.actionSounds.Play(agents[i].gameObject.transform.TransformPoint(agents[i].definition.soundPosition), 1f, parent: agents[i].gameObject.transform, pitch: UnityEngine.Random.Range(0.9f, 1.1f));
						}
					}
				}
				agents[i].animator.speed = Mathf.Abs(timeScale);
			}
		}

		private void TryToMoveAgent(int agentID, bool forward)
		{
			bool flag = false;
			for (int i = 0; i < directions.Length; i++)
			{
				Vector2Int vector2Int = agents[agentID].currentCell + directions[i];
				if (vector2Int.x >= 0 && vector2Int.y >= 0 && vector2Int.x < CellsX && vector2Int.y < CellsZ)
				{
					int num = cellAgents[vector2Int.x, vector2Int.y];
					if (num >= 0 && agents[num].moving)
					{
						flag = true;
						break;
					}
				}
			}
			if (flag)
			{
				return;
			}
			int num2 = UnityEngine.Random.Range(0, directions.Length);
			for (int j = 0; j < directions.Length; j++)
			{
				int num3 = (j + num2) % directions.Length;
				Vector2Int nextCell = agents[agentID].currentCell + directions[num3];
				if (CellsX >= 3 && CellsZ >= 3)
				{
					bool num4 = nextCell.x == 0 || nextCell.x == CellsX - 1;
					bool flag2 = nextCell.y == 0 || nextCell.y == CellsZ - 1;
					if (num4 && flag2)
					{
						continue;
					}
					if (forward)
					{
						if (Mathf.Abs(Mathf.DeltaAngle(directionAngle[agents[agentID].lastDirectionIndex], directionAngle[num3])) > 100f)
						{
							continue;
						}
					}
					else if (Mathf.Abs(Mathf.DeltaAngle(directionAngle[agents[agentID].lastDirectionIndex], directionAngle[num3])) <= 80f)
					{
						continue;
					}
				}
				if (nextCell.x >= 0 && nextCell.y >= 0 && nextCell.x < CellsX && nextCell.y < CellsZ && cellAgents[nextCell.x, nextCell.y] < 0)
				{
					if (forward)
					{
						agents[agentID].lastDirectionIndex = num3;
					}
					else
					{
						agents[agentID].lastDirectionIndex = (num3 + directions.Length / 2) % directions.Length;
					}
					if (forward)
					{
						cellAgents[agents[agentID].currentCell.x, agents[agentID].currentCell.y] = -1;
						cellAgents[nextCell.x, nextCell.y] = agentID;
					}
					agents[agentID].nextCell = nextCell;
					agents[agentID].nextAngle = Mathf.Repeat(directionAngle[agents[agentID].lastDirectionIndex] + UnityEngine.Random.Range(-30f, 30f), 360f);
					agents[agentID].nextCellOffset = UnityEngine.Random.insideUnitCircle * (0.44710678f - agents[agentID].definition.radius / cellSize);
					agents[agentID].nextPosition = GetWorldPosition(agents[agentID].nextCell, agents[agentID].nextCellOffset);
					float num5 = Vector3.Distance(agents[agentID].currentPosition, agents[agentID].nextPosition);
					agents[agentID].movementMultiplier = 1f / num5 * agents[agentID].definition.movementSpeed;
					agents[agentID].movementPhase = 0f;
					agents[agentID].moving = true;
					if (!forward)
					{
						ref Vector2Int nextCell2 = ref agents[agentID].nextCell;
						ref Vector2Int currentCell = ref agents[agentID].currentCell;
						Vector2Int currentCell2 = agents[agentID].currentCell;
						Vector2Int nextCell3 = agents[agentID].nextCell;
						nextCell2 = currentCell2;
						currentCell = nextCell3;
						ref float nextAngle = ref agents[agentID].nextAngle;
						ref float currentAngle = ref agents[agentID].currentAngle;
						float currentAngle2 = agents[agentID].currentAngle;
						float nextAngle2 = agents[agentID].nextAngle;
						nextAngle = currentAngle2;
						currentAngle = nextAngle2;
						ref Vector2 nextCellOffset = ref agents[agentID].nextCellOffset;
						ref Vector2 cellOffset = ref agents[agentID].cellOffset;
						Vector2 cellOffset2 = agents[agentID].cellOffset;
						Vector2 nextCellOffset2 = agents[agentID].nextCellOffset;
						nextCellOffset = cellOffset2;
						cellOffset = nextCellOffset2;
						ref Vector3 nextPosition = ref agents[agentID].nextPosition;
						ref Vector3 currentPosition = ref agents[agentID].currentPosition;
						Vector3 currentPosition2 = agents[agentID].currentPosition;
						Vector3 nextPosition2 = agents[agentID].nextPosition;
						nextPosition = currentPosition2;
						currentPosition = nextPosition2;
						agents[agentID].movementPhase = 1f - agents[agentID].movementPhase;
					}
					break;
				}
			}
		}

		private Vector3 GetCurvePosition(Vector3 startPosition, float startAngle, Vector3 endPosition, float endAngle, float phase, float curveRadius, HeightCorrectionMode heightMode)
		{
			Vector3 vector = new Vector3(Mathf.Cos(startAngle * ((float)Math.PI / 180f)), 0f, 0f - Mathf.Sin(startAngle * ((float)Math.PI / 180f)));
			Vector3 vector2 = new Vector3(Mathf.Cos(endAngle * ((float)Math.PI / 180f)), 0f, 0f - Mathf.Sin(endAngle * ((float)Math.PI / 180f)));
			float num = Vector3.Distance(startPosition, endPosition);
			Vector3 b = startPosition + vector * (num * curveRadius);
			Vector3 a = endPosition - vector2 * (num * curveRadius);
			Vector3 a2 = Vector3.Lerp(startPosition, b, phase);
			Vector3 b2 = Vector3.Lerp(a, endPosition, phase);
			Vector3 input = Vector3.Lerp(a2, b2, Mathf.SmoothStep(0f, 1f, phase));
			CorrectVerticalPosition(heightMode, ref input);
			return input;
		}
	}
}
