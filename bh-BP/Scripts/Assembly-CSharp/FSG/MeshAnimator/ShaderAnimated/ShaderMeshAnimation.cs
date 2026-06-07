using System;
using UnityEngine;

namespace FSG.MeshAnimator.ShaderAnimated
{
	[Serializable]
	public class ShaderMeshAnimation : MeshAnimationBase
	{
		[HideInInspector]
		public MeshFrameDataBase[] frameData;

		[HideInInspector]
		public Texture2D[] textures;

		[HideInInspector]
		public Vector3 animScalar;

		[HideInInspector]
		public Vector2Int textureSize;

		[HideInInspector]
		public int textureCount;

		public override MeshFrameDataBase[] Frames => null;

		public override int TotalFrames => 0;

		public override MeshFrameDataBase GetNearestFrame(int frame)
		{
			return null;
		}

		public override void DisplayFrame(IMeshAnimator meshAnimator, int frame, int previousFrame)
		{
		}

		public override void GenerateFrame(Mesh baseMesh, int frame)
		{
		}

		public override void GenerateFrames(Mesh baseMesh)
		{
		}

		public override void Reset()
		{
		}

		public override void SetFrameData(int frame, MeshFrameDataBase frameData)
		{
		}

		public override void SetFrameData(MeshFrameDataBase[] frameData)
		{
		}
	}
}
