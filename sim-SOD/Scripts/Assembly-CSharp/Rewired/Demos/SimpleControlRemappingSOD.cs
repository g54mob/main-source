using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using NaughtyAttributes;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Rewired.Demos
{
	[AddComponentMenu(null)]
	public class SimpleControlRemappingSOD : MonoBehaviour
	{
		[Serializable]
		public class Row
		{
			public InputAction action;

			public AxisRange actionRange;

			public RemapController button;
		}

		[Serializable]
		private struct TargetMapping
		{
			public ControllerMap controllerMap;

			public int actionElementMapId;
		}

		[Serializable]
		private struct Mapping
		{
			public InputMapper mapper;

			public ControllerMap map;
		}

		[CompilerGenerated]
		private sealed class _003CStartListeningJoystickDelayed_003Ed__50 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public SimpleControlRemappingSOD _003C_003E4__this;

			public int index;

			public ControllerMap joyMap;

			public int actionElementMapToReplaceId;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			public _003CStartListeningJoystickDelayed_003Ed__50(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}
		}

		[CompilerGenerated]
		private sealed class _003CStartListeningMkbDelayed_003Ed__51 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public SimpleControlRemappingSOD _003C_003E4__this;

			public int index;

			public ControllerMap keyMap;

			public int actionElementMapToReplaceId;

			public ControllerMap mouseMap;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			public _003CStartListeningMkbDelayed_003Ed__51(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}
		}

		[CompilerGenerated]
		private sealed class _003CListeningAutoCancel_003Ed__52 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public SimpleControlRemappingSOD _003C_003E4__this;

			public ButtonController uiButton;

			private int _003Ccounter_003E5__2;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			public _003CListeningAutoCancel_003Ed__52(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}
		}

		[CompilerGenerated]
		private sealed class _003CRemapDelay_003Ed__61 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public SimpleControlRemappingSOD _003C_003E4__this;

			private float _003Cdelay_003E5__2;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			public _003CRemapDelay_003Ed__61(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}
		}

		public string category;

		private List<string> categories;

		private const string layout = "Default";

		private const string uiCategory = "JoystickUI";

		public bool enableInputMapping;

		public bool listeningForRemap;

		public List<string> mkbExceptions;

		public List<string> joystickExceptions;

		private InputMapper keyboardMapper;

		private InputMapper mouseMapper;

		private InputMapper gamepadMapper;

		public GameObject buttonPrefab;

		public RectTransform fieldGroupTransform;

		public TextMeshProUGUI statusUIText;

		public ToggleController schemeToggle;

		public ButtonController backButton;

		public ButtonController resetControlsButton;

		public Button aboveButton;

		public Button aboveButton2;

		public ButtonController interactionButton;

		public ButtonController movementButton;

		public ButtonController menuButton;

		public ButtonController cityEditButton;

		public VerticalLayoutGroup layoutGroup;

		public ControllerType selectedControllerType;

		private int selectedControllerId;

		public int debugInt;

		public int debugSwap;

		public List<Row> rows;

		public List<UITextSeparator> labels;

		private TargetMapping _replaceTargetMapping;

		private Row _currentRow;

		private List<Controller> controllers;

		private List<ControllerMap> controllerMaps;

		private Player _player;

		private static SimpleControlRemappingSOD _instance;

		public static SimpleControlRemappingSOD Instance => null;

		private void Awake()
		{
		}

		public void UpdateSelectedCategory(string newCategory)
		{
		}

		private void OnEnable()
		{
		}

		private void OnDisable()
		{
		}

		private void RedrawUI()
		{
		}

		private void ClearUI()
		{
		}

		public void InitializeUI()
		{
		}

		private void CreateUIRow(InputAction action, AxisRange actionRange, string label)
		{
		}

		private void SetSelectedController(ControllerType controllerType)
		{
		}

		public void OnControllerSelected(int controllerType)
		{
		}

		public void ResetControls()
		{
		}

		public void OnInputFieldClicked(int index, int actionElementMapToReplaceId)
		{
		}

		[IteratorStateMachine(typeof(_003CStartListeningJoystickDelayed_003Ed__50))]
		private IEnumerator StartListeningJoystickDelayed(int index, ControllerMap joyMap, int actionElementMapToReplaceId)
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CStartListeningMkbDelayed_003Ed__51))]
		private IEnumerator StartListeningMkbDelayed(int index, ControllerMap keyMap, ControllerMap mouseMap, int actionElementMapToReplaceId)
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CListeningAutoCancel_003Ed__52))]
		private IEnumerator ListeningAutoCancel(ButtonController uiButton)
		{
			return null;
		}

		private void UpdateUIText(ButtonController uiButton, int counter)
		{
		}

		private void UpdateButtonInteractability(bool isInteractable)
		{
		}

		private void OnInputMapped(InputMapper.InputMappedEventData data)
		{
		}

		private void OnStopped(InputMapper.StoppedEventData data)
		{
		}

		public void ReplaceControl(ControllerMap map, ElementAssignmentConflictInfo info)
		{
		}

		[Button(null, EButtonEnableMode.Always)]
		public void TestAssign()
		{
		}

		public void RevertControl(ControllerMap map, ElementAssignmentConflictInfo info)
		{
		}

		public void StopMapping(bool removeEvents = false)
		{
		}

		[IteratorStateMachine(typeof(_003CRemapDelay_003Ed__61))]
		private IEnumerator RemapDelay()
		{
			return null;
		}

		private void OnControllerChanged(ControllerStatusChangedEventArgs args)
		{
		}
	}
}
