using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

namespace RootMotion.FinalIK
{
	[Serializable]
	public class IKSolverVR : IKSolver
	{
		[Serializable]
		public class Arm : BodyPart
		{
			[Serializable]
			public enum ShoulderRotationMode
			{
				YawPitch = 0,
				FromTo = 1
			}

			[LargeHeader("Hand")]
			[Tooltip("The hand target. This should not be the hand controller itself, but a child GameObject parented to it so you could adjust its position/rotation to match the orientation of the hand bone. The best practice for setup would be to move the hand controller to the avatar's hand as it it was held by the avatar, duplicate the avatar's hand bone and parent it to the hand controller. Then assign the duplicate to this slot.")]
			public Transform target;

			[Tooltip("Positional weight of the hand target. Note that if you have nulled the target, the hand will still be pulled to the last position of the target until you set this value to 0.")]
			[Range(0f, 1f)]
			public float positionWeight;

			[Range(0f, 1f)]
			[Tooltip("Rotational weight of the hand target. Note that if you have nulled the target, the hand will still be rotated to the last rotation of the target until you set this value to 0.")]
			public float rotationWeight;

			[LargeHeader("Shoulder")]
			[Range(0f, 1f)]
			[Tooltip("The weight of shoulder rotation")]
			public float shoulderRotationWeight;

			[ShowIf(/*Could not decode attribute arguments.*/)]
			[Tooltip("Different techniques for shoulder bone rotation.")]
			public ShoulderRotationMode shoulderRotationMode;

			[ShowRangeIf(/*Could not decode attribute arguments.*/)]
			[Tooltip("The weight of twisting the shoulders backwards when arms are lifted up.")]
			public float shoulderTwistWeight;

			[ShowIf(/*Could not decode attribute arguments.*/)]
			[Tooltip("Tweak this value to adjust shoulder rotation around the yaw (up) axis.")]
			public float shoulderYawOffset;

			[Tooltip("Tweak this value to adjust shoulder rotation around the pitch (forward) axis.")]
			[ShowIf(/*Could not decode attribute arguments.*/)]
			public float shoulderPitchOffset;

			[LargeHeader("Bending")]
			[Tooltip("The elbow will be bent towards this Transform if 'Bend Goal Weight' > 0.")]
			public Transform bendGoal;

			[Tooltip("If greater than 0, will bend the elbow towards the 'Bend Goal' Transform.")]
			[Range(0f, 1f)]
			public float bendGoalWeight;

			[Range(-180f, 180f)]
			[Tooltip("Angular offset of the elbow bending direction.")]
			public float swivelOffset;

			[Tooltip("Local axis of the hand bone that points from the wrist towards the palm. Used for defining hand bone orientation. If you have copied VRIK component from another avatar that has different bone orientations, right-click on VRIK header and select 'Guess Hand Orientations' from the context menu.")]
			public Vector3 wristToPalmAxis;

			[Tooltip("Local axis of the hand bone that points from the palm towards the thumb. Used for defining hand bone orientation. If you have copied VRIK component from another avatar that has different bone orientations, right-click on VRIK header and select 'Guess Hand Orientations' from the context menu.")]
			public Vector3 palmToThumbAxis;

			[LargeHeader("Stretching")]
			[Tooltip("Use this to make the arm shorter/longer. Works by displacement of hand and forearm localPosition.")]
			[Range(0.01f, 2f)]
			public float armLengthMlp;

			[Tooltip("'Time' represents (target distance / arm length) and 'value' represents the amount of stretching. So value at time 1 represents stretching amount at the point where distance to the target is equal to arm length. Value at time 2 represents stretching amount at the point where distance to the target is double the arm length. Linear stretching would be achieved with a linear curve going up by 45 degrees. Increase the range of stretching by moving the last key up and right by the same amount. Smoothing in the curve can help reduce elbow snapping (start stretching the arm slightly before target distance reaches arm length). To get a good optimal value for this curve, please go to the 'VRIK (Basic)' demo scene and copy the stretch curve over from the Pilot character.")]
			public AnimationCurve stretchCurve;

			[NonSerialized]
			[HideInInspector]
			public Vector3 IKPosition;

			[NonSerialized]
			[HideInInspector]
			public Quaternion IKRotation;

			[NonSerialized]
			[HideInInspector]
			public Vector3 bendDirection;

			[NonSerialized]
			[HideInInspector]
			public Vector3 handPositionOffset;

			private bool hasShoulder;

			private Vector3 chestForwardAxis;

			private Vector3 chestUpAxis;

			private Quaternion chestRotation;

			private Vector3 chestForward;

			private Vector3 chestUp;

			private Quaternion forearmRelToUpperArm;

			private Vector3 upperArmBendAxis;

			public Vector3 position { get; private set; }

			public Quaternion rotation { get; private set; }

			private VirtualBone shoulder => null;

			private VirtualBone upperArm => null;

			private VirtualBone forearm => null;

			private VirtualBone hand => null;

