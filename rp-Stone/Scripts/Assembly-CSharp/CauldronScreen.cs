using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ModalFade))]
public class CauldronScreen : AsciiObject
{
	public enum State
	{
		Disabled = 0,
		In = 1,
		Out = 2,
		Idle = 3,
		Upgrading = 4,
		Brewing = 5,
		ItemDetails = 6,
		AlreadyHavePotion = 7,
		ConfirmPotionChange = 8
	}

	private enum Mode
	{
		FTUE = 0,
		FeatureComplete = 1
	}

	private int TOTAL_RESOURCE_COST = 20;

	private int MAX_RESOURCES = 2;

	public AsciiSprite background;

	public AsciiSprite backgroundFlames;

	public AsciiAnimation bubbleReference;

	public AsciiAnimation splash;

	public DialogButton closeButton;

	public DialogButton brewButton;

	public DialogButton potionButton;

	public SettingsToggleButton toggleButtonPrefab;

	public AsciiString totalResourcePrototype;

	private List<AsciiString> totalResourceLabels = new List<AsciiString>();

	private List<int> totalResourcesBlinking = new List<int>();

	private int totalResourceWidth;

	public AsciiString autoRefillLabel;

	public AsciiString stoneLabel;

	public AsciiString woodLabel;

	public AsciiString tarLabel;

	public AsciiString bronzeLabel;

	public int iconPosX;

	public int iconPosY;

	public TwoChoiceDialog alreadyHavePotionDialog;

	public TwoChoiceDialog confirmPotionChangeDialog;

	public AudioSource bubbleSound;

	private SettingsToggleButton autoRefillToggleButton;

	private SettingsToggleButton stoneToggleButton;

	private SettingsToggleButton woodToggleButton;

	private SettingsToggleButton tarToggleButton;

	private SettingsToggleButton bronzeToggleButton;

	private AsciiSprite potionIcon;

	public RollingMessage rollingMessage;

	public Action<Potion.Type> OnPreBrew;

	private bool upgradePending;

	private bool drawAutoRefill;

	private bool drawStoneToggle;

	private bool drawWoodToggle;

	private bool drawBronzeToggle;

	private ModalFade modalFade;

	private List<AsciiAnimation> bubbles = new List<AsciiAnimation>();

	private List<Data.Resource> enabledResources = new List<Data.Resource>();

	private int ftueDeltaX;

	private int ftueDeltaY;

	private bool potionChangeConfirmedYes;

	private Potion potionItem;

	private float outAcceleration = 1.8f;

	private float inVelocity = 6f;

	private float inBounceThreshold = 6f;

	private float inBounceAcceleration = 1.6f;

	private float inBounceMaxVelocity = 1f;

	private float transitionMaxPosition = 29f;

	private float transitionOffsetY;

	private float transitionVelocity;

	private Potion.Type lastPotionType = Potion.Type.Alacrity;

	private Stack<AsciiString> resourceLabelPool = new Stack<AsciiString>();

	public State currentState { get; private set; }

	public int stateElapsedTics { get; private set; }

	private Mode mode { get; set; }

	private ItemDetailsDialog itemDetailsDialog => GameStates.Singleton.itemScreen.itemDetailsDialog;

	public bool brewInterrupted { get; set; }

	public static CauldronScreen singleton { get; private set; }

	public void Show()
	{
		potionItem = Potion.GetItem();
		mode = (QuestController.singleton.HasCompleted("upgrade_cauldron") ? Mode.FeatureComplete : Mode.FTUE);
		upgradePending = mode == Mode.FeatureComplete && !ProgressFlags.GetFlag("has_upgraded_cauldron");
		drawStoneToggle = (drawWoodToggle = (drawBronzeToggle = (drawAutoRefill = mode == Mode.FeatureComplete && !upgradePending)));
		if (upgradePending)
		{
			ProgressFlags.SetFlag("has_upgraded_cauldron");
		}
		ftueDeltaX = -6;
		ftueDeltaY = 1;
		SetState(State.In);
		autoRefillToggleButton.isOn = (bool)potionItem && potionItem.autoRefill;
		UpdateIcon();
	}

	public void Hide()
	{
		SetState(State.Out);
	}

