using System;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.UI;

namespace VampireSurvivors.UI;

public class ContentAutoSpacer : MonoBehaviour
{
	private float _MaxWidth;

	private float _DefaultSpacing;

	private HorizontalLayoutGroup _layoutGroup;

	private void Start()
	{
		HorizontalLayoutGroup component = GetComponent<HorizontalLayoutGroup>();
		_layoutGroup = component;
		HorizontalLayoutGroup layoutGroup = _layoutGroup;
		_DefaultSpacing = ((HorizontalOrVerticalLayoutGroup)layoutGroup).m_Spacing;
	}

	private void Update()
	{
		//IL_0302: Expected O, but got I4
		//IL_012b: Expected O, but got I4
		//IL_0186: Unknown result type (might be due to invalid IL or missing references)
		//IL_018b: Expected O, but got Unknown
		//IL_0162: Expected O, but got I4
		//IL_0268: Unknown result type (might be due to invalid IL or missing references)
		//IL_026d: Expected O, but got Unknown
		//IL_0277: Unknown result type (might be due to invalid IL or missing references)
		//IL_027c: Expected O, but got Unknown
		//IL_0284: Unknown result type (might be due to invalid IL or missing references)
		//IL_0289: Expected I4, but got Unknown
		//IL_029e: Expected F4, but got I
		//IL_0031->IL02a4: Incompatible stack heights: 1 vs 0
		//IL_0060->IL02a4: Incompatible stack heights: 1 vs 0
		//IL_008a->IL02a4: Incompatible stack heights: 1 vs 0
		//IL_00c3->IL02a4: Incompatible stack heights: 1 vs 0
		//IL_010b->IL02a4: Incompatible stack heights: 1 vs 0
		//IL_0341->IL02a4: Incompatible stack heights: 1 vs 0
		//IL_0225->IL02a4: Incompatible stack heights: 1 vs 0
		//IL_01ed->IL02a4: Incompatible stack heights: 1 vs 0
		//IL_025b->IL02a4: Incompatible stack heights: 1 vs 0
		Transform transform = base.transform;
		HorizontalOrVerticalLayoutGroup layoutGroup;
		float spacing;
		if ((object)transform != null)
		{
			bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
			object obj = Transform.get_childCount_Injected(((UnityEngine.Object)transform).m_CachedPtr);
			if ((nint)obj < 1)
			{
				return;
			}
			Transform transform2 = base.transform;
			if ((object)transform2 != null)
			{
				Transform child = transform2.GetChild(0);
				if ((object)child != null)
				{
					RectTransform component = child.GetComponent<RectTransform>();
					if ((object)component != null)
					{
						Vector2 sizeDelta = component.sizeDelta;
						Transform transform3 = base.transform;
						if ((object)transform3 != null)
						{
							int childCount = transform3.childCount;
							Transform transform4 = base.transform;
							bool flag2 = (nint)transform4 < 0;
							if ((object)transform4 != null)
							{
								int childCount2 = transform4.childCount;
								Transform transform5 = (Transform)(childCount2 - 1);
								if (!flag2)
								{
									if ((nint)transform5 > 1000)
									{
										transform5 = (Transform)1000;
									}
								}
								else
								{
									transform5 = null;
								}
								Transform transform6 = base.transform;
								if ((object)transform6 != null)
								{
									int childCount3 = transform6.childCount;
									object obj2 = childCount * sizeDelta;
									float num = (float)transform5 * _DefaultSpacing;
									float num2 = (float)obj2 + num;
									if (!(num2 > _MaxWidth))
									{
										layoutGroup = _layoutGroup;
										if ((object)_layoutGroup != null)
										{
											spacing = _DefaultSpacing;
											goto IL_0346;
										}
									}
									else
									{
										Transform transform7 = base.transform;
										if ((object)transform7 != null)
										{
											int childCount4 = transform7.childCount;
											layoutGroup = _layoutGroup;
											if ((object)_layoutGroup != null)
											{
												object obj3 = childCount4 * sizeDelta;
												object obj4 = obj3 - _MaxWidth;
												int num3 = obj4 / childCount3;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A128D0]");
												spacing = (nint)num3 ^ (nint)0;
												goto IL_0346;
											}
										}
									}
								}
							}
						}
					}
				}
			}
		}
		throw new NullReferenceException();
		IL_0346:
		layoutGroup.spacing = spacing;
	}

	public ContentAutoSpacer()
	{
		//IL_0015: Expected I, but got O
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
