using System.Diagnostics.CodeAnalysis;

namespace Coherence.Toolkit.Internal
{
	internal abstract class CoherenceSharedBehaviour<TSharedBehaviour> : CoherenceSharedBehaviourBase where TSharedBehaviour : CoherenceSharedBehaviour<TSharedBehaviour>
	{
		private static TSharedBehaviour sharedInstance;

		protected static TSharedBehaviour SharedInstance => null;

		internal static void DisposeSharedInstance(bool immediate)
		{
		}

		internal static bool TryGetSharedInstance([MaybeNullWhen(false)][NotNullWhen(true)] out TSharedBehaviour sharedInstance)
		{
			sharedInstance = null;
			return false;
		}
	}
}
