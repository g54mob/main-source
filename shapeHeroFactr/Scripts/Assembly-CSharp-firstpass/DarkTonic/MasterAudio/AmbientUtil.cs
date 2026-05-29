using System.Collections.Generic;
using UnityEngine;

namespace DarkTonic.MasterAudio
{
	public static class AmbientUtil
	{
		public const string FollowerHolderName = "_Followers";

		public const string ListenerFollowerName = "~ListenerFollower~";

		public const float ListenerFollowerTrigRadius = 0.01f;

		public const int IgnoreRaycastLayerNumber = 2;

		private static Transform _followerHolder;

		private static ListenerFollower _listenerFollower;

		private static List<TransformFollower> _transformFollowers;

		public static ListenerFollower ListenerFollower => null;

		public static Transform FollowerHolder => null;

		public static bool HasListenerFollower => false;

		public static int AmbientCount => 0;

		public static bool HasListenerFolowerRigidBody => false;

		public static void InitFollowerHolder()
		{
		}

		public static bool InitListenerFollower()
		{
			return false;
		}

		public static void RemoveTransformFollower(TransformFollower follower)
		{
		}

		public static Transform InitAudioSourceFollower(Transform transToFollow, string followerName, string soundGroupName, string variationName, float volume, bool willFollowSource, bool willPositionOnClosestColliderPoint, bool useTopCollider, bool useChildColliders, MasterAudio.AmbientSoundExitMode exitMode, float exitFadeTime, MasterAudio.AmbientSoundReEnterMode reEnterMode, float reEnterFadeTime)
		{
			return null;
		}

		public static void ManualUpdate()
		{
		}

		private static void UpdateListenerFollower()
		{
		}
	}
}
