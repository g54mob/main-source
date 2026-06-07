using System.ComponentModel;
using UnityEngine;

namespace Coherence.Toolkit.Internal
{
	[EditorBrowsable(EditorBrowsableState.Never)]
	internal abstract class CoherenceSharedBehaviourBase : CoherenceBehaviour
	{
		private static bool applicationIsQuitting;

		private const HideFlags SharedGameObjectHideFlags = HideFlags.HideAndDontSave;

		private static GameObject sharedGameObject;

		private static int sharedInstancesTotalCount;

		private protected static TSharedBehaviour CreateSharedInstance<TSharedBehaviour>() where TSharedBehaviour : CoherenceSharedBehaviourBase
		{
			return null;
		}

		private static GameObject CreateSharedGameObject()
		{
			return null;
		}

		private protected static void DisposeSharedInstance<TSharedBehaviour>(ref TSharedBehaviour sharedInstance, bool immediate) where TSharedBehaviour : CoherenceSharedBehaviourBase
		{
		}

		private void OnApplicationQuit()
		{
		}
	}
}
