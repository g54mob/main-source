using System;
using System.Collections.Generic;
using System.Linq;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.Components;
using NSMedieval.Construction;
using NSMedieval.EnvironmentEffects;
using NSMedieval.Manager;
using NSMedieval.Map;
using NSMedieval.Model;
using NSMedieval.Repository;
using NSMedieval.Sound;
using NSMedieval_Pooling;
using UnityEngine;

namespace NSMedieval.BuildingComponents
{
	[RequireComponent(typeof(SiegeWeaponComponent), typeof(AudioEventsComponent))]
	public class SiegeWeaponViewComponent : ComponentBaseView
	{
		[NonSerialized]
		private SiegeWeaponComponent siegeWeaponComponent;

		[SerializeField]
		private GameObject projectilePrefab;

		[SerializeField]
		private GameObject projectileParent;

		[SerializeField]
		private GameObject firePosition;

		[SerializeField]
		private GameObject targetArea;

		[Space]
		[SerializeField]
		private GameObject minRangeTopXYZ;

		[SerializeField]
		private GameObject minRangeBottomXZ;

		[Space]
		[SerializeField]
		private GameObject maxRangeTopXYZ;

		[SerializeField]
		private GameObject maxRangeBottomXZ;

		[Space]
		[SerializeField]
		private GameObject minRangePrefab;

		[SerializeField]
		private GameObject maxRangePrefab;

		[Space]
		[SerializeField]
		private Transform minRangeParent;

		[SerializeField]
		private Transform maxRangeParent;

		[Space]
		[SerializeField]
		private List<GameObject> maxRanges;

		[SerializeField]
		private List<GameObject> minRanges;

		[SerializeField]
		private Animator animator;

		[SerializeField]
		private GameObject rotatingPart;

		[SerializeField]
		private LineRenderer trajectoryLineRenderer;

		private AudioEventsComponent audioEventsComponent;

		private Dictionary<SiegeWeaponProjectileBlueprint, List<BezierProjectileTrajectory>> trajectoryDictionary = new Dictionary<SiegeWeaponProjectileBlueprint, List<BezierProjectileTrajectory>>();

		private Dictionary<SiegeWeaponProjectileBlueprint, List<GameObject>> projectilesDictionary = new Dictionary<SiegeWeaponProjectileBlueprint, List<GameObject>>();

		private Dictionary<Vec3Int, GameObject> collisionsCache = new Dictionary<Vec3Int, GameObject>();

		private SiegeWeaponComponentInstance ComponentInstance => siegeWeaponComponent?.ComponentInstance;

		private float AttackAnimationSpeed
		{
			get
			{
				if (ComponentInstance == null || ComponentInstance.Blueprint == null || ComponentInstance.Blueprint.AttackAnimationSpeed <= 0f)
				{
					return 1f;
				}
				return Mathf.Clamp(ComponentInstance.Blueprint.AttackAnimationSpeed, 0.2f, 15f);
			}
		}

		public void StartCameraShake()
		{
			switch (siegeWeaponComponent.ComponentInstance.Blueprint.SiegeWeaponType)
			{
			case SiegeWeaponType.Trebuchet:
				MonoSingleton<CameraManager>.Instance.OnCameraShakeEvent(base.transform.position, CameraShakeStrength.Mild);
				break;
			case SiegeWeaponType.Onager:
				MonoSingleton<CameraManager>.Instance.OnCameraShakeEvent(base.transform.position, CameraShakeStrength.Mild);
				break;
			case SiegeWeaponType.Ballista:
				MonoSingleton<CameraManager>.Instance.OnCameraShakeEvent(base.transform.position, CameraShakeStrength.Weak);
				break;
			}
		}

		public override void PreSpawnInitialization()
		{
			base.PreSpawnInitialization();
			siegeWeaponComponent = GetComponent<SiegeWeaponComponent>();
			audioEventsComponent = GetComponent<AudioEventsComponent>();
			animator = GetComponent<Animator>();
			animator.ResetTriggers();
			trajectoryLineRenderer.gameObject.SetActive(value: false);
			targetArea.SetActive(value: false);
			SetActiveMinMaxRange(active: false);
		}

