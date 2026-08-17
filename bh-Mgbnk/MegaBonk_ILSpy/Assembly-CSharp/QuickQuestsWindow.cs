using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Assets.Scripts._Data.Progression;
using Assets.Scripts.Saves___Serialization.Progression.Achievements;
using Assets.Scripts.Saves___Serialization.Progression.Unlocks;
using Assets.Scripts.UI;
using Cpp2ILInjected;
using UnityEngine;

public class QuickQuestsWindow : MonoBehaviour
{
	public GameObject prefab;

	public GameObject allQuestsCompletedText;

	private int numMaxQuests = 4;

	private List<QuickQuestContainer> containers;

	private List<MyAchievement> quests;

	private Dictionary<MyAchievement, int> randomTieBreaker;

	private void Start()
	{
		//IL_0144: Expected I, but got O
		Refresh();
		Action b = Refresh;
		Delegate obj = Delegate.Combine(SaveManager.A_SavesLoaded, b);
		if ((object)obj == null)
		{
			SaveManager.A_SavesLoaded = null;
			goto IL_00b1;
		}
		bool flag = (object)obj.GetType() != typeof(Action);
		Delegate obj2 = null;
		if (!flag)
		{
			obj2 = obj;
		}
		if ((object)obj2 != null)
		{
			SaveManager.A_SavesLoaded = (Action)obj2;
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
				goto IL_00b1;
			}
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		return;
		IL_00b1:
		Invoke("Refresh", 2f);
	}

