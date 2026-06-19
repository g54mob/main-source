using System.Collections;
using System.Collections.Generic;
using ClockStone;
using I2.Loc;
using UnityEngine;

public class Cocoon : MonoBehaviour
{
	public bool hatch;

	public Transform timerTransform;

	public Transform indicatorTransform;

	public Transform particlesTransform;

	public Transform attachmentTransform;

	public GameObject cocoonStringPrefab;

	public GameObject goopParticles;

	public GameObject smokeParticles;

	public GameObject spawnParticles;

	public GameObject goopParticlesBurst;

	public GameObject movableDustParticles;

	public Rigidbody rigidbodyRef;

	public GameObject cocoonTimerPrefab;

	public InventoryItem openedCocoonItem;

	public GameObject cocoonIndicatorPrefab;

	public GameObject mutationGUI;

	private GameObject hatchlingRef;

	private GameObject instantiatedOpenedCocoon;

	private string dripSound = "cocoon_drip";

	private string cocoonAscendSound = "cocoon_ascend";

	private string cocoonStringSound = "cocoon_string";

	private string cocoonBurstSound = "cocoon_final_burst";

	private string dogSpawnCocoonSound = "dog_spawn_cocoon";

	private string ambientNoiseSound = "cocoon_internal_ambience";

	private string cocoonStringAttachSound = "cocoon_string_attach";

	private AudioObject cocoonAscendAudioObject;

	private AudioObject cocoonAmbianceAudioObject;

	private GameObject cocoonIndicator;

	private bool hatchUIShowing;

	private bool isCurrentlyHatching;

	private bool hasSetGlobalHatchingValue;

	private float tutorialHatchTimerMultiplier = 3f;

	private float hatchTimerMax = 30f;

	private float hatchTimerCurrent;

	private float defaultScale = 4f;

	private ulong? storedCocoonRoom;

	private Vector3 storedCocoonPosition = Vector3.zero;

	private Vector3 centerOfMassOffset = new Vector3(0f, -0.35f, -0.1f);

	private string mutatedGene;

	private ulong associatedDogID;

	private GameObject originalDog;

	private ConfigurableJoint attachmentJoint;

	private AttachmentString cocoonString;

	private bool attachedToWorldObject;

	private bool hasString = true;

	private bool isAscending = true;

	private float ascensionRate = 2.5f;

	private float ascensionRateModLow = -1.5f;

	private float ascensionRateModHigh = 0.5f;

	private float drag = 0.25f;

	private float waitTime = 4f;

	private float dustScale = 0.25f;

	private float lastStringDist;

	private float stringAttachRate = 50f;

	private bool hasAttachedString;

	private GameObject stringDustParticles;

	private float minDist = 0.5f;

	private float maxDist = 3f;

	private float ascensionDist;

	private LiquidInfo goopInfo;

	private float petTimeNeeded = 2f;

	private float petTimeCurrent;

	private bool hatched;

	private bool hasRequestedHatchling;

	private Coroutine currentHatchRoutine;

	private Coroutine controllingHatchRoutine;

	private Coroutine currentPostHatchRoutine;

	private CocoonTimer currentTimer;

	private bool agedToAdult;

	private bool cocoonRemoved;

	private Dictionary<GutFloraMutationEffect, FloraMutationInfo> floraMapping = new Dictionary<GutFloraMutationEffect, FloraMutationInfo>();

	private PenFocus penFocusRef;

	private GUIManagerPens guiRef;

	private BoundingBoxComponent bbc;

	private DogRegistration dogRegRef;

	private DogPettingController pettingRef;

	private ConstructionManager constructionRef;

	private void Start()
	{
		bbc = GetComponent<BoundingBoxComponent>();
		penFocusRef = Camera.main.GetComponent<PenFocus>();
		ObjectRegistration registrationScript = ObjectRegistration.GetRegistrationScript();
		guiRef = registrationScript.GetGlobalComponent<GUIManagerPens>(GlobalObject.GUI);
		dogRegRef = registrationScript.GetGlobalComponent<DogRegistration>(GlobalObject.DOG_REGISTRATION);
		pettingRef = registrationScript.GetGlobalComponent<DogPettingController>(GlobalObject.DOG_PETTING_CONTROLLER);
		constructionRef = registrationScript.GetGlobalComponent<ConstructionManager>(GlobalObject.CONSTRUCTION_MANAGER);
		goopInfo = registrationScript.GetGlobalComponent<LiquidController>(GlobalObject.LIQUID_CONTROLLER).GetLiquidForType(LiquidType.COCOON_GOOP);
		Setup();
		CreateTimer();
		SetCenterOfMass();
		CreateIndicator();
		HandleIndicatorVisibility();
		cocoonAmbianceAudioObject = AudioController.Play(ambientNoiseSound, rigidbodyRef.transform);
	}

	private void OnEnable()
	{
		HandleIndicatorVisibility();
	}

