using System;
using System.Collections.Generic;
using NSEipix;
using NSEipix.Base;
using NSEipix.TaskManager;
using NSMedieval.BuildingComponents;
using NSMedieval.Enums;
using NSMedieval.Map;
using NSMedieval.State;
using NSMedieval.StatsSystem;
using NSMedieval.Terrain;
using NSMedieval.Utils.Pool.Janitors;
using NSMedieval.View;
using NSMedieval.Village;
using NSMedieval.Village.Map;
using UnityEngine;

namespace NSMedieval
{
	public class BezierProjectileTrajectory : MonoBehaviour
	{
		private const int IgnoreCollisionDistance = 4;

		private const string VillagerTag = "Villager";

		private const string TargetableBySiegeWeaponTag = "TargetableBySiegeWeapon";

		private static int raycastLayerMask;

		[SerializeField]
		private Vector3 target;

		[SerializeField]
		private float speed = 4f;

		[SerializeField]
		private MeshRenderer projectileMeshRenderer;

		private Vec3Int startPos;

		private int currentWayPoint;

		private List<Vector3> points;

		private float destroyDelay;

		private readonly RaycastHit[] raycastHitsBuffer = new RaycastHit[20];

		private float damageMultAfterHit;

		private float damageMultiplier;

		private bool doDamageAtFinalPoint;

		[NonSerialized]
		private VillageMap map;

		private int selectableLayer;

		private Task hideGameObjectTask;

		private float hideAfterSeconds;

		[SerializeField]
		private List<GameObject> vfxToHideImmediately;

		private bool isEnded = true;

		private int raycastCheck = 1;

		private readonly HashSet<Vec3Int> collisions = new HashSet<Vec3Int>();

		private static int RaycastLayerMask
		{
			get
			{
				if (raycastLayerMask == 0)
				{
					raycastLayerMask = (1 << LayerMask.NameToLayer("VoxelMap")) | (1 << LayerMask.NameToLayer("BuildableSurface")) | (1 << LayerMask.NameToLayer("CombatCover")) | (1 << LayerMask.NameToLayer("Selectable"));
				}
				return raycastLayerMask;
			}
		}

		public bool IsEnded => isEnded;

		public Vec3Int StartPos => startPos;

		public event Action<Vector3> DestinationReachedEvent;

		public event Action<Vector3, float, bool> ProjectileHitEvent;

		public event Action<CreatureBase, float> CreatureHitEvent;

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
		private static void OnDomainReload()
		{
			raycastLayerMask = 0;
		}

		private void OnDestroy()
		{
			this.CreatureHitEvent = null;
			this.DestinationReachedEvent = null;
			this.ProjectileHitEvent = null;
			if (MonoSingleton<GlobalSaveController>.IsApplicationIsQuitting() && MonoSingleton<TaskController>.IsInstantiated())
			{
				Task task = hideGameObjectTask;
				if (task != null && task.IsRunning)
				{
					MonoSingleton<TaskController>.Instance.Stop(hideGameObjectTask);
					base.gameObject.SetActive(value: false);
				}
			}
			hideGameObjectTask = null;
			SetActiveAdditionalProjectileFlyingEffects(active: false);
		}

		private void SetActiveAdditionalProjectileFlyingEffects(bool active)
		{
			foreach (GameObject item in vfxToHideImmediately)
			{
				item.SetActive(active);
			}
		}

		public static List<Vector3> CalculateTrajectoryPoints(SiegeWeaponType siegeWeaponType, Vector3 start, Vector3 end, out bool willDamageFinalPoint)
		{
			switch (siegeWeaponType)
			{
			case SiegeWeaponType.Trebuchet:
				return CalculateTrebuchetTrajectoryPoints(start, end, out willDamageFinalPoint);
			case SiegeWeaponType.Ballista:
				willDamageFinalPoint = true;
				return CalculateBallistaTrajectoryPoints(start, end);
			default:
				willDamageFinalPoint = true;
				return CalculateOnagerTrajectoryPoints(start, end);
			}
		}

