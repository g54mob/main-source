using System;
using System.Collections.Generic;
using Assets.Scripts.Inventory__Items__Pickups.Stats;
using Assets.Scripts.Utility;
using Cpp2ILInjected;
using UnityEngine;

namespace Assets.Scripts.UI.HUD;

public class ScoreUi : MonoBehaviour
{
	public RandomSfx scoreSound;

	public RandomSfx negativeSound;

	private bool moveDesc;

	private Queue<ScoreContainer> scoreQueue;

	private List<ScoreUiPrefab> prefabs;

	public GameObject prefab;

	private bool isActive;

	private float readyTime;

	public void AddScore(string description, string header, bool isPositive = true, bool useSfx = true, float sizeMultiplier = 1f)
	{
		ScoreContainer scoreContainer = null;
		scoreContainer.sizeMultiplier = 1f;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1803321E0");
		scoreContainer.header = header;
		scoreContainer.description = description;
		scoreContainer.isPositive = isPositive;
		float sizeMultiplier2 = default(float);
		scoreContainer.sizeMultiplier = sizeMultiplier2;
		bool useSfx2 = default(bool);
		scoreContainer.useSfx = useSfx2;
		((Queue<object>)(object)scoreQueue).Enqueue((object)scoreContainer);
		if (!(MyTime.time < readyTime))
		{
			float deltaTime = Time.deltaTime;
			float num = deltaTime + MyTime.time;
			readyTime = num;
		}
	}

	public unsafe void AddScore(StatModifier statModifier, bool isPositive, bool useSfx = true, float sizeMultiplier = 1f)
	{
		//IL_00ae: Expected O, but got Ref
		string modificationString = StatUtility.GetModificationString(statModifier);
		string statTextColor = MyColorUtility.GetStatTextColor(isPositive);
		string text = StatUtility.EncapsulateNumber(modificationString, statTextColor);
		bool flag = text == null;
		string description = "";
		if (!flag)
		{
			description = text;
		}
		string text2 = EnumUtility.EnumToReadable(statModifier.stat);
		bool flag2 = text2 == null;
		string text3 = "";
		if (!flag2)
		{
			text3 = text2;
		}
		if (!isPositive)
		{
			object obj = default(object);
			string text4 = MyColorUtility.ColorToHex((Color)(&obj));
			string text5 = "<color=#" + text4 + ">" + text3;
			text3 = text5;
		}
		bool useSfx2 = default(bool);
		float sizeMultiplier2 = default(float);
		AddScore(description, text3, isPositive, useSfx2, sizeMultiplier2);
	}

	private void Update()
	{
		if (!(MyTime.time < readyTime))
		{
			Queue<ScoreContainer> queue = scoreQueue;
			if (queue._size > 0)
			{
				SetScore();
			}
		}
	}

	private unsafe void SetScore()
	{
		//IL_00fa: Expected O, but got Ref
		//IL_0394: Expected F4, but got I
		//IL_0394: Expected O, but got I
		//IL_0394: Expected O, but got I
		float num = MyTime.time + 0.5f;
		readyTime = num;
		UnityEngine.Object obj2;
		if (scoreQueue != null)
		{
			object obj = ((Queue<object>)(object)scoreQueue).Dequeue();
			if (obj != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v74 @ rax_v14 (System.Object)+21]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v74 @ rax_v14 (System.Object)+20]");
					RandomSfx randomSfx = (((nint)0 != 0) ? scoreSound : negativeSound);
					if ((object)randomSfx == null)
					{
						goto IL_0395;
					}
					randomSfx.Play();
				}
				if (prefabs != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181126F30");
					List<object>.Enumerator enumerator = default(List<object>.Enumerator);
					Component component = default(Component);
					while (true)
					{
						if (enumerator.MoveNext())
						{
							bool flag = (object)component == null;
							List<object>.Enumerator enumerator2 = (List<object>.Enumerator)(&enumerator);
							if (!flag)
							{
								GameObject gameObject = component.gameObject;
								if ((object)gameObject != null)
								{
									if (!gameObject.activeInHierarchy)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1803321E0");
										obj2 = component;
										break;
									}
									continue;
								}
								throw new NullReferenceException();
							}
							throw new NullReferenceException();
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1803321E0");
						obj2 = null;
						break;
					}
					if (!(obj2 == null))
					{
						goto IL_034a;
					}
					if ((object)prefab != null)
					{
						Transform transform = prefab.transform;
						if ((object)transform != null)
						{
							Transform parent = transform.parent;
							GameObject gameObject2 = UnityEngine.Object.Instantiate(prefab, parent);
							if ((object)gameObject2 != null)
							{
								ScoreUiPrefab component2 = gameObject2.GetComponent<ScoreUiPrefab>();
								List<object> list = (List<object>)(object)prefabs;
								if (prefabs != null)
								{
									int version = list._version + 1;
									list._version = version;
									object[] items = list._items;
									if (list._items != null)
									{
										int size = list._size;
										if (list._size >= items.Length)
										{
											((List<object>)(object)prefabs).AddWithResize((object)component2);
											obj2 = component2;
										}
										else
										{
											int size2 = list._size + 1;
											list._size = size2;
											items[size] = component2;
											obj2 = component2;
										}
										goto IL_034a;
									}
								}
							}
						}
					}
				}
			}
		}
		goto IL_0395;
		IL_034a:
		if ((object)obj2 != null)
		{
			UnityEngine.Object obj3 = obj2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v74 @ rax_v14 (System.Object)+18]");
			nint num2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v74 @ rax_v14 (System.Object)+10]");
			nint num3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v74 @ rax_v14 (System.Object)+24]");
			((ScoreUiPrefab)obj3).SetScore((string)num2, (string)num3, 0f);
			return;
		}
		goto IL_0395;
		IL_0395:
		throw new NullReferenceException();
	}

	public int GetQueueCount()
	{
		//IL_001d: Expected I4, but got O
		Queue<ScoreContainer> queue = scoreQueue;
		if (scoreQueue != null)
		{
			return queue._size;
		}
		NullReferenceException ex = new NullReferenceException();
		return (int)ex;
	}

	public ScoreUi()
	{
		Queue<ScoreContainer> queue = new Queue<ScoreContainer>();
		scoreQueue = queue;
		prefabs = new List<ScoreUiPrefab>();
		base._002Ector();
	}
}