		protected override void OnComponentEnterFinishedState(bool afterLoading = false)
		{
			base.OnComponentEnterFinishedState(afterLoading);
			MonoSingleton<SceneController>.Instance.UnscaledTick += OnUnscaledTick;
			ComponentInstance.TargetSetEvent += OnTargetSet;
			ComponentInstance.StartAttackEvent += OnStartAttack;
			ComponentInstance.HideTrajectoryEvent += OnHideTrajectory;
			ComponentInstance.UpdateCrosshairEvent += OnUpdateCrosshair;
			ComponentInstance.StartReloadingEvent += OnStartReloading;
			ComponentInstance.ReloadFailedEvent += OnReloadFailed;
			ComponentInstance.RotateTowardsTargetEvent += OnFaceTarget;
			ComponentInstance.ShowRangeEvent += OnShowRange;
			ComponentInstance.SaveProjectileLaunchPosition(firePosition.transform.position);
			BaseBuildingViewComponent.BuildingSelectedEvent += OnBuildingSelected;
			BaseBuildingViewComponent.BuildingDeselectedEvent += OnBuildingDeselected;
			siegeWeaponComponent.CancelOrderButtonClickEvent += OnCancelOrderButtonClick;
			siegeWeaponComponent.CancelContinuousAttackOrderButtonClickEvent += OnCancelContinuousAttackOrderButtonClick;
			if (!ComponentInstance.WeaponInAttackPosition)
			{
				animator.SetTrigger("construction_finished");
			}
			ClearMinMaxRanges();
			InitializeMinMaxRanges();
			ScaleMinMaxRange();
		}

		protected override void OnBuildingDisposed(IDisposable disposable)
		{
			base.OnBuildingDisposed(disposable);
			ClearCache();
		}

		protected override void OnEnterPool()
		{
			base.OnEnterPool();
			ClearCache();
		}

		private void ClearCache()
		{
			if (MonoSingleton<InputManager>.IsInstantiated())
			{
				MonoSingleton<InputManager>.Instance.GetListener(InputListenerType.Trebuchet).Disable();
			}
			if (MonoSingleton<SceneController>.IsInstantiated())
			{
				MonoSingleton<SceneController>.Instance.UnscaledTick -= OnUnscaledTick;
			}
			ClearMinMaxRanges();
			minRangeTopXYZ.SetActive(value: false);
			maxRangeTopXYZ.SetActive(value: false);
			minRangeBottomXZ.SetActive(value: false);
			maxRangeBottomXZ.SetActive(value: false);
		}

		private void ClearMinMaxRanges()
		{
			if (maxRanges != null)
			{
				foreach (GameObject maxRange in maxRanges)
				{
					UnityEngine.Object.Destroy(maxRange);
				}
			}
			if (minRanges != null)
			{
				foreach (GameObject minRange in minRanges)
				{
					UnityEngine.Object.Destroy(minRange);
				}
			}
			maxRanges?.Clear();
			maxRanges = null;
			minRanges?.Clear();
			minRanges = null;
		}

		private void OnUnscaledTick(float unscaledDeltaTime)
		{
			if (BaseBuildingViewComponent.Selected && MonoSingleton<ReservationManager>.Instance.IsReserved(ComponentInstance) && ComponentInstance.IsPlayerTargeting)
			{
				RefreshTrajectory(ComponentInstance.CrosshairPos);
			}
		}

