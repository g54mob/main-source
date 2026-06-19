using System.Collections.Generic;
using ClockStone;
using HighlightingSystem;
using InControl;
using UnityEngine;

public class DogPettingController : MonoBehaviour
{
	public delegate void PettingFinishedCallback();

	private enum PetMode
	{
		STANDARD = 0,
		SEEKING_TARGET = 1,
		PETTING_TARGET = 2
	}

	public Color highlightColor;

	public GameObject pettableParticlePrefab;

	private PettingFinishedCallback currentPettingFinishedCallback;

	private ParticleSystem currentPettableParticles;

	private PetMode currentMode;

	private DoggyBrain pettableBrainRef;

	private Cocoon currentPettableCocoon;

	private GameObject currentPettableDog;

	private InteractableRoboVacuum currentPettableVacuum;

	private LegController pettableLegsRef;

	private FaceController pettableFaceRef;

	private GameObject currentHighlightedDog;

	private DogParticleController pettableParticleRef;

	private PettablePersonalityType currentPettablePersonality;

	public string pettingDirectionSwitchSound = "petting_balloon2";

	private string pettingFrictionLoopSound = "petting_friction_loop";

	private string petModeEnterSound = "petModeEnter";

	private string grabModeEnterSound = "grabModeEnter";

	private AudioObject currentDirectionSwitchSound;

	private AudioObject activeFrictionLoop;

	public float pettingFrictionVolumeMin;

	public float pettingFrictionVolumeMax = 0.15f;

	public float pettingFrictionPitchMin = 0.5f;

	public float pettingFrictionPitchMax = 0.75f;

	public float pettingSpeedMin;

	public float pettingSpeedMax = 0.6f;

	public float speedChangeTriggerMin = 0.035f;

	public float speedChangeTriggerMax = 0.1f;

	public float speedChangeVolumeMin;

	public float speedChangeVolumeMax = 0.3f;

	public float speedChangePitchMin = 0.75f;

	public float speedChangePitchMax = 1.25f;

	private float defaultCamDistance = 5f;

	private float smoothedPettingSpeed;

	private float previousFrameSmoothedPettingSpeed;

	private float pettingSpeedSmoothTimer = 0.065f;

	private List<Vector2> previousPettingSpeeds = new List<Vector2>();

	private Vector2 previousInputPosition = Vector2.zero;

	private float maxPitchVolumeIncreasePerSecond = 100f;

	private float maxPitchVolumeDecreasePerSecond = 1f;

	private float nextPettingVocalizationChance = 0.9975f;

	private float highPettingVocalizationChance = 0.995f;

	private float mediumPettingVocalizationChance = 0.9975f;

	private float lowPettingVocalizationChance = 0.999f;

	private float growlPettingVocalizationChance = 0.95f;

	private float petForceStandard = 0.1f;

	private float petForceLegs = 1f;

	private float minPetMov = 5f;

	private bool inPettingMode;

	private bool isPettingCocoon;

	private bool isPettingVacuum;

	private Dictionary<GameObject, int> strengthModKeys = new Dictionary<GameObject, int>();

	private float previousMouseX;

	private float previousMouseY;

	private float currentCycleTimer;

	private float cycleTimeout = 1f;

	private float stressReliefRate = 0.175f;

	private float angerRefliefRate = 0.175f;

	private float angerAdditionRate = -0.075f;

	private float boredomReliefRate = 0.075f;

	private float particleRate = 3f;

	private float currentParticleTimer;

	private bool faceChanged;

	private float currentPetTime;

	private float happyEyesTime = 1f;

	private float madEyesTime = 1f;

	private float legsGiveoutTime = 5f;

	private AnimationCurveWrapper legCurveZ;

	private float headTimer;

	private float noHeadTimer;

	private float bellyTimer;

	private float noBellyTimer;

	private float timeToStartHeadReaction = 0.5f;

	private float timeToStartBellyReaction = 0.15f;

	private float timeToCancelBodyPartReaction = 0.5f;

	private float currentLegTime;

	private bool isKicking;

	private float randomKickJitter = 10f;

	private List<GameObject> kickingLegs = new List<GameObject>();

	private bool isPettedEmoting;

	private bool hasRequestedAngryFace;

	private PetHitInfo emptyPetHitInfo;

	private bool mouseOverCommandSwapButton;

	private bool needsMouseUpBeforeAutoClose;

	private float raycastDist = 100f;

	private RaycastHit[] results = new RaycastHit[100];

	private DogNoises dogNoisesRef;

	private Camera mainCam;

	private GUIManagerPens guiRef;

