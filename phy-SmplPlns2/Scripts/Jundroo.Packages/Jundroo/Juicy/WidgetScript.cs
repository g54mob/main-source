using Jundroo.Juicy.Widgets;
using UnityEngine;

namespace Jundroo.Juicy
{
	public class WidgetScript : MonoBehaviour, IWidgetScript
	{
		public virtual bool HandleChildEvents => true;

		public Widget Widget { get; private set; }

		public virtual void OnWidgetInitialized(Widget widget)
		{
			Widget = widget;
		}
	}
}