			protected override void OnRead(Vector3[] positions, Quaternion[] rotations, bool hasChest, bool hasNeck, bool hasShoulders, bool hasToes, bool hasLegs, int rootIndex, int index)
			{
			}

			public override void PreSolve(float scale)
			{
			}

			public override void ApplyOffsets(float scale)
			{
			}

			private void Stretching()
			{
			}

			public void Solve(bool isLeft)
			{
			}

			public override void ResetOffsets()
			{
			}

			public override void Write(ref Vector3[] solvedPositions, ref Quaternion[] solvedRotations)
			{
			}

			private float DamperValue(float value, float min, float max, float weight = 1f)
			{
				return 0f;
			}

			private Vector3 GetBendNormal(Vector3 dir)
			{
				return default(Vector3);
			}

			private void Visualize(VirtualBone bone1, VirtualBone bone2, VirtualBone bone3, Color color)
			{
			}
		}

		[Serializable]
		public abstract class BodyPart
		{
			[HideInInspector]
			public VirtualBone[] bones;

			protected bool initiated;

			protected Vector3 rootPosition;

			protected Quaternion rootRotation;

			protected int index;

			protected int LOD;

			public float sqrMag { get; private set; }

			public float mag { get; private set; }

			protected abstract void OnRead(Vector3[] positions, Quaternion[] rotations, bool hasChest, bool hasNeck, bool hasShoulders, bool hasToes, bool hasLegs, int rootIndex, int index);

			public abstract void PreSolve(float scale);

			public abstract void Write(ref Vector3[] solvedPositions, ref Quaternion[] solvedRotations);

			public abstract void ApplyOffsets(float scale);

			public abstract void ResetOffsets();

			public void SetLOD(int LOD)
			{
			}

			public void Read(Vector3[] positions, Quaternion[] rotations, bool hasChest, bool hasNeck, bool hasShoulders, bool hasToes, bool hasLegs, int rootIndex, int index)
			{
			}

			public void MovePosition(Vector3 position)
			{
			}

			public void MoveRotation(Quaternion rotation)
			{
			}

			public void Translate(Vector3 position, Quaternion rotation)
			{
			}

			public void TranslateRoot(Vector3 newRootPos, Quaternion newRootRot)
			{
			}

			public void RotateTo(VirtualBone bone, Quaternion rotation, float weight = 1f)
			{
			}

			public void Visualize(Color color)
			{
			}

			public void Visualize()
			{
			}
		}

		[Serializable]
		public class Footstep
		{
			public float stepSpeed;

			public Vector3 characterSpaceOffset;

			public Vector3 position;

			public Quaternion rotation;

			public Quaternion stepToRootRot;

			public bool isSupportLeg;

			public bool relaxFlag;

			public Vector3 stepFrom;

			public Vector3 stepTo;

			public Quaternion stepFromRot;

			public Quaternion stepToRot;

			private Quaternion footRelativeToRoot;

			private float supportLegW;

			private float supportLegWV;

			public bool isStepping => false;

			public float stepProgress { get; private set; }

			public Footstep(Quaternion rootRotation, Vector3 footPosition, Quaternion footRotation, Vector3 characterSpaceOffset)
			{
			}

			public void Reset(Quaternion rootRotation, Vector3 footPosition, Quaternion footRotation)
			{
			}

			public void StepTo(Vector3 p, Quaternion rootRotation, float stepThreshold)
			{
			}

			public void UpdateStepping(Vector3 p, Quaternion rootRotation, float speed, float deltaTime)
			{
			}

			public void UpdateStanding(Quaternion rootRotation, float minAngle, float speed, float deltaTime)
			{
			}

			public void Update(InterpolationMode interpolation, UnityEvent onStep, float deltaTime)
			{
			}
		}

		[Serializable]
		public class Leg : BodyPart
		{
			[LargeHeader("Foot/Toe")]
			[Tooltip("The foot/toe target. This should not be the foot tracker itself, but a child GameObject parented to it so you could adjust its position/rotation to match the orientation of the foot/toe bone. If a toe bone is assigned in the References, the solver will match the toe bone to this target. If no toe bone assigned, foot bone will be used instead.")]
			public Transform target;

			[Range(0f, 1f)]
			[Tooltip("Positional weight of the toe/foot target. Note that if you have nulled the target, the foot will still be pulled to the last position of the target until you set this value to 0.")]
			public float positionWeight;

			[Range(0f, 1f)]
			[Tooltip("Rotational weight of the toe/foot target. Note that if you have nulled the target, the foot will still be rotated to the last rotation of the target until you set this value to 0.")]
			public float rotationWeight;

			[LargeHeader("Bending")]
			[Tooltip("The knee will be bent towards this Transform if 'Bend Goal Weight' > 0.")]
			public Transform bendGoal;

			[Tooltip("If greater than 0, will bend the knee towards the 'Bend Goal' Transform.")]
			[Range(0f, 1f)]
			public float bendGoalWeight;

