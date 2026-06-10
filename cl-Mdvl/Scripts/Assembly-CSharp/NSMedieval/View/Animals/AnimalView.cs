using System;
using System.Collections;
using System.Collections.Generic;
using Effects;
using FIMSpace.FSpine;
using FIMSpace.FTail;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using Managers.Selection.EventData;
using NSEipix;
using NSEipix.Base;
using NSEipix.Model;
using NSEipix.Repository;
using NSMedieval.BuildingComponents;
using NSMedieval.Controllers;
using NSMedieval.Enums;
using NSMedieval.FloatingOverlaySystem;
using NSMedieval.Goap;
using NSMedieval.Manager;
using NSMedieval.Managers.Selection;
using NSMedieval.Map;
using NSMedieval.Model;
using NSMedieval.Repository;
using NSMedieval.Scripts.Pooler;
using NSMedieval.State;
using NSMedieval.StatsSystem;
using NSMedieval.Tutorial;
using NSMedieval.Types;
using NSMedieval.UI;
using NSMedieval.UI.Utils;
using NSMedieval.Village;
using UnityEngine;

namespace NSMedieval.View.Animals
{
	public class AnimalView : AnimatedAgentView, IAdditionalMenuOwner, IGameDisposable, IDisposable, IAgentView
	{
		private static readonly int XRayColor = Shader.PropertyToID("_xRay_color");

		private const float WildColor = 1f;

		private const float WildAggressiveColor = 2f;

		private const float DomesticPetColor = 3f;

		[NonSerialized]
		private AnimalInstance animalInstance;

		[SerializeField]
		private GameObject huntMarker;

		[SerializeField]
		private GameObject tameMarker;

		[SerializeField]
		private GameObject slaughterMarker;

		[SerializeField]
		private GameObject trainMarker;

		[SerializeField]
		private GameObject releaseMarker;

		[SerializeField]
		private GameObject bleedingParticle;

		[SerializeField]
		private GameObject gameplayOverlayHook;

		[SerializeField]
		private GameObject saddlebags;

		[SerializeField]
		private Transform heartsParticle;

		[SerializeField]
		private List<Transform> harvestPositions;

		[SerializeField]
		private Transform frontHarvestPosition;

		[SerializeField]
		private GameObject ropeHookBone;

		[SerializeField]
		private Transform mouthBone;

		[SerializeField]
		private Transform milkingBucketPoint;

		private FSpineAnimator spineAnimator;

		private TailAnimator2 tailAnimator;

		private Transform cachedTransform;

		private GameObject eatP;

		private GameObject shearP;

		private GameObject milkBucket;

		private TextFloatingElement animalNameElement;

		private float currentScale;

		private float nextScale;

		public override bool Visible => true;

		public AnimalInstance AnimalInstance => animalInstance;

		public GameObject RopeHookBone => ropeHookBone;

		public Transform FrontHarvestPosition => frontHarvestPosition;

		public List<Transform> HarvestPositions => harvestPositions;

		public bool HasDisposed { get; protected set; }

		public event Action<IGameDisposable> OnDisposedEvent;

		public override WorldObject GetAsWorldObject()
		{
			return null;
		}

		public override CreatureBase GetAsCreature()
		{
			return animalInstance;
		}

		public string GetAdditionalMenuId()
		{
			return GetGoapAgentId();
		}

		public IGoapTargetable GetAsTarget()
		{
			return animalInstance;
		}

		public void Dispose()
		{
			Dispose(disposeInstance: true);
			this.OnDisposedEvent = null;
			animalInstance = null;
		}

