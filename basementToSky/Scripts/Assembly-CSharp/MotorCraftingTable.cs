using System;
using RainbowArt.CleanFlatUI;
using Unity.Cinemachine;
using Unity.VisualScripting;
using UnityEngine;

public class MotorCraftingTable : Furniture
{
	public ProgressBarSpecialPattern boilingProgressbar;

	[SerializeField]
	private CinemachineCamera craftCam;

	public CinemachineCamera mensurationCam;

	public CinemachineCamera grindCam;

	public CinemachineCamera boilCam;

	public CinemachineCamera castingCam;

	public CinemachineCamera testingCam;

	public CinemachineCamera completeCam;

	public MensurationScale mensurationScale;

	public GameObject castingBowl;

	public Transform PowderBowlPos;

	public Blender blender;

	public Transform[] mensurationIngredientsPos;

	public Transform motorTestingPos;

	public Transform lighterPos;

	public GameObject lighterPrefab;

	public Transform spatulaPos;

	public GameObject boiledPowderGO;

	public GameObject spatulaPrefab;

	[SerializeField]
	private GameObject motorMount;

	public GameObject selectedMotorGO;

	private GameObject selcetedMotorGOPrefab;

	public GameObject explodeEffect;

	[SerializeField]
	private Renderer boilPowderRenderer;

	private MaterialPropertyBlock mpb;

	[SerializeField]
	private GameObject[] unlockGOs;

	public static event Action OnMotorSetted;

	private void Awake()
	{
		if (boilPowderRenderer != null)
		{
			mpb = new MaterialPropertyBlock();
		}
	}

