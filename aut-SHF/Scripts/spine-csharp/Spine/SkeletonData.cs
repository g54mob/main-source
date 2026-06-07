namespace Spine
{
	public class SkeletonData
	{
		internal string name;

		internal ExposedList<BoneData> bones;

		internal ExposedList<SlotData> slots;

		internal ExposedList<Skin> skins;

		internal Skin defaultSkin;

		internal ExposedList<EventData> events;

		internal ExposedList<Animation> animations;

		internal ExposedList<IkConstraintData> ikConstraints;

		internal ExposedList<TransformConstraintData> transformConstraints;

		internal ExposedList<PathConstraintData> pathConstraints;

		internal ExposedList<PhysicsConstraintData> physicsConstraints;

		internal float x;

		internal float y;

		internal float width;

		internal float height;

		internal float referenceScale;

		internal string version;

		internal string hash;

		internal float fps;

		internal string imagesPath;

		internal string audioPath;

		public string Name
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public ExposedList<BoneData> Bones => null;

		public ExposedList<SlotData> Slots => null;

		public ExposedList<Skin> Skins
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public Skin DefaultSkin
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public ExposedList<EventData> Events
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public ExposedList<Animation> Animations
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public ExposedList<IkConstraintData> IkConstraints
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public ExposedList<TransformConstraintData> TransformConstraints
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public ExposedList<PathConstraintData> PathConstraints
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public ExposedList<PhysicsConstraintData> PhysicsConstraints
		{
			get
			{
				return null;
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

		public float Width
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float Height
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float ReferenceScale
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public string Version
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public string Hash
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public string ImagesPath
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public string AudioPath
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public float Fps
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public BoneData FindBone(string boneName)
		{
			return null;
		}

		public SlotData FindSlot(string slotName)
		{
			return null;
		}

		public Skin FindSkin(string skinName)
		{
			return null;
		}

		public EventData FindEvent(string eventDataName)
		{
			return null;
		}

		public Animation FindAnimation(string animationName)
		{
			return null;
		}

		public IkConstraintData FindIkConstraint(string constraintName)
		{
			return null;
		}

		public TransformConstraintData FindTransformConstraint(string constraintName)
		{
			return null;
		}

		public PathConstraintData FindPathConstraint(string constraintName)
		{
			return null;
		}

		public PhysicsConstraintData FindPhysicsConstraint(string constraintName)
		{
			return null;
		}

		public override string ToString()
		{
			return null;
		}
	}
}
