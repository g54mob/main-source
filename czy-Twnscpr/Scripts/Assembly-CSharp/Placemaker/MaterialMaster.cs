using System;
using UnityEngine;

namespace Placemaker
{
	public class MaterialMaster : MonoBehaviour, WorldMaster.IOnOnEnable
	{
		[Serializable]
		public class VoxelMaterial
		{
			[SerializeField]
			public Color32 color;
		}

		[SerializeField]
		private WorldMaster master;

		[SerializeField]
		public Material windowMaterial;

		[SerializeField]
		public Material groundMaterial;

		[SerializeField]
		public Material houseMaterial;

		[SerializeField]
		public Material waterMaterial;

		[SerializeField]
		public Material hole0;

		[SerializeField]
		public Material propMaterial;

		[SerializeField]
		public Material doorMaterial;

		[SerializeField]
		public Material mirrorHouseMaterial;

		[SerializeField]
		public Material fenceMaterial;

		[SerializeField]
		public Material gridMaterial;

		[SerializeField]
		public Material voxelMaterial;

		[SerializeField]
		public Material borderMaterial;

		[SerializeField]
		public Material sandMaterial;

		public Color backgroundColor;

		public Color grassColor;

		public Color roofColor;

		public Color plateColor;

		public Color stoneColor;

		public Texture2D materialTexture;

		public Texture2D CreatePaletteTexture()
		{
			return null;
		}

		void WorldMaster.IOnOnEnable.OnOnEnable(WorldMaster worldMaster)
		{
		}

		public void OnStart()
		{
		}
	}
}
