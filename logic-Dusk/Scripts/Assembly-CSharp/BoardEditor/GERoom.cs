using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace BoardEditor
{
	public class GERoom : IGEObject
	{
		private enum MouseDownTypeEnum
		{
			None = 0,
			MouseDownOnObject = 1,
			MouseDownOnEdge = 2
		}

		private bool _isActive;

		private Vector2 _currentLLCorner = new Vector2(-1f, -1f);

		private List<IGEObject> _linkedObjects = new List<IGEObject>();

		private TileData[,] objectTiles;

		private GameEditorScript ge;

		private MouseDownTypeEnum currentMouseDownType;

		private int width = 8;

		private int height = 8;

		public string ID { get; set; }

		public bool isMouseOver { get; private set; }

		public bool isActive
		{
			get
			{
				return _isActive;
			}
			private set
			{
				_isActive = value;
			}
		}

		public bool isInEditMode { get; private set; }

		public bool canRotate
		{
			get
			{
				return false;
			}
		}

		public GEObjectTypeEnum objectType
		{
			get
			{
				return GEObjectTypeEnum.Room;
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

		public Color baseLightColor
		{
			get
			{
				return Color.white;
			}
		}

		public Color baseDarkColor
		{
			get
			{
				return Color.gray;
			}
		}

		public int Width
		{
			get
			{
				return width;
			}
		}

		public int Height
		{
			get
			{
				return height;
			}
		}

		public List<DesignedDungeonManager.MetaData> metaDataList { get; private set; }

		public int settingPowerInletIndex { get; set; }

		public event CommonEvents.MDownOnObjectEventHandler MouseDownOnObjectEvent;

		public event CommonEvents.MUpOnObjectEventHandler MouseUpOnObjectEvent;

		public event CommonEvents.ObjectMEnterEventHandler MouseEnterRoomEvent;

		public event CommonEvents.ObjectActivateChangedEventHandler ObjectActivateChangedEvent;

		private GERoom()
		{
			objectTiles = new TileData[width, height];
		}

		public GERoom(int width, int height)
		{
			Initialize(width, height);
		}

		private void Initialize(int width, int height)
		{
			this.width = width;
			this.height = height;
			objectTiles = new TileData[width, height];
		}

		public void AttachEditor(GameEditorScript ge)
		{
			Debug.Log("Attached Editor to Room");
			this.ge = ge;
			isInEditMode = true;
		}

		public void DetachEditor()
		{
			ge = null;
			isInEditMode = false;
		}

		public void SetLLCorner(Vector2 corner)
		{
			SetLLCorner(corner, false);
		}

		public void SetLLCorner(Vector2 corner, bool ignoreLinkedCheck)
		{
			SetLLCorner((int)corner.x, (int)corner.y, ignoreLinkedCheck);
		}

		public void SetLLCorner(int c, int r)
		{
			SetLLCorner(c, r, false);
		}

		public void SetLLCorner(int c, int r, bool ignoreLinkedCheck)
		{
			if (c < 0 || r < 0)
			{
				return;
			}
			_currentLLCorner.x = c;
			_currentLLCorner.y = r;
			int num = c + width;
			int num2 = r + height;
			if (num >= 36)
			{
				num = 36;
			}
			if (num2 >= 28)
			{
				num2 = 28;
			}
			ClearTiles();
			int num3 = 0;
			int num4 = 0;
			IEnumerable<IGEObject> source = linkedObjects.Where((IGEObject x) => x != null && x.GetType() != typeof(GECorridor));
			List<Rect> list = null;
			int num5 = source.Count();
			if (!ignoreLinkedCheck && num5 > 0)
			{
				list = new List<Rect>();
				for (int num6 = 0; num6 < num5; num6++)
				{
					IGEObject iGEObject = source.ElementAt(num6);
					list.Add(iGEObject.GetRect());
				}
			}
			for (int num7 = c; num7 < num; num7++)
			{
				for (int num8 = r; num8 < num2; num8++)
				{
					if (!ignoreLinkedCheck)
					{
						bool flag = false;
						for (int num9 = 0; num9 < num5; num9++)
						{
							if (list[num9].Contains(DesignedDungeonManager.tiles[num7, num8].boardPosition.position))
							{
								flag = true;
								break;
							}
						}
						if (flag)
						{
							continue;
						}
					}
					objectTiles[num3, num4] = DesignedDungeonManager.tiles[num7, num8];
					objectTiles[num3, num4].RoomX = num3;
					objectTiles[num3, num4].RoomY = num4;
					if (objectTiles[num3, num4].visualComponent != null)
					{
						objectTiles[num3, num4].visualComponent.MouseEnterTileEvent -= HandleMouseEnterTileEvent;
						objectTiles[num3, num4].visualComponent.MouseDownOnTileEvent -= HandleMouseDownOnTileEvent;
						objectTiles[num3, num4].visualComponent.MouseUpOnTileEvent -= HandleMouseUpOnTileEvent;
						objectTiles[num3, num4].visualComponent.MouseEnterTileEvent += HandleMouseEnterTileEvent;
						objectTiles[num3, num4].visualComponent.MouseDownOnTileEvent += HandleMouseDownOnTileEvent;
						objectTiles[num3, num4].visualComponent.MouseUpOnTileEvent += HandleMouseUpOnTileEvent;
					}
					objectTiles[num3, num4].currentTileGroupType = TileData.TileGroupEnum.Room;
					objectTiles[num3, num4].currentTileType = TileData.TileTypeEnum.Standard;
					if (num4 == 0 || num4 == height - 1 || num3 == 0 || num3 == width - 1)
					{
						objectTiles[num3, num4].isEdge = true;
						if (objectTiles[num3, num4].visualComponent != null)
						{
							objectTiles[num3, num4].visualComponent.MouseDownOnEdgeEvent -= HandleMouseDownOnEdgeEvent;
							objectTiles[num3, num4].visualComponent.MouseDownOnEdgeEvent += HandleMouseDownOnEdgeEvent;
						}
						if (num3 == 0 && num4 == 0)
						{
							objectTiles[num3, num4].edgeType = TileData.EdgeTypeEnum.BottomLeft;
						}
						else if (num3 == width - 1 && num4 == 0)
						{
							objectTiles[num3, num4].edgeType = TileData.EdgeTypeEnum.BottomRight;
						}
						else if (num3 == 0 && num4 == height - 1)
						{
							objectTiles[num3, num4].edgeType = TileData.EdgeTypeEnum.TopLeft;
						}
						else if (num3 == width - 1 && num4 == height - 1)
						{
							objectTiles[num3, num4].edgeType = TileData.EdgeTypeEnum.TopRight;
						}
						else if (num3 == 0)
						{
							objectTiles[num3, num4].edgeType = TileData.EdgeTypeEnum.Left;
						}
						else if (num3 == width - 1)
						{
							objectTiles[num3, num4].edgeType = TileData.EdgeTypeEnum.Right;
						}
						else if (num4 == 0)
						{
							objectTiles[num3, num4].edgeType = TileData.EdgeTypeEnum.Bottom;
						}
						else if (num4 == height - 1)
						{
							objectTiles[num3, num4].edgeType = TileData.EdgeTypeEnum.Top;
						}
					}
					if (objectTiles[num3, num4].visualComponent != null)
					{
						if (GameEditorScript.IsWhiteTile(num7, num8))
						{
							objectTiles[num3, num4].visualComponent.SetColor(baseLightColor);
						}
						else
						{
							objectTiles[num3, num4].visualComponent.SetColor(baseDarkColor);
						}
					}
					num4++;
				}
				num3++;
				num4 = 0;
			}
		}

		public void RefreshTileProperties()
		{
			int num = (int)_currentLLCorner.x + width;
			int num2 = (int)_currentLLCorner.y + height;
			if (num >= 36)
			{
				num = 36;
			}
			if (num2 >= 28)
			{
				num2 = 28;
			}
			int num3 = 0;
			int num4 = 0;
			for (int i = (int)_currentLLCorner.x; i < num; i++)
			{
				for (int j = (int)_currentLLCorner.y; j < num2; j++)
				{
					if (num4 == 0 || num4 == height - 1 || num3 == 0 || num3 == width - 1)
					{
						objectTiles[num3, num4].isEdge = true;
						if (num3 == 0 && num4 == 0)
						{
							objectTiles[num3, num4].edgeType = TileData.EdgeTypeEnum.BottomLeft;
						}
						else if (num3 == width - 1 && num4 == 0)
						{
							objectTiles[num3, num4].edgeType = TileData.EdgeTypeEnum.BottomRight;
						}
						else if (num3 == 0 && num4 == height - 1)
						{
							objectTiles[num3, num4].edgeType = TileData.EdgeTypeEnum.TopLeft;
						}
						else if (num3 == width - 1 && num4 == height - 1)
						{
							objectTiles[num3, num4].edgeType = TileData.EdgeTypeEnum.TopRight;
						}
						else if (num3 == 0)
						{
							objectTiles[num3, num4].edgeType = TileData.EdgeTypeEnum.Left;
						}
						else if (num3 == width - 1)
						{
							objectTiles[num3, num4].edgeType = TileData.EdgeTypeEnum.Right;
						}
						else if (num4 == 0)
						{
							objectTiles[num3, num4].edgeType = TileData.EdgeTypeEnum.Bottom;
						}
						else if (num4 == height - 1)
						{
							objectTiles[num3, num4].edgeType = TileData.EdgeTypeEnum.Top;
						}
					}
					if (objectTiles[num3, num4].visualComponent != null)
					{
						objectTiles[num3, num4].visualComponent.ClearAllHighlights();
						if (GameEditorScript.IsWhiteTile(i, j))
						{
							objectTiles[num3, num4].visualComponent.SetColor(baseLightColor);
						}
						else
						{
							objectTiles[num3, num4].visualComponent.SetColor(baseDarkColor);
						}
					}
					num4++;
				}
				num3++;
				num4 = 0;
			}
		}

		public void RefreshLinkedProperties(IGEObject objectToIgnore)
		{
			foreach (IGEObject linkedObject in linkedObjects)
			{
				if (linkedObject != null && (objectToIgnore == null || linkedObject != objectToIgnore))
				{
					linkedObject.RefreshTileProperties();
				}
			}
		}

		public void Move(int cDelta, int rDelta)
		{
			int num = (int)currentLLCorner.x + cDelta;
			int num2 = (int)currentLLCorner.y + rDelta;
			if (num < 0 || num2 < 0 || num > 36 - width || num2 > 28 - height)
			{
				return;
			}
			if (_linkedObjects.Count > 0)
			{
				if (linkedObjects.Where((IGEObject x) => x != null && x.GetType() == typeof(GECorridor)).Count() > 0)
				{
					return;
				}
				SetLLCorner(num, num2);
				IEnumerable<IGEObject> source = linkedObjects.Where((IGEObject x) => x != null && x.GetType() != typeof(GECorridor));
				int num3 = source.Count();
				for (int num4 = 0; num4 < num3; num4++)
				{
					IGEObject iGEObject = source.ElementAt(num4);
					int c = (int)iGEObject.currentLLCorner.x + cDelta;
					int r = (int)iGEObject.currentLLCorner.y + rDelta;
					iGEObject.SetLLCorner(c, r);
				}
			}
			else
			{
				SetLLCorner(num, num2);
			}
			HighlightEdge(HighlightTypeEnum.Selected);
		}

		public void Rotate()
		{
		}

		public Rect GetRect()
		{
			return new Rect(currentLLCorner.x, currentLLCorner.y, width, height);
		}

		public Rect GetBoundsAsRect()
		{
			return new Rect(currentLLCorner.x, currentLLCorner.y, currentLLCorner.x + (float)width, currentLLCorner.y + (float)height);
		}

		public void GetBoundsAsRect(out Rect rect)
		{
			rect = new Rect(currentLLCorner.x, currentLLCorner.y, currentLLCorner.x + (float)width, currentLLCorner.y + (float)height);
		}

		private void HandleMouseDownOnTileEvent(TileData tile)
		{
			if (tile.currentTileGroupType != TileData.TileGroupEnum.Room || currentMouseDownType == MouseDownTypeEnum.MouseDownOnEdge)
			{
				return;
			}
			if (isInEditMode)
			{
				if (!isActive)
				{
					if (ge.CanChangeActiveObject)
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
			else if (this.MouseDownOnObjectEvent != null)
			{
				this.MouseDownOnObjectEvent(this, tile.boardPosition.x, tile.boardPosition.y);
			}
			currentMouseDownType = MouseDownTypeEnum.MouseDownOnObject;
		}

		public void ExternalMouseDown(TileData tile)
		{
			HandleMouseDownOnTileEvent(tile);
		}

		private void HandleMouseDownOnEdgeEvent(TileData tile)
		{
			if (currentMouseDownType == MouseDownTypeEnum.MouseDownOnObject)
			{
				return;
			}
			if (GameEditorScript.Instance.isShowingShadow)
			{
				GameEditorScript.Instance.ActAsIfMouseDownOnTile(tile);
				return;
			}
			foreach (IGEObject linkedObject in linkedObjects)
			{
				if (linkedObject.GetRect().Contains(tile.boardPosition.position))
				{
					linkedObject.ExternalMouseDown(tile);
					return;
				}
			}
			if (!isInEditMode || !isActive)
			{
				return;
			}
			currentMouseDownType = MouseDownTypeEnum.MouseDownOnEdge;
			ClearTiles();
			int num = 1;
			if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
			{
				num = -1;
			}
			switch (tile.edgeType)
			{
			case TileData.EdgeTypeEnum.Top:
				height += 1 * num;
				break;
			case TileData.EdgeTypeEnum.Bottom:
				_currentLLCorner.y -= 1 * num;
				height += 1 * num;
				break;
			case TileData.EdgeTypeEnum.Left:
				_currentLLCorner.x -= 1 * num;
				width += 1 * num;
				break;
			case TileData.EdgeTypeEnum.Right:
				width += 1 * num;
				break;
			case TileData.EdgeTypeEnum.BottomRight:
				width += 1 * num;
				_currentLLCorner.y -= 1 * num;
				height += 1 * num;
				break;
			case TileData.EdgeTypeEnum.BottomLeft:
				width += 1 * num;
				_currentLLCorner.y -= 1 * num;
				_currentLLCorner.x -= 1 * num;
				height += 1 * num;
				break;
			case TileData.EdgeTypeEnum.TopRight:
				width += 1 * num;
				height += 1 * num;
				break;
			case TileData.EdgeTypeEnum.TopLeft:
				width += 1 * num;
				_currentLLCorner.x -= 1 * num;
				height += 1 * num;
				break;
			}
			Initialize(width, height);
			SetLLCorner(_currentLLCorner, true);
			foreach (IGEObject linkedObject2 in linkedObjects)
			{
				linkedObject2.RefreshTileProperties();
			}
		}

		public void ExternalMouseUp(TileData tile)
		{
			HandleMouseUpOnTileEvent(tile);
		}

		private void HandleMouseUpOnTileEvent(TileData tile)
		{
			if (GameEditorScript.Instance.activeGEObject != null)
			{
				foreach (IGEObject linkedObject in linkedObjects)
				{
					if (linkedObject == GameEditorScript.Instance.activeGEObject)
					{
						linkedObject.ExternalMouseUp(tile);
						return;
					}
				}
			}
			if (this.MouseUpOnObjectEvent != null)
			{
				this.MouseUpOnObjectEvent(this);
			}
			currentMouseDownType = MouseDownTypeEnum.None;
		}

		private void HandleMouseEnterTileEvent(TileData tile)
		{
			isMouseOver = true;
			if (this.MouseEnterRoomEvent != null)
			{
				this.MouseEnterRoomEvent(this);
			}
			if (isActive && tile.isEdge && currentMouseDownType != MouseDownTypeEnum.MouseDownOnObject)
			{
				HighlightEdge(HighlightTypeEnum.Selected, tile.edgeType);
			}
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
			ClearTiles();
		}

		public void HighlightEdge(HighlightTypeEnum highlightType)
		{
			HighlightEdge(highlightType, TileData.EdgeTypeEnum.Unknown);
		}

		public void HighlightEdge(HighlightTypeEnum highlightType, TileData.EdgeTypeEnum edgeType)
		{
			IEnumerable<IGEObject> source = linkedObjects.Where((IGEObject x) => x != null && x.GetType() != typeof(GECorridor));
			List<Rect> list = null;
			int num = source.Count();
			if (num > 0)
			{
				list = new List<Rect>();
				for (int num2 = 0; num2 < num; num2++)
				{
					IGEObject iGEObject = source.ElementAt(num2);
					list.Add(iGEObject.GetRect());
				}
			}
			for (int num3 = 0; num3 < width; num3++)
			{
				for (int num4 = 0; num4 < height; num4++)
				{
					bool flag = false;
					for (int num5 = 0; num5 < num; num5++)
					{
						Rect rect = list[num5];
						try
						{
							if (objectTiles[num3, num4] != null && rect.Contains(objectTiles[num3, num4].boardPosition.position))
							{
								flag = true;
								break;
							}
						}
						catch (Exception)
						{
							int num6 = 0;
							num6++;
						}
					}
					if (flag || objectTiles[num3, num4] == null || !objectTiles[num3, num4].isEdge)
					{
						continue;
					}
					switch (highlightType)
					{
					case HighlightTypeEnum.MouseOver:
						objectTiles[num3, num4].visualComponent.SetColor(Color.blue);
						break;
					case HighlightTypeEnum.Selected:
						if (edgeType == TileData.EdgeTypeEnum.Unknown || objectTiles[num3, num4].edgeType != edgeType)
						{
							objectTiles[num3, num4].visualComponent.SetColor(Color.red);
						}
						else
						{
							objectTiles[num3, num4].visualComponent.SetColor(Color.green);
						}
						break;
					}
				}
			}
		}

		public List<TileData> GetEdgeTiles()
		{
			List<TileData> list = new List<TileData>();
			for (int i = 0; i < width; i++)
			{
				for (int j = 0; j < height; j++)
				{
					if (objectTiles[i, j] != null && objectTiles[i, j].isEdge)
					{
						list.Add(objectTiles[i, j]);
					}
				}
			}
			return list;
		}

		public List<TileData> GetHorizEdgeTiles(int side)
		{
			if (side < 0 || side > 1)
			{
				return null;
			}
			List<TileData> list = new List<TileData>();
			for (int i = 0; i < width; i++)
			{
				int num = ((side == 0) ? (height - 1) : 0);
				if (objectTiles[i, num] != null && objectTiles[i, num].isEdge)
				{
					list.Add(objectTiles[i, num]);
				}
			}
			return list;
		}

		public List<TileData> GetVertEdgeTiles(int side)
		{
			if (side < 0 || side > 1)
			{
				return null;
			}
			List<TileData> list = new List<TileData>();
			for (int i = 0; i < height; i++)
			{
				int num = ((side != 0) ? (width - 1) : 0);
				if (objectTiles[num, i] != null && objectTiles[num, i].isEdge)
				{
					list.Add(objectTiles[num, i]);
				}
			}
			return list;
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
			IEnumerable<IGEObject> source = linkedObjects.Where((IGEObject x) => x != null && x.GetType() != typeof(GECorridor));
			List<Rect> list = null;
			int num = source.Count();
			if (num > 0)
			{
				list = new List<Rect>();
				for (int num2 = 0; num2 < num; num2++)
				{
					IGEObject iGEObject = source.ElementAt(num2);
					list.Add(iGEObject.GetRect());
				}
			}
			for (int num3 = 0; num3 < width; num3++)
			{
				for (int num4 = 0; num4 < height; num4++)
				{
					if (objectTiles[num3, num4] == null || !objectTiles[num3, num4].isEdge)
					{
						continue;
					}
					bool flag = false;
					for (int num5 = 0; num5 < num; num5++)
					{
						if (list[num5].Contains(objectTiles[num3, num4].boardPosition.position))
						{
							flag = true;
							break;
						}
					}
					if (flag)
					{
						continue;
					}
					if (isMouseOver && objectTiles[num3, num4].isEdge)
					{
						objectTiles[num3, num4].visualComponent.SetColor(Color.blue);
					}
					else if (Table.Instance != null)
					{
						if (GameEditorScript.IsWhiteTile((int)((float)num3 + currentLLCorner.x), (int)((float)num4 + currentLLCorner.y)))
						{
							objectTiles[num3, num4].visualComponent.SetColor(baseLightColor);
						}
						else
						{
							objectTiles[num3, num4].visualComponent.SetColor(baseDarkColor);
						}
					}
				}
			}
		}

		private void ClearTiles()
		{
			for (int i = 0; i < width; i++)
			{
				for (int j = 0; j < height; j++)
				{
					if (objectTiles[i, j] != null)
					{
						objectTiles[i, j].isEdge = false;
						objectTiles[i, j].currentTileGroupType = TileData.TileGroupEnum.Undefined;
						objectTiles[i, j].currentTileType = TileData.TileTypeEnum.Undefined;
						objectTiles[i, j].visualComponent.SetColor(GlobalSettings.editorUnusedTileColor);
						objectTiles[i, j].visualComponent.MouseDownOnTileEvent -= HandleMouseDownOnTileEvent;
						objectTiles[i, j].visualComponent.MouseDownOnEdgeEvent -= HandleMouseDownOnEdgeEvent;
						objectTiles[i, j].visualComponent.MouseEnterTileEvent -= HandleMouseEnterTileEvent;
						objectTiles[i, j].visualComponent.MouseUpOnTileEvent -= HandleMouseUpOnTileEvent;
					}
				}
			}
		}

		public void BreakLinkToObject(IGEObject obj)
		{
			Debug.Log("Start Count: " + _linkedObjects.Count);
			_linkedObjects.Remove(obj);
			Debug.Log("Ending Count: " + _linkedObjects.Count);
		}

		public void LinkToObject(IGEObject obj)
		{
			_linkedObjects.Add(obj);
		}

		public TileData GetTile(int x, int y)
		{
			if (x >= 0 && x < width && y >= 0 && y < height)
			{
				return objectTiles[x, y];
			}
			return null;
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
