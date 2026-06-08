using System.Collections.Generic;
using UnityEngine;

namespace BoardEditor
{
	public class GECorridor : IGEObject
	{
		public enum CorridorLayoutEnum
		{
			Undefined = 0,
			Horiz = 1,
			Vert = 2
		}

		private List<IGEObject> _linkedObjects = new List<IGEObject>();

		private Vector2 _currentLLCorner = Vector2.zero;

		private List<TileData> objectTiles = new List<TileData>();

		private GameEditorScript ge;

		public string ID { get; set; }

		public bool isActive { get; private set; }

		public bool isInEditMode { get; private set; }

		public bool isMouseOver { get; private set; }

		public bool isDestroying { get; private set; }

		public bool canRotate
		{
			get
			{
				return false;
			}
		}

		public CorridorLayoutEnum corridorLayout { get; private set; }

		public int corridorLength { get; private set; }

		public List<IGEObject> linkedObjects
		{
			get
			{
				return _linkedObjects;
			}
			private set
			{
				_linkedObjects = value;
			}
		}

		public GEObjectTypeEnum objectType
		{
			get
			{
				return GEObjectTypeEnum.Corridor;
			}
		}

		public Vector2 currentLLCorner
		{
			get
			{
				return _currentLLCorner;
			}
			private set
			{
				_currentLLCorner = value;
			}
		}

		public bool isStartingAirlock { get; set; }

		public List<DesignedDungeonManager.MetaData> metaDataList { get; private set; }

		public Color baseLightColor
		{
			get
			{
				return GameEditorScript.DoorColorLight;
			}
		}

		public Color baseDarkColor
		{
			get
			{
				return GameEditorScript.DoorColorDark;
			}
		}

		public event CommonEvents.MDownOnObjectEventHandler MouseDownOnObjectEvent;

		public event CommonEvents.MUpOnObjectEventHandler MouseUpOnObjectEvent;

		public event CommonEvents.ObjectMEnterEventHandler MouseEnterRoomEvent;

		public event CommonEvents.ObjectActivateChangedEventHandler ObjectActivateChangedEvent;

		public void InitCorridor(List<Vector2> tilePositionList, IGEObject obj1, IGEObject obj2, CorridorLayoutEnum corridorLayout, int corridorLength)
		{
			currentLLCorner = tilePositionList[0];
			foreach (Vector2 tilePosition in tilePositionList)
			{
				int num = (int)tilePosition.x;
				int num2 = (int)tilePosition.y;
				objectTiles.Add(DesignedDungeonManager.tiles[num, num2]);
				int index = objectTiles.Count - 1;
				if (Table.Instance != null)
				{
					if (obj1 != null && obj2 != null)
					{
						objectTiles[index].visualComponent.SetColor((!GameEditorScript.IsWhiteTile(num, num2)) ? baseDarkColor : baseLightColor);
					}
					else
					{
						objectTiles[index].visualComponent.SetColor(GameEditorScript.AirlockColor);
					}
				}
				if (objectTiles[index].visualComponent != null)
				{
					objectTiles[index].visualComponent.MouseEnterTileEvent += HandleMouseEnterTileEvent;
					objectTiles[index].visualComponent.MouseDownOnTileEvent += HandleMouseDownOnTileEvent;
					objectTiles[index].visualComponent.MouseUpOnTileEvent += HandleMouseUpOnTileEvent;
				}
				objectTiles[index].currentTileGroupType = TileData.TileGroupEnum.Corridor;
				objectTiles[index].currentTileType = TileData.TileTypeEnum.Corridor;
			}
			LinkToObject(obj1);
			LinkToObject(obj2);
			if (obj1 != null)
			{
				obj1.LinkToObject(this);
			}
			if (obj2 != null)
			{
				obj2.LinkToObject(this);
			}
			this.corridorLayout = corridorLayout;
			this.corridorLength = corridorLength;
		}

		public void AttachEditor(GameEditorScript gameEditor)
		{
			ge = gameEditor;
			isInEditMode = true;
		}

		public void DetachEditor()
		{
			ge = null;
			isInEditMode = false;
		}

		public void DeActivate()
		{
			isActive = false;
			isMouseOver = false;
			ResetEdge();
		}

		public void Activate()
		{
			if (!isActive)
			{
				isActive = true;
				HighlightEdge(HighlightTypeEnum.Selected);
			}
		}

		public void Destroy()
		{
			isDestroying = true;
			ClearTiles();
		}

		private void ClearTiles()
		{
			foreach (TileData objectTile in objectTiles)
			{
				objectTile.isEdge = false;
				objectTile.currentTileGroupType = TileData.TileGroupEnum.Undefined;
				objectTile.currentTileType = TileData.TileTypeEnum.Undefined;
				objectTile.visualComponent.SetColor(GlobalSettings.editorUnusedTileColor);
				objectTile.visualComponent.MouseDownOnTileEvent -= HandleMouseDownOnTileEvent;
				objectTile.visualComponent.MouseEnterTileEvent -= HandleMouseEnterTileEvent;
				objectTile.visualComponent.MouseUpOnTileEvent -= HandleMouseUpOnTileEvent;
				if (_linkedObjects.Count <= 0)
				{
					continue;
				}
				foreach (IGEObject linkedObject in _linkedObjects)
				{
					if (linkedObject != null)
					{
						Debug.Log("Breaking Link");
						linkedObject.BreakLinkToObject(this);
					}
				}
				_linkedObjects.Clear();
			}
		}

