using System.Collections.Generic;
using UnityEngine;
using com.ootii.Base;

namespace com.ootii.Actors.BoneControllers
{
	public abstract class IKBone : BaseObject
	{
		public Transform _Transform;

		protected string mCleanName;

		public Quaternion _BindRotation;

		public Vector3 _BindPosition;

		public Matrix4x4 _BindMatrix;

		public Vector3 _BoneForward;

		public Vector3 _BoneUp;

		public Vector3 _BoneRight;

		public Quaternion _ToBoneForward;

		public bool _IsDirty;

		public float _Length;

		public float _Weight;

		public Quaternion _Swing;

		public Quaternion _Twist;

		public int _ColliderType;

		public Vector3 _ColliderSize;

		public int SerializationParentIndex;

		public List<int> SerializationChildIndexes;

		public virtual Transform Transform
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public virtual string CleanName => null;

		public virtual Quaternion BindRotation => default(Quaternion);

		public virtual Vector3 BindPosition => default(Vector3);

		public virtual Matrix4x4 BindMatrix => default(Matrix4x4);

		public virtual Vector3 BoneForward
		{
			get
			{
				return default(Vector3);
			}
			set
			{
			}
		}

		public virtual Vector3 BoneUp
		{
			get
			{
				return default(Vector3);
			}
			set
			{
			}
		}

		public virtual Vector3 BoneRight
		{
			get
			{
				return default(Vector3);
			}
			set
			{
			}
		}

		public virtual Quaternion ToBoneForward
		{
			get
			{
				return default(Quaternion);
			}
			set
			{
			}
		}

		public virtual bool IsDirty
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public virtual float Length
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public virtual float Weight
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public virtual Quaternion Swing => default(Quaternion);

		public virtual Quaternion Twist => default(Quaternion);

		public virtual int ColliderType
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public Vector3 ColliderSize
		{
			get
			{
				return default(Vector3);
			}
			set
			{
			}
		}

		public IKBone()
		{
		}

		public abstract void InvalidateBones();

		public abstract void LoadBones();

		public abstract void Clear();

		public abstract void ClearRotation();

		public abstract Quaternion TransformWorldRotationToLocalRotation(Quaternion rWorldRotation);

		public abstract Vector3 TransformWorldRotationToLocalRotation(Vector3 rWorldDirection);

		public abstract Quaternion TransformLocalRotationToWorldRotation(Quaternion rLocalRotation);

		public abstract Vector3 TransformLocalRotationToWorldRotation(Vector3 rLocalDirection);

		public abstract Vector3 TransformLocalPointToWorldPoint(Vector3 rLocalPoint);

		public abstract void SetWorldSwing(Quaternion rRotation, float rWeight);

		public abstract void SetWorldRotation(Vector3 rEuler, float rWeight);

		public abstract void SetWorldRotation(float rPitch, float rYaw, float rRoll, float rWeight);

		public abstract void SetWorldRotation(Quaternion rRotation, float rWeight);

		public abstract void SetWorldRotation(Quaternion rSwing, Quaternion rTwist, float rWeight);

		public abstract void SetLocalRotation(Vector3 rEuler, float rWeight);

		public abstract void SetLocalRotation(float rPitch, float rYaw, float rRoll, float rWeight);

		public abstract void SetLocalRotation(Quaternion rRotation, float rWeight);

		public abstract void SetLocalRotation(Quaternion rSwing, Quaternion rTwist, float rWeight);

		public abstract void SetWorldEndPosition(Vector3 rPosition, float rWeight);

		public abstract void SetWorldEndPosition(Vector3 rPosition, Vector3 rUp, float rWeight);

		public abstract bool TestPointCollision(Vector3 rPoint);

		public abstract bool TestRayCollision(Vector3 rStart, Vector3 rDirection, float rRange, out Vector3 rHitPoint);

		public abstract Vector3 ClosetPoint(Vector3 rPoint);
	}
}
