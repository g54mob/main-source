using System.Collections.Generic;
using Placemaker.Quads;
using Unity.Mathematics;
using UnityEngine;

namespace Placemaker
{
	public class HoverData : MonoBehaviour
	{
		[SerializeField]
		private WorldMaster master;

		[SerializeField]
		private int lastId;

		public Ray ray;

		public Vert srcVert;

		public Vert dstVert;

		public Voxel voxel;

		public int srcHeight;

		public int dstHeight;

		public int lastHash;

		public Vector3 pointerHitPos;

		public Vector3 pointerHitDir;

		public sbyte side;

		public bool occupied;

		public bool insideBorders;

		public bool valid;

		public bool validPaint;

		public bool validAdd;

		public bool validRemove;

		public bool validBucket;

		private Plane gamepadPlane;

		[SerializeField]
		private int floodIndex;

		public List<Voxel> floodVoxels;

		public int2 srcHexPos => default(int2);

		public int2 dstHexPos => default(int2);

		public int3 srcHexPosHeight => default(int3);

		public int3 dstHexPosHeight => default(int3);

		public bool vertical => false;

		public Vector3 GetSrcPos()
		{
			return default(Vector3);
		}

		public Vector3 GetDstPos()
		{
			return default(Vector3);
		}

		public void ClearHover()
		{
		}

		public void SetHover(Vector2 position, int actionId)
		{
		}

		private Vert TryGetVert(float2 planePos)
		{
			return default(Vert);
		}

		public void JumpForwardOnAdd()
		{
		}

		private bool IsOccupied(int2 hexPos, int height)
		{
			return false;
		}

		public void GamepadAddMove(Vector2 position, Vector2 delta, float actionT)
		{
		}

		public void OnGamepadMoveAdd()
		{
		}

		public void OnGamepadRemove()
		{
		}

		public void Finish()
		{
		}

		private void Update()
		{
		}

		private bool Iterate()
		{
			return false;
		}

		private void OnDrawGizmos()
		{
		}
	}
}
