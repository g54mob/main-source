using System;
using System.Reflection;
using Assets.Scripts.Design.UI.PartProperties.Events;
using Jundroo.Juicy.Widgets;

namespace Assets.Scripts.Design.UI.PartProperties
{
	public interface IConfigurableProperty
	{
		int ChildIndex { get; }

		object CurrentFieldTarget { get; }

		MemberInfo Member { get; }

		IConfigurableProperty ParentProperty { get; }

		Widget RootWidget { get; }

		event EventHandler<ConfigurablePropertyChangedEventArgs> ValueChanged;

		event EventHandler<ConfigurablePropertyChangedEventArgs> ValueCommitted;

		string GetDefaultLabel();

		void RefreshUI();
	}
}
