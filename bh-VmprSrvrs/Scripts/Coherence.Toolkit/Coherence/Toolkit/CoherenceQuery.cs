using System.Runtime.CompilerServices;
using Coherence.Connection;
using Coherence.Entities;
using Coherence.Log;

namespace Coherence.Toolkit
{
	[NonBindable]
	public abstract class CoherenceQuery : CoherenceBehaviour
	{
		protected CoherenceBridge bridge;

		public Entity EntityID { get; set; }

		protected IClient Client => null;

		protected Logger Logger { get; private set; }

		protected bool IsConnected => false;

		protected abstract bool NeedsUpdate { get; }

		public event CoherenceBridgeResolver<CoherenceQuery> BridgeResolve
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

		private void Start()
		{
		}

		private void OnConnected(CoherenceBridge _)
		{
		}

		private void OnDisconnected(CoherenceBridge _, ConnectionCloseReason __)
		{
		}

		private void Update()
		{
		}

		private void OnEnable()
		{
		}

		private void OnDisable()
		{
		}

		private void OnDestroy()
		{
		}

		private void OnFloatingOriginShiftedInternal(FloatingOriginShiftArgs args)
		{
		}

		protected virtual void OnFloatingOriginShifted(FloatingOriginShiftArgs args)
		{
		}

		protected abstract void CreateQuery();

		protected abstract void UpdateQuery(bool queryActive = true);
	}
}
