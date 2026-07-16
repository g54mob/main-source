using System;
using TMPro;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.UI;

public class HotkeyTooltips : MonoBehaviour
{
	[NonSerialized]
	public PlayerController player;

	private RectTransform rt;

	[SerializeField]
	private HotkeyTooltipsPosition position;

	[SerializeField]
	private float upperPosition = 0.45f;

	[SerializeField]
	private float lowerPosition = -0.45f;

	[SerializeField]
	private VerticalLayoutGroup verticalLayoutGroup;

	[SerializeField]
	private HotkeyTooltip hotkeyTooltipInteract;

	[SerializeField]
	private HotkeyTooltip hotkeyTooltipFix;

	[SerializeField]
	private HotkeyTooltip hotkeyTooltipReload;

	[SerializeField]
	private HotkeyTooltip hotkeyTooltipPush;

	[SerializeField]
	private HotkeyTooltip hotkeyTooltipRadar;

	[SerializeField]
	private HotkeyTooltip hotkeyTooltipDemoAlert;

	[SerializeField]
	private HotkeyTooltip hotkeyTooltipShovel;

	[SerializeField]
	private TextMeshProUGUI radarPrice;

	[SerializeField]
	private TimingBar repairBar;

	[SerializeField]
	private TimingBar shovelBar;

	[Header("Localization")]
	[SerializeField]
	private LocalizedString fixLocalized;

	[SerializeField]
	private LocalizedString fixMinigameLocalized;

	[SerializeField]
	private LocalizedString fixingMinorLocalized;

	[SerializeField]
	private LocalizedString stopFixingMinigameLocalized;

	[SerializeField]
	private LocalizedString reloadLocalized;

	[SerializeField]
	private LocalizedString shovelingLocalized;

	private Vector2 basePosition;

	private float tooltipsOffset;

	private bool interactOn;

	private bool interruptOn;

	private float baseX;

	private float baseY;

	public HotkeyTooltipsPosition Position => position;

	private float trainOffset => Train.Instance.transform.GetChild(0).position.y;

	private float totalOffset => trainOffset + tooltipsOffset;

	private Vector2 offsetVector => new Vector2(0f, trainOffset);

	private void Awake()
	{
		rt = GetComponent<RectTransform>();
		foreach (GameObject value in HUB.Instance.hubElements.Values)
		{
			BrokenHubStation component = value.GetComponent<BrokenHubStation>();
			if ((object)component != null)
			{
				component.onFix += CloseBuyPanel;
			}
		}
	}

	private void Start()
	{
		tooltipsOffset = ((position == HotkeyTooltipsPosition.Upper) ? 0.45f : (-0.45f));
		PlayerManager.Instance.OnCoopEnded += HandleCoopEnded;
	}

	private void OnDestroy()
	{
		PlayerManager.Instance.OnCoopEnded -= HandleCoopEnded;
	}

	private void Update()
	{
		if (interactOn || interruptOn)
		{
			base.transform.position = new Vector2(baseX, baseY + trainOffset);
		}
	}

	public void SetPosition(Vector2 pos)
	{
		basePosition = pos;
	}

	private void HandleCoopEnded(PlayerController controller)
	{
		if (controller == player)
		{
			CloseAll();
			UnityEngine.Object.Destroy(base.gameObject);
		}
		else if (player != null && (bool)player.interactor.ActiveInteractable)
		{
			baseY = upperPosition;
		}
	}

	public void CloseAll()
	{
		SetInteractable(null, null);
		SetInterruptable(null, null);
	}

	private void SetTooltipActive(bool active, params HotkeyTooltip[] tooltips)
	{
		if (tooltips == null)
		{
			return;
		}
		foreach (HotkeyTooltip hotkeyTooltip in tooltips)
		{
			if (hotkeyTooltip != null)
			{
				hotkeyTooltip.gameObject.SetActive(active);
			}
		}
	}

	private void SetTooltipControllerScheme(ControllerType controllerType, params HotkeyTooltip[] tooltips)
	{
		if (tooltips == null)
		{
			return;
		}
		foreach (HotkeyTooltip hotkeyTooltip in tooltips)
		{
			if (hotkeyTooltip != null)
			{
				hotkeyTooltip.SetControllerType(controllerType);
			}
		}
	}

	private void SetTooltipTintColor(Color? color, params HotkeyTooltip[] tooltips)
	{
		if (!color.HasValue)
		{
			color = new Color(0f, 0f, 0f, 0f);
		}
		if (tooltips == null)
		{
			return;
		}
		foreach (HotkeyTooltip hotkeyTooltip in tooltips)
		{
			if (hotkeyTooltip != null)
			{
				hotkeyTooltip.SetPlayerTint(color.Value);
			}
		}
	}

	public void SetInteractable(Interactable interactable, PlayerController pc)
	{
		player = pc;
		SetInterruptable(null);
		SetInteractable(interactable);
	}