	private ObjectGrabber grabberRef;

	private CursorController cursorRef;

	private PlayModeController playModeRef;

	private void Start()
	{
		emptyPetHitInfo = default(PetHitInfo);
		mainCam = Camera.main;
		ObjectRegistration registrationScript = ObjectRegistration.GetRegistrationScript();
		cursorRef = registrationScript.GetGlobalComponent<CursorController>(GlobalObject.CURSOR);
		grabberRef = registrationScript.GetGlobalComponent<ObjectGrabber>(GlobalObject.OBJECT_GRABBER);
		guiRef = registrationScript.GetGlobalComponent<GUIManagerPens>(GlobalObject.GUI, nullAllowed: true);
		if (guiRef != null)
		{
			playModeRef = guiRef.playModeGUI.GetComponent<PlayModeController>();
		}
		CreateCurves();
	}

	private void Update()
	{
		if (guiRef == null)
		{
			return;
		}
		if (!guiRef.GetGUIInteractiveStatus())
		{
			if (currentPettableDog != null)
			{
				OnExitPettingMode();
			}
			if (currentHighlightedDog != null)
			{
				RemovePettableHighlight();
			}
			return;
		}
		if (isKicking && currentPettableDog == null && currentPettableCocoon == null && currentPettableVacuum == null)
		{
			SetPetMode(newVal: false);
		}
		if (!inPettingMode && currentMode != PetMode.STANDARD)
		{
			inPettingMode = true;
			SetPetMode(newVal: false);
		}
		CheckPets();
	}

	private void FixedUpdate()
	{
		if (!(guiRef == null) && guiRef.GetGUIInteractiveStatus() && isKicking)
		{
			UpdateKicks();
		}
	}

	public void SetMouseOverPettingModeButton(bool val)
	{
		mouseOverCommandSwapButton = val;
	}

	public void SetPettingMode(bool val)
	{
		if (inPettingMode != val)
		{
			inPettingMode = val;
			SetPetMode(inPettingMode);
		}
	}

	public bool InPettingMode()
	{
		return inPettingMode;
	}

	public bool HasPettingTarget()
	{
		if (!(currentPettableDog != null) && !(currentPettableCocoon != null))
		{
			return currentPettableVacuum != null;
		}
		return true;
	}

	public bool IsPettingDog(GameObject dog)
	{
		if (currentMode == PetMode.PETTING_TARGET && dog.transform.root.gameObject == currentPettableDog.transform.root.gameObject && currentPetTime >= happyEyesTime)
		{
			return true;
		}
		return false;
	}

	public void SetPetFinishedCallback(PettingFinishedCallback newCallback)
	{
		if (currentPettingFinishedCallback != null)
		{
			Debug.LogError("Double-setting petting callback.");
			currentPettingFinishedCallback();
		}
		currentPettingFinishedCallback = newCallback;
	}

	private void CallCallback()
	{
		if (currentPettingFinishedCallback != null)
		{
			PettingFinishedCallback pettingFinishedCallback = currentPettingFinishedCallback;
			currentPettingFinishedCallback = null;
			pettingFinishedCallback();
		}
	}

	private void CreateCurves()
	{
		AnimationCurve animationCurve = new AnimationCurve();
		animationCurve.AddKey(0f, 0f);
		animationCurve.AddKey(0.25f, 200f);
		animationCurve.AddKey(0.375f, -300f);
		animationCurve.AddKey(0.5f, 0f);
		legCurveZ = new AnimationCurveWrapper(animationCurve);
	}

	private void SetPetMode(bool newVal)
	{
		if (PauseController.IsPaused() || !guiRef.GetGUIInteractiveStatus())
		{
			return;
		}
		if (newVal)
		{
			needsMouseUpBeforeAutoClose = true;
			grabberRef.DisableGrabber(LockReason.DOG_PETTING);
			currentMode = PetMode.SEEKING_TARGET;
			playModeRef.EnterPettingMode();
			AudioController.Play(petModeEnterSound);
			return;
		}
		if (currentMode == PetMode.PETTING_TARGET)
		{
			OnExitPettingMode();
		}
		if (currentHighlightedDog != null)
		{
			RemovePettableHighlight();
		}
		if (grabberRef != null)
		{
			grabberRef.EnableGrabber(LockReason.DOG_PETTING);
		}
		currentMode = PetMode.STANDARD;
		playModeRef.ExitPettingMode();
		AudioController.Play(grabModeEnterSound);
	}