	private void Start()
	{
		GameManager.S.OnMotorCraftingDone += Gm_OnMotorCraftingDone;
		GameManager.S.OnMotorSelected += Gm_OnMotorSelected;
		GameManager.S.OnStartMotorCrafting += Gm_OnStartMotorCrafting;
		GameManager.S.OnMotorCastingStart += Gm_OnMotorCastingStart;
		GameManager.S.OnMotorCraftingCompleted += Gm_OnMotorCraftingCompleted;
		GameManager.S.OnGrainExploded += Gm_OnGrainExploded;
		QuestManager.S.OnPowerRocketUnlocked += S_OnPowerRocketUnlocked;
		if (GameManager.S.isPowderRocketUnlocked)
		{
			base.gameObject.layer = LayerMask.NameToLayer("Interactable");
			GameObject[] array = unlockGOs;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].SetActive(value: true);
			}
		}
		else
		{
			base.gameObject.layer = LayerMask.NameToLayer("Default");
			GameObject[] array = unlockGOs;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].SetActive(value: false);
			}
		}
	}

	private void S_OnPowerRocketUnlocked()
	{
		base.gameObject.layer = LayerMask.NameToLayer("Interactable");
		GameManager.S.isMotorCraftingTableUnlock = true;
		GameObject[] array = unlockGOs;
		for (int i = 0; i < array.Length; i++)
		{
			array[i].SetActive(value: true);
		}
	}

	private void OnDestroy()
	{
		GameManager.S.OnMotorCraftingDone -= Gm_OnMotorCraftingDone;
		GameManager.S.OnMotorSelected -= Gm_OnMotorSelected;
		GameManager.S.OnStartMotorCrafting -= Gm_OnStartMotorCrafting;
		GameManager.S.OnMotorCastingStart -= Gm_OnMotorCastingStart;
		GameManager.S.OnMotorCraftingCompleted -= Gm_OnMotorCraftingCompleted;
		GameManager.S.OnGrainExploded -= Gm_OnGrainExploded;
		QuestManager.S.OnPowerRocketUnlocked -= S_OnPowerRocketUnlocked;
	}

	private void Gm_OnGrainExploded(object sender, EventArgs e)
	{
		UnityEngine.Object.Instantiate(explodeEffect, motorTestingPos.position, Quaternion.identity);
	}

	private void Gm_OnMotorCraftingCompleted(object sender, EventArgs e)
	{
		craftCam.Priority = 0;
		mensurationCam.Priority = 0;
		grindCam.Priority = 0;
		castingCam.Priority = 0;
		testingCam.Priority = 0;
		selectedMotorGO.transform.SetParent(motorMount.transform);
		selectedMotorGO.transform.localPosition = Vector3.zero;
		selectedMotorGO.transform.localRotation = Quaternion.identity;
		selectedMotorGO.SetActive(value: true);
	}

	private void Gm_OnMotorCastingStart(object sender, EventArgs e)
	{
		selectedMotorGO.SetActive(value: true);
		selectedMotorGO.GetComponent<CurrentCraftingRocketGrain>().CastingStart();
	}

	private void Gm_OnStartMotorCrafting(object sender, GameManager.OnStartMotorCraftingArg e)
	{
		MotorCraftingController motorCraftingController = GameManager.S.player.AddComponent<MotorCraftingController>();
		motorCraftingController.rocketMotor = selectedMotorGO.GetComponent<BasicGrain>();
		motorCraftingController.rocketMotor.powerCurve = e.grainGeometryCurve;
		motorCraftingController.rocketMotor.thrustPow += motorCraftingController.rocketMotor.fuel.thrustPow;
		motorCraftingController.rocketMotor.thrustPow += motorCraftingController.rocketMotor.oxidizer.thrustPow;
		motorCraftingController.rocketMotor.launchDuration += motorCraftingController.rocketMotor.fuel.duration;
		motorCraftingController.rocketMotor.launchDuration += motorCraftingController.rocketMotor.oxidizer.duration;
		motorCraftingController.rocketMotor.mass += motorCraftingController.rocketMotor.fuel.mass;
		motorCraftingController.rocketMotor.mass += motorCraftingController.rocketMotor.oxidizer.mass;
		motorCraftingController.rocketMotor.thrustPow *= motorCraftingController.rocketMotor.multiplier;
		CurrentCraftingRocketGrain component = selectedMotorGO.GetComponent<CurrentCraftingRocketGrain>();
		component.stick = motorCraftingController.rocketMotor.stick;
		component.propellant = motorCraftingController.rocketMotor.propellantRenderer;
		motorCraftingController.motorCraftingTable = this;
		motorCraftingController.grindGage = e.grindGage;
		selectedMotorGO.SetActive(value: false);
		craftCam.Priority = 0;
	}

	private void Gm_OnMotorSelected(object sender, GameManager.OnMotorSelectedArg e)
	{
		if (selectedMotorGO != null)
		{
			UnityEngine.Object.Destroy(selectedMotorGO);
		}
		selectedMotorGO = UnityEngine.Object.Instantiate(e.motorGO, motorMount.transform);
		selcetedMotorGOPrefab = e.motorGO;
		BasicGrain component = selectedMotorGO.GetComponent<BasicGrain>();
		CurrentCraftingRocketGrain currentCraftingRocketGrain = selectedMotorGO.AddComponent<CurrentCraftingRocketGrain>();
		currentCraftingRocketGrain.stick = component.stick;
		currentCraftingRocketGrain.propellant = component.propellantRenderer;
		currentCraftingRocketGrain.ps = component.ps;
		currentCraftingRocketGrain.motorPrefab = e.motorGO;
		MotorCraftingTable.OnMotorSetted?.Invoke();
	}

	private void Gm_OnMotorCraftingDone(object sender, EventArgs e)
	{
		craftCam.Priority = 0;
		mensurationCam.Priority = 0;
		grindCam.Priority = 0;
		castingCam.Priority = 0;
		completeCam.Priority = 0;
		testingCam.Priority = 0;
		GameManager.S.player.canControl = true;
		Camera.main.cullingMask |= 1 << LayerMask.NameToLayer("Player");
		Cursor.visible = false;
		selectedMotorGO.GetComponent<CurrentCraftingRocketGrain>().Interact();
		selectedMotorGO = null;
		selcetedMotorGOPrefab = null;
		if (selectedMotorGO != null)
		{
			UnityEngine.Object.Destroy(selectedMotorGO);
		}
	}

	private void Update()
	{
	}

	public override void Interact()
	{
		Camera.main.cullingMask &= ~(1 << LayerMask.NameToLayer("Player"));
		Cursor.visible = true;
		GameManager.S.MotorCraftingTableInteracted();
		craftCam.Priority = 2;
		GameManager.S.player.canControl = false;
		AudioManager.S.PlaySFX(AudioManager.S.craftingTableInteract);
	}

	public void SetBoilPowderColor(Color colr)
	{
		boilPowderRenderer.GetPropertyBlock(mpb);
		mpb.SetColor("_PowderColor", colr);
		boilPowderRenderer.SetPropertyBlock(mpb);
	}
}