		public List<TileData> GetEdgeTiles()
		{
			return null;
		}

		public List<TileData> GetHorizEdgeTiles(int side)
		{
			return null;
		}

		public List<TileData> GetVertEdgeTiles(int side)
		{
			return null;
		}

		public void HighlightEdge(HighlightTypeEnum highlightType)
		{
			foreach (TileData objectTile in objectTiles)
			{
				if (objectTile != null)
				{
					switch (highlightType)
					{
					case HighlightTypeEnum.MouseOver:
						objectTile.visualComponent.SetColor(Color.blue);
						break;
					case HighlightTypeEnum.Selected:
						objectTile.visualComponent.SetColor(Color.red);
						break;
					}
				}
			}
		}

		public void MouseNoLongerOver()
		{
			isMouseOver = false;
			if (!isActive)
			{
				ResetEdge();
			}
		}

		public void ResetEdge()
		{
			if (!isMouseOver && !isActive)
			{
				foreach (TileData objectTile in objectTiles)
				{
					if (isDestroying)
					{
						objectTile.visualComponent.SetColor(GlobalSettings.editorUnusedTileColor);
					}
					else
					{
						int x = objectTile.boardPosition.x;
						int y = objectTile.boardPosition.y;
						if (Table.Instance != null)
						{
							if (linkedObjects[0] != null && linkedObjects[1] != null)
							{
								if (GameEditorScript.IsWhiteTile(x, y))
								{
									objectTile.visualComponent.SetColor(baseLightColor);
								}
								else
								{
									objectTile.visualComponent.SetColor(baseDarkColor);
								}
							}
							else
							{
								objectTile.visualComponent.SetColor(GameEditorScript.AirlockColor);
							}
						}
					}
				}
				return;
			}
			if (isActive)
			{
				HighlightEdge(HighlightTypeEnum.Selected);
			}
			else if (isMouseOver)
			{
				HighlightEdge(HighlightTypeEnum.MouseOver);
			}
		}

		public void SetLLCorner(int c, int r)
		{
		}

		public void SetLLCorner(Vector2 corner)
		{
		}

		public void RefreshTileProperties()
		{
		}

		public void Move(int cDelta, int rDelta)
		{
		}

		public void Rotate()
		{
		}

		public Rect GetRect()
		{
			return default(Rect);
		}

		public Rect GetBoundsAsRect()
		{
			return default(Rect);
		}

		public void GetBoundsAsRect(out Rect rect)
		{
			rect = default(Rect);
		}

		public void BreakLinkToObject(IGEObject obj)
		{
			_linkedObjects.Remove(obj);
		}

		public void LinkToObject(IGEObject obj)
		{
			_linkedObjects.Add(obj);
		}

		public void ExternalMouseDown(TileData tile)
		{
			HandleMouseDownOnTileEvent(tile);
		}

		private void HandleMouseDownOnTileEvent(TileData tile)
		{
			if (!isActive)
			{
				if (ge != null && ge.CanChangeActiveObject)
				{
					Activate();
					if (this.ObjectActivateChangedEvent != null)
					{
						this.ObjectActivateChangedEvent(this, true);
					}
				}
			}
			else if (this.MouseDownOnObjectEvent != null)
			{
				this.MouseDownOnObjectEvent(this, tile.boardPosition.x, tile.boardPosition.y);
			}
		}

		public void ExternalMouseUp(TileData tile)
		{
			HandleMouseUpOnTileEvent(tile);
		}

		private void HandleMouseUpOnTileEvent(TileData tile)
		{
			if (this.MouseUpOnObjectEvent != null)
			{
				this.MouseUpOnObjectEvent(this);
			}
		}

		private void HandleMouseEnterTileEvent(TileData tile)
		{
			isMouseOver = true;
			if (this.MouseEnterRoomEvent != null)
			{
				this.MouseEnterRoomEvent(this);
			}
		}

		public void SetMetaData(string name, string value)
		{
			if (metaDataList == null)
			{
				metaDataList = new List<DesignedDungeonManager.MetaData>();
			}
			int count = metaDataList.Count;
			for (int i = 0; i < count; i++)
			{
				DesignedDungeonManager.MetaData metaData = metaDataList[i];
				if (metaData.name == name)
				{
					metaData.value = value;
					return;
				}
			}
			metaDataList.Add(new DesignedDungeonManager.MetaData(name, value));
		}

		public string GetMetaDataValue(string name)
		{
			if (metaDataList == null)
			{
				return string.Empty;
			}
			foreach (DesignedDungeonManager.MetaData metaData in metaDataList)
			{
				if (metaData.name == name)
				{
					return metaData.value;
				}
			}
			return string.Empty;
		}
	}
}
