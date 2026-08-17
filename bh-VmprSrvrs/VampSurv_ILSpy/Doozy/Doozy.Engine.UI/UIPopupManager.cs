using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using Doozy.Engine.Settings;
using Doozy.Engine.UI.Settings;
using Doozy.Engine.Utils;
using UnityEngine;

namespace Doozy.Engine.UI;

public class UIPopupManager : MonoBehaviour
{
	private static UIPopupManager s_instance;

	public static UIPopup CurrentVisibleQueuePopup;

	public static readonly List<UIPopupQueueData> PopupQueue;

	private static bool _003CApplicationIsQuitting_003Ek__BackingField;

	public static UIPopupManager Instance
	{
		get
		{
			UIPopupManager uIPopupManager = s_instance;
			if ((object)s_instance == null || ((UnityEngine.Object)uIPopupManager).m_CachedPtr == (IntPtr)0)
			{
				if (_003CApplicationIsQuitting_003Ek__BackingField)
				{
					return null;
				}
				UIPopupManager uIPopupManager2 = UnityEngine.Object.FindObjectOfType<UIPopupManager>();
				s_instance = uIPopupManager2;
				UIPopupManager uIPopupManager3 = s_instance;
				if ((object)s_instance == null || ((UnityEngine.Object)uIPopupManager3).m_CachedPtr == (IntPtr)0)
				{
					UIPopupManager uIPopupManager4 = DoozyUtils.AddToScene<UIPopupManager>("UIPopup Manager", isSingleton: true);
					if ((object)uIPopupManager4 == null)
					{
						return (UIPopupManager)(object)new NullReferenceException();
					}
					GameObject target = uIPopupManager4.gameObject;
					UnityEngine.Object.DontDestroyOnLoad(target);
				}
			}
			return s_instance;
		}
	}

	public static UIPopupDatabase PopupDatabase => UIPopupSettings.Database;