	private void SetState(State newState)
	{
		if (modalFade != null)
		{
			modalFade.active = newState != State.Disabled && newState != State.Out;
		}
		if (newState == State.In && upgradePending)
		{
			GameStates.Singleton.HideMouse();
		}
		else if (currentState == State.Upgrading)
		{
			GameStates.Singleton.ShowMouse();
			AsciiMouse.singleton.Hide();
		}
		switch (newState)
		{
		case State.In:
			transitionOffsetY = transitionMaxPosition;
			transitionVelocity = 0f - inVelocity;
			splash.Stop();
			splash.Play();
			bubbleSound.enabled = SfxController.singleton.enabled;
			UpdateBubbleVolume();
			break;
		case State.Out:
		case State.Idle:
			transitionOffsetY = 0f;
			transitionVelocity = 0f;
			GameStates.Singleton.ShowMouse();
			break;
		case State.Upgrading:
			transitionOffsetY = 0f;
			transitionVelocity = 0f;
			break;
		case State.Brewing:
			stoneToggleButton.isOn = false;
			woodToggleButton.isOn = false;
			tarToggleButton.isOn = false;
			bronzeToggleButton.isOn = false;
			enabledResources.Clear();
			UpdateResourcesLabel();
			UpdateIcon();
			AnalyticsMacros.BrewPotion();
			break;
		case State.AlreadyHavePotion:
		{
			Potion item2 = Potion.GetItem();
			string format2 = Te.xt("You already have {0}.");
			alreadyHavePotionDialog.SetMessage(string.Format(format2, Te.xt(item2.displayName)));
			alreadyHavePotionDialog.Show();
			break;
		}
		case State.ConfirmPotionChange:
		{
			potionChangeConfirmedYes = false;
			Potion item = Potion.GetItem();
			string format = Te.xt("The bottle is already full with {0}.\n\nReplace it?");
			confirmPotionChangeDialog.SetMessage(string.Format(format, Te.xt(item.displayName)));
			confirmPotionChangeDialog.Show();
			break;
		}
		case State.Disabled:
			transitionOffsetY = transitionMaxPosition;
			transitionVelocity = 0f;
			bubbleSound.enabled = false;
			break;
		}
		currentState = newState;
		stateElapsedTics = 0;
	}

	public override void UpdateTic()
	{
		stateElapsedTics++;
		if (currentState == State.Out)
		{
			transitionVelocity += outAcceleration;
			transitionOffsetY += transitionVelocity;
			if (transitionOffsetY > transitionMaxPosition)
			{
				SetState(State.Disabled);
			}
		}
		else if (currentState == State.In)
		{
			bool flag = transitionOffsetY >= 0f && transitionVelocity >= 0f;
			if (transitionOffsetY > inBounceThreshold)
			{
				transitionOffsetY += transitionVelocity;
			}
			else
			{
				transitionVelocity = Mathf.Min(inBounceMaxVelocity, transitionVelocity + inBounceAcceleration);
				transitionOffsetY += transitionVelocity;
				if (transitionOffsetY >= 0f && transitionVelocity >= 0f)
				{
					flag = true;
				}
			}
			if (flag)
			{
				if (upgradePending)
				{
					SetState(State.Upgrading);
				}
				else
				{
					SetState(State.Idle);
				}
				transitionOffsetY = 0f;
				transitionVelocity = 0f;
			}
		}
		else if (currentState == State.Idle)
		{
			closeButton.UpdateTic();
			if (enabledResources.Count > 0)
			{
				brewButton.UpdateTic();
			}
			potionButton.UpdateTic();
			tarToggleButton.UpdateTic();
			if (mode == Mode.FeatureComplete)
			{
				autoRefillToggleButton.UpdateTic();
				stoneToggleButton.UpdateTic();
				woodToggleButton.UpdateTic();
				bronzeToggleButton.UpdateTic();
			}
			for (int i = 0; i < totalResourcesBlinking.Count; i++)
			{
				if (totalResourcesBlinking[i] > 0)
				{
					totalResourcesBlinking[i]--;
				}
			}
			UpdateIcon();
		}
		else if (currentState == State.Upgrading)
		{
			if (stateElapsedTics == 3)
			{
				ftueDeltaX /= 2;
			}
			else if (stateElapsedTics == 4)
			{
				ftueDeltaX /= 2;
				ftueDeltaY = 0;
				SfxController.singleton.Play("ui_starold1");
			}
			else if (stateElapsedTics == 5)
			{
				ftueDeltaX = 0;
			}
			else if (stateElapsedTics == 13)
			{
				drawStoneToggle = true;
				SfxController.singleton.Play("ui_starold2");
			}
			else if (stateElapsedTics == 21)
			{
				drawWoodToggle = true;
				SfxController.singleton.Play("ui_starold3");
			}
			else if (stateElapsedTics == 29)
			{
				drawBronzeToggle = true;
				SfxController.singleton.Play("ui_starold4");
			}
			else if (stateElapsedTics == 40)
			{
				drawAutoRefill = true;
				SfxController.singleton.Play("ui_starnew");
				upgradePending = false;
				AsciiParticleEmitter component = GetComponent<AsciiParticleEmitter>();
				if ((bool)component)
				{
					component.MoveTo(new Vector3(background.lastDrawX + 39, background.lastDrawY - 3, 0f));
					component.Emit();
				}
				SetState(State.Idle);
			}
		}
		else if (currentState == State.Brewing && stateElapsedTics >= 15)
		{
			ShowItemDetails();
		}
		else if (currentState == State.ItemDetails)
		{
			itemDetailsDialog.UpdateTic();
			if (itemDetailsDialog.CurrentState == DialogNineSlice.State.Disabled)
			{
				SetState(State.Idle);
			}
		}
		else if (currentState == State.AlreadyHavePotion)
		{
			alreadyHavePotionDialog.UpdateTic();
			if (alreadyHavePotionDialog.CurrentState == DialogNineSlice.State.Disabled)
			{
				SetState(State.Idle);
			}
		}
		else if (currentState == State.ConfirmPotionChange)
		{
			confirmPotionChangeDialog.UpdateTic();
			if (confirmPotionChangeDialog.CurrentState == DialogNineSlice.State.Disabled)
			{
				if (potionChangeConfirmedYes)
				{
					CopyCostsToPotion();
					DoBrew();
				}
				else
				{
					SetState(State.Idle);
				}
			}
		}
		UpdateBubbleVolume();
	}

