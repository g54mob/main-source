using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.UI;
using VampireSurvivors.App.Tools;

public class MultipleLineHorizontalList : MonoBehaviour
{
	private float _LineHeight = 60f;

	private float _MaxWidth;

	private float _PortraitMaxWidth = 640f;

	private List<GameObject> _lines;

	private RectTransform _activeLine;

	private List<GameObject> _spawned;

	private void Start()
	{
	}

	public void AddNewItem(RectTransform t)
	{
		//IL_00b6: Invalid comparison between O and F4
		//IL_0115: Invalid comparison between F4 and O
		//IL_012f: Expected O, but got F4
		RectTransform component = GetComponent<RectTransform>();
		Extensions.RefreshLayoutGroupsImmediateAndRecursive(component);
		Canvas.ForceUpdateCanvases();
		RectTransform activeLine = _activeLine;
		Vector2 vector = default(Vector2);
		if ((object)_activeLine == null || ((UnityEngine.Object)activeLine).m_CachedPtr == (IntPtr)0)
		{
			CreateNewLine();
			RectTransform component2 = GetComponent<RectTransform>();
			float lineHeight = _LineHeight;
			component2.sizeDelta = vector;
		}
		Vector2 sizeDelta = _activeLine.sizeDelta;
		Vector2 sizeDelta2 = t.sizeDelta;
		object obj = sizeDelta2 + sizeDelta;
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)_MaxWidth))
		{
			CreateNewLine();
		}
		t.SetParent(_activeLine, worldPositionStays: true);
		Vector2 sizeDelta3 = t.sizeDelta;
		Vector2 sizeDelta4 = _activeLine.sizeDelta;
		float num = default(float);
		object obj2 = default(object);
		bool flag = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2);
		bool flag2 = true;
		Vector2 vector2 = (Vector2)num;
		if (!flag)
		{
			Vector2 sizeDelta5 = _activeLine.sizeDelta;
			Vector2 sizeDelta6 = t.sizeDelta;
			_activeLine.sizeDelta = vector;
			flag2 = false;
			vector2 = vector;
			float lineHeight = num;
		}
		GameObject gameObject = t.gameObject;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180497F80");
	}

	public void Clear()
	{
		//IL_0087: Expected I4, but got O
		//IL_0087: Expected O, but got I
		//IL_0094: Expected O, but got I
		//IL_013a: Expected I4, but got O
		//IL_013a: Expected O, but got I
		bool flag = _spawned == null;
		MultipleLineHorizontalList multipleLineHorizontalList = this;
		if (!flag)
		{
			List<GameObject>.Enumerator enumerator = default(List<GameObject>.Enumerator);
			while (enumerator.MoveNext())
			{
				UnityEngine.Object.Destroy(null, 0f);
			}
			multipleLineHorizontalList = (MultipleLineHorizontalList)(object)_spawned;
			if (_spawned != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v125 @ rcx_v7 (MultipleLineHorizontalList)+1C]");
				_ = (nint)0 + (nint)1;
				((MonoBehaviour)multipleLineHorizontalList).m_CancellationTokenSource = null;
				if ((nint)((MonoBehaviour)multipleLineHorizontalList).m_CancellationTokenSource > 0)
				{
					Array.Clear((Array)(nint)((UnityEngine.Object)multipleLineHorizontalList).m_CachedPtr, 0, (int)((MonoBehaviour)multipleLineHorizontalList).m_CancellationTokenSource);
					multipleLineHorizontalList = (MultipleLineHorizontalList)(nint)((UnityEngine.Object)multipleLineHorizontalList).m_CachedPtr;
				}
				if (_lines != null)
				{
					List<GameObject>.Enumerator enumerator2 = default(List<GameObject>.Enumerator);
					while (enumerator2.MoveNext())
					{
						UnityEngine.Object.Destroy(null, 0f);
					}
					multipleLineHorizontalList = (MultipleLineHorizontalList)(object)_lines;
					if (_lines != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v125 @ rcx_v7 (MultipleLineHorizontalList)+1C]");
						_ = (nint)0 + (nint)1;
						((MonoBehaviour)multipleLineHorizontalList).m_CancellationTokenSource = null;
						if ((nint)((MonoBehaviour)multipleLineHorizontalList).m_CancellationTokenSource > 0)
						{
							Array.Clear((Array)(nint)((UnityEngine.Object)multipleLineHorizontalList).m_CachedPtr, 0, (int)((MonoBehaviour)multipleLineHorizontalList).m_CancellationTokenSource);
						}
						_activeLine = null;
						RectTransform component = GetComponent<RectTransform>();
						LayoutRebuilder.MarkLayoutForRebuild(component);
						return;
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	public unsafe void CreateNewLine()
	{
		//IL_0189: Unknown result type (might be due to invalid IL or missing references)
		//IL_018e: Expected Ref, but got Unknown
		//IL_01ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b3: Expected Ref, but got Unknown
		//IL_01d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d8: Expected Ref, but got Unknown
		//IL_0205: Unknown result type (might be due to invalid IL or missing references)
		//IL_020a: Expected Ref, but got Unknown
		GameObject gameObject = new GameObject();
		GameObject.Internal_CreateGameObject(gameObject, (string)null);
		if ((object)gameObject != null)
		{
			Transform transform = gameObject.transform;
			Transform parent = base.transform;
			if ((object)transform != null)
			{
				transform.SetParent(parent, worldPositionStays: true);
				Transform transform2 = gameObject.transform;
				bool flag = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
				Vector3 value = default(Vector3);
				Transform.set_localScale_Injected(((UnityEngine.Object)transform2).m_CachedPtr, ref value);
				HorizontalLayoutGroup horizontalLayoutGroup = gameObject.AddComponent<HorizontalLayoutGroup>();
				RectTransform component = horizontalLayoutGroup.GetComponent<RectTransform>();
				_activeLine = component;
				RectTransform component2 = horizontalLayoutGroup.GetComponent<RectTransform>();
				Vector2 sizeDelta = default(Vector2);
				component2.sizeDelta = sizeDelta;
				((LayoutGroup)horizontalLayoutGroup).SetProperty<System.Int32Enum>(ref *(System.Int32Enum*)(horizontalLayoutGroup + 40), (System.Int32Enum)4);
				((LayoutGroup)horizontalLayoutGroup).SetProperty<TextAnchor>(ref *(TextAnchor*)(horizontalLayoutGroup + 102), TextAnchor.UpperLeft);
				((LayoutGroup)horizontalLayoutGroup).SetProperty<TextAnchor>(ref *(TextAnchor*)(horizontalLayoutGroup + 103), TextAnchor.UpperLeft);
				ContentSizeFitter contentSizeFitter = gameObject.AddComponent<ContentSizeFitter>();
				if (UnityEngine.UI.SetPropertyUtility.SetStruct(ref *(System.Int32Enum*)(contentSizeFitter + 32), (System.Int32Enum)2))
				{
					contentSizeFitter.SetDirty();
				}
				((LayoutGroup)(object)_lines).SetProperty<TextAnchor>(ref *(TextAnchor*)gameObject, TextAnchor.UpperLeft);
				RectTransform component3 = GetComponent<RectTransform>();
				LayoutRebuilder.ForceRebuildLayoutImmediate(component3);
				Canvas.ForceUpdateCanvases();
				return;
			}
		}
		throw new NullReferenceException();
	}

	public void SetMaxWidth(float w)
	{
		_MaxWidth = w;
	}

	public MultipleLineHorizontalList()
	{
		List<GameObject> lines = new List<GameObject>();
		_lines = lines;
		List<GameObject> spawned = new List<GameObject>();
		_spawned = spawned;
	}
}