	private void CheckPets()
	{
		if (currentMode != PetMode.STANDARD && !PauseController.IsPaused())
		{
			if (currentMode == PetMode.SEEKING_TARGET)
			{
				FindTarget();
			}
			UpdateSmoothedPettingSpeed();
			if (currentMode == PetMode.PETTING_TARGET)
			{
				PetTarget();
				cursorRef.SetCursor(CursorController.CursorType.PETTING);
			}
			else if (currentMode == PetMode.SEEKING_TARGET && !mouseOverCommandSwapButton)
			{
				cursorRef.SetCursor(CursorController.CursorType.PETTABLE);
			}
			previousFrameSmoothedPettingSpeed = smoothedPettingSpeed;
		}
	}

	private void FindTarget()
	{
		GameObject hitTarget = GetHitTarget(ref emptyPetHitInfo);
		HighlightDog(hitTarget);
		if (hitTarget != null)
		{
			cursorRef.SetCursor(CursorController.CursorType.PETTABLE);
		}
		if (!GameControls.actions.Interact.IsPressed)
		{
			needsMouseUpBeforeAutoClose = false;
			return;
		}
		currentPettableDog = hitTarget;
		if (currentPettableDog != null)
		{
			currentMode = PetMode.PETTING_TARGET;
			dogNoisesRef = currentPettableDog.GetComponent<DogNoises>();
			isPettingCocoon = currentPettableDog.CompareTag(Tags.COCOON);
			isPettingVacuum = currentPettableDog.CompareTag(Tags.VACUUM);
			OnEnterPettingMode();
		}
		else if (!needsMouseUpBeforeAutoClose && GameControls.actions.Interact.WasPressed && !GameControls.actions.PettingGrabSwap.IsPressed && !mouseOverCommandSwapButton)
		{
			SetPetMode(newVal: false);
		}
	}

	private GameObject GetHitTarget(ref PetHitInfo petHitInfo, bool petHit = false)
	{
		if (petHit)
		{
			petHitInfo.hitBody = null;
			petHitInfo.hitNormal = Vector3.zero;
		}
		RaycastHit raycastHit = default(RaycastHit);
		Ray ray = mainCam.ScreenPointToRay(InputManager.MouseProvider.GetPosition());
		int num = RaycastUtil.DogGrabberCastAllNonAlloc(ray.origin, ray.direction, results, raycastDist);
		if (num == 0)
		{
			return null;
		}
		RaycastHit raycastHit2 = raycastHit;
		GameObject result = null;
		float num2 = float.PositiveInfinity;
		for (int i = 0; i < num; i++)
		{
			GameObject gameObject = results[i].transform.gameObject;
			GameObject gameObject2 = results[i].transform.root.gameObject;
			if (gameObject.layer == RaycastUtil.stageLayer)
			{
				Renderer component = gameObject.GetComponent<Renderer>();
				if (component != null && !component.enabled)
				{
					continue;
				}
			}
			float num3 = Vector3.Distance(results[i].point, ray.origin);
			if (num3 < num2)
			{
				num2 = num3;
				raycastHit2 = results[i];
				result = gameObject2;
			}
		}
		if (raycastHit2.transform != null)
		{
			GameObject gameObject3 = raycastHit2.transform.root.gameObject;
			if (((gameObject3.CompareTag(Tags.DOG) && !gameObject3.GetComponent<DoggyBrain>().IsDead()) || gameObject3.CompareTag(Tags.COCOON) || gameObject3.CompareTag(Tags.VACUUM)) && (!petHit || gameObject3 == currentPettableDog))
			{
				if (petHit)
				{
					petHitInfo.hitPoint = raycastHit2.point;
					petHitInfo.hitNormal = raycastHit2.normal;
					petHitInfo.hitBody = raycastHit2.rigidbody;
				}
				return result;
			}
		}
		return null;
	}