	private void UpdateBubbleVolume()
	{
		float volume = AmbianceController.singleton.volume;
		if (currentState == State.Disabled)
		{
			bubbleSound.volume = 0f;
		}
		else if (currentState == State.In)
		{
			float t = Mathf.Clamp01((float)stateElapsedTics / 10f);
			bubbleSound.volume = Mathf.Lerp(0f, volume, t);
		}
		else if (currentState == State.Out)
		{
			float t2 = Mathf.Clamp01((float)stateElapsedTics / 10f);
			bubbleSound.volume = Mathf.Lerp(volume, 0f, t2);
		}
		else
		{
			bubbleSound.volume = volume;
		}
	}

	public override void Draw(AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		if (modalFade != null)
		{
			modalFade.Draw(r);
		}
		offsetX += PositionX + (Width >> 1);
		offsetY += PositionY + (int)transitionOffsetY;
		if (currentState == State.Idle)
		{
			r.Clear();
		}
		if (currentState != State.Disabled)
		{
			background.Draw(r, offsetX, offsetY);
			for (int i = 0; i < bubbles.Count; i++)
			{
				bubbles[i].Sprite.Draw(r, offsetX, offsetY);
			}
			closeButton.Draw(r, offsetX, offsetY);
			if (enabledResources.Count > 0)
			{
				brewButton.Draw(r, offsetX, offsetY);
			}
			int num = offsetX - totalResourceWidth / 2;
			int offsetY2 = offsetY + ((mode == Mode.FTUE) ? 1 : 0);
			for (int j = 0; j < totalResourceLabels.Count; j++)
			{
				if (totalResourcesBlinking[j] > 0 && (totalResourcesBlinking[j] - 1) % 6 <= 2)
				{
					totalResourceLabels[j].Draw(r, num, offsetY2, ColorConstants.red);
				}
				else
				{
					totalResourceLabels[j].Draw(r, num, offsetY2);
				}
				num += totalResourceLabels[j].Length;
			}
			splash.Sprite.Draw(r, offsetX, offsetY);
			num = offsetX;
			offsetY2 = offsetY;
			if (mode == Mode.FTUE || upgradePending)
			{
				num += ftueDeltaX;
				offsetY2 += ftueDeltaY;
			}
			DrawToggle(r, num, offsetY2, tarToggleButton, tarLabel);
			if (drawAutoRefill)
			{
				DrawToggle(r, num, offsetY2, autoRefillToggleButton, autoRefillLabel);
			}
			if (drawStoneToggle)
			{
				DrawToggle(r, num, offsetY2, stoneToggleButton, stoneLabel);
			}
			if (drawWoodToggle)
			{
				DrawToggle(r, num, offsetY2, woodToggleButton, woodLabel);
			}
			if (drawBronzeToggle)
			{
				DrawToggle(r, num, offsetY2, bronzeToggleButton, bronzeLabel);
			}
			if (potionIcon != null)
			{
				potionIcon.Draw(r, num + iconPosX, offsetY2 + iconPosY);
			}
			potionButton.Draw(r, num, offsetY2);
			rollingMessage.Draw(r, offsetX, offsetY);
		}
		if (currentState == State.ItemDetails)
		{
			itemDetailsDialog.Draw(r, r.width >> 1, r.height >> 1);
		}
		if (currentState == State.AlreadyHavePotion)
		{
			alreadyHavePotionDialog.Draw(r, r.width >> 1, r.height >> 1);
		}
		else if (currentState == State.ConfirmPotionChange)
		{
			confirmPotionChangeDialog.Draw(r, r.width >> 1, r.height >> 1);
		}
	}

