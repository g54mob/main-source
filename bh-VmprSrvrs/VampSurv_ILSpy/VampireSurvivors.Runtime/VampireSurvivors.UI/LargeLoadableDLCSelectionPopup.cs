using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using TMPro;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace VampireSurvivors.UI;

public class LargeLoadableDLCSelectionPopup : BasePopup
{
	private sealed class _003CFrameDelays_003Ed__9(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state = _003C_003E1__state;

		private object _003C_003E2__current;

		public LargeLoadableDLCSelectionPopup _003C_003E4__this;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			//IL_0014: Expected I4, but got I8
			//IL_0062: Expected I4, but got I8
			LargeLoadableDLCSelectionPopup largeLoadableDLCSelectionPopup = _003C_003E4__this;
			if (_003C_003E1__state == 0)
			{
				_003C_003E1__state = -1;
				_003C_003E2__current = null;
				_003C_003E1__state = 1;
				return true;
			}
			if (_003C_003E1__state == 1)
			{
				_003C_003E1__state = -1;
				List<GameObject> spawned = largeLoadableDLCSelectionPopup._spawned;
				if (spawned._size <= 0)
				{
					System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
					bool result = default(bool);
					return result;
				}
				GameObject[] items = spawned._items;
				LargeLoadableDLCSelectionPopupItem component = items[0].GetComponent<LargeLoadableDLCSelectionPopupItem>();
				((SelectableUI)component)._selectable.Select();
			}
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		void IEnumerator.Reset()
		{
			NotSupportedException ex = new NotSupportedException();
			throw ex;
		}
	}

	protected TextMeshProUGUI _Title;

	protected TextMeshProUGUI _Description;

	protected RectTransform _Container;

	protected Button _Confirm;

	protected Button _Back;

	protected LargeLoadableDLCSelectionPopupItem _DLCOptionPrefab;

	protected List<DLCOptionDataSet> _Options;

	protected Action _onConfirmCallback;

