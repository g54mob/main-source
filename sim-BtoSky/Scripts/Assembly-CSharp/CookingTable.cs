using System;
using Unity.Cinemachine;
using Unity.VisualScripting;
using UnityEngine;

public class CookingTable : Furniture
{
	[SerializeField]
	private CinemachineCamera craftCam;

	[SerializeField]
	private CinemachineCamera panCam;

	[SerializeField]
	private CinemachineCamera stackCam;

	[SerializeField]
	private CinemachineCamera completeCam;

	[SerializeField]
	private CinemachineCamera boilingCam;

	[SerializeField]
	private RenderTexture rtCooking;

	[SerializeField]
	private RenderTexture rtVideo;

	[SerializeField]
	private GameObject pan;

	[SerializeField]
	private GameObject stackPlate;

	[SerializeField]
	private GameObject foodMount;

	[SerializeField]
	private Transform[] boilingIngredPos;

	[SerializeField]
	private GameObject[] boilingEffects;

	[SerializeField]
	private GameObject panEffect;

	public Color plainColor;

	public Color overCookColor;

	private GameObject selectedMenuGO;

	private Food selectedFood;

	private bool isMenuSelecting;

	private int maxStars;

	private void Start()
	{
		GameManager.S.OnCookingTableUnlocked += S_OnCookingTableUnlocked;
		GameManager.S.OnCookingDone += GameManager_OnCookingDone;
		GameManager.S.OnCookingStart += GameManager_OnCookingStart;
		GameManager.S.OnMenuSelected += GameManager_OnMenuSelected;
		GameManager.S.OnStackCookingStart += S_OnStackCookingStart;
		GameManager.S.OnAddBounsOnFood += Gm_OnAddBounsOnFood;
		GameManager.S.OnBoilCookingStart += S_OnBoilCookingStart;
		GameManager.S.OnBoilCookingDone += S_OnBoilCookingDone;
		GameManager.S.OnPanCookingStart += S_OnPanCookingStart;
		GameManager.S.OnPanCookingDone += S_OnPanCookingDone;
		GameManager.S.OnCookingCompleted += S_OnCookingCompleted;
		if (GameManager.S.isCookingTableUnlocked)
		{
			base.gameObject.layer = LayerMask.NameToLayer("Interactable");
		}
		else
		{
			base.gameObject.layer = LayerMask.NameToLayer("Default");
		}
	}

	private void S_OnCookingTableUnlocked()
	{
		base.gameObject.layer = LayerMask.NameToLayer("Interactable");
	}

	private void S_OnCookingCompleted(object sender, GameManager.OnCookingCompletedArg e)
	{
		Graphics.CopyTexture(rtCooking, rtVideo);
	}

	private void S_OnPanCookingDone()
	{
		panEffect.SetActive(value: false);
	}

	private void S_OnPanCookingStart(object sender, EventArgs e)
	{
		panEffect.SetActive(value: true);
	}

	private void S_OnBoilCookingDone(object sender, EventArgs e)
	{
		GameObject[] array = boilingEffects;
		for (int i = 0; i < array.Length; i++)
		{
			array[i].SetActive(value: false);
		}
	}

	private void S_OnBoilCookingStart(object sender, EventArgs e)
	{
		GameObject[] array = boilingEffects;
		for (int i = 0; i < array.Length; i++)
		{
			array[i].SetActive(value: true);
		}
	}

	private void OnDestroy()
	{
		GameManager.S.OnCookingTableUnlocked -= S_OnCookingTableUnlocked;
		GameManager.S.OnCookingDone -= GameManager_OnCookingDone;
		GameManager.S.OnCookingStart -= GameManager_OnCookingStart;
		GameManager.S.OnMenuSelected -= GameManager_OnMenuSelected;
		GameManager.S.OnStackCookingStart -= S_OnStackCookingStart;
		GameManager.S.OnAddBounsOnFood -= Gm_OnAddBounsOnFood;
		GameManager.S.OnBoilCookingStart -= S_OnBoilCookingStart;
		GameManager.S.OnBoilCookingDone -= S_OnBoilCookingDone;
		GameManager.S.OnPanCookingStart -= S_OnPanCookingStart;
		GameManager.S.OnPanCookingDone -= S_OnPanCookingDone;
		GameManager.S.OnCookingCompleted -= S_OnCookingCompleted;
	}

