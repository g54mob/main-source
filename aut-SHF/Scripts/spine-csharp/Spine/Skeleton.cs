using System;

namespace Spine
{
	public class Skeleton
	{
		public enum Physics
		{
			None = 0,
			Reset = 1,
			Update = 2,
			Pose = 3
		}

		private static readonly int[] quadTriangles;

		internal SkeletonData data;

		internal ExposedList<Bone> bones;

		internal ExposedList<Slot> slots;

		internal ExposedList<Slot> drawOrder;

		internal ExposedList<IkConstraint> ikConstraints;

		internal ExposedList<TransformConstraint> transformConstraints;

		internal ExposedList<PathConstraint> pathConstraints;

		internal ExposedList<PhysicsConstraint> physicsConstraints;

		internal ExposedList<IUpdatable> updateCache;

		internal Skin skin;

		internal float r;

		internal float g;

		internal float b;

		internal float a;

		internal float x;

		internal float y;

		internal float scaleX;

		internal float time;

		private float scaleY;

		public SkeletonData Data => null;

		public ExposedList<Bone> Bones => null;

		public ExposedList<IUpdatable> UpdateCacheList => null;

		public ExposedList<Slot> Slots => null;

		public ExposedList<Slot> DrawOrder => null;

		public ExposedList<IkConstraint> IkConstraints => null;

		public ExposedList<PathConstraint> PathConstraints => null;

		public ExposedList<PhysicsConstraint> PhysicsConstraints => null;

		public ExposedList<TransformConstraint> TransformConstraints => null;

		public Skin Skin
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public float R
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float G
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float B
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float A
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float X
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float Y
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float ScaleX
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float ScaleY
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		[Obsolete("Use ScaleX instead. FlipX is when ScaleX is negative.")]
		public bool FlipX
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		[Obsolete("Use ScaleY instead. FlipY is when ScaleY is negative.")]
		public bool FlipY
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public float Time
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public Bone RootBone => null;

		public Skeleton(SkeletonData data)
		{
		}

		public Skeleton(Skeleton skeleton)
		{
		}

		public void UpdateCache()
		{
		}

		private void SortIkConstraint(IkConstraint constraint)
		{
		}

		private void SortTransformConstraint(TransformConstraint constraint)
		{
		}

		private void SortPathConstraint(PathConstraint constraint)
		{
		}

		private void SortPathConstraintAttachment(Skin skin, int slotIndex, Bone slotBone)
		{
		}

		private void SortPathConstraintAttachment(Attachment attachment, Bone slotBone)
		{
		}

		private void SortPhysicsConstraint(PhysicsConstraint constraint)
		{
		}

		private void SortBone(Bone bone)
		{
		}

		private static void SortReset(ExposedList<Bone> bones)
		{
		}

		public void UpdateWorldTransform(Physics physics)
		{
		}

		public void UpdateWorldTransform(Physics physics, Bone parent)
		{
		}

		public void PhysicsTranslate(float x, float y)
		{
		}

		public void PhysicsRotate(float x, float y, float degrees)
		{
		}

		public void Update(float delta)
		{
		}

		public void SetToSetupPose()
		{
		}

		public void SetBonesToSetupPose()
		{
		}

		public void SetSlotsToSetupPose()
		{
		}

		public Bone FindBone(string boneName)
		{
			return null;
		}

		public Slot FindSlot(string slotName)
		{
			return null;
		}

		public void SetSkin(string skinName)
		{
		}

		public void SetSkin(Skin newSkin)
		{
		}

		public Attachment GetAttachment(string slotName, string attachmentName)
		{
			return null;
		}

		public Attachment GetAttachment(int slotIndex, string attachmentName)
		{
			return null;
		}

		public void SetAttachment(string slotName, string attachmentName)
		{
		}

		public IkConstraint FindIkConstraint(string constraintName)
		{
			return null;
		}

		public TransformConstraint FindTransformConstraint(string constraintName)
		{
			return null;
		}

		public PathConstraint FindPathConstraint(string constraintName)
		{
			return null;
		}

		public PhysicsConstraint FindPhysicsConstraint(string constraintName)
		{
			return null;
		}

		public void GetBounds(out float x, out float y, out float width, out float height, ref float[] vertexBuffer, SkeletonClipping clipper = null)
		{
			x = default(float);
			y = default(float);
			width = default(float);
			height = default(float);
		}

		public override string ToString()
		{
			return null;
		}
	}
}