	private void Update()
	{
		if (hatch)
		{
			hatch = false;
			StartHatchRoutine();
		}
		Ascend();
		UpdateTimer();
		UpdateString();
		CheckAttachedObject();
		HandleIndicatorVisibility();
	}

	private void OnDestroy()
	{
		bool flag = false;
		if (currentHatchRoutine != null)
		{
			flag = true;
			StopCoroutine(currentHatchRoutine);
			currentHatchRoutine = null;
			Debug.LogError("Cocoon destroyed before currentHatchRoutine finished.");
		}
		if (currentPostHatchRoutine != null)
		{
			flag = true;
			StopCoroutine(currentPostHatchRoutine);
			currentPostHatchRoutine = null;
			Debug.LogError("Cocoon destroyed before currentPostHatchRoutine finished.");
			if (TutorialController.IsTutorialActive())
			{
				TutorialController.OnDogMutationFinished();
			}
		}
		if (currentTimer != null)
		{
			Object.Destroy(currentTimer.transform.root.gameObject);
			currentTimer = null;
		}
		if (cocoonIndicator != null)
		{
			Object.Destroy(cocoonIndicator.gameObject);
			cocoonIndicator = null;
		}
		if (cocoonString != null)
		{
			Object.Destroy(cocoonString.gameObject);
			cocoonString = null;
		}
		if (hasSetGlobalHatchingValue)
		{
			dogRegRef.SetIsHatching(val: false);
		}
		if (flag)
		{
			dogRegRef.RefreshSelectedDog();
			dogRegRef.RefreshThumbnailForDogID(associatedDogID);
		}
		if (originalDog != null)
		{
			Object.Destroy(originalDog);
			originalDog = null;
		}
		if (guiRef != null)
		{
			guiRef.SetGUIInteractiveStatus(status: true, LockReason.COCOON_HATCHING);
		}
		cocoonRemoved = true;
	}

	public void HandleIndicatorVisibility()
	{
		if (!(currentTimer == null))
		{
			if (constructionRef.IsInStandardMode())
			{
				currentTimer.gameObject.SetActive(value: true);
			}
			else
			{
				currentTimer.gameObject.SetActive(value: false);
			}
		}
	}

	public void SetAssociatedDogID(ulong dogID)
	{
		associatedDogID = dogID;
	}

	public ulong GetAssociatedDogID()
	{
		return associatedDogID;
	}

	public Transform GetFocusTransform()
	{
		return particlesTransform;
	}

	public CocoonTimer GetCocoonTimer()
	{
		return currentTimer;
	}

	public void LoadSaveableCocoon(SaveableCocoon cocoon)
	{
		dogRegRef = ObjectRegistration.GetRegistrationScript().GetGlobalComponent<DogRegistration>(GlobalObject.DOG_REGISTRATION);
		if (cocoon.ascensionLinearLimit != -1f && cocoon.anchorPos != null)
		{
			CreateCocoonString();
			CreateStringDustParticles();
			CreateAttachmentJoint(cocoon.anchorPos.Load(), ascensionDist);
			FinalizeString(playSounds: false);
		}
		ascensionDist = cocoon.ascensionDist;
		associatedDogID = cocoon.associatedDogID;
		attachedToWorldObject = cocoon.attachedToWorldObject;
		if (!attachedToWorldObject && cocoon.attachedTransformName != "")
		{
			attachedToWorldObject = true;
		}
		if (attachedToWorldObject)
		{
			GameObject gameObject = ((!cocoon.attachedToDog) ? ObjectRegistration.GetRegistrationScript().GetObjectForUID(cocoon.attachedObjectID) : dogRegRef.GetDogFromID(cocoon.attachedObjectID));
			Rigidbody rigidbody = null;
			Transform transform = null;
			if (gameObject != null)
			{
				transform = ObjectUtil.FindNestedTransformByName(gameObject, cocoon.attachedTransformName);
				if (transform != null)
				{
					rigidbody = transform.GetComponent<Rigidbody>();
				}
			}
			if (rigidbody != null)
			{
				attachmentJoint.enableCollision = true;
				attachmentJoint.connectedBody = transform.GetComponent<Rigidbody>();
				ObjectConnectionsManager.OnCocoonAttachedToObject(base.gameObject, gameObject);
			}
			else
			{
				Object.Destroy(attachmentJoint);
				FindAndAttachToPoint(playSounds: false);
				hasAttachedString = false;
				attachedToWorldObject = false;
			}
		}
		isAscending = cocoon.isAscending;
		if (!isAscending)
		{
			FinishAscension();
		}
		if (cocoon.ascensionLinearLimit == -1f || cocoon.anchorPos == null)
		{
			waitTime = cocoon.ascensionWaitTimer;
		}
		else
		{
			SoftJointLimit linearLimit = new SoftJointLimit
			{
				limit = cocoon.ascensionLinearLimit,
				bounciness = attachmentJoint.linearLimit.bounciness
			};
			attachmentJoint.linearLimit = linearLimit;
		}
		hatchTimerCurrent = cocoon.hatchTimerCurrent;
		hasString = cocoon.hasString;
		if (!cocoon.hasString)
		{
			DestroyString();
		}
		if (cocoon.goopMixed)
		{
			petTimeCurrent = petTimeNeeded;
		}
	}