	private void Gm_OnAddBounsOnFood(object sender, GameManager.OnAddBounsOnFoodArg e)
	{
		selectedMenuGO.gameObject.SetActive(value: true);
		selectedMenuGO.GetComponent<Rigidbody>().isKinematic = false;
		isMenuSelecting = false;
		foodMount.gameObject.SetActive(value: true);
		selectedMenuGO.transform.SetParent(null);
		selectedMenuGO.transform.rotation = Quaternion.identity;
		Food component = selectedMenuGO.GetComponent<Food>();
		component.hungerGain += e.hungerGainBouns;
		component.knowledgeGain += e.knowledgeGainBouns;
		component.value += e.valueBouns;
		selectedMenuGO = null;
	}

	private void S_OnStackCookingStart(object sender, EventArgs e)
	{
		foodMount.SetActive(value: true);
	}

	private void GameManager_OnMenuSelected(object sender, GameManager.OnMenuSelectedArg e)
	{
		if (selectedMenuGO != null)
		{
			UnityEngine.Object.Destroy(selectedMenuGO);
		}
		selectedMenuGO = UnityEngine.Object.Instantiate(e.menuGO, foodMount.transform);
		selectedMenuGO.GetComponent<Rigidbody>().isKinematic = true;
		isMenuSelecting = true;
		maxStars = e.maxStars;
	}

	private void GameManager_OnCookingStart(object sender, GameManager.OnCookingStartArg e)
	{
		CookingController cookingController = GameManager.S.player.AddComponent<CookingController>();
		cookingController.cookingPan = pan;
		cookingController.food = e.food;
		cookingController.panCam = panCam;
		cookingController.stackCam = stackCam;
		cookingController.stackingPlate = stackPlate;
		cookingController.completeCam = completeCam;
		cookingController.plainColor = plainColor;
		cookingController.overCookColor = overCookColor;
		cookingController.panCookingGage = e.panCookingGage;
		cookingController.boilingIngredPos = boilingIngredPos;
		cookingController.boilingCam = boilingCam;
		cookingController.boilCookingGage = e.boilCookingGage;
		cookingController.maxStars = maxStars;
		foodMount.gameObject.SetActive(value: false);
		selectedMenuGO.gameObject.SetActive(value: false);
		craftCam.Priority = 0;
		isMenuSelecting = false;
	}

	private void GameManager_OnCookingDone(object sender, EventArgs e)
	{
		craftCam.Priority = 0;
		panCam.Priority = 0;
		stackCam.Priority = 0;
		completeCam.Priority = 0;
		GameManager.S.player.canControl = true;
		Camera.main.cullingMask |= 1 << LayerMask.NameToLayer("Player");
		Cursor.visible = false;
		isMenuSelecting = false;
		if (selectedMenuGO != null)
		{
			UnityEngine.Object.Destroy(selectedMenuGO);
		}
		foodMount.gameObject.SetActive(value: true);
	}

	private void Update()
	{
		if (isMenuSelecting)
		{
			foodMount.transform.Rotate(0f, 45f * Time.deltaTime, 0f);
		}
	}

	public override void Interact()
	{
		base.Interact();
		if (GameManager.S.isCookingTableUnlocked)
		{
			Camera.main.cullingMask &= ~(1 << LayerMask.NameToLayer("Player"));
			Cursor.visible = true;
			GameManager.S.InteractingWithCookingTable();
			craftCam.Priority = 2;
			GameManager.S.player.canControl = false;
		}
	}
}
