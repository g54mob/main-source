using DV.Common;
using DV.Interaction;
using DV.InventorySystem;
using DV.Items;
using DV.JObjectExtstensions;
using DV.Player;
using DV.Utils;
using DV.VRTK_Extensions;
using Newtonsoft.Json.Linq;
using UnityEngine;
using VRTK;

namespace DV.Customization.Gadgets
{
	[RequireComponent(typeof(ItemSaveData))]
	public class GadgetSolderingTool : GadgetInteractor, IItemUse, ItemPositionController.IPositionProvider
	{
		private const string KEY_REMAINING_UNITS = "AMMO";

		private const int SOLDERING_BONUS_UNITS = 6553;

		[SerializeField]
		private float solderingSpeed = 0.5f;

		[SerializeField]
		private Transform coil;

		[SerializeField]
		private Transform coilWire;

		[SerializeField]
		private Transform wireModel;

		[SerializeField]
		private ParticleSystem solderingEffect;

		[SerializeField]
		private float coilRevolutionsPerDose = 4f;

		[SerializeField]
		private float coilEmptySize = 0.25f;

		[SerializeField]
		private GameObject emptyCoilItemPrefab;

		[SerializeField]
		private GameObject reelInteractionPoint;

		[SerializeField]
		private LampControl indicatorLamp;

		[SerializeField]
		private Color colorInvalidTarget;

		[SerializeField]
		private Color colorMissingResource;

		[SerializeField]
		private Color colorReady;

		[SerializeField]
		private Color colorComplete;

		public AudioSource soundSoldering;

		public float soundSolderingFinalPitch = 0.9f;

		public AudioClip soundOnSpoolLoaded;

		public AudioClip soundOnSpoolUnloaded;

		public ItemWorkingAnimation itemWorkingAnimation;

		private ItemMagazine magazine;

		private int remainingUnits;

		private bool shouldParticlesBeOn;

		private GadgetBase solderingTarget;

		private GadgetBase vrHoveringTarget;

		private MagazineAmmo currentSpool;

		private bool ignoreMagazineDataChange;

		public bool CoilLoaded => remainingUnits != 0;

		public bool CoilFull => remainingUnits >= 65536;

		public bool HasSpool => remainingUnits != 0;

		public bool HasEjectableSpool
		{
			get
			{
				if (remainingUnits != 0)
				{
					return remainingUnits <= 6553;
				}
				return false;
			}
		}

		public bool HasNonEmptySpool => remainingUnits > 0;

		public override bool CallRegularUpdateWhenNull => true;

		public int Priority => 1;

		private void Awake()
		{
			magazine = GetComponent<ItemMagazine>();
			ItemSaveData component = GetComponent<ItemSaveData>();
			magazine.ItemContainerDataChanged += OnMagazineDataChanged;
			component.ItemSaveDataRequested += OnSaveDataRequested;
			component.AfterContainerSaveDataLoaded += OnAfterMagazineDataLoaded;
			SetParticles(on: false);
			if (VRManager.IsVREnabled())
			{
				reelInteractionPoint.AddComponent<ItemMagazineInteractionVr>().Initialize(magazine, reelInteractionPoint, DropEmptySpool, unloadSpentOnly: true);
				return;
			}
			itemWorkingAnimation.InputPressedCallback = () => base.IsPressed && GadgetInteractor.IsCameraInInteractionRange(solderingTarget.transform.position);
			itemWorkingAnimation.WorkDoneCallback = delegate
			{
				ProcessSoldering(solderingTarget);
				return !HasNonEmptySpool;
			};
			itemWorkingAnimation.AnimationStarted += delegate
			{
				SingletonBehaviour<ItemPositionController>.Instance.Add(this);
			};
			itemWorkingAnimation.AnimationStopped += delegate
			{
				SingletonBehaviour<ItemPositionController>.Instance.Remove(this);
				soundSoldering.Stop();
			};
		}

