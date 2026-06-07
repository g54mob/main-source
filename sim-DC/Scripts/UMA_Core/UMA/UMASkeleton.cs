using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace UMA
{
	[Serializable]
	public class UMASkeleton
	{
		[Serializable]
		public class BoneData
		{
			public int boneNameHash;

			public int parentBoneNameHash;

			public Transform boneTransform;

			public UMATransform umaTransform;

			public Quaternion rotation;

			public Vector3 position;

			public Vector3 scale;

			public int accessedFrame;
		}

		[CompilerGenerated]
		private sealed class _003CGetBoneHashes_003Ed__41 : IEnumerable<int>, IEnumerable, IEnumerator<int>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private int _003C_003E2__current;

			private int _003C_003El__initialThreadId;

			public UMASkeleton _003C_003E4__this;

			private Dictionary<int, BoneData>.KeyCollection.Enumerator _003C_003E7__wrap1;

			int IEnumerator<int>.Current
			{
				[DebuggerHidden]
				get
				{
					return 0;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			public _003CGetBoneHashes_003Ed__41(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			private void _003C_003Em__Finally1()
			{
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}

			[DebuggerHidden]
			IEnumerator<int> IEnumerable<int>.GetEnumerator()
			{
				return null;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return null;
			}
		}

		protected bool updating;

		protected int frame;

		private Dictionary<int, BoneData> boneHashDataLookup;

		public IEnumerable<int> BoneHashes => null;

		public string[] BoneNames => null;

		public int rootBoneHash { get; protected set; }

		public virtual int boneCount => 0;

		public bool isUpdating => false;

		public Dictionary<int, BoneData> boneHashData
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public UMASkeleton(Transform rootBone, UMAGeneratorBase umaGenerator)
		{
		}

		protected UMASkeleton()
		{
		}

		public virtual void BeginSkeletonUpdate()
		{
		}

		public virtual void EndSkeletonUpdate()
		{
		}

		public virtual void SetAnimatedBone(int nameHash)
		{
		}

		public virtual void SetAnimatedBoneHierachy(int nameHash)
		{
		}

		public virtual void ClearAnimatedBoneHierachy(int nameHash, bool recursive)
		{
		}

		private void AddBonesRecursive(Transform transform, UMAGeneratorBase umaGenerator)
		{
		}

		protected virtual BoneData GetBone(int nameHash)
		{
			return null;
		}

		public virtual bool HasBone(int nameHash)
		{
			return false;
		}

		public virtual bool BoneExists(int nameHash)
		{
			return false;
		}

		public virtual void AddBone(int parentHash, int hash, Transform transform)
		{
		}

		public virtual void AddBone(UMATransform transform)
		{
		}

		public virtual void RemoveBone(int nameHash)
		{
		}

		public virtual bool TryGetBoneTransform(int nameHash, out Transform boneTransform, out bool transformDirty, out int parentBoneNameHash)
		{
			boneTransform = null;
			transformDirty = default(bool);
			parentBoneNameHash = default(int);
			return false;
		}

		public virtual Transform GetBoneTransform(int nameHash)
		{
			return null;
		}

		public virtual Transform GetBoneTransform(string boneName)
		{
			return null;
		}

		public Transform GetRootTransform()
		{
			return null;
		}

		public Transform GetGlobalTransform()
		{
			return null;
		}

		public virtual GameObject GetBoneGameObject(int nameHash)
		{
			return null;
		}

		public virtual GameObject GetBoneGameObject(string name)
		{
			return null;
		}

		public List<KeyValuePair<int, string>> GetBoneHashNames()
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CGetBoneHashes_003Ed__41))]
		protected virtual IEnumerable<int> GetBoneHashes()
		{
			return null;
		}

		private string[] GetBoneNames()
		{
			return null;
		}

		public bool isValid()
		{
			return false;
		}

		public virtual void Set(int nameHash, Vector3 position, Vector3 scale, Quaternion rotation)
		{
		}

		public virtual void SetPosition(int nameHash, Vector3 position)
		{
		}

		public virtual void SetPositionRelative(int nameHash, Vector3 delta, float weight = 1f)
		{
		}

		public virtual void SetScale(int nameHash, Vector3 scale)
		{
		}

		public virtual void SetScaleRelative(int nameHash, Vector3 scale, float weight = 1f)
		{
		}

		public virtual void SetRotation(int nameHash, Quaternion rotation)
		{
		}

		public virtual void SetRotationRelative(int nameHash, Quaternion rotation, float weight)
		{
		}

		public virtual void Lerp(int nameHash, Vector3 position, Vector3 scale, Quaternion rotation, float weight)
		{
		}

		public virtual void Morph(int nameHash, Vector3 position, Vector3 scale, Quaternion rotation, float weight)
		{
		}

		public virtual bool Reset(int nameHash)
		{
			return false;
		}

		public virtual void ResetAll()
		{
		}

		public virtual bool Restore(int nameHash)
		{
			return false;
		}

		public virtual void RestoreAll()
		{
		}

		public virtual Vector3 GetPosition(int nameHash)
		{
			return default(Vector3);
		}

		public virtual Vector3 GetRelativePosition(int nameHash)
		{
			return default(Vector3);
		}

		public virtual Vector3 GetScale(int nameHash)
		{
			return default(Vector3);
		}

		public virtual Quaternion GetRotation(int nameHash)
		{
			return default(Quaternion);
		}

		public static int StringToHash(string name)
		{
			return 0;
		}

		public virtual Transform[] HashesToTransforms(int[] boneNameHashes)
		{
			return null;
		}

		public virtual Transform[] HashesToTransforms(List<int> boneNameHashes)
		{
			return null;
		}

		public virtual void EnsureBone(UMATransform umaTransform)
		{
		}

		public virtual void EnsureBoneHierarchy()
		{
		}

		public virtual Quaternion GetTPoseCorrectedRotation(int nameHash, Quaternion tPoseRotation)
		{
			return default(Quaternion);
		}

		internal void ReplaceBone(UMASavedItem usi)
		{
		}

		internal void ReplaceBoneRecursively(Transform transform)
		{
		}
	}
}