	public static bool QueueIsEmpty
	{
		get
		{
			//IL_002c: Expected I4, but got O
			List<UIPopupQueueData> popupQueue = PopupQueue;
			if (PopupQueue != null)
			{
				return popupQueue._size == 0;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
	}

	private static bool ApplicationIsQuitting
	{
		get
		{
			return _003CApplicationIsQuitting_003Ek__BackingField;
		}
		set
		{
			_003CApplicationIsQuitting_003Ek__BackingField = value;
		}
	}

	private bool DebugComponent
	{
		get
		{
			//IL_003e: Expected I4, but got O
			DoozySettings instance = DoozySettings.Instance;
			if ((object)instance != null)
			{
				return instance.DebugUIPopupManager;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
	}

	protected UIPopupManager()
	{
		//IL_0015: Expected I, but got O
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}

	private static void RunOnStart()
	{
		_003CApplicationIsQuitting_003Ek__BackingField = false;
		CurrentVisibleQueuePopup = null;
		List<UIPopupQueueData> popupQueue = PopupQueue;
		int version = popupQueue._version + 1;
		popupQueue._version = version;
		popupQueue._size = 0;
		if (popupQueue._size > 0)
		{
			Array.Clear(popupQueue._items, 0, popupQueue._size);
		}
	}

	private void Awake()
	{
		//IL_020a: Expected O, but got I4
		//IL_0224: Expected O, but got I4
		//IL_010e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0113: Expected O, but got Unknown
		UIPopupManager uIPopupManager = s_instance;
		if ((object)s_instance != null && ((UnityEngine.Object)uIPopupManager).m_CachedPtr != (IntPtr)0)
		{
			UIPopupManager uIPopupManager2 = s_instance;
			bool flag = (object)s_instance == null;
			bool flag2 = (object)this == null;
			object obj = flag2 & flag;
			bool flag3 = obj == null;
			object obj2 = !flag3;
			if (obj2 == null)
			{
				bool flag4;
				if ((object)this != null)
				{
					if ((object)s_instance != null)
					{
						object obj3 = (object)s_instance - (object)this;
						flag4 = obj3 == null;
					}
					else
					{
						flag4 = ((UnityEngine.Object)this).m_CachedPtr == (IntPtr)0;
					}
				}
				else
				{
					flag4 = ((UnityEngine.Object)uIPopupManager2).m_CachedPtr == (IntPtr)0;
				}
				if (!flag4)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
					object obj5 = default(object);
					object obj4 = obj5 + 32;
					Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
					object obj6 = default(object);
					string text;
					string text2 = default(string);
					if (obj6 != null)
					{
						object obj7 = obj6;
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v642 @ rdx_v12+168] (should have been resolved before IL gen)");
						text = "There cannot be two ";
					}
					else
					{
						text = "There cannot be two ";
						text2 = null;
					}
					string message = text + text2 + "' active at the same time. Destroying this one!";
					DDebug.Log(message);
					GameObject obj8 = base.gameObject;
					UnityEngine.Object.Destroy(obj8, 0f);
					return;
				}
			}
		}
		s_instance = this;
		GameObject target = base.gameObject;
		UnityEngine.Object.DontDestroyOnLoad(target);
	}

	private void OnApplicationQuit()
	{
		_003CApplicationIsQuitting_003Ek__BackingField = true;
	}

	public static void AddToQueue(UIPopup popup, bool instantAction = false)
	{
		UIPopupQueueData uIPopupQueueData = null;
		uIPopupQueueData.PopupName = popup._003CPopupName_003Ek__BackingField;
		uIPopupQueueData.Popup = popup;
		uIPopupQueueData.InstantAction = instantAction;
		List<object> popupQueue = (List<object>)(object)PopupQueue;
		int version = popupQueue._version + 1;
		popupQueue._version = version;
		object[] items = popupQueue._items;
		if (popupQueue._size >= items.Length)
		{
			popupQueue.AddWithResize((object)uIPopupQueueData);
		}
		else
		{
			int size = popupQueue._size + 1;
			popupQueue._size = size;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		popup.m_addedToQueue = true;
		UIPopupManager instance = Instance;
		DoozySettings instance2 = DoozySettings.Instance;
		if (instance2.DebugUIPopupManager)
		{
			string message = "UIPopup '" + popup._003CPopupName_003Ek__BackingField + "' added to the PopupQueue";
			UIPopupManager instance3 = Instance;
			DDebug.Log(message, instance3);
		}
		UIPopup currentVisibleQueuePopup = CurrentVisibleQueuePopup;
		if ((object)CurrentVisibleQueuePopup != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v408 @ rbx_v3 (Doozy.Engine.UI.UIPopup)+10]");
			if ((nint)0 != 0)
			{
				return;
			}
		}
		ShowNextInQueue();
	}

	public unsafe static void ClearQueue(bool instantAction = false)
	{
		//IL_00ba: Expected O, but got I4
		//IL_00c2: Expected O, but got Ref
		//IL_031b: Expected O, but got I
		UIPopup currentVisibleQueuePopup = CurrentVisibleQueuePopup;
		UIPopup currentVisibleQueuePopup2;
		if ((object)CurrentVisibleQueuePopup != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v57 @ rbx_v1 (Doozy.Engine.UI.UIPopup)+10]");
			if ((nint)0 != 0)
			{
				currentVisibleQueuePopup2 = CurrentVisibleQueuePopup;
				if ((object)CurrentVisibleQueuePopup == null)
				{
					goto IL_03ba;
				}
				CurrentVisibleQueuePopup.Hide(instantAction);
			}
		}
		if (QueueIsEmpty)
		{
			return;
		}
		currentVisibleQueuePopup2 = null;
		if (PopupQueue != null)
		{
			List<UIPopupQueueData>.Enumerator enumerator = default(List<UIPopupQueueData>.Enumerator);
			if (enumerator.MoveNext())
			{
				object obj = 0;
				currentVisibleQueuePopup2 = (UIPopup)(&enumerator);
				throw new NullReferenceException();
			}
			currentVisibleQueuePopup2 = (UIPopup)(object)PopupQueue;
			if (PopupQueue != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v450 @ rcx_v10 (Doozy.Engine.UI.UIPopup)+1C]");
				_ = (nint)0 + (nint)1;
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v450 @ rcx_v10 (Doozy.Engine.UI.UIPopup)+18]");
				if ((nint)0 > (nint)0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v450 @ rcx_v10 (Doozy.Engine.UI.UIPopup)+10]");
					nint num = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v450 @ rcx_v10 (Doozy.Engine.UI.UIPopup)+18]");
					Array.Clear((Array)num, 0, 0);
				}
				UIPopupManager instance = Instance;
				bool flag = (object)instance == null;
				currentVisibleQueuePopup2 = null;
				if (!flag)
				{
					DoozySettings instance2 = DoozySettings.Instance;
					bool flag2 = (object)instance2 == null;
					currentVisibleQueuePopup2 = null;
					if (!flag2)
					{
						if (instance2.DebugUIPopupManager)
						{
							UIPopupManager instance3 = Instance;
							DDebug.Log("PopupQueue Cleared", instance3);
						}
						return;
					}
				}
			}
		}
		goto IL_03ba;
		IL_03ba:
		throw new NullReferenceException();
	}

	public static UIPopup GetPopup(string popupName)
	{
		UIPopupDatabase database = UIPopupSettings.Database;
		string text;
		string text2;
		if ((object)database != null)
		{
			List<UIPopupLink> popups = database.Popups;
			if (database.Popups != null)
			{
				if (popups._size == 0)
				{
					DDebug.Log("No Popups have been defined in the Popups Database. Open the Control Panel at the Popups section and add some there.");
					return null;
				}
				UIPopupDatabase database2 = UIPopupSettings.Database;
				if ((object)database2 != null)
				{
					if (!database2.Contains(popupName))
					{
						text = "' has been defined in the Popups Database. Open the Control Panel at the Popups section and add it there.";
						text2 = "No Popup with the name '";
						goto IL_0287;
					}
					UIPopupDatabase database3 = UIPopupSettings.Database;
					if ((object)database3 != null)
					{
						GameObject prefab = database3.GetPrefab(popupName);
						if ((object)prefab == null || ((UnityEngine.Object)prefab).m_CachedPtr == (IntPtr)0)
						{
							text = "' PopupName has been defined in the Popups Database. Open the Control Panel at the Popups section and add it there.";
							text2 = "No Popup prefab with the '";
							goto IL_0287;
						}
						UIPopup component = prefab.GetComponent<UIPopup>();
						if ((object)component != null)
						{
							UICanvas targetCanvas = component.GetTargetCanvas();
							if ((object)targetCanvas != null)
							{
								Transform parent = targetCanvas.transform;
								GameObject gameObject = UnityEngine.Object.Instantiate(prefab, parent);
								if ((object)gameObject != null)
								{
									UIPopup component2 = gameObject.GetComponent<UIPopup>();
									if ((object)component2 != null)
									{
										component2.SetPopupName(popupName);
										return component2;
									}
								}
							}
						}
					}
				}
			}
		}
		return (UIPopup)(object)new NullReferenceException();
		IL_0287:
		string message = text2 + popupName + text;
		DDebug.Log(message);
		return null;
	}

	private static UIPopupQueueData GetPopupData(string popupName)
	{
		if (popupName != null && popupName._stringLength > 0 && !QueueIsEmpty)
		{
			if (PopupQueue == null)
			{
				return (UIPopupQueueData)(object)new NullReferenceException();
			}
			List<UIPopupQueueData>.Enumerator enumerator = default(List<UIPopupQueueData>.Enumerator);
			if (enumerator.MoveNext())
			{
				UIPopupQueueData uIPopupQueueData = null;
				throw new NullReferenceException();
			}
		}
		return null;
	}

	private static UIPopupQueueData GetPopupData(UIPopup popup)
	{
		if ((object)popup != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [popup @ rcx (Doozy.Engine.UI.UIPopup)+10]");
			if ((nint)0 != 0 && !QueueIsEmpty)
			{
				if (PopupQueue == null)
				{
					return (UIPopupQueueData)(object)new NullReferenceException();
				}
				List<UIPopupQueueData>.Enumerator enumerator = default(List<UIPopupQueueData>.Enumerator);
				if (enumerator.MoveNext())
				{
					UIPopupQueueData uIPopupQueueData = null;
					throw new NullReferenceException();
				}
			}
		}
		return null;
	}

	public static bool HideCurrentVisiblePopup(bool instantAction = false)
	{
		//IL_009c: Expected I4, but got O
		UIPopup currentVisibleQueuePopup = CurrentVisibleQueuePopup;
		if ((object)CurrentVisibleQueuePopup != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v51 @ rbx_v1 (Doozy.Engine.UI.UIPopup)+10]");
			if ((nint)0 != 0)
			{
				if ((object)CurrentVisibleQueuePopup != null)
				{
					CurrentVisibleQueuePopup.Hide(instantAction);
					ShowNextInQueue();
					return true;
				}
				NullReferenceException ex = new NullReferenceException();
				return (byte)(int)ex != 0;
			}
		}
		return false;
	}

	public static bool IsInQueue(string popupName)
	{
		//IL_01c5: Expected I4, but got O
		//IL_0059: Expected O, but got I4
		if (popupName != null && popupName._stringLength > 0 && !QueueIsEmpty)
		{
			if (PopupQueue == null)
			{
				NullReferenceException ex = new NullReferenceException();
				return (byte)(int)ex != 0;
			}
			List<UIPopupQueueData>.Enumerator enumerator = default(List<UIPopupQueueData>.Enumerator);
			if (enumerator.MoveNext())
			{
				object obj = 0;
				throw new NullReferenceException();
			}
		}
		return false;
	}

	public static bool IsInQueue(UIPopup popup)
	{
		//IL_0180: Expected I4, but got O
		//IL_0068: Expected O, but got I4
		if ((object)popup != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [popup @ rcx (Doozy.Engine.UI.UIPopup)+10]");
			if ((nint)0 != 0 && !QueueIsEmpty)
			{
				if (PopupQueue == null)
				{
					NullReferenceException ex = new NullReferenceException();
					return (byte)(int)ex != 0;
				}
				List<UIPopupQueueData>.Enumerator enumerator = default(List<UIPopupQueueData>.Enumerator);
				if (enumerator.MoveNext())
				{
					object obj = 0;
					throw new NullReferenceException();
				}
			}
		}
		return false;
	}

	public static void RemoveFromQueue(string popupName, bool showNextInQueue = true)
	{
		//IL_02ba: Expected O, but got I4
		//IL_02d4: Expected O, but got I4
		if (!IsInQueue(popupName))
		{
			return;
		}
		UIPopupQueueData popupData = GetPopupData(popupName);
		if (popupData == null)
		{
			return;
		}
		bool flag = ((List<object>)(object)PopupQueue).Remove((object)popupData);
		UIPopupManager instance = Instance;
		DoozySettings instance2 = DoozySettings.Instance;
		if (instance2.DebugUIPopupManager)
		{
			string message = "UIPopup '" + popupData.PopupName + "' removed from the PopupQueue";
			UIPopupManager instance3 = Instance;
			DDebug.Log(message, instance3);
		}
		UIPopup popup = popupData.Popup;
		if ((object)popupData.Popup == null)
		{
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v219 @ rbx_v7 (Doozy.Engine.UI.UIPopup)+10]");
		if ((nint)0 == 0)
		{
			return;
		}
		UIPopup popup2 = popupData.Popup;
		popup2.m_addedToQueue = false;
		UIPopup popup3 = popupData.Popup;
		UIPopup currentVisibleQueuePopup = CurrentVisibleQueuePopup;
		bool flag2 = (object)popupData.Popup == null;
		bool flag3 = (object)CurrentVisibleQueuePopup == null;
		object obj = flag3 & flag2;
		bool flag4 = obj == null;
		object obj2 = !flag4;
		if (obj2 == null)
		{
			bool flag5;
			if ((object)popupData.Popup != null)
			{
				if ((object)CurrentVisibleQueuePopup != null)
				{
					object obj3 = (object)CurrentVisibleQueuePopup - (object)popupData.Popup;
					flag5 = obj3 == null;
				}
				else
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v199 @ rdi_v6 (Doozy.Engine.UI.UIPopup)+10]");
					flag5 = (nint)0 == 0;
				}
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v218 @ rbx_v8 (Doozy.Engine.UI.UIPopup)+10]");
				flag5 = (nint)0 == 0;
			}
			if (!flag5)
			{
				return;
			}
		}
		CurrentVisibleQueuePopup = null;
		if (showNextInQueue)
		{
			ShowNextInQueue();
		}
	}

	public static void RemoveFromQueue(UIPopup popup, bool showNextInQueue = true)
	{
		//IL_01c0: Expected O, but got I4
		//IL_01da: Expected O, but got I4
		if (!IsInQueue(popup))
		{
			return;
		}
		UIPopupQueueData popupData = GetPopupData(popup);
		bool flag = ((List<object>)(object)PopupQueue).Remove((object)popupData);
		UIPopupManager instance = Instance;
		DoozySettings instance2 = DoozySettings.Instance;
		if (instance2.DebugUIPopupManager)
		{
			string message = "UIPopup '" + popup._003CPopupName_003Ek__BackingField + "' added to the PopupQueue";
			UIPopupManager instance3 = Instance;
			DDebug.Log(message, instance3);
		}
		popup.m_addedToQueue = false;
		bool flag2 = (object)CurrentVisibleQueuePopup == null;
		bool flag3 = (object)popup == null;
		object obj = flag3 & flag2;
		bool flag4 = obj == null;
		object obj2 = !flag4;
		if (obj2 == null)
		{
			bool flag5;
			if ((object)CurrentVisibleQueuePopup != null)
			{
				object obj3 = (object)CurrentVisibleQueuePopup - (object)popup;
				flag5 = obj3 == null;
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [popup @ rcx (Doozy.Engine.UI.UIPopup)+10]");
				flag5 = (nint)0 == 0;
			}
			if (!flag5)
			{
				return;
			}
		}
		CurrentVisibleQueuePopup = null;
		if (showNextInQueue)
		{
			ShowNextInQueue();
		}
	}

	public static void ShowNextInQueue()
	{
		UIPopup currentVisibleQueuePopup;
		while (true)
		{
			List<UIPopupQueueData> popupQueue = PopupQueue;
			if (popupQueue._size == 0)
			{
				return;
			}
			List<UIPopupQueueData> popupQueue2 = PopupQueue;
			if (popupQueue2._size > 0)
			{
				UIPopupQueueData[] items = popupQueue2._items;
				UIPopupQueueData uIPopupQueueData = items[0];
				UIPopup popup = uIPopupQueueData.Popup;
				if ((object)uIPopupQueueData.Popup == null)
				{
					goto IL_00e9;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ rbx_v7 (Doozy.Engine.UI.UIPopup)+10]");
				if ((nint)0 == 0)
				{
					goto IL_00e9;
				}
				List<UIPopupQueueData> popupQueue3 = PopupQueue;
				if (popupQueue3._size > 0)
				{
					UIPopupQueueData[] items2 = popupQueue3._items;
					UIPopupQueueData uIPopupQueueData2 = items2[0];
					UIPopup popup2 = uIPopupQueueData2.Popup;
					if ((object)uIPopupQueueData2.Popup != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v146 @ rdi_v6 (Doozy.Engine.UI.UIPopup)+10]");
						if ((nint)0 != 0)
						{
							uIPopupQueueData2.Popup.Show(uIPopupQueueData2.InstantAction);
							currentVisibleQueuePopup = uIPopupQueueData2.Popup;
							break;
						}
					}
					currentVisibleQueuePopup = null;
					break;
				}
			}
			System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
			return;
			IL_00e9:
			PopupQueue.RemoveAt(0);
		}
		CurrentVisibleQueuePopup = currentVisibleQueuePopup;
	}

	public static void ShowPopup(UIPopup popup, bool addToPopupQueue, bool instantAction, string targetCanvasName)
	{
		if ((object)popup == null)
		{
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [popup @ rcx (Doozy.Engine.UI.UIPopup)+10]");
		if ((nint)0 == 0)
		{
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899806E9]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		popup.DisplayTarget = PopupDisplayOn.TargetCanvas;
		popup.CanvasName = targetCanvasName;
		popup.ReparentToTargetCanvas();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [popup @ rcx (Doozy.Engine.UI.UIPopup)+20]");
		if ((nint)0 == 0)
		{
			DoozySettings instance = DoozySettings.Instance;
			if (!instance.DebugUIPopup)
			{
				goto IL_00f6;
			}
		}
		string message = "Set Target Canvas Name: " + targetCanvasName;
		DDebug.Log(message, popup);
		goto IL_00f6;
		IL_00f6:
		ShowPopup(popup, addToPopupQueue, instantAction);
	}

	public static void ShowPopup(UIPopup popup, bool addToPopupQueue, bool instantAction)
	{
		if ((object)popup == null)
		{
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [popup @ rcx (Doozy.Engine.UI.UIPopup)+10]");
		if ((nint)0 == 0)
		{
			return;
		}
		if (!addToPopupQueue)
		{
			UIPopupManager instance = Instance;
			DoozySettings instance2 = DoozySettings.Instance;
			if (instance2.DebugUIPopupManager)
			{
				string message = "Showing UIPopup '" + popup._003CPopupName_003Ek__BackingField + "'";
				UIPopupManager instance3 = Instance;
				DDebug.Log(message, instance3);
			}
			popup.Show(instantAction);
		}
		else
		{
			AddToQueue(popup, instantAction);
		}
	}

	public static UIPopup ShowPopup(string popupName, bool addToPopupQueue, bool instantAction, string targetCanvasName)
	{
		UIPopup popup = GetPopup(popupName);
		ShowPopup(popup, addToPopupQueue, instantAction, targetCanvasName);
		return popup;
	}

	public static UIPopup ShowPopup(string popupName, bool addToPopupQueue, bool instantAction)
	{
		UIPopup popup = GetPopup(popupName);
		ShowPopup(popup, addToPopupQueue, instantAction);
		return popup;
	}

	private static UIPopupManager AddToScene(bool selectGameObjectAfterCreation = false)
	{
		return DoozyUtils.AddToScene<UIPopupManager>("UIPopup Manager", isSingleton: true, selectGameObjectAfterCreation);
	}

	static UIPopupManager()
	{
		List<UIPopupQueueData> popupQueue = new List<UIPopupQueueData>();
		PopupQueue = popupQueue;
	}
}
