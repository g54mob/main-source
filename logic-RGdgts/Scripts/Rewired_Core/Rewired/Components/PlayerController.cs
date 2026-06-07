using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Rewired.Components
{
	[Serializable]
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
		[CustomObfuscation]
		[CustomClassObfuscation]
		internal sealed class ElementWithSourceInfo
		{
			[SerializeField]
			private string _name;

			[SerializeField]
			private Rewired.PlayerController.Element.TypeWithSource _elementType;

			[SerializeField]
			private bool _enabled;

			[SerializeField]
			private int _actionId;

			[SerializeField]
			private AxisCoordinateMode _coordinateMode;

			[SerializeField]
			private float _absoluteToRelativeSensitivity;

			[SerializeField]
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

			public Rewired.PlayerController.Element.Definition ToDefinition()
			{
				return null;
			}
		}

		[Serializable]
		[CustomObfuscation]
		[CustomClassObfuscation]
		internal sealed class ElementInfo
		{
			[SerializeField]
			private string _name;

			[SerializeField]
			private Rewired.PlayerController.Element.Type _elementType;

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

		[CustomObfuscation]
		[SerializeField]
		private InputManager_Base _rewiredInputManager;

		[SerializeField]
		[CustomObfuscation]
		private int _playerId;

		[CustomObfuscation]
		[SerializeField]
		private List<ElementInfo> _elements;

		[SerializeField]
		[CustomObfuscation]
		private ButtonStateChangedHandler _onButtonStateChanged;

		[SerializeField]
		[CustomObfuscation]
		private AxisValueChangedHandler _onAxisValueChanged;

		[CustomObfuscation]
		[SerializeField]
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

		internal virtual List<ElementInfo> KNoWOpeWgdlxCnBGGhQMtQLkTkVM()
		{
			return null;
		}

		private void KOpbSpxJyuGAzPcGwbIgHpZsVVLn(int P_0, bool P_1)
		{
		}

		private void lLFFKNPRhFapxntcuwlZTDsroWzC(int P_0, float P_1)
		{
		}

		private void UkLQAalAElxoMUHFoBNzzGhnVlsp(bool P_0)
		{
		}

		private void sxtSnKfDpcAAfEbOHFsQbecmqEcQA()
		{
		}
	}
}
