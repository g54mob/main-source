using System;
using Noesis;
using NoesisApp;

namespace NoesisGUIExtensions
{
	public class GamepadTrigger : TriggerBase<UIElement>
	{
		public static readonly DependencyProperty ButtonProperty;

		public static readonly DependencyProperty ActiveOnFocusProperty;

		public static readonly DependencyProperty FiredOnProperty;

		private IntPtr _source;

		public GamepadButton Button
		{
			get
			{
				return default(GamepadButton);
			}
			set
			{
			}
		}

		public bool ActiveOnFocus
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public GamepadTriggerFiredOn FiredOn
		{
			get
			{
				return default(GamepadTriggerFiredOn);
			}
			set
			{
			}
		}

		public new GamepadTrigger Clone()
		{
			return null;
		}

		public new GamepadTrigger CloneCurrentValue()
		{
			return null;
		}

		private static void OnActiveOnFocusChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
		}

		private static void OnFiredOnChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
		}

		protected override void OnAttached()
		{
		}

		protected override void OnDetaching()
		{
		}

		private void OnButtonPress(object sender, KeyEventArgs e)
		{
		}

		private void RegisterSource()
		{
		}

		private void UnregisterSource(GamepadTriggerFiredOn firedOn)
		{
		}

		private void OnSourceDestroyed(IntPtr d)
		{
		}

		private UIElement GetRoot(Visual current)
		{
			return null;
		}
	}
}
