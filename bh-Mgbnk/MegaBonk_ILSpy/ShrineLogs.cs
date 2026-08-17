using System.Collections.Generic;
using Assets.Scripts.Inventory__Items__Pickups.Stats;
using Assets.Scripts.UI;
using Assets.Scripts.Utility;
using Cpp2ILInjected;
using UnityEngine;

public class ShrineLogs : MonoBehaviour
{
	public GameObject prefab;

	private static List<StatModifier> backLog;

	private static List<StatModifier> shownLog;

	private bool isInitialized;

	private unsafe void Start()
	{
		isInitialized = true;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181126F30");
		List<object>.Enumerator enumerator = default(List<object>.Enumerator);
		StatModifier statModifier = default(StatModifier);
		while (enumerator.MoveNext())
		{
			AddLog(statModifier, isNew: false);
		}
		((List<StatModifier>.Enumerator*)(&enumerator))->Dispose();
	}

	public static void Reset()
	{
		List<StatModifier> list = new List<StatModifier>();
		backLog = list;
		List<StatModifier> list2 = new List<StatModifier>();
		shownLog = list2;
	}

	public void AddLog(StatModifier statModifier, bool isNew = true)
	{
		//IL_006d: Expected F4, but got I4
		if (isInitialized)
		{
			if (isNew)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180001FF0");
			}
			bool flag = statModifier.modifyType == EStatModifyType.Multiplication;
			string text = MyColorUtility.requirementCompletedColor;
			float num = (flag ? 1f : 0f);
			if (num > statModifier.modification)
			{
				text = MyColorUtility.requirementMissingColor;
			}
			string modificationString = StatUtility.GetModificationString(statModifier, addOneToMultiplication: false);
			string text2 = EnumUtility.EnumToReadable(statModifier.stat);
			string text3 = "<color=" + text + ">" + modificationString + "</color> " + text2;
			Transform transform = prefab.transform;
			Transform parent = transform.parent;
			GameObject gameObject = Object.Instantiate(prefab, parent);
			GameObject gameObject2 = gameObject.gameObject;
			gameObject2.SetActive(value: true);
			ShrineLogEntry component = gameObject.GetComponent<ShrineLogEntry>();
			component.text.text = text3;
			component.textSizer.Refresh();
			component.textSizer.Recalculate();
			Transform root = component.transform;
			UiUtility.RebuildUi(root);
			Transform root2 = base.transform;
			UiUtility.RebuildUi(root2);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180001FF0");
		}
	}

	static ShrineLogs()
	{
		List<StatModifier> list = new List<StatModifier>();
		backLog = list;
		List<StatModifier> list2 = new List<StatModifier>();
		shownLog = list2;
	}
}
