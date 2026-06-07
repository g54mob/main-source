using System;
using Doozy.Engine.UI.Base;

namespace Doozy.Engine.UI
{
	[Serializable]
	public class UIDrawerBehavior
	{
		public UIDrawerBehaviorType DrawerBehaviorType;

		public UIAction OnFinished;

		public UIAction OnStart;

		public bool HasAnimatorEvents => false;

		public bool HasEffect => false;

		public bool HasGameEvents => false;

		public bool HasSound => false;

		public bool HasUnityEvents => false;

		public UIDrawerBehavior(UIDrawerBehaviorType behaviorType)
		{
		}

		public void Reset(UIDrawerBehaviorType behaviorType)
		{
		}
	}
}
