using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Assets.Scripts.Actors.Player;
using Assets.Scripts.Inventory__Items__Pickups.Items;
using Assets.Scripts.Utility;
using Cpp2ILInjected;
using TMPro;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.UI;
using UnityEngine.UIElements.Experimental;

namespace Assets.Scripts.UI.HUD;

public class ObjectivePrefabUi : MonoBehaviour
{
	public GameObject checkBox;

	public GameObject checkMark;

	public TextMeshProUGUI t_objective;

	public LayoutGroup content;

	public TextSizer textSizer;

	private EObjective eObjective;

	private LocalizedString localizedObjective;

	public RawImage overlay;

	private float padding;

	private int paddingWidth;

	private float slideTime;

	private float timer;

	private bool completed;

	private Color completedColor;

	private void Awake()
	{
		//IL_00b2: Expected I, but got O
		//IL_008a: Expected I, but got O
		Action<EItem> b = OnItemAdded;
		Delegate obj = Delegate.Combine(ItemInventory.A_ItemAdded, b);
		if ((object)obj == null)
		{
			ItemInventory.A_ItemAdded = (Action<EItem>)obj;
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		Action<EItem> action = default(Action<EItem>);
		if (action != null)
		{
			ItemInventory.A_ItemAdded = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj2 = default(object);
			bool flag = obj2 == null;
			nint num = (nint)typeof(Action<EItem>);
			if (!flag)
			{
				return;
			}
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
			nint num = (nint)typeof(Action<EItem>);
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
	}

	private void OnDestroy()
	{
		//IL_00b2: Expected I, but got O
		//IL_008a: Expected I, but got O
		Action<EItem> value = OnItemAdded;
		Delegate obj = Delegate.Remove(ItemInventory.A_ItemAdded, value);
		if ((object)obj == null)
		{
			ItemInventory.A_ItemAdded = (Action<EItem>)obj;
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		Action<EItem> action = default(Action<EItem>);
		if (action != null)
		{
			ItemInventory.A_ItemAdded = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj2 = default(object);
			bool flag = obj2 == null;
			nint num = (nint)typeof(Action<EItem>);
			if (!flag)
			{
				return;
			}
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
			nint num = (nint)typeof(Action<EItem>);
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
	}

	private void OnItemAdded(EItem eItem)
	{
		if (eObjective == EObjective.CryptKeys && eItem == EItem.CryptKey)
		{
			RefreshText();
		}
	}

	private unsafe void RefreshText()
	{
		//IL_02d2: Expected I, but got O
		//IL_00db: Expected I, but got O
		//IL_00e8: Expected O, but got Ref
		//IL_0184: Expected I, but got O
		//IL_019d: Expected O, but got I
		//IL_036d: Expected O, but got I
		//IL_01e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e9: Expected O, but got Unknown
		//IL_0215: Expected I, but got O
		//IL_0258: Expected I, but got O
		string localizedString;
		TextMeshProUGUI textMeshProUGUI;
		if (eObjective != EObjective.Generic)
		{
			if (eObjective != EObjective.CryptKeys)
			{
				goto IL_0324;
			}
			ItemInventory itemInventory = (ItemInventory)(object)this;
			MyPlayer instance = MyPlayer.Instance;
			if ((object)MyPlayer.Instance != null)
			{
				PlayerInventory inventory = instance.inventory;
				if (instance.inventory != null)
				{
					itemInventory = inventory.itemInventory;
					if (inventory.itemInventory != null)
					{
						int amount = inventory.itemInventory.GetAmount(EItem.CryptKey);
						Dictionary<string, string> dictionary = new Dictionary<string, string>();
						int num = default(int);
						string value = num.ToString();
						bool flag = dictionary == null;
						nint num2 = unchecked((nint)null);
						object obj = null;
						itemInventory = (ItemInventory)(&num);
						if (!flag)
						{
							((Dictionary<object, object>)(object)dictionary).Add((object)"current", (object)value);
							int num3 = default(int);
							string text = num3.ToString();
							((Dictionary<object, object>)(object)dictionary).Add((object)"target", (object)text);
							object[] array = new object[1];
							bool flag2 = array == null;
							num2 = 1;
							obj = text;
							itemInventory = (ItemInventory)(object)typeof(object[]);
							if (!flag2)
							{
								nint num4 = (nint)array;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v406 @ rdx_v17 (Il2CppClass<System.Object[]>)+40]");
								dictionary.Add((string)0, text);
								object obj2 = default(object);
								bool flag3 = obj2 == null;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v406 @ rdx_v17 (Il2CppClass<System.Object[]>)+40]");
								num2 = 0;
								obj = text;
								itemInventory = (ItemInventory)(object)dictionary;
								if (flag3)
								{
									((Dictionary<string, string>)(object)itemInventory).Add((string)num2, (string)obj);
									object obj3 = default(object);
									throw obj3;
								}
								itemInventory = (ItemInventory)(array + 32);
								array[0] = dictionary;
								bool flag4 = localizedObjective == null;
								num2 = (nint)dictionary;
								obj = text;
								if (!flag4)
								{
									localizedString = localizedObjective.GetLocalizedString(array);
									bool flag5 = (object)t_objective == null;
									num2 = (nint)array;
									obj = null;
									itemInventory = (ItemInventory)(object)localizedObjective;
									if (!flag5)
									{
										textMeshProUGUI = t_objective;
										goto IL_037f;
									}
								}
							}
						}
					}
				}
			}
		}
		else
		{
			bool flag6 = localizedObjective == null;
			ItemInventory itemInventory = (ItemInventory)(object)localizedObjective;
			if (!flag6)
			{
				localizedString = localizedObjective.GetLocalizedString();
				bool flag7 = (object)t_objective == null;
				nint num2 = unchecked((nint)null);
				itemInventory = (ItemInventory)(object)localizedObjective;
				if (!flag7)
				{
					textMeshProUGUI = t_objective;
					goto IL_037f;
				}
			}
		}
		throw new NullReferenceException();
		IL_0324:
		Invoke("PadAndRebuild", 0.5f);
		return;
		IL_037f:
		textMeshProUGUI.text = localizedString;
		goto IL_0324;
	}

	public void Set(LocalizedString localizedObjective, bool showCheckmark, EObjective eObjective = EObjective.Generic)
	{
		this.eObjective = eObjective;
		GameObject gameObject = base.gameObject;
		gameObject.SetActive(value: true);
		checkBox.SetActive(showCheckmark);
		this.localizedObjective = localizedObjective;
		RefreshText();
	}

	private unsafe void Update()
	{
		//IL_0008: Expected O, but got Ref
		//IL_06fa: Invalid comparison between I4 and F4
		//IL_03b2: Expected F4, but got I4
		//IL_072e: Invalid comparison between I4 and F4
		//IL_03ee: Expected F4, but got I4
		//IL_0569: Invalid comparison between I4 and F4
		//IL_008d: Expected F4, but got I4
		//IL_0401: Expected O, but got Ref
		//IL_00a8: Invalid comparison between I4 and F4
		//IL_07eb: Expected I, but got O
		//IL_084a: Expected I, but got O
		//IL_00fb: Expected F4, but got I4
		//IL_095c: Invalid comparison between I4 and F4
		//IL_0474: Expected F4, but got I4
		//IL_0176: Invalid comparison between I4 and F4
		//IL_01c1: Expected F4, but got I4
		//IL_048c: Expected O, but got Ref
		//IL_05b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_05bb: Expected O, but got Unknown
		//IL_01e4: Expected O, but got Ref
		//IL_05ce: Expected I, but got O
		//IL_062d: Expected I, but got O
		//IL_091a: Invalid comparison between I4 and F4
		//IL_0258: Expected F4, but got I4
		//IL_0270: Expected O, but got Ref
		//IL_02d4: Expected O, but got Ref
		//IL_0317: Expected I, but got O
		//IL_0325: Expected O, but got Ref
		object obj2 = default(object);
		object obj = (object)(&obj2);
		RectOffset rectOffset;
		if (timer < 1f)
		{
			if (completed || !(1f > timer))
			{
				float num = MyTime.deltaTime + MyTime.deltaTime;
				float num2 = num + timer;
				if (!(0f > num2))
				{
					if (num2 > 1f)
					{
						num2 = 1f;
					}
				}
				else
				{
					num2 = 0f;
				}
				timer = num2;
				float num3 = Easing.InQuad(num2);
				if (!(0f > num3))
				{
					if (num3 > 1f)
					{
						num3 = 1f;
					}
				}
				else
				{
					num3 = 0f;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Assets.Scripts.UI.HUD.ObjectivePrefabUi)+78]");
				float num4 = 0f - 1f;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Assets.Scripts.UI.HUD.ObjectivePrefabUi)+80]");
				float num5 = 0f - 1f;
				float num6 = (float)completedColor * num3;
				float num7 = num4 * num3;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Assets.Scripts.UI.HUD.ObjectivePrefabUi)+7C]");
				float num8 = 0f * num3;
				float num9 = num5 * num3;
				float num10 = num7 + 1f;
				float num11 = num9 + 1f;
				Color color = (Color)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 57));
				overlay.color = color;
				Transform transform = content.transform;
				nint num12 = (nint)typeof(Vector3);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v756 @ rax_v17 (Il2CppClass<UnityEngine.Vector3>)+B8]");
				nint num13 = 0;
				float num14 = (float)Vector3.oneVector * 1.5f;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v757 @ rcx_v11 (Il2CppStaticFields<UnityEngine.Vector3>)+10]");
				float num15 = 0f * 1.5f;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v757 @ rcx_v11 (Il2CppStaticFields<UnityEngine.Vector3>)+14]");
				float num16 = 0f * 1.5f;
				nint num17 = (nint)typeof(Vector3);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v790 @ rax_v18 (Il2CppClass<UnityEngine.Vector3>)+B8]");
				nint num18 = 0;
				_ = Vector3.oneVector;
				float num19 = Easing.OutCirc(timer);
				if (!(0f > num19))
				{
					if (num19 > 1f)
					{
						num19 = 1f;
					}
				}
				else
				{
					num19 = 0f;
				}
				float num20 = (float)Vector3.oneVector - num14;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-35]");
				float num21 = 0f - num15;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v228 @ rax_v19 (Il2CppStaticFields<UnityEngine.Vector3>)+14]");
				float num22 = 0f - num16;
				float num23 = num20 * num19;
				float num24 = num21 * num19;
				float num25 = num22 * num19;
				float num26 = num23 + num14;
				float num27 = num24 + num15;
				float num28 = num25 + num16;
				Vector3 localScale = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 57));
				transform.localScale = localScale;
				return;
			}
			float num29 = MyTime.deltaTime / slideTime;
			float num30 = num29 + timer;
			if (!(0f > num30))
			{
				if (num30 > 1f)
				{
					num30 = 1f;
				}
			}
			else
			{
				num30 = 0f;
			}
			LayoutGroup layoutGroup = content;
			timer = num30;
			float num31 = Easing.OutCubic(num30);
			if (!(0f > num31))
			{
				bool flag = !(num31 > 1f);
				float num32 = num31;
				if (!flag)
				{
					num32 = 1f;
				}
			}
			else
			{
				float num32 = 0f;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si edx,xmm0\"");
			layoutGroup.m_Padding.left = 0;
			float num33 = timer * 4f;
			float num34 = num33 / 1.9f;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802FE430");
			float num35 = num34 * 1.9f;
			float num36 = num33 - num35;
			if (!(0f > num36))
			{
				if (num36 > 1.9f)
				{
					num36 = 1.9f;
				}
			}
			else
			{
				num36 = 0f;
			}
			float num37 = num36 - 0.95f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18262ED80]");
			object obj3 = num37 & 0;
			float num38 = 0.95f - (float)obj3;
			Color color2 = (Color)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 57));
			_ = 1065353216;
			overlay.color = color2;
			Transform transform2 = content.transform;
			nint num39 = (nint)typeof(Vector3);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v889 @ rax_v36 (Il2CppClass<UnityEngine.Vector3>)+B8]");
			nint num40 = 0;
			float num41 = (float)Vector3.oneVector * 1.5f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v890 @ rcx_v22 (Il2CppStaticFields<UnityEngine.Vector3>)+10]");
			float num42 = 0f * 1.5f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v890 @ rcx_v22 (Il2CppStaticFields<UnityEngine.Vector3>)+14]");
			float num43 = 0f * 1.5f;
			nint num44 = (nint)typeof(Vector3);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v908 @ rax_v37 (Il2CppClass<UnityEngine.Vector3>)+B8]");
			nint num45 = 0;
			_ = Vector3.oneVector;
			float num46 = Easing.OutCirc(timer);
			if (!(0f > num46))
			{
				if (num46 > 1f)
				{
					num46 = 1f;
				}
			}
			else
			{
				num46 = 0f;
			}
			float num47 = (float)Vector3.oneVector - num41;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-35]");
			float num48 = 0f - num42;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v224 @ rax_v38 (Il2CppStaticFields<UnityEngine.Vector3>)+14]");
			float num49 = 0f - num43;
			float num50 = num47 * num46;
			float num51 = num48 * num46;
			float num52 = num49 * num46;
			float num53 = num50 + num41;
			float num54 = num51 + num42;
			float num55 = num52 + num43;
			Vector3 localScale2 = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 57));
			transform2.localScale = localScale2;
			content.SetLayoutHorizontal();
			content.SetLayoutVertical();
			if (timer < 1f)
			{
				return;
			}
			Color color3 = (Color)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 57));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18262ED30]");
			_ = 0;
			overlay.color = color3;
			Transform transform3 = content.transform;
			nint num56 = (nint)typeof(Vector3);
			Vector3 localScale3 = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 57));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v977 @ rcx_v30 (Il2CppClass<UnityEngine.Vector3>)+B8]");
			nint num57 = 0;
			_ = Vector3.oneVector;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v978 @ rax_v48 (Il2CppStaticFields<UnityEngine.Vector3>)+14]");
			_ = 0;
			transform3.localScale = localScale3;
			LayoutGroup layoutGroup2 = content;
			rectOffset = layoutGroup2.m_Padding;
		}
		else
		{
			LayoutGroup layoutGroup3 = content;
			if (layoutGroup3.m_Padding.left == 0)
			{
				return;
			}
			LayoutGroup layoutGroup4 = content;
			rectOffset = layoutGroup4.m_Padding;
		}
		rectOffset.left = 0;
	}

	private void PadAndRebuild()
	{
		//IL_0044: Expected I4, but got O
		//IL_005b: Expected I4, but got O
		Rebuild();
		Canvas.ForceUpdateCanvases();
		RectTransform component = content.GetComponent<RectTransform>();
		Rect rect = component.rect;
		LayoutGroup layoutGroup = content;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si edx,xmm0\"");
		paddingWidth = (int)component;
		layoutGroup.m_Padding.left = (int)component;
	}

	private void Rebuild()
	{
		//IL_00c8: Expected O, but got I4
		//IL_01f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f6: Expected O, but got Unknown
		//IL_0201: Expected O, but got I4
		textSizer.Refresh();
		textSizer.Recalculate();
		Transform transform = textSizer.transform;
		bool flag = (object)transform == null;
		RectTransform layoutRoot = null;
		if (!flag)
		{
			bool flag2 = (object)transform.GetType() != typeof(RectTransform);
			layoutRoot = null;
			if (!flag2)
			{
				layoutRoot = (RectTransform)transform;
			}
		}
		LayoutRebuilder.ForceRebuildLayoutImmediate(layoutRoot);
		Transform transform2 = base.transform;
		LayoutGroup[] componentsInChildren = transform2.GetComponentsInChildren<LayoutGroup>();
		bool flag3 = (nint)componentsInChildren < 0;
		object obj = componentsInChildren.Length - 1;
		if (!flag3)
		{
			object obj3;
			do
			{
				componentsInChildren[obj].CalculateLayoutInputHorizontal();
				componentsInChildren[obj].CalculateLayoutInputVertical();
				Transform transform3 = componentsInChildren[obj].transform;
				bool flag4 = (nint)transform3 < 0;
				bool flag5 = (object)transform3 == null;
				RectTransform layoutRoot2 = null;
				if (!flag5)
				{
					object obj2 = (object)transform3 - (object)typeof(RectTransform);
					flag4 = (nint)obj2 < 0;
					bool flag6 = (object)transform3.GetType() != typeof(RectTransform);
					layoutRoot2 = null;
					if (!flag6)
					{
						layoutRoot2 = (RectTransform)transform3;
					}
				}
				LayoutRebuilder.ForceRebuildLayoutImmediate(layoutRoot2);
				obj--;
				obj3 = !flag4;
			}
			while (obj3 != null);
		}
		RectTransform component = GetComponent<RectTransform>();
		LayoutRebuilder.ForceRebuildLayoutImmediate(component);
	}

	public unsafe void Complete()
	{
		//IL_0029: Expected O, but got Ref
		checkMark.SetActive(value: true);
		object obj = default(object);
		overlay.color = (Color)(&obj);
		LayoutGroup layoutGroup = content;
		timer = 0f;
		layoutGroup.m_Padding.left = 0;
		completed = true;
		RectTransform component = GetComponent<RectTransform>();
		LayoutRebuilder.ForceRebuildLayoutImmediate(component);
	}

	public ObjectivePrefabUi()
	{
		//IL_0027: Expected O, but got I4
		padding = 20f;
		slideTime = 1f;
		_ = 1045220556;
		completedColor = (Color)0;
		_ = 1065353216;
		base._002Ector();
	}
}