		private void RefreshTrajectory(Vector3 position)
		{
			if (ComponentInstance == null || ComponentInstance.HasDisposed || ComponentInstance.OwnerBuilding == null || ComponentInstance.OwnerBuilding.HasDisposed)
			{
				return;
			}
			bool willDamageFinalPoint;
			List<Vector3> list = BezierProjectileTrajectory.CalculateTrajectoryPoints(ComponentInstance.Blueprint.SiegeWeaponType, firePosition.transform.position, position, out willDamageFinalPoint);
			list.Insert(0, trajectoryLineRenderer.transform.position);
			list.Add(position);
			trajectoryLineRenderer.SetPositions(list.ToArray());
			trajectoryLineRenderer.positionCount = list.Count;
			if (!trajectoryLineRenderer.gameObject.activeSelf)
			{
				trajectoryLineRenderer.gameObject.SetActive(value: true);
			}
			Vec3Int[] array = collisionsCache.Keys.ToArray();
			foreach (Vec3Int key in array)
			{
				GameObjectPool.Return(collisionsCache[key]);
				collisionsCache.Remove(key);
			}
			for (int j = 0; j < list.Count; j++)
			{
				if (Vector3.Distance(base.transform.position, list[j]) < 2f)
				{
					continue;
				}
				if (j > 0)
				{
					int num = 10;
					for (int k = 0; k <= num; k++)
					{
						float t = (float)k / (float)num;
						Vector3 vector = Vector3.Lerp(list[j], list[j - 1], t);
						if (ComponentInstance.Map.BuildingsManagerMain.CollidesWithProjectile(vector, ComponentInstance.OwnerBuilding))
						{
							Vec3Int key2 = vector.ToGridVec3Int();
							if (!collisionsCache.ContainsKey(key2))
							{
								GameObject gameObject = GameObjectPool.Get("SiegeWeaponProjectileCollisionIndicator");
								Vector3 position2 = new Vector3(key2.x, vector.y, key2.z);
								gameObject.transform.position = position2;
								collisionsCache.Add(key2, gameObject);
							}
						}
					}
				}
				if (j >= list.Count - 1)
				{
					continue;
				}
				int num2 = 10;
				for (int l = 0; l <= num2; l++)
				{
					float t2 = (float)l / (float)num2;
					Vector3 vector2 = Vector3.Lerp(list[j], list[j + 1], t2);
					if (ComponentInstance.Map.BuildingsManagerMain.CollidesWithProjectile(vector2, ComponentInstance.OwnerBuilding))
					{
						Vec3Int key3 = vector2.ToGridVec3Int();
						if (!collisionsCache.ContainsKey(key3))
						{
							GameObject gameObject2 = GameObjectPool.Get("SiegeWeaponProjectileCollisionIndicator");
							Vector3 position3 = new Vector3(key3.x, vector2.y, key3.z);
							gameObject2.transform.position = position3;
							collisionsCache.Add(key3, gameObject2);
						}
					}
				}
			}
		}

		private void ResetCollisionIndicators()
		{
			Vec3Int[] array = collisionsCache.Keys.ToArray();
			foreach (Vec3Int key in array)
			{
				UnityEngine.Object.Destroy(collisionsCache[key]);
				collisionsCache.Remove(key);
			}
		}

		private void ResetProjectilePosition()
		{
			foreach (List<GameObject> value in projectilesDictionary.Values)
			{
				foreach (GameObject item in value)
				{
					item.transform.parent = projectileParent.transform;
					item.transform.position = Vector3.zero;
				}
			}
		}

		private void SpawnProjectiles(SiegeWeaponProjectileBlueprint projectileBlueprint)
		{
			if (!projectilesDictionary.TryGetValue(projectileBlueprint, out var value))
			{
				projectilesDictionary.Add(projectileBlueprint, new List<GameObject>());
				for (int i = 0; i < projectileBlueprint.ProjectileAmount; i++)
				{
					GameObject gameObject = GetBullet();
					gameObject.transform.parent = projectileParent.transform;
					gameObject.transform.position = Vector3.zero;
					BezierProjectileTrajectory component = gameObject.GetComponent<BezierProjectileTrajectory>();
					component.DestinationReachedEvent += OnDestinationReached;
					projectilesDictionary[projectileBlueprint].Add(gameObject);
					if (!trajectoryDictionary.ContainsKey(projectileBlueprint))
					{
						trajectoryDictionary.Add(projectileBlueprint, new List<BezierProjectileTrajectory>());
					}
					trajectoryDictionary[projectileBlueprint].Add(component);
				}
				return;
			}
			for (int j = 0; j < projectileBlueprint.ProjectileAmount; j++)
			{
				if (value.Count <= j)
				{
					GameObject gameObject2 = GetBullet();
					gameObject2.transform.parent = projectileParent.transform;
					gameObject2.transform.position = Vector3.zero;
					value.Add(gameObject2);
					BezierProjectileTrajectory component2 = gameObject2.GetComponent<BezierProjectileTrajectory>();
					component2.DestinationReachedEvent += OnDestinationReached;
					projectilesDictionary[projectileBlueprint].Add(gameObject2);
					if (!trajectoryDictionary.ContainsKey(projectileBlueprint))
					{
						trajectoryDictionary.Add(projectileBlueprint, new List<BezierProjectileTrajectory>());
					}
					trajectoryDictionary[projectileBlueprint].Add(component2);
				}
			}
			GameObject GetBullet()
			{
				GameObject byAddress = MonoRepository<PrefabRepository, KeyGameObjectPair>.Instance.GetByAddress(projectileBlueprint.PrefabId);
				return UnityEngine.Object.Instantiate((byAddress != null) ? byAddress : projectilePrefab, projectileParent.transform);
			}
		}

