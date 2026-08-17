using System;
using System.Collections.Generic;
using Assets.Scripts.Managers;
using Assets.Scripts.UI;
using Assets.Scripts.UI.InGame.Rewards;
using Assets.Scripts.UI.Menu.Windows;
using Cpp2ILInjected;
using TMPro;
using UnityEngine;

public class EncounterUi : BaseEncounterWindow
{
	public TextMeshProUGUI t_name;

	public TextMeshProUGUI t_description;

	public GameObject b_generic;

	private List<EncounterButton> genericButtons;

	private List<EncounterButton> rarityButtons;

	public GameObject particles;

	public TabsExplicitNavigation tabsExplicitNavigation;

	private EncounterOffer[] offers;

	private float openedAtTime;

	private int rebuildAfterFrames;

	private bool needRebuild;

	public override void Open(EEncounter encounterType)
	{
		//IL_03d1: Expected O, but got I4
		//IL_0283: Expected O, but got I4
		float time = Time.time;
		openedAtTime = time;
		GameObject gameObject = base.gameObject;
		gameObject.SetActive(value: true);
		GameObject gameObject2 = particles.gameObject;
		gameObject2.SetActive(value: true);
		EncounterData encounter = DataManager.Instance.GetEncounter(encounterType);
		EncounterOffer[] array = encounter.GetOffers();
		offers = array;
		string text = encounter.GetName();
		t_name.text = text;
		TextMeshProUGUI textMeshProUGUI = t_description;
		string description = encounter.GetDescription();
		textMeshProUGUI.text = description;
		bool flag = encounter.HasRarity();
		bool flag2 = !flag;
		List<EncounterButton> list = genericButtons;
		if (!flag2)
		{
			list = rarityButtons;
		}
		if (list._size <= 0)
		{
			EncounterButton component = b_generic.GetComponent<EncounterButton>();
			list.Add(component);
			EncounterButton encounterButton = list.get_Item(0);
			encounterButton.encounterUi = this;
			encounterButton.index = 0;
		}
		HideButtons();
		EncounterOffer[] array2 = offers;
		int num = 0;
		int num2 = 0;
		GameObject gameObject4 = default(GameObject);
		while (true)
		{
			object obj = array2.Length + 1;
			if (num >= (nint)obj)
			{
				break;
			}
			if (num2 >= list._size)
			{
				Transform transform = b_generic.transform;
				Transform parent = transform.parent;
				GameObject gameObject3 = UnityEngine.Object.Instantiate(b_generic, parent);
				EncounterButton component2 = gameObject3.GetComponent<EncounterButton>();
				component2.encounterUi = this;
				component2.index = num2;
				list.Add(component2);
				gameObject4 = b_generic;
			}
			EncounterButton encounterButton2 = list.get_Item(num2);
			GameObject gameObject5 = encounterButton2.gameObject;
			gameObject5.SetActive(value: true);
			EncounterOffer[] array3 = offers;
			object obj2 = array3.Length - 1;
			EncounterOffer encounterOffer;
			if (num2 > (nint)obj2)
			{
				EncounterButton encounterButton3 = list.get_Item(num2);
				EncounterOffer[] array4 = offers;
				encounterButton3.SetDeclineOffer(array4.Length);
				encounterOffer = (EncounterOffer)(object)gameObject4;
			}
			else
			{
				EncounterButton encounterButton4 = list.get_Item(num2);
				EncounterOffer[] array5 = offers;
				encounterOffer = array5[num2];
				bool showRarity = encounter.HasRarity();
				encounterButton4.SetOffer(array5[num2], showRarity);
			}
			array2 = offers;
			num2++;
			gameObject4 = (GameObject)(object)encounterOffer;
			num = num2;
		}
		tabsExplicitNavigation.Refresh();
		rebuildAfterFrames = 3;
	}