		private void OnMagazineDataChanged(AItemContainer container, int sourceIndex, int destinationIndex)
		{
			if (ignoreMagazineDataChange || sourceIndex != 0 || destinationIndex != -1)
			{
				return;
			}
			GameObject gameObject = container[0];
			currentSpool = ((gameObject != null) ? gameObject.GetComponent<MagazineAmmo>() : null);
			if (currentSpool == null)
			{
				remainingUnits = 0;
				if (soundOnSpoolUnloaded != null)
				{
					if (base.gameObject.activeInHierarchy)
					{
						soundOnSpoolUnloaded.Play(base.transform.position);
					}
					else
					{
						soundOnSpoolUnloaded.Play2D();
					}
				}
				OnUnitsChanged();
				return;
			}
			if (currentSpool.isSpent)
			{
				remainingUnits = -1;
				coil.gameObject.SetActive(value: true);
			}
			else
			{
				ReloadResource();
			}
			if (!(soundOnSpoolLoaded == null))
			{
				if (base.gameObject.activeInHierarchy)
				{
					soundOnSpoolLoaded.Play(base.transform.position);
				}
				else
				{
					soundOnSpoolLoaded.Play2D();
				}
			}
		}

		protected override void Start()
		{
			base.Start();
			OnUnitsChanged();
		}

		private void OnAfterMagazineDataLoaded(JObject data)
		{
			if (data != null)
			{
				remainingUnits = data.GetInt("AMMO") ?? 0;
				OnUnitsChanged();
			}
		}

		private JObject OnSaveDataRequested(JObject data)
		{
			data.SetInt("AMMO", remainingUnits);
			return data;
		}

		protected override HighlightMode OnUpdate(GadgetBase target, bool use)
		{
			shouldParticlesBeOn = itemWorkingAnimation.IsWorking;
			if (VRManager.IsVREnabled() && vrHoveringTarget != target)
			{
				vrHoveringTarget = target;
				HapticUtils.DoHapticPulse(VRTK_ControllerReference.GetControllerReference(GetComponent<VRTK_InteractableObject_DV>().GetGrabbingObject().GetComponent<VRTK_InteractGrab_DV>().gameObject), HapticIntensityType.Weak);
			}
			HighlightMode highlightMode = (itemWorkingAnimation.IsWorking ? HighlightMode.Good : ((target != null) ? OnUpdateRaw(target, use) : HighlightMode.None));
			Color emissionColor = default(Color);
			LampControl.LampState state = LampControl.LampState.On;
			switch (highlightMode)
			{
			case HighlightMode.Bad:
				emissionColor = colorInvalidTarget;
				state = LampControl.LampState.Blinking;
				break;
			case HighlightMode.Maybe:
				emissionColor = colorMissingResource;
				break;
			case HighlightMode.Good:
				emissionColor = colorReady;
				break;
			case HighlightMode.Done:
				emissionColor = colorComplete;
				break;
			case HighlightMode.None:
				state = LampControl.LampState.Off;
				break;
			}
			indicatorLamp.lampInd.emissionColor = emissionColor;
			indicatorLamp.SetLampState(state);
			if (shouldParticlesBeOn != solderingEffect.emission.enabled)
			{
				SetParticles(shouldParticlesBeOn);
			}
			if (!shouldParticlesBeOn && soundSoldering.isPlaying)
			{
				soundSoldering.Stop();
			}
			return HighlightMode.None;
		}