	public void SaveCocoon(SaveableCocoon cocoon)
	{
		cocoon.hasString = hasString;
		cocoon.isAscending = isAscending;
		cocoon.ascensionDist = ascensionDist;
		cocoon.associatedDogID = associatedDogID;
		cocoon.attachedToWorldObject = attachedToWorldObject;
		if (petTimeCurrent >= petTimeNeeded)
		{
			cocoon.goopMixed = true;
		}
		else
		{
			cocoon.goopMixed = false;
		}
		if (attachmentJoint != null)
		{
			cocoon.ascensionLinearLimit = attachmentJoint.linearLimit.limit;
		}
		if (isAscending && attachmentJoint == null)
		{
			cocoon.ascensionLinearLimit = -1f;
			cocoon.ascensionWaitTimer = waitTime;
		}
		if (attachmentJoint != null)
		{
			cocoon.anchorPos = new SerializableVector3(attachmentJoint.connectedAnchor);
			Rigidbody connectedBody = attachmentJoint.connectedBody;
			if (connectedBody != null)
			{
				cocoon.attachedTransformName = connectedBody.transform.name;
				if (connectedBody.transform.root.CompareTag(Tags.DOG))
				{
					cocoon.attachedToDog = true;
					cocoon.attachedObjectID = dogRegRef.GetIDFromDog(connectedBody.transform.root.gameObject);
				}
				else
				{
					cocoon.attachedToDog = false;
					cocoon.attachedObjectID = connectedBody.transform.root.gameObject.GetComponent<ObjectID>().GetUID();
				}
			}
		}
		if (hatchTimerCurrent >= hatchTimerMax)
		{
			cocoon.hatchTimerCurrent = hatchTimerMax - 1f;
		}
		else
		{
			cocoon.hatchTimerCurrent = hatchTimerCurrent;
		}
	}

	public bool IsCurrentlyHatching()
	{
		return isCurrentlyHatching;
	}

	public bool HasRequestedHatchling()
	{
		return hasRequestedHatchling;
	}

	public bool HatchUIShowing()
	{
		return hatchUIShowing;
	}

	public void UpdatePettingTimer()
	{
		if (!(petTimeCurrent >= petTimeNeeded))
		{
			petTimeCurrent += Time.deltaTime;
			if (petTimeCurrent > petTimeNeeded)
			{
				petTimeCurrent = petTimeNeeded;
			}
			currentTimer.UpdateHeart(petTimeCurrent / petTimeNeeded);
			if (petTimeCurrent >= petTimeNeeded)
			{
				currentTimer.RequestHeartBurst();
			}
		}
	}

	public void HidePettingGUI()
	{
		currentTimer.HideHeart();
	}

	public void ShowPettingGUI()
	{
		currentTimer.DisplayHeart(petTimeCurrent / petTimeNeeded);
	}

	private void UpdateTimer()
	{
		if (currentTimer == null)
		{
			return;
		}
		if (hatchTimerCurrent >= hatchTimerMax)
		{
			if (GameSettings.IsPassiveModeEnabled() && GameSettings.PassiveModeAutoHatch() && !dogRegRef.AnyDogHatching() && !pettingRef.InPettingMode() && guiRef.GetGUIInteractiveStatus() && !PauseController.IsPaused())
			{
				StartHatchRoutine();
			}
			return;
		}
		float num = 1f;
		if (TutorialController.IsTutorialActive())
		{
			num = tutorialHatchTimerMultiplier;
		}
		hatchTimerCurrent += Time.deltaTime * num;
		hatchTimerCurrent = Mathf.Min(hatchTimerCurrent, hatchTimerMax);
		currentTimer.UpdateTimer(hatchTimerCurrent / hatchTimerMax);
	}

	private void SetCenterOfMass()
	{
		Vector3 inertiaTensor = rigidbodyRef.inertiaTensor;
		Quaternion inertiaTensorRotation = rigidbodyRef.inertiaTensorRotation;
		float num = base.transform.root.localScale.x / defaultScale;
		rigidbodyRef.centerOfMass += centerOfMassOffset * num;
		rigidbodyRef.inertiaTensor = inertiaTensor;
		rigidbodyRef.inertiaTensorRotation = inertiaTensorRotation;
		rigidbodyRef.mass *= num;
	}

	private void Setup()
	{
		rigidbodyRef.velocity = Vector3.zero;
		rigidbodyRef.angularVelocity = Vector3.zero;
	}

	private void CheckAttachedObject()
	{
		if (attachedToWorldObject && (attachmentJoint == null || attachmentJoint.connectedBody == null))
		{
			DestroyString();
			hasString = false;
			attachedToWorldObject = false;
		}
	}

