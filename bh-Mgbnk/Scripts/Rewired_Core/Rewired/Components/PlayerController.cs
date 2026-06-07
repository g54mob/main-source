using System;
using System.Collections.Generic;
using Rewired.Utils.Attributes;
using UnityEngine;
using UnityEngine.Events;

namespace Rewired.Components
{
	[Serializable]
	[AddComponentMenu("Rewired/Player Controllers/Player Controller")]
	public class PlayerController : ComponentWrapper<Rewired.PlayerController>, IPlayerController
	{
		[Serializable]
		public class ButtonStateChangedHandler : UnityEvent<int, bool>
		{
		}

		[Serializable]
		public class AxisValueChangedHandler : UnityEvent<int, float>
		{
		}

		[Serializable]
		public class EnabledStateChangedHandler : UnityEvent<bool>
		{
		}

		[Serializable]
		[CustomObfuscation(rename = false)]
		[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = false)]
		internal class ElementWithSourceInfo
		{
			[Tooltip("The name of the element.")]
			[SerializeField]
			private string _name;

			[Tooltip("The element type.")]
			[SerializeField]
			private Rewired.PlayerController.Element.TypeWithSource _elementType;

			[Tooltip("Is this element enabled? Disabled elements return no value.")]
			[SerializeField]
			private bool _enabled;

			[Tooltip("The Action id of the Action which will be used as the input source for the Element.")]
			[SerializeField]
			private int _actionId;

			[Tooltip("The output coordinate mode of the axis. An Absolute axis will only return value for input received from Absolute sources. A Relative axis will return value for input received from both Relative and Absolute sources. When converting from an Absolute input source to a Relative output, absoluteToRelativeSensitivity will be multiplied by the Absolute value to yield a simulated Relative value.")]
			[SerializeField]
			private AxisCoordinateMode _coordinateMode;

			[Tooltip("The absolute to relative sensitivity multiplier for axes. This is only applied when the axis coordinate mode is set to Relative and the axis receives Absolute coordinate mode input (joystick axes, keyboard keys, etc.). This is equivalent to pixels per second on a 1920x1080 screen. The final result can also be affected by Absolute To Relative Scaling Mode, and, for a mouse, Pointer Speed.")]
			[SerializeField]
			[FieldRange(0f, 3.4028235E+38f)]
			private float _absoluteToRelativeSensitivity;

			[Tooltip("Determines how a relative axis value will be scaled when controlled by an absolute axis (eg: a joystick). This can be used to scale axis value based on screen or viewport resolution. This is used for scaling mouse pointer speed. Set PlayerController.absoluteToRelativeScalingReferenceResolution to use a custom scaling reference resolution.")]
			[SerializeField]
			private Rewired.PlayerController.AbsoluteToRelativeScalingMode _absoluteToRelativeScalingMode;

			[Tooltip("The number of times per second the wheel ticks when the value source is an absolute axis value.")]
			[SerializeField]
			[FieldRange(0f, 3.4028235E+38f)]
			private float _repeatRate;

			public string name
			{
				get
				{
					return null;
				}
				set
				{
				}
			}

			public Rewired.PlayerController.Element.TypeWithSource elementType
			{
				get
				{
					return default(Rewired.PlayerController.Element.TypeWithSource);
				}
				set
				{
				}
			}

			public bool enabled
			{
				get
				{
					return false;
				}
				set
				{
				}
			}

			public int actionId
			{
				get
				{
					return 0;
				}
				set
				{
				}
			}

			public AxisCoordinateMode coordinateMode
			{
				get
				{
					return default(AxisCoordinateMode);
				}
				set
				{
				}
			}

			public float absoluteSourceSensitivity
			{
				get
				{
					return 0f;
				}
				set
				{
				}
			}

			public Rewired.PlayerController.AbsoluteToRelativeScalingMode absoluteToRelativeScalingMode
			{
				get
				{
					return default(Rewired.PlayerController.AbsoluteToRelativeScalingMode);
				}
				set
				{
				}
			}

			public float repeatRate
			{
				get
				{
					return 0f;
				}
				set
				{
				}
			}

			[Preserve]
			public ElementWithSourceInfo()
			{
			}

			public Rewired.PlayerController.Element.Definition ToDefinition()
			{
				return null;
			}

			internal static ElementWithSourceInfo Create()
			{
				return null;
			}
		}

