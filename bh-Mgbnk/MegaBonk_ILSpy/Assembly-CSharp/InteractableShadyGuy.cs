using System;
using System.Collections.Generic;
using Assets.Scripts.Inventory__Items__Pickups;
using Assets.Scripts.Inventory__Items__Pickups.GoldAndMoney;
using Assets.Scripts.Inventory__Items__Pickups.Items;
using Assets.Scripts.UI.InGame.Rewards;
using Assets.Scripts.UI.Localization;
using Cpp2ILInjected;
using UnityEngine;

public class InteractableShadyGuy : BaseInteractable
{
	public Material matRare;

	public Material matEpic;

	public Material matLegendary;

	public SkinnedMeshRenderer meshRenderer;

	public GameObject smokeFx;

	public RandomSfx purchaseSfx;

	public GameObject[] hideAfterPurchase;

	public EItemRarity rarity;

	public List<ItemData> items;

	public List<int> prices;

	public static InteractableShadyGuy currentlyInteracting;

	private float[] pricesMultipliers;

	public static Action<InteractableShadyGuy> A_ShadyGuyDone;

	private bool done;

	public static string debugName = "Shady Guy";

	private new void Start()
	{
		//IL_0214: Expected O, but got I4
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Expected O, but got Unknown
		//IL_0271: Expected I, but got O
		base.Start();
		EItemRarity eItemRarity = (rarity = Rarity.GetShadyGuyRarity(0f));
		object obj = eItemRarity - 1;
		bool flag = eItemRarity == EItemRarity.Rare;
		Renderer renderer;
		Material material;
		if (!flag)
		{
			object obj2 = obj - 1;
			if (!flag)
			{
				if ((nint)obj2 != 1)
				{
					goto IL_00e9;
				}
				renderer = meshRenderer;
				if ((object)meshRenderer == null)
				{
					goto IL_01d3;
				}
				material = matLegendary;
			}
			else
			{
				renderer = meshRenderer;
				if ((object)meshRenderer == null)
				{
					goto IL_01d3;
				}
				material = matEpic;
			}
		}
		else
		{
			renderer = meshRenderer;
			if ((object)meshRenderer == null)
			{
				goto IL_01d3;
			}
			material = matRare;
		}
		renderer.SetMaterial(material);
		goto IL_00e9;
		IL_02c6:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_02bb;
		IL_02bb:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		return;
		IL_01d3:
		NullReferenceException ex = new NullReferenceException();
		Delegate obj3 = null;
		goto IL_02c6;
		IL_00e9:
		Invoke("FindItems", 1f);
		Action b = OnShadyGuyDone;
		Delegate obj4 = Delegate.Combine(UpgradePicker.A_ShadyGuyDone, b);
		if ((object)obj4 == null)
		{
			UpgradePicker.A_ShadyGuyDone = null;
			return;
		}
		bool flag2 = (object)obj4.GetType() != typeof(Action);
		Delegate obj5 = null;
		if (!flag2)
		{
			obj5 = obj4;
		}
		bool flag3 = (object)obj5 == null;
		float num = 1f;
		obj3 = obj4;
		nint num2 = (nint)typeof(Action);
		if (flag3)
		{
			goto IL_02bb;
		}
		UpgradePicker.A_ShadyGuyDone = (Action)obj5;
		bool flag4 = (object)obj4.GetType() != typeof(Action);
		Delegate obj6 = null;
		if (!flag4)
		{
			obj6 = obj4;
		}
		bool flag5 = (object)obj6 == null;
		num = 1f;
		obj3 = obj4;
		ex = (NullReferenceException)(object)typeof(Action);
		if (!flag5)
		{
			return;
		}
		goto IL_02c6;
	}

	private void FindItems()
	{
		//IL_003e: Expected O, but got I4
		//IL_0047: Expected O, but got I4
		//IL_0077: Unknown result type (might be due to invalid IL or missing references)
		//IL_007c: Expected O, but got Unknown
		List<ItemData> randomItemsShadyGuy = InventoryUtility.GetRandomItemsShadyGuy(rarity);
		items = randomItemsShadyGuy;
		List<ItemData> list = items;
		float[] array = new float[list._size];
		pricesMultipliers = array;
		List<ItemData> list2 = items;
		object obj = 0;
		object obj2 = 0;
		while ((nint)obj2 < list2._size)
		{
			float[] array2 = pricesMultipliers;
			float num = UnityEngine.Random.Range(0.5f, 1.5f);
			object obj3 = obj + 1;
			array2[obj] = num;
			list2 = items;
			obj = obj3;
			obj2 = obj3;
		}
		UpdatePrices();
	}