	public unsafe virtual void Initialize(string id, string title, string description, List<DLCOptionDataSet> options, Action callback, bool showBackButton)
	{
		//IL_016b: Expected O, but got I4
		//IL_0174: Expected O, but got I4
		//IL_0253: Expected O, but got I
		//IL_0288: Expected O, but got I
		//IL_02cf: Expected O, but got I
		//IL_061c: Expected O, but got Ref
		//IL_0304: Expected O, but got I
		//IL_034b: Expected O, but got I
		//IL_0703: Expected O, but got I4
		//IL_0737: Unknown result type (might be due to invalid IL or missing references)
		//IL_073c: Expected O, but got Unknown
		//IL_0669: Unknown result type (might be due to invalid IL or missing references)
		//IL_066e: Expected O, but got Unknown
		//IL_079b: Unknown result type (might be due to invalid IL or missing references)
		//IL_07a0: Expected O, but got Unknown
		//IL_07bd: Expected O, but got I4
		//IL_03b2: Expected O, but got I
		//IL_048e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0493: Expected O, but got Unknown
		//IL_01ec->IL07f1: Incompatible stack heights: 1 vs 0
		//IL_0223->IL07f1: Incompatible stack heights: 1 vs 0
		//IL_057d->IL07f1: Incompatible stack heights: 1 vs 0
		//IL_05a3->IL07f1: Incompatible stack heights: 1 vs 0
		//IL_0273->IL07f1: Incompatible stack heights: 1 vs 0
		//IL_05d6->IL07f1: Incompatible stack heights: 1 vs 0
		//IL_02a8->IL07f1: Incompatible stack heights: 1 vs 0
		//IL_0605->IL07f1: Incompatible stack heights: 1 vs 0
		//IL_02ef->IL07f1: Incompatible stack heights: 1 vs 0
		//IL_0324->IL07f1: Incompatible stack heights: 1 vs 0
		//IL_06eb->IL07f1: Incompatible stack heights: 1 vs 0
		//IL_065b->IL07f1: Incompatible stack heights: 1 vs 0
		//IL_036b->IL07f1: Incompatible stack heights: 1 vs 0
		//IL_075e->IL07f1: Incompatible stack heights: 1 vs 0
		//IL_0690->IL07f1: Incompatible stack heights: 1 vs 0
		//IL_0390->IL07f1: Incompatible stack heights: 1 vs 0
		//IL_07d3->IL0887: Incompatible stack heights: 1 vs 0
		//IL_07dd->IL07f1: Incompatible stack heights: 1 vs 0
		//IL_085e->IL07f1: Incompatible stack heights: 2 vs 0
		//IL_0410->IL07f1: Incompatible stack heights: 2 vs 0
		//IL_04ad->IL07f1: Incompatible stack heights: 2 vs 0
		//IL_04c7->IL0863: Incompatible stack heights: 2 vs 0
		_ID = id;
		if ((object)_Title != null)
		{
			_Title.text = title;
			Action onConfirmCallback = default(Action);
			_onConfirmCallback = onConfirmCallback;
			if ((object)_Description != null)
			{
				string text = default(string);
				_Description.text = text;
				List<DLCOptionDataSet> options2 = default(List<DLCOptionDataSet>);
				_Options = options2;
				EventSystem current = EventSystem.current;
				if ((object)current != null)
				{
					_previouslySelected = current.m_CurrentSelected;
					object obj = default(object);
					if (obj == null)
					{
						goto IL_0139;
					}
					if ((object)_Back != null)
					{
						GameObject gameObject = _Back.gameObject;
						if ((object)gameObject != null)
						{
							gameObject.SetActive(value: true);
							goto IL_0139;
						}
					}
				}
			}
		}
		goto IL_07f1;
		IL_0139:
		if (_Options != null)
		{
			List<DLCOptionDataSet> options3 = _Options;
			object obj2 = 0;
			object obj3 = 0;
			while ((nint)obj2 < options3._size)
			{
				List<DLCOptionDataSet> options4 = _Options;
				if (_Options != null)
				{
					bool flag = (nint)obj3 >= options4._size;
					DLCOptionDataSet[] items = options4._items;
					if (options4._items != null)
					{
						LargeLoadableDLCSelectionPopupItem largeLoadableDLCSelectionPopupItem = UnityEngine.Object.Instantiate(_DLCOptionPrefab, _Container);
						if ((object)largeLoadableDLCSelectionPopupItem != null)
						{
							largeLoadableDLCSelectionPopupItem._dlcOptionDataSet = items[obj3];
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v223 @ rax_v64 (LargeLoadableDLCSelectionPopupItem)+B8]");
							object obj4 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v223 @ rax_v64 (LargeLoadableDLCSelectionPopupItem)+B8]");
							if ((nint)0 != 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v223 @ rax_v64 (LargeLoadableDLCSelectionPopupItem)+A8]");
								object obj5 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v223 @ rax_v64 (LargeLoadableDLCSelectionPopupItem)+A8]");
								if ((nint)0 != 0)
								{
									object obj6 = obj5;
									Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1325 @ rax_v66+558] (should have been resolved before IL gen)");
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v223 @ rax_v64 (LargeLoadableDLCSelectionPopupItem)+B8]");
									object obj7 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v223 @ rax_v64 (LargeLoadableDLCSelectionPopupItem)+B8]");
									if ((nint)0 != 0)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v223 @ rax_v64 (LargeLoadableDLCSelectionPopupItem)+B0]");
										object obj8 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v223 @ rax_v64 (LargeLoadableDLCSelectionPopupItem)+B0]");
										if ((nint)0 != 0)
										{
											object obj9 = obj8;
											Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1327 @ rax_v68+558] (should have been resolved before IL gen)");
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v223 @ rax_v64 (LargeLoadableDLCSelectionPopupItem)+B8]");
											object obj10 = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v223 @ rax_v64 (LargeLoadableDLCSelectionPopupItem)+B8]");
											if ((nint)0 != 0)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v223 @ rax_v64 (LargeLoadableDLCSelectionPopupItem)+A0]");
												if ((nint)0 != 0)
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v223 @ rax_v64 (LargeLoadableDLCSelectionPopupItem)+A0]");
													nint num = 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v188 @ rdx_v38+20]");
													((TickBoxUI)num).InitialSet(b: false);
													List<object> spawned = (List<object>)(object)_spawned;
													bool flag2 = ((string)(object)largeLoadableDLCSelectionPopupItem)._stringLength == 0;
													IntPtr gcHandlePtr = Component.get_gameObject_Injected((IntPtr)((string)(object)largeLoadableDLCSelectionPopupItem)._stringLength);
													GameObject gameObject2 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<GameObject>(gcHandlePtr);
													if (_spawned != null)
													{
														int version = spawned._version + 1;
														spawned._version = version;
														object[] items2 = spawned._items;
														if (spawned._items != null)
														{
															if (spawned._size >= items2.Length)
															{
																((List<object>)(object)_spawned).AddWithResize((object)gameObject2);
															}
															else
															{
																int size = spawned._size + 1;
																spawned._size = size;
																Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
															}
															options3 = _Options;
															obj3++;
															if (_Options != null)
															{
																string text = (string)(object)gameObject2;
																obj2 = obj3;
																continue;
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
					}
				}
				goto IL_07f1;
			}
			LayoutRebuilder.ForceRebuildLayoutImmediate(_Container);
			List<GameObject> spawned2 = _spawned;
			bool flag3 = _spawned == null;
			string text2 = null;
			string text3 = null;
			if (flag3)
			{
				goto IL_07f1;
			}
			object obj11 = default(object);
			GameObject gameObject3 = default(GameObject);
			GameObject gameObject4 = default(GameObject);
			while ((nint)text2 < spawned2._size)
			{
				List<GameObject> spawned3 = _spawned;
				LargeLoadableDLCSelectionPopupItem component;
				if (_spawned != null)
				{
					bool flag4 = (nint)text3 >= spawned3._size;
					GameObject[] items3 = spawned3._items;
					if (spawned3._items != null && (object)items3[(object)text3] != null)
					{
						component = items3[(object)text3].GetComponent<LargeLoadableDLCSelectionPopupItem>();
						if ((object)component != null)
						{
							Selectable selectable = ((SelectableUI)component)._selectable;
							if ((object)((SelectableUI)component)._selectable != null)
							{
								((SelectableUI)component)._selectable.navigation = (Navigation)(&obj11);
								bool flag5 = (nint)text3 <= 0;
								Selectable selectable2 = null;
								if (flag5)
								{
									goto IL_06c7;
								}
								if (_spawned != null)
								{
									object obj12 = text3 - 1;
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
									if ((object)gameObject3 != null)
									{
										Selectable component2 = gameObject3.GetComponent<Selectable>();
										SetNavigationUp(((SelectableUI)component)._selectable, component2);
										string text = null;
										selectable2 = component2;
										goto IL_06c7;
									}
								}
							}
						}
					}
				}
				goto IL_07f1;
				IL_06c7:
				List<GameObject> spawned4 = _spawned;
				if (_spawned != null)
				{
					object obj13 = spawned4._size - 1;
					Selectable target;
					if (System.Runtime.CompilerServices.Unsafe.As<string, UIntPtr>(ref text3) >= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj13))
					{
						target = _Confirm;
					}
					else
					{
						object obj14 = text3 + 1;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
						if ((object)gameObject4 == null)
						{
							goto IL_07f1;
						}
						target = gameObject4.GetComponent<Selectable>();
					}
					SetNavigationDown(((SelectableUI)component)._selectable, target);
					spawned2 = _spawned;
					text3++;
					bool flag6 = _spawned != null;
					obj11 = 4;
					string text = null;
					text2 = text3;
					if (flag6)
					{
						continue;
					}
				}
				goto IL_07f1;
			}
		}
		_003CFrameDelays_003Ed__9 obj15 = null;
		obj15._003C_003E1__state = 0;
		obj15._003C_003E4__this = this;
		Coroutine coroutine = StartCoroutine(obj15);
		return;
		IL_07f1:
		throw new NullReferenceException();
	}

	private IEnumerator FrameDelays()
	{
		_003CFrameDelays_003Ed__9 obj = null;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		return obj;
	}

	public unsafe void Confirm()
	{
		//IL_01ab: Expected I4, but got O
		//IL_0013: Expected O, but got I4
		//IL_001b: Expected O, but got Ref
		System.Collections.Generic.InsertionBehavior insertionBehavior = (System.Collections.Generic.InsertionBehavior)(int)_Options;
		List<DLCOptionDataSet>.Enumerator enumerator = default(List<DLCOptionDataSet>.Enumerator);
		if (enumerator.MoveNext())
		{
			object obj = 0;
			List<DLCOptionDataSet>.Enumerator enumerator2 = (List<DLCOptionDataSet>.Enumerator)(&enumerator);
			throw new NullReferenceException();
		}
		Debug.Log("confrimed DLC selection pre save");
		Debug.LogError("SaveDlcSelection will not be saved as the current platform is not IOS or Android");
		Debug.Log("confrimed DLC selection post save");
		Action onConfirmCallback = _onConfirmCallback;
		if (_onConfirmCallback != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v594.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
		}
		base.Hide();
		PopupManager.ClosePopup(_ID);
	}

	public void Close()
	{
		base.Hide();
		PopupManager.ClosePopup(_ID);
	}
}