		private HighlightMode OnUpdateRaw(GadgetBase target, bool _)
		{
			if (!target.IsSolderable || !SingletonBehaviour<GadgetSystemUtility>.Instance.CheckSolderingAgainstRestrictions(target) || !GameFeatureFlags.IsAllowed(GameFeatureFlags.Flag.SolderingGadgets))
			{
				return HighlightMode.None;
			}
			if (!target.ArePlacementRequirementsMet)
			{
				GadgetInteractor.ShowInteractionText("interaction/requirements_unmet", localize: true, null);
				return HighlightMode.Bad;
			}
			if (target.IsSoldered && remainingUnits >= 65536)
			{
				return HighlightMode.Done;
			}
			base.HighlightFill = target.SolderingProgress;
			if (base.IsPressed && HasNonEmptySpool)
			{
				if (VRManager.IsVREnabled())
				{
					ProcessSoldering(target);
				}
				else if (!itemWorkingAnimation.IsAnimating)
				{
					solderingTarget = target;
					itemWorkingAnimation.StartAnimating();
				}
			}
			if (HasNonEmptySpool)
			{
				GadgetInteractor.ShowInteractionTextLMB("interaction/solder");
				if (!target.IsSoldered)
				{
					return HighlightMode.Good;
				}
				return HighlightMode.Done;
			}
			if (HasEjectableSpool)
			{
				GadgetInteractor.ShowInteractionTextLMB("interaction/eject_empty_solder");
				if (!target.IsSoldered)
				{
					return HighlightMode.Maybe;
				}
				return HighlightMode.Done;
			}
			GadgetInteractor.ShowInteractionTextLMB("interaction/missing_solder");
			if (!target.IsSoldered)
			{
				return HighlightMode.Maybe;
			}
			return HighlightMode.Done;
		}

		private void ProcessSoldering(GadgetBase target)
		{
			int num = (int)(65536f * solderingSpeed * Time.deltaTime);
			if (num > remainingUnits)
			{
				num = remainingUnits;
			}
			if (remainingUnits < 65536)
			{
				target.MakeSoldered(num);
			}
			else
			{
				num = target.MakeSoldered(num);
			}
			remainingUnits -= num;
			if (remainingUnits == 0)
			{
				remainingUnits = -1;
			}
			if (num != 0 && magazine[0] != null && currentSpool != null && !currentSpool.isSpent)
			{
				ignoreMagazineDataChange = true;
				GameObject item = magazine[0];
				magazine.RemoveItem(0, activateItem: true, dropItem: true);
				SingletonBehaviour<Inventory>.Instance.DestroyItem(item);
				if (emptyCoilItemPrefab != null)
				{
					GameObject gameObject = Object.Instantiate(emptyCoilItemPrefab, reelInteractionPoint.transform.position, reelInteractionPoint.transform.rotation);
					UpdateEmptySpoolItemParams(gameObject);
					magazine.AddItem(gameObject, 0);
				}
				ignoreMagazineDataChange = false;
			}
			OnUnitsChanged();
			shouldParticlesBeOn = true;
			soundSoldering.pitch = soundSolderingFinalPitch + (1f - soundSolderingFinalPitch) * Mathf.Sqrt(1f - target.SolderingProgress);
			if (!soundSoldering.isPlaying)
			{
				soundSoldering.PlayRandomTime();
			}
		}

		private void SetParticles(bool on)
		{
			ParticleSystem.EmissionModule emission = solderingEffect.emission;
			emission.enabled = on;
		}

		private void DropEmptySpool()
		{
			if (HasEjectableSpool)
			{
				remainingUnits = 0;
				soundOnSpoolUnloaded?.Play(base.transform.position);
				OnUnitsChanged();
				GameObject gameObject = magazine[0];
				if (gameObject != null)
				{
					ignoreMagazineDataChange = true;
					magazine.RemoveItem(0, activateItem: true, dropItem: true);
					ignoreMagazineDataChange = false;
					gameObject.transform.SetPositionAndRotation(reelInteractionPoint.transform.position, reelInteractionPoint.transform.rotation);
				}
			}
		}

		private void UpdateEmptySpoolItemParams(GameObject emptySpool)
		{
			RespawnOnDrop component = emptySpool.GetComponent<RespawnOnDrop>();
			if (component != null)
			{
				component.respawnOnDropThroughFloor = false;
				component.ignoreDistanceFromSpawnPosition = true;
			}
		}

