using System;
using System.Collections.Generic;
using UnityEngine;

namespace BoardEditor
{
	public class GECorridorEdit
	{
		private struct JoiningObjectStruct
		{
			public Dictionary<KeyValuePair<int, int>, KeyValuePair<int, int>> linkDict;

			public IGEObject obj1 { get; set; }

			public IGEObject obj2 { get; set; }
		}

		public delegate void CorriorRequestedEventHandler(List<Vector2> tilePositionList, IGEObject obj1, IGEObject obj2, GECorridor.CorridorLayoutEnum corridorLayout, int corridorLength);

		private bool _isActive;

		private List<GECorridorCollection> corridorList = new List<GECorridorCollection>();

		private Table gameTable;

		private GECorridorCollection mouseOverCorridor;

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

		public event CorriorRequestedEventHandler CorriorRequestedEvent;

		private GECorridorEdit()
		{
		}

		public GECorridorEdit(Table gameTable)
		{
			this.gameTable = gameTable;
		}

		public bool InitPlacement()
		{
			List<IGEObject> objectListByType = gameTable.GetObjectListByType(GEObjectTypeEnum.Room);
			List<JoiningObjectStruct> list = new List<JoiningObjectStruct>();
			List<JoiningObjectStruct> list2 = new List<JoiningObjectStruct>();
			List<JoiningObjectStruct> list3 = new List<JoiningObjectStruct>();
			int count = objectListByType.Count;
			for (int i = 0; i < count - 1; i++)
			{
				IGEObject iGEObject = objectListByType[i];
				List<TileData> edgeTiles = iGEObject.GetEdgeTiles();
				for (int j = i + 1; j < count; j++)
				{
					IGEObject iGEObject2 = objectListByType[j];
					List<TileData> edgeTiles2 = iGEObject2.GetEdgeTiles();
					List<int> list4 = new List<int>();
					List<int> list5 = new List<int>();
					List<int> list6 = new List<int>();
					List<int> list7 = new List<int>();
					foreach (TileData item3 in edgeTiles)
					{
						if (!list4.Contains(item3.boardPosition.x))
						{
							list4.Add(item3.boardPosition.x);
						}
						if (!list5.Contains(item3.boardPosition.y))
						{
							list5.Add(item3.boardPosition.y);
						}
					}
					foreach (TileData item4 in edgeTiles2)
					{
						if (list4.Contains(item4.boardPosition.x))
						{
							list6.Add(item4.boardPosition.x);
						}
						if (list5.Contains(item4.boardPosition.y))
						{
							list7.Add(item4.boardPosition.y);
						}
					}
					if (list6.Count <= 0 && list7.Count <= 0)
					{
						continue;
					}
					JoiningObjectStruct item = new JoiningObjectStruct
					{
						obj1 = iGEObject,
						obj2 = iGEObject2
					};
					item.linkDict = new Dictionary<KeyValuePair<int, int>, KeyValuePair<int, int>>();
					foreach (int item5 in list6)
					{
						KeyValuePair<int, int> keyValuePair = new KeyValuePair<int, int>(item5, -1);
						if (!item.linkDict.ContainsKey(keyValuePair))
						{
							item.linkDict.Add(keyValuePair, keyValuePair);
						}
					}
					foreach (int item6 in list7)
					{
						KeyValuePair<int, int> keyValuePair2 = new KeyValuePair<int, int>(-1, item6);
						if (!item.linkDict.ContainsKey(keyValuePair2))
						{
							item.linkDict.Add(keyValuePair2, keyValuePair2);
						}
					}
					list.Add(item);
				}
			}
			if (list.Count == 0)
			{
				Debug.LogWarning("No corridor possible");
				return true;
			}
			Debug.Log(list.Count + " pair of POSSIBLE rooms can be connected");
			list2 = new List<JoiningObjectStruct>(list.Count);
			foreach (JoiningObjectStruct item7 in list)
			{
				JoiningObjectStruct item2 = new JoiningObjectStruct
				{
					obj1 = item7.obj1,
					obj2 = item7.obj2
				};
				item2.linkDict = new Dictionary<KeyValuePair<int, int>, KeyValuePair<int, int>>();
				bool flag = true;
				int num = -1;
				int num2 = 1;
				Dictionary<KeyValuePair<int, int>, KeyValuePair<int, int>>.Enumerator enumerator6 = item7.linkDict.GetEnumerator();
				List<TileData> list8 = new List<TileData>();
				List<TileData> list9 = new List<TileData>();
				while (enumerator6.MoveNext())
				{
					if (!flag)
					{
						continue;
					}
					num = ((enumerator6.Current.Key.Key == -1) ? 1 : 0);
					if (num == 0)
					{
						if (item7.obj2.currentLLCorner.y < item7.obj1.currentLLCorner.y)
						{
							num2 = -1;
						}
						list8 = item7.obj1.GetHorizEdgeTiles((num2 != 1) ? 1 : 0);
						list9 = item7.obj2.GetHorizEdgeTiles((num2 == 1) ? 1 : 0);
					}
					else
					{
						if (item7.obj2.currentLLCorner.x < item7.obj1.currentLLCorner.x)
						{
							num2 = -1;
						}
						list8 = item7.obj1.GetVertEdgeTiles((num2 == 1) ? 1 : 0);
						list9 = item7.obj2.GetVertEdgeTiles((num2 != 1) ? 1 : 0);
					}
					flag = false;
					break;
				}
				foreach (TileData item8 in list8)
				{
					foreach (TileData item9 in list9)
					{
						bool flag2 = false;
						if (num == 0)
						{
							if (item8.boardPosition.x == item9.boardPosition.x && Math.Abs(item8.boardPosition.y - item9.boardPosition.y) == 3)
							{
								flag2 = true;
							}
						}
						else if (item8.boardPosition.y == item9.boardPosition.y && Math.Abs(item8.boardPosition.x - item9.boardPosition.x) == 3)
						{
							bool flag3 = false;
							foreach (TileData item10 in list8)
							{
								if (item10.boardPosition.y == item8.boardPosition.y - 1)
								{
									foreach (TileData item11 in list9)
									{
										if (item11.boardPosition.y == item10.boardPosition.y)
										{
											flag3 = true;
											break;
										}
									}
								}
								if (flag3)
								{
									break;
								}
								if (item10.boardPosition.y == item8.boardPosition.y + 1)
								{
									foreach (TileData item12 in list9)
									{
										if (item12.boardPosition.y == item10.boardPosition.y)
										{
											flag3 = true;
											break;
										}
									}
								}
								if (flag3)
								{
									break;
								}
							}
							if (flag3)
							{
								flag2 = true;
							}
						}
						if (flag2)
						{
							KeyValuePair<int, int> key = new KeyValuePair<int, int>(item8.boardPosition.x, item8.boardPosition.y);
							KeyValuePair<int, int> value = new KeyValuePair<int, int>(item9.boardPosition.x, item9.boardPosition.y);
							item2.linkDict.Add(key, value);
							break;
						}
					}
				}
				list2.Add(item2);
			}
			list3 = list2;
			if (corridorList != null && corridorList.Count > 0)
			{
				foreach (GECorridorCollection corridor in corridorList)
				{
					corridor.MouseOverCorriorEvent -= HandleCorColMouseOverCorriorEvent;
					corridor.MouseDownCorriorEvent -= HandleCorColMouseDownCorriorEvent;
				}
				corridorList.Clear();
			}
			foreach (JoiningObjectStruct item13 in list3)
			{
				Dictionary<KeyValuePair<int, int>, KeyValuePair<int, int>>.Enumerator enumerator14 = item13.linkDict.GetEnumerator();
				while (enumerator14.MoveNext())
				{
					KeyValuePair<int, int> key2 = enumerator14.Current.Key;
					KeyValuePair<int, int> value2 = enumerator14.Current.Value;
					int num3 = Math.Min(key2.Key, value2.Key);
					int num4 = Math.Max(key2.Key, value2.Key) + 1;
					int num5 = Math.Min(key2.Value, value2.Value);
					int num6 = Math.Max(key2.Value, value2.Value) + 1;
					bool flag4 = ((num3 != num4 - 1) ? true : false);
					GECorridorCollection gECorridorCollection = new GECorridorCollection();
					gECorridorCollection.corridorLayout = (flag4 ? GECorridor.CorridorLayoutEnum.Horiz : GECorridor.CorridorLayoutEnum.Vert);
					gECorridorCollection.corridorLength = ((!flag4) ? (num6 - num5 - 2) : (num4 - num3 - 2));
					GECorridorCollection gECorridorCollection2 = gECorridorCollection;
					gECorridorCollection2.MouseOverCorriorEvent += HandleCorColMouseOverCorriorEvent;
					gECorridorCollection2.MouseDownCorriorEvent += HandleCorColMouseDownCorriorEvent;
					gECorridorCollection2.obj1 = item13.obj1;
					gECorridorCollection2.obj2 = item13.obj2;
					if (flag4)
					{
						num6++;
						bool flag5 = false;
						for (int k = num3; k < num4; k++)
						{
							for (int l = num5; l < num6; l++)
							{
								if (k > num3 && k < num4 - 1 && gameTable.tiles[k, l].currentTileType != TileData.TileTypeEnum.Undefined)
								{
									flag5 = true;
									break;
								}
							}
							if (flag5)
							{
								break;
							}
						}
						if (flag5)
						{
							continue;
						}
						for (int m = num3; m < num4; m++)
						{
							for (int n = num5; n < num6; n++)
							{
								if (m > num3 && m < num4 - 1)
								{
									gameTable.tiles[m, n].visualComponent.SetTileHighLightColor(Color.blue, 0.5f, "corridor tint");
									gECorridorCollection2.AddTile(gameTable.tiles[m, n]);
								}
							}
							corridorList.Add(gECorridorCollection2);
						}
						continue;
					}
					num4++;
					bool flag6 = false;
					for (int num7 = num5; num7 < num6; num7++)
					{
						for (int num8 = num3; num8 < num4; num8++)
						{
							if (num7 > num5 && num7 < num6 - 1 && gameTable.tiles[num8, num7].currentTileType != TileData.TileTypeEnum.Undefined)
							{
								flag6 = true;
								break;
							}
						}
						if (flag6)
						{
							break;
						}
					}
					if (flag6)
					{
						continue;
					}
					for (int num9 = num5; num9 < num6; num9++)
					{
						for (int num10 = num3; num10 < num4; num10++)
						{
							if (num9 > num5 && num9 < num6 - 1)
							{
								gameTable.tiles[num10, num9].visualComponent.SetTileHighLightColor(Color.blue, 0.5f, "corridor tint");
								gECorridorCollection2.AddTile(gameTable.tiles[num10, num9]);
							}
						}
						corridorList.Add(gECorridorCollection2);
					}
				}
			}
			return true;
		}