			[Tooltip("Angular offset of knee bending direction.")]
			[Range(-180f, 180f)]
			public float swivelOffset;

			[Range(0f, 1f)]
			[Tooltip("If 0, the bend plane will be locked to the rotation of the pelvis and rotating the foot will have no effect on the knee direction. If 1, to the target rotation of the leg so that the knee will bend towards the forward axis of the foot. Values in between will be slerped between the two.")]
			public float bendToTargetWeight;

			[LargeHeader("Stretching")]
			[Tooltip("Use this to make the leg shorter/longer. Works by displacement of foot and calf localPosition.")]
			[Range(0.01f, 2f)]
			public float legLengthMlp;

			[Tooltip("Evaluates stretching of the leg by target distance relative to leg length. Value at time 1 represents stretching amount at the point where distance to the target is equal to leg length. Value at time 1 represents stretching amount at the point where distance to the target is double the leg length. Value represents the amount of stretching. Linear stretching would be achieved with a linear curve going up by 45 degrees. Increase the range of stretching by moving the last key up and right at the same amount. Smoothing in the curve can help reduce knee snapping (start stretching the arm slightly before target distance reaches leg length). To get a good optimal value for this curve, please go to the 'VRIK (Basic)' demo scene and copy the stretch curve over from the Pilot character.")]
			public AnimationCurve stretchCurve;

			[NonSerialized]
			[HideInInspector]
			public Vector3 IKPosition;

			[NonSerialized]
			[HideInInspector]
			public Quaternion IKRotation;

			[NonSerialized]
			[HideInInspector]
			public Vector3 footPositionOffset;

			[NonSerialized]
			[HideInInspector]
			public Vector3 heelPositionOffset;

			[NonSerialized]
			[HideInInspector]
			public Quaternion footRotationOffset;

			[NonSerialized]
			[HideInInspector]
			public float currentMag;

			[HideInInspector]
			public bool useAnimatedBendNormal;

			private Vector3 footPosition;

			private Quaternion footRotation;

			private Vector3 bendNormal;

			private Quaternion calfRelToThigh;

			private Quaternion thighRelToFoot;

			public Vector3 position { get; private set; }

			public Quaternion rotation { get; private set; }

			public bool hasToes { get; private set; }

			public VirtualBone thigh => null;

			private VirtualBone calf => null;

			private VirtualBone foot => null;

			private VirtualBone toes => null;

			public VirtualBone lastBone => null;

			public Vector3 thighRelativeToPelvis { get; private set; }

			public Vector3 bendNormalRelToPelvis { get; set; }

			public Vector3 bendNormalRelToTarget { get; set; }

			protected override void OnRead(Vector3[] positions, Quaternion[] rotations, bool hasChest, bool hasNeck, bool hasShoulders, bool hasToes, bool hasLegs, int rootIndex, int index)
			{
			}

			public override void PreSolve(float scale)
			{
			}

			public override void ApplyOffsets(float scale)
			{
			}

			private void ApplyPositionOffset(Vector3 offset, float weight)
			{
			}

			private void ApplyRotationOffset(Quaternion offset, float weight)
			{
			}

			public void Solve(bool stretch)
			{
			}

			private void FixTwistRotations()
			{
			}

			private void Stretching()
			{
			}

			public override void Write(ref Vector3[] solvedPositions, ref Quaternion[] solvedRotations)
			{
			}

			public override void ResetOffsets()
			{
			}
		}

		[Serializable]
		public class Locomotion
		{
			[Serializable]
			public enum Mode
			{
				Procedural = 0,
				Animated = 1
			}

			[Tooltip("Procedural (legacy) or animated locomotion.")]
			public Mode mode;

			[Tooltip("Used for blending in/out of procedural/animated locomotion.")]
			[Range(0f, 1f)]
			public float weight;

			[ShowIf(/*Could not decode attribute arguments.*/)]
			[Tooltip("Start moving (horizontal distance to HMD + HMD velocity) threshold.")]
			public float moveThreshold;

			[SerializeField]
			[ShowLargeHeaderIf(/*Could not decode attribute arguments.*/)]
			private byte animationHeader;

			[Tooltip("Minimum locomotion animation speed.")]
			[ShowRangeIf(/*Could not decode attribute arguments.*/)]
			public float minAnimationSpeed;

			[Tooltip("Maximum locomotion animation speed.")]
			[ShowRangeIf(/*Could not decode attribute arguments.*/)]
			public float maxAnimationSpeed;

			[ShowRangeIf(/*Could not decode attribute arguments.*/)]
			[Tooltip("Smoothing time for Vector3.SmoothDamping 'VRIK_Horizontal' and 'VRIK_Vertical' parameters. Larger values make animation smoother, but less responsive.")]
			public float animationSmoothTime;

			[ShowLargeHeaderIf(/*Could not decode attribute arguments.*/)]
			[SerializeField]
			private byte rootPositionHeader;

