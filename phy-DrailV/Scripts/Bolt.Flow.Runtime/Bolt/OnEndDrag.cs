using System;
using Ludiq;

namespace Bolt
{
	[UnitCategory("Events/GUI")]
	[TypeIcon(typeof(OnDrag))]
	[UnitOrder(18)]
	public sealed class OnEndDrag : PointerEventUnit
	{
		public override Type MessageListenerType => typeof(UnityOnEndDragMessageListener);

		protected override string hookName => "OnEndDrag";
	}
}
