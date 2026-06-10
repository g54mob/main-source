using UnityEngine;

namespace NSMedieval.Components
{
	public abstract class InputListener
	{
		private bool isEnabled;

		private InputListenerType type;

		public InputListenerType Type => type;

		public bool IsEnabled => isEnabled;

		public bool WasEnabled { get; set; }

		protected InputListener(InputListenerType type)
		{
			isEnabled = true;
			this.type = type;
		}

		public virtual void OnAdded()
		{
		}

		public virtual void OnRemoved()
		{
		}

		public virtual void Update()
		{
		}

		public virtual void BlockedUpdate()
		{
		}

		public virtual void Begin()
		{
		}

		public virtual void BeginDisabled()
		{
		}

		public virtual void MouseButtonDown(int button, Vector3 position)
		{
		}

		public virtual void MouseButtonTick(int button, Vector3 position)
		{
		}

		public virtual void MouseButtonUp(int button, Vector3 position)
		{
		}

		public virtual void MouseFullClick(int button, Vector3 position)
		{
		}

		public virtual void KeyDown(KeyCode key)
		{
		}

		public virtual void KeyDownTick(KeyCode key)
		{
		}

		public virtual void KeyUp(KeyCode key)
		{
		}

		public virtual bool IsStopEventPropagation()
		{
			return false;
		}

		public virtual void Disable()
		{
			isEnabled = false;
		}

		public virtual void Enable()
		{
			isEnabled = true;
			WasEnabled = true;
		}

		public virtual void Dispose()
		{
		}
	}
}
