using System;
using System.Collections.Generic;
using I2.Loc;
using InControl;
using TMPro;
using UnityEngine;

public class ObjectIndicatorPens : ScreenSpaceBillboard
{
	public TextMeshProUGUI objectNameText;

	public TextMeshProUGUI objectDescriptionText;

	public GameObject optionalLabelHolder;

	public TextMeshProUGUI optionalLabelText;

	public GameObject contextMenuLocationCircle;

	public GameObject mainUIHolder;

	public GameObject choiceMenuHolder;

	public LineRenderer activeObjectLine;

	public GameObject dogCenter;

	public GameObject menuCenter;

	public GameObject backButtonPrefab;

	private IndicatorActionButton instantiatedBackButton;

	public GameObject indicatorButtonPrefab;

	private List<IndicatorActionButton> indicatorButtons = new List<IndicatorActionButton>();

	public GameObject actionParticles;

	public List<RectTransform> mainUIReferenceTransforms;

	private Vector3 locationOffset = new Vector3(0f, 0.01f, 0f);

	private float buttonDelay = 0.05f;

	private float centerButtonOffset = 400f;

	private float centerButtonSelectionRadiusPercentage = 0.33f;

	private float offScreenBuffer = 150f;

	private bool isDog;

	private bool isDogDen;

	private bool isPlaceableObject;

	private bool activeObjectLineEnabled;

	private ulong? highlightedDogID;

	private GameObject indicatedObject;

	private float maxLineDistance = 500f;

	private bool lineShouldDraw;

	private float timeToLine = 0.1f;

	private float timeSinceLineRequested;

	private int actionsPerPage = 6;

	private int currentActionPage;

	private List<IndicatorAction> actions = new List<IndicatorAction>();

	private bool actionsVisible;

	private string buttonInSound = "contextMenu_buttonIn";

	private DogDen dogDenRef;

	private bool clearedDenArea;

	private Camera mainCamRef;

	private PenFocus penFocusRef;

	private ObjectGrabber grabberRef;

	private DogRegistration dogRegRef;

	private CursorController cursorRef;

	private ObjectIndicatorManager indicatorManagerRef;

	protected override void AwakeBehavior()
	{
		base.AwakeBehavior();
		ObjectRegistration registrationScript = ObjectRegistration.GetRegistrationScript();
		DisableDogLine();
		contextMenuLocationCircle.SetActive(value: false);
		mainCamRef = Camera.main;
		penFocusRef = mainCamRef.GetComponent<PenFocus>();
		cursorRef = registrationScript.GetGlobalComponent<CursorController>(GlobalObject.CURSOR);
		grabberRef = registrationScript.GetGlobalComponent<ObjectGrabber>(GlobalObject.OBJECT_GRABBER);
		dogRegRef = registrationScript.GetGlobalComponent<DogRegistration>(GlobalObject.DOG_REGISTRATION);
		indicatorManagerRef = registrationScript.GetGlobalComponent<ObjectIndicatorManager>(GlobalObject.OBJECT_INDICATOR_MANAGER, nullAllowed: true);
	}

	private void Update()
	{
		if (clearedDenArea)
		{
			UpdateClearedAreaText();
		}
		if (actionsVisible && !cursorRef.IsSystemMouseActive())
		{
			CheckActionHighlight();
		}
	}

	protected override void FixedUpdateBehavior()
	{
		base.FixedUpdateBehavior();
		UpdateObjectLine();
	}

	public override void UpdateBillboard(bool force = false)
	{
		if (indicatorButtons.Count > 0 && !force)
		{
			LockToScreen();
		}
		else
		{
			base.UpdateBillboard(force);
		}
	}

	private void OnDisable()
	{
		RemoveIndicatorButtons();
	}

	private void OnEnable()
	{
		lineShouldDraw = false;
		if (!isDog && !isDogDen && !isPlaceableObject)
		{
			EnableMainUIHolder();
		}
		if (!isDogDen)
		{
			return;
		}
		DenStage currentDenStage = dogDenRef.GetCurrentDenStage();
		if (currentDenStage != DenStage.EMPTY && currentDenStage == DenStage.CLEARED)
		{
			clearedDenArea = true;
			EnableMainUIHolder();
			if (dogDenRef.GetIsSnowy())
			{
				SetNameAndDescription(ScriptLocalization.RoomCustomizationObjects_MISC.OBJ_MISC_UTIL_SNOWPATCH_NAME, ScriptLocalization.RoomCustomizationObjects_MISC.OBJ_MISC_UTIL_SNOWPATCH_DESC, GetClearedAreaText());
			}
			else
			{
				SetNameAndDescription(ScriptLocalization.RoomCustomizationObjects_MISC.OBJ_MISC_UTIL_DIRTPATCH_NAME, ScriptLocalization.RoomCustomizationObjects_MISC.OBJ_MISC_UTIL_DIRTPATCH_DESC, GetClearedAreaText());
			}
		}
	}