	public void Disattach()
	{
		if (attachmentJoint != null && attachmentJoint.connectedBody != null)
		{
			ObjectConnectionsManager.OnCocoonDisattachedFromObject(base.gameObject, attachmentJoint.connectedBody.transform.root.gameObject);
		}
		DestroyString();
		hasString = false;
		attachedToWorldObject = false;
	}

	private void UpdateString()
	{
		if (!(cocoonString == null) && hasAttachedString)
		{
			cocoonString.AttachString(attachmentTransform.position, GetAttachmentPoint());
		}
	}

	public ConfigurableJoint GetAttachmentJoint()
	{
		return attachmentJoint;
	}

	private Vector3 GetAttachmentPoint()
	{
		if (attachmentJoint.connectedBody == null)
		{
			return attachmentJoint.connectedAnchor;
		}
		return attachmentJoint.connectedBody.transform.TransformPoint(attachmentJoint.connectedAnchor);
	}

	private void Ascend()
	{
		if (!isAscending)
		{
			return;
		}
		if (!hasAttachedString)
		{
			AttachString();
			return;
		}
		float num = ascensionRate + Random.Range(ascensionRateModLow, ascensionRateModHigh);
		float num2 = Mathf.Max(attachmentJoint.linearLimit.limit - Time.deltaTime * num, ascensionDist);
		SoftJointLimit linearLimit = new SoftJointLimit
		{
			limit = num2,
			bounciness = attachmentJoint.linearLimit.bounciness
		};
		attachmentJoint.linearLimit = linearLimit;
		if (num2 <= ascensionDist)
		{
			FinishAscension();
		}
	}

	private void FinishAscension()
	{
		isAscending = false;
		rigidbodyRef.drag = drag;
		rigidbodyRef.angularDrag = drag;
		if (cocoonAscendAudioObject != null)
		{
			cocoonAscendAudioObject.Stop(0.25f);
			cocoonAscendAudioObject = null;
		}
	}

	private void AttachString()
	{
		if (waitTime > 0f)
		{
			waitTime -= Time.deltaTime;
			if (waitTime <= 0f)
			{
				Attach();
			}
		}
		else if (!(cocoonString == null))
		{
			float num = Vector3.Distance(attachmentTransform.position, GetAttachmentPoint());
			lastStringDist += Time.deltaTime * stringAttachRate;
			lastStringDist = Mathf.Min(lastStringDist, num);
			float num2 = lastStringDist / num;
			Vector3 pointAlongLine = MathUtil.GetPointAlongLine(attachmentTransform.position, GetAttachmentPoint(), num2);
			cocoonString.AttachString(attachmentTransform.position, pointAlongLine);
			stringDustParticles.transform.position = pointAlongLine;
			if (num2 == 1f)
			{
				FinalizeString();
			}
		}
	}

	private void FinalizeString(bool playSounds = true)
	{
		hasAttachedString = true;
		attachmentJoint.xMotion = ConfigurableJointMotion.Limited;
		attachmentJoint.yMotion = ConfigurableJointMotion.Limited;
		attachmentJoint.zMotion = ConfigurableJointMotion.Limited;
		SoftJointLimitSpring linearLimitSpring = new SoftJointLimitSpring
		{
			spring = 500f
		};
		float limit = Vector3.Distance(attachmentTransform.position, GetAttachmentPoint());
		SoftJointLimit linearLimit = new SoftJointLimit
		{
			limit = limit,
			bounciness = 0.5f
		};
		attachmentJoint.linearLimit = linearLimit;
		attachmentJoint.linearLimitSpring = linearLimitSpring;
		ParticleSystem.MainModule main = stringDustParticles.GetComponent<ParticleSystem>().main;
		main.loop = false;
		Object.Instantiate(smokeParticles, GetAttachmentPoint(), Quaternion.identity).transform.localScale = new Vector3(dustScale, dustScale, dustScale) * 2f;
		if (playSounds)
		{
			AudioController.Play(cocoonStringAttachSound, GetAttachmentPoint());
		}
		if (isAscending)
		{
			cocoonAscendAudioObject = AudioController.Play(cocoonAscendSound, attachmentTransform);
		}
	}

	private void Attach()
	{
		CreateCocoonString();
		FindAndAttachToPoint();
	}

	private void CreateStringDustParticles()
	{
		stringDustParticles = Object.Instantiate(movableDustParticles, attachmentTransform.position, Quaternion.identity);
		stringDustParticles.transform.localScale = new Vector3(dustScale, dustScale, dustScale);
	}