	private void OnDestroy()
	{
		//IL_0101: Expected I, but got O
		Action value = Refresh;
		Delegate obj = Delegate.Remove(SaveManager.A_SavesLoaded, value);
		if ((object)obj == null)
		{
			SaveManager.A_SavesLoaded = null;
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
			SaveManager.A_SavesLoaded = (Action)obj2;
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

	private void OnEnable()
	{
		Refresh();
	}

	private unsafe void Refresh()
	{
		if (!(DataManager.Instance != null))
		{
			return;
		}
		TryInit();
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181126F30");
		List<object>.Enumerator enumerator = default(List<object>.Enumerator);
		while (enumerator.MoveNext())
		{
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1803321E0");
		List<MyAchievement> list = new List<MyAchievement>();
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181126F30");
		List<object>.Enumerator enumerator2 = default(List<object>.Enumerator);
		object obj = default(object);
		while (true)
		{
			if (enumerator2.MoveNext())
			{
				if (obj == null)
				{
					break;
				}
				if (((MyAchievement)obj).IsCompleted())
				{
					list.Add((MyAchievement)obj);
				}
				continue;
			}
			((List<MyAchievement>.Enumerator*)(&enumerator2))->Dispose();
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181126F30");
			while (true)
			{
				if (enumerator2.MoveNext())
				{
					List<object> list2 = (List<object>)(object)quests;
					if (quests == null)
					{
						break;
					}
					bool flag = ((List<object>)(object)quests).Remove(obj);
					continue;
				}
				((List<MyAchievement>.Enumerator*)(&enumerator2))->Dispose();
				List<MyAchievement> list3 = quests;
				if (list3._size < numMaxQuests)
				{
					List<MyAchievement> allAchievements = GetAllAchievements();
					List<MyAchievement> list4 = quests;
					int num = numMaxQuests - list4._size;
					if (num >= allAchievements._size)
					{
						num = allAchievements._size;
					}
					bool flag2 = num <= 0;
					int num2 = 0;
					if (!flag2)
					{
						do
						{
							List<object> list5 = (List<object>)(object)quests;
							MyAchievement item = allAchievements.get_Item(num2);
							int version = list5._version + 1;
							list5._version = version;
							List<object> list2 = (List<object>)(object)list5._items;
							int size = list5._size;
							if (list5._size >= list2._size)
							{
								list5.AddWithResize((object)item);
							}
							else
							{
								int size2 = list5._size + 1;
								list5._size = size2;
								if (list5._size >= list2._size)
								{
									throw new IndexOutOfRangeException();
								}
							}
							num2++;
						}
						while (num2 < num);
					}
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181126F30");
				while (true)
				{
					if (enumerator.MoveNext())
					{
						if (obj != null)
						{
							GameObject gameObject = ((Component)obj).gameObject;
							if ((object)gameObject == null)
							{
								break;
							}
							gameObject.SetActive(value: false);
							continue;
						}
						throw new NullReferenceException();
					}
					((List<QuickQuestContainer>.Enumerator*)(&enumerator))->Dispose();
					List<MyAchievement> list6 = quests;
					int num3 = 0;
					for (int num4 = 0; num4 < list6._size; num4 = num3)
					{
						QuickQuestContainer quickQuestContainer = containers.get_Item(num3);
						GameObject gameObject2 = quickQuestContainer.gameObject;
						gameObject2.SetActive(value: true);
						QuickQuestContainer quickQuestContainer2 = containers.get_Item(num3);
						MyAchievement quest = quests.get_Item(num3);
						quickQuestContainer2.SetQuest(quest);
						num3++;
						list6 = quests;
					}
					List<MyAchievement> list7 = quests;
					GameObject gameObject3;
					bool active;
					if (list7._size <= 0 && MyAchievements.AreAllQuestsCompleted())
					{
						gameObject3 = allQuestsCompletedText;
						active = true;
					}
					else
					{
						gameObject3 = allQuestsCompletedText;
						active = false;
					}
					gameObject3.SetActive(active);
					Transform root = base.transform;
					UiUtility.RebuildUi(root);
					return;
				}
				throw new NullReferenceException();
			}
			throw new NullReferenceException();
		}
		throw new NullReferenceException();
	}

	private int GetTie(MyAchievement a)
	{
		//IL_008b: Expected I4, but got O
		//IL_003d: Expected I4, but got I8
		if (randomTieBreaker != null)
		{
			int num = default(int);
			if (!randomTieBreaker.TryGetValue(a, out var _))
			{
				num = UnityEngine.Random.Range(-2147483648, 2147483647);
				if (randomTieBreaker == null)
				{
					goto IL_007d;
				}
				((Dictionary<object, int>)(object)randomTieBreaker).set_Item((object)a, num);
			}
			return num;
		}
		goto IL_007d;
		IL_007d:
		NullReferenceException ex = new NullReferenceException();
		return (int)ex;
	}

	private unsafe List<MyAchievement> GetAllAchievements()
	{
		DataManager instance = DataManager.Instance;
		if ((object)DataManager.Instance != null)
		{
			Func<MyAchievement, bool> predicate = delegate(MyAchievement a)
			{
				//IL_00e3: Expected I4, but got O
				if (a != null)
				{
					if ((object)a != null)
					{
						if (!a.IsVisible() || a.IsCompleted())
						{
							goto IL_00cf;
						}
						if (quests != null)
						{
							bool flag = ((List<object>)(object)quests).Contains((object)a);
							return (byte)((flag ? 1u : 0u) ^ 1u) != 0;
						}
					}
					NullReferenceException ex = new NullReferenceException();
					return (byte)(int)ex != 0;
				}
				goto IL_00cf;
				IL_00cf:
				return false;
			};
			IEnumerable<MyAchievement> source = Enumerable.Where(instance.unsortedAchievements, predicate);
			List<object> list = Enumerable.ToList((IEnumerable<object>)source);
			Comparison<MyAchievement> comparison = delegate(MyAchievement a, MyAchievement b)
			{
				//IL_015f: Expected I4, but got O
				//IL_00d5: Expected I4, but got O
				//IL_00e6: Expected O, but got Ref
				if (a != null && b != null)
				{
					if ((object)a != null)
					{
						float progress = a.GetProgress();
						if ((object)b != null)
						{
							float progress2 = b.GetProgress();
							float num2 = default(float);
							int num = num2.CompareTo(progress);
							if (num == 0)
							{
								object obj = default(object);
								object target = (EAchievementDifficulty)obj;
								IntPtr intPtr = default(IntPtr);
								num = ((Enum)(&intPtr)).CompareTo(target);
								if (num == 0)
								{
									int tie = GetTie(a);
									int tie2 = GetTie(b);
									int num3 = default(int);
									num = num3.CompareTo(tie2);
								}
							}
							return num;
						}
					}
					NullReferenceException ex = new NullReferenceException();
					return (int)ex;
				}
				return 0;
			};
			if (list != null)
			{
				list.Sort((Comparison<object>)comparison);
				return (List<MyAchievement>)(object)list;
			}
		}
		return (List<MyAchievement>)(object)new NullReferenceException();
	}

	private void TryInit()
	{
		//IL_0056: Expected O, but got I4
		//IL_0071: Expected O, but got I4
		//IL_0184: Unknown result type (might be due to invalid IL or missing references)
		//IL_0189: Expected O, but got Unknown
		//IL_0199: Expected O, but got I4
		if (containers == null)
		{
			List<QuickQuestContainer> list = new List<QuickQuestContainer>();
			containers = list;
			QuickQuestContainer component = prefab.GetComponent<QuickQuestContainer>();
			containers.Add(component);
			object obj = numMaxQuests - 1;
			bool flag = (nint)obj <= 0;
			object obj2 = 0;
			if (!flag)
			{
				int num = default(int);
				object obj3;
				do
				{
					List<object> list2 = (List<object>)(object)containers;
					Transform transform = prefab.transform;
					Transform parent = transform.parent;
					GameObject gameObject = UnityEngine.Object.Instantiate(prefab, parent);
					QuickQuestContainer component2 = gameObject.GetComponent<QuickQuestContainer>();
					int version = list2._version + 1;
					list2._version = version;
					object[] items = list2._items;
					if (list2._size >= items.Length)
					{
						list2.AddWithResize((object)component2);
					}
					else
					{
						int size = list2._size + 1;
						list2._size = size;
						items[num] = component2;
					}
					obj2++;
					obj3 = numMaxQuests - 1;
				}
				while (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj3));
			}
		}
		if (quests != null)
		{
			return;
		}
		List<MyAchievement> list3 = new List<MyAchievement>();
		quests = list3;
		List<MyAchievement> allAchievements = GetAllAchievements();
		int size2 = numMaxQuests;
		if (numMaxQuests >= allAchievements._size)
		{
			size2 = allAchievements._size;
		}
		bool flag2 = size2 <= 0;
		int num2 = 0;
		if (flag2)
		{
			return;
		}
		int num3 = default(int);
		do
		{
			List<object> list4 = (List<object>)(object)quests;
			MyAchievement myAchievement = allAchievements.get_Item(num2);
			int version2 = list4._version + 1;
			list4._version = version2;
			object[] items2 = list4._items;
			if (list4._size >= items2.Length)
			{
				list4.AddWithResize((object)myAchievement);
			}
			else
			{
				int size3 = list4._size + 1;
				list4._size = size3;
				items2[num3] = myAchievement;
			}
			num2++;
		}
		while (num2 < size2);
	}

	public QuickQuestsWindow()
	{
		Dictionary<MyAchievement, int> dictionary = new Dictionary<MyAchievement, int>();
		randomTieBreaker = dictionary;
		base._002Ector();
	}

	private bool _003CGetAllAchievements_003Eb__11_0(MyAchievement a)
	{
		//IL_00e3: Expected I4, but got O
		if (a != null)
		{
			if ((object)a != null)
			{
				if (!a.IsVisible() || a.IsCompleted())
				{
					goto IL_00cf;
				}
				if (quests != null)
				{
					bool flag = ((List<object>)(object)quests).Contains((object)a);
					return (byte)((flag ? 1u : 0u) ^ 1u) != 0;
				}
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
		goto IL_00cf;
		IL_00cf:
		return false;
	}

	private unsafe int _003CGetAllAchievements_003Eb__11_1(MyAchievement a, MyAchievement b)
	{
		//IL_015f: Expected I4, but got O
		//IL_00d5: Expected I4, but got O
		//IL_00e6: Expected O, but got Ref
		if (a != null && b != null)
		{
			if ((object)a != null)
			{
				float progress = a.GetProgress();
				if ((object)b != null)
				{
					float progress2 = b.GetProgress();
					float num2 = default(float);
					int num = num2.CompareTo(progress);
					if (num == 0)
					{
						object obj = default(object);
						object target = (EAchievementDifficulty)obj;
						IntPtr intPtr = default(IntPtr);
						num = ((Enum)(&intPtr)).CompareTo(target);
						if (num == 0)
						{
							int tie = GetTie(a);
							int tie2 = GetTie(b);
							int num3 = default(int);
							num = num3.CompareTo(tie2);
						}
					}
					return num;
				}
			}
			NullReferenceException ex = new NullReferenceException();
			return (int)ex;
		}
		return 0;
	}
}