	public void UpdateDogDenText()
	{
		if (!isDogDen)
		{
			return;
		}
		DenStage currentDenStage = dogDenRef.GetCurrentDenStage();
		if (currentDenStage != DenStage.EMPTY && currentDenStage == DenStage.CLEARED)
		{
			if (dogDenRef.GetIsSnowy())
			{
				SetNameAndDescription(ScriptLocalization.RoomCustomizationObjects_MISC.OBJ_MISC_UTIL_SNOWPATCH_NAME, ScriptLocalization.RoomCustomizationObjects_MISC.OBJ_MISC_UTIL_SNOWPATCH_DESC, GetClearedAreaText());
			}
			else
			{
				SetNameAndDescription(ScriptLocalization.RoomCustomizationObjects_MISC.OBJ_MISC_UTIL_DIRTPATCH_NAME, ScriptLocalization.RoomCustomizationObjects_MISC.OBJ_MISC_UTIL_DIRTPATCH_DESC, GetClearedAreaText());
			}
		}
	}

	private void EnableMainUIHolder()
	{
		mainUIHolder.SetActive(value: true);
		ClearReferenceTransforms();
		for (int i = 0; i < mainUIReferenceTransforms.Count; i++)
		{
			AddReferenceTransform(mainUIReferenceTransforms[i]);
		}
	}

	private void UpdateClearedAreaText()
	{
		UpdateOptionalLabel(GetClearedAreaText());
	}

	private string GetClearedAreaText()
	{
		if (dogDenRef.GetIsSnowy())
		{
			return ScriptLocalization.RoomCustomizationObjects_MISC.OBJ_MISC_UTIL_SNOWCOLLECTED + " " + dogDenRef.GetDirtClumpCount() + "/" + dogDenRef.GetRequiredDirtClumpCount();
		}
		return ScriptLocalization.RoomCustomizationObjects_MISC.OBJ_MISC_UTIL_DIRTCOLLECTED + " " + dogDenRef.GetDirtClumpCount() + "/" + dogDenRef.GetRequiredDirtClumpCount();
	}

	public void OnDenFinalized()
	{
		mainUIHolder.SetActive(value: false);
	}

	public Sprite GetWhistleIcon()
	{
		return indicatorManagerRef.whistleIcon;
	}

	public void HideEverything()
	{
		RemoveIndicatorButtons();
		mainUIHolder.SetActive(value: false);
	}

	public GameObject GetIndicatedObject()
	{
		return indicatedObject;
	}

	public void SetIndicatedObject(GameObject newObj)
	{
		indicatedObject = newObj;
	}

	public void SetIsDog()
	{
		isDog = true;
		mainUIHolder.SetActive(value: false);
	}

	public void SetIsDogDen(DogDen denRef)
	{
		isDogDen = true;
		mainUIHolder.SetActive(value: false);
		dogDenRef = denRef;
	}

	public void SetIsDogMemorial()
	{
		isPlaceableObject = false;
		mainUIHolder.SetActive(value: true);
	}

	public void SetIsPlaceableObject()
	{
		isPlaceableObject = true;
		mainUIHolder.SetActive(value: false);
	}

	public void SetNameAndDescription(string objectName, string objectDescription, string optionalLabel = "")
	{
		objectNameText.text = objectName;
		objectDescriptionText.text = objectDescription;
		if (optionalLabel.Length > 0)
		{
			optionalLabelHolder.SetActive(value: true);
			optionalLabelText.text = optionalLabel;
		}
		else
		{
			optionalLabelHolder.SetActive(value: false);
		}
	}

	public void UpdateDescription(string objectDescription)
	{
		objectDescriptionText.text = objectDescription;
	}

	public void UpdateOptionalLabel(string newText)
	{
		optionalLabelHolder.SetActive(value: true);
		optionalLabelText.text = newText;
	}

	public void ShowContextMenuLocationCircle(Vector3 pos)
	{
		contextMenuLocationCircle.SetActive(value: true);
		contextMenuLocationCircle.transform.position = pos + locationOffset;
	}

	public void HideContextMenuLocationCircle()
	{
		if (contextMenuLocationCircle != null)
		{
			contextMenuLocationCircle.SetActive(value: false);
		}
	}