	private void SetInteractable(Interactable interactable)
	{
		if (interactable == null)
		{
			interactOn = false;
			SetTooltipActive(false, hotkeyTooltipInteract, hotkeyTooltipFix, hotkeyTooltipReload, hotkeyTooltipRadar, hotkeyTooltipDemoAlert);
			return;
		}
		if (interactable.gameObject.GetComponent<Module>() == null)
		{
			SetTooltipActive(false, hotkeyTooltipInteract, hotkeyTooltipFix, hotkeyTooltipReload, hotkeyTooltipRadar, hotkeyTooltipDemoAlert);
		}
		interactOn = true;
		if ((bool)interactable.Interactor)
		{
			if (PlayerManager.Instance.IsCoop)
			{
				SetTooltipTintColor(player.GetPlayerColor(), hotkeyTooltipInteract, hotkeyTooltipFix, hotkeyTooltipReload);
			}
			else
			{
				SetTooltipTintColor(null, hotkeyTooltipInteract, hotkeyTooltipFix, hotkeyTooltipReload);
			}
			SetTooltipControllerScheme(player.InputHandler.controllerType, hotkeyTooltipInteract, hotkeyTooltipFix, hotkeyTooltipReload);
		}
		_ = interactable.overridePosition;
		if (interactable.overridePosition == Vector2.zero)
		{
			baseX = interactable.transform.position.x;
			baseY = ((position == HotkeyTooltipsPosition.Upper) ? upperPosition : lowerPosition);
		}
		else
		{
			if (PlayerManager.Instance.Players.Count > 1 && player == PlayerManager.Instance.Players[1])
			{
				BrokenHubStation component = interactable.gameObject.GetComponent<BrokenHubStation>();
				if ((object)component != null && component.isFixed)
				{
					float num = interactable.transform.position.x + interactable.overridePosition.x;
					float num2 = interactable.transform.position.y + (0f - interactable.overridePosition.y);
					baseX = num;
					baseY = num2;
					goto IL_0273;
				}
			}
			Vector2 vector = (Vector2)interactable.transform.position + interactable.overridePosition;
			baseX = vector.x;
			baseY = vector.y;
		}
		goto IL_0273;
		IL_0273:
		LayoutRebuilder.MarkLayoutForRebuild(base.transform.GetComponent<RectTransform>());
		if ((bool)interactable.GetComponent<BrokenHubStation>() && GameManager.Instance.isDemo && !interactable.GetComponent<BrokenHubStation>().isStartingStation)
		{
			SetDemoAlertPanel(interactable, player.InputHandler.controllerType);
		}
		else if ((bool)interactable.GetComponent<BrokenHubStation>() && !interactable.GetComponent<BrokenHubStation>().isFixed && interactable.GetComponent<BrokenHubStation>().coresRequired > 0)
		{
			SetRadarPanel(interactable, interactable.GetComponent<BrokenHubStation>().coresRequired, player.InputHandler.controllerType);
		}
		else
		{
			SetInteractPanel(interactable);
		}
		if ((bool)interactable.GetComponent<Health>())
		{
			SetFixPanel(interactable);
		}
		SetReloadPanel(interactable);
	}

	public void SetInterruptable(Interactable interactable, PlayerController interruptingPc)
	{
		player = interruptingPc;
		SetInteractable(null);
		SetInterruptable(interactable);
	}

	private void SetInterruptable(Interactable interactable)
	{
		if ((bool)interactable && (bool)player)
		{
			interruptOn = true;
			_ = interactable.overridePosition;
			if (interactable.overridePosition == Vector2.zero)
			{
				baseX = interactable.transform.position.x;
				baseY = ((position == HotkeyTooltipsPosition.Upper) ? upperPosition : lowerPosition);
			}
			else
			{
				Vector2 vector = (Vector2)interactable.transform.position + interactable.overridePosition;
				baseX = vector.x;
				baseY = vector.y;
			}
			SetTooltipTintColor(player.GetPlayerColor(), hotkeyTooltipPush);
			hotkeyTooltipPush.gameObject.SetActive(value: true);
			hotkeyTooltipPush.SetControllerType(player.InputHandler.controllerType);
		}
		else
		{
			interruptOn = false;
			hotkeyTooltipPush.gameObject.SetActive(value: false);
		}
	}

	private bool SetInteractPanel(Interactable interactable)
	{
		if (interactable.CanInteract())
		{
			hotkeyTooltipInteract.gameObject.SetActive(value: true);
			if (!player.IsInteracting())
			{
				interactable.GetLocalizedActionName(delegate(string localizedAction)
				{
					hotkeyTooltipInteract.SetActionText(localizedAction);
				});
			}
			else
			{
				interactable.GetLocalizedInactionName(delegate(string localizedInaction)
				{
					hotkeyTooltipInteract.SetActionText(localizedInaction);
				});
			}
			return true;
		}
		hotkeyTooltipInteract.gameObject.SetActive(value: false);
		return false;
	}