	private void UpdateSmoothedPettingSpeed()
	{
		float num = 1f;
		if (pettableLegsRef != null)
		{
			num = Mathf.Max(Vector3.Distance(mainCam.transform.position, pettableLegsRef.bodyFront.transform.position) * 0.5f, defaultCamDistance) / defaultCamDistance;
		}
		else if (isPettingCocoon && currentPettableCocoon != null)
		{
			num = Mathf.Max(Vector3.Distance(mainCam.transform.position, currentPettableCocoon.rigidbodyRef.transform.position) * 0.5f, defaultCamDistance) / defaultCamDistance;
		}
		else if (isPettingVacuum && currentPettableVacuum != null)
		{
			num = Mathf.Max(Vector3.Distance(mainCam.transform.position, currentPettableVacuum.rb.transform.position) * 0.5f, defaultCamDistance) / defaultCamDistance;
		}
		float num2 = (Mathf.Abs(InputManager.MouseProvider.GetPosition().x - previousInputPosition.x) + Mathf.Abs(InputManager.MouseProvider.GetPosition().y - previousInputPosition.y)) / 2f;
		previousInputPosition = new Vector2(InputManager.MouseProvider.GetPosition().x, InputManager.MouseProvider.GetPosition().y);
		float x = Mathf.Clamp(num2 * num * Time.deltaTime, pettingSpeedMin, pettingSpeedMax);
		previousPettingSpeeds.Add(new Vector2(x, Time.time));
		for (int num3 = previousPettingSpeeds.Count - 1; num3 >= 0; num3--)
		{
			if (Time.time - previousPettingSpeeds[num3].y > pettingSpeedSmoothTimer)
			{
				previousPettingSpeeds.RemoveAt(num3);
			}
		}
		if (!cursorRef.IsSystemMouseActive())
		{
			smoothedPettingSpeed /= cursorRef.GetVirtualPettingCursorSpeedMultiplier();
		}
		smoothedPettingSpeed = 0f;
		for (int i = 0; i < previousPettingSpeeds.Count; i++)
		{
			smoothedPettingSpeed += previousPettingSpeeds[i].x;
		}
		smoothedPettingSpeed /= previousPettingSpeeds.Count;
	}

	private void PlaySoundFromSmoothedPettingSpeed(PetHitInfo hitInfo)
	{
		if (activeFrictionLoop == null)
		{
			return;
		}
		float minVal = speedChangeVolumeMin * SFXOverlord.GetSFXVolume();
		float maxVal = speedChangeVolumeMax * SFXOverlord.GetSFXVolume();
		float minVal2 = speedChangePitchMin * SFXOverlord.GetSFXVolume();
		float maxVal2 = speedChangePitchMax * SFXOverlord.GetSFXVolume();
		float minVal3 = pettingFrictionVolumeMin * SFXOverlord.GetSFXVolume();
		float maxVal3 = pettingFrictionVolumeMax * SFXOverlord.GetSFXVolume();
		float minVal4 = pettingFrictionPitchMin * SFXOverlord.GetSFXVolume();
		float maxVal4 = pettingFrictionPitchMax * SFXOverlord.GetSFXVolume();
		float num = 1f;
		if (!cursorRef.IsSystemMouseActive())
		{
			num = cursorRef.GetVirtualPettingCursorDampen();
		}
		float sinusoidalValue = Inchworm.GetSinusoidalValue(MathUtil.GetPercentageOfRange(smoothedPettingSpeed, pettingSpeedMin, pettingSpeedMax * num), 0f, -1f, 1f);
		float num2 = MathUtil.GetValueOfRangePercentage(sinusoidalValue, minVal3, maxVal3);
		float num3 = MathUtil.GetValueOfRangePercentage(sinusoidalValue, minVal4, maxVal4);
		if (hitInfo.hitBody == null)
		{
			num2 = 0f;
			num3 = 0f;
		}
		float num4 = maxPitchVolumeIncreasePerSecond * Time.deltaTime;
		float num5 = maxPitchVolumeDecreasePerSecond * Time.deltaTime;
		float num6 = num2;
		if (num6 > activeFrictionLoop.volume && num6 - activeFrictionLoop.volume > num4)
		{
			num6 = activeFrictionLoop.volume + num4;
		}
		else if (num6 < activeFrictionLoop.volume && activeFrictionLoop.volume - num6 > num5)
		{
			num6 = activeFrictionLoop.volume - num5;
		}
		float num7 = num3;
		if (num7 > activeFrictionLoop.pitch && num7 - activeFrictionLoop.pitch > num4)
		{
			num7 = activeFrictionLoop.pitch + num4;
		}
		else if (num7 < activeFrictionLoop.pitch && activeFrictionLoop.pitch - num7 > num5)
		{
			num7 = activeFrictionLoop.pitch - num5;
		}
		activeFrictionLoop.volume = num6;
		activeFrictionLoop.pitch = num7;
		if (currentDirectionSwitchSound != null && currentDirectionSwitchSound.IsPlaying())
		{
			float valueOfRangePercentage = MathUtil.GetValueOfRangePercentage(sinusoidalValue, minVal, maxVal);
			float valueOfRangePercentage2 = MathUtil.GetValueOfRangePercentage(sinusoidalValue, minVal2, maxVal2);
			float num8 = valueOfRangePercentage;
			if (num8 > currentDirectionSwitchSound.volume && num8 - currentDirectionSwitchSound.volume > num4)
			{
				num8 = currentDirectionSwitchSound.volume + num4;
			}
			else if (num8 < currentDirectionSwitchSound.volume && currentDirectionSwitchSound.volume - num8 > num5)
			{
				num8 = currentDirectionSwitchSound.volume - num5;
			}
			float num9 = valueOfRangePercentage2;
			if (num9 > currentDirectionSwitchSound.pitch && num9 - currentDirectionSwitchSound.pitch > num4)
			{
				num9 = currentDirectionSwitchSound.pitch + num4;
			}
			else if (num9 < currentDirectionSwitchSound.pitch && currentDirectionSwitchSound.pitch - num9 > num5)
			{
				num9 = currentDirectionSwitchSound.pitch - num5;
			}
			currentDirectionSwitchSound.volume = num8;
			currentDirectionSwitchSound.pitch = num9;
		}
		if (hitInfo.hitBody != null && (smoothedPettingSpeed > previousFrameSmoothedPettingSpeed || !cursorRef.IsSystemMouseActive()))
		{
			float num10 = smoothedPettingSpeed - previousFrameSmoothedPettingSpeed;
			float num11 = speedChangeTriggerMin;
			float num12 = speedChangeTriggerMax;
			if (!cursorRef.IsSystemMouseActive())
			{
				num11 = speedChangeTriggerMin * cursorRef.GetVirtualPettingCursorDampen() / 2f;
				num12 = speedChangeTriggerMax * cursorRef.GetVirtualPettingCursorDampen() / 2f;
			}
			if (num10 > num11)
			{
				num10 = Mathf.Clamp(num10, num11, num12);
				float valueOfRangePercentage3 = MathUtil.GetValueOfRangePercentage(MathUtil.GetPercentageOfRange(num10, num11, num12), minVal, maxVal);
				if (currentDirectionSwitchSound != null && currentDirectionSwitchSound.IsPlaying())
				{
					currentDirectionSwitchSound.Stop(0.1f);
				}
				currentDirectionSwitchSound = AudioController.Play(pettingDirectionSwitchSound, currentPettableParticles.transform, valueOfRangePercentage3);
			}
		}
		previousFrameSmoothedPettingSpeed = smoothedPettingSpeed;
	}