		private void ReloadResource()
		{
			remainingUnits = 72089;
			OnUnitsChanged();
		}

		private void OnUnitsChanged()
		{
			magazine.SetQuickDropAllowed(!HasSpool || HasEjectableSpool);
			if (!HasSpool)
			{
				coil.gameObject.SetActive(value: false);
				wireModel.gameObject.SetActive(value: false);
			}
			else if (!HasNonEmptySpool)
			{
				coil.gameObject.SetActive(value: true);
				coilWire.gameObject.SetActive(value: false);
				wireModel.gameObject.SetActive(value: false);
				coilWire.localScale = new Vector3(1f, coilEmptySize, coilEmptySize);
			}
			else
			{
				float num = (float)remainingUnits / 65536f;
				coil.localRotation = Quaternion.AngleAxis(num * coilRevolutionsPerDose * 360f, Vector3.left);
				float num2 = coilEmptySize + Mathf.Sqrt(num) * (1f - coilEmptySize);
				coilWire.localScale = new Vector3(1f, num2, num2);
				coil.gameObject.SetActive(value: true);
				wireModel.gameObject.SetActive(value: true);
				coilWire.gameObject.SetActive(value: true);
			}
		}

		protected override void OnUsed()
		{
			if (!VRManager.IsVREnabled())
			{
				DropEmptySpool();
			}
		}

		protected override void OnUnused()
		{
			soundSoldering.Stop();
		}

		protected override void OnUngrabbed()
		{
			if (!VRManager.IsVREnabled())
			{
				itemWorkingAnimation.StopAnimating();
			}
		}

		public bool HandleHover(ItemUseTarget target)
		{
			if (VRManager.IsVREnabled())
			{
				return false;
			}
			SingletonBehaviour<InteractionTextControllerNonVr>.Instance.DisplayText(InteractionInfoType.LoadSolderRoll);
			return true;
		}

		public bool HandleUse(ItemUseTarget target)
		{
			magazine.AddItem(target.gameObject, 0);
			return true;
		}

		public bool IsHoverCompatible(ItemUseTarget target)
		{
			return IsUseCompatible(target);
		}

		public bool IsUseCompatible(ItemUseTarget target)
		{
			if (HasSpool || target == null)
			{
				return false;
			}
			MagazineAmmo ammo = ((target != null) ? target.GetComponent<MagazineAmmo>() : null);
			return magazine.ValidItem(ammo, allowSpent: false);
		}

		private void OnDestroy()
		{
			if (!UnloadWatcher.isUnloading && !VRManager.IsVREnabled())
			{
				itemWorkingAnimation.StopAnimating();
			}
		}

		public (Vector3 pos, Quaternion rot, float overridePreviousPerc) GetPose(Vector3 pos, Quaternion rot)
		{
			if (solderingTarget == null)
			{
				return (pos: default(Vector3), rot: default(Quaternion), overridePreviousPerc: 0f);
			}
			Quaternion quaternion = Quaternion.Euler(Mathf.Sin(Time.timeSinceLevelLoad), Mathf.Sin(Time.timeSinceLevelLoad * 2.423f) - 30f, Mathf.Sin(Time.timeSinceLevelLoad * 1.623f));
			(Vector3, Quaternion) tuple = TransformUtils.CalculateAlignmentTargets(SingletonBehaviour<ItemPositionController>.Instance.itemAnchor, solderingTarget.transform.TransformPoint(new Vector3(solderingTarget.Bounds.extents.x, 0f, 0f)), solderingTarget.transform.rotation * quaternion, vrInteractionPoint);
			return (pos: tuple.Item1, rot: tuple.Item2, overridePreviousPerc: ItemWorkingAnimation.EaseInOutCubic(itemWorkingAnimation.MoveToWorkProgress));
		}
	}
}