	private void FindAndAttachToPoint(bool playSounds = true)
	{
		RaycastHit raycastHit = default(RaycastHit);
		RaycastHit[] array = new RaycastHit[100];
		if (bbc == null)
		{
			bbc = GetComponent<BoundingBoxComponent>();
			if (bbc == null)
			{
				return;
			}
		}
		Vector3 boxCenter = bbc.GetBoxCenter();
		int num = RaycastUtil.GoodRaycastAllNonAlloc(boxCenter, Vector3.up, 50f, array);
		bool flag = false;
		float num2 = float.PositiveInfinity;
		for (int i = 0; i < num; i++)
		{
			if (!(array[i].transform.root.GetComponent<Pipe>() != null))
			{
				float num3 = Vector3.Distance(boxCenter, array[i].point);
				if (num3 < num2 && array[i].transform.root.gameObject != base.gameObject)
				{
					flag = true;
					num2 = num3;
					raycastHit = array[i];
				}
			}
		}
		if (!flag)
		{
			Disattach();
			return;
		}
		if (playSounds)
		{
			AudioController.Play(cocoonStringSound, attachmentTransform.position);
		}
		Vector3 point = raycastHit.point;
		point = cocoonString.GetOffsetAttachmentPoint(point);
		float num4 = Vector3.Distance(point, attachmentTransform.position);
		CreateAttachmentJoint(point, num4);
		if (raycastHit.rigidbody != null)
		{
			attachedToWorldObject = true;
			attachmentJoint.enableCollision = true;
			attachmentJoint.connectedBody = raycastHit.rigidbody;
			attachmentJoint.connectedAnchor = raycastHit.transform.InverseTransformPoint(point);
			ObjectConnectionsManager.OnCocoonAttachedToObject(base.gameObject, raycastHit.transform.root.gameObject);
		}
		CreateStringDustParticles();
		ascensionDist = Mathf.Min(Random.Range(minDist, maxDist), num4);
	}

	private void CreateCocoonString()
	{
		GameObject gameObject = Object.Instantiate(cocoonStringPrefab);
		cocoonString = gameObject.GetComponent<AttachmentString>();
	}

	private void CreateAttachmentJoint(Vector3 attachmentPoint, float dist)
	{
		attachmentJoint = rigidbodyRef.gameObject.AddComponent<ConfigurableJoint>();
		attachmentJoint.configuredInWorldSpace = true;
		attachmentJoint.anchor = attachmentTransform.localPosition;
		attachmentJoint.autoConfigureConnectedAnchor = false;
		attachmentJoint.connectedAnchor = attachmentPoint;
		SoftJointLimitSpring linearLimitSpring = new SoftJointLimitSpring
		{
			spring = 0f
		};
		SoftJointLimit linearLimit = new SoftJointLimit
		{
			limit = dist,
			bounciness = 0.5f
		};
		attachmentJoint.linearLimit = linearLimit;
		attachmentJoint.linearLimitSpring = linearLimitSpring;
		SoftJointLimit lowAngularXLimit = default(SoftJointLimit);
		SoftJointLimit highAngularXLimit = default(SoftJointLimit);
		SoftJointLimit softJointLimit = default(SoftJointLimit);
		float num = 45f;
		float bounciness = 0.5f;
		lowAngularXLimit.limit = 0f - num;
		lowAngularXLimit.bounciness = bounciness;
		highAngularXLimit.limit = num;
		highAngularXLimit.bounciness = bounciness;
		softJointLimit.limit = num;
		softJointLimit.bounciness = bounciness;
		attachmentJoint.lowAngularXLimit = lowAngularXLimit;
		attachmentJoint.highAngularXLimit = highAngularXLimit;
		attachmentJoint.angularYLimit = softJointLimit;
		attachmentJoint.angularZLimit = softJointLimit;
		attachmentJoint.enablePreprocessing = false;
		attachmentJoint.projectionMode = JointProjectionMode.PositionAndRotation;
		attachmentJoint.projectionAngle = 1f;
		attachmentJoint.projectionDistance = 0.1f;
	}

	public void StartHatchRoutine()
	{
		if (controllingHatchRoutine != null)
		{
			return;
		}
		if (GameSettings.IsPassiveModeEnabled() && GameSettings.PassiveModeAutoHatch() && GameSettings.PassiveModeFocusOnHatchingCocoons())
		{
			if (GameSettings.PassiveModeRandomDogFocus())
			{
				penFocusRef.AutoFocusOnCocoonIfNeeded(base.gameObject);
			}
			else
			{
				penFocusRef.AutoFocusOnRoomObjectIsInIfNeeded(base.gameObject);
			}
		}
		controllingHatchRoutine = StartCoroutine(SubHatchRoutine());
	}

	private void Hatch()
	{
		if (currentHatchRoutine == null && !isCurrentlyHatching && !hatched)
		{
			if (currentHatchRoutine != null)
			{
				Debug.LogError("Attempting to hatch a dog for real but the original UI routine hasn't finished.");
				return;
			}
			currentTimer.HideAllGUI();
			guiRef.SetGUIInteractiveStatus(status: false, LockReason.COCOON_HATCHING);
			isCurrentlyHatching = true;
			SaveableDog saveableDogFromID = dogRegRef.GetSaveableDogFromID(associatedDogID);
			dogRegRef.RequestNewDog(new Vector3(-100f, -100f, -100f), Quaternion.identity, saveableDogFromID.dogGene, null, manualDog: false, dogProfile: saveableDogFromID.dogProfile, customDogAge: saveableDogFromID.brain.dogAge, customDogAgeProgress: saveableDogFromID.brain.dogAgeProgress, callback: OnOriginalDogCreatedCallback, playerOwned: false);
		}
	}

