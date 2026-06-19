using System;
using JetBrains.Annotations;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public abstract class HoverMenuBase : InWorldMenuObject
	{
		protected override void Setup(ICursorSelectable objectSelected, Level level)
		{
			base.Setup(objectSelected, level);
			BuildEvents buildEvents = base.Level.BuildEvents;
			buildEvents.OnCursorHoverStop = (Action<ICursorSelectable>)Delegate.Combine(buildEvents.OnCursorHoverStop, new Action<ICursorSelectable>(OnCursorHoverStop));
		}

		public override void Destroy()
		{
			base.Destroy();
			BuildEvents buildEvents = base.Level.BuildEvents;
			buildEvents.OnCursorHoverStop = (Action<ICursorSelectable>)Delegate.Remove(buildEvents.OnCursorHoverStop, new Action<ICursorSelectable>(OnCursorHoverStop));
		}

		private void OnCursorHoverStop(ICursorSelectable cursorSelectable)
		{
			if (cursorSelectable == base.ObjectSelected)
			{
				CloseMenu();
			}
		}
	}
}
