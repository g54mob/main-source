using System;
using System.Runtime.CompilerServices;
using UnityEngine.InputSystem;

namespace InputControl
{
	public class OverridePadInput : InputActionController.IUIControlActions
	{
		public event Action<InputAction.CallbackContext> Escape
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event Action<InputAction.CallbackContext> Reset
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event Action<InputAction.CallbackContext> MousePosition
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event Action<InputAction.CallbackContext> MouseScroll
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event Action<InputAction.CallbackContext> MouseLeftClick
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event Action<InputAction.CallbackContext> MouseRightClick
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event Action<InputAction.CallbackContext> Left
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event Action<InputAction.CallbackContext> Right
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event Action<InputAction.CallbackContext> Up
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event Action<InputAction.CallbackContext> Down
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event Action<InputAction.CallbackContext> Switch
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event Action<InputAction.CallbackContext> LeftTrigger
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event Action<InputAction.CallbackContext> RightTrigger
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event Action<InputAction.CallbackContext> Decide
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event Action<InputAction.CallbackContext> Cancel
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event Action<InputAction.CallbackContext> Select
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event Action<InputAction.CallbackContext> LeftShoulder
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event Action<InputAction.CallbackContext> RightShoulder
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event Action<InputAction.CallbackContext> SubMenu
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event Action<InputAction.CallbackContext> Start
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event Action<InputAction.CallbackContext> RightStickPush
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public void SetAction(PadInputSetting input)
		{
		}

		public void ResetEvent()
		{
		}

		private void ProcessInputAction(InputAction.CallbackContext context, Action<InputAction.CallbackContext> action)
		{
		}

		public void OnESC(InputAction.CallbackContext context)
		{
		}

		public virtual void OnReset(InputAction.CallbackContext context)
		{
		}

		public virtual void OnMousePosition(InputAction.CallbackContext context)
		{
		}

		public virtual void OnMouseScroll(InputAction.CallbackContext context)
		{
		}

		public virtual void OnMouseLeftClick(InputAction.CallbackContext context)
		{
		}

		public virtual void OnMouseRightClick(InputAction.CallbackContext context)
		{
		}

		public virtual void OnLeft(InputAction.CallbackContext context)
		{
		}

		public void OnSelect(InputAction.CallbackContext context)
		{
		}

		public void OnLeftShoulder(InputAction.CallbackContext context)
		{
		}

		public void OnRightShoulder(InputAction.CallbackContext context)
		{
		}

		public void OnSubMenu(InputAction.CallbackContext context)
		{
		}

		public void OnStart(InputAction.CallbackContext context)
		{
		}

		public void OnRightStickPush(InputAction.CallbackContext context)
		{
		}

		public virtual void OnRight(InputAction.CallbackContext context)
		{
		}

		public virtual void OnUp(InputAction.CallbackContext context)
		{
		}

		public virtual void OnDown(InputAction.CallbackContext context)
		{
		}

		public virtual void OnDecide(InputAction.CallbackContext context)
		{
		}

		public virtual void OnCancel(InputAction.CallbackContext context)
		{
		}

		public virtual void OnSwitch(InputAction.CallbackContext context)
		{
		}

		public virtual void OnLeftTrigger(InputAction.CallbackContext context)
		{
		}

		public virtual void OnRightTrigger(InputAction.CallbackContext context)
		{
		}
	}
}