		private void InitializeMinMaxRanges()
		{
			if (maxRanges == null)
			{
				maxRanges = new List<GameObject>();
			}
			if (minRanges == null)
			{
				minRanges = new List<GameObject>();
			}
			int count = ComponentInstance.Blueprint.RangePerLayer.Dictionary.Count;
			for (int i = 0; i < count - 1; i++)
			{
				GameObject gameObject = UnityEngine.Object.Instantiate(maxRangePrefab, maxRangeParent);
				gameObject.transform.localScale = Vector3.one;
				gameObject.transform.localPosition = new Vector3(maxRangeParent.localPosition.x, maxRangeParent.localPosition.y - (float)(World.MapBlockHeight * (i + 1)), maxRangeParent.localPosition.z);
				maxRanges.Add(gameObject);
				gameObject.SetActive(value: false);
				gameObject.name = ((i < 10) ? $"Max_range_middle_0{i}" : $"Max_range_middle_{i}");
				GameObject gameObject2 = UnityEngine.Object.Instantiate(minRangePrefab, minRangeParent);
				gameObject2.transform.localScale = Vector3.one;
				gameObject2.transform.localPosition = new Vector3(minRangeParent.localPosition.x, minRangeParent.localPosition.y - (float)(World.MapBlockHeight * (i + 1)), minRangeParent.localPosition.z);
				minRanges.Add(gameObject2);
				gameObject2.SetActive(value: false);
				gameObject2.name = ((i < 10) ? $"Min_range_middle_0{i}" : $"Min_range_middle_{i}");
			}
			maxRangeBottomXZ.SetActive(value: false);
			maxRangeBottomXZ.transform.localPosition = new Vector3(maxRangeParent.localPosition.x, maxRangeParent.localPosition.y - (float)(World.MapBlockHeight * count), maxRangeParent.localPosition.z);
			minRangeBottomXZ.SetActive(value: false);
			minRangeBottomXZ.transform.localPosition = new Vector3(minRangeParent.localPosition.x, minRangeParent.localPosition.y - (float)(World.MapBlockHeight * count), minRangeParent.localPosition.z);
		}

		private void HideProjectiles()
		{
			foreach (List<GameObject> value in projectilesDictionary.Values)
			{
				foreach (GameObject item in value)
				{
					item.SetActive(value: false);
				}
			}
		}

		private void ShowProjectiles(SiegeWeaponProjectileBlueprint projectileBlueprint)
		{
			if (projectilesDictionary.TryGetValue(projectileBlueprint, out var value))
			{
				for (int i = 0; i < projectileBlueprint.ProjectileAmount; i++)
				{
					value[i].SetActive(value: true);
				}
			}
		}

		private void OnHideTrajectory()
		{
			HideTrajectory();
		}

		private void OnTargetSet()
		{
			ShowTargetArea();
		}

		private void OnStartAttack(SiegeWeaponProjectileBlueprint projectileBlueprint)
		{
			animator.SetTrigger("attack");
			animator.speed = AttackAnimationSpeed;
			ComponentInstance.WeaponInAttackPosition = false;
			if (!ComponentInstance.ContinuousAttack)
			{
				SetActiveMinMaxRange(active: false);
			}
		}

		private void OnStartReloading(float reloadSpeed)
		{
			animator.SetTrigger("reload");
			animator.speed = reloadSpeed;
		}

		private void OnReloadFailed()
		{
			animator.SetTrigger("abort_reload");
			animator.speed = 1f;
			audioEventsComponent.StopAllInstances();
		}

		private void OnFaceTarget()
		{
			FaceTarget();
		}

		private void FaceTarget()
		{
			Vector3 position = base.transform.position;
			Vector3 vector = new Vector3(ComponentInstance.Target.x, position.y, ComponentInstance.Target.z) - position;
			if (vector != Vector3.zero)
			{
				Quaternion rotation = Quaternion.LookRotation(vector, Vector3.up);
				rotatingPart.transform.rotation = rotation;
				rotatingPart.transform.rotation.Set(0f, rotation.y, 0f, rotation.w);
			}
		}