	private void DrawToggle(AsciiRenderProcedural r, int offsetX, int offsetY, SettingsToggleButton toggleButton, AsciiString label)
	{
		label.Draw(r, offsetX, offsetY);
		toggleButton.Draw(r, offsetX + label.PositionX - 4, offsetY + label.PositionY + 1);
	}

	private void UpdateIcon()
	{
		if (potionItem != null && lastPotionType != potionItem.type)
		{
			lastPotionType = potionItem.type;
			potionIcon = IconLoader.Singleton.GetSharedIcon(potionItem.iconPath);
		}
	}

	private void AddEnabledResource(Data.Resource whichResource)
	{
		if (enabledResources.Count >= MAX_RESOURCES)
		{
			switch (enabledResources[0])
			{
			case Data.Resource.Stone:
				stoneToggleButton.isOn = false;
				break;
			case Data.Resource.Wood:
				woodToggleButton.isOn = false;
				break;
			case Data.Resource.Tar:
				tarToggleButton.isOn = false;
				break;
			case Data.Resource.Bronze:
				bronzeToggleButton.isOn = false;
				break;
			}
			enabledResources.RemoveAt(0);
		}
		enabledResources.Add(whichResource);
	}

	private void RemoveEnabledResource(Data.Resource whichResource)
	{
		enabledResources.Remove(whichResource);
	}

	private void UpdateResourcesLabel()
	{
		RecycleAllLabels();
		totalResourceWidth = 0;
		if (enabledResources.Count <= 0)
		{
			return;
		}
		int num = ComputeCostPerResource();
		for (int i = 0; i < enabledResources.Count; i++)
		{
			if (i > 0)
			{
				if (enabledResources.Count >= 4)
				{
					AddResourceLabel(" + ");
				}
				else
				{
					AddResourceLabel("  +  ");
				}
			}
			AddResourceLabel(MoneyUI.BuildResourceString(num, enabledResources[i]));
		}
	}

	private void AddResourceLabel(string str)
	{
		totalResourceWidth += str.Length;
		AsciiString asciiString;
		if (resourceLabelPool.Count > 0)
		{
			asciiString = resourceLabelPool.Pop();
		}
		else
		{
			asciiString = new AsciiString();
			asciiString.color = totalResourcePrototype.color;
			asciiString.PositionY = totalResourcePrototype.PositionY;
		}
		asciiString.SetValue(str);
		totalResourceLabels.Add(asciiString);
		totalResourcesBlinking.Add(0);
	}

	private void RecycleAllLabels()
	{
		for (int i = 0; i < totalResourceLabels.Count; i++)
		{
			resourceLabelPool.Push(totalResourceLabels[i]);
		}
		totalResourceLabels.Clear();
		totalResourcesBlinking.Clear();
	}

