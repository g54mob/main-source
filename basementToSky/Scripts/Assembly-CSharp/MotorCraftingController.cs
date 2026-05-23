using System;
using System.Collections.Generic;
using RainbowArt.CleanFlatUI;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class MotorCraftingController : MonoBehaviour
{
	public enum MotorCraftingMethod
	{
		Mensuration = 0,
		Grind = 1,
		Boil = 2,
		Casting = 3,
		Testing = 4
	}

	public BasicGrain rocketMotor;

	public MotorCraftingTable motorCraftingTable;

	public ProgressBarPattern grindGage;

	private CurrentMensurationIngredient currentMensurationIngredient;

	private InputSystem_Actions input;

	private Lighter currentLighter;

	private bool isClicked;

	private bool isDrag;

	private bool spaced;

	private float sensitivity = 0.2f;

	private float spatulaMaxOffset = 0.15f;

	private int craftingMethodIndex;

	private MotorCraftingMethod craftingMethod;

	private List<GameObject> currentHandledIngredients;

	private LayerMask stackableLayer;

	private Vector3 targetPos;

	private bool fail;

	public static event Action<string> OnRecipeOnNote;

	private void Awake()
	{
		input = GameManager.S.player.playerInput;
	}

	private void Start()
	{
		fail = false;
		craftingMethodIndex = 0;
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
		input.Player.Jump.canceled += delegate
		{
			spaced = false;
		};
		currentHandledIngredients = new List<GameObject>();
		stackableLayer = LayerMask.GetMask("Stackable");
		GameManager.S.OnMotorToTheNextStep += Gm_OnMotorToTheNextStep;
		GameManager.S.OnMotorCraftingDone += Gm_OnMotorCraftingDone;
		GameManager.S.OnBoilCompleted += Gm_OnBoilCompleted;
		CraftingInit(rocketMotor);
	}

	private void Gm_OnBoilCompleted(object sender, EventArgs e)
	{
	}

	private void Gm_OnMotorCraftingDone(object sender, EventArgs e)
	{
		foreach (GameObject currentHandledIngredient in currentHandledIngredients)
		{
			UnityEngine.Object.Destroy(currentHandledIngredient);
		}
		currentHandledIngredients.Clear();
		UnityEngine.Object.Destroy(this);
	}

	public bool IsGoodRatio(float fuel, float oxidizer)
	{
		float num = rocketMotor.fuel.requiredGram;
		float num2 = rocketMotor.oxidizer.requiredGram;
		float num3 = 5f;
		bool num4 = fuel >= num - num3 && fuel <= num + num3;
		bool flag = oxidizer >= num2 - num3 && oxidizer <= num2 + num3;
		return num4 && flag;
	}

	private void Gm_OnMotorToTheNextStep(object sender, EventArgs e)
	{
		Cursor.visible = true;
		motorCraftingTable.mensurationCam.Priority = 0;
		motorCraftingTable.grindCam.Priority = 0;
		motorCraftingTable.castingCam.Priority = 0;
		motorCraftingTable.testingCam.Priority = 0;
		motorCraftingTable.boilCam.Priority = 0;
		if (craftingMethodIndex == 0)
		{
			fail = !IsGoodRatio(motorCraftingTable.mensurationScale.ingred[0], motorCraftingTable.mensurationScale.ingred[1]);
			motorCraftingTable.mensurationScale.ClearScale();
		}
		else if (craftingMethodIndex == 1)
		{
			grindGage.CurrentValue = 0f;
			motorCraftingTable.blender.StopShake();
			if (motorCraftingTable.blender.currentGage / motorCraftingTable.blender.maxGage < 0.7f)
			{
				fail = true;
			}
		}
		else if (craftingMethodIndex == 2)
		{
			if (motorCraftingTable.boilingProgressbar.CurrentValue < 60f)
			{
				fail = true;
			}
		}
		else if (craftingMethodIndex != 3)
		{
			_ = craftingMethodIndex;
			_ = 4;
		}
		foreach (GameObject currentHandledIngredient in currentHandledIngredients)
		{
			UnityEngine.Object.Destroy(currentHandledIngredient);
		}
		currentHandledIngredients.Clear();
		motorCraftingTable.selectedMotorGO.GetComponent<CurrentCraftingRocketGrain>().fail = fail;
		craftingMethodIndex++;
		AudioManager.S.StopCookingSFX();
		CraftingInit(rocketMotor);
	}

	private void Update()
	{
		if (!isDrag && isClicked && !EventSystem.current.IsPointerOverGameObject())
		{
			isDrag = true;
		}
		if (craftingMethodIndex == 0)
		{
			MensurationControl();
		}
		else if (craftingMethodIndex == 1)
		{
			GrindControl();
		}
		else if (craftingMethodIndex == 3)
		{
			CastingControl();
		}
		else if (craftingMethodIndex == 4)
		{
			TestingControl();
		}
		else if (craftingMethodIndex == 2)
		{
			BoilingControl();
		}
	}

	private void CraftingInit(BasicGrain motor)
	{
		if (craftingMethodIndex == 5)
		{
			GameManager.S.MotorCraftingCompleted();
			motorCraftingTable.completeCam.Priority = 2;
		}
		else if (craftingMethodIndex == 0)
		{
			GameManager.S.MotorMensurationStart();
			motorCraftingTable.mensurationCam.Priority = 2;
			int num = 0;
			string text = "";
			GameObject gameObject = UnityEngine.Object.Instantiate(motor.fuel.itemPrefab, motorCraftingTable.mensurationIngredientsPos[num].position, motorCraftingTable.mensurationIngredientsPos[num].rotation);
			CurrentMensurationIngredient obj = gameObject.AddComponent<CurrentMensurationIngredient>();
			UnityEngine.Object.Destroy(gameObject.GetComponent<Outline>());
			obj.isMensuration = true;
			obj.itemIndex = num;
			gameObject.GetComponentInChildren<Rigidbody>().isKinematic = true;
			gameObject.GetComponent<BoxCollider>().enabled = true;
			MotorIngredientItem component = gameObject.GetComponent<MotorIngredientItem>();
			text = $"- {component.itemNameTemp.GetLocalizedString()} {component.requiredGram}g";
			currentHandledIngredients.Add(gameObject);
			num++;
			GameObject gameObject2 = UnityEngine.Object.Instantiate(motor.oxidizer.itemPrefab, motorCraftingTable.mensurationIngredientsPos[num].position, motorCraftingTable.mensurationIngredientsPos[num].rotation);
			CurrentMensurationIngredient obj2 = gameObject2.AddComponent<CurrentMensurationIngredient>();
			UnityEngine.Object.Destroy(gameObject2.GetComponent<Outline>());
			obj2.isMensuration = true;
			obj2.itemIndex = num;
			gameObject2.GetComponentInChildren<Rigidbody>().isKinematic = true;
			gameObject2.GetComponent<BoxCollider>().enabled = true;
			MotorIngredientItem component2 = gameObject2.GetComponent<MotorIngredientItem>();
			text = text + "\n\n" + $"- {component2.itemNameTemp.GetLocalizedString()} {component2.requiredGram}g";
			currentHandledIngredients.Add(gameObject2);
			num++;
			MotorCraftingController.OnRecipeOnNote?.Invoke(text);
		}
		else if (craftingMethodIndex == 1)
		{
			GameManager.S.MotorGrindStart();
			motorCraftingTable.grindCam.Priority = 2;
			motorCraftingTable.blender.grindGage = grindGage;
			motorCraftingTable.blender.grindGage.CurrentValue = 0f;
			motorCraftingTable.blender.InitBlender();
		}
		else if (craftingMethodIndex == 3)
		{
			GameManager.S.MotorCastingStart();
			motorCraftingTable.castingCam.Priority = 2;
			GameObject gameObject3 = UnityEngine.Object.Instantiate(motorCraftingTable.castingBowl, motorCraftingTable.PowderBowlPos.position, motorCraftingTable.PowderBowlPos.rotation);
			CurrentMensurationIngredient obj3 = gameObject3.AddComponent<CurrentMensurationIngredient>();
			MotorIngredientItem component3 = gameObject3.GetComponent<MotorIngredientItem>();
			Color liquidColor = motor.liquidColor;
			obj3.SetCastingColor(liquidColor);
			component3.SetPowderColor(liquidColor);
			obj3.isMensuration = false;
			currentHandledIngredients.Add(gameObject3);
		}
		else if (craftingMethodIndex == 4)
		{
			CurrentCraftingRocketGrain component4 = motor.GetComponent<CurrentCraftingRocketGrain>();
			component4.powerCurve = CombineWithLagueNoise(20, motor.powerCurve, motor.fuel.curve, motor.oxidizer.curve);
			rocketMotor.powerCurve = component4.powerCurve;
			GameManager.S.MotorTestingStart(component4);
			Cursor.visible = true;
			motorCraftingTable.testingCam.Priority = 2;
			motorCraftingTable.selectedMotorGO.transform.SetParent(motorCraftingTable.motorTestingPos.transform);
			motorCraftingTable.selectedMotorGO.transform.localPosition = Vector3.zero;
			motorCraftingTable.selectedMotorGO.transform.localRotation = Quaternion.identity;
			GameObject item = UnityEngine.Object.Instantiate(motorCraftingTable.lighterPrefab, motorCraftingTable.lighterPos.position, motorCraftingTable.lighterPos.rotation);
			currentHandledIngredients.Add(item);
		}
		else if (craftingMethodIndex == 2)
		{
			GameManager.S.MotorIngredBoilStart();
			motorCraftingTable.boilCam.Priority = 2;
			GameObject gameObject4 = UnityEngine.Object.Instantiate(motorCraftingTable.spatulaPrefab, motorCraftingTable.spatulaPos.position, motorCraftingTable.spatulaPos.rotation);
			gameObject4.GetComponent<BoilCoverage>().progressBar = motorCraftingTable.boilingProgressbar;
			motorCraftingTable.boilingProgressbar.CurrentValue = 0f;
			currentHandledIngredients.Add(gameObject4);
			motorCraftingTable.boiledPowderGO.SetActive(value: true);
			Color liquidColor2 = motor.liquidColor;
			motorCraftingTable.SetBoilPowderColor(liquidColor2);
			AudioManager.S.PlayCookingSFX(AudioManager.S.powderBoil, 0.5f);
		}
	}

	public AnimationCurve CombineCurves(AnimationCurve geo, AnimationCurve fuel, AnimationCurve ox)
	{
		AnimationCurve animationCurve = new AnimationCurve();
		int num = 20;
		for (int i = 0; i <= num; i++)
		{
			float time = (float)i / (float)num;
			float num2 = geo.Evaluate(time);
			float num3 = fuel.Evaluate(time);
			float num4 = ox.Evaluate(time);
			float value = num2 * 0.5f + num3 * 0.25f + num4 * 0.25f;
			animationCurve.AddKey(time, value);
		}
		for (int j = 0; j < animationCurve.length; j++)
		{
			animationCurve.SmoothTangents(j, 0f);
		}
		return animationCurve;
	}

	public AnimationCurve CombineWithLagueNoise(int resolution, AnimationCurve geo, AnimationCurve fuel, AnimationCurve ox)
	{
		AnimationCurve animationCurve = new AnimationCurve();
		float num = Mathf.Max((geo.length > 0) ? geo.keys[geo.length - 1].time : 0f, (fuel.length > 0) ? fuel.keys[fuel.length - 1].time : 0f, (ox.length > 0) ? ox.keys[ox.length - 1].time : 0f);
		float num2 = 0.5f;
		float num3 = 0.2f;
		for (int i = 0; i <= resolution; i++)
		{
			float time = num / (float)resolution * (float)i;
			float num4 = geo.Evaluate(time);
			float num5 = (fuel.Evaluate(time) - 0.5f) * 2f;
			float num6 = (ox.Evaluate(time) - 0.5f) * 2f;
			float num7 = 1f;
			float num8 = 0f;
			float num9 = 0f;
			num8 += num5 * num7;
			num9 += num7;
			num7 *= num2;
			num8 += num6 * num7;
			num9 += num7;
			num8 /= num9;
			float num10 = 1f + num8 * num3;
			float b = num4 * num10;
			animationCurve.AddKey(time, Mathf.Max(0f, b));
		}
		for (int j = 0; j < animationCurve.length; j++)
		{
			animationCurve.SmoothTangents(j, 0f);
		}
		return animationCurve;
	}

	private void MensurationControl()
	{
		if (input.Player.MouseLeftClick.WasPressedThisFrame())
		{
			Vector2 vector = Mouse.current.position.ReadValue();
			if (Physics.Raycast(Camera.main.ScreenPointToRay(vector), out var hitInfo, 2f, LayerMask.GetMask("Interactable")))
			{
				if (hitInfo.transform.TryGetComponent<CurrentMensurationIngredient>(out var component))
				{
					currentMensurationIngredient = component;
					component.isHandled = true;
					Cursor.visible = false;
				}
				else
				{
					currentMensurationIngredient = null;
				}
			}
			else
			{
				currentMensurationIngredient = null;
			}
		}
		if (!(currentMensurationIngredient != null))
		{
			return;
		}
		if (isDrag)
		{
			Vector2 zero = Vector2.zero;
			zero = GameManager.S.player.GetMouseInput();
			Vector3 vector2 = new Vector3(zero.x, 0f, zero.y) * sensitivity;
			Vector3 b = currentMensurationIngredient.transform.position + vector2;
			b.y = motorCraftingTable.mensurationIngredientsPos[0].position.y + 0.3f;
			currentMensurationIngredient.transform.position = Vector3.Lerp(currentMensurationIngredient.transform.position, b, Time.deltaTime * 5f);
			if (spaced)
			{
				currentMensurationIngredient.isPouring = true;
			}
			else
			{
				currentMensurationIngredient.isPouring = false;
			}
		}
		else
		{
			currentMensurationIngredient.isPouring = false;
			currentMensurationIngredient.isHandled = false;
			currentMensurationIngredient = null;
			Cursor.visible = true;
		}
	}

	private void GrindControl()
	{
		if (spaced)
		{
			motorCraftingTable.blender.Shake();
			if (!AudioManager.S.CheckCookingSFXPlaying())
			{
				AudioManager.S.PlayCookingSFX(AudioManager.S.grind, 0.5f);
			}
		}
		else
		{
			motorCraftingTable.blender.StopShake();
			AudioManager.S.StopCookingSFX();
		}
	}

	private void CastingControl()
	{
		if (input.Player.MouseLeftClick.WasPressedThisFrame())
		{
			Vector2 vector = Mouse.current.position.ReadValue();
			if (Physics.Raycast(Camera.main.ScreenPointToRay(vector), out var hitInfo, 2f, LayerMask.GetMask("Stackable")))
			{
				Debug.Log(hitInfo.transform.name);
				if (hitInfo.transform.TryGetComponent<CurrentMensurationIngredient>(out var component))
				{
					currentMensurationIngredient = component;
					component.isHandled = true;
					Cursor.visible = false;
				}
				else
				{
					currentMensurationIngredient = null;
				}
			}
			else
			{
				currentMensurationIngredient = null;
			}
		}
		if (!(currentMensurationIngredient != null))
		{
			return;
		}
		if (isDrag)
		{
			Vector2 zero = Vector2.zero;
			zero = GameManager.S.player.GetMouseInput();
			Vector3 vector2 = new Vector3(zero.x, 0f, zero.y) * sensitivity;
			Vector3 b = currentMensurationIngredient.transform.position + vector2;
			b.y = motorCraftingTable.mensurationIngredientsPos[0].position.y + 0.5f;
			currentMensurationIngredient.transform.position = Vector3.Lerp(currentMensurationIngredient.transform.position, b, Time.deltaTime * 5f);
			if (spaced)
			{
				currentMensurationIngredient.isPouring = true;
			}
			else
			{
				currentMensurationIngredient.isPouring = false;
			}
		}
		else
		{
			currentMensurationIngredient.isPouring = false;
			currentMensurationIngredient.isHandled = false;
			currentMensurationIngredient = null;
			Cursor.visible = true;
		}
	}

	private void TestingControl()
	{
		if (input.Player.MouseLeftClick.WasPressedThisFrame())
		{
			Vector2 vector = Mouse.current.position.ReadValue();
			if (Physics.Raycast(Camera.main.ScreenPointToRay(vector), out var hitInfo, 2f, LayerMask.GetMask("Stackable")))
			{
				Debug.Log(hitInfo.transform.name);
				if (hitInfo.transform.TryGetComponent<Lighter>(out var component))
				{
					currentLighter = component;
					component.isHandled = true;
					Cursor.visible = false;
				}
				else
				{
					currentLighter = null;
				}
			}
			else
			{
				currentLighter = null;
			}
		}
		if (!(currentLighter != null))
		{
			return;
		}
		if (isDrag)
		{
			Vector2 zero = Vector2.zero;
			zero = GameManager.S.player.GetMouseInput();
			Vector3 vector2 = new Vector3(zero.x, 0f, zero.y) * sensitivity;
			Vector3 b = currentLighter.transform.position + vector2;
			b.y = motorCraftingTable.selectedMotorGO.transform.position.y - 0.1f;
			currentLighter.transform.position = Vector3.Lerp(currentLighter.transform.position, b, Time.deltaTime * 5f);
			if (spaced)
			{
				currentLighter.isPouring = true;
			}
			else
			{
				currentLighter.isPouring = false;
			}
		}
		else
		{
			currentLighter.isPouring = false;
			currentLighter.isHandled = false;
			currentLighter = null;
			Cursor.visible = true;
		}
	}

	private void BoilingControl()
	{
		Vector2 vector = Vector2.zero;
		if (isDrag)
		{
			vector = GameManager.S.player.GetMouseInput();
			Cursor.visible = false;
		}
		else
		{
			Cursor.visible = true;
		}
		Vector3 vector2 = new Vector3(0f - vector.y, 0f, vector.x) * sensitivity / 2f;
		Vector3 position = motorCraftingTable.spatulaPos.position;
		Vector3 vector3 = currentHandledIngredients[0].transform.position + vector2 - position;
		if (vector3.magnitude > spatulaMaxOffset)
		{
			vector3 = vector3.normalized * spatulaMaxOffset;
		}
		Vector3 position2 = Vector3.Lerp(b: new Vector3(position.x + vector3.x, currentHandledIngredients[0].transform.position.y, position.z + vector3.z), a: currentHandledIngredients[0].transform.position, t: Time.deltaTime * 10f);
		currentHandledIngredients[0].transform.position = position2;
	}

	private bool IsDifferenceWithin10Percent(float a, float b)
	{
		float num = Mathf.Abs(a - b);
		float num2 = Mathf.Max(a, b);
		return num <= num2 * 0.2f;
	}

	private void OnDestroy()
	{
		GameManager.S.OnMotorToTheNextStep -= Gm_OnMotorToTheNextStep;
		GameManager.S.OnMotorCraftingDone -= Gm_OnMotorCraftingDone;
		GameManager.S.OnBoilCompleted -= Gm_OnBoilCompleted;
	}
}
