using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Input.XR;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Assets.Scripts.XR.UI.Layout
{
	public class ControllerLayoutScript : MonoBehaviour
	{
		private class QueryInputAction : IQueryInputAction, IDisposable
		{
			public event Action BindingsChanged;

			public QueryInputAction()
			{
				if (Game.Instance.SceneManager.InMenuScene)
				{
					XRVirtualInputDevice.UpdateGrip(XRHandType.Left, XRControlGripType.Default);
					XRVirtualInputDevice.UpdateGrip(XRHandType.Right, XRControlGripType.Default);
					XRInputs.Menu.GripLeft.performed += OnMenuGripChanged;
					XRInputs.Menu.GripLeft.canceled += OnMenuGripChanged;
					XRInputs.Menu.GripRight.performed += OnMenuGripChanged;
					XRInputs.Menu.GripRight.canceled += OnMenuGripChanged;
				}
				XRVirtualInputDevice.Current.OnStateChanged += OnGripStateChanged;
			}

			public void Dispose()
			{
				XRVirtualInputDevice.Current.OnStateChanged -= OnGripStateChanged;
				XRInputs.Menu.GripLeft.performed -= OnMenuGripChanged;
				XRInputs.Menu.GripLeft.canceled -= OnMenuGripChanged;
				XRInputs.Menu.GripRight.performed -= OnMenuGripChanged;
				XRInputs.Menu.GripRight.canceled -= OnMenuGripChanged;
			}

			public string GetActionName(string inputBindingPath, HandScriptBase hand)
			{
				FlightHand flightHand = hand as FlightHand;
				if (flightHand?.GripTarget != null)
				{
					string overrideControlBinding = flightHand.GripTarget.GetOverrideControlBinding(inputBindingPath);
					if (!string.IsNullOrWhiteSpace(overrideControlBinding))
					{
						return overrideControlBinding;
					}
				}
				List<InputAction> inputActions = XRInputs.Flight.GetInputActions(hand.HandType, XRVirtualInputDevice.Current.GetGrip(hand.HandType), inputBindingPath);
				if (inputActions == null || inputActions.Count == 0)
				{
					return null;
				}
				if (inputActions.Count == 1)
				{
					return inputActions[0].name;
				}
				return string.Join(System.Environment.NewLine, inputActions.Select((InputAction x) => x.name));
			}

			private void OnGripStateChanged(object sender, EventArgs e)
			{
				this.BindingsChanged?.Invoke();
			}

			private void OnMenuGripChanged(InputAction.CallbackContext context)
			{
				int num;
				int num2;
				if (context.action != XRInputs.Menu.GripLeft)
				{
					num = 1;
					if (num != 0)
					{
						num2 = (context.canceled ? 1 : 2);
						goto IL_0031;
					}
				}
				else
				{
					num = 0;
				}
				num2 = (context.canceled ? 1 : 4);
				goto IL_0031;
				IL_0031:
				XRControlGripType gripType = (XRControlGripType)num2;
				XRVirtualInputDevice.UpdateGrip((XRHandType)num, gripType);
			}
		}

		private List<ControllerLayoutDeviceScript> _controllers = new List<ControllerLayoutDeviceScript>();

		private List<string> _highlightedActionIds;

		private Dictionary<string, string> _namePrefabMap = new Dictionary<string, string>
		{
			{ "Oculus Touch Controller OpenXR", "Oculus" },
			{ "Index Controller OpenXR", "Index" },
			{ "HTC Vive Controller OpenXR", "ViveWand" },
			{ "Windows MR Controller OpenXR", "WMR" },
			{ "PicoXR Controller-Left", "PicoXR" },
			{ "PicoXR Controller-Right", "PicoXR" }
		};

		public IReadOnlyList<ControllerLayoutDeviceScript> Controllers => _controllers;

		public IReadOnlyList<string> HighlightedActionIds => _highlightedActionIds;

		public bool IsVisible { get; private set; }

		public void HideLayouts()
		{
			if (!IsVisible)
			{
				return;
			}
			IsVisible = false;
			foreach (ControllerLayoutDeviceScript controller in _controllers)
			{
				UnityEngine.Object.Destroy(controller.gameObject);
			}
			_controllers.Clear();
		}

		public void SetHighlightedActionId(string actionId, bool highlighted)
		{
			if (highlighted)
			{
				if (_highlightedActionIds.Contains(actionId))
				{
					return;
				}
				_highlightedActionIds.Add(actionId);
				{
					foreach (ControllerLayoutDeviceScript controller in _controllers)
					{
						controller.QueueRefresh();
					}
					return;
				}
			}
			_highlightedActionIds.Remove(actionId);
			foreach (ControllerLayoutDeviceScript controller2 in _controllers)
			{
				controller2.QueueRefresh();
			}
		}

		public void ShowLayouts()
		{
			if (IsVisible)
			{
				return;
			}
			IsVisible = true;
			string text = GetControllerPrefabName(XRInputs.PoseLeftHand.DevicePosition.activeControl?.device) ?? GetControllerPrefabName(XRInputs.PoseRightHand.DevicePosition.activeControl?.device);
			if (text == null)
			{
				Debug.LogWarning("Unable to determine controller type for binds, defaulting");
				text = _namePrefabMap.First().Value;
			}
			HandScriptBase[] componentsInChildren = base.gameObject.GetComponentsInChildren<HandScriptBase>(includeInactive: true);
			if (componentsInChildren.Length >= 2)
			{
				GameObject gameObject = UnityEngine.Object.Instantiate(Resources.Load("XR/Layouts/" + text)) as GameObject;
				ControllerLayoutDeviceScript[] componentsInChildren2 = gameObject.GetComponentsInChildren<ControllerLayoutDeviceScript>();
				foreach (ControllerLayoutDeviceScript controller in componentsInChildren2)
				{
					List<HandScriptBase> list = componentsInChildren.Where((HandScriptBase x) => x.HandType == controller.HandType).ToList();
					if (list.Count > 0)
					{
						HandScriptBase handScriptBase = list[0];
						controller.transform.SetParent(handScriptBase.transform, worldPositionStays: false);
						controller.transform.localPosition = Vector3.zero;
						controller.transform.localRotation = Quaternion.identity;
						controller.Initialize(this, new QueryInputAction(), list);
						_controllers.Add(controller);
					}
				}
				UnityEngine.Object.Destroy(gameObject);
			}
			else
			{
				Debug.LogError($"Not enough hands: {componentsInChildren.Length}");
			}
		}

		protected virtual void Awake()
		{
			_highlightedActionIds = new List<string>();
		}

		protected string GetControllerPrefabName(InputDevice device)
		{
			string text = device?.description.product;
			if (text != null && _namePrefabMap.TryGetValue(text, out var value))
			{
				return value;
			}
			return null;
		}

		protected virtual void Update()
		{
			if (UnityEngine.Input.GetKeyUp(KeyCode.U))
			{
				ShowLayouts();
			}
		}
	}
}