		public void Dispose(bool disposeInstance)
		{
			if (!HasDisposed)
			{
				if (animalInstance != null)
				{
					animalInstance.LifePhaseChangedEvent -= OnLifePhaseChanged;
					animalInstance.AnimalTypeChangedEvent -= OnAnimalTypeChanged;
				}
				if (MonoSingleton<SelectionManager>.IsInstantiated())
				{
					MonoSingleton<SelectionManager>.Instance.OrderResourceCollectionEvent -= OnOrderResourceCollectionEvent;
					MonoSingleton<SelectionManager>.Instance.SelectionHighlightEvent -= OnSelectionHighlight;
				}
				DestroyAnimatedAgent();
				if (disposeInstance)
				{
					animalInstance?.Dispose();
				}
				cachedTransform = null;
				UnityEngine.Object.Destroy(base.gameObject);
				HasDisposed = true;
				if (!LoadingController.IsLeavingMainScene)
				{
					this.OnDisposedEvent?.Invoke(this);
				}
				this.OnDisposedEvent = null;
			}
		}

		public override Transform GetGuiOverlayHookTransform()
		{
			if (gameplayOverlayHook == null)
			{
				return base.transform;
			}
			return gameplayOverlayHook.transform;
		}

		public bool ShouldMenuFollowHookTransform()
		{
			return false;
		}

		public void Setup(AnimalInstance instance)
		{
			animalInstance = instance;
			animalInstance.LifePhaseChangedEvent += OnLifePhaseChanged;
			animalInstance.AnimalTypeChangedEvent += OnAnimalTypeChanged;
			animalInstance.AnimalNameChangeEvent += OnAnimalNameChange;
			MonoSingleton<SelectionManager>.Instance.OrderResourceCollectionEvent += OnOrderResourceCollectionEvent;
			MonoSingleton<SelectionManager>.Instance.SelectionHighlightEvent += OnSelectionHighlight;
			MonoSingleton<OptionsController>.Instance.ToggleAnimalNames += OnAnimalNameChange;
			SetScaleValuesForLifePhase(animalInstance);
			SetScale();
			SetupGoapView();
			GenerateAnimalNameGuiOverlayElements();
			OnMarkForOrder(instance.OrderType);
			SetMaterialBasedOnType(instance.AnimalType);
		}

		protected override bool IsSelectionNull()
		{
			if (animalInstance != null)
			{
				return animalInstance.HasDisposed;
			}
			return true;
		}

		protected override void OnDestroy()
		{
			if (animalInstance != null)
			{
				animalInstance.LifePhaseChangedEvent -= OnLifePhaseChanged;
				animalInstance.AnimalTypeChangedEvent -= OnAnimalTypeChanged;
				animalInstance.AnimalNameChangeEvent -= OnAnimalNameChange;
				animalInstance = null;
			}
			if (MonoSingleton<SelectionManager>.IsInstantiated())
			{
				MonoSingleton<SelectionManager>.Instance.OrderResourceCollectionEvent -= OnOrderResourceCollectionEvent;
				MonoSingleton<SelectionManager>.Instance.SelectionHighlightEvent -= OnSelectionHighlight;
			}
			if (MonoSingleton<OptionsController>.IsInstantiated())
			{
				MonoSingleton<OptionsController>.Instance.ToggleAnimalNames -= OnAnimalNameChange;
			}
			base.OnDestroy();
		}

		public Transform GetClosestInteractTransform(IPathfindingAgent agent, Func<Vec3Int, bool> validator = null)
		{
			Transform result = null;
			float num = float.PositiveInfinity;
			foreach (Transform harvestPosition in harvestPositions)
			{
				Vector3 position = harvestPosition.position;
				if (validator == null || validator(GridUtils.GetGridPosition(position)))
				{
					float num2 = Vector3.Distance(position, agent.GetPosition());
					if (num2 < num)
					{
						num = num2;
						result = harvestPosition;
					}
				}
			}
			return result;
		}

		public void GoToSleep(BedComponentInstance bed = null)
		{
			if (bed != null)
			{
				Transform sleepTRS = bed.Map.BedComponentManager.GetComponent(bed).SleepTRS;
				Quaternion rotation = base.transform.rotation;
				StartCoroutine(RotateAndMove(new Vector3(rotation.x, sleepTRS.eulerAngles.y, rotation.z), sleepTRS.position));
			}
		}

