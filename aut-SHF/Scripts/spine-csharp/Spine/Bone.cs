namespace Spine
{
	public class Bone : IUpdatable
	{
		public static bool yDown;

		internal BoneData data;

		internal Skeleton skeleton;

		internal Bone parent;

		internal ExposedList<Bone> children;

		internal float x;

		internal float y;

		internal float rotation;

		internal float scaleX;

		internal float scaleY;

		internal float shearX;

		internal float shearY;

		internal float ax;

		internal float ay;

		internal float arotation;

		internal float ascaleX;

		internal float ascaleY;

		internal float ashearX;

		internal float ashearY;

		internal float a;

		internal float b;

		internal float worldX;

		internal float c;

		internal float d;

		internal float worldY;

		internal Inherit inherit;

		internal bool sorted;

		internal bool active;

		public BoneData Data => null;

		public Skeleton Skeleton => null;

		public Bone Parent => null;

		public ExposedList<Bone> Children => null;

		public bool Active => false;

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

		public float Rotation
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

		public float ShearX
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float ShearY
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public Inherit Inherit
		{
			get
			{
				return default(Inherit);
			}
			set
			{
			}
		}

		public float AppliedRotation
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float AX
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float AY
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float AScaleX
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float AScaleY
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float AShearX
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float AShearY
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

		public float C
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float D
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float WorldX
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float WorldY
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float WorldRotationX => 0f;

		public float WorldRotationY => 0f;

		public float WorldScaleX => 0f;

		public float WorldScaleY => 0f;

		public Bone(BoneData data, Skeleton skeleton, Bone parent)
		{
		}

		public Bone(Bone bone, Skeleton skeleton, Bone parent)
		{
		}

		public void Update(Skeleton.Physics physics)
		{
		}

		public void UpdateWorldTransform()
		{
		}

		public void UpdateWorldTransform(float x, float y, float rotation, float scaleX, float scaleY, float shearX, float shearY)
		{
		}

		public void SetToSetupPose()
		{
		}

		public void UpdateAppliedTransform()
		{
		}

		public void WorldToLocal(float worldX, float worldY, out float localX, out float localY)
		{
			localX = default(float);
			localY = default(float);
		}

		public void LocalToWorld(float localX, float localY, out float worldX, out float worldY)
		{
			worldX = default(float);
			worldY = default(float);
		}

		public void WorldToParent(float worldX, float worldY, out float parentX, out float parentY)
		{
			parentX = default(float);
			parentY = default(float);
		}

		public void ParentToWorld(float parentX, float parentY, out float worldX, out float worldY)
		{
			worldX = default(float);
			worldY = default(float);
		}

		public float WorldToLocalRotation(float worldRotation)
		{
			return 0f;
		}

		public float LocalToWorldRotation(float localRotation)
		{
			return 0f;
		}

		public void RotateWorld(float degrees)
		{
		}

		public override string ToString()
		{
			return null;
		}
	}
}
