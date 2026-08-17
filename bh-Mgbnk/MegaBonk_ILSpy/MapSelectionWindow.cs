using System;
using System.Collections.Generic;
using System.Linq;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.UI;

public class MapSelectionWindow : MonoBehaviour
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static Func<MapData, int> _003C_003E9__2_0;

		static _003C_003Ec()
		{
			_003C_003Ec obj = new _003C_003Ec();
			_003C_003E9 = obj;
		}

		internal int _003CInitButtons_003Eb__2_0(MapData a)
		{
			//IL_0035: Expected I4, but got O
			if ((object)a != null)
			{
				return a.unlockOrder;
			}
			NullReferenceException ex = new NullReferenceException();
			return (int)ex;
		}
	}

	public GameObject mapEntryPrefab;

	public SelectionGroupToggleSingle selectionGroup;

	public unsafe void InitButtons()
	{
		//IL_0074: Expected O, but got Ref
		//IL_02af: Expected O, but got I4
		//IL_0334: Expected O, but got Ref
		DataManager instance = DataManager.Instance;
		Func<MapData, int> keySelector = _003C_003Ec._003C_003E9__2_0;
		if (_003C_003Ec._003C_003E9__2_0 == null)
		{
			keySelector = (_003C_003Ec._003C_003E9__2_0 = delegate(MapData a)
			{
				//IL_0035: Expected I4, but got O
				if ((object)a == null)
				{
					NullReferenceException ex = new NullReferenceException();
					return (int)ex;
				}
				return a.unlockOrder;
			});
		}
		IOrderedEnumerable<MapData> source = Enumerable.OrderBy(instance.maps, keySelector);
		List<object> list = Enumerable.ToList((IEnumerable<object>)source);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181126F30");
		int num = 0;
		List<object>.Enumerator enumerator = default(List<object>.Enumerator);
		MapData mapData = default(MapData);
		Navigation navigation = default(Navigation);
		while (true)
		{
			if (enumerator.MoveNext())
			{
				bool flag = num <= 0;
				GameObject gameObject = mapEntryPrefab;
				GameObject gameObject2 = (GameObject)(&enumerator);
				if (!flag)
				{
					if ((object)mapEntryPrefab == null)
					{
						break;
					}
					Transform transform = mapEntryPrefab.transform;
					Transform parent = transform.parent;
					gameObject = UnityEngine.Object.Instantiate(mapEntryPrefab, parent);
				}
				if ((object)gameObject != null)
				{
					MapEntry component = gameObject.GetComponent<MapEntry>();
					if ((object)component != null)
					{
						component.Set(mapData);
						num++;
						continue;
					}
					throw new NullReferenceException();
				}
				throw new NullReferenceException();
			}
			((List<MapData>.Enumerator*)(&enumerator))->Dispose();
			GameObject gameObject3 = mapEntryPrefab;
			int num2 = 0;
			int num3 = 0;
			while (true)
			{
				Transform transform2 = gameObject3.transform;
				Transform parent2 = transform2.parent;
				int childCount = parent2.childCount;
				if (num2 < childCount)
				{
					Transform transform3 = mapEntryPrefab.transform;
					Transform parent3 = transform3.parent;
					Transform child = parent3.GetChild(num3);
					Button component2 = child.GetComponent<Button>();
					if (num3 != 0)
					{
						Transform transform4 = mapEntryPrefab.transform;
						Transform parent4 = transform4.parent;
						int index = num3 - 1;
						Transform child2 = parent4.GetChild(index);
						Button component3 = child2.GetComponent<Button>();
					}
					Transform transform5 = mapEntryPrefab.transform;
					Transform parent5 = transform5.parent;
					int childCount2 = parent5.childCount;
					object obj = childCount2 - 1;
					if (num3 != (nint)obj)
					{
						Transform transform6 = mapEntryPrefab.transform;
						Transform parent6 = transform6.parent;
						int index2 = num3 + 1;
						Transform child3 = parent6.GetChild(index2);
						Button component4 = child3.GetComponent<Button>();
					}
					component2.navigation = (Navigation)(&navigation);
					selectionGroup.FindButtons();
					num3++;
					gameObject3 = mapEntryPrefab;
					num2 = num3;
					continue;
				}
				break;
			}
			return;
		}
		throw new NullReferenceException();
	}
}