	private IEnumerator SubHatchRoutine()
	{
		dogRegRef.SetIsHatching(val: true);
		hasSetGlobalHatchingValue = true;
		WaitForEndOfFrame frameWait = new WaitForEndOfFrame();
		Hatch();
		while (IsCurrentlyHatching())
		{
			yield return frameWait;
		}
		CreateHatchGUI();
		while (base.gameObject != null && HatchUIShowing())
		{
			yield return frameWait;
		}
		controllingHatchRoutine = null;
	}

	private void OnOriginalDogCreatedCallback(GameObject dog)
	{
		dog.name = "Original Dog (Cocoon)";
		if (cocoonRemoved)
		{
			Object.Destroy(dog);
			return;
		}
		originalDog = dog;
		dogRegRef.MakeDogSuitableForUIDisplay(originalDog);
		AgeUp();
		Mutate();
		currentHatchRoutine = StartCoroutine(HatchRoutineCreateDog());
	}

	private void CreateGoopPuddle()
	{
		RaycastUtil.StageRaycast(particlesTransform.position, Vector3.down, out var hitInfo, 50f);
		Vector3 position = hitInfo.point + Vector3.up * 0.1f;
		GameObject obj = new GameObject("Cocoon Goop Puddle Creator");
		obj.transform.position = position;
		Liquid liquid = obj.AddComponent<Liquid>();
		liquid.ApplyLiquid(goopInfo);
		liquid.CreatePuddle();
		Object.Destroy(obj);
	}

	private void ForceSpreadGoopToDog(GameObject dog)
	{
		Liquid liquid = dog.GetComponent<Liquid>();
		if (liquid == null)
		{
			liquid = dog.AddComponent<Liquid>();
		}
		liquid.ApplyLiquid(goopInfo, force: true);
	}

	public void CreateHatchGUI()
	{
		if (GameSettings.IsPassiveModeEnabled() && GameSettings.PassiveModeAutoHatch() && GameSettings.PassiveModeMutationNotificationOption() != GameSettings.PassiveNotificationsOption.FULL_NOTIF)
		{
			if (originalDog != null)
			{
				Object.Destroy(originalDog);
				originalDog = null;
			}
			MutationUIFinishedCallback();
			if (GameSettings.PassiveModeMutationNotificationOption() == GameSettings.PassiveNotificationsOption.SMALL_NOTIF)
			{
				string gUI_POPUP_MUTATE_SHORT = ScriptLocalization.GUI.GUI_POPUP_MUTATE_SHORT;
				int length = gUI_POPUP_MUTATE_SHORT.IndexOf("[");
				int num = gUI_POPUP_MUTATE_SHORT.IndexOf("]");
				gUI_POPUP_MUTATE_SHORT = gUI_POPUP_MUTATE_SHORT.Substring(0, length) + dogRegRef.GetSaveableDogFromID(associatedDogID).dogName + gUI_POPUP_MUTATE_SHORT.Substring(num + 1);
				guiRef.ShowPassiveModeNotification(ScriptLocalization.GUI.GUI_POPUP_MUTATE_HEADER, gUI_POPUP_MUTATE_SHORT, dogRegRef.GetDefaultThumbnailForDog(hatchlingRef));
			}
		}
		else
		{
			hatchUIShowing = true;
			SaveableDog saveableDogFromID = dogRegRef.GetSaveableDogFromID(associatedDogID);
			MutationGUI component = Object.Instantiate(mutationGUI).GetComponent<MutationGUI>();
			component.SetCocoonRef(this);
			component.SetAssociatedDog(saveableDogFromID, originalDog, mutatedGene, floraMapping);
		}
	}

	public void MutationUIFinishedCallback()
	{
		if (originalDog != null)
		{
			originalDog = null;
		}
		if (TutorialController.IsTutorialActive())
		{
			TutorialController.OnDogMutationFinished();
		}
		hatchUIShowing = false;
		dogRegRef.SetIsHatching(val: false);
		hasSetGlobalHatchingValue = false;
		guiRef.SetGUIInteractiveStatus(status: true, LockReason.COCOON_HATCHING);
		TryPushEatCocoonDistraction();
		try
		{
			DogRegistration.SafeDestroy(base.gameObject);
		}
		catch
		{
			Debug.LogError("Cocoon destroyed after mutation UI was created but before mutation UI was closed.");
		}
	}

	private void TryPushEatCocoonDistraction()
	{
		if (!(hatchlingRef == null) && !(instantiatedOpenedCocoon == null))
		{
			DogAI component = hatchlingRef.GetComponent<DogAI>();
			DistractionFood newDistraction = new DistractionFood(component, 1f, instantiatedOpenedCocoon);
			component.TryAddNewDistraction(newDistraction);
		}
	}