			[ShowIf(/*Could not decode attribute arguments.*/)]
			[Tooltip("X and Z standing offset from the horizontal position of the HMD.")]
			public Vector2 standOffset;

			[ShowRangeIf(/*Could not decode attribute arguments.*/)]
			[Tooltip("Lerp root towards the horizontal position of the HMD with this speed while moving.")]
			public float rootLerpSpeedWhileMoving;

			[ShowRangeIf(/*Could not decode attribute arguments.*/)]
			[Tooltip("Lerp root towards the horizontal position of the HMD with this speed while in transition from locomotion to idle state.")]
			public float rootLerpSpeedWhileStopping;

			[ShowRangeIf(/*Could not decode attribute arguments.*/)]
			[Tooltip("Lerp root towards the horizontal position of the HMD with this speed while turning on spot.")]
			public float rootLerpSpeedWhileTurning;

			[ShowIf(/*Could not decode attribute arguments.*/)]
			[Tooltip("Max horizontal distance from the root to the HMD.")]
			public float maxRootOffset;

			[ShowLargeHeaderIf(/*Could not decode attribute arguments.*/)]
			[SerializeField]
			private byte rootRotationHeader;

			[Tooltip("Max root angle from head forward while moving (ik.solver.spine.maxRootAngle).")]
			[ShowRangeIf(/*Could not decode attribute arguments.*/)]
			public float maxRootAngleMoving;

			[Tooltip("Max root angle from head forward while standing (ik.solver.spine.maxRootAngle.")]
			[ShowRangeIf(/*Could not decode attribute arguments.*/)]
			public float maxRootAngleStanding;

			[HideInInspector]
			[SerializeField]
			public float stepLengthMlp;

			private Animator animator;

			private Vector3 velocityLocal;

			private Vector3 velocityLocalV;

			private Vector3 lastCorrection;

			private Vector3 lastHeadTargetPos;

			private Vector3 lastSpeedRootPos;

			private Vector3 lastEndRootPos;

			private float rootLerpSpeed;

			private float rootVelocityV;

			private float animSpeed;

			private float animSpeedV;

			private float stopMoveTimer;

			private float turn;

			private float maxRootAngleV;

			private float currentAnimationSmoothTime;

			private bool isMoving;

			private bool firstFrame;

			private static int VRIK_Horizontal;

			private static int VRIK_Vertical;

			private static int VRIK_IsMoving;

			private static int VRIK_Speed;

			private static int VRIK_Turn;

			private static bool isHashed;

			private float lastVelLocalMag;

			[ShowIf(/*Could not decode attribute arguments.*/)]
			[Tooltip("Tries to maintain this distance between the legs.")]
			public float footDistance;

			[ShowIf(/*Could not decode attribute arguments.*/)]
			[Tooltip("Makes a step only if step target position is at least this far from the current footstep or the foot does not reach the current footstep anymore or footstep angle is past the 'Angle Threshold'.")]
			public float stepThreshold;

			[Tooltip("Makes a step only if step target position is at least 'Step Threshold' far from the current footstep or the foot does not reach the current footstep anymore or footstep angle is past this value.")]
			[ShowIf(/*Could not decode attribute arguments.*/)]
			public float angleThreshold;

			[Tooltip("Multiplies angle of the center of mass - center of pressure vector. Larger value makes the character step sooner if losing balance.")]
			[ShowIf(/*Could not decode attribute arguments.*/)]
			public float comAngleMlp;

			[ShowIf(/*Could not decode attribute arguments.*/)]
			[Tooltip("Maximum magnitude of head/hand target velocity used in prediction.")]
			public float maxVelocity;

			[ShowIf(/*Could not decode attribute arguments.*/)]
			[Tooltip("The amount of head/hand target velocity prediction.")]
			public float velocityFactor;

			[ShowRangeIf(/*Could not decode attribute arguments.*/)]
			[Tooltip("How much can a leg be extended before it is forced to step to another position? 1 means fully stretched.")]
			public float maxLegStretch;

			[ShowIf(/*Could not decode attribute arguments.*/)]
			[Tooltip("The speed of lerping the root of the character towards the horizontal mid-point of the footsteps.")]
			public float rootSpeed;

			[ShowIf(/*Could not decode attribute arguments.*/)]
			[Tooltip("The speed of moving a foot to the next position.")]
			public float stepSpeed;

			[Tooltip("The height of the foot by normalized step progress (0 - 1).")]
			[ShowIf(/*Could not decode attribute arguments.*/)]
			public AnimationCurve stepHeight;

			[Tooltip("Reduce this value if locomotion makes the head bob too much.")]
			[ShowIf(/*Could not decode attribute arguments.*/)]
			public float maxBodyYOffset;

			[Tooltip("The height offset of the heel by normalized step progress (0 - 1).")]
			[ShowIf(/*Could not decode attribute arguments.*/)]
			public AnimationCurve heelHeight;

