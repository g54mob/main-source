using System.Collections.Generic;
using DV.CabControls;
using DV.Utils;
using UnityEngine;

namespace DV.Items.Brick
{
	public class BrickInput : MonoBehaviour
	{
		public delegate void InputActionDelegate(BrickInputAction action);

		public enum BrickInputAction
		{
			None = 0,
			Up = 1,
			Down = 2,
			Left = 3,
			Right = 4,
			PowerOn = 5,
			PowerOff = 6,
			Pause = 7,
			Resume = 8,
			Restart = 9
		}

		public enum BrickButton
		{
			Power = 0,
			A = 1,
			B = 2
		}

		[SerializeField]
		private GameObject buttonPowerGO;

		[SerializeField]
		private GameObject buttonUpGO;

		[SerializeField]
		private GameObject buttonDownGO;

		private ButtonBase buttonPower;

		private ButtonBase buttonUp;

		private ButtonBase buttonDown;

		private ItemScrolling itemScrolling;

		private ItemBase item;

		private Dictionary<ScrollAction, BrickButton> scrollActionToBrickInputAction = new Dictionary<ScrollAction, BrickButton>
		{
			{
				ScrollAction.ScrollUp,
				BrickButton.A
			},
			{
				ScrollAction.ScrollRight,
				BrickButton.A
			},
			{
				ScrollAction.ScrollDown,
				BrickButton.B
			},
			{
				ScrollAction.ScrollLeft,
				BrickButton.B
			}
		};

		public event InputActionDelegate InputAction;

		private void Start()
		{
			buttonPower = ((buttonPowerGO != null) ? buttonPowerGO.GetComponent<ButtonBase>() : null);
			buttonUp = ((buttonUpGO != null) ? buttonUpGO.GetComponent<ButtonBase>() : null);
			buttonDown = ((buttonDownGO != null) ? buttonDownGO.GetComponent<ButtonBase>() : null);
			if (buttonPower == null || buttonUp == null || buttonDown == null)
			{
				Debug.LogError("BrickInput: At least one of the buttons has an invalid reference!. Brick got bricked!");
				return;
			}
			item = GetComponent<ItemBase>();
			if (item == null)
			{
				Debug.LogError("BrickInput: Invalid ItemBase reference!. Brick got bricked!");
				return;
			}
			if (VRManager.IsVREnabled())
			{
				ItemScrollingVR itemScrollingVR = base.gameObject.AddComponent<ItemScrollingVR>();
				itemScrollingVR.ignoreUseRestriction = true;
				itemScrolling = itemScrollingVR;
			}
			else
			{
				itemScrolling = base.gameObject.AddComponent<ItemScrollingNonVR>();
			}
			SetupListeners(on: true);
		}

		private void OnDestroy()
		{
			if (!UnloadWatcher.isUnloading)
			{
				SetupListeners(on: false);
			}
		}

		private void SetupListeners(bool on)
		{
			if (on)
			{
				if (itemScrolling != null)
				{
					itemScrolling.Scrolled += OnScrolled;
				}
				if (item != null)
				{
					item.Used += OnItemUsed;
				}
				if (buttonPower != null)
				{
					buttonPower.Used += OnPowerButtonPressed;
				}
				if (buttonUp != null)
				{
					buttonUp.Used += OnUpButtonPressed;
				}
				if (buttonDown != null)
				{
					buttonDown.Used += OnDownButtonPressed;
				}
				SingletonBehaviour<AppUtil>.Instance.GamePauseRequested += OnGamePaused;
				SingletonBehaviour<AppUtil>.Instance.GameUnpaused += OnGameUnpaused;
			}
			else
			{
				if (itemScrolling != null)
				{
					itemScrolling.Scrolled -= OnScrolled;
				}
				if (item != null)
				{
					item.Used -= OnItemUsed;
				}
				if (buttonPower != null)
				{
					buttonPower.Used -= OnPowerButtonPressed;
				}
				if (buttonUp != null)
				{
					buttonUp.Used -= OnUpButtonPressed;
				}
				if (buttonDown != null)
				{
					buttonDown.Used -= OnDownButtonPressed;
				}
				SingletonBehaviour<AppUtil>.Instance.GamePauseRequested -= OnGamePaused;
				SingletonBehaviour<AppUtil>.Instance.GameUnpaused -= OnGameUnpaused;
			}
		}

		private void OnGamePaused()
		{
			this.InputAction?.Invoke(BrickInputAction.Pause);
		}

		private void OnGameUnpaused()
		{
			this.InputAction?.Invoke(BrickInputAction.Resume);
		}

		private void OnItemUsed()
		{
			if (!(buttonPower == null))
			{
				if (buttonPower.IsOn)
				{
					this.InputAction?.Invoke(BrickInputAction.Restart);
				}
				else
				{
					buttonPower.Use();
				}
			}
		}

		private void OnScrolled(ScrollAction action)
		{
			if (!scrollActionToBrickInputAction.TryGetValue(action, out var value))
			{
				Debug.LogError(string.Format("Unrecognized {0}: {1}. Brick got bricked!", "ScrollAction", action));
			}
			else
			{
				ForceButtonPress(value);
			}
		}

		private void OnPowerButtonPressed()
		{
			bool flag = buttonPower != null && buttonPower.IsOn;
			this.InputAction?.Invoke(flag ? BrickInputAction.PowerOff : BrickInputAction.PowerOn);
		}

		private void OnUpButtonPressed()
		{
			this.InputAction?.Invoke(BrickInputAction.Up);
		}

		private void OnDownButtonPressed()
		{
			this.InputAction?.Invoke(BrickInputAction.Down);
		}

		public void ForceButtonPress(BrickButton button)
		{
			switch (button)
			{
			case BrickButton.Power:
				if (buttonPower != null)
				{
					buttonPower.Use();
				}
				break;
			case BrickButton.A:
				if (buttonUp != null)
				{
					buttonUp.Use();
				}
				break;
			case BrickButton.B:
				if (buttonDown != null)
				{
					buttonDown.Use();
				}
				break;
			}
		}
	}
}
