using Mirror;

namespace Smooth
{
	public struct NetworkStateMirror : NetworkMessage
	{
		public SmoothSyncMirror smoothSync;

		public StateMirror state;

		public void copyFromSmoothSync(SmoothSyncMirror smoothSyncScript)
		{
			smoothSync = smoothSyncScript;
			state.copyFromSmoothSync(smoothSyncScript);
		}
	}
}
