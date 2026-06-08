using System;
using System.Collections.Generic;

namespace Kitchen
{
	[Serializable]
	public abstract class ResponsiveViewSystemBase<TView, TResp> : IncrementalViewSystemBase<TView>, IHandleStateUpdates where TView : IViewData, IViewData.ICheckForChanges<TView> where TResp : IResponseData
	{
		protected List<KeyValuePair<ViewIdentifier, TResp>> Updates = new List<KeyValuePair<ViewIdentifier, TResp>>();

		public Type HandleType => typeof(TResp);

		public void HandleStateUpdate(ViewIdentifier view_source, IResponseData status)
		{
			if (status is TResp value)
			{
				Updates.Add(new KeyValuePair<ViewIdentifier, TResp>(view_source, value));
			}
		}

		protected bool ApplyUpdates(ViewIdentifier identifier, Action<TResp> act, bool only_final_update = false)
		{
			bool result = false;
			for (int num = Updates.Count - 1; num >= 0; num--)
			{
				KeyValuePair<ViewIdentifier, TResp> keyValuePair = Updates[num];
				if (keyValuePair.Key == identifier)
				{
					act(keyValuePair.Value);
					result = true;
					if (only_final_update)
					{
						break;
					}
				}
			}
			ClearUpdates(identifier);
			return result;
		}

		protected void ClearUpdates()
		{
			Updates.Clear();
		}

		protected new void ClearUpdates(ViewIdentifier id)
		{
			Updates.RemoveAll((KeyValuePair<ViewIdentifier, TResp> i) => i.Key == id);
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