		public override string GetMultiselectName()
		{
			if (animalInstance == null || animalInstance.Blueprint == null || animalInstance.HasDisposed)
			{
				return string.Empty;
			}
			return $"{animalInstance.Blueprint.GetID()}_{animalInstance.AnimalType}";
		}

		public override string GetSimpleName()
		{
			string text = MonoSingleton<LocalizationController>.Instance.GetText($"animal_type_{animalInstance.AnimalType}");
			string text2 = ((animalInstance.Gender == BodyType.Female) ? "female" : "male");
			string text3 = MonoSingleton<LocalizationController>.Instance.GetText("general_" + text2);
			return animalInstance.GetFullName() + "\n" + AnimalUtils.GetLocalizedName(animalInstance.Blueprint) + " (" + text3 + ") (" + text + ")";
		}

		public override InfoPanelData GetInfoPanelData()
		{
			if (HasDisposed || animalInstance == null)
			{
				return null;
			}
			InfoPanelHeader header = new InfoPanelHeader("Animal_" + animalInstance.Id + ".png", AnimalUtils.GetFullName(animalInstance), "animal");
			InfoPanelAnimalBody body = new InfoPanelAnimalBody(animalInstance, GetInfoStats(), GetInfos());
			InfoPanelFooter footer = new InfoPanelFooter(GetInfoPanelActions());
			return new InfoPanelData(header, body, footer);
		}

		public override InfoPanelData UpdateCallback()
		{
			return GetInfoPanelData();
		}

		public void SetScale()
		{
			float num = Mathf.Lerp(currentScale, nextScale, animalInstance.GetLifePhasePercent());
			base.gameObject.transform.localScale = Vector3.one * num;
		}

		public void OnStorageChange(SimpleResourceCount count)
		{
			if (!(saddlebags == null) && !animalInstance.HasDisposed)
			{
				saddlebags.SetActive(!animalInstance.Storage.IsEmpty());
			}
		}

		public void TameParticlesSuccess()
		{
			if (!(heartsParticle == null))
			{
				MonoSingleton<ParticleSystemPool>.Instance.PlayParticles("tame_hearts", heartsParticle);
			}
		}

		public override void EatParticles()
		{
			if (!(mouthBone == null))
			{
				if (eatP != null)
				{
					StopEatParticles();
				}
				eatP = MonoSingleton<ParticleSystemPool>.Instance.PlayParticles("eating", mouthBone, autoStop: false);
			}
		}

		public override void StopEatParticles()
		{
			if (!(eatP == null))
			{
				MonoSingleton<ParticleSystemPool>.Instance.ReturnToPool(eatP);
				eatP = null;
			}
		}

		public void TrainParticles()
		{
			if (!(heartsParticle == null))
			{
				MonoSingleton<ParticleSystemPool>.Instance.PlayParticles("trainsuccess", heartsParticle);
			}
		}

		public void ShearParticles()
		{
			if (!(heartsParticle == null))
			{
				if (shearP != null)
				{
					StopShearParticles();
				}
				shearP = MonoSingleton<ParticleSystemPool>.Instance.PlayParticles("shearing", heartsParticle, autoStop: false);
			}
		}

		public void StopShearParticles()
		{
			if (!(shearP == null))
			{
				MonoSingleton<ParticleSystemPool>.Instance.ReturnToPool(shearP);
				shearP = null;
			}
		}

		public void Milking()
		{
			if (!(milkingBucketPoint == null))
			{
				milkBucket = UnityEngine.Object.Instantiate(MonoRepository<PrefabRepository, NSMedieval.Model.KeyGameObjectPair>.Instance.GetByAddress("milk_bucket"), milkingBucketPoint);
				milkBucket.transform.localPosition = Vector3.zero;
			}
		}

