using System.Collections.Generic;
using UnityEngine;

namespace MagicaCloth2
{
	public abstract class ColliderComponent : ClothBehaviour, IDataValidate, ITransform
	{
		public Vector3 center;

		[SerializeField]
		protected Vector3 size;

		public ColliderSymmetryMode symmetryMode;

		public Transform symmetryTarget;

		private HashSet<int> teamIdSet;

		public ColliderSymmetryMode? ActiveSymmetryMode { get; private set; }

		public Transform ActiveSymmetryTarget { get; private set; }

		public int UseTeamCount => 0;

		public abstract ColliderManager.ColliderType GetColliderType();

		public abstract void DataValidate();

		public virtual Vector3 GetSize()
		{
			return default(Vector3);
		}

		public void SetSize(Vector3 size)
		{
		}

		public void SetSizeX(float size)
		{
		}

		public void SetSizeY(float size)
		{
		}

		public void SetSizeZ(float size)
		{
		}

		public virtual float GetScale()
		{
			return 0f;
		}

		public virtual bool IsReverseDirection()
		{
			return false;
		}

		internal void Register(int teamId)
		{
		}

		internal bool Exit(int teamId)
		{
			return false;
		}

		public void UpdateParameters()
		{
		}

		public ColliderSymmetryMode CalcSymmetryMode(out Transform symmetryParent)
		{
			symmetryParent = null;
			return default(ColliderSymmetryMode);
		}

		private bool GetHumanoidSymmetryBone(ref Transform target, Transform parent, Animator ani, HumanBodyBones src, HumanBodyBones dst)
		{
			return false;
		}

		private Transform FindCommonParent(Transform at, Transform bt)
		{
			return null;
		}

		internal void SetActiveSymmetryMode(bool firstOnly)
		{
		}

		public void GetUsedTransform(HashSet<Transform> transformSet)
		{
		}

		public void ReplaceTransform(Dictionary<MagicaObjectId, Transform> replaceDict)
		{
		}

		protected virtual void Start()
		{
		}

		protected virtual void OnValidate()
		{
		}

		protected virtual void OnEnable()
		{
		}

		protected virtual void OnDisable()
		{
		}

		protected virtual void OnDestroy()
		{
		}
	}
}
