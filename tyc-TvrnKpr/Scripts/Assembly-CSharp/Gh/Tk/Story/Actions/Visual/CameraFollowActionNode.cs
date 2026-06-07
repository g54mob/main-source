using UnityEngine.Scripting;
using XNode;

namespace Gh.Tk.Story.Actions.Visual
{
	[InitializeOnGameStarted]
	[NodeTint("#7f7189")]
	public class CameraFollowActionNode : ConnectedStoryNode
	{
		public enum FollowTarget
		{
			Actor = 0,
			Prop = 1,
			Merchant = 2
		}

		public FollowTarget followTarget;

		[Output(ShowBackingValue.Never, ConnectionType.Multiple, TypeConstraint.None, false)]
		public NodeConnection onTargetInFrame;

		private const string FOLLOW_TARGET_KEY = "followTargetId";

		private static StandardCameraRig CameraRig => null;

		[Preserve]
		private static void OnGameStarted()
		{
		}

		private void OnFollowTargetChanged(ActiveStory story)
		{
		}

		private void OnTargetInFrame(ActiveStory story)
		{
		}

		public override void OnTrigger(ActiveStory story)
		{
		}

		private void SetFollowTarget(ActiveStory story, GameObjectX gox)
		{
		}
	}
}
