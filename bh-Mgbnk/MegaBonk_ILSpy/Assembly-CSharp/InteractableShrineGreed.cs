using System;
using Assets.Scripts.Inventory__Items__Pickups.GoldAndMoney;
using Assets.Scripts.UI.InGame.Rewards;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.Localization;

public class InteractableShrineGreed : BaseInteractable
{
	public LocalizedString localizationName;

	public GameObject minimapIcon;

	public GameObject alertIcon;

	private bool done;

	public GameObject fx;

	public GameObject fxLoop;

	public EffectStat statEffect;

	public static string debugName = "Greed Shrines";

	public unsafe override bool Interact()
	{
		//IL_024d: Expected I4, but got O
		//IL_0208: Expected O, but got Ref
		if (!done)
		{
			done = true;
			if ((object)fx != null)
			{
				fx.SetActive(value: true);
				if ((object)fxLoop != null)
				{
					fxLoop.SetActive(value: true);
					if (statEffect != null)
					{
						statEffect.ApplyEffect();
						if (statEffect != null)
						{
							string effectName = statEffect.GetEffectName();
							if (statEffect != null)
							{
								string effectNumber = statEffect.GetEffectNumber();
								if (!string.IsNullOrEmpty(effectNumber) && !string.IsNullOrEmpty(effectName))
								{
									UiManager instance = UiManager.Instance;
									if ((object)UiManager.Instance == null || (object)instance.scoreUi == null)
									{
										goto IL_023f;
									}
									bool useSfx = default(bool);
									float sizeMultiplier = default(float);
									instance.scoreUi.AddScore(effectName, effectNumber, isPositive: true, useSfx, sizeMultiplier);
								}
								int chestPrice = MoneyUtility.GetChestPrice();
								Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm0\"");
								bool flag = chestPrice <= 25;
								int amount = 25;
								if (!flag)
								{
									amount = chestPrice;
								}
								Transform transform = base.transform;
								if ((object)transform != null)
								{
									Vector3 position = transform.position;
									object obj = default(object);
									MoneyUtility.SpawnMoney(amount, (Vector3)(&obj));
									UnityEngine.Object.Destroy(minimapIcon);
									UnityEngine.Object.Destroy(alertIcon);
									OnDestroy();
									return true;
								}
							}
						}
					}
				}
			}
			goto IL_023f;
		}
		return false;
		IL_023f:
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	public override bool CanInteract()
	{
		return !done;
	}

	public override string GetInteractString()
	{
		if (localizationName != null)
		{
			return localizationName.GetLocalizedString();
		}
		return (string)(object)new NullReferenceException();
	}

	public override bool ShowInDebug()
	{
		return true;
	}

	public override string GetDebugName()
	{
		return debugName;
	}

	public InteractableShrineGreed()
	{
		showOutline = true;
		((MonoBehaviour)this)._002Ector();
	}
}
