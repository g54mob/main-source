using System;
using MessagePack;
using UnityEngine;

namespace Controllers
{
	[Serializable]
	[MessagePackObject(false)]
	public struct InputState : IEquatable<InputState>
	{
		[Key(1)]
		public ButtonState InteractAction;

		[Key(2)]
		public ButtonState GrabAction;

		[Key(3)]
		public ButtonState SecondaryAction1;

		[Key(4)]
		public ButtonState SecondaryAction2;

		[Key(5)]
		public Vector2 Movement;

		[Key(6)]
		public ButtonState StopMoving;

		[Key(7)]
		public ButtonState MenuTrigger;

		[Key(8)]
		public ButtonState MenuUp;

		[Key(9)]
		public ButtonState MenuDown;

		[Key(10)]
		public ButtonState MenuLeft;

		[Key(11)]
		public ButtonState MenuRight;

		[Key(12)]
		public ButtonState MenuSelect;

		[Key(13)]
		public ButtonState MenuCancel;

		[Key(14)]
		public GameStateRequest Request;

		[IgnoreMember]
		public bool IsAdvancingMenu => MenuSelect == ButtonState.Pressed;

		[IgnoreMember]
		public bool IsCancellingMenu
		{
			get
			{
				if (MenuCancel != ButtonState.Pressed)
				{
					return MenuTrigger == ButtonState.Pressed;
				}
				return true;
			}
		}

		[IgnoreMember]
		public bool IsUnconsenting
		{
			get
			{
				if (InteractAction != ButtonState.Pressed && GrabAction != ButtonState.Pressed && SecondaryAction1 != ButtonState.Pressed && SecondaryAction2 != ButtonState.Pressed && MenuCancel != ButtonState.Pressed)
				{
					return MenuTrigger == ButtonState.Pressed;
				}
				return true;
			}
		}

		public static InputState Neutral => new InputState
		{
			InteractAction = ButtonState.Up,
			GrabAction = ButtonState.Up,
			SecondaryAction1 = ButtonState.Up,
			SecondaryAction2 = ButtonState.Up,
			MenuTrigger = ButtonState.Up,
			Movement = Vector2.zero,
			StopMoving = ButtonState.Up,
			MenuUp = ButtonState.Up,
			MenuDown = ButtonState.Up,
			MenuLeft = ButtonState.Up,
			MenuRight = ButtonState.Up,
			MenuSelect = ButtonState.Up,
			MenuCancel = ButtonState.Up
		};

		public static InputState Consumed => new InputState
		{
			InteractAction = ButtonState.Consumed,
			GrabAction = ButtonState.Consumed,
			SecondaryAction1 = ButtonState.Consumed,
			SecondaryAction2 = ButtonState.Consumed,
			MenuTrigger = ButtonState.Consumed,
			Movement = Vector2.zero,
			StopMoving = ButtonState.Consumed,
			MenuUp = ButtonState.Consumed,
			MenuDown = ButtonState.Consumed,
			MenuLeft = ButtonState.Consumed,
			MenuRight = ButtonState.Consumed,
			MenuSelect = ButtonState.Consumed,
			MenuCancel = ButtonState.Consumed
		};

		[IgnoreMember]
		public bool IsAnyButtonHeld
		{
			get
			{
				if (InteractAction != ButtonState.Held && GrabAction != ButtonState.Held && SecondaryAction1 != ButtonState.Held && SecondaryAction2 != ButtonState.Held && StopMoving != ButtonState.Held && MenuTrigger != ButtonState.Held && MenuUp != ButtonState.Held && MenuDown != ButtonState.Held && MenuLeft != ButtonState.Held && MenuRight != ButtonState.Held && MenuSelect != ButtonState.Held)
				{
					return MenuCancel == ButtonState.Held;
				}
				return true;
			}
		}

		[IgnoreMember]
		public bool IsAnyButtonHeldOrPressed
		{
			get
			{
				if (!IsAnyButtonHeld && InteractAction != ButtonState.Pressed && GrabAction != ButtonState.Pressed && SecondaryAction1 != ButtonState.Pressed && SecondaryAction2 != ButtonState.Pressed && StopMoving != ButtonState.Pressed && MenuTrigger != ButtonState.Pressed && MenuUp != ButtonState.Pressed && MenuDown != ButtonState.Pressed && MenuLeft != ButtonState.Pressed && MenuRight != ButtonState.Pressed && MenuSelect != ButtonState.Pressed)
				{
					return MenuCancel == ButtonState.Pressed;
				}
				return true;
			}
		}

