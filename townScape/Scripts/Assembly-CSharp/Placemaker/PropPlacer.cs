using System.Collections.Generic;
using Placemaker.Graphs;
using Placemaker.Props;
using Unity.Mathematics;
using UnityEngine;

namespace Placemaker
{
	public class PropPlacer : MonoBehaviour
	{
		[SerializeField]
		private WorldMaster master;

		[SerializeField]
		private List<Prop> srcProps;

		private Dictionary<Prop, Transform> propPools;

		[SerializeField]
		private Transform propPoolContainer;

		[SerializeField]
		private Transform secondaryPropsContainer;

		[SerializeField]
		private Transform deconstructionContainer;

		public readonly Dictionary<int3, List<PropCollider>> colliderDict;

		[SerializeField]
		private List<Mesh> materialMeshes;

		public const float chunkSize = 2f;

		public const float chunkHalfSize = 1f;

		public const float chunkInvSize = 0.5f;

		private Matrix4x4 GetChunkMatrix(int3 coordinate)
		{
			return default(Matrix4x4);
		}

		private void OnEnable()
		{
		}

		private void AddColliderToDict(PropNode node0)
		{
		}

		private void RemoveColliderFromDict(PropNode node0)
		{
		}

		public PropRadiusIterator<T> GetPropIterator<T>(Vector3 pos, float radius) where T : Component
		{
			return default(PropRadiusIterator<T>);
		}

		private void HideCountMinus(PropNode node)
		{
		}

		private void HideCountPlus(PropNode node)
		{
		}

		private void ChangeHideCount(PropNode node, bool add)
		{
		}

		private bool RecursiveCheck(PropNode node0, PropNode inNode = null)
		{
			return false;
		}

		public Mesh GetMeshWithVoxelType(Mesh srcMesh, byte voxelType)
		{
			return null;
		}

		private Prop GetProp(Prop srcProp, Transform parent)
		{
			return null;
		}

		private void FirstTurnOn(PropNode node)
		{
		}

		public void ReturnProp(Prop prop)
		{
		}

		private void RecursivePropNodeSetup(PropNode parentNode, Transform srcT, Transform dstT)
		{
		}

		public void RemovePropsFromContainer(ModuleContainer moduleContainer)
		{
		}

		public bool IterateDeconstructProps()
		{
			return false;
		}

		public void PlacePropsInQube(Qube qube)
		{
		}

		public void OnReset()
		{
		}

		public void OnDoneResetting()
		{
		}

		private void AddSmoothTangentsToMesh(Mesh mesh)
		{
		}

		private void OnDrawGizmos()
		{
		}
	}
}
