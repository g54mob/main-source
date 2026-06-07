using UnityEngine;

namespace com.ootii.Input
{
	[AddComponentMenu("ootii/Input Sources/Unity Input Source")]
	public class UnityInputSource : MonoBehaviour, IInputSource, IViewActivator
	{
		[Tooltip("Determines if we'll get input from the mouse, keyboard, and gamepad.")]
		public bool _IsEnabled;

		[Tooltip("Determines we can use the Xbox controller for input.")]
		public bool _IsXboxControllerEnabled;

		[Tooltip("Determines what button enables viewing.")]
		public int _ViewActivator;

		public virtual bool IsEnabled
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public virtual bool IsXboxControllerEnabled => false;

		public virtual float InputFromCameraAngle
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public virtual float InputFromAvatarAngle
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public virtual float MovementX => 0f;

		public virtual float MovementY => 0f;

		public virtual float MovementSqr => 0f;

		public virtual float ViewX => 0f;

		public virtual float ViewY => 0f;

		public virtual bool IsViewingActivated => false;

		public int ViewActivator
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public virtual bool IsJustPressed(KeyCode rKey)
		{
			return false;
		}

		public virtual bool IsJustPressed(int rKey)
		{
			return false;
		}

		public virtual bool IsJustPressed(string rAction)
		{
			return false;
		}

		public virtual bool IsPressed(KeyCode rKey)
		{
			return false;
		}

		public virtual bool IsPressed(int rKey)
		{
			return false;
		}

		public virtual bool IsPressed(string rAction)
		{
			return false;
		}

		public virtual bool IsJustReleased(KeyCode rKey)
		{
			return false;
		}

		public virtual bool IsJustReleased(int rKey)
		{
			return false;
		}

		public virtual bool IsJustReleased(string rAction)
		{
			return false;
		}

		public virtual bool IsReleased(KeyCode rKey)
		{
			return false;
		}

		public virtual bool IsReleased(int rKey)
		{
			return false;
		}

		public virtual bool IsReleased(string rAction)
		{
			return false;
		}

		public virtual float GetValue(int rKey)
		{
			return 0f;
		}

		public virtual float GetValue(string rAction)
		{
			return 0f;
		}
	}
}