	private void TryToBrew()
	{
		CrashReportController.singleton.AddBreadcrumb("1");
		if (enabledResources.Count <= 0)
		{
			return;
		}
		CrashReportController.singleton.AddBreadcrumb("2");
		int num = ComputeCostPerResource();
		for (int i = 0; i < enabledResources.Count; i++)
		{
			long resourceOfType = InventoryResources.singleton.GetResourceOfType(enabledResources[i]);
			if (num > resourceOfType)
			{
				int num2 = i * 2;
				if (num2 < totalResourcesBlinking.Count)
				{
					totalResourcesBlinking[num2] = 15;
				}
				return;
			}
		}
		CrashReportController.singleton.AddBreadcrumb("3");
		Potion item = Potion.GetItem();
		Potion.Type potionForResources = Potion.GetPotionForResources(enabledResources);
		if (CheckInterruption(potionForResources))
		{
			rollingMessage.Show(Te.xt("tid_craft_interrupted"), Color.red);
			return;
		}
		CrashReportController.singleton.AddBreadcrumb("4");
		if (item.type != Potion.Type.Empty)
		{
			if (potionForResources == item.type)
			{
				SetState(State.AlreadyHavePotion);
			}
			else
			{
				SetState(State.ConfirmPotionChange);
			}
		}
		else
		{
			CopyCostsToPotion();
			DoBrew();
		}
	}

	public bool CheckInterruption(Potion.Type type)
	{
		brewInterrupted = false;
		OnPreBrew?.Invoke(type);
		return brewInterrupted;
	}

	private void CopyCostsToPotion()
	{
		Potion item = Potion.GetItem();
		item.costs.Clear();
		int amount = ComputeCostPerResource();
		for (int i = 0; i < enabledResources.Count; i++)
		{
			Data.Cost cost = new Data.Cost();
			cost.resource = enabledResources[i];
			cost.amount = amount;
			item.costs.Add(cost);
		}
	}

	private void DoBrew()
	{
		Potion item = Potion.GetItem();
		if ((bool)item)
		{
			Potion.Type potionForResources = Potion.GetPotionForResources(enabledResources);
			if (potionForResources == Potion.Type.Empty)
			{
				ExceptionHandlingUI.Report("Something went wrong when brewing the potion.");
				return;
			}
			item.Refill(potionForResources);
			SetState(State.Brewing);
		}
		else
		{
			ExceptionHandlingUI.Report("Failed to Brew. No potion in inventory.");
		}
	}

	private void ShowItemDetails()
	{
		Potion item = Potion.GetItem();
		if (item != null)
		{
			itemDetailsDialog.item = item;
			itemDetailsDialog.Show();
		}
		SetState(State.ItemDetails);
	}

	private int ComputeCostPerResource()
	{
		return Mathf.CeilToInt((float)TOTAL_RESOURCE_COST / (float)enabledResources.Count);
	}

	private void HandleCloseButtonPressed(DialogButton button)
	{
		Hide();
	}

	private void HandleBrewButtonPressed(DialogButton button)
	{
		TryToBrew();
	}

	private void HandlePotionButtonPressed(DialogButton button)
	{
		ShowItemDetails();
	}

	private void HandleAutoRefillPressed(DialogButton button)
	{
		Potion item = Potion.GetItem();
		if (item != null)
		{
			item.autoRefill = autoRefillToggleButton.isOn;
		}
	}

	private void HandleStoneTogglePressed(DialogButton button)
	{
		if (stoneToggleButton.isOn)
		{
			AddEnabledResource(Data.Resource.Stone);
			SfxController.singleton.Play("pickup_stone");
		}
		else
		{
			RemoveEnabledResource(Data.Resource.Stone);
			SfxController.singleton.Play("click");
		}
		UpdateResourcesLabel();
	}

	private void HandleWoodTogglePressed(DialogButton button)
	{
		if (woodToggleButton.isOn)
		{
			AddEnabledResource(Data.Resource.Wood);
			SfxController.singleton.Play("pickup_wood");
		}
		else
		{
			RemoveEnabledResource(Data.Resource.Wood);
			SfxController.singleton.Play("click");
		}
		UpdateResourcesLabel();
	}

	private void HandleTarTogglePressed(DialogButton button)
	{
		if (tarToggleButton.isOn)
		{
			AddEnabledResource(Data.Resource.Tar);
			SfxController.singleton.Play("pickup_tar");
		}
		else
		{
			RemoveEnabledResource(Data.Resource.Tar);
			SfxController.singleton.Play("click");
		}
		UpdateResourcesLabel();
	}