		private void OnUpdateCrosshair(Vector3 position)
		{
			if (!(targetArea == null))
			{
				targetArea.SetActive(value: true);
				targetArea.transform.localScale = Vector3.one * (ComponentInstance.Blueprint.TargetRandomRadius * 2f);
				targetArea.transform.position = position;
			}
		}

		private void OnDestinationReached(Vector3 target)
		{
			HideTargetArea();
		}

		private void ShowTargetArea()
		{
			if (!(targetArea == null))
			{
				if (ComponentInstance == null || ComponentInstance.Blueprint == null || ComponentInstance.HasDisposed || ComponentInstance.OwnerBuilding == null || ComponentInstance.OwnerBuilding.HasDisposed || !ComponentInstance.OwnerBuilding.OwnedByPlayer())
				{
					targetArea.SetActive(value: false);
					return;
				}
				targetArea.SetActive(value: true);
				targetArea.transform.localScale = Vector3.one * (ComponentInstance.Blueprint.TargetRandomRadius * 2f);
				targetArea.transform.position = ComponentInstance.Target;
			}
		}

		private void HideTargetArea()
		{
			if (!(targetArea == null) && ComponentInstance != null && !ComponentInstance.HasDisposed && (!BaseBuildingViewComponent.Selected || !ComponentInstance.ContinuousAttack))
			{
				targetArea.SetActive(value: false);
			}
		}

		private void GoapAnimationEvent(string eventName)
		{
			if (ComponentInstance == null || ComponentInstance.HasDisposed || ComponentInstance.OwnerBuilding == null || ComponentInstance.OwnerBuilding.HasDisposed || ComponentInstance.OwnerBuilding.ConstructionPhase != ConstructionPhase.Finished)
			{
				return;
			}
			SiegeWeaponComponentBlueprint blueprint = ComponentInstance.Blueprint;
			if (eventName.Equals("reload_end"))
			{
				ComponentInstance.ReloadSuccessRefactored();
				animator.SetTrigger("reload_success");
				audioEventsComponent.KeyOffEventInstance(blueprint.WindUpAudioEvent);
			}
			else if (eventName.Equals("reload_start"))
			{
				audioEventsComponent.PlayEventInstance(blueprint.WindUpAudioEvent);
			}
			else if (eventName.Equals("attack_end"))
			{
				ComponentInstance.AttackInProgress = false;
				animator.SetTrigger("attack_success");
			}
			else
			{
				if (!eventName.Equals("fire"))
				{
					return;
				}
				bool isEnabled;
				FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(5, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Constructables\\Building Components\\SiegeWeapons\\SiegeWeaponViewComponent.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Fire ");
					messageBuilder.AppendFormatted(blueprint.ReleaseAudioEvent);
				}
				Log.Trace(messageBuilder);
				audioEventsComponent.PlayEvent(blueprint.ReleaseAudioEvent);
				ComponentInstance.AttackInProgress = true;
				SiegeWeaponProjectileBlueprint bulletBlueprint = ComponentInstance.BulletBlueprint;
				if (bulletBlueprint != null)
				{
					ResetProjectilePosition();
					SpawnProjectiles(bulletBlueprint);
					HideProjectiles();
					ShowProjectiles(bulletBlueprint);
					float num = ComponentInstance.Blueprint.ProjectileSpeed;
					if (projectilesDictionary.TryGetValue(bulletBlueprint, out var value))
					{
						for (int i = 0; i < bulletBlueprint.ProjectileAmount; i++)
						{
							Vector3 randomizedPosition = ComponentInstance.GetRandomizedPosition(ComponentInstance.Target);
							if (bulletBlueprint.ProjectileAmount > 1)
							{
								num += UnityEngine.Random.Range(0f, 1.5f);
							}
							if (trajectoryDictionary.TryGetValue(bulletBlueprint, out var value2))
							{
								value2[i].Setup(ComponentInstance.Blueprint.SiegeWeaponType, firePosition.transform.position, randomizedPosition, num, bulletBlueprint);
								TrailRenderer[] componentsInChildren = value[i].GetComponentsInChildren<TrailRenderer>();
								for (int j = 0; j < componentsInChildren.Length; j++)
								{
									componentsInChildren[j].Clear();
								}
								new SiegeWeaponProjectileInstance(bulletBlueprint, ComponentInstance, value2[i]);
								continue;
							}
							return;
						}
					}
					if (!ComponentInstance.ContinuousAttack)
					{
						ComponentInstance.ResetTarget();
					}
				}
				else
				{
					Log.Error("No ammo found but siege weapon animation was triggered (using 'fire' trigger').", "C:\\GIT\\dev\\Assets\\Scripts\\Constructables\\Building Components\\SiegeWeapons\\SiegeWeaponViewComponent.cs");
				}
			}
		}