		private static List<Vector3> CalculateTrebuchetTrajectoryPoints(Vector3 start, Vector3 end, out bool willDamageFinalPoint)
		{
			Vector3 item = start + (end - start) / 2f + Vector3.up * Mathf.Sqrt(Vector3.Distance(start, end) * 1.1f);
			List<Vector3> list = new List<Vector3> { start, item, item, end };
			List<Vector3> list2 = BezierPath.CreateCurve(list, 5);
			int pointCount = 25;
			Vector3 normalized = (list2[list2.Count - 1] - list2[list2.Count - 2]).normalized;
			if (Physics.Raycast(end, normalized, out var hitInfo, 200f, 1 << MonoSingleton<World>.Instance.TerrainLayer))
			{
				willDamageFinalPoint = true;
				if (Vector3.Distance(end, hitInfo.point) > 2.5f)
				{
					list[2] = end;
					list[3] = hitInfo.point;
				}
			}
			else
			{
				willDamageFinalPoint = false;
				list[2] = end;
				list[3] = end + normalized * 25f;
			}
			return BezierPath.CreateCurve(list, pointCount);
		}

		private static List<Vector3> CalculateBallistaTrajectoryPoints(Vector3 start, Vector3 end)
		{
			Vector3 vector = new Vector3(0f, Mathf.Clamp(Mathf.Sqrt(Mathf.Abs(start.y - end.y)), 0f, Mathf.Max(Mathf.Abs(start.y), Mathf.Abs(end.y))), 0f);
			Vector3 item = Vector3.Lerp(start + vector, end + vector, 0.5f);
			return BezierPath.CreateCurve(new List<Vector3> { start, item, item, end }, 30);
		}

		private static List<Vector3> CalculateOnagerTrajectoryPoints(Vector3 start, Vector3 end)
		{
			Vector3 item = start + (end - start) / 2f + Vector3.up * Mathf.Sqrt(Vector3.Distance(start, end));
			return BezierPath.CreateCurve(new List<Vector3> { start, item, item, end });
		}

		private void Awake()
		{
			selectableLayer = LayerMask.NameToLayer("Selectable");
		}

		private void OnDrawGizmos()
		{
			Color color = Gizmos.color;
			Gizmos.color = Color.red;
			foreach (Vec3Int collision in collisions)
			{
				Gizmos.DrawCube(GridUtils.GetWorldPosition(collision) + Vector3.up * 1.5f, Vector3.up * 3f + Vector3.right + Vector3.forward);
			}
			Gizmos.color = color;
		}

		public void Setup(SiegeWeaponType siegeWeaponType, Vector3 start, Vector3 end, float speed, SiegeWeaponProjectileBlueprint projectileBlueprint)
		{
			map = VillageManager.ActiveVillage.Map;
			startPos = start.ToGridVec3Int();
			projectileMeshRenderer.enabled = true;
			if (projectileBlueprint != null)
			{
				damageMultAfterHit = 1f - Mathf.Clamp01(projectileBlueprint.PowerLossAfterHit);
			}
			else
			{
				damageMultAfterHit = 0.9f;
			}
			CalculateHideAfterSecondsDuration(projectileBlueprint, siegeWeaponType);
			isEnded = false;
			base.transform.position = start;
			destroyDelay = 0.05f;
			damageMultiplier = 1f;
			collisions.Clear();
			this.speed = speed;
			currentWayPoint = 0;
			points = CalculateTrajectoryPoints(siegeWeaponType, start, end, out doDamageAtFinalPoint);
			target = points[points.Count - 1];
			SetActiveAdditionalProjectileFlyingEffects(active: true);
		}

		private void CalculateHideAfterSecondsDuration(SiegeWeaponProjectileBlueprint projectileBlueprint, SiegeWeaponType siegeWeaponType)
		{
			switch (siegeWeaponType)
			{
			case SiegeWeaponType.Ballista:
				hideAfterSeconds = 2f;
				break;
			case SiegeWeaponType.Onager:
				hideAfterSeconds = ((!projectileBlueprint.SpawnsFire) ? 2f : 10f);
				break;
			case SiegeWeaponType.Trebuchet:
				hideAfterSeconds = ((!projectileBlueprint.SpawnsFire) ? 2f : 10f);
				break;
			}
		}

		private void FixedUpdate()
		{
			if (this == null || points == null || points.Count == 0)
			{
				return;
			}
			if (currentWayPoint < points.Count)
			{
				Move();
				return;
			}
			destroyDelay -= Time.fixedDeltaTime;
			if (!(destroyDelay <= 0f))
			{
				return;
			}
			Task task = hideGameObjectTask;
			if ((task == null || !task.IsRunning) && hideGameObjectTask == null)
			{
				hideGameObjectTask = MonoSingleton<TaskController>.Instance.WaitFor(hideAfterSeconds).Then(delegate
				{
					base.gameObject.SetActive(value: false);
					hideGameObjectTask = null;
				});
			}
			SetActiveAdditionalProjectileFlyingEffects(active: false);
		}

