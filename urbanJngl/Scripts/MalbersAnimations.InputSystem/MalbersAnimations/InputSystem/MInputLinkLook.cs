using MalbersAnimations.Events;
using MalbersAnimations.Scriptables;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Users;

namespace MalbersAnimations.InputSystem
{
	[AddComponentMenu("Malbers/Input/MInput Look")]
	public class MInputLinkLook : MonoBehaviour
	{
		[Tooltip("Leave this at -1 for single-player games.  For multi-player games, set this to be the player index, and the actions will be read from that player's controls")]
		public int PlayerIndex = -1;

		[Tooltip("If set, Input Actions will be auto-enabled at start")]
		public bool AutoEnableInputs = true;

		[Tooltip("Vector2 action for XY movement")]
		public InputActionReference LookAxis;

		[Tooltip("Float action for Z movement")]
		public InputActionReference Zoom;

		[Tooltip("Camera Input Values (Look X:Horizontal, Look Y: Vertical)")]
		public Vector2Reference look = new Vector2Reference();

		[Tooltip("Camera Input Values (Look X:Horizontal, Look Y: Vertical)")]
		public BoolReference IgnoreOnPause = new BoolReference();

		public Vector2Event OnLookValue = new Vector2Event();

		public FloatEvent OnZoomValue = new FloatEvent();

		private InputAction m_cachedLook;

		private InputAction m_cachedZoom;

		private InputAction lookXY;

		private InputAction zoom;

		protected InputAction ResolveForPlayer(InputAction cache, InputActionReference actionRef)
		{
			if (actionRef == null || actionRef.action == null)
			{
				return null;
			}
			if (cache != null && actionRef.action.id != cache.id)
			{
				cache = null;
			}
			if (cache == null)
			{
				cache = actionRef.action;
				if (PlayerIndex != -1 && InputUser.all.Count > 0)
				{
					cache = GetFirstMatch(InputUser.all[PlayerIndex], actionRef);
				}
				if (AutoEnableInputs && actionRef != null && actionRef.action != null)
				{
					actionRef.action.Enable();
				}
			}
			if (cache != null && cache.enabled != actionRef.action.enabled)
			{
				if (actionRef.action.enabled)
				{
					cache.Enable();
				}
				else
				{
					cache.Disable();
				}
			}
			return cache;
			InputAction GetFirstMatch(in InputUser user, InputActionReference aRef)
			{
				foreach (InputAction action in user.actions)
				{
					if (action.id == aRef.action.id)
					{
						return action;
					}
				}
				Debug.LogWarning("Action Reference [" + aRef.action.name + "] Not Found. Make sure the Player is Using the Same Action MAP", this);
				return null;
			}
		}

		public void OnEnable()
		{
			PlayerInput componentInParent = GetComponentInParent<PlayerInput>();
			if (componentInParent != null)
			{
				PlayerIndex = componentInParent.playerIndex;
			}
			else if (PlayerIndex == -1)
			{
				PlayerIndex = 0;
			}
			lookXY = ResolveForPlayer(m_cachedLook, LookAxis);
			zoom = ResolveForPlayer(m_cachedZoom, Zoom);
			if (lookXY != null)
			{
				lookXY.performed += ReadLook;
				lookXY.canceled += ReadLook;
			}
			if (zoom != null)
			{
				zoom.performed += ReadZoom;
			}
		}

		protected virtual void OnDisable()
		{
			if (lookXY != null)
			{
				lookXY.performed -= ReadLook;
				lookXY.canceled -= ReadLook;
			}
			if (zoom != null)
			{
				zoom.performed -= ReadZoom;
			}
			m_cachedLook = null;
			m_cachedZoom = null;
		}

		private void ReadLook(InputAction.CallbackContext context)
		{
			look.Value = Vector2.zero;
			if (!IgnoreOnPause || Time.timeScale != 0f)
			{
				look.Value = context.ReadValue<Vector2>();
			}
			OnLookValue.Invoke(look.Value);
		}

		private void ReadZoom(InputAction.CallbackContext context)
		{
			float num = 0f;
			if (!IgnoreOnPause || (Time.timeScale != 0f && context.valueType == typeof(Vector2)))
			{
				num = context.ReadValue<Vector2>().y;
			}
			if (num != 0f)
			{
				OnZoomValue.Invoke(num);
			}
		}

		public void SetPlayerIndex(int index)
		{
			PlayerIndex = index;
			OnDisable();
			OnEnable();
		}
	}
}