	public void AddIndicatorAction(IndicatorAction newAction)
	{
		actions.Add(newAction);
	}

	protected virtual void RemoveIndicatorButtons()
	{
		if (instantiatedBackButton != null)
		{
			UnityEngine.Object.Destroy(instantiatedBackButton.gameObject);
			instantiatedBackButton = null;
		}
		for (int num = indicatorButtons.Count - 1; num >= 0; num--)
		{
			UnityEngine.Object.Destroy(indicatorButtons[num].gameObject);
		}
		indicatorButtons.Clear();
		HideContextMenuLocationCircle();
		ClearReferenceTransforms();
		DisableDogLine();
		if (actionsVisible)
		{
			actionsVisible = false;
			cursorRef.ReportContextMenuClosed();
		}
	}

	public void AdvanceActionPage()
	{
		currentActionPage++;
		ShowActions(currentActionPage);
		grabberRef.ReportIndicatorActive();
		indicatorManagerRef.ReportMouseOffContextButton();
	}

	public void RetreatActionPage()
	{
		currentActionPage--;
		ShowActions(currentActionPage);
		grabberRef.ReportIndicatorActive();
		indicatorManagerRef.ReportMouseOffContextButton();
	}

	private void ShowActions(int startingPage = 0)
	{
		ClearReferenceTransforms();
		RemoveIndicatorButtons();
		int num = startingPage * actionsPerPage;
		while (startingPage > 0)
		{
			startingPage--;
			num--;
		}
		if (num > 0)
		{
			instantiatedBackButton = UnityEngine.Object.Instantiate(backButtonPrefab).GetComponent<IndicatorActionButton>();
			instantiatedBackButton.transform.SetParent(choiceMenuHolder.transform);
			instantiatedBackButton.transform.localPosition = Vector3.zero;
			instantiatedBackButton.transform.localScale = new Vector3(2f, 2f, 2f);
			instantiatedBackButton.SetIndicatorRef(this);
			instantiatedBackButton.SetAction(IndicatorAction.PAGE_BACK);
			instantiatedBackButton.GetComponent<InchwormBounce>().RequestBounce();
		}
		int num2 = 0;
		List<int> objects = new List<int>();
		for (int i = 0; i < actions.Count; i++)
		{
			IndicatorActionButton component = UnityEngine.Object.Instantiate(indicatorButtonPrefab).GetComponent<IndicatorActionButton>();
			component.transform.SetParent(choiceMenuHolder.transform);
			component.transform.localScale = Vector3.one;
			component.SetIndicatorRef(this);
			component.SetAction(actions[i]);
			if (!component.IsValid())
			{
				UnityEngine.Object.Destroy(component.gameObject);
				continue;
			}
			if (num2 < num)
			{
				num2++;
				UnityEngine.Object.Destroy(component.gameObject);
				continue;
			}
			indicatorButtons.Add(component);
			objects.Add(objects.Count);
			if (indicatorButtons.Count >= actionsPerPage - 1 && actions.Count - num - actionsPerPage > 0 && AdditionalValidActionExists(i + 1))
			{
				IndicatorActionButton component2 = UnityEngine.Object.Instantiate(indicatorButtonPrefab).GetComponent<IndicatorActionButton>();
				component2.transform.SetParent(choiceMenuHolder.transform);
				component2.transform.localScale = Vector3.one;
				component2.SetIndicatorRef(this);
				component2.SetAction(IndicatorAction.PAGE_ADVANCE);
				indicatorButtons.Insert(0, component2);
				objects.Insert(0, objects.Count);
				break;
			}
		}
		int num3 = 0;
		for (int j = 0; j < indicatorButtons.Count - num3; j++)
		{
			if (indicatorButtons[j].IsDogAction())
			{
				IndicatorActionButton item = indicatorButtons[j];
				indicatorButtons.RemoveAt(j);
				indicatorButtons.Add(item);
				num3++;
			}
		}
		int num4 = 0;
		int num5 = 1;
		for (int k = 1; k < indicatorButtons.Count - num3 - 1; k++)
		{
			if (indicatorButtons[k].IsDogAction())
			{
				continue;
			}
			int index = num5;
			if (num4 % 2 == 0)
			{
				index = indicatorButtons.Count - num5;
			}
			if (!indicatorButtons[index].IsDogAction())
			{
				num4++;
				index = num5;
				if (num4 % 2 == 0)
				{
					index = indicatorButtons.Count - num5;
				}
			}
			IndicatorActionButton value = indicatorButtons[k];
			indicatorButtons[k] = indicatorButtons[index];
			indicatorButtons[index] = value;
			num4++;
			if (num4 % 2 == 0)
			{
				num5++;
			}
		}
		if (indicatorButtons.Count == 0)
		{
			return;
		}
		RectTransform component3 = indicatorButtons[0].GetComponent<RectTransform>();
		float num6 = (component3.sizeDelta.x - component3.sizeDelta.y) / 8f;
		ListUtil.ShuffleList(ref objects);
		for (int l = 0; l < indicatorButtons.Count; l++)
		{
			Vector3 zero = Vector3.zero;
			if (indicatorButtons.Count > 1 || currentActionPage != 0)
			{
				float num7 = Mathf.Sin((float)l / (float)indicatorButtons.Count * ((float)Math.PI * 2f));
				float num8 = Mathf.Cos((float)l / (float)indicatorButtons.Count * ((float)Math.PI * 2f));
				zero += Vector3.up * (centerButtonOffset * num8);
				zero += Vector3.right * (centerButtonOffset * num7);
				if (indicatorButtons.Count >= actionsPerPage - 1 && !MathUtil.AlmostEqual(num7, 0f))
				{
					Vector3 vector = Vector3.up * num6 * Mathf.Abs(num7);
					if (num8 < 0f)
					{
						zero += vector;
					}
					else if (num8 > 0f)
					{
						zero -= vector;
					}
				}
				if (indicatorButtons.Count == actionsPerPage - 1)
				{
					Vector3 vector2 = Vector3.right * component3.sizeDelta.x / 8f * Mathf.Abs(num8);
					if (num7 > 0f)
					{
						zero += vector2;
					}
					else if (num7 < 0f)
					{
						zero -= vector2;
					}
				}
				if (indicatorButtons.Count == 3 && MathUtil.AlmostEqual(num8, 1f))
				{
					zero -= Vector3.up * component3.sizeDelta.y / 1.5f;
				}
			}
			indicatorButtons[l].transform.localPosition = zero;
			int num9 = objects[l];
			AudioController.Play(buttonInSound, 1f, (float)num9 * buttonDelay);
			InchwormBounce component4 = indicatorButtons[l].GetComponent<InchwormBounce>();
			component4.bounceStartDelay = (float)num9 * buttonDelay;
			component4.Initialize();
			component4.RequestBounce();
		}
		for (int m = 0; m < indicatorButtons.Count; m++)
		{
			AddReferenceTransform(indicatorButtons[m].GetComponent<RectTransform>());
		}
		EnableDogLine();
		if (!actionsVisible)
		{
			actionsVisible = true;
			cursorRef.ReportContextMenuOpen(this);
		}
	}