			[Tooltip("Rotates the foot while the leg is not stepping to relax the twist rotation of the leg if ideal rotation is past this angle.")]
			[ShowRangeIf(/*Could not decode attribute arguments.*/)]
			public float relaxLegTwistMinAngle;

			[Tooltip("The speed of rotating the foot while the leg is not stepping to relax the twist rotation of the leg.")]
			[ShowIf(/*Could not decode attribute arguments.*/)]
			public float relaxLegTwistSpeed;

			[Tooltip("Interpolation mode of the step.")]
			[ShowIf(/*Could not decode attribute arguments.*/)]
			public InterpolationMode stepInterpolation;

			[Tooltip("Offset for the approximated center of mass.")]
			[ShowIf(/*Could not decode attribute arguments.*/)]
			public Vector3 offset;

			[HideInInspector]
			public bool blockingEnabled;

			[HideInInspector]
			public LayerMask blockingLayers;

			[HideInInspector]
			public float raycastRadius;

			[HideInInspector]
			public float raycastHeight;

			[SerializeField]
			[HideInInspector]
			public UnityEvent onLeftFootstep;

			[SerializeField]
			[HideInInspector]
			public UnityEvent onRightFootstep;

			private Footstep[] footsteps;

			private Vector3 lastComPosition;

			private Vector3 comVelocity;

			private int leftFootIndex;

			private int rightFootIndex;

			public Vector3 centerOfMass { get; private set; }

			public Vector3 leftFootstepPosition => default(Vector3);

			public Vector3 rightFootstepPosition => default(Vector3);

			public Quaternion leftFootstepRotation => default(Quaternion);

			public Quaternion rightFootstepRotation => default(Quaternion);

			public void Initiate(Animator animator, Vector3[] positions, Quaternion[] rotations, bool hasToes, float scale)
			{
			}

			public void Reset(Vector3[] positions, Quaternion[] rotations)
			{
			}

			public void Relax()
			{
			}

			public void AddDeltaRotation(Quaternion delta, Vector3 pivot)
			{
			}

			public void AddDeltaPosition(Vector3 delta)
			{
			}

			public void Initiate_Animated(Animator animator, Vector3[] positions)
			{
			}

			private void ResetParams(Vector3[] positions)
			{
			}

			public void Reset_Animated(Vector3[] positions)
			{
			}

			private void AddDeltaRotation_Animated(Quaternion delta, Vector3 pivot)
			{
			}

			private void AddDeltaPosition_Animated(Vector3 delta)
			{
			}

			public void Solve_Animated(IKSolverVR solver, float scale, float deltaTime)
			{
			}

			private void Initiate_Procedural(Vector3[] positions, Quaternion[] rotations, bool hasToes, float scale)
			{
			}

			private void Reset_Procedural(Vector3[] positions, Quaternion[] rotations)
			{
			}

			private void Relax_Procedural()
			{
			}

			private void AddDeltaRotation_Procedural(Quaternion delta, Vector3 pivot)
			{
			}

			private void AddDeltaPosition_Procedural(Vector3 delta)
			{
			}

			public void Solve_Procedural(VirtualBone rootBone, Spine spine, Leg leftLeg, Leg rightLeg, Arm leftArm, Arm rightArm, int supportLegIndex, out Vector3 leftFootPosition, out Vector3 rightFootPosition, out Quaternion leftFootRotation, out Quaternion rightFootRotation, out float leftFootOffset, out float rightFootOffset, out float leftHeelOffset, out float rightHeelOffset, float scale, float deltaTime)
			{
				leftFootPosition = default(Vector3);
				rightFootPosition = default(Vector3);
				leftFootRotation = default(Quaternion);
				rightFootRotation = default(Quaternion);
				leftFootOffset = default(float);
				rightFootOffset = default(float);
				leftHeelOffset = default(float);
				rightHeelOffset = default(float);
			}

			private bool StepBlocked(Vector3 fromPosition, Vector3 toPosition, Vector3 rootPosition)
			{
				return false;
			}

			private bool CanStep()
			{
				return false;
			}

			private static bool GetLineSphereCollision(Vector3 lineStart, Vector3 lineEnd, Vector3 sphereCenter, float sphereRadius)
			{
				return false;
			}
		}

		[Serializable]
		public class Spine : BodyPart
		{
			[LargeHeader("Head")]
			[Tooltip("The head target. This should not be the camera Transform itself, but a child GameObject parented to it so you could adjust its position/rotation  to match the orientation of the head bone. The best practice for setup would be to move the camera to the avatar's eyes, duplicate the avatar's head bone and parent it to the camera. Then assign the duplicate to this slot.")]
			public Transform headTarget;

			[Tooltip("Positional weight of the head target. Note that if you have nulled the headTarget, the head will still be pulled to the last position of the headTarget until you set this value to 0.")]
			[Range(0f, 1f)]
			public float positionWeight;

			[Tooltip("Rotational weight of the head target. Note that if you have nulled the headTarget, the head will still be rotated to the last rotation of the headTarget until you set this value to 0.")]
			[Range(0f, 1f)]
			public float rotationWeight;