		private void Move()
		{
			Vector3 vector = points[currentWayPoint];
			Transform obj = base.transform;
			Vector3 position = obj.position;
			obj.forward = Vector3.RotateTowards(obj.forward, vector - position, speed * Time.fixedDeltaTime, 0f);
			obj.position = Vector3.MoveTowards(position, vector, speed * Time.fixedDeltaTime);
			if (!(Vector3.Distance(obj.position, vector) <= 0.1f))
			{
				return;
			}
			currentWayPoint++;
			if (currentWayPoint >= points.Count && this.ProjectileHitEvent != null)
			{
				if (doDamageAtFinalPoint)
				{
					this.ProjectileHitEvent?.Invoke(target, damageMultiplier, arg3: true);
				}
				this.DestinationReachedEvent?.Invoke(target);
				isEnded = true;
				base.transform.position = target;
				TriggerProjectileEffectHiding();
			}
			else if (currentWayPoint >= raycastCheck && currentWayPoint % raycastCheck == 0 && currentWayPoint >= 0 && currentWayPoint < points.Count)
			{
				Vector3 currentPt = points[currentWayPoint];
				Vector3 prevPt = points[currentWayPoint - raycastCheck];
				CheckProjectileCollision(currentPt, prevPt);
			}
		}

		private void TriggerProjectileEffectHiding()
		{
			Task task = hideGameObjectTask;
			if (task != null && task.IsRunning)
			{
				return;
			}
			hideGameObjectTask = MonoSingleton<TaskController>.Instance.WaitFor(hideAfterSeconds).Then(delegate
			{
				if (!(this == null))
				{
					if (base.gameObject != null)
					{
						base.gameObject.SetActive(value: false);
					}
					hideGameObjectTask = null;
				}
			});
			projectileMeshRenderer.enabled = false;
			SetActiveAdditionalProjectileFlyingEffects(active: false);
		}

		private void CheckProjectileCollision(Vector3 currentPt, Vector3 prevPt)
		{
			Vector3 vector = currentPt - prevPt;
			float maxDistance = Vector3.Magnitude(vector);
			int num = Physics.RaycastNonAlloc(prevPt, vector, raycastHitsBuffer, maxDistance, RaycastLayerMask);
			for (int i = 0; i < num; i++)
			{
				RaycastHit hit = raycastHitsBuffer[i];
				Vec3Int a = GridUtils.GetGridPosition(hit.point - hit.normal * 0.1f + Vector3.down * ((float)World.MapBlockHeight * 0.5f));
				if (IgnoreHitIfTooClose(a) || IgnoreHitIfTooClose(a + ILSpyHelper_AsRefReadOnly(Vector3.up)))
				{
					continue;
				}
				if (CheckIfCreatureIsHit(hit, out var hitCreature))
				{
					bool flag = false;
					if (hitCreature == null)
					{
						continue;
					}
					this.CreatureHitEvent?.Invoke(hitCreature, damageMultiplier);
					damageMultiplier *= damageMultAfterHit;
					if (hitCreature.HasDied || hitCreature.HasDisposed)
					{
						flag = true;
					}
					StatInstance stat = hitCreature.GetStat(StatType.Health);
					if (stat != null)
					{
						if (stat.Current <= 0.001f)
						{
							flag = true;
						}
						if (!flag)
						{
							target = hit.point;
							base.transform.position = target;
							currentWayPoint = points.Count;
							this.DestinationReachedEvent?.Invoke(target);
							TriggerProjectileEffectHiding();
							isEnded = true;
							break;
						}
					}
				}
				else
				{
					if (hit.transform.gameObject.layer == selectableLayer)
					{
						continue;
					}
					if (hit.transform.CompareTag("MapChunk"))
					{
						a = hit.point.ToGridVec3Int();
						if (collisions.Add(a))
						{
							this.ProjectileHitEvent?.Invoke(hit.point, damageMultiplier, arg3: true);
							damageMultiplier *= damageMultAfterHit;
							target = hit.point;
							base.transform.position = target;
							currentWayPoint = points.Count;
							this.DestinationReachedEvent?.Invoke(a.ToVector3World());
							TriggerProjectileEffectHiding();
							isEnded = true;
							break;
						}
					}
					if (!hit.transform.CompareTag("Building"))
					{
						continue;
					}
					a = hit.transform.position.ToGridVec3Int();
					if (collisions.Add(a))
					{
						this.ProjectileHitEvent?.Invoke(hit.point, damageMultiplier, arg3: true);
						damageMultiplier *= damageMultAfterHit;
						a = hit.transform.position.ToGridVec3Int();
						if (ShouldProjectileStop(a))
						{
							target = hit.point;
							base.transform.position = target;
							currentWayPoint = points.Count;
							this.DestinationReachedEvent?.Invoke(a.ToVector3World());
							TriggerProjectileEffectHiding();
							isEnded = true;
							break;
						}
					}
				}
			}
			static ref readonly T ILSpyHelper_AsRefReadOnly<T>(in T temp)
			{
				//ILSpy generated this function to help ensure overload resolution can pick the overload using 'in'
				return ref temp;
			}
		}