	private void PetTarget()
	{
		if (!GameControls.actions.Interact.IsPressed || currentPettableDog == null)
		{
			OnExitPettingMode();
			return;
		}
		PetHitInfo petHitInfo = new PetHitInfo
		{
			hitPoint = currentPettableParticles.gameObject.transform.position
		};
		GetHitTarget(ref petHitInfo, petHit: true);
		PlaySoundFromSmoothedPettingSpeed(petHitInfo);
		Vector3 vector = mainCam.WorldToScreenPoint(petHitInfo.hitPoint);
		currentCycleTimer -= Time.deltaTime;
		float num = minPetMov;
		if (!cursorRef.IsSystemMouseActive())
		{
			num = minPetMov * cursorRef.GetVirtualPettingCursorDampen();
		}
		if ((vector.x > previousMouseX && Mathf.Abs(vector.x - previousMouseX) >= num) || (vector.y > previousMouseY && Mathf.Abs(vector.y - previousMouseY) >= num) || (vector.x < previousMouseX && Mathf.Abs(vector.x - previousMouseX) >= num) || (vector.y < previousMouseY && Mathf.Abs(vector.y - previousMouseY) >= num))
		{
			currentCycleTimer = cycleTimeout;
			if (isPettingCocoon)
			{
				currentPettableCocoon.UpdatePettingTimer();
			}
		}
		else
		{
			ParticleSystem.EmissionModule emission = currentPettableParticles.emission;
			emission.enabled = false;
		}
		previousMouseX = vector.x;
		previousMouseY = vector.y;
		if (currentCycleTimer > 0f)
		{
			if (!isPettingCocoon && !isPettingVacuum && petHitInfo.hitBody != null)
			{
				float num2 = petForceStandard;
				if (petHitInfo.hitBody.gameObject.layer == LayerMask.NameToLayer("Legs"))
				{
					num2 = petForceLegs;
				}
				petHitInfo.hitBody.AddForceAtPosition(Vector3.Normalize(petHitInfo.hitPoint - mainCam.transform.position) * num2, petHitInfo.hitPoint, ForceMode.Impulse);
			}
			currentPettableParticles.gameObject.transform.position = petHitInfo.hitPoint;
			ParticleSystem.EmissionModule emission2 = currentPettableParticles.emission;
			emission2.enabled = true;
			currentPetTime += Time.deltaTime;
			if (isPettingVacuum && currentPetTime >= happyEyesTime)
			{
				if (!faceChanged)
				{
					faceChanged = true;
					currentPettableVacuum.OnPettingStart();
				}
				currentPettableVacuum.OnPetting();
			}
			if (isPettingCocoon || isPettingVacuum)
			{
				return;
			}
			if (!faceChanged && currentPetTime >= happyEyesTime)
			{
				faceChanged = true;
				if (currentPettablePersonality == PettablePersonalityType.DISLIKES_PETTING)
				{
					hasRequestedAngryFace = true;
					pettableFaceRef.RequestFace(Face.ANGRY);
				}
				else
				{
					pettableBrainRef.OnDogPraised();
					pettableFaceRef.RequestFace(Face.SLEEP);
				}
			}
			if (currentPettablePersonality == PettablePersonalityType.DISLIKES_PETTING && Random.value >= growlPettingVocalizationChance)
			{
				dogNoisesRef.RequestGrowl(updateFace: false);
			}
			if (currentPetTime >= legsGiveoutTime && currentPetTime - Time.deltaTime < legsGiveoutTime && currentPettablePersonality != PettablePersonalityType.DISLIKES_PETTING)
			{
				if (!isKicking)
				{
					GiveOut();
				}
				dogNoisesRef.RequestContentWhine();
			}
			if (IsPettingHead(petHitInfo))
			{
				headTimer += Time.deltaTime;
				noHeadTimer = 0f;
			}
			else
			{
				noHeadTimer += Time.deltaTime;
				if (noHeadTimer > timeToCancelBodyPartReaction)
				{
					headTimer = 0f;
				}
			}
			if (currentPettablePersonality != PettablePersonalityType.DISLIKES_PETTING)
			{
				if (!isPettedEmoting && headTimer > timeToStartHeadReaction)
				{
					StartHeadPetEmote();
					dogNoisesRef.RequestContentWhine();
				}
				else if (isPettedEmoting && noHeadTimer >= timeToCancelBodyPartReaction)
				{
					StopHeadPetEmote();
				}
			}
			if (IsPettingBelly(petHitInfo))
			{
				bellyTimer += Time.deltaTime;
				noBellyTimer = 0f;
			}
			else
			{
				noBellyTimer += Time.deltaTime;
				if (noBellyTimer >= timeToCancelBodyPartReaction)
				{
					bellyTimer = 0f;
				}
			}
			if (!isKicking && bellyTimer >= timeToStartBellyReaction)
			{
				StartKicking();
				if (currentPettablePersonality != PettablePersonalityType.DISLIKES_PETTING)
				{
					dogNoisesRef.RequestContentWhine();
				}
				else
				{
					dogNoisesRef.RequestGrowl();
				}
			}
			else if (isKicking && noBellyTimer >= timeToCancelBodyPartReaction)
			{
				StopKicking();
			}
			if (currentPettablePersonality == PettablePersonalityType.DISLIKES_PETTING)
			{
				if (currentPetTime > madEyesTime)
				{
					pettableBrainRef.UpdateAnger(angerAdditionRate * Time.deltaTime);
				}
			}
			else
			{
				pettableBrainRef.UpdateAnger(angerRefliefRate * Time.deltaTime);
				pettableBrainRef.UpdateStress(stressReliefRate * Time.deltaTime);
				pettableBrainRef.UpdateBoredom(boredomReliefRate * Time.deltaTime);
				if (Random.value >= nextPettingVocalizationChance)
				{
					dogNoisesRef.RequestContentWhine();
					float value = Random.value;
					if (value < 0.35f)
					{
						nextPettingVocalizationChance = lowPettingVocalizationChance;
					}
					else if (value < 0.7f)
					{
						nextPettingVocalizationChance = mediumPettingVocalizationChance;
					}
					else
					{
						nextPettingVocalizationChance = highPettingVocalizationChance;
					}
				}
			}
			currentParticleTimer += Time.deltaTime;
			if (currentParticleTimer >= particleRate)
			{
				currentParticleTimer = 0f;
				if (currentPettablePersonality == PettablePersonalityType.DISLIKES_PETTING)
				{
					pettableParticleRef.RequestAngryUpdateParticles();
				}
				else
				{
					pettableParticleRef.RequestHappyUpdateParticles();
				}
			}
			return;
		}
		currentPetTime = 0f;
		currentParticleTimer = 0f;
		if (pettableFaceRef != null)
		{
			pettableFaceRef.CancelEmote();
			if (hasRequestedAngryFace)
			{
				hasRequestedAngryFace = false;
				pettableFaceRef.RequestFace(Face.ANGRY, 1f);
			}
			else
			{
				pettableFaceRef.RequestFace(Face.DEFAULT);
			}
		}
	}

