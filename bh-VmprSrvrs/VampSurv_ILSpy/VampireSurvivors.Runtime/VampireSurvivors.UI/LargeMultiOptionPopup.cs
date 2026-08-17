using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using Rewired;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using VampireSurvivors.Framework;

namespace VampireSurvivors.UI;

public class LargeMultiOptionPopup : BasePopup
{
	private sealed class _003C_003Ec__DisplayClass10_0
	{
		public GameObject optionItemGameObject;

		public LargeMultiOptionPopup _003C_003E4__this;

		internal void _003CInitialize_003Eb__0()
		{
			_003C_003E4__this.SelectOption(optionItemGameObject);
		}
	}

	private sealed class _003CFrameDelays_003Ed__11(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state = _003C_003E1__state;

		private object _003C_003E2__current;

		public LargeMultiOptionPopup _003C_003E4__this;

		private ScrollRect _003CscrollRect_003E5__2;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		void IDisposable.Dispose()
		{
		}

		private unsafe bool MoveNext()
		{
			//IL_0538: Expected I4, but got I8
			//IL_0026: Expected O, but got I4
			//IL_0261: Expected I4, but got I8
			//IL_0063: Expected I4, but got I8
			//IL_008e: Expected O, but got I
			//IL_009e: Expected O, but got I
			//IL_0743: Expected O, but got I
			//IL_0753: Expected O, but got I
			//IL_00fa: Expected O, but got I
			//IL_0361: Expected O, but got I
			//IL_014d: Expected O, but got I
			//IL_03b4: Expected O, but got I
			//IL_07b5: Expected O, but got I
			//IL_07c5: Expected O, but got I
			//IL_0467: Expected O, but got I
			//IL_04c4: Expected O, but got I
			//IL_023f: Expected O, but got I
			//IL_0733->IL07f4: Incompatible stack heights: 6 vs 2
			//IL_0529->IL07e6: Incompatible stack heights: 15 vs 0
			//IL_0244->IL0244: Incompatible stack heights: 18 vs 0
			Component component = _003C_003E4__this;
			bool flag = _003C_003E1__state == 0;
			if (!flag)
			{
				object obj = _003C_003E1__state - 1;
				if (!flag)
				{
					if ((nint)obj == 1)
					{
						_003C_003E1__state = -1;
						bool flag2 = (object)_003C_003E4__this == null;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ r15_v1 (UnityEngine.Component)+20]");
						object obj2 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ r15_v1 (UnityEngine.Component)+70]");
						object obj3 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ r15_v1 (UnityEngine.Component)+20]");
						bool flag3 = (nint)0 == 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ r15_v1 (UnityEngine.Component)+70]");
						nint num = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v360 @ rcx_v68+18]");
						bool flag4 = num >= 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v360 @ rcx_v68+10]");
						object obj4 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v360 @ rcx_v68+10]");
						bool flag5 = (nint)0 == 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v336 @ rdx_v45+20+v613 @ rax_v85*8]");
						bool flag6 = (nint)0 == 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v336 @ rdx_v45+20+v613 @ rax_v85*8]");
						RectTransform component2 = ((GameObject)0).GetComponent<RectTransform>();
						Component component3 = _003CscrollRect_003E5__2;
						bool flag7 = (object)_003CscrollRect_003E5__2 == null;
						Transform transform = _003CscrollRect_003E5__2.transform;
						ScrollRect scrollRect = _003CscrollRect_003E5__2;
						bool flag8 = (object)_003CscrollRect_003E5__2 == null;
						object content = scrollRect.m_Content;
						bool flag9 = (object)scrollRect.m_Content == null;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v317 @ rsi_v21 (System.Object)+10]");
						bool flag10 = (nint)0 == 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v317 @ rsi_v21 (System.Object)+10]");
						Transform.get_position_Injected((IntPtr)0, out Vector3 ret);
						bool flag11 = (object)transform == null;
						bool flag12 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
						Vector3 position = default(Vector3);
						Transform.InverseTransformPoint_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref position, out Vector3 _);
						bool flag13 = (object)_003CscrollRect_003E5__2 == null;
						Transform transform2 = _003CscrollRect_003E5__2.transform;
						bool flag14 = (object)component2 == null;
						bool flag15 = ((UnityEngine.Object)component2).m_CachedPtr == (IntPtr)0;
						Transform.get_position_Injected(((UnityEngine.Object)component2).m_CachedPtr, out ret);
						bool flag16 = (object)transform2 == null;
						bool flag17 = ((_003CFrameDelays_003Ed__11)(object)transform2)._003C_003E1__state == 0;
						List<GameObject>.Enumerator position2 = default(List<GameObject>.Enumerator);
						Transform.InverseTransformPoint_Injected((IntPtr)((_003CFrameDelays_003Ed__11)(object)transform2)._003C_003E1__state, ref *(Vector3*)(&position2), out position);
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181B93710");
						bool flag18 = ((UnityEngine.Object)component2).m_CachedPtr == (IntPtr)0;
						RectTransform.get_rect_Injected(((UnityEngine.Object)component2).m_CachedPtr, out *(Rect*)(&position2));
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v614 @ rax_v87 (UnityEngine.Component)+20]");
						bool flag19 = (nint)0 == 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v614 @ rax_v87 (UnityEngine.Component)+20]");
						Vector2 anchoredPosition = default(Vector2);
						((RectTransform)0).anchoredPosition = anchoredPosition;
					}
					return false;
				}
				_003C_003E1__state = -1;
				bool flag20 = (object)_003C_003E4__this == null;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ r15_v1 (UnityEngine.Component)+20]");
				bool flag21 = (nint)0 == 0;
				List<GameObject>.Enumerator enumerator = default(List<GameObject>.Enumerator);
				while (enumerator.MoveNext())
				{
					Transform transform3 = ((GameObject)null).transform;
					bool flag22 = (object)transform3 == null;
					Transform child = transform3.GetChild(2);
					bool flag23 = (object)child == null;
					GameObject gameObject = child.gameObject;
					bool flag24 = (object)gameObject == null;
					bool flag25 = ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0;
					GameObject.SetActive_Injected(((UnityEngine.Object)gameObject).m_CachedPtr, false);
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ r15_v1 (UnityEngine.Component)+20]");
				object obj5 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ r15_v1 (UnityEngine.Component)+70]");
				object obj6 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ r15_v1 (UnityEngine.Component)+20]");
				bool flag26 = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ r15_v1 (UnityEngine.Component)+70]");
				nint num2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v617 @ rax_v42+18]");
				bool flag27 = num2 >= 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v617 @ rax_v42+10]");
				object obj7 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v617 @ rax_v42+10]");
				bool flag28 = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v340 @ rdx_v24+20+v364 @ rcx_v31*8]");
				bool flag29 = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v340 @ rdx_v24+20+v364 @ rcx_v31*8]");
				Transform transform4 = ((GameObject)0).transform;
				bool flag30 = (object)transform4 == null;
				Transform child2 = transform4.GetChild(2);
				bool flag31 = (object)child2 == null;
				GameObject gameObject2 = child2.gameObject;
				bool flag32 = (object)gameObject2 == null;
				bool flag33 = ((UnityEngine.Object)gameObject2).m_CachedPtr == (IntPtr)0;
				GameObject.SetActive_Injected(((UnityEngine.Object)gameObject2).m_CachedPtr, true);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ r15_v1 (UnityEngine.Component)+20]");
				object obj8 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ r15_v1 (UnityEngine.Component)+70]");
				object obj9 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ r15_v1 (UnityEngine.Component)+20]");
				bool flag34 = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ r15_v1 (UnityEngine.Component)+70]");
				nint num3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v373 @ rcx_v38+18]");
				bool flag35 = num3 >= 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v373 @ rcx_v38+10]");
				object obj10 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v373 @ rcx_v38+10]");
				bool flag36 = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v368 @ rcx_v39+20+v621 @ rax_v50*8]");
				bool flag37 = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v368 @ rcx_v39+20+v621 @ rax_v50*8]");
				Selectable componentInChildren = ((GameObject)0).GetComponentInChildren<Selectable>(includeInactive: false);
				bool flag38 = (object)componentInChildren == null;
				componentInChildren.Select();
				ScrollRect componentInChildren2 = _003C_003E4__this.GetComponentInChildren<ScrollRect>();
				_003CscrollRect_003E5__2 = componentInChildren2;
				Canvas.ForceUpdateCanvases();
				_003C_003E2__current = null;
				_003C_003E1__state = 2;
			}
			else
			{
				_003C_003E1__state = -1;
				_003C_003E2__current = null;
				_003C_003E1__state = 1;
			}
			return true;
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

	protected GameObject _OptionPrefab;

	protected int _selectedIndex;

	private Rewired.Player _player;

	protected Action<int> _onSelectedCallback;

	protected Action _onClosedCallback;

	protected void Update()
	{
		//IL_001d: Expected O, but got I4
		//IL_0053: Expected O, but got I4
		bool buttonDown = _player.GetButtonDown(10);
		object obj = 0;
		if (!buttonDown)
		{
			bool buttonDown2 = _player.GetButtonDown(6);
			bool flag = !buttonDown2;
			obj = 0;
			if (flag)
			{
				return;
			}
		}
		if (_onClosedCallback != null)
		{
			Action onClosedCallback = _onClosedCallback;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v123.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
		}
		base.Hide();
		PopupManager.ClosePopup(_ID);
	}

	public unsafe virtual void Initialize(string id, string title, string description, List<OptionDataSet> options, Action<int> callback, Action closedCallback, TextAlignmentOptions? titleTextAlignment = null, bool centerTicks = false)
	{
		//IL_0008: Expected O, but got Ref
		//IL_00c6: Expected O, but got I
		//IL_0111: Expected O, but got I
		//IL_014d: Expected O, but got I
		//IL_015b: Expected O, but got I4
		//IL_0164: Expected O, but got I4
		//IL_016d: Expected O, but got I4
		//IL_0556: Expected O, but got I4
		//IL_055f: Expected O, but got I4
		//IL_01c6: Expected O, but got I
		//IL_01db: Expected O, but got I
		//IL_0605: Expected O, but got Ref
		//IL_0238: Expected O, but got I
		//IL_0696: Expected O, but got I4
		//IL_0633: Unknown result type (might be due to invalid IL or missing references)
		//IL_0638: Expected O, but got Unknown
		//IL_0261: Expected O, but got I
		//IL_0742: Unknown result type (might be due to invalid IL or missing references)
		//IL_0747: Expected O, but got Unknown
		//IL_0305: Expected O, but got I
		//IL_0781: Expected O, but got I
		//IL_028f: Expected I4, but got O
		//IL_079e: Unknown result type (might be due to invalid IL or missing references)
		//IL_07a3: Expected O, but got Unknown
		//IL_06f8: Expected O, but got Ref
		//IL_02f0: Expected O, but got I
		//IL_072f: Expected O, but got I
		//IL_0358: Expected O, but got I
		//IL_051b: Expected O, but got I
		//IL_0524: Unknown result type (might be due to invalid IL or missing references)
		//IL_0529: Expected O, but got Unknown
		//IL_0449: Expected O, but got I
		//IL_04dd: Expected O, but got Ref
		object obj2 = default(object);
		object obj = (object)(&obj2);
		int playerCount = MultiplayerManager.s_instance.GetPlayerCount();
		Rewired.Player player;
		if (playerCount <= 1 && !MultiplayerManager.s_instance.IsOnlineMultiplayer)
		{
			ReInput.PlayerHelper players = ReInput.players;
			player = players.GetPlayer(0);
		}
		else
		{
			player = MultiplayerManager.s_instance.GetCurrentUIPlayer();
		}
		_player = player;
		_ID = id;
		_Title.text = title;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+78]");
		_onSelectedCallback = (Action<int>)0;
		string text = default(string);
		_Description.text = text;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+80]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+80]");
			_onClosedCallback = (Action)0;
		}
		EventSystem current = EventSystem.current;
		_previouslySelected = current.m_CurrentSelected;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+70]");
		object obj3 = 0;
		object obj4 = 0;
		object obj5 = 0;
		object obj6 = 0;
		Vector2 vector = default(Vector2);
		object message = default(object);
		Vector2 vector2 = default(Vector2);
		object obj16 = default(object);
		GameObject gameObject2 = default(GameObject);
		GameObject gameObject3 = default(GameObject);
		while (true)
		{
			object obj7 = obj5;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v382 @ rsi_v6+18]");
			if ((nint)obj7 < 0)
			{
				_003C_003Ec__DisplayClass10_0 CS_0024_003C_003E8__locals6 = new _003C_003Ec__DisplayClass10_0();
				CS_0024_003C_003E8__locals6._003C_003E4__this = this;
				object obj8 = obj6;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v382 @ rsi_v6+18]");
				if ((nint)obj8 >= 0)
				{
					break;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v382 @ rsi_v6+10]");
				object obj9 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v332 @ rcx_v49+20+v394 @ r15_v6*8]");
				object obj10 = 0;
				GameObject optionItemGameObject = UnityEngine.Object.Instantiate(_OptionPrefab, _Container);
				CS_0024_003C_003E8__locals6.optionItemGameObject = optionItemGameObject;
				LargeMultiOptionPopupItem component = CS_0024_003C_003E8__locals6.optionItemGameObject.GetComponent<LargeMultiOptionPopupItem>();
				TextMeshProUGUI title2 = component.Title;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v395 @ r15_v8+10]");
				title2.text = (string)0;
				TextMeshProUGUI description2 = component.Description;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v395 @ r15_v8+18]");
				description2.text = (string)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+88]");
				if ((nint)0 != 0)
				{
					object obj11 = (TextAlignmentOptions)vector;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182AD6810");
					GameObject context = component.gameObject;
					Debug.Log(message, context);
					TextMeshProUGUI title3 = component.Title;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+8C]");
					title3.alignment = (TextAlignmentOptions)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+8C]");
					vector = (Vector2)0;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v395 @ r15_v8+20]");
				object obj12 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v395 @ r15_v8+20]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v190 @ r12_v8+10]");
					if ((nint)0 != 0)
					{
						Image image = component.Image;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v395 @ r15_v8+20]");
						image.sprite = (Sprite)0;
						GameObject gameObject = component.Image.gameObject;
						gameObject.SetActive(value: true);
					}
				}
				Button component2 = CS_0024_003C_003E8__locals6.optionItemGameObject.GetComponent<Button>();
				UnityAction call = delegate
				{
					CS_0024_003C_003E8__locals6._003C_003E4__this.SelectOption(CS_0024_003C_003E8__locals6.optionItemGameObject);
				};
				component2.m_OnClick.AddListener(call);
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180497F80");
				component.Tick.SetActive(value: true);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+90]");
				if ((nint)0 != 0)
				{
					RectTransform component3 = component.Tick.GetComponent<RectTransform>();
					component3.anchoredPosition = vector2;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v395 @ r15_v8+20]");
					object obj13 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v395 @ r15_v8+20]");
					bool flag = (nint)0 == 0;
					Vector2 vector3 = vector2;
					if (!flag)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2063 @ r14_v9+10]");
						bool flag2 = (nint)0 == 0;
						vector3 = vector2;
						if (!flag2)
						{
							Vector4 margin = component.Title.margin;
							Vector4 margin2 = component.Title.margin;
							Vector4 margin3 = component.Title.margin;
							component.Title.margin = (Vector4)(&vector);
							vector3 = vector2;
							vector = vector2;
						}
					}
				}
				if (obj4 == null)
				{
					component.Tick.SetActive(value: true);
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+70]");
				obj3 = 0;
				obj6 = obj4 + 1;
				text = null;
				obj4 = obj6;
				obj5 = obj6;
				continue;
			}
			List<GameObject> spawned = _spawned;
			object obj14 = 0;
			object obj15 = 0;
			while (true)
			{
				if ((nint)obj15 < spawned._size)
				{
					List<GameObject> spawned2 = _spawned;
					if ((nint)obj14 >= spawned2._size)
					{
						break;
					}
					GameObject[] items = spawned2._items;
					Selectable component4 = items[obj14].GetComponent<Selectable>();
					_ = component4.m_Navigation;
					_ = 4;
					component4.navigation = (Navigation)(&obj16);
					bool flag3 = (nint)obj14 <= 0;
					Selectable selectable = null;
					if (!flag3)
					{
						object obj17 = obj14 - 1;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
						Selectable component5 = gameObject2.GetComponent<Selectable>();
						SetNavigationUp(component4, component5);
						text = null;
						selectable = component5;
					}
					List<GameObject> spawned3 = _spawned;
					object obj18 = spawned3._size - 1;
					if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj14) >= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj18))
					{
						SetNavigationDown(component4, _Confirm);
						Selectable component6 = _Confirm.GetComponent<Selectable>();
						_ = component6.m_Navigation;
						_ = 4;
						component6.navigation = (Navigation)(&obj16);
						Selectable component7 = _Confirm.GetComponent<Selectable>();
						SetNavigationUp(component7, component4);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-80]");
						obj16 = 0;
						text = null;
					}
					else
					{
						object obj19 = obj14 + 1;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
						Selectable component8 = gameObject3.GetComponent<Selectable>();
						SetNavigationDown(component4, component8);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-80]");
						obj16 = 0;
						text = null;
					}
					spawned = _spawned;
					obj14++;
					obj15 = obj14;
					continue;
				}
				_003CFrameDelays_003Ed__11 obj20 = null;
				obj20._003C_003E1__state = 0;
				obj20._003C_003E4__this = this;
				Coroutine coroutine = StartCoroutine(obj20);
				return;
			}
			break;
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
	}

	private IEnumerator FrameDelays()
	{
		_003CFrameDelays_003Ed__11 obj = null;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		return obj;
	}

	public void SelectOption(int index)
	{
		List<GameObject> spawned = _spawned;
		int num = 0;
		GameObject gameObject = default(GameObject);
		GameObject gameObject2 = default(GameObject);
		for (int num2 = 0; num2 < spawned._size; num2 = num)
		{
			GameObject tick;
			bool active;
			if (index != num)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
				LargeMultiOptionPopupItem component = gameObject.GetComponent<LargeMultiOptionPopupItem>();
				tick = component.Tick;
				active = false;
			}
			else
			{
				_selectedIndex = num;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
				LargeMultiOptionPopupItem component2 = gameObject2.GetComponent<LargeMultiOptionPopupItem>();
				tick = component2.Tick;
				active = true;
			}
			tick.SetActive(active);
			spawned = _spawned;
			num++;
		}
		Selectable component3 = _Confirm.GetComponent<Selectable>();
		component3.Select();
	}

	public void SelectOption(GameObject g)
	{
		//IL_0244: Expected O, but got I4
		//IL_025e: Expected O, but got I4
		List<GameObject> spawned = _spawned;
		int num = 0;
		int num2 = 0;
		GameObject gameObject2 = default(GameObject);
		while (true)
		{
			GameObject tick;
			bool active;
			if (num2 < spawned._size)
			{
				List<GameObject> spawned2 = _spawned;
				if (num >= spawned2._size)
				{
					break;
				}
				GameObject[] items = spawned2._items;
				GameObject gameObject = items[num];
				bool flag = (object)items[num] == null;
				bool flag2 = (object)g == null;
				object obj = flag2 & flag;
				bool flag3 = obj == null;
				object obj2 = !flag3;
				if (obj2 == null)
				{
					bool flag4;
					if ((object)items[num] != null)
					{
						if ((object)g != null)
						{
							object obj3 = (object)g - (object)items[num];
							flag4 = obj3 == null;
						}
						else
						{
							flag4 = ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0;
						}
					}
					else
					{
						flag4 = ((UnityEngine.Object)g).m_CachedPtr == (IntPtr)0;
					}
					if (!flag4)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
						LargeMultiOptionPopupItem component = gameObject2.GetComponent<LargeMultiOptionPopupItem>();
						tick = component.Tick;
						active = false;
						goto IL_027a;
					}
				}
				_selectedIndex = num;
				LargeMultiOptionPopupItem component2 = g.GetComponent<LargeMultiOptionPopupItem>();
				tick = component2.Tick;
				active = true;
				goto IL_027a;
			}
			Selectable component3 = _Confirm.GetComponent<Selectable>();
			component3.Select();
			return;
			IL_027a:
			tick.SetActive(active);
			spawned = _spawned;
			num++;
			num2 = num;
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
	}

	public void Confirm()
	{
		base.Hide();
		Action<int> onSelectedCallback = _onSelectedCallback;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v13 @ rax_v3 (System.Action`1<System.Int32>)+18] (should have been resolved before IL gen)");
		PopupManager.ClosePopup(_ID);
	}

	public void Closed()
	{
		if (_onClosedCallback != null)
		{
			Action onClosedCallback = _onClosedCallback;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v14.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
		}
		base.Hide();
		PopupManager.ClosePopup(_ID);
	}
}
