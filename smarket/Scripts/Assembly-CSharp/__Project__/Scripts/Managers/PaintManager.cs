using System;
using System.Collections.Generic;
using UnityEngine;
using __Project__.Scripts.FloorPaintSystem;
using __Project__.Scripts.WallPaintSystem;

namespace __Project__.Scripts.Managers
{
	public class PaintManager : NoktaSingleton<PaintManager>
	{
		public FloorBox selectedFloorBox;

		public List<ColorData> wallColorDataList;

		public List<ColorData> bucketColorDataList;

		public List<ColorData> shelfColorDataList;

		public List<FloorTextureData> floorTextureDataList;

		private List<PaintBucket> m_BucketList;

		private List<FloorBox> m_FloorBoxes;

		public List<PaintableWall> walls;

		public List<PaintableFloor> floors;

		public Action onWallPainted;

		public Action onFloorPainted;

		private void Awake()
		{
		}

		public void LoadSaveProgress()
		{
		}

		private void Update()
		{
		}

		public ColorData GetColorDataFromList(int colorIndex)
		{
			return default(ColorData);
		}

		public ColorData GetColorDataFromList(int colorIndex, bool isBucket)
		{
			return default(ColorData);
		}

		public FloorTextureData GetTextureDataFromList(FloorTextureType type)
		{
			return null;
		}

		public void RemoveBucket(PaintBucket paintBucket)
		{
		}

		private void RefreshBucketList()
		{
		}

		public void AddBucket(PaintBucket paintBucket)
		{
		}

		public void AddFloorBox(FloorBox floorBox)
		{
		}

		public void RemoveFloorBox(FloorBox floorBox)
		{
		}

		public void SetBucketSaveData()
		{
		}

		private void LoadBucketData()
		{
		}

		public void SetFloorBoxSaveData()
		{
		}

		private void LoadFloorBoxData()
		{
		}

		private void LoadWallPaintData()
		{
		}

		private void LoadFloorPaintData()
		{
		}

		public void SaveWallPaintData()
		{
		}

		public void SaveFloorData()
		{
		}

		[Tooltip("Use only for editor. sets all paintable walls")]
		public void SetAllPaintableWalls()
		{
		}

		[Tooltip("Use only for editor. sets all paintable floors")]
		public void SetAllPaintableFloors()
		{
		}

		public void GrabFloorBox(FloorBox floorBox)
		{
		}
	}
}