	private unsafe void UpdatePrices()
	{
		//IL_02df: Expected I, but got O
		//IL_023d: Expected O, but got I
		//IL_01bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c2: Expected O, but got Unknown
		//IL_011b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0120: Expected O, but got Unknown
		//IL_0296: Expected O, but got I
		//IL_027b: Expected I4, but got F8
		List<int> list = new List<int>();
		prices = list;
		List<ItemData> list2 = items;
		int num = 0;
		double num5 = default(double);
		for (int num2 = 0; num2 < list2._size; num2 = num)
		{
			ItemData itemData = items.get_Item(num);
			int itemPriceShadyGuy = MoneyUtility.GetItemPriceShadyGuy(itemData.rarity);
			float[] array = pricesMultipliers;
			List<int> list3 = prices;
			double num3 = (double)itemPriceShadyGuy * (double)array[num];
			nint num4 = (nint)typeof(Math);
			ItemData itemData2 = ((List<ItemData>)(object)typeof(Math)).get_Item((int)(&num5));
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"comisd xmm6,xmm9\"");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v116 @ rcx_v14 (Il2CppClass<System.Math>)+E4]");
			double num6;
			if ((nint)0 >= (nint)0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"ucomisd xmm0,xmm7\"");
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 00000001804CDB5Dh\"");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v116 @ rcx_v14 (Il2CppClass<System.Math>)+E4]");
				if ((nint)0 == 0)
				{
					object obj = num5 & 1;
					bool flag = obj == null;
					num6 = num5;
					if (!flag)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"addsd xmm0,xmm8\"");
						num6 = num5;
					}
				}
				else
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"addsd xmm6,xmm7\"");
					num6 = Math.Floor(num3);
				}
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"ucomisd xmm0,xmm10\"");
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 00000001804CDB8Dh\"");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v116 @ rcx_v14 (Il2CppClass<System.Math>)+E4]");
				if ((nint)0 == 0)
				{
					object obj2 = num5 & 1;
					bool flag2 = obj2 == null;
					num6 = num5;
					if (!flag2)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"subsd xmm0,xmm8\"");
						num6 = num5;
					}
				}
				else
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"subsd xmm6,xmm7\"");
					num6 = Math.Ceiling(num3);
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v99 @ rbx_v7 (System.Collections.Generic.List`1<System.Int32>)+1C]");
			_ = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v99 @ rbx_v7 (System.Collections.Generic.List`1<System.Int32>)+10]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v99 @ rbx_v7 (System.Collections.Generic.List`1<System.Int32>)+18]");
			nint num7 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v105 @ rdx_v10+18]");
			if (num7 >= 0)
			{
				list3.AddWithResize((int)num6);
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v99 @ rbx_v7 (System.Collections.Generic.List`1<System.Int32>)+18]");
				object obj4 = (nint)0 + (nint)1;
			}
			list2 = items;
			num++;
		}
	}

	private new void OnDestroy()
	{
		//IL_012a: Expected I, but got O
		base.OnDestroy();
		Action value = OnShadyGuyDone;
		Delegate obj = Delegate.Remove(UpgradePicker.A_ShadyGuyDone, value);
		if ((object)obj == null)
		{
			UpgradePicker.A_ShadyGuyDone = null;
			return;
		}
		bool flag = (object)obj.GetType() != typeof(Action);
		Delegate obj2 = null;
		if (!flag)
		{
			obj2 = obj;
		}
		if ((object)obj2 != null)
		{
			UpgradePicker.A_ShadyGuyDone = (Action)obj2;
			bool flag2 = (object)obj.GetType() != typeof(Action);
			Delegate obj3 = null;
			if (!flag2)
			{
				obj3 = obj;
			}
			bool flag3 = (object)obj3 == null;
			nint num = (nint)typeof(Action);
			if (!flag3)
			{
				return;
			}
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
	}

	public override bool Interact()
	{
		//IL_004e: Expected I4, but got O
		currentlyInteracting = this;
		UpdatePrices();
		UiManager instance = UiManager.Instance;
		if ((object)UiManager.Instance != null && (object)instance.encounterWindows != null)
		{
			instance.encounterWindows.AddEncounter(EEncounter.ShadyGuy);
			return false;
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	public override string GetInteractString()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183172C6F]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		return LocalizationUtility.GetLocalizedString("Game_Interactables", "SHADY_GUY_INTERACT");
	}

	private void OnShadyGuyDone()
	{
		//IL_008b: Expected O, but got I4
		//IL_0094: Expected O, but got I4
		//IL_00b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00be: Expected O, but got Unknown
		if (currentlyInteracting == this)
		{
			AudioManager instance = AudioManager.Instance;
			instance.purchaseSfx.Play();
			done = true;
			Invoke("Disappear", 1f);
			GameObject[] array = hideAfterPurchase;
			object obj = 0;
			object obj2 = 0;
			while ((nint)obj2 < array.Length)
			{
				array[obj].SetActive(value: false);
				obj++;
				obj2 = obj;
			}
			currentlyInteracting = null;
			Action<InteractableShadyGuy> a_ShadyGuyDone = A_ShadyGuyDone;
			if (A_ShadyGuyDone != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v309 @ rax_v23 (System.Action`1<InteractableShadyGuy>)+18] (should have been resolved before IL gen)");
			}
		}
	}

	private unsafe void Disappear()
	{
		//IL_0117: Expected O, but got Ref
		//IL_0117: Expected O, but got Ref
		GameObject gameObject = base.gameObject;
		Transform transform = gameObject.transform;
		Transform parent = transform.parent;
		GameObject obj = parent.gameObject;
		UnityEngine.Object.Destroy(obj);
		Transform transform2 = smokeFx.transform;
		transform2.parentInternal = null;
		AudioSource component = smokeFx.GetComponent<AudioSource>();
		component.enabled = true;
		smokeFx.SetActive(value: true);
		DestroyObject destroyObject = smokeFx.AddComponent<DestroyObject>();
		destroyObject.time = 2f;
		string localizedString = LocalizationUtility.GetLocalizedString("Game_Interactables", "SHADY_GUY_LEAVE");
		GameObject[] array = hideAfterPurchase;
		Transform transform3 = array[1].transform;
		Vector3 position = transform3.position;
		object obj2 = default(object);
		object obj3 = default(object);
		int textSize = default(int);
		EffectManager.Instance.PopupText(localizedString, (Color)(&obj2), (Vector3)(&obj3), textSize);
	}

	public override bool CanInteract()
	{
		return !done;
	}

	public override bool ShowInDebug()
	{
		return true;
	}

	public override string GetDebugName()
	{
		return debugName;
	}

	public InteractableShadyGuy()
	{
		showOutline = true;
		((MonoBehaviour)this)._002Ector();
	}
}