	private void HandleBronzeTogglePressed(DialogButton button)
	{
		if (bronzeToggleButton.isOn)
		{
			AddEnabledResource(Data.Resource.Bronze);
			SfxController.singleton.Play("pickup_bronze");
		}
		else
		{
			RemoveEnabledResource(Data.Resource.Bronze);
			SfxController.singleton.Play("click");
		}
		UpdateResourcesLabel();
	}

	private void HandleAlreadyHavePotionYes(DialogButton button)
	{
		alreadyHavePotionDialog.Hide();
	}

	private void HandleConfirmPotionChangeYes(DialogButton button)
	{
		potionChangeConfirmedYes = true;
		confirmPotionChangeDialog.Hide();
	}

	private void Update()
	{
		if (currentState == State.Idle && Input.GetKeyDown(KeyCode.Escape))
		{
			HandleCloseButtonPressed(null);
		}
	}

	protected void Start()
	{
		InitBubbles();
		UpdateResourcesLabel();
		splash.Sprite.Load();
		stoneToggleButton.isOn = false;
		woodToggleButton.isOn = false;
		tarToggleButton.isOn = false;
		bronzeToggleButton.isOn = false;
		autoRefillToggleButton.OnPressed += HandleAutoRefillPressed;
		stoneToggleButton.OnPressed += HandleStoneTogglePressed;
		woodToggleButton.OnPressed += HandleWoodTogglePressed;
		tarToggleButton.OnPressed += HandleTarTogglePressed;
		bronzeToggleButton.OnPressed += HandleBronzeTogglePressed;
		closeButton.OnPressed += HandleCloseButtonPressed;
		brewButton.OnPressed += HandleBrewButtonPressed;
		potionButton.OnPressed += HandlePotionButtonPressed;
		potionButton.OnSecondaryPressed += HandlePotionButtonPressed;
		confirmPotionChangeDialog.okButton.OnPressed += HandleConfirmPotionChangeYes;
		alreadyHavePotionDialog.okButton.OnPressed += HandleAlreadyHavePotionYes;
	}

	protected void OnDestroy()
	{
		autoRefillToggleButton.OnPressed -= HandleAutoRefillPressed;
		stoneToggleButton.OnPressed -= HandleStoneTogglePressed;
		woodToggleButton.OnPressed -= HandleWoodTogglePressed;
		tarToggleButton.OnPressed -= HandleTarTogglePressed;
		bronzeToggleButton.OnPressed -= HandleBronzeTogglePressed;
		closeButton.OnPressed -= HandleCloseButtonPressed;
		brewButton.OnPressed -= HandleBrewButtonPressed;
		potionButton.OnPressed -= HandlePotionButtonPressed;
		potionButton.OnSecondaryPressed -= HandlePotionButtonPressed;
		confirmPotionChangeDialog.okButton.OnPressed -= HandleConfirmPotionChangeYes;
		alreadyHavePotionDialog.okButton.OnPressed -= HandleAlreadyHavePotionYes;
	}

	protected void Awake()
	{
		singleton = this;
		autoRefillToggleButton = UnityEngine.Object.Instantiate(toggleButtonPrefab);
		stoneToggleButton = UnityEngine.Object.Instantiate(toggleButtonPrefab);
		woodToggleButton = UnityEngine.Object.Instantiate(toggleButtonPrefab);
		tarToggleButton = UnityEngine.Object.Instantiate(toggleButtonPrefab);
		bronzeToggleButton = UnityEngine.Object.Instantiate(toggleButtonPrefab);
		modalFade = GetComponent<ModalFade>();
	}

	private void InitBubbles()
	{
		bubbles.Add(bubbleReference);
		for (int i = 1; i < 9; i++)
		{
			AsciiAnimation asciiAnimation = UnityEngine.Object.Instantiate(bubbleReference);
			asciiAnimation.transform.parent = base.transform;
			AsciiSprite component = asciiAnimation.GetComponent<AsciiSprite>();
			component.pivotX -= i * 3;
			component.Load();
			bubbles.Add(asciiAnimation);
		}
		bubbleReference.Sprite.Load();
	}

	public int GetStateNumericRepresentation()
	{
		return (int)currentState;
	}
}
