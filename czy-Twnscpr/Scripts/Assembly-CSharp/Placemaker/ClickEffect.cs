using System.Collections.Generic;
using UnityEngine;

namespace Placemaker
{
	public class ClickEffect : MonoBehaviour
	{
		[SerializeField]
		private WorldMaster master;

		[SerializeField]
		private ParticleSystem particle;

		[SerializeField]
		private ParticleSystem voxelSplash;

		[SerializeField]
		private ParticleSystem dust;

		[SerializeField]
		private ParticleSystem colorPickEffect;

		private VoxelType lastVoxelType;

		private VoxelType lastColorPickType;

		[SerializeField]
		private List<AudioClip> addClips;

		[SerializeField]
		private List<AudioClip> removeClips;

		[SerializeField]
		private List<AudioClip> addClips1;

		[SerializeField]
		private List<AudioClip> removeClips1;

		[SerializeField]
		private List<AudioClip> splashClips;

		[SerializeField]
		private List<AudioClip> colorPickClips;

		public float lastClick;

		private float lastPitch;

		public void ColorPick(HoverData hover)
		{
		}

		public void Click(bool add, Vector2 planePos, int height, VoxelType voxelType)
		{
		}

		public void Click(HoverData hover, bool add, Voxel voxel)
		{
		}

		public void ClickBig(VoxelType voxelType)
		{
		}

		private void SetColor(VoxelType voxelType)
		{
		}

		private void SetColorPickColor(VoxelType voxelType)
		{
		}
	}
}
