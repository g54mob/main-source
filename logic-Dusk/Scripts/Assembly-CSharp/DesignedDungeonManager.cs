using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using BoardEditor;
using UnityEngine;

public static class DesignedDungeonManager
{
	public class MetaData
	{
		public string name { get; private set; }

		public string value { get; set; }

		private MetaData()
		{
		}

		public MetaData(string name, string value)
		{
			this.name = name;
			this.value = value;
		}
	}

	public static TileData[,] tiles { get; set; }

	public static void InitializeTiles()
	{
		tiles = new TileData[36, 28];
		for (int i = 0; i < 36; i++)
		{
			for (int j = 0; j < 28; j++)
			{
				tiles[i, j] = new TileData();
				tiles[i, j].boardPosition = new BoardPosition(i, j);
				tiles[i, j].currentTileType = TileData.TileTypeEnum.Undefined;
			}
		}
	}

	public static bool LoadBoardFromXml(string xmlText, ref List<IGEObject> boardObjects, ref List<MetaData> shipMetaData)
	{
		if (boardObjects == null)
		{
			boardObjects = new List<IGEObject>();
		}
		XmlDocument xmlDocument = new XmlDocument();
		xmlDocument.LoadXml(xmlText);
		XmlNode parentNode = xmlDocument.SelectSingleNode("/Board/Objects");
		LoadMetaData(ref shipMetaData, parentNode);
		XmlNodeList xmlNodeList = xmlDocument.SelectNodes("/Board/Objects/Obj[@type='Room']");
		if (xmlNodeList.Count > 0)
		{
			foreach (XmlNode item in xmlNodeList)
			{
				string text = string.Empty;
				int c = 0;
				int r = 0;
				int width = 0;
				int height = 0;
				int settingPowerInletIndex = 0;
				if (item.Attributes["id"] != null)
				{
					text = item.Attributes["id"].Value;
				}
				if (string.IsNullOrEmpty(text))
				{
					break;
				}
				if (item.Attributes["posX"] != null)
				{
					c = Convert.ToInt32(item.Attributes["posX"].Value);
				}
				if (item.Attributes["posY"] != null)
				{
					r = Convert.ToInt32(item.Attributes["posY"].Value);
				}
				if (item.Attributes["sizeX"] != null)
				{
					width = Convert.ToInt32(item.Attributes["sizeX"].Value);
				}
				if (item.Attributes["sizeY"] != null)
				{
					height = Convert.ToInt32(item.Attributes["sizeY"].Value);
				}
				if (item.Attributes["powerInletIdx"] != null)
				{
					settingPowerInletIndex = Convert.ToInt32(item.Attributes["powerInletIdx"].Value);
				}
				GERoom gERoom = new GERoom(width, height);
				boardObjects.Add(gERoom);
				gERoom.ID = text;
				gERoom.SetLLCorner(c, r);
				gERoom.settingPowerInletIndex = settingPowerInletIndex;
				IGEObject geObject = gERoom;
				LoadMetaData(ref geObject, item);
			}
		}
		xmlNodeList = xmlDocument.SelectNodes("/Board/Objects/Obj[@type='Corridor']");
		if (xmlNodeList.Count > 0)
		{
			foreach (XmlNode item2 in xmlNodeList)
			{
				string text2 = string.Empty;
				int num = 0;
				int num2 = 0;
				GECorridor.CorridorLayoutEnum corridorLayoutEnum = GECorridor.CorridorLayoutEnum.Undefined;
				int num3 = 0;
				IGEObject iGEObject = null;
				IGEObject iGEObject2 = null;
				bool isStartingAirlock = false;
				if (item2.Attributes["id"] != null)
				{
					text2 = item2.Attributes["id"].Value;
				}
				if (string.IsNullOrEmpty(text2))
				{
					break;
				}
				if (item2.Attributes["posX"] != null)
				{
					num = Convert.ToInt32(item2.Attributes["posX"].Value);
				}
				if (item2.Attributes["posY"] != null)
				{
					num2 = Convert.ToInt32(item2.Attributes["posY"].Value);
				}
				if (item2.Attributes["layout"] != null)
				{
					corridorLayoutEnum = (GECorridor.CorridorLayoutEnum)(int)Enum.Parse(typeof(GECorridor.CorridorLayoutEnum), item2.Attributes["layout"].Value, true);
				}
				if (corridorLayoutEnum == GECorridor.CorridorLayoutEnum.Undefined)
				{
					break;
				}
				if (item2.Attributes["length"] != null)
				{
					num3 = Convert.ToInt32(item2.Attributes["length"].Value);
				}
				if (num3 <= 0)
				{
					break;
				}
				if (item2.Attributes["isStartingAirlock"] != null)
				{
					isStartingAirlock = Convert.ToBoolean(item2.Attributes["isStartingAirlock"].Value);
				}
				XmlNodeList xmlNodeList2 = item2.SelectNodes("Joins/Obj[@type='Room']");
				for (int i = 0; i < xmlNodeList2.Count; i++)
				{
					string text3 = string.Empty;
					XmlNode xmlNode3 = xmlNodeList2[i];
					if (xmlNode3.Attributes["id"] != null)
					{
						text3 = xmlNode3.Attributes["id"].Value;
					}
					if (string.IsNullOrEmpty(text3))
					{
						break;
					}
					bool flag = false;
					List<IGEObject> objectListByType = GetObjectListByType(boardObjects, GEObjectTypeEnum.Room);
					if (objectListByType == null)
					{
						continue;
					}
					int count = objectListByType.Count;
					for (int j = 0; j < count; j++)
					{
						IGEObject iGEObject3 = objectListByType[j];
						if (iGEObject3.ID == text3)
						{
							int num4 = i;
							if (xmlNode3.Attributes["side"] != null)
							{
								num4 = Convert.ToInt32(xmlNode3.Attributes["side"].Value);
							}
							if (num4 == 0)
							{
								iGEObject = iGEObject3;
							}
							else
							{
								iGEObject2 = iGEObject3;
							}
							flag = true;
							break;
						}
					}
					if (!flag)
					{
						break;
					}
				}
				if (iGEObject == null && iGEObject2 == null)
				{
					continue;
				}
				List<Vector2> list = new List<Vector2>(num3);
				list.Add(new Vector2(num, num2));
				if (corridorLayoutEnum == GECorridor.CorridorLayoutEnum.Horiz)
				{
					list.Add(new Vector2(num, num2 + 1));
				}
				else
				{
					list.Add(new Vector2(num + 1, num2));
				}
				for (int k = 1; k < num3; k++)
				{
					if (corridorLayoutEnum == GECorridor.CorridorLayoutEnum.Horiz)
					{
						list.Add(new Vector2(list[k - 1].x + 1f, list[k - 1].y));
						list.Add(new Vector2(list[k - 1].x + 1f, list[k - 1].y + 1f));
					}
					else
					{
						list.Add(new Vector2(list[k - 1].x, list[k - 1].y + 1f));
						list.Add(new Vector2(list[k - 1].x + 1f, list[k - 1].y + 1f));
					}
				}
				GECorridor gECorridor = new GECorridor();
				gECorridor.InitCorridor(list, iGEObject, iGEObject2, corridorLayoutEnum, num3);
				gECorridor.isStartingAirlock = isStartingAirlock;
				if (boardObjects != null)
				{
					boardObjects.Add(gECorridor);
					int index = boardObjects.Count - 1;
					boardObjects[index].ID = text2;
				}
				IGEObject geObject2 = gECorridor;
				LoadMetaData(ref geObject2, item2);
			}
		}
		xmlNodeList = xmlDocument.SelectNodes("/Board/Objects/Obj[@type='PowerInlet']");
		if (xmlNodeList.Count > 0)
		{
			foreach (XmlNode item3 in xmlNodeList)
			{
				string text4 = string.Empty;
				int c2 = 0;
				int r2 = 0;
				int num5 = 0;
				int num6 = 0;
				if (item3.Attributes["id"] != null)
				{
					text4 = item3.Attributes["id"].Value;
				}
				if (string.IsNullOrEmpty(text4))
				{
					break;
				}
				if (item3.Attributes["posX"] != null)
				{
					c2 = Convert.ToInt32(item3.Attributes["posX"].Value);
				}
				if (item3.Attributes["posY"] != null)
				{
					r2 = Convert.ToInt32(item3.Attributes["posY"].Value);
				}
				GEPowerInlet gEPowerInlet = new GEPowerInlet(2, 2);
				boardObjects.Add(gEPowerInlet);
				gEPowerInlet.ID = text4;
				gEPowerInlet.SetLLCorner(c2, r2);
				IGEObject geObject3 = gEPowerInlet;
				LoadMetaData(ref geObject3, item3);
				XmlNodeList xmlNodeList3 = item3.SelectNodes("Joins/Obj[@type='Room']");
				if (xmlNodeList3.Count <= 0)
				{
					continue;
				}
				string text5 = string.Empty;
				XmlNode xmlNode5 = xmlNodeList3[0];
				if (xmlNode5.Attributes["id"] != null)
				{
					text5 = xmlNode5.Attributes["id"].Value;
				}
				if (string.IsNullOrEmpty(text5))
				{
					break;
				}
				bool flag2 = false;
				List<IGEObject> objectListByType2 = GetObjectListByType(boardObjects, GEObjectTypeEnum.Room);
				if (objectListByType2 == null)
				{
					continue;
				}
				int count2 = objectListByType2.Count;
				for (int l = 0; l < count2; l++)
				{
					IGEObject iGEObject4 = objectListByType2[l];
					if (iGEObject4.ID == text5)
					{
						iGEObject4.LinkToObject(gEPowerInlet);
						gEPowerInlet.LinkToObject(iGEObject4);
						flag2 = true;
						break;
					}
				}
				if (!flag2)
				{
					break;
				}
			}
		}
		xmlNodeList = xmlDocument.SelectNodes("/Board/Objects/Obj[@type='FuelAccess']");
		if (xmlNodeList.Count > 0)
		{
			foreach (XmlNode item4 in xmlNodeList)
			{
				string text6 = string.Empty;
				int c3 = 0;
				int r3 = 0;
				int num7 = 0;
				int num8 = 0;
				if (item4.Attributes["id"] != null)
				{
					text6 = item4.Attributes["id"].Value;
				}
				if (string.IsNullOrEmpty(text6))
				{
					break;
				}
				if (item4.Attributes["posX"] != null)
				{
					c3 = Convert.ToInt32(item4.Attributes["posX"].Value);
				}
				if (item4.Attributes["posY"] != null)
				{
					r3 = Convert.ToInt32(item4.Attributes["posY"].Value);
				}
				GEFuelAccess gEFuelAccess = new GEFuelAccess(2, 2);
				boardObjects.Add(gEFuelAccess);
				gEFuelAccess.ID = text6;
				gEFuelAccess.SetLLCorner(c3, r3);
				IGEObject geObject4 = gEFuelAccess;
				LoadMetaData(ref geObject4, item4);
				XmlNodeList xmlNodeList4 = item4.SelectNodes("Joins/Obj[@type='Room']");
				if (xmlNodeList4.Count <= 0)
				{
					continue;
				}
				string text7 = string.Empty;
				XmlNode xmlNode7 = xmlNodeList4[0];
				if (xmlNode7.Attributes["id"] != null)
				{
					text7 = xmlNode7.Attributes["id"].Value;
				}
				if (string.IsNullOrEmpty(text7))
				{
					break;
				}
				bool flag3 = false;
				List<IGEObject> objectListByType3 = GetObjectListByType(boardObjects, GEObjectTypeEnum.Room);
				if (objectListByType3 == null)
				{
					continue;
				}
				int count3 = objectListByType3.Count;
				for (int m = 0; m < count3; m++)
				{
					IGEObject iGEObject5 = objectListByType3[m];
					if (iGEObject5.ID == text7)
					{
						iGEObject5.LinkToObject(gEFuelAccess);
						gEFuelAccess.LinkToObject(iGEObject5);
						flag3 = true;
						break;
					}
				}
				if (!flag3)
				{
					break;
				}
			}
		}
		xmlNodeList = xmlDocument.SelectNodes("/Board/Objects/Obj[@type='Terminal']");
		if (xmlNodeList.Count > 0)
		{
			foreach (XmlNode item5 in xmlNodeList)
			{
				string text8 = string.Empty;
				int c4 = 0;
				int r4 = 0;
				int width2 = 0;
				int height2 = 0;
				if (item5.Attributes["id"] != null)
				{
					text8 = item5.Attributes["id"].Value;
				}
				if (string.IsNullOrEmpty(text8))
				{
					break;
				}
				if (item5.Attributes["posX"] != null)
				{
					c4 = Convert.ToInt32(item5.Attributes["posX"].Value);
				}
				if (item5.Attributes["posY"] != null)
				{
					r4 = Convert.ToInt32(item5.Attributes["posY"].Value);
				}
				if (item5.Attributes["sizeX"] != null)
				{
					width2 = Convert.ToInt32(item5.Attributes["sizeX"].Value);
				}
				if (item5.Attributes["sizeY"] != null)
				{
					height2 = Convert.ToInt32(item5.Attributes["sizeY"].Value);
				}
				GETerminal gETerminal = new GETerminal(width2, height2);
				boardObjects.Add(gETerminal);
				gETerminal.ID = text8;
				gETerminal.SetLLCorner(c4, r4);
				IGEObject geObject5 = gETerminal;
				LoadMetaData(ref geObject5, item5);
				XmlNodeList xmlNodeList5 = item5.SelectNodes("Joins/Obj[@type='Room']");
				if (xmlNodeList5.Count <= 0)
				{
					continue;
				}
				string text9 = string.Empty;
				XmlNode xmlNode9 = xmlNodeList5[0];
				if (xmlNode9.Attributes["id"] != null)
				{
					text9 = xmlNode9.Attributes["id"].Value;
				}
				if (string.IsNullOrEmpty(text9))
				{
					break;
				}
				bool flag4 = false;
				List<IGEObject> objectListByType4 = GetObjectListByType(boardObjects, GEObjectTypeEnum.Room);
				if (objectListByType4 == null)
				{
					continue;
				}
				int count4 = objectListByType4.Count;
				for (int n = 0; n < count4; n++)
				{
					IGEObject iGEObject6 = objectListByType4[n];
					if (iGEObject6.ID == text9)
					{
						iGEObject6.LinkToObject(gETerminal);
						gETerminal.LinkToObject(iGEObject6);
						flag4 = true;
						break;
					}
				}
				if (!flag4)
				{
					break;
				}
			}
		}
		xmlNodeList = xmlDocument.SelectNodes("/Board/Objects/Obj[@type='Vent']");
		if (xmlNodeList.Count > 0)
		{
			foreach (XmlNode item6 in xmlNodeList)
			{
				string text10 = string.Empty;
				int c5 = 0;
				int r5 = 0;
				int width3 = 0;
				int height3 = 0;
				if (item6.Attributes["id"] != null)
				{
					text10 = item6.Attributes["id"].Value;
				}
				if (string.IsNullOrEmpty(text10))
				{
					break;
				}
				if (item6.Attributes["posX"] != null)
				{
					c5 = Convert.ToInt32(item6.Attributes["posX"].Value);
				}
				if (item6.Attributes["posY"] != null)
				{
					r5 = Convert.ToInt32(item6.Attributes["posY"].Value);
				}
				if (item6.Attributes["sizeX"] != null)
				{
					width3 = Convert.ToInt32(item6.Attributes["sizeX"].Value);
				}
				if (item6.Attributes["sizeY"] != null)
				{
					height3 = Convert.ToInt32(item6.Attributes["sizeY"].Value);
				}
				GEVent gEVent = new GEVent(width3, height3);
				boardObjects.Add(gEVent);
				gEVent.ID = text10;
				gEVent.SetLLCorner(c5, r5);
				IGEObject geObject6 = gEVent;
				LoadMetaData(ref geObject6, item6);
				XmlNodeList xmlNodeList6 = item6.SelectNodes("Joins/Obj[@type='Room']");
				if (xmlNodeList6.Count <= 0)
				{
					continue;
				}
				string text11 = string.Empty;
				XmlNode xmlNode11 = xmlNodeList6[0];
				if (xmlNode11.Attributes["id"] != null)
				{
					text11 = xmlNode11.Attributes["id"].Value;
				}
				if (string.IsNullOrEmpty(text11))
				{
					break;
				}
				bool flag5 = false;
				List<IGEObject> objectListByType5 = GetObjectListByType(boardObjects, GEObjectTypeEnum.Room);
				if (objectListByType5 == null)
				{
					continue;
				}
				int count5 = objectListByType5.Count;
				for (int num9 = 0; num9 < count5; num9++)
				{
					IGEObject iGEObject7 = objectListByType5[num9];
					if (iGEObject7.ID == text11)
					{
						iGEObject7.LinkToObject(gEVent);
						gEVent.LinkToObject(iGEObject7);
						flag5 = true;
						break;
					}
				}
				if (!flag5)
				{
					break;
				}
			}
		}
		xmlNodeList = xmlDocument.SelectNodes("/Board/Objects/Obj[@type='Defense']");
		if (xmlNodeList.Count > 0)
		{
			foreach (XmlNode item7 in xmlNodeList)
			{
				string text12 = string.Empty;
				int c6 = 0;
				int r6 = 0;
				int num10 = 0;
				int num11 = 0;
				if (item7.Attributes["id"] != null)
				{
					text12 = item7.Attributes["id"].Value;
				}
				if (string.IsNullOrEmpty(text12))
				{
					break;
				}
				if (item7.Attributes["posX"] != null)
				{
					c6 = Convert.ToInt32(item7.Attributes["posX"].Value);
				}
				if (item7.Attributes["posY"] != null)
				{
					r6 = Convert.ToInt32(item7.Attributes["posY"].Value);
				}
				GEDefense gEDefense = new GEDefense(1, 1);
				boardObjects.Add(gEDefense);
				gEDefense.ID = text12;
				gEDefense.SetLLCorner(c6, r6);
				IGEObject geObject7 = gEDefense;
				LoadMetaData(ref geObject7, item7);
				XmlNodeList xmlNodeList7 = item7.SelectNodes("Joins/Obj[@type='Room']");
				if (xmlNodeList7.Count <= 0)
				{
					continue;
				}
				string text13 = string.Empty;
				XmlNode xmlNode13 = xmlNodeList7[0];
				if (xmlNode13.Attributes["id"] != null)
				{
					text13 = xmlNode13.Attributes["id"].Value;
				}
				if (string.IsNullOrEmpty(text13))
				{
					break;
				}
				bool flag6 = false;
				List<IGEObject> objectListByType6 = GetObjectListByType(boardObjects, GEObjectTypeEnum.Room);
				if (objectListByType6 == null)
				{
					continue;
				}
				int count6 = objectListByType6.Count;
				for (int num12 = 0; num12 < count6; num12++)
				{
					IGEObject iGEObject8 = objectListByType6[num12];
					if (iGEObject8.ID == text13)
					{
						iGEObject8.LinkToObject(gEDefense);
						gEDefense.LinkToObject(iGEObject8);
						flag6 = true;
						break;
					}
				}
				if (!flag6)
				{
					break;
				}
			}
		}
		xmlNodeList = xmlDocument.SelectNodes("/Board/Objects/Obj[@type='SubSystem']");
		if (xmlNodeList.Count > 0)
		{
			foreach (XmlNode item8 in xmlNodeList)
			{
				string text14 = string.Empty;
				int c7 = 0;
				int r7 = 0;
				int num13 = 0;
				int num14 = 0;
				if (item8.Attributes["id"] != null)
				{
					text14 = item8.Attributes["id"].Value;
				}
				if (string.IsNullOrEmpty(text14))
				{
					break;
				}
				if (item8.Attributes["posX"] != null)
				{
					c7 = Convert.ToInt32(item8.Attributes["posX"].Value);
				}
				if (item8.Attributes["posY"] != null)
				{
					r7 = Convert.ToInt32(item8.Attributes["posY"].Value);
				}
				GESubSystem gESubSystem = new GESubSystem(1, 1);
				boardObjects.Add(gESubSystem);
				gESubSystem.ID = text14;
				gESubSystem.SetLLCorner(c7, r7);
				IGEObject geObject8 = gESubSystem;
				LoadMetaData(ref geObject8, item8);
				XmlNodeList xmlNodeList8 = item8.SelectNodes("Joins/Obj[@type='Room']");
				if (xmlNodeList8.Count <= 0)
				{
					continue;
				}
				string text15 = string.Empty;
				XmlNode xmlNode15 = xmlNodeList8[0];
				if (xmlNode15.Attributes["id"] != null)
				{
					text15 = xmlNode15.Attributes["id"].Value;
				}
				if (string.IsNullOrEmpty(text15))
				{
					break;
				}
				bool flag7 = false;
				List<IGEObject> objectListByType7 = GetObjectListByType(boardObjects, GEObjectTypeEnum.Room);
				if (objectListByType7 == null)
				{
					continue;
				}
				int count7 = objectListByType7.Count;
				for (int num15 = 0; num15 < count7; num15++)
				{
					IGEObject iGEObject9 = objectListByType7[num15];
					if (iGEObject9.ID == text15)
					{
						iGEObject9.LinkToObject(gESubSystem);
						gESubSystem.LinkToObject(iGEObject9);
						flag7 = true;
						break;
					}
				}
				if (!flag7)
				{
					break;
				}
			}
		}
		Rect rect = new Rect(float.MaxValue, float.MaxValue, float.MinValue, float.MinValue);
		for (int num16 = 0; num16 < 36; num16++)
		{
			for (int num17 = 0; num17 < 28; num17++)
			{
				TileData tileData = tiles[num16, num17];
				tileData.BoardX = num16;
				tileData.BoardY = num17;
				if (tileData.currentTileType != TileData.TileTypeEnum.Undefined)
				{
					float num18 = num16 * 1;
					float num19 = (float)num17 * 0.05f;
					float num20 = num18 + 1f;
					float num21 = num19 + 0.05f;
					if (num18 < rect.x)
					{
						rect.x = num18;
					}
					if (num20 > rect.width)
					{
						rect.width = num20;
					}
					if (num19 < rect.y)
					{
						rect.y = num19;
					}
					if (num21 > rect.height)
					{
						rect.height = num21;
					}
				}
			}
		}
		return true;
	}