		public void RemoveMilkBucket()
		{
			if (!(milkingBucketPoint == null))
			{
				UnityEngine.Object.Destroy(milkBucket);
			}
		}

		public void SetSpineTailAnimatorEnabled(bool state)
		{
			if ((object)spineAnimator != null && spineAnimator.enabled != state)
			{
				spineAnimator.enabled = state;
			}
			if ((object)tailAnimator != null && tailAnimator.enabled != state)
			{
				tailAnimator.enabled = state;
			}
		}

		protected override void OnPointerEnter(Vector3 pos)
		{
			if (MonoSingleton<SelectionManager>.Instance.OrderType == OrderType.None)
			{
				base.OnPointerEnter(pos);
			}
		}

		internal override void Select()
		{
			if (MonoSingleton<KeybindingManager>.Instance.IsKeybindingKeyDown(KeyInputEvent.LeftControl))
			{
				ClickedJumpToUpperLayer();
			}
			else
			{
				base.Select();
			}
		}

		internal override void Deselect(bool isSilent = false)
		{
			base.Deselect(isSilent);
			if (MonoSingleton<GoapController>.IsInstantiated())
			{
				MonoSingleton<GoapController>.Instance.AgentSelected(selected: false, GetAgent());
			}
		}

		protected override string GetAnimatedAgentDataId()
		{
			return animalInstance.Id;
		}

		protected override StatsInstance GetAgentStats()
		{
			return animalInstance.Stats;
		}

		protected override string GetGoapAgentId()
		{
			return animalInstance.GetGoapAgentID();
		}

		protected override void Awake()
		{
			base.Awake();
			spineAnimator = GetComponent<FSpineAnimator>();
			tailAnimator = GetComponent<TailAnimator2>();
			cachedTransform = base.transform;
		}

		private void LateUpdate()
		{
			using (ProfilerSampleJanitor.Begin("AnimalView Spine Animator Frustum Culling"))
			{
				if (MonoSingleton<AnimalManager>.Instance.FrustumCullingVisibleCounter <= 20)
				{
					Camera gameplayCamera = MonoSingleton<CameraManager>.Instance.GameplayCamera;
					Vector3 position = cachedTransform.position;
					Vector3 vector = gameplayCamera.WorldToViewportPoint(position);
					bool flag = vector.z > 0f && vector.x > 0f && vector.x < 1f && vector.y > 0f && vector.y < 1f;
					SetSpineTailAnimatorEnabled(flag);
					if (flag)
					{
						MonoSingleton<AnimalManager>.Instance.FrustumCullingVisibleCounter++;
					}
				}
			}
		}

		private IEnumerator RotateAndMove(Vector3 angles, Vector3 position)
		{
			yield return new WaitForEndOfFrame();
			Transform obj = base.transform;
			obj.eulerAngles = angles;
			obj.position = position;
			AnimalInstance.UpdatePosition(position);
		}