		private bool IgnoreHitIfTooClose(Vec3Int hitPosition)
		{
			if (Vec3Int.DistanceSquared(in startPos, in hitPosition) > 16)
			{
				return false;
			}
			using PooledList<BaseBuildingInstance> pooledList = map.BuildingsManagerMain.GetBuildings(hitPosition, (BaseBuildingInstance x) => !x.HasDisposed);
			foreach (BaseBuildingInstance item in pooledList)
			{
				if (item.HasDisposed)
				{
					continue;
				}
				if (item.BuildingType == BuildingType.Merlon)
				{
					return true;
				}
				if (item.BuildingType == BuildingType.Door && item.GetNode().Tag.HasFlag(MapNodeTags.DoorAlwaysOpen))
				{
					return true;
				}
				if (item.BuildingType == BuildingType.Window)
				{
					WindowComponentInstance componentInstance = item.GetComponentInstance<WindowComponentInstance>();
					if (componentInstance != null && componentInstance.LockState == LockState.AlwaysOpen)
					{
						return true;
					}
				}
			}
			return false;
		}

		private bool CheckIfCreatureIsHit(RaycastHit hit)
		{
			if (hit.transform.gameObject.layer == LayerMask.NameToLayer("Selectable"))
			{
				if (!hit.transform.CompareTag("Villager"))
				{
					return hit.transform.CompareTag("TargetableBySiegeWeapon");
				}
				return true;
			}
			return false;
		}

		private bool CheckIfCreatureIsHit(RaycastHit hit, out CreatureBase hitCreature)
		{
			hitCreature = null;
			if (Vec3Int.DistanceSquared(in startPos, hit.transform.position.ToGridVec3Int()) < 16)
			{
				return false;
			}
			if (hit.transform.gameObject.layer == LayerMask.NameToLayer("Selectable") && (hit.transform.CompareTag("Villager") || hit.transform.CompareTag("TargetableBySiegeWeapon")))
			{
				SelectableObject selectableObject = hit.transform.GetComponent<SelectableObject>();
				if (selectableObject == null)
				{
					selectableObject = hit.transform.GetComponentInParent<SelectableObject>();
				}
				if (selectableObject != null)
				{
					hitCreature = selectableObject.GetAsCreature();
					return true;
				}
			}
			return false;
		}

		private bool ShouldProjectileStop(Vec3Int gridPosition)
		{
			if (MonoSingleton<GroundManager>.Instance.GroundExists(gridPosition))
			{
				return true;
			}
			using PooledList<BaseBuildingInstance> pooledList = VillageManager.ActiveVillage.Map.BuildingsManagerMain.GetBuildings(gridPosition, delegate(BaseBuildingInstance x)
			{
				BuildingType buildingType = BuildingType.Wall | BuildingType.Floor | BuildingType.Roof | BuildingType.Window | BuildingType.Door | BuildingType.Merlon | BuildingType.BarnDoor;
				return buildingType.HasFlag(x.BuildingType);
			});
			foreach (BaseBuildingInstance item in pooledList)
			{
				if (item != null && !item.HasDisposed && item.Stats != null)
				{
					StatInstance stat = item.Stats.GetStat(StatType.Health);
					if (stat != null && stat.Current > 0f)
					{
						return true;
					}
				}
			}
			return false;
		}
	}
}