	private static void LoadMetaData(ref IGEObject geObject, XmlNode parentNode)
	{
		XmlNodeList xmlNodeList = parentNode.SelectNodes("Meta/Data");
		if (xmlNodeList == null)
		{
			return;
		}
		foreach (XmlNode item in xmlNodeList)
		{
			string text = string.Empty;
			string text2 = string.Empty;
			if (item.Attributes["name"] != null)
			{
				text = item.Attributes["name"].Value;
			}
			if (item.Attributes["value"] != null)
			{
				text2 = item.Attributes["value"].Value;
			}
			if (text != string.Empty && text2 != null)
			{
				geObject.SetMetaData(text, text2);
			}
		}
	}

	private static void LoadMetaData(ref List<MetaData> metaDataList, XmlNode parentNode)
	{
		XmlNodeList xmlNodeList = parentNode.SelectNodes("Meta/Data");
		if (xmlNodeList == null)
		{
			return;
		}
		foreach (XmlNode item in xmlNodeList)
		{
			string text = string.Empty;
			string text2 = string.Empty;
			if (item.Attributes["name"] != null)
			{
				text = item.Attributes["name"].Value;
			}
			if (item.Attributes["value"] != null)
			{
				text2 = item.Attributes["value"].Value;
			}
			if (text != string.Empty && text2 != null)
			{
				if (metaDataList == null)
				{
					metaDataList = new List<MetaData>();
				}
				metaDataList.Add(new MetaData(text, text2));
			}
		}
	}