		[Serializable]
		[CustomObfuscation(rename = false)]
		[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = false)]
		internal sealed class ElementWithSourceInfoCreator : ElementWithSourceInfo
		{
		}

		[Serializable]
		[CustomObfuscation(rename = false)]
		[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = false)]
		internal sealed class ElementInfo
		{
			[Tooltip("The name of the element.")]
			[SerializeField]
			private string _name;

			[Tooltip("The element type.")]
			[SerializeField]
			private Rewired.PlayerController.Element.Type _elementType;

			[Tooltip("Is this element enabled? Disabled elements return no value.")]
			[SerializeField]
			private bool _enabled;

			[SerializeField]
			private ElementWithSourceInfo[] _elements;

			public string name
			{
				get
				{
					return null;
				}
				set
				{
				}
			}

			public Rewired.PlayerController.Element.Type elementType
			{
				get
				{
					return default(Rewired.PlayerController.Element.Type);
				}
				set
				{
				}
			}

			public bool enabled
			{
				get
				{
					return false;
				}
				set
				{
				}
			}

			public ElementWithSourceInfo[] elements
			{
				get
				{
					return null;
				}
				set
				{
				}
			}

			public Rewired.PlayerController.Element.Definition ToDefinition()
			{
				return null;
			}
		}

		[Tooltip("(Optional) Link the Rewired Input Manager here for easier access to Action ids, Player ids, etc.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private InputManager_Base _rewiredInputManager;

		[Tooltip("The Player id of the Player used for the source of input.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private int _playerId;

		[Tooltip("The elements that will be created in the controller.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private List<ElementInfo> _elements;

		[Tooltip("Triggered the first frame the button is pressed or released.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private ButtonStateChangedHandler _onButtonStateChanged;

		[Tooltip("Triggered when the axis value changes.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private AxisValueChangedHandler _onAxisValueChanged;

		[Tooltip("Triggered when the controller is enabled or disabled.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private EnabledStateChangedHandler _onEnabledStateChanged;

		public int playerId
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public IList<Rewired.PlayerController.Button> buttons => null;

		public IList<Rewired.PlayerController.Axis> axes => null;

		public IList<Rewired.PlayerController.Element> elements => null;

		public int buttonCount => 0;

		public int axisCount => 0;

		public int elementCount => 0;

		bool IPlayerController.enabled
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public event Action<int, bool> ButtonStateChangedEvent
		{
			add
			{
			}
			remove
			{
			}
		}

		public event Action<int, float> AxisValueChangedEvent
		{
			add
			{
			}
			remove
			{
			}
		}

		public event Action<bool> EnabledStateChangedEvent
		{
			add
			{
			}
			remove
			{
			}
		}

		public bool GetButton(int index)
		{
			return false;
		}

		public bool GetButtonDown(int index)
		{
			return false;
		}

		public bool GetButtonUp(int index)
		{
			return false;
		}

		public float GetAxis(int index)
		{
			return 0f;
		}

		public float GetAxisRaw(int index)
		{
			return 0f;
		}

		public Rewired.PlayerController.Element GetElement(int index)
		{
			return null;
		}

		public T GetElement<T>(int index) where T : Rewired.PlayerController.Element
		{
			return null;
		}

		protected override void OnAwake()
		{
		}

		protected override void OnAwakeFinished()
		{
		}

		protected override void OnEnabled()
		{
		}

		protected override void OnDisabled()
		{
		}

		protected override void OnValidated()
		{
		}

		protected override void OnReset()
		{
		}

		protected override void Subscribe()
		{
		}

		protected override void Unsubscribe()
		{
		}

		protected override object GetCreateSourceArgs()
		{
			return null;
		}

		protected override Rewired.PlayerController CreateSource(object args)
		{
			return null;
		}

		internal virtual List<ElementInfo> kZPfxafqEeLOrsiTlcYkCgviCAklA()
		{
			return null;
		}

		private void iluugqXajasbWDEpxzywVYQksKTV(int P_0, bool P_1)
		{
		}

		private void BFVAzpJNSUjfRHEzFapXbMNZriet(int P_0, float P_1)
		{
		}

		private void iPZNJZGqhHfQcaZDGKkJcSQBMinIA(bool P_0)
		{
		}

		private void oMVKlsfAxWCvYEtuxGVZcVvIPOYEA()
		{
		}
	}
}
