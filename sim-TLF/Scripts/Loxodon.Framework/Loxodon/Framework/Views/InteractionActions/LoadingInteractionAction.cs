using System;
using System.Collections.Generic;
using Loxodon.Framework.Interactivity;

namespace Loxodon.Framework.Views.InteractionActions
{
	public class LoadingInteractionAction : InteractionActionBase<VisibilityNotification>
	{
		private List<Loading> list = new List<Loading>();

		public override void Action(VisibilityNotification notification, Action callback)
		{
			try
			{
				if (notification.Visible)
				{
					Loading loading = Loading.Show(ignoreAnimation: true);
					if (loading != null)
					{
						list.Insert(0, loading);
					}
				}
				else if (list.Count > 0)
				{
					Loading loading2 = list[0];
					list.RemoveAt(0);
					loading2.Dispose();
				}
			}
			finally
			{
				callback?.Invoke();
			}
		}
	}
}
