using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts._Data.MapsAndStages;
using Assets.Scripts.Actors.Player;
using Assets.Scripts.Inventory__Items__Pickups.Items;
using Assets.Scripts.Managers;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.Localization;

namespace Assets.Scripts.UI.HUD;

public class ObjectiveUi : MonoBehaviour
{
	private sealed class _003CAnimateObjective_003Ed__20 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public ObjectiveUi _003C_003E4__this;

		public LocalizedString objective;

		public bool canComplete;

		public EObjective eObjective;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		public _003CAnimateObjective_003Ed__20(int _003C_003E1__state)
		{
			((IDisposable)this).Dispose();
			this._003C_003E1__state = _003C_003E1__state;
		}

		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			//IL_0014: Expected I4, but got I8
			//IL_007e: Expected I4, but got I8
			//IL_0265: Expected I4, but got O
			//IL_0201: Expected O, but got I
			if (_003C_003E1__state == 0)
			{
				_003C_003E1__state = -1;
				WaitForSeconds waitForSeconds = new WaitForSeconds(1f);
				_003C_003E2__current = waitForSeconds;
				_003C_003E1__state = 1;
				return true;
			}
			if (_003C_003E1__state == 1)
			{
				ObjectiveUi objectiveUi = _003C_003E4__this;
				_003C_003E1__state = -1;
				if ((object)_003C_003E4__this != null && (object)objectiveUi.objectivePrefab != null)
				{
					Transform transform = objectiveUi.objectivePrefab.transform;
					if ((object)transform != null)
					{
						Transform parent = transform.parent;
						GameObject gameObject = UnityEngine.Object.Instantiate(objectiveUi.objectivePrefab, parent);
						if ((object)gameObject != null)
						{
							ObjectivePrefabUi component = gameObject.GetComponent<ObjectivePrefabUi>();
							objectiveUi.currentObjective = component;
							Component currentObjective = objectiveUi.currentObjective;
							if ((object)objectiveUi.currentObjective != null)
							{
								_ = eObjective;
								GameObject gameObject2 = objectiveUi.currentObjective.gameObject;
								if ((object)gameObject2 != null)
								{
									gameObject2.SetActive(value: true);
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v101 @ rsi_v3 (UnityEngine.Component)+20]");
									if ((nint)0 != 0)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v101 @ rsi_v3 (UnityEngine.Component)+20]");
										((GameObject)0).SetActive(canComplete);
										_ = objective;
										objectiveUi.currentObjective.RefreshText();
										if ((object)objectiveUi.a_new != null)
										{
											objectiveUi.a_new.Play();
											return false;
										}
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

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		void IEnumerator.Reset()
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802696E0");
			NotSupportedException ex = new NotSupportedException();
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802696E0");
			throw ex;
		}
	}

	public GameObject objectivePrefab;

	private ObjectivePrefabUi currentObjective;

	public AudioSource a_new;

	public AudioSource a_complete;

	public LocalizedString findBoss;

	public LocalizedString defeatBoss;

	public LocalizedString defeatBossFinal;

	public LocalizedString survive;

	public LocalizedString enterPortal;

	public LocalizedString graveyardCryptEscape;

	public LocalizedString graveyardCryptKeys;

	public LocalizedString graveyardFindCrypt;

	private void Awake()
	{
		//IL_036d: Expected O, but got I4
		//IL_03e0: Expected O, but got I4
		//IL_03f6: Expected I, but got O
		//IL_0533: Expected I, but got O
		//IL_0130: Expected I, but got O
		//IL_0141: Expected O, but got I4
		//IL_0184: Expected I, but got O
		//IL_0195: Expected O, but got I4
		//IL_046c: Expected I, but got O
		//IL_047d: Expected O, but got I4
		//IL_0493: Expected I, but got O
		//IL_04c1: Expected O, but got I4
		//IL_04d7: Expected I, but got O
		//IL_02e9: Expected O, but got I4
		//IL_033d: Expected O, but got I4
		Delegate obj = InteractableBossSpawner.A_BossSpawned;
		Action action = OnBossSpawned;
		Delegate obj2 = Delegate.Combine(InteractableBossSpawner.A_BossSpawned, action);
		Action action2;
		object obj4;
		Delegate obj5;
		if ((object)obj2 == null)
		{
			InteractableBossSpawner.A_BossSpawned = null;
		}
		else
		{
			bool flag = (object)obj2.GetType() != typeof(Action);
			Delegate obj3 = null;
			if (!flag)
			{
				obj3 = obj2;
			}
			if ((object)obj3 == null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
				action2 = action;
				obj4 = 0;
				obj5 = obj2;
				goto IL_04f5;
			}
			InteractableBossSpawner.A_BossSpawned = (Action)obj3;
			bool flag2 = (object)obj2.GetType() != typeof(Action);
			Delegate obj6 = null;
			if (!flag2)
			{
				obj6 = obj2;
			}
			bool flag3 = (object)obj6 == null;
			obj4 = 0;
			obj5 = obj2;
			nint num = (nint)typeof(Action);
			if (flag3)
			{
				goto IL_0505;
			}
		}
		Action<bool> b = OnBossDefeated;
		Delegate obj7 = Delegate.Combine(InteractableBossSpawner.A_BossDefeated, b);
		nint num2;
		Delegate obj8;
		if ((object)obj7 == null)
		{
			InteractableBossSpawner.A_BossDefeated = null;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<bool> action3 = default(Action<bool>);
			bool flag4 = action3 == null;
			num2 = (nint)typeof(Action<bool>);
			obj8 = obj7;
			obj4 = 0;
			obj5 = null;
			if (flag4)
			{
				goto IL_0404;
			}
			InteractableBossSpawner.A_BossDefeated = action3;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj9 = default(object);
			bool flag5 = obj9 == null;
			num2 = (nint)typeof(Action<bool>);
			obj8 = obj7;
			obj4 = 0;
			obj5 = null;
			if (flag5)
			{
				goto IL_0414;
			}
		}
		obj = EnemyManager.A_StageBossDied;
		Action action4 = OnStageBossDied;
		Delegate obj10 = Delegate.Combine(EnemyManager.A_StageBossDied, action4);
		if ((object)obj10 == null)
		{
			EnemyManager.A_StageBossDied = null;
		}
		else
		{
			bool flag6 = (object)obj10.GetType() != typeof(Action);
			Delegate obj11 = null;
			if (!flag6)
			{
				obj11 = obj10;
			}
			bool flag7 = (object)obj11 == null;
			num2 = (nint)obj;
			obj8 = action4;
			obj4 = 0;
			obj5 = obj10;
			nint num3 = (nint)typeof(Action);
			if (flag7)
			{
				goto IL_0510;
			}
			EnemyManager.A_StageBossDied = (Action)obj11;
			bool flag8 = (object)obj10.GetType() != typeof(Action);
			Delegate obj12 = null;
			if (!flag8)
			{
				obj12 = obj10;
			}
			bool flag9 = (object)obj12 == null;
			action2 = action4;
			obj4 = 0;
			obj5 = obj10;
			nint num4 = (nint)typeof(Action);
			if (flag9)
			{
				goto IL_0520;
			}
		}
		Action<EItem> b2 = OnItemAdded;
		Delegate obj13 = Delegate.Combine(ItemInventory.A_ItemAdded, b2);
		if ((object)obj13 == null)
		{
			ItemInventory.A_ItemAdded = null;
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		Action<EItem> action5 = default(Action<EItem>);
		bool flag10 = action5 == null;
		obj = (Delegate)(object)typeof(Action<EItem>);
		action2 = (Action)obj13;
		obj4 = 0;
		obj5 = null;
		if (flag10)
		{
			goto IL_04e5;
		}
		ItemInventory.A_ItemAdded = action5;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		object obj14 = default(object);
		bool flag11 = obj14 == null;
		obj = (Delegate)(object)typeof(Action<EItem>);
		action2 = (Action)obj13;
		obj4 = 0;
		obj5 = null;
		if (!flag11)
		{
			return;
		}
		goto IL_04f5;
		IL_0510:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0414;
		IL_0414:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0404;
		IL_0505:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		return;
		IL_0404:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0505;
		IL_0520:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		num2 = (nint)obj;
		obj8 = action2;
		goto IL_0510;
		IL_04f5:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_04e5;
		IL_04e5:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0520;
	}

	private void OnDestroy()
	{
		//IL_036d: Expected O, but got I4
		//IL_03e0: Expected O, but got I4
		//IL_03f6: Expected I, but got O
		//IL_0533: Expected I, but got O
		//IL_0130: Expected I, but got O
		//IL_0141: Expected O, but got I4
		//IL_0184: Expected I, but got O
		//IL_0195: Expected O, but got I4
		//IL_046c: Expected I, but got O
		//IL_047d: Expected O, but got I4
		//IL_0493: Expected I, but got O
		//IL_04c1: Expected O, but got I4
		//IL_04d7: Expected I, but got O
		//IL_02e9: Expected O, but got I4
		//IL_033d: Expected O, but got I4
		Delegate obj = InteractableBossSpawner.A_BossSpawned;
		Action action = OnBossSpawned;
		Delegate obj2 = Delegate.Remove(InteractableBossSpawner.A_BossSpawned, action);
		Action action2;
		object obj4;
		Delegate obj5;
		if ((object)obj2 == null)
		{
			InteractableBossSpawner.A_BossSpawned = null;
		}
		else
		{
			bool flag = (object)obj2.GetType() != typeof(Action);
			Delegate obj3 = null;
			if (!flag)
			{
				obj3 = obj2;
			}
			if ((object)obj3 == null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
				action2 = action;
				obj4 = 0;
				obj5 = obj2;
				goto IL_04f5;
			}
			InteractableBossSpawner.A_BossSpawned = (Action)obj3;
			bool flag2 = (object)obj2.GetType() != typeof(Action);
			Delegate obj6 = null;
			if (!flag2)
			{
				obj6 = obj2;
			}
			bool flag3 = (object)obj6 == null;
			obj4 = 0;
			obj5 = obj2;
			nint num = (nint)typeof(Action);
			if (flag3)
			{
				goto IL_0505;
			}
		}
		Action<bool> value = OnBossDefeated;
		Delegate obj7 = Delegate.Remove(InteractableBossSpawner.A_BossDefeated, value);
		nint num2;
		Delegate obj8;
		if ((object)obj7 == null)
		{
			InteractableBossSpawner.A_BossDefeated = null;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<bool> action3 = default(Action<bool>);
			bool flag4 = action3 == null;
			num2 = (nint)typeof(Action<bool>);
			obj8 = obj7;
			obj4 = 0;
			obj5 = null;
			if (flag4)
			{
				goto IL_0404;
			}
			InteractableBossSpawner.A_BossDefeated = action3;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj9 = default(object);
			bool flag5 = obj9 == null;
			num2 = (nint)typeof(Action<bool>);
			obj8 = obj7;
			obj4 = 0;
			obj5 = null;
			if (flag5)
			{
				goto IL_0414;
			}
		}
		obj = EnemyManager.A_StageBossDied;
		Action action4 = OnStageBossDied;
		Delegate obj10 = Delegate.Remove(EnemyManager.A_StageBossDied, action4);
		if ((object)obj10 == null)
		{
			EnemyManager.A_StageBossDied = null;
		}
		else
		{
			bool flag6 = (object)obj10.GetType() != typeof(Action);
			Delegate obj11 = null;
			if (!flag6)
			{
				obj11 = obj10;
			}
			bool flag7 = (object)obj11 == null;
			num2 = (nint)obj;
			obj8 = action4;
			obj4 = 0;
			obj5 = obj10;
			nint num3 = (nint)typeof(Action);
			if (flag7)
			{
				goto IL_0510;
			}
			EnemyManager.A_StageBossDied = (Action)obj11;
			bool flag8 = (object)obj10.GetType() != typeof(Action);
			Delegate obj12 = null;
			if (!flag8)
			{
				obj12 = obj10;
			}
			bool flag9 = (object)obj12 == null;
			action2 = action4;
			obj4 = 0;
			obj5 = obj10;
			nint num4 = (nint)typeof(Action);
			if (flag9)
			{
				goto IL_0520;
			}
		}
		Action<EItem> value2 = OnItemAdded;
		Delegate obj13 = Delegate.Remove(ItemInventory.A_ItemAdded, value2);
		if ((object)obj13 == null)
		{
			ItemInventory.A_ItemAdded = null;
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		Action<EItem> action5 = default(Action<EItem>);
		bool flag10 = action5 == null;
		obj = (Delegate)(object)typeof(Action<EItem>);
		action2 = (Action)obj13;
		obj4 = 0;
		obj5 = null;
		if (flag10)
		{
			goto IL_04e5;
		}
		ItemInventory.A_ItemAdded = action5;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		object obj14 = default(object);
		bool flag11 = obj14 == null;
		obj = (Delegate)(object)typeof(Action<EItem>);
		action2 = (Action)obj13;
		obj4 = 0;
		obj5 = null;
		if (!flag11)
		{
			return;
		}
		goto IL_04f5;
		IL_0510:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0414;
		IL_0414:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0404;
		IL_0505:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		return;
		IL_0404:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0505;
		IL_0520:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		num2 = (nint)obj;
		obj8 = action2;
		goto IL_0510;
		IL_04f5:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_04e5;
		IL_04e5:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0520;
	}

	private void Start()
	{
		if (!MapController.isFinalBossStage)
		{
			Invoke("FirstObjective", 4f);
		}
		else
		{
			Invoke("FinalBossObjective", 0.5f);
		}
	}

	private void FirstObjective()
	{
		MapData mapData = MapController._003CcurrentMap_003Ek__BackingField;
		if (mapData.eMap != EMap.Graveyard)
		{
			AddObjective(findBoss, canComplete: true);
		}
		else
		{
			AddObjective(graveyardCryptEscape, canComplete: true);
		}
	}

	public void GraveyardKeys()
	{
		AddObjective(graveyardCryptKeys, canComplete: true, EObjective.CryptKeys);
	}

	private void FinalBossObjective()
	{
		AddObjective(defeatBossFinal, canComplete: true);
	}

	public void AddObjective(LocalizedString localizedString, bool canComplete, EObjective eObjective = EObjective.Generic)
	{
		CancelInvoke("FirstObjective");
		if (currentObjective != null)
		{
			currentObjective.Complete();
			a_complete.Play();
		}
		_003CAnimateObjective_003Ed__20 obj = new _003CAnimateObjective_003Ed__20(0);
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		obj.objective = localizedString;
		obj.canComplete = canComplete;
		obj.eObjective = eObjective;
		Coroutine coroutine = StartCoroutine(obj);
	}

	public void CompleteCurrentObjective()
	{
		if (currentObjective != null)
		{
			currentObjective.Complete();
			a_complete.Play();
			currentObjective = null;
		}
	}

	private IEnumerator AnimateObjective(LocalizedString objective, bool canComplete, EObjective eObjective)
	{
		_003CAnimateObjective_003Ed__20 obj = new _003CAnimateObjective_003Ed__20(0);
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		obj.objective = objective;
		obj.canComplete = canComplete;
		obj.eObjective = eObjective;
		return obj;
	}

	public void OnBossSpawned()
	{
		AddObjective(defeatBoss, canComplete: true);
	}

	private void OnBossDefeated(bool isOpeningPortal)
	{
		//IL_001b: Expected O, but got I
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Assets.Scripts.UI.HUD.ObjectiveUi)+58+isOpeningPortal @ rdx (System.Boolean)*8]");
		AddObjective((LocalizedString)0, isOpeningPortal);
	}

	private void OnStageBossDied()
	{
		if (MapController.isFinalBossStage && currentObjective != null)
		{
			currentObjective.Complete();
			a_complete.Play();
			currentObjective = null;
		}
	}

	private void OnItemAdded(EItem eItem)
	{
		MapData mapData = MapController._003CcurrentMap_003Ek__BackingField;
		if (mapData.eMap == EMap.Graveyard && eItem == EItem.CryptKey)
		{
			MyPlayer instance = MyPlayer.Instance;
			PlayerInventory inventory = instance.inventory;
			int amount = inventory.itemInventory.GetAmount(EItem.CryptKey);
			if (amount == 4)
			{
				AddObjective(graveyardFindCrypt, canComplete: true);
			}
		}
	}
}