	private bool IsPettingHead(PetHitInfo info)
	{
		if (info.hitBody == null)
		{
			return false;
		}
		return info.hitBody.gameObject.layer == LayerMask.NameToLayer("Head");
	}

	private bool IsPettingBelly(PetHitInfo info)
	{
		if (info.hitBody == null)
		{
			return false;
		}
		if (info.hitBody.gameObject != pettableLegsRef.bodyFront && info.hitBody.gameObject != pettableLegsRef.bodyBack)
		{
			return false;
		}
		if (info.hitNormal == -info.hitBody.transform.up)
		{
			return true;
		}
		return false;
	}

	private void StartKicking()
	{
		RestoreLegs();
		if (currentPettablePersonality != PettablePersonalityType.DISLIKES_PETTING)
		{
			pettableLegsRef.LockStabilitySteps();
		}
		isKicking = true;
		currentLegTime = 0f;
		kickingLegs.AddRange(pettableLegsRef.GetLegsForBodySegment(pettableLegsRef.bodyBack));
	}

	private void StopKicking()
	{
		if (!isPettingCocoon && !isPettingVacuum)
		{
			GiveOut();
			isKicking = false;
			kickingLegs.Clear();
		}
	}

	private void StartHeadPetEmote()
	{
		isPettedEmoting = true;
		pettableFaceRef.RequestEmote(HeadEmote.PETTED);
	}

