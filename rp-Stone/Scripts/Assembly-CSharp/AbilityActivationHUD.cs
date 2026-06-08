using System;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class AbilityActivationHUD : MonoBehaviour
{
	private const float MESSAGE_DURATION = 3f;

	public DialogButton potionButton;

	public DialogButton weaponButton;

	public AsciiString message;

	private List<DialogButton> buttons = new List<DialogButton>();

	private List<IAbilityActivationProvider> abilityProviders = new List<IAbilityActivationProvider>();

	private List<Binding.Action> actions = new List<Binding.Action>();

	private List<DialogButton> potionButtonPool = new List<DialogButton>();

	private List<DialogButton> weaponButtonPool = new List<DialogButton>();

	private float messageTimeRemaining;

	private int isActive;

	private static int disabledCountdown;

	public static bool activationFullDisable;

	private float[] flashWhite = new float[8];

	public event Action<IAbilityActivationProvider, SuperAbilityActivationState, bool> OnActivated;

	public void UpdateContents()
	{
		abilityProviders.Clear();
		actions.Clear();
		for (int i = 0; i < buttons.Count; i++)
		{
			DialogButton dialogButton = buttons[i];
			if (dialogButton.sourcePrefab == potionButton)
			{
				potionButtonPool.Add(dialogButton);
			}
			else
			{
				weaponButtonPool.Add(dialogButton);
			}
		}
		buttons.Clear();
		Item firstItemWithId = Inventory.Singleton.GetFirstItemWithId("potion");
		TryAddAbility(firstItemWithId, potionButtonPool, potionButton, Binding.Action.Potion);
		Hero hero = GameStates.Singleton.hero;
		TryAddAbility(hero.LeftHand, weaponButtonPool, weaponButton, Binding.Action.ItemLeft);
		TryAddAbility(hero.RightHand, weaponButtonPool, weaponButton, Binding.Action.ItemRight);
		Binding.Action action = Binding.Action.Dynamic1;
		DynamicActivatedAbilityProvider component = hero.GetComponent<DynamicActivatedAbilityProvider>();
		for (int j = 0; j < component.activatedAbilities.Count; j++)
		{
			IAbilityActivationProvider abilityActivationProvider = component.activatedAbilities[j];
			if (abilityActivationProvider != null)
			{
				TryAddAbility(abilityActivationProvider, weaponButtonPool, weaponButton, action);
			}
			action++;
		}
	}

	private void TryAddAbility(Item item, List<DialogButton> pool, DialogButton sourceButton, Binding.Action action)
	{
		if (!(item == null))
		{
			IAbilityActivationProvider abilityActivationProvider = item as IAbilityActivationProvider;
			if (abilityActivationProvider == null)
			{
				abilityActivationProvider = item.GetComponent<IAbilityActivationProvider>();
			}
			TryAddAbility(abilityActivationProvider, pool, sourceButton, action);
		}
	}

	private void TryAddAbility(IAbilityActivationProvider provider, List<DialogButton> pool, DialogButton sourceButton, Binding.Action action)
	{
		if (provider != null && provider.IsAvailable())
		{
			abilityProviders.Add(provider);
			actions.Add(action);
			if (pool.Count <= 0)
			{
				PoolAdditionalButton(pool, sourceButton);
			}
			DialogButton dialogButton = pool[0];
			pool.RemoveAt(0);
			dialogButton.PositionX = 1 + buttons.Count * 9;
			buttons.Add(dialogButton);
		}
	}

	public void UpdateTic()
	{
		if (GameStates.Singleton.level.QuestData.hideHUD)
		{
			return;
		}
		disabledCountdown--;
		if (IsDisabledState())
		{
			return;
		}
		for (int i = 0; i < abilityProviders.Count; i++)
		{
			IAbilityActivationProvider abilityActivationProvider = abilityProviders[i];
			if (abilityActivationProvider.IsWaiting() && abilityActivationProvider.IsEnabled())
			{
				buttons[i].UpdateTic();
			}
		}
		isActive = Mathf.CeilToInt(1f / 30f / Time.deltaTime);
	}

	public void Draw(AsciiRenderProcedural r)
	{
		if (GameStates.Singleton.level.QuestData.hideHUD || !Hud.IsEnabled(Hud.Flag.ABILITIES))
		{
			return;
		}
		for (int i = 0; i < abilityProviders.Count; i++)
		{
			IAbilityActivationProvider abilityActivationProvider = abilityProviders[i];
			DialogButton dialogButton = buttons[i];
			dialogButton.Draw(r, 0, 0);
			AsciiSprite icon = abilityActivationProvider.GetIcon();
			if (icon != null)
			{
				if (IsDisabledState() || !abilityActivationProvider.IsEnabled())
				{
					icon.Draw(r, dialogButton.PositionX + dialogButton.Width / 2, dialogButton.PositionY + dialogButton.Height / 2, Color.grey);
				}
				else
				{
					icon.Draw(r, dialogButton.PositionX + dialogButton.Width / 2, dialogButton.PositionY + dialogButton.Height / 2);
				}
			}
			Binding.Action action = actions[i];
			KeyCode codeForAction = Binding.singleton.GetCodeForAction(action);
			string text = codeForAction.ToString();
			if (codeForAction != KeyCode.None && text != null && text.Length > 0)
			{
				char c = text[0];
				int num = dialogButton.lastDrawX + dialogButton.Width - 3;
				int y = dialogButton.lastDrawY + dialogButton.Height - 1;
				Color color = dialogButton.edgeSymbols.color;
				r.SetCell(num, y, SpecialSymbols.Map(c), color);
				r.SetCell(num - 1, y, 91, color);
				r.SetCell(num + 1, y, 93, color);
			}
			float num2 = 1f - abilityActivationProvider.GetCooldownRemaining();
			if (num2 < 1f)
			{
				num2 *= 360f;
				float num3 = (float)dialogButton.Width / 2f;
				float num4 = (float)dialogButton.Height / 2f;
				for (int j = 0; j < dialogButton.Width; j++)
				{
					for (int k = 0; k < dialogButton.Height; k++)
					{
						AsciiCellProcedural cell = r.GetCell(j + dialogButton.lastDrawnX, k + dialogButton.lastDrawnY);
						if (cell == null)
						{
							continue;
						}
						float x = (float)j - num3;
						float num5 = Mathf.Repeat(Mathf.Atan2(((float)k - num4) * 1.7f, x) * 180f / MathF.PI + 360f + 90f, 360f);
						float num6 = num5 - num2 + 14f;
						if (num5 > 0f)
						{
							Color foreground = cell.GetForeground();
							if (num6 < 28f)
							{
								cell.SetForeground(foreground * Mathf.Lerp(1f, 0.2f, num6 / 28f));
							}
							else
							{
								cell.SetForeground(foreground * 0.2f);
							}
						}
					}
				}
				flashWhite[i] = 2f;
			}
			else
			{
				if (!(flashWhite[i] > 0.05f))
				{
					continue;
				}
				for (int l = 0; l < dialogButton.Width; l++)
				{
					if (IsDisabledState())
					{
						break;
					}
					for (int m = 0; m < dialogButton.Height; m++)
					{
						AsciiCellProcedural cell2 = r.GetCell(l + dialogButton.lastDrawnX, m + dialogButton.lastDrawnY);
						if (cell2 != null)
						{
							Color foreground2 = cell2.GetForeground();
							cell2.SetForeground(Color.Lerp(foreground2, ColorConstants.white, flashWhite[i]));
						}
					}
				}
				flashWhite[i] = Mathf.Lerp(flashWhite[i], 0f, Time.deltaTime * 20f);
			}
		}
		if (messageTimeRemaining > 0f)
		{
			message.Draw(r, 0, 0);
		}
	}

	private void Update()
	{
		messageTimeRemaining -= Time.deltaTime;
		if (isActive-- <= 0)
		{
			return;
		}
		for (int i = 0; i < Binding.singleton.boundKeyCodes.Count; i++)
		{
			KeyCode keyCode = Binding.singleton.boundKeyCodes[i];
			if (Input.GetKeyDown(keyCode))
			{
				FireWithKeyCode(keyCode);
			}
		}
	}

	public void FirePotionActivated(bool withStonescript = false)
	{
		if (abilityProviders.Count <= 0)
		{
			return;
		}
		IAbilityActivationProvider abilityActivationProvider = Inventory.Singleton.GetFirstItemWithId("potion") as IAbilityActivationProvider;
		for (int i = 0; i < abilityProviders.Count; i++)
		{
			if (abilityActivationProvider == abilityProviders[i])
			{
				FireAbilityActivated(abilityProviders[i], withStonescript);
				break;
			}
		}
	}

	public void FireRightItemActivated(bool withStonescript = false)
	{
		FireWithKeyCode(KeyCode.R, withStonescript);
	}

	public void FireLeftItemActivated(bool withStonescript = false)
	{
		FireWithKeyCode(KeyCode.E, withStonescript);
	}

	public void FireFaerieItemActivated(bool withStonescript = false)
	{
		FireWithKeyCode(KeyCode.W, withStonescript);
	}

	public void FireAbilityWithId(string abilityId, bool withStonescript = false)
	{
		for (int i = 0; i < abilityProviders.Count; i++)
		{
			IAbilityActivationProvider abilityActivationProvider = abilityProviders[i];
			if (Compare(abilityId, abilityActivationProvider.GetId()) && abilityActivationProvider.IsWaiting() && abilityActivationProvider.IsEnabled())
			{
				FireAbilityActivated(abilityActivationProvider, withStonescript);
				break;
			}
		}
	}

	private bool Compare(string a, string b)
	{
		return CultureInfo.InvariantCulture.CompareInfo.IndexOf(a, b, CompareOptions.IgnoreCase) == 0;
	}

	private void FireWithKeyCode(KeyCode code, bool withStonescript = false)
	{
		Binding.Action actionForCode = Binding.singleton.GetActionForCode(code);
		FireWithAction(actionForCode, withStonescript);
	}

	private void FireWithAction(Binding.Action action, bool withStonescript = false)
	{
		for (int i = 0; i < abilityProviders.Count; i++)
		{
			if (action == actions[i])
			{
				IAbilityActivationProvider abilityActivationProvider = abilityProviders[i];
				if (abilityActivationProvider.IsWaiting() && abilityActivationProvider.IsEnabled())
				{
					FireAbilityActivated(abilityActivationProvider, withStonescript);
					break;
				}
			}
		}
	}

	private void FireAbilityActivated(IAbilityActivationProvider provider, bool withStonescript = false)
	{
		if (IsDisabledState())
		{
			return;
		}
		SuperAbilityActivationState superAbilityActivationState = provider.ActivateAbility();
		if (superAbilityActivationState != null)
		{
			if (superAbilityActivationState.CanActivate())
			{
				if (this.OnActivated != null)
				{
					this.OnActivated(provider, superAbilityActivationState, withStonescript);
				}
			}
			else
			{
				SetMessage(superAbilityActivationState.errorMessage);
			}
		}
		else if (this.OnActivated != null)
		{
			this.OnActivated(provider, null, withStonescript);
		}
		UpdateContents();
	}

	public bool IsAbilityEnabled(string abilityId)
	{
		for (int i = 0; i < abilityProviders.Count; i++)
		{
			IAbilityActivationProvider abilityActivationProvider = abilityProviders[i];
			if (abilityActivationProvider.GetId() == abilityId)
			{
				return abilityActivationProvider.IsEnabled();
			}
		}
		return false;
	}

	public static bool IsDisabledState()
	{
		if (activationFullDisable || GameStates.Singleton.level.gameTime <= 1)
		{
			return true;
		}
		if (GameStates.Singleton.hero.GetComponent<HeroAI>().targetWaypoint != null)
		{
			disabledCountdown = 3;
		}
		return disabledCountdown > 0;
	}

	private void HandleButtonPressed(DialogButton btn)
	{
		for (int i = 0; i < buttons.Count; i++)
		{
			if (btn == buttons[i] && abilityProviders[i].IsWaiting())
			{
				FireAbilityActivated(abilityProviders[i]);
				break;
			}
		}
	}

	private void SetMessage(string msg)
	{
		messageTimeRemaining = 3f;
		message.SetValue(msg);
	}

	private void PoolAdditionalButton(List<DialogButton> pool, DialogButton buttonPrefab)
	{
		DialogButton dialogButton = UnityEngine.Object.Instantiate(buttonPrefab);
		dialogButton.sourcePrefab = buttonPrefab;
		pool.Add(dialogButton);
		dialogButton.OnPressed += HandleButtonPressed;
	}

	private void Start()
	{
		PoolAdditionalButton(potionButtonPool, potionButton);
		PoolAdditionalButton(weaponButtonPool, weaponButton);
		PoolAdditionalButton(weaponButtonPool, weaponButton);
	}

	private void OnDestroy()
	{
		for (int i = 0; i < buttons.Count; i++)
		{
			buttons[i].OnPressed -= HandleButtonPressed;
		}
		for (int j = 0; j < potionButtonPool.Count; j++)
		{
			potionButtonPool[j].OnPressed -= HandleButtonPressed;
		}
		for (int k = 0; k < weaponButtonPool.Count; k++)
		{
			weaponButtonPool[k].OnPressed -= HandleButtonPressed;
		}
		buttons.Clear();
		potionButtonPool.Clear();
		weaponButtonPool.Clear();
	}
}
