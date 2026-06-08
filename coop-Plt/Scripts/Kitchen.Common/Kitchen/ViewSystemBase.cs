using System;
using System.Collections.Generic;
using Unity.Entities;

namespace Kitchen
{
	[UpdateInGroup(typeof(ViewSystemsGroup))]
	public abstract class ViewSystemBase : GenericSystemBase
	{
		protected struct ViewUpdateIdentifier : IEquatable<ViewUpdateIdentifier>
		{
			public ViewIdentifier Identifier;

			public MessageType Type;

			public int Nonce;

			public ViewUpdateIdentifier(ViewIdentifier id, MessageType type, int nonce = 0)
			{
				Identifier = id;
				Type = type;
				Nonce = nonce;
			}

			public bool Equals(ViewUpdateIdentifier other)
			{
				if (Identifier.Equals(other.Identifier) && Type == other.Type)
				{
					return Nonce == other.Nonce;
				}
				return false;
			}

			public override bool Equals(object obj)
			{
				if (obj is ViewUpdateIdentifier other)
				{
					return Equals(other);
				}
				return false;
			}

			public override int GetHashCode()
			{
				return (int)(((uint)(Identifier.GetHashCode() * 397) ^ (uint)Type) * 397) ^ Nonce;
			}

			public static bool operator ==(ViewUpdateIdentifier left, ViewUpdateIdentifier right)
			{
				return left.Equals(right);
			}

			public static bool operator !=(ViewUpdateIdentifier left, ViewUpdateIdentifier right)
			{
				return !left.Equals(right);
			}
		}

		private List<ViewUpdateIdentifier> CachedToRemove = new List<ViewUpdateIdentifier>();

		protected Dictionary<ViewUpdateIdentifier, IViewData> PreviousUpdates = new Dictionary<ViewUpdateIdentifier, IViewData>();

		public void Rebroadcast(ViewIdentifier id)
		{
			foreach (KeyValuePair<ViewUpdateIdentifier, IViewData> previousUpdate in PreviousUpdates)
			{
				if (previousUpdate.Key.Type != MessageType.CreateView && previousUpdate.Key.Identifier == id)
				{
					base.Router.BroadcastUpdate(id, previousUpdate.Value, previousUpdate.Key.Type);
				}
			}
		}

		public virtual void ClearUpdates(ViewIdentifier id)
		{
			CachedToRemove.Clear();
			foreach (KeyValuePair<ViewUpdateIdentifier, IViewData> previousUpdate in PreviousUpdates)
			{
				if (previousUpdate.Key.Identifier == id)
				{
					CachedToRemove.Add(previousUpdate.Key);
				}
			}
			foreach (ViewUpdateIdentifier item in CachedToRemove)
			{
				PreviousUpdates.Remove(item);
			}
		}

		protected void SendUpdate<T>(ViewIdentifier id, T update, MessageType type = MessageType.ViewUpdate, int nonce = 0) where T : IViewData
		{
			type = DetermineType<T>(type);
			if (type == MessageType.DestroyView)
			{
				ClearUpdates(id);
			}
			else
			{
				PreviousUpdates[new ViewUpdateIdentifier(id, type, nonce)] = update;
			}
			base.Router?.BroadcastUpdate(id, update, type);
		}

		protected MessageType DetermineType<T>(MessageType base_type) where T : IViewData
		{
			if (base_type == MessageType.ViewUpdate && typeof(ISpecificViewData).IsAssignableFrom(typeof(T)))
			{
				return MessageType.SpecificViewUpdate;
			}
			return base_type;
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