			[Tooltip("Clamps head rotation. Value of 0.5 allows 90 degrees of rotation for the head relative to the headTarget. Value of 0 allows 180 degrees and value of 1 means head rotation will be locked to the target.")]
			[Range(0f, 1f)]
			public float headClampWeight;

			[Tooltip("Minimum height of the head from the root of the character.")]
			public float minHeadHeight;

			[Range(0f, 1f)]
			[Tooltip("Allows for more natural locomotion animation for 3rd person networked avatars by inheriting vertical head bob motion from the animation while head target height is close to head bone height.")]
			public float useAnimatedHeadHeightWeight;

			[ShowIf(/*Could not decode attribute arguments.*/)]
			[Tooltip("If abs(head target height - head bone height) < this value, will use head bone height as head target Y.")]
			public float useAnimatedHeadHeightRange;

			[Tooltip("Falloff range for the 'Use Animated Head Height Range' effect above. If head target height from head bone height is greater than useAnimatedHeadHeightRange + animatedHeadHeightBlend, then the head will be vertically locked to the head target again.")]
			[ShowIf(/*Could not decode attribute arguments.*/)]
			public float animatedHeadHeightBlend;

			[Tooltip("The pelvis target (optional), useful for seated rigs or if you had an additional tracker on the backpack or belt are. The best practice for setup would be to duplicate the avatar's pelvis bone and parenting it to the pelvis tracker. Then assign the duplicate to this slot.")]
			[LargeHeader("Pelvis")]
			public Transform pelvisTarget;

			[Tooltip("Positional weight of the pelvis target. Note that if you have nulled the pelvisTarget, the pelvis will still be pulled to the last position of the pelvisTarget until you set this value to 0.")]
			[Range(0f, 1f)]
			public float pelvisPositionWeight;

			[Tooltip("Rotational weight of the pelvis target. Note that if you have nulled the pelvisTarget, the pelvis will still be rotated to the last rotation of the pelvisTarget until you set this value to 0.")]
			[Range(0f, 1f)]
			public float pelvisRotationWeight;

			[Tooltip("How much will the pelvis maintain its animated position?")]
			[Range(0f, 1f)]
			public float maintainPelvisPosition;

			[LargeHeader("Chest")]
			[Tooltip("If 'Chest Goal Weight' is greater than 0, the chest will be turned towards this Transform.")]
			public Transform chestGoal;

			[Tooltip("Weight of turning the chest towards the 'Chest Goal'.")]
			[Range(0f, 1f)]
			public float chestGoalWeight;

			[Tooltip("Clamps chest rotation. Value of 0.5 allows 90 degrees of rotation for the chest relative to the head. Value of 0 allows 180 degrees and value of 1 means the chest will be locked relative to the head.")]
			[Range(0f, 1f)]
			public float chestClampWeight;

			[Tooltip("The amount of rotation applied to the chest based on hand positions.")]
			[Range(0f, 1f)]
			public float rotateChestByHands;

			[Range(0f, 1f)]
			[Tooltip("Determines how much the body will follow the position of the head.")]
			[LargeHeader("Spine")]
			public float bodyPosStiffness;

			[Range(0f, 1f)]
			[Tooltip("Determines how much the body will follow the rotation of the head.")]
			public float bodyRotStiffness;

			[Tooltip("Determines how much the chest will rotate to the rotation of the head.")]
			[FormerlySerializedAs("chestRotationWeight")]
			[Range(0f, 1f)]
			public float neckStiffness;

			[Tooltip("Moves the body horizontally along -character.forward axis by that value when the player is crouching.")]
			public float moveBodyBackWhenCrouching;

			[Tooltip("Will automatically rotate the root of the character if the head target has turned past this angle.")]
			[Range(0f, 180f)]
			[LargeHeader("Root Rotation")]
			public float maxRootAngle;

			[Tooltip("Angular offset for root heading. Adjust this value to turn the root relative to the HMD around the vertical axis. Usefulf for fighting or shooting games where you would sometimes want the avatar to stand at an angled stance.")]
			[Range(-180f, 180f)]
			public float rootHeadingOffset;

			[NonSerialized]
			[HideInInspector]
			public Vector3 IKPositionHead;

			[NonSerialized]
			[HideInInspector]
			public Quaternion IKRotationHead;

			[NonSerialized]
			[HideInInspector]
			public Vector3 IKPositionPelvis;

			[NonSerialized]
			[HideInInspector]
			public Quaternion IKRotationPelvis;

			[NonSerialized]
			[HideInInspector]
			public Vector3 goalPositionChest;

			[NonSerialized]
			[HideInInspector]
			public Vector3 pelvisPositionOffset;

			[NonSerialized]
			[HideInInspector]
			public Vector3 chestPositionOffset;

			[NonSerialized]
			[HideInInspector]
			public Vector3 headPositionOffset;

			[NonSerialized]
			[HideInInspector]
			public Quaternion pelvisRotationOffset;

