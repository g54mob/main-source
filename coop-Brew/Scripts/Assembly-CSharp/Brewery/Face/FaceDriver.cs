using System.Collections.Generic;
using Brewery.Voice;
using UnityEngine;

namespace Brewery.Face
{
	[DisallowMultipleComponent]
	public class FaceDriver : MonoBehaviour
	{
		private class Slot
		{
			public SkinnedMeshRenderer smr;

			public Mesh cachedMesh;
		}

		private struct BlendTarget
		{
			public int slot;

			public int inSlot;
		}

		private enum GestureType
		{
			HoldStill = 0,
			NodBurst = 1,
			ForwardEmphasis = 2
		}

		[Header("Culling")]
		[Tooltip("Beyond this distance, the driver skips ticking entirely.")]
		[SerializeField]
		private float maxTickDistance;

		[Tooltip("Between near and far distance, ticking happens at this stride (1 = every frame, 4 = every 4th frame).")]
		[SerializeField]
		private int midRangeStride;

		[Tooltip("Inside this distance, tick every frame.")]
		[SerializeField]
		private float nearTickDistance;

		[Tooltip("Use frustum culling (smr.isVisible) when distance > this.")]
		[SerializeField]
		private float frustumCullDistance;

		[Header("Apply")]
		[Tooltip("Skip SetBlendShapeWeight when the new value differs by less than this (range 0-100).")]
		[SerializeField]
		private float minDeltaToApply;

		[Header("Bone-Driven Animation")]
		[Tooltip("Maximum jaw rotation in degrees when jawOpen is at 100%. Negative = opens downward.")]
		[SerializeField]
		private float jawOpenAngle;

		[Tooltip("Name of the jaw bone in the character skeleton.")]
		[SerializeField]
		private string jawBoneName;

		[Header("Conversational Head Gesture (while talking)")]
		[Tooltip("Enable expressive head movement while voice is active.")]
		[SerializeField]
		private bool enableHeadGesture;

		[Tooltip("How far the head turns side to side (yaw) in degrees.")]
		[SerializeField]
		private float gestureYawRange;

		[Tooltip("How far the head tilts ear-to-shoulder (roll) in degrees. Set to 0 to disable.")]
		[SerializeField]
		private float gestureRollRange;

		[Tooltip("How far the head leans forward (engaged) or back (thinking) in degrees.")]
		[SerializeField]
		private float gestureLeanRange;

		[Tooltip("How far the head nods up-down (pitch) on emphasis dips.")]
		[SerializeField]
		private float gestureNodDip;

		[Tooltip("Speed of the nod dips (Hz).")]
		[SerializeField]
		private float gestureNodSpeed;

		[Tooltip("Spring stiffness — higher = faster snap to target. 6-10 is Disney-like.")]
		[SerializeField]
		private float gestureSpringStiffness;

		[Tooltip("Spring damping — lower = more overshoot bounce. 3-5 is bouncy.")]
		[SerializeField]
		private float gestureSpringDamping;

		[Tooltip("How often the head picks a new pose while talking (seconds).")]
		[SerializeField]
		private float gesturePoseInterval;

		[Tooltip("Bone for head gesture. Use 'neck_01' to avoid conflict with head look IK.")]
		[SerializeField]
		private string headBoneName;

		[Header("Eye Bone Rotation")]
		[Tooltip("Enable eye bone rotation for eye direction. Uses Synty's bone coordinate system.")]
		[SerializeField]
		private bool enableEyeBoneRotation;

		[Tooltip("Multiplier on Synty's eye rotation targets. 0.5 = subtle glances, 1.0 = full Synty range. Keep LOW to avoid eyeball distortion.")]
		[SerializeField]
		private float eyeBoneScale;

		[SerializeField]
		private string eyeBoneLeftName;

		[SerializeField]
		private string eyeBoneRightName;

		[Header("Debug")]
		[SerializeField]
		private bool logBlendshapeNamesOnAwake;

		private readonly List<Slot> _slots;

		private readonly Dictionary<string, int> _blendIndex;

		private readonly List<FaceSource> _sources;

		private readonly FaceFrame _frame;

		private readonly List<int> _activeIndices;

		private BlendTarget[][] _globalTargets;

		private string[] _globalNames;

		private float[] _lastApplied;

		private bool[] _isActive;

		private int _globalCount;

		private int _frameCounter;

		private int _cacheVersion;

		private int _primarySlot;

		private Transform _jawBone;

		private int _jawOpenGlobalId;

		private Transform _headBone;

		private float _lastHeadNodPitch;

		private float _lastHeadNodRoll;

		private VivoxPlayerTracker _voiceTracker;

		private float _smoothedVoiceActivity;

		private Vector3 _gesturePoseTarget;

		private Vector3 _gesturePoseCurrent;

		private Vector3 _gestureVelocity;

		private float _nextPoseChangeTime;

		private float _currentStiffness;

		private GestureType _activeGesture;

		private float _gestureIntensity;

		private float _gestureStartTime;

		private float _gestureEndTime;

		private float _nextGestureTime;

		private Transform _eyeBoneL;

		private Transform _eyeBoneR;

		private int _idxLookInL;

		private int _idxLookOutL;

		private int _idxLookUpL;

		private int _idxLookDownL;

		private int _idxLookInR;

		private int _idxLookOutR;

		private int _idxLookUpR;

		private int _idxLookDownR;

		private readonly List<string> _missingConstants;

		private static readonly string[] _faceBlendshapePrefixes;

		public bool HeadBoneResolved => false;

		public float LastHeadNodPitch => 0f;

		public float LastHeadNodRoll => 0f;

		public bool EyeBonesResolved => false;

		public Vector3 LastEyeRotL { get; private set; }

		public Vector3 LastEyeRotR { get; private set; }

		public SkinnedMeshRenderer HeadMesh => null;

		public IReadOnlyList<FaceSource> Sources => null;

		public int BlendShapeCount => 0;

		public int CacheVersion => 0;

		public int FaceMeshCount => 0;

		public IReadOnlyList<string> MissingConstants => null;

		public Dictionary<string, float> DebugForcedShapes { get; }

		private void Awake()
		{
		}

		private void OnEnable()
		{
		}

		private bool EnsureMeshAndCache()
		{
			return false;
		}

		private void BuildBlendIndex()
		{
		}

		private void ResolveJawBone()
		{
		}

		private void ResolveHeadBone()
		{
		}

		private void ResolveEyeBones()
		{
		}

		private static Transform FindBoneRecursive(Transform parent, string boneName)
		{
			return null;
		}

		private void ComputeMissingConstants()
		{
		}

		private static bool HasAnyFaceBlendshape(Mesh mesh)
		{
			return false;
		}

		private void GatherSources()
		{
		}

		public int GetBlendIndex(string bareName)
		{
			return 0;
		}

		public string GetBlendName(int globalId)
		{
			return null;
		}

		public float GetBlendCurrentWeight(int globalId)
		{
			return 0f;
		}

		public void RefreshSources()
		{
		}

		private bool ShouldTickThisFrame(out float dt)
		{
			dt = default(float);
			return false;
		}

		private void LateUpdate()
		{
		}

		private void ApplyFrame()
		{
		}

		private void SwapPop(int i)
		{
		}
	}
}
