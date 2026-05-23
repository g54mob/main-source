using System;
using System.Collections;
using System.Collections.Generic;
using RainbowArt.CleanFlatUI;
using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class CookingController : MonoBehaviour
{
	public enum CookingMethod
	{
		Pan = 0,
		Stack = 1,
		Boil = 2
	}

	public Food food;

	public Color plainColor;

	public Color overCookColor;

	public CinemachineCamera panCam;

	public CinemachineCamera stackCam;

	public CinemachineCamera completeCam;

	public CinemachineCamera boilingCam;

	public GameObject cookingPan;

	public ProgressBarSpecialPattern panCookingGage;

	public ProgressBarSpecialPattern boilCookingGage;

	public Transform[] boilingIngredPos;

	private Vector3 panOriginPos;

	private float panFlip;

	private float panRotation;

	private float panMaxOffset = 0.1f;

	private InputSystem_Actions input;

	private bool isClicked;

	private bool isDrag;

	private bool spaced;

	private float sensitivity = 0.1f;

	private int cookingTypeIndex;

	private CookingMethod cookingType;

	private List<GameObject> currentCookingIngredients;

	private LayerMask stackableLayer;

	private GameObject currentPannedFood;

	private GameObject currentStackingFood;

	private GameObject currentBoilingGrabFood;

	private Rigidbody currentBoilingGrabRb;

	public GameObject stackingPlate;

	private int stackingFoodIndex;

	private float stackingCompleteCounter;

	private Vector3 targetPos;

	private int stars;

	public int maxStars;

	private Rigidbody panRb;

	private Vector3 panPos;

	private Quaternion panRot;

	private void Awake()
	{
		input = GameManager.S.player.playerInput;
		currentCookingIngredients = new List<GameObject>();
	}

	private void Start()
	{
		input.Player.MouseLeftClick.started += delegate
		{
			isClicked = true;
		};
		input.Player.MouseLeftClick.canceled += delegate
		{
			isClicked = false;
		};
		input.Player.MouseLeftClick.canceled += delegate
		{
			isDrag = false;
		};
		input.Player.Jump.started += delegate
		{
			spaced = true;
		};
		stackableLayer = LayerMask.GetMask("Stackable");
		GameManager.S.OnCookingDone += GameManager_OnCookingDone;
		GameManager.S.OnToTheNextStep += GameManager_OnToTheNextStep;
		panRb = cookingPan.GetComponent<Rigidbody>();
		cookingPan.transform.localPosition = Vector3.zero;
		panOriginPos = cookingPan.transform.position;
		panPos = panOriginPos;
		panRot = cookingPan.transform.rotation;
		panRb.position = panOriginPos;
		panRb.rotation = panRot;
		targetPos = stackingPlate.transform.position + Vector3.up * 0.3f;
		cookingTypeIndex = 0;
		CookingInit(food);
	}

	private void GameManager_OnToTheNextStep(object sender, EventArgs e)
	{
		completeCam.Priority = 0;
		panCam.Priority = 0;
		stackCam.Priority = 0;
		boilingCam.Priority = 0;
		if (food.recipe[cookingTypeIndex].cookingMethod == CookingMethod.Pan)
		{
			PannedFood component = currentPannedFood.GetComponent<PannedFood>();
			if (component.totalCookingGage / component.maxGage >= 0.7f)
			{
				stars++;
			}
			GameManager.S.PanCookingDone();
			AudioManager.S.StopCookingSFX();
		}
		else if (food.recipe[cookingTypeIndex].cookingMethod == CookingMethod.Stack)
		{
			bool flag = true;
			foreach (GameObject currentCookingIngredient in currentCookingIngredients)
			{
				Vector2 vector = new Vector2(currentCookingIngredient.transform.position.x, currentCookingIngredient.transform.position.z);
				Vector2 vector2 = new Vector2(stackingPlate.transform.position.x, stackingPlate.transform.position.z);
				if ((vector - vector2).magnitude > 0.13f)
				{
					flag = false;
				}
				Debug.Log((vector - vector2).magnitude);
			}
			if (flag)
			{
				stars++;
			}
		}
		else if (food.recipe[cookingTypeIndex].cookingMethod == CookingMethod.Boil)
		{
			if (boilCookingGage.CurrentValue >= 50f)
			{
				stars++;
			}
			GameManager.S.BoilCookingDone();
			AudioManager.S.StopCookingSFX();
		}
		foreach (GameObject currentCookingIngredient2 in currentCookingIngredients)
		{
			UnityEngine.Object.Destroy(currentCookingIngredient2);
		}
		currentCookingIngredients.Clear();
		cookingTypeIndex++;
		CookingInit(food);
	}

	private void GameManager_OnCookingDone(object sender, EventArgs e)
	{
		foreach (GameObject currentCookingIngredient in currentCookingIngredients)
		{
			UnityEngine.Object.Destroy(currentCookingIngredient);
		}
		currentCookingIngredients.Clear();
		UnityEngine.Object.Destroy(this);
	}

	private void Update()
	{
		if (!isDrag && isClicked && !EventSystem.current.IsPointerOverGameObject())
		{
			isDrag = true;
		}
		if (cookingType == CookingMethod.Pan)
		{
			PanControl();
		}
		else if (cookingType == CookingMethod.Stack)
		{
			StackControl();
		}
		else if (cookingType == CookingMethod.Boil)
		{
			BoilControl();
		}
	}

	private void FixedUpdate()
	{
		if (cookingType == CookingMethod.Pan)
		{
			PanMovement();
		}
	}

	private void CookingInit(Food food)
	{
		if (food.recipe.Length == cookingTypeIndex)
		{
			GameManager.S.CookingCompleted(stars, maxStars);
			completeCam.Priority = 2;
			AudioManager.S.PlaySFX(AudioManager.S.tutorialUIOn);
			return;
		}
		cookingType = food.recipe[cookingTypeIndex].cookingMethod;
		if (cookingType == CookingMethod.Pan)
		{
			GameManager.S.PanCookingStart();
			panCam.Priority = 2;
			GameObject[] array = food.recipe[cookingTypeIndex].food;
			for (int i = 0; i < array.Length; i++)
			{
				_ = array[i];
				currentPannedFood = UnityEngine.Object.Instantiate(food.recipe[cookingTypeIndex].food[0], panOriginPos + Vector3.up * 0.4f, Quaternion.identity);
				Debug.Log(panOriginPos);
				Debug.Log(currentPannedFood.transform.position);
				Rigidbody component = currentPannedFood.GetComponent<Rigidbody>();
				component.linearVelocity = Vector3.zero;
				component.angularVelocity = Vector3.zero;
				StartCoroutine(InitPhysics(component));
				Physics.SyncTransforms();
				PannedFood pannedFood = currentPannedFood.AddComponent<PannedFood>();
				pannedFood.plainColor = plainColor;
				pannedFood.overCookedColor = overCookColor;
				pannedFood.cookingGage = panCookingGage;
				currentCookingIngredients.Add(currentPannedFood);
			}
			panCookingGage.CurrentValue = 0f;
			panRb.MovePosition(panOriginPos);
		}
		else if (cookingType == CookingMethod.Stack)
		{
			GameManager.S.StackCookingStart();
			stackCam.Priority = 2;
			currentStackingFood = UnityEngine.Object.Instantiate(food.recipe[cookingTypeIndex].food[0], stackingPlate.transform.position + Vector3.up * 1f, Quaternion.identity);
			currentStackingFood.GetComponent<Rigidbody>().isKinematic = true;
			currentCookingIngredients.Add(currentStackingFood);
		}
		else if (cookingType == CookingMethod.Boil)
		{
			GameManager.S.BoilCookingStart();
			boilingCam.Priority = 2;
			boilCookingGage.CurrentValue = 0f;
			int num = 0;
			GameObject[] array = food.recipe[cookingTypeIndex].food;
			for (int i = 0; i < array.Length; i++)
			{
				GameObject gameObject = UnityEngine.Object.Instantiate(array[i], boilingIngredPos[num].transform.position, Quaternion.Euler(UnityEngine.Random.Range(0, 360), UnityEngine.Random.Range(0, 360), UnityEngine.Random.Range(0, 360)));
				gameObject.GetComponent<Rigidbody>();
				Buoyancy buoyancy = gameObject.AddComponent<Buoyancy>();
				buoyancy.density = 1000f;
				currentCookingIngredients.Add(gameObject);
				buoyancy.numOfIngred = food.recipe[cookingTypeIndex].food.Length;
				num++;
			}
			AudioManager.S.PlayCookingSFX(AudioManager.S.cookingBoil, 1f);
		}
	}

	private void PanControl()
	{
		Vector2 vector = Vector2.zero;
		if (isDrag)
		{
			if (Cursor.visible)
			{
				Cursor.visible = false;
			}
			vector = GameManager.S.player.GetMouseInput();
		}
		else if (!Cursor.visible)
		{
			Cursor.visible = true;
		}
		Vector3 vector2 = new Vector3(vector.y, 0f, 0f - vector.x) * sensitivity;
		if (spaced)
		{
			panFlip = panMaxOffset * 2f;
			panRotation = -30f;
			spaced = false;
		}
		if (panFlip > 0f)
		{
			panFlip -= Time.deltaTime * 2f;
		}
		if (panRotation < 0f)
		{
			panRotation += Time.deltaTime * 60f;
		}
		Vector3 vector3 = cookingPan.transform.position + vector2;
		float x = Mathf.Clamp(vector3.x, panOriginPos.x - panMaxOffset, panOriginPos.x + panMaxOffset);
		float z = Mathf.Clamp(vector3.z, panOriginPos.z - panMaxOffset, panOriginPos.z + panMaxOffset);
		float y = Mathf.Max(panOriginPos.y, panOriginPos.y + panFlip);
		panPos = new Vector3(x, y, z);
		panRot = Quaternion.Euler(0f, cookingPan.transform.eulerAngles.y, panRotation);
	}

	private void PanMovement()
	{
		panPos = Vector3.Lerp(cookingPan.transform.position, panPos, Time.fixedDeltaTime * 10f);
		panRot = Quaternion.Lerp(cookingPan.transform.rotation, panRot, Time.fixedDeltaTime * 10f);
		panRb.MovePosition(panPos);
		panRb.MoveRotation(panRot);
	}

	private void StackControl()
	{
		if (currentStackingFood == null)
		{
			return;
		}
		Vector2 vector = Mouse.current.position.ReadValue();
		if (Physics.Raycast(Camera.main.ScreenPointToRay(vector), out var hitInfo, 2f, stackableLayer))
		{
			targetPos = new Vector3(hitInfo.point.x, stackingPlate.transform.position.y + 0.3f, hitInfo.point.z);
		}
		currentStackingFood.transform.position = Vector3.Lerp(currentStackingFood.transform.position, targetPos, Time.deltaTime * 5f);
		if (Mouse.current.leftButton.wasPressedThisFrame && !EventSystem.current.IsPointerOverGameObject())
		{
			stackingFoodIndex++;
			currentStackingFood.GetComponent<Rigidbody>().isKinematic = false;
			GameManager.S.FoodStacked();
			if (stackingFoodIndex == food.recipe[cookingTypeIndex].food.Length)
			{
				currentStackingFood = null;
				StartCoroutine(DelayedNextStep());
				return;
			}
			currentStackingFood = UnityEngine.Object.Instantiate(food.recipe[cookingTypeIndex].food[stackingFoodIndex], stackingPlate.transform.position + Vector3.up * 1f, Quaternion.identity);
			currentStackingFood.GetComponent<Rigidbody>().isKinematic = true;
			currentStackingFood.AddComponent<StackingFoodSound>();
			currentCookingIngredients.Add(currentStackingFood);
		}
	}

	private void BoilControl()
	{
		if (input.Player.MouseLeftClick.WasPressedThisFrame())
		{
			TryPickObject();
		}
		if (currentBoilingGrabFood != null)
		{
			DragObject();
			if (input.Player.MouseLeftClick.WasReleasedThisFrame())
			{
				DropObject();
			}
		}
	}

	private void TryPickObject()
	{
		Vector2 vector = Mouse.current.position.ReadValue();
		if (Physics.Raycast(Camera.main.ScreenPointToRay(vector), out var hitInfo, 3f, LayerMask.GetMask("BoilingIngred")))
		{
			currentBoilingGrabFood = hitInfo.transform.root.gameObject;
			currentBoilingGrabRb = hitInfo.transform.root.gameObject.GetComponent<Rigidbody>();
			if (currentBoilingGrabRb != null)
			{
				currentBoilingGrabRb.isKinematic = true;
			}
			Cursor.visible = false;
		}
	}

	private void DragObject()
	{
		Vector2 vector = Mouse.current.position.ReadValue();
		if (Physics.Raycast(Camera.main.ScreenPointToRay(vector), out var hitInfo, 2f, stackableLayer))
		{
			targetPos = new Vector3(hitInfo.point.x, 1.95f, hitInfo.point.z);
		}
		currentBoilingGrabFood.transform.position = Vector3.Lerp(currentBoilingGrabFood.transform.position, targetPos, Time.deltaTime * 5f);
	}

	private void DropObject()
	{
		if (currentBoilingGrabRb != null)
		{
			currentBoilingGrabRb.isKinematic = false;
			currentBoilingGrabRb = null;
		}
		currentBoilingGrabFood = null;
		Cursor.visible = true;
	}

	private void OnDestroy()
	{
		GameManager.S.OnCookingDone -= GameManager_OnCookingDone;
		GameManager.S.OnToTheNextStep -= GameManager_OnToTheNextStep;
	}

	private void CookingCompleted()
	{
	}

	private IEnumerator DelayedNextStep()
	{
		yield return new WaitForSeconds(1f);
		GameManager.S.ToTheNextStep();
	}

	private IEnumerator InitPhysics(Rigidbody rb)
	{
		yield return new WaitForFixedUpdate();
		rb.collisionDetectionMode = CollisionDetectionMode.Continuous;
	}
}
