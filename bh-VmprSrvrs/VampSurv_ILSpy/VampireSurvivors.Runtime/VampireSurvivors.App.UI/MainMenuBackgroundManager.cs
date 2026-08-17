using System;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.Bindings;
using VampireSurvivors.App.Scripts.Framework.Adventures;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.Loading;

namespace VampireSurvivors.App.UI;

public class MainMenuBackgroundManager : MonoBehaviour
{
	private Transform _CustomBackgroundHolder;

	private MainMenuBackgroundFactory _mainMenuBackgroundFactory;

	private AdventureManager _adventureManager;

	private void Construct(MainMenuBackgroundFactory mainMenuBackgroundFactory, AdventureManager adventureManager)
	{
		_mainMenuBackgroundFactory = mainMenuBackgroundFactory;
		_adventureManager = adventureManager;
	}

	private void Awake()
	{
		GameObject gameObject = _CustomBackgroundHolder.gameObject;
		gameObject.SetActive(value: false);
	}

	private void Start()
	{
		if (AdventureManager._003CIsInAdventureMode_003Ek__BackingField)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 95 Invalid \"Jump target not found in method: 0x186BF3830\"");
		}
	}

	public unsafe void SetBackgroundForAdventure(AdventureType adventureType)
	{
		//IL_0093: Expected I4, but got O
		//IL_00b8: Expected O, but got Ref
		GameObject backgroundForAdventureType = _mainMenuBackgroundFactory.GetBackgroundForAdventureType(adventureType);
		if ((object)backgroundForAdventureType != null && ((UnityEngine.Object)backgroundForAdventureType).m_CachedPtr != (IntPtr)0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1830B46D0");
			GameObject gameObject = _CustomBackgroundHolder.gameObject;
			gameObject.SetActive(value: true);
		}
		else
		{
			object obj = default(object);
			object arg = (AdventureType)obj;
			System.ParamsArray paramsArray = new System.ParamsArray(arg);
			object obj2 = default(object);
			string message = string.FormatHelper((IFormatProvider)null, "No custom background available for AdventureType: {0}", (System.ParamsArray)(&obj2));
			Debug.LogWarning(message);
		}
	}

	public void ForceCustomBackground(Transform customBackground)
	{
		if ((object)customBackground != null && ((UnityEngine.Object)customBackground).m_CachedPtr != (IntPtr)0)
		{
			GameObject gameObject = _CustomBackgroundHolder.gameObject;
			gameObject.SetActive(value: true);
			customBackground.SetParent(_CustomBackgroundHolder, worldPositionStays: true);
		}
		else
		{
			Debug.LogWarning("Could not set a custom background due to it being NULL");
		}
	}

	public void ResetBackgroundToMainGame()
	{
		//IL_0124: Expected O, but got I4
		//IL_012d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0132: Expected O, but got Unknown
		//IL_0179: Expected I4, but got O
		//IL_01f7: Expected I, but got O
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Expected O, but got Unknown
		//IL_00a0->IL00c4: Incompatible stack heights: 1 vs 0
		//IL_0220->IL00c4: Incompatible stack heights: 1 vs 0
		//IL_0280->IL00c4: Incompatible stack heights: 2 vs 0
		//IL_01a2->IL00c4: Incompatible stack heights: 2 vs 0
		//IL_0077->IL01fc: Incompatible stack heights: 3 vs 1
		//IL_007c->IL007c: Incompatible stack heights: 3 vs 1
		Transform customBackgroundHolder = _CustomBackgroundHolder;
		if ((object)_CustomBackgroundHolder != null)
		{
			bool flag = ((UnityEngine.Object)customBackgroundHolder).m_CachedPtr == (IntPtr)0;
			bool flag2 = (nint)0 < (nint)0;
			object obj = Transform.get_childCount_Injected(((UnityEngine.Object)customBackgroundHolder).m_CachedPtr);
			object obj2 = obj - 1;
			if (flag2)
			{
				goto IL_007c;
			}
			while (true)
			{
				object customBackgroundHolder2 = _CustomBackgroundHolder;
				if ((object)_CustomBackgroundHolder == null)
				{
					break;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v78 @ rbx_v14 (System.Object)+10]");
				bool flag3 = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v78 @ rbx_v14 (System.Object)+10]");
				IntPtr child_Injected = Transform.GetChild_Injected((IntPtr)0, (int)obj2);
				Transform transform = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(child_Injected);
				if ((object)transform == null)
				{
					break;
				}
				bool flag4 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				IntPtr gcHandlePtr = Component.get_gameObject_Injected(((UnityEngine.Object)transform).m_CachedPtr);
				GameObject obj3 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<GameObject>(gcHandlePtr);
				nint num = (nint)typeof(UnityEngine.Object);
				UnityEngine.Object.Destroy(obj3, 0f);
				obj2--;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v840 @ rcx_v42 (Il2CppClass<UnityEngine.Object>)+E4]");
				if ((nint)0 >= (nint)0)
				{
					continue;
				}
				goto IL_007c;
			}
		}
		goto IL_00c4;
		IL_007c:
		object customBackgroundHolder3 = _CustomBackgroundHolder;
		if ((object)_CustomBackgroundHolder != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v79 @ rbx_v18 (System.Object)+10]");
			bool flag5 = (nint)0 == 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v79 @ rbx_v18 (System.Object)+10]");
			IntPtr gcHandlePtr2 = Component.get_gameObject_Injected((IntPtr)0);
			GameObject gameObject = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<GameObject>(gcHandlePtr2);
			if ((object)gameObject != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v95 @ rax_v62 (UnityEngine.GameObject)+10]");
				bool flag6 = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v95 @ rax_v62 (UnityEngine.GameObject)+10]");
				GameObject.SetActive_Injected((IntPtr)0, false);
				AddressableCache.ReleaseCustomOperationHandleGroup("AdventureBackgrounds");
				return;
			}
		}
		goto IL_00c4;
		IL_00c4:
		throw new NullReferenceException();
	}

	public MainMenuBackgroundManager()
	{
		//IL_0015: Expected I, but got O
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