	private void StopHeadPetEmote()
	{
		if (!isPettingCocoon && !isPettingVacuum)
		{
			isPettedEmoting = false;
			if (pettableFaceRef != null)
			{
				pettableFaceRef.RequestEmote(HeadEmote.PETTED_END);
			}
		}
	}

	private void UpdateKicks()
	{
		for (int i = 0; i < kickingLegs.Count; i++)
		{
			if (!(kickingLegs[i] == null) && !RaycastUtil.StageRaycast(kickingLegs[i].transform.position, Vector3.down, 0.3f))
			{
				float num = currentLegTime - (float)(i / kickingLegs.Count);
				float num2 = CurveUtil.EvaluateAverageCurveWrapperTime(legCurveZ, num, num - Time.fixedDeltaTime);
				pettableLegsRef.TorqueLeg(kickingLegs[i], num2 * Mathf.Min(Random.Range(0f, randomKickJitter) - 5f, 0f) * base.transform.forward, applyLimbCompensation: true, modifyLegStrength: true, restoreTension: true, rawTorque: true);
			}
		}
		currentLegTime += Time.fixedDeltaTime;
		if (currentLegTime >= legCurveZ.GetTotalTime())
		{
			currentLegTime = 0f;
		}
	}

	private void OnEnterPettingMode()
	{
		Vector3 vector = ((!isPettingCocoon && !isPettingVacuum) ? currentPettableDog.GetComponent<LegController>().bodyFront.transform.position : currentPettableDog.GetComponentInChildren<Rigidbody>().transform.position);
		previousMouseX = vector.x;
		previousMouseY = vector.y;
		currentPettableParticles = Object.Instantiate(pettableParticlePrefab).GetComponent<ParticleSystem>();
		ParticleSystem.EmissionModule emission = currentPettableParticles.emission;
		emission.enabled = false;
		hasRequestedAngryFace = false;
		activeFrictionLoop = AudioController.Play(pettingFrictionLoopSound, currentPettableParticles.transform, 0.05f);
		if (!isPettingCocoon && !isPettingVacuum)
		{
			LegController component = currentPettableDog.GetComponent<LegController>();
			pettableBrainRef = currentPettableDog.GetComponent<DoggyBrain>();
			pettableLegsRef = currentPettableDog.GetComponent<LegController>();
			pettableFaceRef = currentPettableDog.GetComponent<FaceController>();
			pettableParticleRef = currentPettableDog.GetComponent<DogParticleController>();
			currentPettablePersonality = pettableBrainRef.GetPersonality().GetPettablePersonalityType();
			if (currentPettablePersonality != PettablePersonalityType.DISLIKES_PETTING)
			{
				component.FreezeMotion();
			}
			currentPettableDog.GetComponent<DogAI>().SetEnabled(enabledVal: false);
			currentPettableDog.GetComponent<BodyBuck>().LockBucks();
			currentPettableDog.GetComponent<DogAI>().LockDistractions();
		}
		else if (isPettingCocoon)
		{
			currentPettableCocoon = currentPettableDog.GetComponent<Cocoon>();
			currentPettableCocoon.ShowPettingGUI();
		}
		else if (isPettingVacuum)
		{
			currentPettableVacuum = currentPettableDog.GetComponent<InteractableRoboVacuum>();
		}
	}

