namespace Kitchen
{
	public abstract class IncrementalViewSystemBase<T> : ViewSystemBase where T : IViewData, IViewData.ICheckForChanges<T>
	{
		protected virtual void SendUpdate(ViewIdentifier id, T update, MessageType type = MessageType.ViewUpdate, int nonce = 0)
		{
			type = DetermineType<T>(type);
			ViewUpdateIdentifier key = new ViewUpdateIdentifier(id, type, nonce);
			if (!PreviousUpdates.TryGetValue(key, out var value) || !(value is T val) || val.IsChangedFrom(update))
			{
				base.SendUpdate(id, update, type, nonce);
			}
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