	public float GetAdjustedContextMenuRadius()
	{
		if (indicatorButtons.Count == 0)
		{
			return 0f;
		}
		float num = Vector2.Distance(menuCenter.transform.position, indicatorButtons[0].transform.position);
		float num2 = indicatorButtons[0].GetComponent<RectTransform>().rect.height * indicatorButtons[0].transform.lossyScale.y;
		return num + num2;
	}

	private void CheckActionHighlight()
	{
		if (indicatorButtons.Count == 0)
		{
			cursorRef.ClearOverrideUIElement();
			return;
		}
		Vector3 vector = InputManager.MouseProvider.GetPosition();
		if (Vector2.Distance(vector, menuCenter.transform.position) <= GetAdjustedContextMenuRadius() * centerButtonSelectionRadiusPercentage)
		{
			if (instantiatedBackButton == null)
			{
				cursorRef.SetOverrideUIElement(null);
			}
			else
			{
				cursorRef.SetOverrideUIElement(instantiatedBackButton.gameObject);
			}
			return;
		}
		GameObject gameObject = indicatorButtons[0].gameObject;
		float num = Vector3.Distance(vector, gameObject.transform.position);
		for (int i = 1; i < indicatorButtons.Count; i++)
		{
			float num2 = Vector3.Distance(vector, indicatorButtons[i].transform.position);
			if (num2 < num)
			{
				num = num2;
				gameObject = indicatorButtons[i].gameObject;
			}
		}
		cursorRef.SetOverrideUIElement(gameObject);
	}

	private bool AdditionalValidActionExists(int startingIndex)
	{
		for (int i = startingIndex; i < actions.Count; i++)
		{
			IndicatorActionButton component = UnityEngine.Object.Instantiate(indicatorButtonPrefab).GetComponent<IndicatorActionButton>();
			component.SetIndicatorRef(this);
			component.SetAction(actions[i]);
			bool flag = component.IsValid();
			UnityEngine.Object.Destroy(component.gameObject);
			if (flag)
			{
				return true;
			}
		}
		return false;
	}

