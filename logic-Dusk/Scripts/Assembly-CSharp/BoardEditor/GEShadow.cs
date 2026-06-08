using System.Collections.Generic;
using UnityEngine;

namespace BoardEditor
{
	public class GEShadow
	{
		private Vector2 _currentLLCorner = new Vector2(-1f, -1f);

		private bool _isPlaceable;

		public TileData[,] roomTiles;

		public int width;

		public int height;

		public bool isPaintbrush;

		public bool hasMoved;

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

		public bool isPlaceable
		{
			get
			{
				return _isPlaceable;
			}
			private set
			{
				_isPlaceable = value;
			}
		}

		public GEObjectTypeEnum shadowType { get; private set; }

		public bool canRotate
		{
			get
			{
				return shadowType == GEObjectTypeEnum.Terminal || shadowType == GEObjectTypeEnum.Vent;
			}
		}

		private GEShadow()
		{
		}

		public GEShadow(GEObjectTypeEnum shadowType, int width, int height)
		{
			this.shadowType = shadowType;
			this.width = width;
			this.height = height;
			Initialize();
		}

		private void Initialize()
		{
			roomTiles = new TileData[width, height];
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
			isPlaceable = true;
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
			for (int i = 0; i < width; i++)
			{
				for (int j = 0; j < height; j++)
				{
					if (roomTiles[i, j] != null)
					{
						roomTiles[i, j].visualComponent.ClearTileHighLightColor("shadow highlight");
					}
				}
			}
			int num3 = 0;
			int num4 = 0;
			int num5 = 0;
			int num6 = 0;
			bool flag = shadowType == GEObjectTypeEnum.FuelAccess;
			for (int k = c; k < num; k++)
			{
				for (int l = r; l < num2; l++)
				{
					roomTiles[num3, num4] = DesignedDungeonManager.tiles[k, l];
					bool flag2 = false;
					switch (shadowType)
					{
					case GEObjectTypeEnum.PowerInlet:
					case GEObjectTypeEnum.SubSystem:
						if (roomTiles[num3, num4].currentTileGroupType == TileData.TileGroupEnum.Room)
						{
							flag2 = true;
						}
						break;
					case GEObjectTypeEnum.Defense:
					case GEObjectTypeEnum.Terminal:
					case GEObjectTypeEnum.Vent:
						if (roomTiles[num3, num4].currentTileGroupType == TileData.TileGroupEnum.Room && roomTiles[num3, num4].isEdge)
						{
							flag2 = true;
						}
						break;
					case GEObjectTypeEnum.FuelAccess:
						if (roomTiles[num3, num4].currentTileGroupType == TileData.TileGroupEnum.Room)
						{
							num6++;
							if (roomTiles[num3, num4].isEdge)
							{
								num5++;
							}
							flag2 = true;
						}
						break;
					default:
						if (roomTiles[num3, num4].currentTileType == TileData.TileTypeEnum.Undefined)
						{
							flag2 = true;
						}
						break;
					}
					if (!flag)
					{
						if (flag2)
						{
							roomTiles[num3, num4].visualComponent.SetTileHighLightColor(Color.blue, 0.5f, "shadow highlight");
						}
						else
						{
							roomTiles[num3, num4].visualComponent.SetTileHighLightColor(Color.red, 0.5f, "shadow highlight");
							isPlaceable = false;
						}
					}
					num4++;
				}
				num3++;
				num4 = 0;
			}
			if (!flag)
			{
				return;
			}
			isPlaceable = false;
			if (num6 == 4 && num5 >= 2)
			{
				isPlaceable = true;
			}
			num3 = 0;
			num4 = 0;
			for (int m = c; m < num; m++)
			{
				for (int n = r; n < num2; n++)
				{
					if (isPlaceable)
					{
						roomTiles[num3, num4].visualComponent.SetTileHighLightColor(Color.blue, 0.5f, "shadow highlight");
					}
					else
					{
						roomTiles[num3, num4].visualComponent.SetTileHighLightColor(Color.red, 0.5f, "shadow highlight");
					}
					num4++;
				}
				num3++;
				num4 = 0;
			}
		}

		public void DeActivate()
		{
			for (int i = 0; i < width; i++)
			{
				for (int j = 0; j < height; j++)
				{
					if (roomTiles[i, j] != null)
					{
						roomTiles[i, j].visualComponent.ClearTileHighLightColor("shadow highlight");
					}
				}
			}
		}

		public void Move(int cDelta, int rDelta)
		{
			int num = (int)_currentLLCorner.x + cDelta;
			int num2 = (int)_currentLLCorner.y + rDelta;
			if (num >= 0 && num2 >= 0 && num <= 36 - width && num2 <= 28 - height)
			{
				SetLLCorner(num, num2);
				hasMoved = true;
			}
		}

		public void Rotate()
		{
			int num = height;
			height = width;
			width = num;
			Initialize();
			SetLLCorner(_currentLLCorner);
		}

		public List<TileData> getTiles()
		{
			List<TileData> list = new List<TileData>();
			for (int i = 0; i < width; i++)
			{
				for (int j = 0; j < height; j++)
				{
					if (roomTiles[i, j] != null)
					{
						list.Add(roomTiles[i, j]);
					}
				}
			}
			return list;
		}
	}
}