		private void OnLifePhaseChanged(AnimalInstance animalInstance, AnimalLifePhase previousLifePhase)
		{
			SetScaleValuesForLifePhase(animalInstance);
			SetScale();
			bool isEnabled;
			FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(33, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\View\\Animals\\AnimalView.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Animal (");
				messageBuilder.AppendFormatted(animalInstance.Blueprint.GetID());
				messageBuilder.AppendLiteral("): life phase changed to ");
				messageBuilder.AppendFormatted(animalInstance.LifePhase.PhaseName);
			}
			Log.Info(messageBuilder);
		}

		private void OnAnimalTypeChanged(AnimalInstance animalInstance, AnimalType animalType)
		{
			OnAnimalNameChange();
			SetMaterialBasedOnType(animalType);
		}

		private void SetMaterialBasedOnType(AnimalType animalType)
		{
			float num;
			switch (animalType)
			{
			case AnimalType.Domestic:
			case AnimalType.DomesticNpc:
			case AnimalType.Pet:
				num = 3f;
				break;
			case AnimalType.Wild:
				num = 1f;
				break;
			case AnimalType.WildAggressive:
				num = 2f;
				break;
			default:
				throw new ArgumentOutOfRangeException("animalType", animalType, null);
			}
			float value = num;
			Renderer[] componentsInChildren = base.transform.GetComponentsInChildren<Renderer>();
			foreach (Renderer renderer in componentsInChildren)
			{
				MaterialPropertyBlock materialPropertyBlock = MonoSingleton<MaterialPropertyBlockManager>.Instance.GetMaterialPropertyBlock(renderer);
				materialPropertyBlock.SetFloat(XRayColor, value);
				renderer.SetPropertyBlock(materialPropertyBlock);
			}
		}

		private List<string> GetInfos()
		{
			List<string> list = new List<string>();
			list.AddIfNotNullOrEmpty("<style=Desc>" + CreatureBaseUtils.GetLocalizedCurrentActionInfo(animalInstance) + "</style>");
			return list;
		}

		private List<InfoPanelAction> GetInfoPanelActions()
		{
			List<InfoPanelAction> list = new List<InfoPanelAction>();
			if (TutorialManager.IsTutorialActive && !MonoSingleton<TutorialManager>.Instance.AllowCreatureCommands)
			{
				return list;
			}
			if (animalInstance.AnimalType == AnimalType.Wild)
			{
				int currentIndex = ((animalInstance.OrderType == AnimalOrderType.Hunt) ? 1 : 0);
				KeyValuePair<SelectionInputActionData, Action>[] objectActions = new KeyValuePair<SelectionInputActionData, Action>[2]
				{
					new KeyValuePair<SelectionInputActionData, Action>(Repository<ObjectActionDataRepository, SelectionInputActionData>.Instance.GetByID("Hunting"), delegate
					{
						OnOrder(OrderType.Hunting);
					}),
					new KeyValuePair<SelectionInputActionData, Action>(Repository<ObjectActionDataRepository, SelectionInputActionData>.Instance.GetByID("Cancel"), delegate
					{
						OnOrder(OrderType.Cancel);
					})
				};
				list.Add(new InfoPanelAction(objectActions, currentIndex));
				if (animalInstance.Blueprint.CanBeTamed)
				{
					int currentIndex2 = ((animalInstance.OrderType == AnimalOrderType.Tame) ? 1 : 0);
					KeyValuePair<SelectionInputActionData, Action>[] objectActions2 = new KeyValuePair<SelectionInputActionData, Action>[2]
					{
						new KeyValuePair<SelectionInputActionData, Action>(Repository<ObjectActionDataRepository, SelectionInputActionData>.Instance.GetByID("TameAnimal"), delegate
						{
							OnOrder(OrderType.TameAnimal);
						}),
						new KeyValuePair<SelectionInputActionData, Action>(Repository<ObjectActionDataRepository, SelectionInputActionData>.Instance.GetByID("Cancel"), delegate
						{
							OnOrder(OrderType.Cancel);
						})
					};
					list.Add(new InfoPanelAction(objectActions2, currentIndex2));
				}
				return list;
			}
			if (animalInstance.AnimalType == AnimalType.Domestic)
			{
				int currentIndex3 = ((animalInstance.OrderType == AnimalOrderType.Train) ? 1 : 0);
				KeyValuePair<SelectionInputActionData, Action>[] objectActions3 = new KeyValuePair<SelectionInputActionData, Action>[2]
				{
					new KeyValuePair<SelectionInputActionData, Action>(Repository<ObjectActionDataRepository, SelectionInputActionData>.Instance.GetByID("TrainAnimal"), delegate
					{
						OnOrder(OrderType.TrainAnimal);
					}),
					new KeyValuePair<SelectionInputActionData, Action>(Repository<ObjectActionDataRepository, SelectionInputActionData>.Instance.GetByID("Cancel"), delegate
					{
						OnOrder(OrderType.Cancel);
					})
				};
				list.Add(new InfoPanelAction(objectActions3, currentIndex3));
			}
			if (animalInstance.AnimalType == AnimalType.Domestic || animalInstance.AnimalType == AnimalType.Pet)
			{
				int currentIndex4 = ((animalInstance.OrderType == AnimalOrderType.Slaughter) ? 1 : 0);
				KeyValuePair<SelectionInputActionData, Action>[] objectActions4 = new KeyValuePair<SelectionInputActionData, Action>[2]
				{
					new KeyValuePair<SelectionInputActionData, Action>(Repository<ObjectActionDataRepository, SelectionInputActionData>.Instance.GetByID("SlaughterAnimal"), delegate
					{
						OnOrder(OrderType.SlaughterAnimal);
					}),
					new KeyValuePair<SelectionInputActionData, Action>(Repository<ObjectActionDataRepository, SelectionInputActionData>.Instance.GetByID("Cancel"), delegate
					{
						OnOrder(OrderType.Cancel);
					})
				};
				list.Add(new InfoPanelAction(objectActions4, currentIndex4));
				int currentIndex5 = ((animalInstance.OrderType == AnimalOrderType.Release) ? 1 : 0);
				KeyValuePair<SelectionInputActionData, Action>[] objectActions5 = new KeyValuePair<SelectionInputActionData, Action>[2]
				{
					new KeyValuePair<SelectionInputActionData, Action>(Repository<ObjectActionDataRepository, SelectionInputActionData>.Instance.GetByID("ReleaseAnimal"), delegate
					{
						OnOrder(OrderType.ReleaseAnimal);
					}),
					new KeyValuePair<SelectionInputActionData, Action>(Repository<ObjectActionDataRepository, SelectionInputActionData>.Instance.GetByID("Cancel"), delegate
					{
						OnOrder(OrderType.Cancel);
					})
				};
				list.Add(new InfoPanelAction(objectActions5, currentIndex5));
			}
			return list;
		}

		private List<InfoPanelStat> GetInfoStats()
		{
			if (HasDisposed || animalInstance == null || animalInstance.HasDisposed)
			{
				return new List<InfoPanelStat>();
			}
			StatInstance stat = animalInstance.Stats.GetStat(StatType.Health);
			StatInstance stat2 = animalInstance.Stats.GetStat(StatType.Hunger);
			if (stat == null && stat2 == null)
			{
				return new List<InfoPanelStat>();
			}
			List<InfoPanelStat> list = new List<InfoPanelStat>();
			if (stat != null)
			{
				list.Add(new InfoPanelStat("menu_hit_points", $"{Mathf.RoundToInt(stat.Current)}%", new IntRange(Mathf.RoundToInt(stat.Current), Mathf.RoundToInt(stat.Max)), StatType.Health));
			}
			if (stat2 != null)
			{
				list.Add(new InfoPanelStat("menu_hunger", $"{stat2.Current}%", new IntRange(Mathf.RoundToInt(stat2.Current), Mathf.RoundToInt(stat2.Max)), StatType.Hunger));
			}
			return list;
		}

		private void OnOrder(OrderType orderType)
		{
			switch (orderType)
			{
			case OrderType.Cancel:
				MonoSingleton<AnimalController>.Instance.MarkForOrder(AnimalOrderType.None, animalInstance);
				if (animalInstance.HasHarvestableProduction())
				{
					MonoSingleton<AnimalController>.Instance.MarkForOrder(AnimalOrderType.Harvest, animalInstance);
				}
				break;
			case OrderType.Hunting:
				MonoSingleton<AnimalController>.Instance.MarkForOrder(AnimalOrderType.Hunt, animalInstance);
				break;
			case OrderType.TameAnimal:
				MonoSingleton<AnimalController>.Instance.MarkForOrder(AnimalOrderType.Tame, animalInstance);
				break;
			case OrderType.SlaughterAnimal:
				MonoSingleton<AnimalController>.Instance.MarkForOrder(AnimalOrderType.Slaughter, animalInstance);
				if (animalInstance.HasHarvestableProduction())
				{
					MonoSingleton<AnimalController>.Instance.MarkForOrder(AnimalOrderType.Harvest, animalInstance);
				}
				break;
			case OrderType.TrainAnimal:
				MonoSingleton<AnimalController>.Instance.MarkForOrder(AnimalOrderType.Train, animalInstance);
				if (animalInstance.HasHarvestableProduction())
				{
					MonoSingleton<AnimalController>.Instance.MarkForOrder(AnimalOrderType.Harvest, animalInstance);
				}
				break;
			case OrderType.ReleaseAnimal:
				MonoSingleton<AnimalController>.Instance.MarkForOrder(AnimalOrderType.Release, animalInstance);
				break;
			}
			UpdateViewImmediate();
			MonoSingleton<AnimalController>.Instance.OrderGivenFromAnimalUI(animalInstance);
		}

		private void OnOrderResourceCollectionEvent(OrderEventData eventData)
		{
			if ((int)(base.transform.position.y / (float)World.MapBlockHeight) <= MonoSingleton<World>.Instance.ElevationLevel && SelectionManager.IsWithinSelectionBounds(base.transform.position, eventData.MinPoint.x, eventData.MaxPoint.x, eventData.MinPoint.y, eventData.MaxPoint.y, isTolerantSingleSelection: true) && (!eventData.AffectOnlyOneLayer || (int)base.transform.position.y == (int)eventData.Y))
			{
				if (eventData.OrderType.Equals(OrderType.Cancel))
				{
					MonoSingleton<AnimalController>.Instance.MarkForOrder(AnimalOrderType.None, animalInstance);
				}
				else if (animalInstance.AnimalType != AnimalType.DomesticNpc && animalInstance.AnimalType != AnimalType.Domestic && animalInstance.AnimalType != AnimalType.Pet && eventData.OrderType.Equals(OrderType.Hunting))
				{
					MonoSingleton<AnimalController>.Instance.MarkForOrder(AnimalOrderType.Hunt, animalInstance);
				}
			}
		}

		public void OnMarkForOrder(AnimalOrderType order)
		{
			if (animalInstance.OrderType != AnimalOrderType.Harvest || animalInstance.PreviousOrder == AnimalOrderType.None)
			{
				MonoSingleton<OrderMarkAnimationManager>.Instance.CancelOngoingAnimation(huntMarker);
				MonoSingleton<OrderMarkAnimationManager>.Instance.CancelOngoingAnimation(tameMarker);
				MonoSingleton<OrderMarkAnimationManager>.Instance.CancelOngoingAnimation(slaughterMarker);
				MonoSingleton<OrderMarkAnimationManager>.Instance.CancelOngoingAnimation(trainMarker);
				MonoSingleton<OrderMarkAnimationManager>.Instance.CancelOngoingAnimation(releaseMarker);
				GameObject gameObject = order switch
				{
					AnimalOrderType.Hunt => huntMarker, 
					AnimalOrderType.Tame => tameMarker, 
					AnimalOrderType.Slaughter => slaughterMarker, 
					AnimalOrderType.Train => trainMarker, 
					AnimalOrderType.Release => releaseMarker, 
					_ => null, 
				};
				if (gameObject != null)
				{
					MonoSingleton<OrderMarkAnimationManager>.Instance.AnimateOrderIcon(gameObject.GetComponent<AnimatedRenderMeshes>());
					return;
				}
				huntMarker.SetActive(value: false);
				tameMarker.SetActive(value: false);
				slaughterMarker.SetActive(value: false);
				trainMarker.SetActive(value: false);
				releaseMarker.SetActive(value: false);
			}
		}

		private void SetScaleValuesForLifePhase(AnimalInstance animalInstance)
		{
			if (animalInstance.HasLifePhases())
			{
				currentScale = animalInstance.LifePhase.ScaleStart;
				nextScale = animalInstance.LifePhase.ScaleEnd;
			}
			else
			{
				currentScale = 1f;
				nextScale = 1f;
			}
		}

		private void GenerateAnimalNameGuiOverlayElements()
		{
			if (!(animalNameElement != null))
			{
				animalNameElement = FloatingElementFactory.ProduceTextElement(OverlayTextElementType.AnimalName, FloatingElementHolderType.Default, GetGuiOverlayHookTransform());
				OnAnimalNameChange();
			}
		}

		private void OnAnimalNameChange()
		{
			if (!(animalNameElement == null))
			{
				bool active = false;
				switch ((AnimalNamesOption)MonoSingleton<GlobalSaveController>.Instance.GlobalSettings.ShowAnimalNameOption)
				{
				case AnimalNamesOption.All:
					active = true;
					break;
				case AnimalNamesOption.Pets:
					active = animalInstance.AnimalType == AnimalType.Pet;
					break;
				case AnimalNamesOption.Domestic:
					active = animalInstance.AnimalType == AnimalType.Domestic || animalInstance.AnimalType == AnimalType.Pet;
					break;
				}
				string text = (animalInstance.IsUnnamed ? AnimalUtils.GetLocalizedName(animalInstance.Blueprint) : animalInstance.GetFullName());
				animalNameElement.SetText(text);
				SetNameHolderActiveDelayed(animalNameElement.gameObject, active);
			}
		}

		private void SetNameHolderActiveDelayed(GameObject holder, bool active)
		{
			MonoSingleton<TaskController>.Instance.WaitForNextFrameUnscaled().Then(delegate
			{
				if (holder != null)
				{
					holder.gameObject.SetActive(active);
				}
			});
		}

		private void OnSelectionHighlight(OrderEventData eventData)
		{
			if (base.gameObject == null || base.transform == null)
			{
				if (MonoSingleton<SelectionManager>.IsInstantiated())
				{
					MonoSingleton<SelectionManager>.Instance.SelectionHighlightEvent -= OnSelectionHighlight;
				}
			}
			else
			{
				if ((int)(base.transform.position.y / (float)World.MapBlockHeight) > MonoSingleton<World>.Instance.ElevationLevel)
				{
					return;
				}
				if (!SelectionManager.IsWithinSelectionBounds(base.transform.position, eventData.MinPoint.x, eventData.MaxPoint.x, eventData.MinPoint.y, eventData.MaxPoint.y))
				{
					HideHighlight();
				}
				else
				{
					if ((eventData.AffectOnlyOneLayer && (int)base.transform.position.y != (int)eventData.Y) || (!eventData.OrderType.HasFlag(OrderType.Hunting) && !eventData.OrderType.HasFlag(OrderType.Cancel)))
					{
						return;
					}
					if (eventData.OrderType.Equals(OrderType.Cancel))
					{
						if (!animalInstance.OrderType.Equals(AnimalOrderType.None))
						{
							ShowHighlight();
						}
					}
					else
					{
						ShowHighlight();
					}
				}
			}
		}

		private void OnDrawGizmos()
		{
			if (animalInstance == null)
			{
				return;
			}
			bool flag = animalInstance.IsProtectorInProximity();
			bool flag2 = GlobalSaveController.CurrentVillageData.DateAndTime.MinutesTotal < animalInstance.PredatorCannotTargetUntil;
			Color color = Gizmos.color;
			if (flag || flag2)
			{
				if (flag2)
				{
					Gizmos.color = Color.cyan;
				}
				if (flag)
				{
					Gizmos.color = Color.blue;
				}
				Gizmos.DrawSphere(animalInstance.GetPosition(), 0.7f);
			}
			Gizmos.color = color;
		}
	}
}
