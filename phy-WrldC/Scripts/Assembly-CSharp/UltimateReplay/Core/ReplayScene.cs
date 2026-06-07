using System.Collections.Generic;
using UltimateReplay.Storage;

namespace UltimateReplay.Core
{
	public sealed class ReplayScene
	{
		public enum ReplaySceneMode
		{
			Live = 0,
			Playback = 1
		}

		private List<ReplayObject> replayObjects = new List<ReplayObject>();

		private Queue<ReplayObject> dynamicReplayObjects = new Queue<ReplayObject>();

		private ReplaySnapshot prePlaybackState;

		private bool isPlayback;

		public bool restorePreviousSceneState = true;

		public bool ReplayEnabled => isPlayback;

		public List<ReplayObject> ActiveReplayObjects => replayObjects;

		public void RegisterReplayObject(ReplayObject replayObject)
		{
			replayObjects.Add(replayObject);
			if (isPlayback)
			{
				ReplayManager.Preparer.PrepareForPlayback(replayObject);
			}
			else
			{
				dynamicReplayObjects.Enqueue(replayObject);
			}
		}

		public void UnregisterReplayObject(ReplayObject replayObject)
		{
			if (replayObjects.Contains(replayObject))
			{
				replayObjects.Remove(replayObject);
			}
		}

		public void SetReplaySceneMode(ReplaySceneMode mode, ReplayInitialDataBuffer initialStateBuffer)
		{
			if (mode == ReplaySceneMode.Playback)
			{
				PrepareForPlayback(initialStateBuffer);
				isPlayback = true;
			}
			else
			{
				PrepareForGameplay(initialStateBuffer);
				isPlayback = false;
			}
		}

		private void PrepareForPlayback(ReplayInitialDataBuffer initialStateBuffer)
		{
			prePlaybackState = RecordSnapshot(0f, initialStateBuffer);
			for (int i = 0; i < replayObjects.Count; i++)
			{
				ReplayManager.Preparer.PrepareForPlayback(replayObjects[i]);
			}
		}

		private void PrepareForGameplay(ReplayInitialDataBuffer initialStateBuffer)
		{
			if (prePlaybackState != null)
			{
				if (restorePreviousSceneState)
				{
					RestoreSnapshot(prePlaybackState, initialStateBuffer);
				}
				prePlaybackState = null;
				ReplayTime.Delta = 1f;
				ReplayBehaviour.Events.CallReplayUpdateEvents();
			}
			for (int i = 0; i < replayObjects.Count; i++)
			{
				ReplayManager.Preparer.PrepareForGameplay(replayObjects[i]);
			}
		}

		public ReplaySnapshot RecordSnapshot(float timeStamp, ReplayInitialDataBuffer initialStateBuffer)
		{
			ReplaySnapshot replaySnapshot = new ReplaySnapshot(timeStamp);
			if (initialStateBuffer != null)
			{
				while (dynamicReplayObjects.Count > 0)
				{
					ReplayObject replayObject = dynamicReplayObjects.Dequeue();
					if (replayObject != null)
					{
						initialStateBuffer.RecordInitialReplayObjectData(replayObject, timeStamp, replayObject.transform.position, replayObject.transform.rotation, replayObject.transform.localScale);
					}
				}
			}
			foreach (ReplayObject replayObject2 in replayObjects)
			{
				ReplayState replayState = new ReplayState();
				replayObject2.OnReplaySerialize(replayState);
				if (replayState.Size != 0)
				{
					replaySnapshot.RecordSnapshot(replayObject2.ReplayIdentity, replayState);
				}
			}
			return replaySnapshot;
		}

		public void RestoreSnapshot(ReplaySnapshot snapshot, ReplayInitialDataBuffer initialStateBuffer)
		{
			snapshot.RestoreReplayObjects(this, initialStateBuffer);
			foreach (ReplayObject replayObject in replayObjects)
			{
				ReplayState replayState = snapshot.RestoreSnapshot(replayObject.ReplayIdentity);
				if (replayState != null)
				{
					replayObject.OnReplayDeserialize(replayState);
				}
			}
		}
	}
}