		public InputState ApplyUpdatedState(InputState update, bool is_aggregation = false)
		{
			return new InputState
			{
				InteractAction = CombineButtonState(InteractAction, update.InteractAction, is_aggregation),
				GrabAction = CombineButtonState(GrabAction, update.GrabAction, is_aggregation),
				SecondaryAction1 = CombineButtonState(SecondaryAction1, update.SecondaryAction1, is_aggregation),
				SecondaryAction2 = CombineButtonState(SecondaryAction2, update.SecondaryAction2, is_aggregation),
				MenuTrigger = CombineButtonState(MenuTrigger, update.MenuTrigger, is_aggregation),
				Movement = update.Movement,
				StopMoving = CombineButtonState(StopMoving, update.StopMoving, is_aggregation),
				MenuUp = CombineButtonState(MenuUp, update.MenuUp, is_aggregation),
				MenuDown = CombineButtonState(MenuDown, update.MenuDown, is_aggregation),
				MenuLeft = CombineButtonState(MenuLeft, update.MenuLeft, is_aggregation),
				MenuRight = CombineButtonState(MenuRight, update.MenuRight, is_aggregation),
				MenuSelect = CombineButtonState(MenuSelect, update.MenuSelect, is_aggregation),
				MenuCancel = CombineButtonState(MenuCancel, update.MenuCancel, is_aggregation),
				Request = CombineRequests(Request, update.Request, is_aggregation)
			};
		}

		private GameStateRequest CombineRequests(GameStateRequest prev, GameStateRequest next, bool is_aggregation = false)
		{
			if (prev == GameStateRequest.None && next == GameStateRequest.None)
			{
				return GameStateRequest.None;
			}
			if (is_aggregation)
			{
				return (GameStateRequest)Mathf.Max((int)prev, (int)next);
			}
			return next;
		}

		private ButtonState CombineButtonState(ButtonState prev, ButtonState next, bool is_aggregation = false)
		{
			bool flag = next == ButtonState.Held || next == ButtonState.Pressed;
			bool flag2 = prev == ButtonState.Held || prev == ButtonState.Pressed;
			if (prev == ButtonState.Consumed)
			{
				if (flag)
				{
					return ButtonState.Consumed;
				}
				return ButtonState.Up;
			}
			if (is_aggregation)
			{
				if (!(flag || flag2))
				{
					return ButtonState.Up;
				}
				return ButtonState.Held;
			}
			if (flag)
			{
				if (!flag2)
				{
					return ButtonState.Pressed;
				}
				return ButtonState.Held;
			}
			if (!flag2)
			{
				return ButtonState.Up;
			}
			return ButtonState.Released;
		}

		public bool ApproximatelyEqual(InputState other)
		{
			if (InteractAction == other.InteractAction && GrabAction == other.GrabAction && SecondaryAction1 == other.SecondaryAction1 && SecondaryAction2 == other.SecondaryAction2 && Mathf.Abs(Movement.x - other.Movement.x) < 0.01f && Mathf.Abs(Movement.y - other.Movement.y) < 0.01f && MenuTrigger == other.MenuTrigger && StopMoving == other.StopMoving && MenuUp == other.MenuUp && MenuDown == other.MenuDown && MenuLeft == other.MenuLeft && MenuRight == other.MenuRight && MenuSelect == other.MenuSelect && MenuCancel == other.MenuCancel)
			{
				return Request == other.Request;
			}
			return false;
		}

		public bool Equals(InputState other)
		{
			if (InteractAction == other.InteractAction && GrabAction == other.GrabAction && SecondaryAction1 == other.SecondaryAction1 && SecondaryAction2 == other.SecondaryAction2 && Mathf.Approximately(Movement.x, other.Movement.x) && Mathf.Approximately(Movement.y, other.Movement.y) && MenuTrigger == other.MenuTrigger && StopMoving == other.StopMoving && MenuUp == other.MenuUp && MenuDown == other.MenuDown && MenuLeft == other.MenuLeft && MenuRight == other.MenuRight && MenuSelect == other.MenuSelect && MenuCancel == other.MenuCancel)
			{
				return Request == other.Request;
			}
			return false;
		}

		public override bool Equals(object obj)
		{
			if (obj is InputState other)
			{
				return Equals(other);
			}
			return false;
		}

		public override int GetHashCode()
		{
			return (int)(((((((((((((((((((((((((uint)((int)InteractAction * 397) ^ (uint)GrabAction) * 397) ^ (uint)SecondaryAction1) * 397) ^ (uint)SecondaryAction2) * 397) ^ (uint)Movement.GetHashCode()) * 397) ^ (uint)StopMoving) * 397) ^ (uint)MenuTrigger) * 397) ^ (uint)MenuUp) * 397) ^ (uint)MenuDown) * 397) ^ (uint)MenuLeft) * 397) ^ (uint)MenuRight) * 397) ^ (uint)MenuSelect) * 397) ^ (uint)MenuCancel) * 397) ^ (int)Request;
		}

		public static bool operator ==(InputState left, InputState right)
		{
			return left.Equals(right);
		}

		public static bool operator !=(InputState left, InputState right)
		{
			return !left.Equals(right);
		}
	}
}