			[NonSerialized]
			[HideInInspector]
			public Quaternion chestRotationOffset;

			[NonSerialized]
			[HideInInspector]
			public Quaternion headRotationOffset;

			[NonSerialized]
			[HideInInspector]
			public Vector3 faceDirection;

			[NonSerialized]
			[HideInInspector]
			internal Vector3 headPosition;

			private Quaternion headRotation;

			private Quaternion pelvisRotation;

			private Quaternion anchorRelativeToPelvis;

			private Quaternion pelvisRelativeRotation;

			private Quaternion chestRelativeRotation;

			private Vector3 headDeltaPosition;

			private Quaternion pelvisDeltaRotation;

			private Quaternion chestTargetRotation;

			private int pelvisIndex;

			private int spineIndex;

			private int chestIndex;

			private int neckIndex;

			private int headIndex;

			private float length;

			private bool hasChest;

			private bool hasNeck;

			private bool hasLegs;

			private float headHeight;

			private float sizeMlp;

			private Vector3 chestForward;

			internal VirtualBone pelvis => null;

			internal VirtualBone firstSpineBone => null;

			internal VirtualBone chest => null;

			internal VirtualBone head => null;

			private VirtualBone neck => null;

			internal Quaternion anchorRotation { get; private set; }

			internal Quaternion anchorRelativeToHead { get; private set; }

			protected override void OnRead(Vector3[] positions, Quaternion[] rotations, bool hasChest, bool hasNeck, bool hasShoulders, bool hasToes, bool hasLegs, int rootIndex, int index)
			{
			}

			public override void PreSolve(float scale)
			{
			}

			public override void ApplyOffsets(float scale)
			{
			}

			private void CalculateChestTargetRotation(VirtualBone rootBone, Arm[] arms)
			{
			}

			public void Solve(Animator animator, VirtualBone rootBone, Leg[] legs, Arm[] arms, float scale)
			{
			}

			private void FABRIKPass(Vector3 animatedPelvisPos, Vector3 rootUp, float weight)
			{
			}

			private void SolvePelvis()
			{
			}

			public override void Write(ref Vector3[] solvedPositions, ref Quaternion[] solvedRotations)
			{
			}

			public override void ResetOffsets()
			{
			}

			private void AdjustChestByHands(ref Quaternion chestTargetRotation, Arm[] arms)
			{
			}

			public void InverseTranslateToHead(Leg[] legs, bool limited, bool useCurrentLegMag, Vector3 offset, float w)
			{
			}

			private void TranslatePelvis(Leg[] legs, Vector3 deltaPosition, Quaternion deltaRotation, float scale)
			{
			}

			private Vector3 LimitPelvisPosition(Leg[] legs, Vector3 pelvisPosition, bool useCurrentLegMag, int it = 2)
			{
				return default(Vector3);
			}

			private void Bend(VirtualBone[] bones, int firstIndex, int lastIndex, Quaternion targetRotation, float clampWeight, bool uniformWeight, float w)
			{
			}

			private void Bend(VirtualBone[] bones, int firstIndex, int lastIndex, Quaternion targetRotation, Quaternion rotationOffset, float clampWeight, bool uniformWeight, float w)
			{
			}
		}

		[Serializable]
		public enum PositionOffset
		{
			Pelvis = 0,
			Chest = 1,
			Head = 2,
			LeftHand = 3,
			RightHand = 4,
			LeftFoot = 5,
			RightFoot = 6,
			LeftHeel = 7,
			RightHeel = 8
		}

		[Serializable]
		public enum RotationOffset
		{
			Pelvis = 0,
			Chest = 1,
			Head = 2
		}

		[Serializable]
		public class VirtualBone
		{
			public Vector3 readPosition;

			public Quaternion readRotation;

			public Vector3 solverPosition;

			public Quaternion solverRotation;

			public float length;

			public float sqrMag;

			public Vector3 axis;

			public VirtualBone(Vector3 position, Quaternion rotation)
			{
			}

			public void Read(Vector3 position, Quaternion rotation)
			{
			}

			public static void SwingRotation(VirtualBone[] bones, int index, Vector3 swingTarget, float weight = 1f)
			{
			}

			public static float PreSolve(ref VirtualBone[] bones)
			{
				return 0f;
			}

			public static void RotateAroundPoint(VirtualBone[] bones, int index, Vector3 point, Quaternion rotation)
			{
			}

			public static void RotateBy(VirtualBone[] bones, int index, Quaternion rotation)
			{
			}

			public static void RotateBy(VirtualBone[] bones, Quaternion rotation)
			{
			}

			public static void RotateTo(VirtualBone[] bones, int index, Quaternion rotation)
			{
			}

			public static void SolveTrigonometric(VirtualBone[] bones, int first, int second, int third, Vector3 targetPosition, Vector3 bendNormal, float weight)
			{
			}

