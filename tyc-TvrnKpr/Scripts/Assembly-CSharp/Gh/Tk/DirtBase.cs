using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Gh.Tk
{
	public class DirtBase : GameObjectX
	{
		public static HashSet<DirtBase> AllDirt;

		public static event EventHandler<EventArgs<DirtBase>> DirtAdded
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public override void Start()
		{
		}

		public override void OnDestroy()
		{
		}

		protected void RaiseDirtAddedEvent()
		{
		}

		public void DecreaseFilth(float delta)
		{
		}

		protected void SetFlammability()
		{
		}

		public int GetAmountOfDirt()
		{
			return 0;
		}

		public override int SetErrorInfo(string errorKey, string errorMessageKey, string errorDetailKey, string icon, string backer = "thought", int priority = 5, float autoRemoveInSeconds = -1f, string alertType = "critical", float showAfterSeconds = 0f)
		{
			return 0;
		}
	}
}
