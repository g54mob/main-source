using System.Collections.Generic;
using BoardEditor;
using UnityEngine;

public class GETerminal : IGEObject
{
	private enum MouseDownTypeEnum
	{
		None = 0,
		MouseDownOnObject = 1
	}

	private bool _isActive;

	private Vector2 _currentLLCorner = new Vector2(-1f, -1f);

	private List<IGEObject> _linkedObjects = new List<IGEObject>();

	private TileData[,] objectTiles;

	private GameEditorScript ge;

	private MouseDownTypeEnum currentMouseDownType;

	private int width = 2;

	private int height = 1;

	private bool isMoving;

	private Vector2 preMovePosition = Vector2.zero;

	private int preMoveWidth;

	private int preMoveHeight;

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
			return true;
		}
	}

	public GEObjectTypeEnum objectType
	{
		get
		{
			return GEObjectTypeEnum.Terminal;
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
			return GameEditorScript.TerminalColor;
		}
	}

	public Color baseDarkColor
	{
		get
		{
			return GameEditorScript.TerminalColor;
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

	public event CommonEvents.MDownOnObjectEventHandler MouseDownOnObjectEvent;

	public event CommonEvents.MUpOnObjectEventHandler MouseUpOnObjectEvent;

	public event CommonEvents.ObjectMEnterEventHandler MouseEnterRoomEvent;

	public event CommonEvents.ObjectActivateChangedEventHandler ObjectActivateChangedEvent;

	private GETerminal()
	{
		objectTiles = new TileData[width, height];
	}

	public GETerminal(int width, int height)
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
		Debug.Log("Attached Editor to Terminal");
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
		SetLLCorner((int)corner.x, (int)corner.y);
	}

	public void SetLLCorner(int c, int r)
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
		for (int i = c; i < num; i++)
		{
			for (int j = r; j < num2; j++)
			{
				objectTiles[num3, num4] = DesignedDungeonManager.tiles[i, j];
				objectTiles[num3, num4].edgeType = TileData.EdgeTypeEnum.Unknown;
				if (objectTiles[num3, num4].visualComponent != null)
				{
					objectTiles[num3, num4].visualComponent.MouseEnterTileEvent -= HandleMouseEnterTileEvent;
					objectTiles[num3, num4].visualComponent.MouseDownOnTileEvent -= HandleMouseDownOnTileEvent;
					objectTiles[num3, num4].visualComponent.MouseUpOnTileEvent -= HandleMouseUpOnTileEvent;
					objectTiles[num3, num4].visualComponent.MouseEnterTileEvent += HandleMouseEnterTileEvent;
					objectTiles[num3, num4].visualComponent.MouseDownOnTileEvent += HandleMouseDownOnTileEvent;
					objectTiles[num3, num4].visualComponent.MouseUpOnTileEvent += HandleMouseUpOnTileEvent;
				}
				objectTiles[num3, num4].currentTileGroupType = TileData.TileGroupEnum.Terminal;
				objectTiles[num3, num4].currentTileType = TileData.TileTypeEnum.Standard;
				if (objectTiles[num3, num4].visualComponent != null)
				{
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
				objectTiles[num3, num4].edgeType = TileData.EdgeTypeEnum.Unknown;
				if (objectTiles[num3, num4].visualComponent != null)
				{
					objectTiles[num3, num4].visualComponent.MouseEnterTileEvent -= HandleMouseEnterTileEvent;
					objectTiles[num3, num4].visualComponent.MouseDownOnTileEvent -= HandleMouseDownOnTileEvent;
					objectTiles[num3, num4].visualComponent.MouseUpOnTileEvent -= HandleMouseUpOnTileEvent;
					objectTiles[num3, num4].visualComponent.MouseEnterTileEvent += HandleMouseEnterTileEvent;
					objectTiles[num3, num4].visualComponent.MouseDownOnTileEvent += HandleMouseDownOnTileEvent;
					objectTiles[num3, num4].visualComponent.MouseUpOnTileEvent += HandleMouseUpOnTileEvent;
					if (GameEditorScript.IsWhiteTile(i, j))
					{
						objectTiles[num3, num4].visualComponent.SetColor(baseLightColor);
					}
					else
					{
						objectTiles[num3, num4].visualComponent.SetColor(baseDarkColor);
					}
				}
				objectTiles[num3, num4].currentTileGroupType = TileData.TileGroupEnum.Terminal;
				objectTiles[num3, num4].currentTileType = TileData.TileTypeEnum.Standard;
				num4++;
			}
			num3++;
			num4 = 0;
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
		Vector2 zero = Vector2.zero;
		zero.x = num;
		zero.y = num2;
		IGEObject iGEObject = linkedObjects[0];
		Rect boundsAsRect = iGEObject.GetBoundsAsRect();
		if (!(zero.x < boundsAsRect.x) && !(zero.x > boundsAsRect.width - 1f) && !(zero.y < boundsAsRect.y) && !(zero.y > boundsAsRect.height - 1f))
		{
			if (!isMoving)
			{
				isMoving = true;
				preMovePosition = currentLLCorner;
				preMoveWidth = width;
				preMoveHeight = height;
			}
			iGEObject.RefreshTileProperties();
			SetLLCorner(num, num2);
			HighlightEdge(HighlightTypeEnum.Selected);
			((GERoom)iGEObject).RefreshLinkedProperties(this);
		}
	}

	public void Rotate()
	{
		int num = height;
		height = width;
		width = num;
		Initialize(width, height);
		SetLLCorner(_currentLLCorner);
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

	public void ExternalMouseDown(TileData tile)
	{
		HandleMouseDownOnTileEvent(tile);
	}

	private void HandleMouseDownOnTileEvent(TileData tile)
	{
		if (isInEditMode)
		{
			if (!isActive)
			{
				if (linkedObjects[0].isActive)
				{
					linkedObjects[0].DeActivate();
					ge.ActAsIfMouseReleasedOnObject(linkedObjects[0]);
				}
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

	public void ExternalMouseUp(TileData tile)
	{
		HandleMouseUpOnTileEvent(tile);
	}

	private void HandleMouseUpOnTileEvent(TileData tile)
	{
		if (isMoving && linkedObjects.Count > 0)
		{
			isMoving = false;
			bool flag = false;
			IGEObject iGEObject = linkedObjects[0];
			Rect boundsAsRect = GetBoundsAsRect();
			Rect boundsAsRect2 = iGEObject.GetBoundsAsRect();
			if (boundsAsRect.x >= boundsAsRect2.x && boundsAsRect.width <= boundsAsRect2.width && (boundsAsRect.y == boundsAsRect2.y || boundsAsRect.y == boundsAsRect2.height - 1f))
			{
				flag = true;
			}
			else if (boundsAsRect.y >= boundsAsRect2.y && boundsAsRect.height <= boundsAsRect2.height && (boundsAsRect.x == boundsAsRect2.x || boundsAsRect.x == boundsAsRect2.width - 1f))
			{
				flag = true;
			}
			if (!flag)
			{
				ClearTiles();
				iGEObject.RefreshTileProperties();
				Initialize(preMoveWidth, preMoveHeight);
				SetLLCorner(preMovePosition);
				((GERoom)iGEObject).RefreshLinkedProperties(null);
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
		for (int i = 0; i < width; i++)
		{
			for (int j = 0; j < height; j++)
			{
				if (objectTiles[i, j] == null)
				{
					continue;
				}
				switch (highlightType)
				{
				case HighlightTypeEnum.MouseOver:
					objectTiles[i, j].visualComponent.SetColor(Color.blue);
					break;
				case HighlightTypeEnum.Selected:
					if (edgeType == TileData.EdgeTypeEnum.Unknown || objectTiles[i, j].edgeType != edgeType)
					{
						objectTiles[i, j].visualComponent.SetColor(Color.red);
					}
					else
					{
						objectTiles[i, j].visualComponent.SetColor(Color.green);
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
		for (int i = 0; i < width; i++)
		{
			for (int j = 0; j < height; j++)
			{
				if (objectTiles[i, j] == null || !objectTiles[i, j].isEdge)
				{
					continue;
				}
				if (isMouseOver && objectTiles[i, j].isEdge)
				{
					objectTiles[i, j].visualComponent.SetColor(Color.blue);
				}
				else if (Table.Instance != null)
				{
					if (GameEditorScript.IsWhiteTile((int)((float)i + currentLLCorner.x), (int)((float)j + currentLLCorner.y)))
					{
						objectTiles[i, j].visualComponent.SetColor(baseLightColor);
					}
					else
					{
						objectTiles[i, j].visualComponent.SetColor(baseDarkColor);
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