	public void ShowChoiceMenu()
	{
		mainUIHolder.SetActive(value: false);
		currentActionPage = 0;
		ShowActions();
	}

	public bool IsChoiceMenuActive()
	{
		return actionsVisible;
	}

	public void CloseContextMenu(bool fromDeactivation = false)
	{
		indicatorManagerRef.ReportMouseOffContextButton();
		indicatorManagerRef.ReportClick(null);
		RemoveIndicatorButtons();
		if (!fromDeactivation)
		{
			grabberRef.DeactivateIndicator();
		}
	}

	public void ReportMouseOverContextButton(bool isDogAction, bool isDogSelfAction)
	{
		if (isDogAction && activeObjectLineEnabled && !isDogSelfAction)
		{
			RequestLineEnable();
		}
		indicatorManagerRef.ReportMouseOverContextButton();
	}

	public void ReportMouseOffContextButton()
	{
		lineShouldDraw = false;
		dogCenter.SetActive(value: false);
		menuCenter.SetActive(value: false);
		activeObjectLine.enabled = false;
		indicatorManagerRef.ReportMouseOffContextButton();
	}

	private void EnableDogLine()
	{
		activeObjectLineEnabled = true;
		UpdateObjectLine();
		if (dogRegRef.GetSelectedDog() != null && !dogRegRef.GetSelectedDog().inCocoon)
		{
			highlightedDogID = dogRegRef.GetSelectedDog().dogID;
			grabberRef.HighlightActiveDog(dogRegRef.GetDogFromID(highlightedDogID.Value));
		}
	}

	private void DisableDogLine()
	{
		dogCenter.SetActive(value: false);
		menuCenter.SetActive(value: false);
		activeObjectLineEnabled = false;
		activeObjectLine.enabled = false;
		if (grabberRef != null && highlightedDogID.HasValue)
		{
			grabberRef.ClearActiveDog(dogRegRef.GetDogFromID(highlightedDogID.Value));
		}
		highlightedDogID = null;
	}

	private void UpdateObjectLine()
	{
		if (!activeObjectLineEnabled)
		{
			return;
		}
		if (dogRegRef.GetSelectedDog() == null || dogRegRef.GetSelectedDog().inCocoon)
		{
			DisableDogLine();
			return;
		}
		LegController component = dogRegRef.GetDogFromID(dogRegRef.GetSelectedDog().dogID).GetComponent<LegController>();
		if (component == null)
		{
			DisableDogLine();
			return;
		}
		if (lineShouldDraw && !activeObjectLine.enabled)
		{
			timeSinceLineRequested += Time.fixedDeltaTime;
			if (timeSinceLineRequested < timeToLine)
			{
				return;
			}
			dogCenter.SetActive(value: true);
			menuCenter.SetActive(value: true);
			activeObjectLine.enabled = true;
		}
		Vector3 position = component.bodyFront.transform.position;
		Vector3 position2 = choiceMenuHolder.transform.position;
		Vector3 vector = mainCamRef.WorldToScreenPoint(position);
		float num = (float)Screen.width + offScreenBuffer;
		float num2 = (float)Screen.height + offScreenBuffer;
		if (position2.x < 0f - offScreenBuffer || position2.y < 0f - offScreenBuffer || vector.x < 0f - offScreenBuffer || vector.y < 0f - offScreenBuffer || position2.x > num || position2.y > num2 || vector.x > num || vector.y > num2)
		{
			DisableDogLine();
			return;
		}
		if (Vector3.Distance(position, mainCamRef.transform.position) > maxLineDistance)
		{
			DisableDogLine();
			return;
		}
		position2 = new Vector3(position2.x, position2.y, mainCamRef.nearClipPlane + 2f);
		vector = new Vector3(vector.x, vector.y, mainCamRef.nearClipPlane + 2f);
		dogCenter.transform.position = vector;
		position2 = mainCamRef.ScreenToWorldPoint(position2);
		vector = mainCamRef.ScreenToWorldPoint(vector);
		activeObjectLine.SetPosition(0, position2);
		activeObjectLine.SetPosition(1, vector);
	}

	private void RequestLineEnable()
	{
		if (!(penFocusRef.GetFollowTarget() != null))
		{
			lineShouldDraw = true;
			timeSinceLineRequested = 0f;
		}
	}
}