	private bool SetFixPanel(Interactable interactable)
	{
		Health component = interactable.GetComponent<Health>();
		float num = component.HealthCurrent / component.HealthMax * 100f;
		Color color = UIManager.Instance.GradientGYR.Evaluate(num / 100f);
		string arg = num.ToString("N0");
		string text = $"<color=#{ColorUtility.ToHtmlStringRGB(color)}>{arg}</color>";
		float num2 = Train.Instance.CoalSeconds / Train.Instance.CoalSecondsCapacity * 100f;
		Color color2 = UIManager.Instance.GradientGYR.Evaluate(num2 / 100f);
		string arg2 = num2.ToString("N0");
		string text2 = $"<color=#{ColorUtility.ToHtmlStringRGB(color2)}>{arg2}</color>";
		if (player.IsRepairDamage())
		{
			hotkeyTooltipFix.gameObject.SetActive(value: true);
			fixingMinorLocalized.Arguments = new object[1] { text };
			hotkeyTooltipFix.SetActionText(fixingMinorLocalized.GetLocalizedString());
			if (!GameManager.Instance.isTimingMinigameEnabled)
			{
				return true;
			}
			repairBar.currentModule = player.interactor.ActiveInteractable.GetComponent<Health>();
			repairBar.currentPlayer = player;
			repairBar.gameObject.SetActive(value: true);
			if (shovelBar.gameObject.activeSelf)
			{
				shovelBar.gameObject.SetActive(value: false);
			}
			return true;
		}
		repairBar.gameObject.SetActive(value: false);
		if (player.isShoveling)
		{
			shovelingLocalized.Arguments = new object[1] { text2 };
			hotkeyTooltipShovel.SetActionText(shovelingLocalized.GetLocalizedString());
			if (!GameManager.Instance.isTimingMinigameEnabled)
			{
				return true;
			}
			shovelBar.currentModule = Train.Instance.GetModuleByType<ModuleFurnace>().HealthComponent;
			shovelBar.currentPlayer = player;
			shovelBar.gameObject.SetActive(value: true);
			if (repairBar.gameObject.activeSelf)
			{
				repairBar.gameObject.SetActive(value: false);
			}
			return true;
		}
		shovelBar.gameObject.SetActive(value: false);
		if (player.IsRepairMinigame())
		{
			hotkeyTooltipFix.SetActionText(stopFixingMinigameLocalized.GetLocalizedString());
			return true;
		}
		if (component.HealthCurrent == component.HealthMax)
		{
			hotkeyTooltipFix.gameObject.SetActive(value: false);
			return false;
		}
		if (component.IsDead)
		{
			hotkeyTooltipFix.SetActionText(fixMinigameLocalized.GetLocalizedString());
			hotkeyTooltipFix.gameObject.SetActive(value: true);
			return true;
		}
		fixLocalized.Arguments = new object[1] { text };
		hotkeyTooltipFix.SetActionText(fixLocalized.GetLocalizedString());
		hotkeyTooltipFix.gameObject.SetActive(value: true);
		return true;
	}

	private bool SetReloadPanel(Interactable interactable)
	{
		Module component = interactable.GetComponent<Module>();
		if (!component)
		{
			return false;
		}
		Module component2 = interactable.GetComponent<Module>();
		if ((object)component2 != null && component2.IsFullyBroken)
		{
			hotkeyTooltipReload.gameObject.SetActive(value: false);
			return false;
		}
		if (component.GetType() != typeof(ModuleCannon))
		{
			hotkeyTooltipReload.gameObject.SetActive(value: false);
			return false;
		}
		ModuleCannon moduleCannon = component as ModuleCannon;
		if (moduleCannon.cannon.AmmoCount >= (float)Mathf.FloorToInt(moduleCannon.GetUpgradedStatValueByStatType(StatTypes.capacity)) || moduleCannon.cannon._reloading)
		{
			hotkeyTooltipReload.gameObject.SetActive(value: false);
			return false;
		}
		hotkeyTooltipReload.gameObject.SetActive(value: true);
		hotkeyTooltipReload.SetActionText(reloadLocalized.GetLocalizedString());
		return true;
	}

	private void SetRadarPanel(Interactable interactable, int price, ControllerType controllerType)
	{
		if (interactable.CanInteract())
		{
			hotkeyTooltipRadar.SetControllerType(controllerType);
			hotkeyTooltipRadar.gameObject.SetActive(value: true);
			radarPrice.text = price.ToString();
		}
		else
		{
			hotkeyTooltipRadar.gameObject.SetActive(value: false);
		}
	}

	private void SetDemoAlertPanel(Interactable interactable, ControllerType controllerType)
	{
		if (interactable.CanInteract())
		{
			hotkeyTooltipDemoAlert.gameObject.SetActive(value: true);
		}
		else
		{
			hotkeyTooltipDemoAlert.gameObject.SetActive(value: false);
		}
	}

	private void CloseBuyPanel(PlayerController player)
	{
		if (this.player == player)
		{
			hotkeyTooltipRadar.gameObject.SetActive(value: false);
		}
	}
}