	private void OnExitPettingMode()
	{
		if (currentPetTime >= legsGiveoutTime && currentPettablePersonality != PettablePersonalityType.DISLIKES_PETTING && dogNoisesRef != null)
		{
			dogNoisesRef.RequestGrunt();
		}
		if (currentPetTime >= happyEyesTime && currentPettableCocoon == null && currentPettableVacuum == null)
		{
			if (currentPettablePersonality != PettablePersonalityType.DISLIKES_PETTING)
			{
				GoalsController.ReportGoalEvent(GoalCondition.PET_DOG);
			}
			else
			{
				GoalsController.ReportGoalEvent(GoalCondition.PET_UNPETTABLE_DOG);
			}
		}
		bellyTimer = 0f;
		noBellyTimer = 0f;
		headTimer = 0f;
		noHeadTimer = 0f;
		StopHeadPetEmote();
		currentPetTime = 0f;
		currentParticleTimer = 0f;
		faceChanged = false;
		pettableBrainRef = null;
		pettableParticleRef = null;
		if (pettableFaceRef != null)
		{
			if (hasRequestedAngryFace)
			{
				pettableFaceRef.RequestFace(Face.ANGRY, 1f);
			}
			else
			{
				pettableFaceRef.RequestFace(Face.DEFAULT);
			}
			pettableFaceRef = null;
		}
		hasRequestedAngryFace = false;
		if (currentPettableCocoon != null)
		{
			currentPettableCocoon.HidePettingGUI();
			currentPettableCocoon = null;
		}
		if (currentPettableVacuum != null)
		{
			currentPettableVacuum = null;
		}
		StopKicking();
		if (activeFrictionLoop != null)
		{
			activeFrictionLoop.Stop();
			activeFrictionLoop = null;
		}
		previousPettingSpeeds.Clear();
		Object.Destroy(currentPettableParticles.gameObject);
		if (!isPettingCocoon && !isPettingVacuum)
		{
			if (pettableLegsRef != null)
			{
				pettableLegsRef.UnfreezeMotion();
				pettableLegsRef.UnlockStabilitySteps();
			}
			RestoreLegs();
			if (pettableLegsRef != null)
			{
				pettableLegsRef.GetComponent<BodyBuck>().UnlockBucks();
				pettableLegsRef.GetComponent<DogAI>().UnlockDistractions();
			}
			if (currentPettableDog != null)
			{
				currentPettableDog.GetComponent<DogAI>().SetEnabled(enabledVal: true);
			}
		}
		dogNoisesRef = null;
		pettableLegsRef = null;
		currentPettableDog = null;
		currentPettableCocoon = null;
		currentPettableVacuum = null;
		currentMode = PetMode.SEEKING_TARGET;
		CallCallback();
	}

	private void RestoreLegs()
	{
		if (strengthModKeys.Count <= 0)
		{
			return;
		}
		if (pettableLegsRef != null)
		{
			foreach (GameObject allLeg in pettableLegsRef.GetAllLegs())
			{
				if (strengthModKeys.ContainsKey(allLeg))
				{
					allLeg.GetComponent<Limb>().RequestWakeUp(strengthModKeys[allLeg]);
				}
			}
		}
		strengthModKeys.Clear();
	}

	private void GiveOut()
	{
		RestoreLegs();
		if (currentPettablePersonality == PettablePersonalityType.DISLIKES_PETTING || pettableLegsRef == null)
		{
			return;
		}
		pettableLegsRef.LockStabilitySteps();
		foreach (GameObject allLeg in pettableLegsRef.GetAllLegs())
		{
			if (allLeg != null)
			{
				strengthModKeys[allLeg] = allLeg.GetComponent<Limb>().RequestSleep();
			}
		}
	}

	private void HighlightDog(GameObject dog)
	{
		if (currentHighlightedDog != null)
		{
			RemovePettableHighlight();
		}
		currentHighlightedDog = dog;
		if (!(dog == null))
		{
			Highlighter[] componentsInChildren = dog.GetComponentsInChildren<Highlighter>();
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				componentsInChildren[i].ConstantOn(highlightColor);
			}
		}
	}

	private void RemovePettableHighlight()
	{
		if (!(currentHighlightedDog == null))
		{
			Highlighter[] componentsInChildren = currentHighlightedDog.GetComponentsInChildren<Highlighter>();
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				componentsInChildren[i].ConstantOff();
			}
		}
	}
}