		public bool InitAirlockPlacement()
		{
			List<IGEObject> objectListByType = gameTable.GetObjectListByType(GEObjectTypeEnum.Room);
			int count = objectListByType.Count;
			for (int i = 0; i < count; i++)
			{
				IGEObject iGEObject = objectListByType[i];
				List<TileData> edgeTiles = iGEObject.GetEdgeTiles();
				int count2 = edgeTiles.Count;
				for (int num = count2 - 1; num >= 0; num--)
				{
					bool flag = true;
					bool flag2 = false;
					int num2 = 0;
					int num3 = 0;
					int num4 = 0;
					int num5 = 0;
					TileData tileData = edgeTiles[num];
					int num6 = 0;
					if (tileData.RoomX == 0 && tileData.RoomY != 0 && tileData.RoomY != ((GERoom)iGEObject).Height)
					{
						num6 = 3;
						flag2 = true;
						num2 = tileData.BoardX - 3;
						num3 = tileData.BoardX + 1;
						num4 = tileData.BoardY - 1;
						num5 = tileData.BoardY;
						for (int num7 = tileData.BoardX - 1; num7 >= 0; num7--)
						{
							if (gameTable.tiles[num7, tileData.BoardY].currentTileType != TileData.TileTypeEnum.Undefined)
							{
								flag = false;
								break;
							}
						}
					}
					else if (tileData.RoomX == ((GERoom)iGEObject).Width - 1 && tileData.RoomY != 0 && tileData.RoomY != ((GERoom)iGEObject).Height)
					{
						num6 = 2;
						flag2 = true;
						num2 = tileData.BoardX;
						num3 = tileData.BoardX + 4;
						num4 = tileData.BoardY - 1;
						num5 = tileData.BoardY;
						int length = gameTable.tiles.GetLength(0);
						for (int j = tileData.BoardX + 1; j < length; j++)
						{
							if (gameTable.tiles[j, tileData.BoardY].currentTileType != TileData.TileTypeEnum.Undefined)
							{
								flag = false;
								break;
							}
						}
					}
					else if (tileData.RoomY == 0 && tileData.RoomX != 0 && tileData.RoomX != ((GERoom)iGEObject).Width)
					{
						num6 = 1;
						flag2 = false;
						num2 = tileData.BoardX - 1;
						num3 = tileData.BoardX;
						num4 = tileData.BoardY - 3;
						num5 = tileData.BoardY + 1;
						for (int num8 = tileData.BoardY - 1; num8 >= 0; num8--)
						{
							if (gameTable.tiles[tileData.BoardX, num8].currentTileType != TileData.TileTypeEnum.Undefined)
							{
								flag = false;
								break;
							}
						}
					}
					else if (tileData.RoomY == ((GERoom)iGEObject).Height - 1)
					{
						num6 = 0;
						flag2 = false;
						num2 = tileData.BoardX - 1;
						num3 = tileData.BoardX;
						num4 = tileData.BoardY;
						num5 = tileData.BoardY + 4;
						int length2 = gameTable.tiles.GetLength(1);
						for (int k = tileData.BoardY + 1; k < length2; k++)
						{
							if (gameTable.tiles[tileData.BoardX, k].currentTileType != TileData.TileTypeEnum.Undefined)
							{
								flag = false;
								break;
							}
						}
					}
					else
					{
						flag = false;
					}
					if (flag)
					{
						GECorridorCollection gECorridorCollection = new GECorridorCollection();
						gECorridorCollection.corridorLayout = (flag2 ? GECorridor.CorridorLayoutEnum.Horiz : GECorridor.CorridorLayoutEnum.Vert);
						gECorridorCollection.corridorLength = 2;
						GECorridorCollection gECorridorCollection2 = gECorridorCollection;
						gECorridorCollection2.MouseOverCorriorEvent += HandleCorColMouseOverCorriorEvent;
						gECorridorCollection2.MouseDownCorriorEvent += HandleCorColMouseDownCorriorEvent;
						if (num6 == 0 || num6 == 2)
						{
							gECorridorCollection2.obj1 = iGEObject;
							gECorridorCollection2.obj2 = null;
						}
						else
						{
							gECorridorCollection2.obj1 = null;
							gECorridorCollection2.obj2 = iGEObject;
						}
						if (flag2)
						{
							num5++;
							bool flag3 = false;
							for (int l = num2; l < num3; l++)
							{
								for (int m = num4; m < num5; m++)
								{
									if (l > num2 && l < num3 - 1 && (l < 0 || l >= gameTable.tiles.GetLength(0) || m < 0 || m >= gameTable.tiles.GetLength(1) || gameTable.tiles[l, m].currentTileType != TileData.TileTypeEnum.Undefined))
									{
										flag3 = true;
										break;
									}
								}
								if (flag3)
								{
									break;
								}
							}
							if (!flag3)
							{
								for (int n = num2; n < num3; n++)
								{
									for (int num9 = num4; num9 < num5; num9++)
									{
										if (n > num2 && n < num3 - 1)
										{
											gameTable.tiles[n, num9].visualComponent.SetTileHighLightColor(Color.blue, 0.5f, "corridor tint");
											gECorridorCollection2.AddTile(gameTable.tiles[n, num9]);
										}
									}
									corridorList.Add(gECorridorCollection2);
								}
							}
						}
						else
						{
							num3++;
							bool flag4 = false;
							for (int num10 = num4; num10 < num5; num10++)
							{
								for (int num11 = num2; num11 < num3; num11++)
								{
									if (num10 > num4 && num10 < num5 - 1 && (num11 < 0 || num11 >= gameTable.tiles.GetLength(0) || num10 < 0 || num10 >= gameTable.tiles.GetLength(1) || gameTable.tiles[num11, num10].currentTileType != TileData.TileTypeEnum.Undefined))
									{
										flag4 = true;
										break;
									}
								}
								if (flag4)
								{
									break;
								}
							}
							if (!flag4)
							{
								for (int num12 = num4; num12 < num5; num12++)
								{
									for (int num13 = num2; num13 < num3; num13++)
									{
										if (num12 > num4 && num12 < num5 - 1)
										{
											gameTable.tiles[num13, num12].visualComponent.SetTileHighLightColor(Color.blue, 0.5f, "corridor tint");
											gECorridorCollection2.AddTile(gameTable.tiles[num13, num12]);
										}
									}
									corridorList.Add(gECorridorCollection2);
								}
							}
						}
					}
				}
			}
			return true;
		}

		private void HandleCorColMouseDownCorriorEvent(GECorridorCollection corridor)
		{
			corridorList.Remove(corridor);
			if (this.CorriorRequestedEvent != null)
			{
				this.CorriorRequestedEvent(corridor.GetTilePositions(), corridor.obj1, corridor.obj2, corridor.corridorLayout, corridor.corridorLength);
			}
		}

		private void HandleCorColMouseOverCorriorEvent(GECorridorCollection corridor)
		{
			if (mouseOverCorridor != null)
			{
				mouseOverCorridor.MouseLeftCorridor();
			}
			mouseOverCorridor = corridor;
		}

		public void DeActivate()
		{
			foreach (GECorridorCollection corridor in corridorList)
			{
				corridor.ClearTiles();
			}
			corridorList.Clear();
		}
	}
}