			private static Vector3 GetDirectionToBendPoint(Vector3 direction, float directionMag, Vector3 bendDirection, float sqrMag1, float sqrMag2)
			{
				return default(Vector3);
			}

			public static void SolveFABRIK(VirtualBone[] bones, Vector3 startPosition, Vector3 targetPosition, float weight, float minNormalizedTargetDistance, int iterations, float length, Vector3 startOffset)
			{
			}

			private static Vector3 SolveFABRIKJoint(Vector3 pos1, Vector3 pos2, float length)
			{
				return default(Vector3);
			}

			public static void SolveCCD(VirtualBone[] bones, Vector3 targetPosition, float weight, int iterations)
			{
			}
		}

		private Transform[] solverTransforms;

		private bool hasChest;

		private bool hasNeck;

		private bool hasShoulders;

		private bool hasToes;

		private bool hasLegs;

		private bool hasArms;

		private Vector3[] readPositions;

		private Quaternion[] readRotations;

		private Vector3[] solvedPositions;

		private Quaternion[] solvedRotations;

		private Quaternion[] defaultLocalRotations;

		private Vector3[] defaultLocalPositions;

		private Vector3 rootV;

		private Vector3 rootVelocity;

		private Vector3 bodyOffset;

		private int supportLegIndex;

		private int lastLOD;

		private float lastLocomotionWeight;

		[Tooltip("LOD 0: Full quality solving. LOD 1: Shoulder solving, stretching plant feet disabled, spine solving quality reduced. This provides about 30% of performance gain. LOD 2: Culled, but updating root position and rotation if locomotion is enabled.")]
		[Range(0f, 2f)]
		public int LOD;

		[Tooltip("Scale of the character. Value of 1 means normal adult human size.")]
		public float scale;

		[Tooltip("If true, will keep the toes planted even if head target is out of reach, so this can cause the camera to exit the head if it is too high for the model to reach. Enabling this increases the cost of the solver as the legs will have to be solved multiple times.")]
		public bool plantFeet;

		[Tooltip("The spine solver.")]
		public Spine spine;

		[Tooltip("The left arm solver.")]
		public Arm leftArm;

		[Tooltip("The right arm solver.")]
		public Arm rightArm;

		[Tooltip("The left leg solver.")]
		public Leg leftLeg;

		[Tooltip("The right leg solver.")]
		public Leg rightLeg;

		[Tooltip("Procedural leg shuffling for stationary VR games. Not designed for roomscale and thumbstick locomotion. For those it would be better to use a strafing locomotion blend tree to make the character follow the horizontal direction towards the HMD by root motion or script.")]
		public Locomotion locomotion;

		private Leg[] legs;

		private Arm[] arms;

		private Vector3 headPosition;

		private Vector3 headDeltaPosition;

		private Vector3 raycastOriginPelvis;

		private Vector3 lastOffset;

		private Vector3 debugPos1;

		private Vector3 debugPos2;

		private Vector3 debugPos3;

		private Vector3 debugPos4;

		public Animator animator { get; private set; }

		[HideInInspector]
		public VirtualBone rootBone { get; private set; }

		public void SetToReferences(VRIK.References references)
		{
		}

		public void GuessHandOrientations(VRIK.References references, bool onlyIfZero)
		{
		}

		public void DefaultAnimationCurves()
		{
		}

		public void AddPositionOffset(PositionOffset positionOffset, Vector3 value)
		{
		}

		public void AddRotationOffset(RotationOffset rotationOffset, Vector3 value)
		{
		}

		public void AddRotationOffset(RotationOffset rotationOffset, Quaternion value)
		{
		}

		public void AddPlatformMotion(Vector3 deltaPosition, Quaternion deltaRotation, Vector3 platformPivot)
		{
		}

		public void Reset()
		{
		}

		public override void StoreDefaultLocalState()
		{
		}

		public override void FixTransforms()
		{
		}

		public override Point[] GetPoints()
		{
			return null;
		}

		public override Point GetPoint(Transform transform)
		{
			return null;
		}

		public override bool IsValid(ref string message)
		{
			return false;
		}

		private Vector3 GetNormal(Transform[] transforms)
		{
			return default(Vector3);
		}

		private static Keyframe[] GetSineKeyframes(float mag)
		{
			return null;
		}

		private void UpdateSolverTransforms()
		{
		}

		protected override void OnInitiate()
		{
		}

		protected override void OnUpdate()
		{
		}

		private void WriteTransforms()
		{
		}

		private void Read(Vector3[] positions, Quaternion[] rotations, bool hasChest, bool hasNeck, bool hasShoulders, bool hasToes, bool hasLegs, bool hasArms)
		{
		}

		private void Solve()
		{
		}

		private Vector3 GetPosition(int index)
		{
			return default(Vector3);
		}

		private Quaternion GetRotation(int index)
		{
			return default(Quaternion);
		}

		private void Write()
		{
		}

		private Vector3 GetPelvisOffset(float deltaTime)
		{
			return default(Vector3);
		}
	}
}