		private void HideTrajectory()
		{
			ResetCollisionIndicators();
			if (trajectoryLineRenderer.gameObject.activeSelf)
			{
				siegeWeaponComponent.SetHasInfoChanged(hasInfoChanged: true);
				trajectoryLineRenderer.gameObject.SetActive(value: false);
			}
		}

		private void OnShowRange(bool visible)
		{
			SetActiveMinMaxRange(visible);
		}

		private void SetActiveMinMaxRange(bool active)
		{
			if (ComponentInstance == null || ComponentInstance.Blueprint == null || ComponentInstance.HasDisposed || ComponentInstance.OwnerBuilding == null || ComponentInstance.OwnerBuilding.HasDisposed || !ComponentInstance.OwnerBuilding.OwnedByPlayer())
			{
				return;
			}
			minRangeTopXYZ.SetActive(active);
			maxRangeTopXYZ.SetActive(active);
			minRangeBottomXZ.SetActive(active);
			maxRangeBottomXZ.SetActive(active);
			if (minRanges != null)
			{
				foreach (GameObject minRange in minRanges)
				{
					minRange.SetActive(active);
				}
			}
			if (maxRanges == null)
			{
				return;
			}
			foreach (GameObject maxRange in maxRanges)
			{
				maxRange.SetActive(active);
			}
		}

		private void ScaleMinMaxRange()
		{
			maxRangeTopXYZ.transform.localScale = Vector3.one * (ComponentInstance.Blueprint.MaxRangeRadius * 2f);
			maxRangeBottomXZ.transform.localScale = new Vector3(ComponentInstance.MaxRangeMultipliersPerLayer.Last() * 2f, maxRangeBottomXZ.transform.localScale.y, ComponentInstance.MaxRangeMultipliersPerLayer.Last() * 2f);
			for (int i = 0; i < maxRanges.Count; i++)
			{
				maxRanges[i].transform.localScale = new Vector3(ComponentInstance.MaxRangeMultipliersPerLayer[i] * 2f, maxRanges[i].transform.localScale.y, ComponentInstance.MaxRangeMultipliersPerLayer[i] * 2f);
			}
			minRangeTopXYZ.transform.localScale = Vector3.one * (ComponentInstance.Blueprint.MinRangeRadius * 2f);
			minRangeBottomXZ.transform.localScale = new Vector3(ComponentInstance.MinRangeMultipliersPerLayer.Last() * 2f, minRangeBottomXZ.transform.localScale.y, ComponentInstance.MinRangeMultipliersPerLayer.Last() * 2f);
			for (int j = 0; j < minRanges.Count; j++)
			{
				minRanges[j].transform.localScale = new Vector3(ComponentInstance.MinRangeMultipliersPerLayer[j] * 2f, minRanges[j].transform.localScale.y, ComponentInstance.MinRangeMultipliersPerLayer[j] * 2f);
			}
		}

		private void OnBuildingSelected()
		{
			if (ComponentInstance != null && !ComponentInstance.HasDisposed && ComponentInstance.OwnerBuilding != null && !ComponentInstance.OwnerBuilding.HasDisposed && ComponentInstance.OwnerBuilding.OwnedByPlayer() && ComponentInstance.ContinuousAttack)
			{
				RefreshTrajectory(ComponentInstance.Target);
				ShowTargetArea();
			}
		}

		private void OnBuildingDeselected()
		{
			HideTrajectory();
			HideTargetArea();
			SetActiveMinMaxRange(active: false);
		}

		private void OnCancelOrderButtonClick()
		{
			HideTrajectory();
			HideTargetArea();
		}

		private void OnCancelContinuousAttackOrderButtonClick()
		{
			HideTrajectory();
			HideTargetArea();
		}
	}
}
