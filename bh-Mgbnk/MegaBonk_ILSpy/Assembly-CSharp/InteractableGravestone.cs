using System;
using Actors.Enemies;
using Assets.Scripts.Actors.Enemies;
using Assets.Scripts.Managers;
using Assets.Scripts.UI.InGame.Rewards;
using UnityEngine;
using UnityEngine.Localization;

public class InteractableGravestone : BaseInteractable
{
	public LocalizedString localizationName;

	private bool done;

	public GameObject fx;

	public EffectStat[] statEffects;

	private static int numInteractions = 0;

	public static string debugName = "Gravestones";

	private void Awake()
	{
		numInteractions = 0;
	}

	public unsafe override bool Interact()
	{
		//IL_0384: Expected I4, but got O
		//IL_00fb: Expected O, but got I4
		//IL_0105: Expected O, but got I4
		//IL_0252: Expected O, but got I4
		//IL_022c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0231: Expected O, but got Unknown
		//IL_0345: Expected I4, but got F4
		//IL_0345: Expected O, but got Ref
		if (!done)
		{
			done = true;
			GameObject gameObject = base.gameObject;
			if ((object)gameObject != null)
			{
				gameObject.SetActive(value: false);
				if ((object)fx != null)
				{
					fx.SetActive(value: true);
					if ((object)fx != null)
					{
						Transform transform = fx.transform;
						if ((object)transform != null)
						{
							transform.parentInternal = null;
							EffectStat[] array = statEffects;
							if (statEffects != null)
							{
								object obj = 0;
								object obj2 = 0;
								bool flag = default(bool);
								float num = default(float);
								object obj4 = default(object);
								bool canBeElite = default(bool);
								float extraSizeMultiplier = default(float);
								while (true)
								{
									if ((nint)obj2 < array.Length)
									{
										if (array[obj] == null)
										{
											break;
										}
										array[obj].ApplyEffect();
										string effectName = array[obj].GetEffectName();
										string effectNumber = array[obj].GetEffectNumber();
										if (!string.IsNullOrEmpty(effectNumber) && !string.IsNullOrEmpty(effectName))
										{
											UiManager instance = UiManager.Instance;
											if ((object)UiManager.Instance == null || (object)instance.scoreUi == null)
											{
												break;
											}
											instance.scoreUi.AddScore(effectName, effectNumber, isPositive: true, flag, num);
										}
										obj++;
										obj2 = obj;
										continue;
									}
									bool flag2 = numInteractions == 0;
									EEnemy eEnemy;
									if (!flag2)
									{
										object obj3 = numInteractions - 1;
										eEnemy = (flag2 ? EEnemy.GreaterGhost : (((nint)obj3 == 1) ? EEnemy.GhostPurple : EEnemy.GhostRed));
									}
									else
									{
										eEnemy = EEnemy.Ghost;
									}
									if ((object)DataManager.Instance == null)
									{
										break;
									}
									EnemyData enemyData = DataManager.Instance.GetEnemyData(eEnemy);
									Transform transform2 = base.transform;
									if ((object)transform2 == null)
									{
										break;
									}
									Vector3 position = transform2.position;
									if ((object)EnemyManager.Instance == null)
									{
										break;
									}
									Enemy enemy = EnemyManager.Instance.SpawnEnemy(enemyData, (Vector3)(&obj4), 0, flag, (EEnemyFlag)num, canBeElite, extraSizeMultiplier);
									int num2 = numInteractions + 1;
									numInteractions = num2;
									return true;
								}
							}
						}
					}
				}
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
		return false;
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

	public InteractableGravestone()
	{
		showOutline = true;
		((MonoBehaviour)this)._002Ector();
	}
}
