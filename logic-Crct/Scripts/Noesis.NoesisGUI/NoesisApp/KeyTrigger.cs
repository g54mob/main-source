using System;
using Noesis;

namespace NoesisApp
{
	public class KeyTrigger : TriggerBase<UIElement>
	{
		public static readonly DependencyProperty KeyProperty;

		public static readonly DependencyProperty ModifiersProperty;

		public static readonly DependencyProperty ActiveOnFocusProperty;

		public static readonly DependencyProperty FiredOnProperty;

		private IntPtr _source;

		public Key Key
		{
			get
			{
				return default(Key);
			}
			set
			{
			}
		}

		public ModifierKeys Modifiers
		{
			get
			{
				return default(ModifierKeys);
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

		public KeyTriggerFiredOn FiredOn
		{
			get
			{
				return default(KeyTriggerFiredOn);
			}
			set
			{
			}
		}

		public new KeyTrigger Clone()
		{
			return null;
		}

		public new KeyTrigger CloneCurrentValue()
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

		private void OnKeyPress(object sender, KeyEventArgs e)
		{
		}

		private void RegisterSource()
		{
		}

		private void UnregisterSource(KeyTriggerFiredOn firedOn)
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