	private IEnumerator HatchRoutineCreateDog()
	{
		GameObject gameObject = Object.Instantiate(goopParticles, particlesTransform);
		gameObject.transform.localPosition = Vector3.zero;
		AudioController.Play(dripSound, particlesTransform.position);
		float goopTimer = gameObject.GetComponent<ParticleSystem>().main.duration / 2f;
		yield return new WaitForSeconds(goopTimer);
		CreateGoopPuddle();
		yield return new WaitForSeconds(goopTimer);
		hasRequestedHatchling = true;
		Vector3 position = particlesTransform.position;
		ObjectSpawnParticles component = Object.Instantiate(spawnParticles, position, Quaternion.identity).GetComponent<ObjectSpawnParticles>();
		SaveableDog saveableDogFromID = dogRegRef.GetSaveableDogFromID(associatedDogID);
		component.SetContainedDog(saveableDogFromID);
		component.spawnPos = position;
		component.dogRegRef = dogRegRef;
		component.SetSpawnCallback(HatchCallback);
		component.SetExpectedRoom(bbc.GetRoomUID());
		component.SetSpawnSoundOverride(dogSpawnCocoonSound);
		storedCocoonPosition = rigidbodyRef.position;
		GetComponent<BoundingBoxComponent>().GetRoomUID();
		Collider[] componentsInChildren = GetComponentsInChildren<Collider>();
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			componentsInChildren[i].enabled = false;
		}
		dogRegRef.ClearCachedThumbnailsForSaveableDog(saveableDogFromID, fromHatch: true);
		currentHatchRoutine = null;
	}

	private void DestroyString()
	{
		if (cocoonString != null)
		{
			Object.Destroy(cocoonString.gameObject);
			cocoonString = null;
		}
		if (attachmentJoint != null)
		{
			Object.Destroy(attachmentJoint);
		}
		FinishAscension();
	}

	private bool ExtraMutation()
	{
		if (petTimeCurrent >= petTimeNeeded)
		{
			return true;
		}
		return false;
	}

	private void AgeUp()
	{
		SaveableDog saveableDogFromID = dogRegRef.GetSaveableDogFromID(associatedDogID);
		saveableDogFromID.brain.dogAgeProgress = 0f;
		if (saveableDogFromID.brain.dogAge < DogAge.ADULT)
		{
			StoreCurrentGene(saveableDogFromID);
			saveableDogFromID.brain.dogAge++;
			if (saveableDogFromID.brain.dogAge >= DogAge.ADULT)
			{
				agedToAdult = true;
			}
		}
		dogRegRef.UpdateSaveableDog(saveableDogFromID);
	}

	private void StoreCurrentGene(SaveableDog sd)
	{
		string text = dogRegRef.ExportDog(sd);
		switch (sd.brain.dogAge)
		{
		case DogAge.PUPPY:
			sd.dogGene.puppyCode = text;
			break;
		case DogAge.CHILD:
			sd.dogGene.childCode = text;
			break;
		case DogAge.TEEN:
			sd.dogGene.teenCode = text;
			break;
		case DogAge.YOUNG_ADULT:
			sd.dogGene.youngAdultCode = text;
			break;
		default:
			Debug.LogError("Attempting to store the current gene for an age where this makes no sense: " + sd.brain.dogAge);
			break;
		}
	}

	private void Mutate()
	{
		SaveableDog saveableDogFromID = dogRegRef.GetSaveableDogFromID(associatedDogID);
		MasterDogGene component = originalDog.GetComponent<MasterDogGene>();
		component.MapDogGene(saveableDogFromID.dogGene);
		GameSettings.PassiveMutationRate pupationMutationRate = GameSettings.PassiveMutationRate.DEFAULT;
		if (GameSettings.IsPassiveModeEnabled())
		{
			pupationMutationRate = GameSettings.PassivePupationMutationRate();
		}
		GameSettings.PassiveMutationRate passiveMutationRate = GameSettings.PassiveMutationRate.DEFAULT;
		if (GameSettings.IsPassiveModeEnabled())
		{
			passiveMutationRate = GameSettings.PassiveFloraMutationEffects();
		}
		if (ExtraMutation() && passiveMutationRate != GameSettings.PassiveMutationRate.VERY_HIGH)
		{
			passiveMutationRate = GameSettings.PassiveMutationRate.HIGH;
		}
		floraMapping = originalDog.GetComponent<MasterDogGene>().AdvanceDogGenes(saveableDogFromID, passiveMutationRate, pupationMutationRate);
		saveableDogFromID.dogGene = component.GetSaveableDogGene(saveableDogFromID.dogGene);
		dogRegRef.UpdateSaveableDog(saveableDogFromID);
		mutatedGene = saveableDogFromID.dogGene.dogGene;
	}

	private void HatchCallback(GameObject hatchling)
	{
		if (cocoonIndicator != null)
		{
			Object.Destroy(cocoonIndicator.gameObject);
			cocoonIndicator = null;
		}
		if (particlesTransform != null)
		{
			AudioController.Play(cocoonBurstSound, particlesTransform.position);
			Object.Instantiate(smokeParticles, particlesTransform.position, Quaternion.identity);
			Object.Instantiate(goopParticlesBurst, particlesTransform.position, Quaternion.identity);
		}
		if (hatchling != null)
		{
			List<LegStructure> allLegStructures = hatchling.GetComponent<LegController>().GetAllLegStructures();
			for (int i = 0; i < allLegStructures.Count; i++)
			{
				allLegStructures[i].limb.ForceGiveOut();
			}
			ForceSpreadGoopToDog(hatchling);
			dogRegRef.SaveDog(hatchling, inWorld: true);
			hatchling.transform.rotation = Random.rotation;
			LegController component = hatchling.GetComponent<LegController>();
			component.bodyBack.GetComponent<Rigidbody>().AddRelativeTorque(Random.rotation.eulerAngles * 500f);
			component.bodyFront.GetComponent<Rigidbody>().AddRelativeTorque(Random.rotation.eulerAngles * 500f);
			try
			{
				if (penFocusRef.IsCameraFollowingObject(base.gameObject))
				{
					penFocusRef.RequestFollowCam(component.bodyFront.transform);
				}
			}
			catch
			{
				Debug.LogError("Cocoon destroyed between hatch request and callback.");
				if (TutorialController.IsTutorialActive())
				{
					TutorialController.OnDogMutationFinished();
				}
			}
		}
		dogRegRef.RefreshSelectedDog();
		dogRegRef.RefreshThumbnailForDogID(associatedDogID);
		try
		{
			currentPostHatchRoutine = StartCoroutine(PostHatchRoutine(hatchling));
		}
		catch
		{
			Debug.LogError("Cocoon destroyed between hatch request and callback.");
		}
	}

	private IEnumerator PostHatchRoutine(GameObject hatchling)
	{
		yield return new WaitForSeconds(0.5f);
		DestroyString();
		GetComponentInChildren<Renderer>().enabled = false;
		DogHome globalComponent = ObjectRegistration.GetRegistrationScript().GetGlobalComponent<DogHome>(GlobalObject.DOG_HOME);
		List<GameObject> toIgnoreDuringPlacement = new List<GameObject> { base.gameObject };
		hatchlingRef = hatchling;
		instantiatedOpenedCocoon = globalComponent.TrySpawnItem(openedCocoonItem, storedCocoonPosition, customScale: base.transform.localScale, customRotation: rigidbodyRef.rotation, expectedRoom: storedCocoonRoom, moveToGoodLocation: true, toIgnoreDuringPlacement: toIgnoreDuringPlacement);
		Rigidbody[] componentsInChildren = GetComponentsInChildren<Rigidbody>();
		foreach (Rigidbody obj in componentsInChildren)
		{
			obj.collisionDetectionMode = CollisionDetectionMode.ContinuousSpeculative;
			obj.isKinematic = true;
		}
		DestroyString();
		yield return new WaitForSeconds(1f);
		if (hatchling != null)
		{
			MasterDogGene component = hatchling.GetComponent<MasterDogGene>();
			if (agedToAdult && hatchling.GetComponent<DoggyBrain>().DidDogHatchFromEgg())
			{
				GoalsController.ReportGoalEvent(GoalCondition.DOG_RAISED_FROM_PUP_TO_ADULT);
				if (component.GetDomRecPropertyStatus(GeneticDomRecProperty.MISSING_FRONT_LEFT_LEG) && component.GetDomRecPropertyStatus(GeneticDomRecProperty.MISSING_FRONT_RIGHT_LEG) && component.GetDomRecPropertyStatus(GeneticDomRecProperty.MISSING_BACK_LEFT_LEG) && component.GetDomRecPropertyStatus(GeneticDomRecProperty.MISSING_BACK_RIGHT_LEG))
				{
					GoalsController.ReportGoalEvent(GoalCondition.DOG_RAISED_FROM_PUP_TO_ADULT_NO_LEGS);
				}
			}
			component.CheckGeneticGoals();
		}
		yield return new WaitForSeconds(1f);
		hatched = true;
		isCurrentlyHatching = false;
		currentPostHatchRoutine = null;
	}

	public bool HasHatched()
	{
		return hatched;
	}

	private void CreateTimer()
	{
		if (currentTimer == null)
		{
			currentTimer = Object.Instantiate(cocoonTimerPrefab).GetComponent<CocoonTimer>();
		}
		currentTimer.SetCocoonRef(this);
		currentTimer.SetFollowTransform(timerTransform);
		if (ExtraMutation())
		{
			currentTimer.ShowFinalHeart();
		}
	}

	private void CreateIndicator()
	{
		cocoonIndicator = Object.Instantiate(cocoonIndicatorPrefab);
		cocoonIndicator.GetComponent<CocoonIndicator>().SetFollowTransform(indicatorTransform);
		cocoonIndicator.GetComponent<CocoonIndicator>().SetName(dogRegRef.GetSaveableDogFromID(associatedDogID).dogName);
	}

	public GameObject GetIndicator()
	{
		return cocoonIndicator;
	}
}