	public static List<IGEObject> GetObjectListByType(List<IGEObject> boardObjects, GEObjectTypeEnum objectType)
	{
		if (boardObjects != null)
		{
			List<IGEObject> list = new List<IGEObject>();
			{
				foreach (IGEObject boardObject in boardObjects)
				{
					if (boardObject.objectType == GEObjectTypeEnum.Room)
					{
						list.Add(boardObject);
					}
				}
				return list;
			}
		}
		return null;
	}

	public static void BuildDesignedDungeon(List<IGEObject> boardObjects, bool skipDungeonBuilderCall, bool offsetToFinalPosition)
	{
		Rect designedDungeonRect = GetDesignedDungeonRect();
		int num = 0;
		int num2 = 0;
		if (offsetToFinalPosition)
		{
			if (designedDungeonRect.x > 0f)
			{
				num = (int)designedDungeonRect.x;
				designedDungeonRect.width -= designedDungeonRect.x;
				designedDungeonRect.x = 0f;
			}
			if (designedDungeonRect.y > 0f)
			{
				num2 = (int)designedDungeonRect.y;
				designedDungeonRect.height -= designedDungeonRect.y;
				designedDungeonRect.y = 0f;
			}
		}
		DungeonGenerator.GetInstance().InitializeDungeon((int)designedDungeonRect.width, (int)designedDungeonRect.height);
		IEnumerable<IGEObject> enumerable = boardObjects.Where((IGEObject x) => x != null && x.GetType() == typeof(GERoom));
		Dictionary<IGEObject, DungeonRoom> dictionary = new Dictionary<IGEObject, DungeonRoom>();
		if (enumerable != null)
		{
			int num3 = enumerable.Count();
			DungeonRoom[] array = new DungeonRoom[num3];
			for (int num4 = 0; num4 < num3; num4++)
			{
				IGEObject iGEObject = enumerable.ElementAt(num4);
				Rect boundsAsRect = iGEObject.GetBoundsAsRect();
				Coordinate2D origin = new Coordinate2D((int)boundsAsRect.x - num, (int)boundsAsRect.y - num2);
				Coordinate2D dimensions = new Coordinate2D((int)(boundsAsRect.width - boundsAsRect.x), (int)(boundsAsRect.height - boundsAsRect.y));
				DungeonRoom dungeonRoom = new DungeonRoom(origin, dimensions, null);
				dungeonRoom.metaDataList = iGEObject.metaDataList;
				array[num4] = dungeonRoom;
				IGEObject iGEObject2 = iGEObject.linkedObjects.FirstOrDefault((IGEObject x) => x != null && x.GetType() == typeof(GEPowerInlet));
				dungeonRoom.AddPowerGrid(((GERoom)iGEObject).settingPowerInletIndex);
				if (iGEObject2 != null)
				{
					boundsAsRect = iGEObject2.GetBoundsAsRect();
					origin = new Coordinate2D((int)boundsAsRect.x - num, (int)boundsAsRect.y - num2);
					dungeonRoom.powerInlet = new DungeonBoardPowerInlet(origin);
					dungeonRoom.powerInlet.metaDataList = iGEObject2.metaDataList;
				}
				IGEObject iGEObject3 = iGEObject.linkedObjects.FirstOrDefault((IGEObject x) => x != null && x.GetType() == typeof(GEFuelAccess));
				if (iGEObject3 != null)
				{
					boundsAsRect = iGEObject3.GetBoundsAsRect();
					origin = new Coordinate2D((int)boundsAsRect.x - num, (int)boundsAsRect.y - num2);
					dungeonRoom.fuelAccess = new DungeonBoardFuelAccess(origin);
					dungeonRoom.fuelAccess.metaDataList = iGEObject3.metaDataList;
				}
				IGEObject iGEObject4 = iGEObject.linkedObjects.FirstOrDefault((IGEObject x) => x != null && x.GetType() == typeof(GETerminal));
				if (iGEObject4 != null)
				{
					boundsAsRect = iGEObject4.GetBoundsAsRect();
					origin = new Coordinate2D((int)boundsAsRect.x - num, (int)boundsAsRect.y - num2);
					dungeonRoom.terminal = new DungeonBoardTerminal(origin, boundsAsRect.y == boundsAsRect.height - 1f);
					dungeonRoom.terminal.metaDataList = iGEObject4.metaDataList;
				}
				IGEObject iGEObject5 = iGEObject.linkedObjects.FirstOrDefault((IGEObject x) => x != null && x.GetType() == typeof(GEDefense));
				if (iGEObject5 != null)
				{
					DungeonRoom dungeonRoom2 = null;
					boundsAsRect = iGEObject5.GetBoundsAsRect();
					origin = new Coordinate2D((int)boundsAsRect.x - num, (int)boundsAsRect.y - num2);
					dungeonRoom.defense = new DungeonBoardDefense(origin);
					if (dungeonRoom.terminal == null)
					{
						int num5 = array.Length;
						for (int num6 = 0; num6 < num5 - 1; num6++)
						{
							if (array[num6] != null && array[num6].powerGrids.Contains(((GERoom)iGEObject).settingPowerInletIndex) && array[num6].terminal != null)
							{
								dungeonRoom2 = array[num6];
								break;
							}
						}
					}
					else
					{
						dungeonRoom2 = dungeonRoom;
					}
					if (dungeonRoom2 != null)
					{
						dungeonRoom2.terminal.defense = new DungeonBoardDefense(origin);
					}
					dungeonRoom.defense.metaDataList = iGEObject5.metaDataList;
					if (dungeonRoom2 != null)
					{
						dungeonRoom2.terminal.defense.metaDataList = iGEObject5.metaDataList;
					}
				}
				IEnumerable<IGEObject> enumerable2 = iGEObject.linkedObjects.Where((IGEObject x) => x != null && x.GetType() == typeof(GESubSystem));
				foreach (IGEObject item in enumerable2)
				{
					boundsAsRect = item.GetBoundsAsRect();
					origin = new Coordinate2D((int)boundsAsRect.x - num, (int)boundsAsRect.y - num2);
					DungeonBoardShipSubSystems dungeonBoardShipSubSystems = new DungeonBoardShipSubSystems(origin, false);
					dungeonBoardShipSubSystems.metaDataList = item.metaDataList;
					dungeonRoom.AddSubSystem(dungeonBoardShipSubSystems);
				}
				IGEObject iGEObject6 = iGEObject.linkedObjects.FirstOrDefault((IGEObject x) => x != null && x.GetType() == typeof(GEVent));
				if (iGEObject6 != null)
				{
					boundsAsRect = iGEObject6.GetBoundsAsRect();
					origin = new Coordinate2D((int)boundsAsRect.x - num, (int)boundsAsRect.y - num2);
					dungeonRoom.vent = new DungeonBoardVent(origin, boundsAsRect.y == boundsAsRect.height - 1f);
					dungeonRoom.vent.metaDataList = iGEObject6.metaDataList;
				}
				dictionary.Add(enumerable.ElementAt(num4), dungeonRoom);
			}
			DungeonGenerator.GetInstance().SetRoomTiles(array);
		}
		IEnumerable<IGEObject> enumerable3 = boardObjects.Where((IGEObject x) => x != null && x.GetType() == typeof(GECorridor));
		if (enumerable3 != null)
		{
			int num7 = enumerable3.Count();
			DungeonDoor[] array2 = new DungeonDoor[num7];
			for (int num8 = 0; num8 < num7; num8++)
			{
				bool flag = false;
				IGEObject iGEObject7 = enumerable3.ElementAt(num8);
				DungeonRoom dungeonRoom3 = null;
				DungeonRoom dungeonRoom4 = null;
				if (iGEObject7.linkedObjects[0] != null && dictionary.ContainsKey(iGEObject7.linkedObjects[0]))
				{
					dungeonRoom3 = dictionary[iGEObject7.linkedObjects[0]];
				}
				if (iGEObject7.linkedObjects[1] != null && dictionary.ContainsKey(iGEObject7.linkedObjects[1]))
				{
					dungeonRoom4 = dictionary[iGEObject7.linkedObjects[1]];
				}
				if (iGEObject7.linkedObjects[0] == null || iGEObject7.linkedObjects[1] == null)
				{
					flag = true;
					if (dungeonRoom3 == null)
					{
						DungeonRoom dungeonRoom5 = dungeonRoom3;
						dungeonRoom3 = dungeonRoom4;
						dungeonRoom4 = dungeonRoom5;
					}
				}
				else
				{
					bool flag2 = false;
					GECorridor gECorridor = (GECorridor)iGEObject7;
					if (gECorridor.corridorLayout == GECorridor.CorridorLayoutEnum.Horiz)
					{
						if (dungeonRoom3.origin.x > dungeonRoom4.origin.x)
						{
							flag2 = true;
						}
					}
					else if (dungeonRoom3.origin.y > dungeonRoom4.origin.y)
					{
						flag2 = true;
					}
					if (flag2)
					{
						DungeonRoom dungeonRoom6 = dungeonRoom3;
						dungeonRoom3 = dungeonRoom4;
						dungeonRoom4 = dungeonRoom6;
					}
				}
				Coordinate2D coordinate2D = new Coordinate2D(iGEObject7.currentLLCorner);
				coordinate2D.x -= num;
				coordinate2D.y -= num2;
				array2[num8] = new DungeonDoor(coordinate2D, (((GECorridor)iGEObject7).corridorLayout != GECorridor.CorridorLayoutEnum.Horiz) ? true : false);
				array2[num8].metaDataList = iGEObject7.metaDataList;
				if (dungeonRoom3 != null)
				{
					array2[num8].rooms.Add(dungeonRoom3);
					if (array2[num8].horizontal)
					{
						if (dungeonRoom3.origin.y < array2[num8].origin.y)
						{
							DungeonGenerator.GetInstance().tiles[array2[num8].origin.x, array2[num8].origin.y - 1].roomItemType = BoardTileRoomItemType.Doorway;
							DungeonGenerator.GetInstance().tiles[array2[num8].origin.x, array2[num8].origin.y - 1].roomItemType = BoardTileRoomItemType.Doorway;
						}
						else
						{
							DungeonGenerator.GetInstance().tiles[array2[num8].origin.x, array2[num8].origin.y + 1].roomItemType = BoardTileRoomItemType.Doorway;
							DungeonGenerator.GetInstance().tiles[array2[num8].origin.x, array2[num8].origin.y + 1].roomItemType = BoardTileRoomItemType.Doorway;
						}
					}
					else if (dungeonRoom3.origin.x < array2[num8].origin.x)
					{
						DungeonGenerator.GetInstance().tiles[array2[num8].origin.x - 1, array2[num8].origin.y + 1].roomItemType = BoardTileRoomItemType.Doorway;
						DungeonGenerator.GetInstance().tiles[array2[num8].origin.x - 1, array2[num8].origin.y].roomItemType = BoardTileRoomItemType.Doorway;
					}
					else
					{
						DungeonGenerator.GetInstance().tiles[array2[num8].origin.x + 2, array2[num8].origin.y + 1].roomItemType = BoardTileRoomItemType.Doorway;
						DungeonGenerator.GetInstance().tiles[array2[num8].origin.x + 2, array2[num8].origin.y].roomItemType = BoardTileRoomItemType.Doorway;
					}
				}
				if (dungeonRoom4 != null)
				{
					array2[num8].rooms.Add(dungeonRoom4);
					if (array2[num8].horizontal)
					{
						if (dungeonRoom4.origin.y < array2[num8].origin.y)
						{
							DungeonGenerator.GetInstance().tiles[array2[num8].origin.x, array2[num8].origin.y - 1].roomItemType = BoardTileRoomItemType.Doorway;
							DungeonGenerator.GetInstance().tiles[array2[num8].origin.x, array2[num8].origin.y - 1].roomItemType = BoardTileRoomItemType.Doorway;
						}
						else
						{
							DungeonGenerator.GetInstance().tiles[array2[num8].origin.x, array2[num8].origin.y + 1].roomItemType = BoardTileRoomItemType.Doorway;
							DungeonGenerator.GetInstance().tiles[array2[num8].origin.x, array2[num8].origin.y + 1].roomItemType = BoardTileRoomItemType.Doorway;
						}
					}
					else if (dungeonRoom4.origin.x < array2[num8].origin.x)
					{
						DungeonGenerator.GetInstance().tiles[array2[num8].origin.x - 1, array2[num8].origin.y + 1].roomItemType = BoardTileRoomItemType.Doorway;
						DungeonGenerator.GetInstance().tiles[array2[num8].origin.x - 1, array2[num8].origin.y].roomItemType = BoardTileRoomItemType.Doorway;
					}
					else
					{
						DungeonGenerator.GetInstance().tiles[array2[num8].origin.x + 2, array2[num8].origin.y + 1].roomItemType = BoardTileRoomItemType.Doorway;
						DungeonGenerator.GetInstance().tiles[array2[num8].origin.x + 2, array2[num8].origin.y].roomItemType = BoardTileRoomItemType.Doorway;
					}
				}
				if (flag)
				{
					array2[num8].airlock = flag;
					array2[num8].dontTranslateAirlock = true;
					array2[num8].initialDockingAirlock = ((GECorridor)iGEObject7).isStartingAirlock;
					if (dungeonRoom3 != null)
					{
						dungeonRoom3.SetAirlock(array2[num8]);
					}
					else
					{
						dungeonRoom4.SetAirlock(array2[num8]);
					}
				}
			}
			DungeonGenerator.GetInstance().SetDoorTiles(array2);
		}
		DungeonBuilder dungeonBuilder = DungeonBuilder.Instance;
		if (dungeonBuilder == null)
		{
			dungeonBuilder = (DungeonBuilder)UnityEngine.Object.FindObjectOfType(typeof(DungeonBuilder));
		}
		if (!skipDungeonBuilderCall)
		{
			dungeonBuilder.BuildDungeon(0f, 0f, DungeonTypeEnum.Derelict);
		}
	}

	public static Rect GetDesignedDungeonRect()
	{
		int length = tiles.GetLength(0);
		int length2 = tiles.GetLength(1);
		Rect result = new Rect(float.MaxValue, float.MaxValue, float.MinValue, float.MinValue);
		for (int i = 0; i < length; i++)
		{
			for (int j = 0; j < length2; j++)
			{
				if (tiles[i, j].currentTileGroupType != TileData.TileGroupEnum.Undefined)
				{
					if ((float)i < result.x)
					{
						result.x = i;
					}
					if ((float)j < result.y)
					{
						result.y = j;
					}
					if ((float)i > result.width)
					{
						result.width = i;
					}
					if ((float)j > result.height)
					{
						result.height = j;
					}
				}
			}
		}
		return result;
	}
}
