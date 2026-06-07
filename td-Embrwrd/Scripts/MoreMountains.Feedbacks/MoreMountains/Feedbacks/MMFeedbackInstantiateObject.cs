using UnityEngine;
using UnityEngine.Serialization;

namespace MoreMountains.Feedbacks
{
	[FeedbackPath("GameObject/Instantiate Object")]
	[FeedbackHelp("This feedback allows you to instantiate the object specified in its inspector, at the feedback's position (plus an optional offset). You can also optionally (and automatically) create an object pool at initialization to save on performance. In that case you'll need to specify a pool size (usually the maximum amount of these instantiated objects you plan on having in your scene at each given time).")]
	[AddComponentMenu(null)]
	public class MMFeedbackInstantiateObject : MMFeedback
	{
		public enum PositionModes
		{
			FeedbackPosition = 0,
			Transform = 1,
			WorldPosition = 2,
			Script = 3
		}

		public static bool FeedbackTypeAuthorized;

		[Header("Instantiate Object")]
		[Tooltip("the object to instantiate")]
		[FormerlySerializedAs("VfxToInstantiate")]
		public GameObject GameObjectToInstantiate;

		[Header("Position")]
		[Tooltip("the chosen way to position the object")]
		public PositionModes PositionMode;

		[Tooltip("the chosen way to position the object")]
		public bool AlsoApplyRotation;

		[Tooltip("the chosen way to position the object")]
		public bool AlsoApplyScale;

		[MMFEnumCondition("PositionMode", new int[] { 1 })]
		[Tooltip("the transform at which to instantiate the object")]
		public Transform TargetTransform;

		[Tooltip("the transform at which to instantiate the object")]
		[MMFEnumCondition("PositionMode", new int[] { 2 })]
		public Vector3 TargetPosition;

		[Tooltip("the position offset at which to instantiate the object")]
		[FormerlySerializedAs("VfxPositionOffset")]
		public Vector3 PositionOffset;

		[Header("Object Pool")]
		[FormerlySerializedAs("VfxCreateObjectPool")]
		[Tooltip("whether or not we should create automatically an object pool for this object")]
		public bool CreateObjectPool;

		[MMFCondition("CreateObjectPool", true)]
		[Tooltip("the initial and planned size of this object pool")]
		[FormerlySerializedAs("VfxObjectPoolSize")]
		public int ObjectPoolSize;

		[Tooltip("whether or not to create a new pool even if one already exists for that same prefab")]
		[MMFCondition("CreateObjectPool", true)]
		public bool MutualizePools;

		protected MMMiniObjectPooler _objectPooler;

		protected GameObject _newGameObject;

		protected bool _poolCreatedOrFound;

		protected override void CustomInitialization(GameObject owner)
		{
		}

		protected override void CustomPlayFeedback(Vector3 position, float feedbacksIntensity = 1f)
		{
		}

		protected virtual void PositionObject(Vector3 position)
		{
		}

		protected virtual Vector3 GetPosition(Vector3 position)
		{
			return default(Vector3);
		}

		protected virtual Quaternion GetRotation()
		{
			return default(Quaternion);
		}

		protected virtual Vector3 GetScale()
		{
			return default(Vector3);
		}
	}
}
