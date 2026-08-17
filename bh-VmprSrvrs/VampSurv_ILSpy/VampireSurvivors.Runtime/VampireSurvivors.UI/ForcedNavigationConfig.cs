using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.UI;

namespace VampireSurvivors.UI;

public class ForcedNavigationConfig : MonoBehaviour
{
	private Selectable _Target;

	private Selectable _OnDown;

	private Selectable _OnUp;

	private Selectable _OnLeft;

	private Selectable _OnRight;

	private List<Selectable> _FallbackUpSelections;

	private Navigation.Mode _cachedMode;

	private Selectable _cachedLeft;

	private Selectable _cachedRight;

	private Selectable _cachedUp;

	private Selectable _cachedDown;

	public bool isLive;

	private unsafe void OnEnable()
	{
		//IL_003d: Expected I4, but got O
		//IL_004f: Expected O, but got I
		//IL_0066: Expected O, but got I
		//IL_007d: Expected O, but got I
		//IL_0094: Expected O, but got I
		//IL_01b9: Expected O, but got Ref
		//IL_02fb: Expected O, but got I4
		//IL_0313->IL031d: Incompatible stack heights: 2 vs 0
		//IL_01a5->IL02ac: Incompatible stack heights: 2 vs 0
		if (!isLive)
		{
			return;
		}
		Selectable target = _Target;
		List<Selectable> fallbackUpSelections = default(List<Selectable>);
		if ((object)_Target != null)
		{
			_cachedMode = (Navigation.Mode)target.m_Navigation;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v61 @ rax_v4 (UnityEngine.UI.Selectable)+40]");
			_cachedLeft = (Selectable)0;
			Selectable target2 = _Target;
			if ((object)_Target != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v243 @ rax_v18 (UnityEngine.UI.Selectable)+48]");
				_cachedRight = (Selectable)0;
				Selectable target3 = _Target;
				if ((object)_Target != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v244 @ rax_v21 (UnityEngine.UI.Selectable)+30]");
					_cachedUp = (Selectable)0;
					Selectable target4 = _Target;
					if ((object)_Target != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v245 @ rax_v23 (UnityEngine.UI.Selectable)+38]");
						_cachedDown = (Selectable)0;
						if ((object)_Target != null)
						{
							Selectable onUp = _OnUp;
							if ((object)_OnUp == null || ((UnityEngine.Object)onUp).m_CachedPtr == (IntPtr)0)
							{
								goto IL_02ac;
							}
							if ((object)_OnUp != null)
							{
								GameObject gameObject = _OnUp.gameObject;
								if ((object)gameObject != null)
								{
									if (!gameObject.activeInHierarchy)
									{
										if (_FallbackUpSelections == null)
										{
											goto IL_01bf;
										}
										fallbackUpSelections = _FallbackUpSelections;
										List<Selectable>.Enumerator enumerator = default(List<Selectable>.Enumerator);
										while (enumerator.MoveNext())
										{
											GameObject gameObject2 = ((Component)null).gameObject;
											bool flag = (object)gameObject2 == null;
											bool flag2 = ((UnityEngine.Object)gameObject2).m_CachedPtr == (IntPtr)0;
											object obj = GameObject.get_activeInHierarchy_Injected(((UnityEngine.Object)gameObject2).m_CachedPtr);
											if (obj != null)
											{
												break;
											}
										}
									}
									goto IL_02ac;
								}
							}
						}
					}
				}
			}
		}
		goto IL_01bf;
		IL_02ac:
		if ((object)_Target != null)
		{
			_Target.navigation = (Navigation)(&fallbackUpSelections);
			return;
		}
		goto IL_01bf;
		IL_01bf:
		throw new NullReferenceException();
	}

	private unsafe void OnDisable()
	{
		//IL_0033: Expected O, but got Ref
		if (isLive)
		{
			object obj = default(object);
			_Target.navigation = (Navigation)(&obj);
		}
		else
		{
			isLive = true;
		}
	}

	public ForcedNavigationConfig()
	{
		//IL_0015: Expected I, but got O
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