	private void Update()
	{
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected O, but got Unknown
		float time = Time.time;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtss2sd xmm2,xmm0\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"addsd xmm1,qword ptr [18262F138h]\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"comisd xmm1,xmm2\"");
		object obj = default(object);
		object obj2 = default(object);
		bool flag = obj == obj2;
		object obj4 = default(object);
		object obj3 = ~obj4;
		object obj5 = flag & obj3;
		if (obj5 == null)
		{
			bool keyDownInt = Input.GetKeyDownInt(KeyCode.Alpha1);
			int num = (Input.GetKeyDownInt(KeyCode.Alpha2) ? 1 : ((keyDownInt ? 1 : 0) - 1));
			if (Input.GetKeyDownInt(KeyCode.Alpha3))
			{
				num = 2;
			}
			if (Input.GetKeyDownInt(KeyCode.Alpha4))
			{
				num = 3;
			}
			if (Input.GetKeyDownInt(KeyCode.Alpha5))
			{
				num = 4;
			}
			else if (num == -1)
			{
				return;
			}
			EncounterOffer[] array = offers;
			if (array.Length > num)
			{
				ChooseOffer(num);
			}
		}
	}

	private void KeyboardInput()
	{
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected O, but got Unknown
		float time = Time.time;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtss2sd xmm2,xmm0\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"addsd xmm1,qword ptr [18262F138h]\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"comisd xmm1,xmm2\"");
		object obj = default(object);
		object obj2 = default(object);
		bool flag = obj == obj2;
		object obj4 = default(object);
		object obj3 = ~obj4;
		object obj5 = flag & obj3;
		if (obj5 == null)
		{
			bool keyDownInt = Input.GetKeyDownInt(KeyCode.Alpha1);
			int num = (Input.GetKeyDownInt(KeyCode.Alpha2) ? 1 : ((keyDownInt ? 1 : 0) - 1));
			if (Input.GetKeyDownInt(KeyCode.Alpha3))
			{
				num = 2;
			}
			if (Input.GetKeyDownInt(KeyCode.Alpha4))
			{
				num = 3;
			}
			if (Input.GetKeyDownInt(KeyCode.Alpha5))
			{
				num = 4;
			}
			else if (num == -1)
			{
				return;
			}
			EncounterOffer[] array = offers;
			if (array.Length > num)
			{
				ChooseOffer(num);
			}
		}
	}

	private void LateUpdate()
	{
		if (rebuildAfterFrames >= 0)
		{
			int num = rebuildAfterFrames - 1;
			rebuildAfterFrames = num;
			if (rebuildAfterFrames == 0)
			{
				Transform root = base.transform;
				UiUtility.RebuildUi(root);
				ButtonManager.Refresh();
			}
		}
	}

	private unsafe void HideButtons()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181126F30");
		List<object>.Enumerator enumerator = default(List<object>.Enumerator);
		Component component = default(Component);
		while (true)
		{
			if (enumerator.MoveNext())
			{
				if ((object)component == null)
				{
					break;
				}
				GameObject gameObject = component.gameObject;
				gameObject.SetActive(value: false);
				continue;
			}
			((List<EncounterButton>.Enumerator*)(&enumerator))->Dispose();
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181126F30");
			while (true)
			{
				if (enumerator.MoveNext())
				{
					if ((object)component != null)
					{
						GameObject gameObject2 = component.gameObject;
						if ((object)gameObject2 == null)
						{
							break;
						}
						gameObject2.SetActive(value: false);
						continue;
					}
					throw new NullReferenceException();
				}
				((List<EncounterButton>.Enumerator*)(&enumerator))->Dispose();
				return;
			}
			throw new NullReferenceException();
		}
		throw new NullReferenceException();
	}

	public override void OnClose()
	{
		GameObject gameObject = base.gameObject;
		gameObject.SetActive(value: false);
		GameObject gameObject2 = particles.gameObject;
		gameObject2.SetActive(value: false);
	}

	public override void ChooseOffer(int index)
	{
		EncounterOffer[] array = offers;
		if (index < array.Length)
		{
			array[index].ApplyEffects();
		}
		UiManager instance = UiManager.Instance;
		instance.encounterWindows.RewardFinished();
	}

	public EncounterUi()
	{
		//IL_002d: Expected I4, but got I8
		List<EncounterButton> list = new List<EncounterButton>();
		genericButtons = list;
		rarityButtons = new List<EncounterButton>();
		rebuildAfterFrames = -1;
		base._002Ector();
	}
}
