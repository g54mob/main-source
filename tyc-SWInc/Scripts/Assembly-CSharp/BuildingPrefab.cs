using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;

public class BuildingPrefab : IFormatColorObject, IByteData
{
	public class SegmentObject : IByteData
	{
		public string Name;

		public SVector3 Position;

		public float Width;

		public bool Reversed;

		public int AtlasIndex;

		public SVector3[] Colors;

		public uint NetworkID;

		public SegmentObject(RoomSegment segment, int floorOffset, bool network, IRoom from)
		{
			Name = segment.name;
			Position = segment.transform.position + Vector3.up * 2f * floorOffset;
			Width = segment.WallWidth;
			Reversed = segment.Directional && (segment.ParentRooms[0] == null || from != segment.ParentRooms[0]);
			AtlasIndex = segment.AtlasIndex;
			Colors = new SVector3[3] { segment.ActualColorPrimary, segment.ActualColorSecondary, segment.ActualColorTertiary };
			NetworkID = (network ? segment.InitLocalNetworkID() : 0u);
		}

		public SegmentObject(uint networkID, string name, SVector3 position, float width, bool reversed, int atlasIndex, SVector3[] colors)
		{
			NetworkID = networkID;
			Name = name;
			Position = position;
			Width = width;
			Reversed = reversed;
			AtlasIndex = atlasIndex;
			Colors = colors;
		}

		public static SegmentObject ReadData(Stream st)
		{
			uint networkID = st.ReadUInt();
			string name = st.ReadStringUTF8();
			SVector3 position = st.ReadVector();
			float width = st.ReadFloat();
			bool reversed = st.ReadBool();
			int atlasIndex = st.ReadInt();
			SVector3[] colors = st.ReadArray((Func<Stream, SVector3>)((Stream s) => s.ReadColor(false)));
			return new SegmentObject(networkID, name, position, width, reversed, atlasIndex, colors);
		}

		public void WriteData(Stream st)
		{
			st.WriteUInt(NetworkID);
			st.WriteStringUTF8(Name);
			st.WriteVector(Position);
			st.WriteFloat(Width);
			st.WriteBool(Reversed);
			st.WriteInt(AtlasIndex);
			st.WriteArray(Colors, delegate(Stream s, SVector3 x)
			{
				s.WriteColor(x.ToColor32(), false);
			});
		}

		public SegmentObject(XMLParser.XMLNode node)
		{
			Name = node.GetNodeValue("Name");
			Position = SVector3.Deserialize(node.GetNodeValue("Position"));
			Width = (float)Convert.ToDouble(node.GetNodeValue("Width"));
			Reversed = Convert.ToBoolean(node.GetNodeValue("Reversed", false.ToString()));
			AtlasIndex = node.GetNodeValue("AtlasIndex", 0);
			if (node.Contains("Color1"))
			{
				Colors = new SVector3[3]
				{
					SVector3.Deserialize(node.GetNodeValue("Color1")),
					SVector3.Deserialize(node.GetNodeValue("Color2")),
					SVector3.Deserialize(node.GetNodeValue("Color3"))
				};
			}
			else
			{
				Colors = null;
			}
		}

		public XMLParser.XMLNode ToXmlNode()
		{
			XMLParser.XMLNode xMLNode = new XMLParser.XMLNode("Segment", new XMLParser.XMLNode("Name", Name), new XMLParser.XMLNode("Position", Position.Serialize(3)), new XMLParser.XMLNode("Width", Width.ToString()), new XMLParser.XMLNode("Color1", Colors[0].Serialize()), new XMLParser.XMLNode("Color2", Colors[1].Serialize()), new XMLParser.XMLNode("Color3", Colors[2].Serialize()), new XMLParser.XMLNode("AtlasIndex", AtlasIndex.ToString()));
			if (Reversed)
			{
				xMLNode.Children.Add(new XMLParser.XMLNode("Reversed", Reversed.ToString()));
			}
			return xMLNode;
		}
	}

	public class FurnitureObject : IByteData
	{
		public string Name;

		public uint ID;

		public SVector3 Position;

		public SVector3 Rotation;

		public SVector3 SnapPointOffset;

		public float RotationOffset;

		public int Floor;

		public float BoostValue;

		public uint Parent;

		public uint ParentNetworkRoom;

		public int SnapID;

		public int AtlasIndex;

		public int ServerID;

		public SVector3[] Colors;

		public string Replacement1;

		public string Replacement2;

		public string ComponentOutput;

		public float[] Signage;

		public bool IsReversed;

		public bool TypeOnly;

		public bool IsConstructionFurniture()
		{
			Furniture furnitureComponent = ObjectDatabase.Instance.GetFurnitureComponent(Name);
			if (furnitureComponent != null)
			{
				return furnitureComponent.IsConstructionFurniture();
			}
			return false;
		}

		public FurnitureObject(string name, uint id, SVector3 position, SVector3 rotation, float rotationOffset, int floor, uint parent, uint parentNetworkRoom, int snapID, int atlasIndex, SVector3[] colors, float[] signage, bool isReversed, SVector3 snapPointOffset)
		{
			Name = name;
			ID = id;
			Position = position;
			Rotation = rotation;
			RotationOffset = rotationOffset;
			Floor = floor;
			Parent = parent;
			ParentNetworkRoom = parentNetworkRoom;
			SnapID = snapID;
			AtlasIndex = atlasIndex;
			Colors = colors;
			Signage = signage;
			IsReversed = isReversed;
			SnapPointOffset = snapPointOffset;
		}

		public static FurnitureObject ReadData(Stream st)
		{
			uint id = st.ReadUInt();
			string name = st.ReadStringUTF8();
			SVector3 position = st.ReadVector();
			SVector3 rotation = st.ReadVector();
			float rotationOffset = st.ReadFloat();
			int floor = st.ReadInt();
			uint parent = st.ReadUInt();
			uint parentNetworkRoom = st.ReadUInt();
			int snapID = st.ReadInt();
			int atlasIndex = st.ReadInt();
			SVector3[] colors = st.ReadArray((Func<Stream, SVector3>)((Stream s) => s.ReadColor(false)));
			float[] signage = st.ReadArray((Stream s) => s.ReadFloat());
			bool isReversed = st.ReadBool();
			SVector3 snapPointOffset = st.ReadVector();
			return new FurnitureObject(name, id, position, rotation, rotationOffset, floor, parent, parentNetworkRoom, snapID, atlasIndex, colors, signage, isReversed, snapPointOffset);
		}

		public void WriteData(Stream st)
		{
			st.WriteUInt(ID);
			st.WriteStringUTF8(Name);
			st.WriteVector(Position);
			st.WriteVector(Rotation);
			st.WriteFloat(RotationOffset);
			st.WriteInt(Floor);
			st.WriteUInt(Parent);
			st.WriteUInt(ParentNetworkRoom);
			st.WriteInt(SnapID);
			st.WriteInt(AtlasIndex);
			st.WriteArray(Colors, delegate(Stream s, SVector3 x)
			{
				s.WriteColor(x.ToColor32(), false);
			});
			st.WriteArray(Signage, delegate(Stream s, float x)
			{
				s.WriteFloat(x);
			});
			st.WriteBool(IsReversed);
			st.WriteVector(SnapPointOffset);
		}

		public FurnitureObject(Furniture furn, bool local)
		{
			Name = furn.name;
			ID = ((local && (furn.NetworkID == 0 || furn.IsNetworkIDLocal())) ? furn.InitLocalNetworkID() : furn.NetworkID);
			Position = furn.OriginalPosition;
			Rotation = furn.transform.rotation;
			RotationOffset = furn.RotationOffset;
			Floor = furn.Floor;
			SnapPointOffset = furn.SnapPointOffset;
			if (furn.IsActivelySnapping)
			{
				Parent = (local ? furn.SnappedTo.Parent.InitLocalNetworkID() : furn.SnappedTo.Parent.NetworkID);
				SnapID = furn.SnappedTo.Id;
			}
			if (furn.NetworkParent != null)
			{
				ParentNetworkRoom = furn.NetworkParent.NetworkID;
			}
			else if (furn.Parent != null && !furn.Parent.Outside)
			{
				ParentNetworkRoom = furn.Parent.NetworkID;
			}
			IsReversed = furn.IsReversed;
			AtlasIndex = furn.AtlasIndex;
			Colors = new SVector3[3] { furn.ActualColorPrimary, furn.ActualColorSecondary, furn.ActualColorTertiary };
			ComponentOutput = furn.GetComponentOutput();
			BoostValue = furn.BoostValue;
			Replacement1 = furn.GetReplacement(0);
			Replacement2 = furn.GetReplacement(1);
			if (furn.Signage != null)
			{
				Signage = new float[6]
				{
					furn.Signage.Thickness,
					furn.Signage.Outline,
					furn.Signage.ShadowSize,
					furn.Signage.ShadowHor,
					furn.Signage.ShadowVert,
					furn.Signage.ShadowOpacity
				};
			}
		}

		public FurnitureObject(Furniture furn, int floorOffset, Dictionary<ServerGroup, int> sIDs)
		{
			Name = furn.name;
			ID = furn.DID;
			Position = furn.OriginalPosition + Vector3.up * 2f * floorOffset;
			Rotation = furn.transform.rotation;
			RotationOffset = furn.RotationOffset;
			SnapPointOffset = furn.SnapPointOffset;
			Floor = furn.Floor;
			Parent = (furn.IsActivelySnapping ? furn.SnappedTo.Parent.DID : 0u);
			SnapID = (furn.IsActivelySnapping ? furn.SnappedTo.Id : 0);
			IsReversed = furn.IsReversed;
			AtlasIndex = furn.AtlasIndex;
			Colors = new SVector3[3] { furn.ActualColorPrimary, furn.ActualColorSecondary, furn.ActualColorTertiary };
			ComponentOutput = furn.GetComponentOutput();
			BoostValue = furn.BoostValue;
			Replacement1 = furn.GetReplacement(0);
			Replacement2 = furn.GetReplacement(1);
			if (furn.Signage != null)
			{
				Signage = new float[6]
				{
					furn.Signage.Thickness,
					furn.Signage.Outline,
					furn.Signage.ShadowSize,
					furn.Signage.ShadowHor,
					furn.Signage.ShadowVert,
					furn.Signage.ShadowOpacity
				};
			}
			Server component = furn.GetComponent<Server>();
			if (component != null)
			{
				ServerID = sIDs.GetOrAdd(component.Group, (ServerGroup x) => sIDs.Count + 1);
			}
		}

		public FurnitureObject(XMLParser.XMLNode node)
		{
			Name = node.GetNodeValue("Name");
			ID = Convert.ToUInt32(node.GetNodeValue("ID"));
			Position = SVector3.Deserialize(node.GetNodeValue("Position"));
			Rotation = SVector3.Deserialize(node.GetNodeValue("Rotation"));
			SnapPointOffset = SVector3.Deserialize(node.GetNodeValue("SnapPointOffset", "0"));
			RotationOffset = (float)Convert.ToDouble(node.GetNodeValue("RotationOffset"));
			Parent = Convert.ToUInt32(node.GetNodeValue("Parent"));
			SnapID = Convert.ToInt32(node.GetNodeValue("SnapID"));
			IsReversed = node.GetNodeValue("IsReversed", false);
			AtlasIndex = node.GetNodeValue("AtlasIndex", 0);
			ServerID = node.GetNodeValue("ServerID", 0);
			Colors = new SVector3[3]
			{
				SVector3.Deserialize(node.GetNodeValue("Color1")),
				SVector3.Deserialize(node.GetNodeValue("Color2")),
				SVector3.Deserialize(node.GetNodeValue("Color3"))
			};
			ComponentOutput = node.GetNodeValue("ComponentOutput");
			Replacement1 = node.GetNodeValue("FirstReplacement");
			Replacement2 = node.GetNodeValue("SecondReplacement");
			string nodeValue = node.GetNodeValue("Signage");
			if (nodeValue != null)
			{
				Signage = nodeValue.Split(',').SelectInPlace((string x) => x.ConvertToFloatDef(0.5f));
			}
			BoostValue = node.GetNodeValue("BoostValue", 1f);
			TypeOnly = node.GetNodeValue("TypeOnly", false);
		}

		public XMLParser.XMLNode ToXmlNode()
		{
			XMLParser.XMLNode xMLNode = new XMLParser.XMLNode("Furniture", new XMLParser.XMLNode("Name", Name), new XMLParser.XMLNode("ID", ID.ToString()), new XMLParser.XMLNode("Position", Position.Serialize(3)), new XMLParser.XMLNode("Rotation", Rotation.Serialize()), new XMLParser.XMLNode("RotationOffset", RotationOffset.ToString()), new XMLParser.XMLNode("Parent", Parent.ToString()), new XMLParser.XMLNode("SnapID", SnapID.ToString()), new XMLParser.XMLNode("Color1", Colors[0].Serialize()), new XMLParser.XMLNode("Color2", Colors[1].Serialize()), new XMLParser.XMLNode("Color3", Colors[2].Serialize()), new XMLParser.XMLNode("AtlasIndex", AtlasIndex.ToString()));
			if (!SnapPointOffset.IsZero())
			{
				xMLNode.Children.Add(new XMLParser.XMLNode("SnapPointOffset", SnapPointOffset.Serialize(3)));
			}
			if (IsReversed)
			{
				xMLNode.Children.Add(new XMLParser.XMLNode("IsReversed", IsReversed.ToString()));
			}
			if (ComponentOutput != null)
			{
				xMLNode.Children.Add(new XMLParser.XMLNode("ComponentOutput", ComponentOutput));
			}
			if (Replacement1 != null)
			{
				xMLNode.Children.Add(new XMLParser.XMLNode("FirstReplacement", Replacement1));
			}
			if (Replacement2 != null)
			{
				xMLNode.Children.Add(new XMLParser.XMLNode("SecondReplacement", Replacement2));
			}
			if (Signage != null)
			{
				xMLNode.Children.Add(new XMLParser.XMLNode("Signage", string.Join(",", Signage.SelectInPlace((float x) => x.ToString()))));
			}
			if (ServerID > 0)
			{
				xMLNode.Children.Add(new XMLParser.XMLNode("ServerID", ServerID.ToString()));
			}
			if (BoostValue != 1f)
			{
				xMLNode.Children.Add(new XMLParser.XMLNode("BoostValue", BoostValue.ToString()));
			}
			return xMLNode;
		}
	}

	public class RoomObject : IByteData
	{
		public enum AtriumType
		{
			None = 0,
			Main = 1,
			Upper = 2,
			Balcony = 3
		}

		public string[] Materials;

		public SVector3[] Colors;

		public SVector3 Offset = new SVector3(0f, 0f, 0f, 1f);

		public bool Outdoor;

		public bool Pillar;

		public int Floor;

		public int[] Edges;

		public FurnitureObject[] Furniture;

		public SegmentObject[] Segments;

		public float Area;

		public WriteDictionary RoomData;

		public uint RoomGroupID;

		public bool Rentable;

		public int Atrium = -1;

		public int RoomHeight = 1;

		public SVector3 EColor1;

		public SVector3 EColor2;

		public SVector3 EColor3;

		public string Group;

		public bool Ignore;

		public RoomObject(string[] materials, SVector3[] colors, bool outdoor, int floor, int[] edges, SVector3 eColor1, SVector3 eColor2, SVector3 eColor3, SVector3 offset, int atrium, uint networkID, SegmentObject[] segments)
		{
			Materials = materials;
			Colors = colors;
			Outdoor = outdoor;
			Floor = floor;
			Edges = edges;
			EColor1 = eColor1;
			EColor2 = eColor2;
			EColor3 = eColor3;
			Offset = offset;
			RoomHeight = atrium;
			RoomGroupID = networkID;
			Segments = segments;
		}

		public void WriteData(Stream st)
		{
			st.WriteArray(Materials, delegate(Stream s, string x)
			{
				s.WriteStringUTF8(x);
			});
			st.WriteArray(Colors, delegate(Stream s, SVector3 x)
			{
				s.WriteColor(x.ToColor32(), false);
			});
			st.WriteArray(Edges, delegate(Stream s, int x)
			{
				s.WriteInt(x);
			});
			st.WriteInt(Floor);
			st.WriteBools(Outdoor, EColor1 != null, EColor2 != null, EColor3 != null);
			if (EColor1 != null)
			{
				st.WriteColor(EColor1.ToColor32(), false);
			}
			if (EColor2 != null)
			{
				st.WriteColor(EColor2.ToColor32(), false);
			}
			if (EColor3 != null)
			{
				st.WriteColor(EColor3.ToColor32(), false);
			}
			st.WriteVector(Offset);
			st.WriteInt(RoomHeight);
			st.WriteUInt(RoomGroupID);
			st.WriteArray(Segments, delegate(Stream s, SegmentObject x)
			{
				x.WriteData(s);
			});
		}

		public static RoomObject ReadData(Stream st)
		{
			string[] materials = st.ReadArray((Stream s) => s.ReadStringUTF8());
			SVector3[] colors = st.ReadArray((Func<Stream, SVector3>)((Stream s) => s.ReadColor(false)));
			int[] edges = st.ReadArray((Stream s) => s.ReadInt());
			int floor = st.ReadInt();
			bool b;
			bool b2;
			bool b3;
			bool b4;
			st.ReadBools(out b, out b2, out b3, out b4);
			return new RoomObject(eColor1: b2 ? ((SVector3)st.ReadColor(false)) : null, eColor2: b3 ? ((SVector3)st.ReadColor(false)) : null, eColor3: b4 ? ((SVector3)st.ReadColor(false)) : null, offset: st.ReadVector(), atrium: st.ReadInt(), networkID: st.ReadUInt(), segments: st.ReadArray(SegmentObject.ReadData), materials: materials, colors: colors, outdoor: b, floor: floor, edges: edges);
		}

		public AtriumType GetAtriumType(int idx, IList<RoomObject> rooms)
		{
			if (Atrium == -1)
			{
				return AtriumType.None;
			}
			if (Atrium == idx)
			{
				return AtriumType.Main;
			}
			if (rooms[Atrium].Atrium == Atrium)
			{
				return AtriumType.Upper;
			}
			return AtriumType.Balcony;
		}

		public float GetFenceHeight()
		{
			for (int i = 0; i < ObjectDatabase.Instance.FenceStyles.Count; i++)
			{
				ObjectDatabase.FenceStyle fenceStyle = ObjectDatabase.Instance.FenceStyles[i];
				if (fenceStyle.Name.Equals(Materials[3]))
				{
					return fenceStyle.Height;
				}
			}
			return 0.3f;
		}

		public void SetColors(Room x)
		{
			if (x.Outdoors || x.IsBalcony)
			{
				Colors = new SVector3[3]
				{
					x.InsideColor.Alpha(1f),
					x.FenceColor.Alpha(1f),
					x.FloorColor.Alpha(1f)
				};
				if (RoomMaterialController.AllowSecondaryRecolor(x.FloorMat))
				{
					EColor1 = x.FloorColor2;
				}
				return;
			}
			Colors = new SVector3[3]
			{
				x.InsideColor.Alpha(1f),
				x.OutsideColor.Alpha(1f),
				x.FloorColor.Alpha(1f)
			};
			if (RoomMaterialController.AllowSecondaryRecolor(x.InsideMat))
			{
				EColor1 = x.InsideColor2;
			}
			if (RoomMaterialController.AllowSecondaryRecolor(x.OutsideMat))
			{
				EColor2 = x.OutsideColor2;
			}
			if (RoomMaterialController.AllowSecondaryRecolor(x.FloorMat))
			{
				EColor3 = x.FloorColor2;
			}
		}

		public void SetColors(NetworkRoom x)
		{
			if (x.Outdoors)
			{
				Colors = new SVector3[3]
				{
					Color.black,
					x.FenceColor.Alpha(1f),
					x.FloorColor1.Alpha(1f)
				};
				if (RoomMaterialController.AllowSecondaryRecolor(x.FloorMaterial))
				{
					EColor1 = x.FloorColor2;
				}
			}
			else
			{
				Colors = new SVector3[3]
				{
					Color.black,
					x.OutsideColor1.Alpha(1f),
					Color.black
				};
				if (RoomMaterialController.AllowSecondaryRecolor(x.WallMaterial))
				{
					EColor2 = x.OutsideColor2;
				}
			}
		}

		public RoomObject(Room x, HashSet<Room> rs, Dictionary<ServerGroup, int> serverIDs, Dictionary<WallEdge, int> edgeNum, int floorOffset, bool onlyRooms, bool withData, bool removeInvalidSegments, bool rentInfo, bool saved)
		{
			Materials = new string[4] { x.InsideMat, x.OutsideMat, x.FloorMat, x.FenceStyle };
			SetColors(x);
			Outdoor = x.Outdoors;
			Pillar = x.Pillar;
			Floor = x.Floor + floorOffset;
			Edges = x.Edges.Select((WallEdge z) => edgeNum[z]).ToArray();
			Offset = new SVector3(x.FloorOffset.x, x.FloorOffset.y, x.FloorRotation, x.FloorScale);
			Furniture = (onlyRooms ? Array.Empty<FurnitureObject>() : (from z in x.GetFurnitures()
				where z != null && z.Parent == x && z.CanCopy && (!saved || z.ValidInBlueprints)
				orderby z.GetSnappingDepth()
				select new FurnitureObject(z, floorOffset, serverIDs)).ToArray());
			Segments = (onlyRooms ? Array.Empty<SegmentObject>() : x.GetSegments().WhereSelect(delegate(RoomSegment z)
			{
				IRoom primarySaveRoom = z.GetPrimarySaveRoom();
				return (!removeInvalidSegments || z.ValidSnap(false, rs, true)) && (x == primarySaveRoom || !rs.Contains(primarySaveRoom));
			}, (RoomSegment z) => new SegmentObject(z, floorOffset, false, x)).ToArray());
			Area = x.Area;
			RoomData = (withData ? x.SerializeThis(GameReader.NewLoadMode.Full, false) : null);
			RoomGroupID = (rentInfo ? (x.ParentRoom ?? x).DID : x.DID);
			Rentable = !rentInfo || x.Rentable;
			RoomHeight = x.AtriumChildren.Count + 1;
			Group = x.RoomGroup;
		}

		public RoomObject(Room x, Dictionary<WallEdge, int> edgeNum, bool includeSegments)
		{
			Materials = new string[4] { x.InsideMat, x.OutsideMat, x.FloorMat, x.FenceStyle };
			SetColors(x);
			Outdoor = x.Outdoors;
			Pillar = x.Pillar;
			Floor = x.Floor;
			Edges = x.Edges.Select((WallEdge z) => edgeNum[z]).ToArray();
			Offset = new SVector3(x.FloorOffset.x, x.FloorOffset.y, x.FloorRotation, x.FloorScale);
			Furniture = Array.Empty<FurnitureObject>();
			Segments = (includeSegments ? x.GetSegments().WhereSelect((RoomSegment z) => x == z.GetPrimarySaveRoom() && z.TowardsOutdoors(), (RoomSegment z) => new SegmentObject(z, 0, true, x)).ToArray() : Array.Empty<SegmentObject>());
			Area = x.Area;
			RoomData = null;
			RoomGroupID = x.GetRoomNetworkID();
			Rentable = false;
			RoomHeight = x.AtriumChildren.Count + 1;
		}

		public RoomObject(NetworkRoom x, Dictionary<WallEdge, int> edgeNum, int floorOffset)
		{
			Materials = new string[4] { null, x.WallMaterial, x.FloorMaterial, x.WallMaterial };
			SetColors(x);
			Outdoor = x.Outdoors;
			Pillar = x.Pillar;
			Floor = x.Floor + floorOffset;
			Edges = x.Edges.Select((WallEdge z) => edgeNum[z]).ToArray();
			Offset = new SVector3(x.FloorOffset.x, x.FloorOffset.y, x.FloorRotation, x.FloorScale);
			Furniture = Array.Empty<FurnitureObject>();
			Segments = x.GetSegments().WhereSelect((RoomSegment z) => z != null && x == z.GetPrimarySaveRoom(), (RoomSegment z) => new SegmentObject(z, floorOffset, true, x)).ToArray();
			Area = 0f;
			RoomData = null;
			RoomGroupID = x.NetworkID;
			Rentable = false;
			RoomHeight = x.FloorHeight;
		}

		public RoomObject(XMLParser.XMLNode node, uint id)
		{
			Outdoor = Convert.ToBoolean(node.GetNodeValue("Outdoor"));
			Pillar = node.GetNodeValue("Pillar", false);
			Floor = Convert.ToInt32(node.GetNodeValue("Floor"));
			Edges = (from x in node.GetNode("Edges").GetNodes("Edge")
				select Convert.ToInt32(x.Value)).ToArray();
			Colors = new SVector3[3]
			{
				SVector3.Deserialize(node.GetNodeValue("Color1")).Swizzle(1f, 3),
				SVector3.Deserialize(node.GetNodeValue("Color2")).Swizzle(1f, 3),
				SVector3.Deserialize(node.GetNodeValue("Color3")).Swizzle(1f, 3)
			};
			EColor1 = GetColorOrNothing(node, "EColor1");
			EColor2 = GetColorOrNothing(node, "EColor2");
			EColor3 = GetColorOrNothing(node, "EColor3");
			Materials = new string[4]
			{
				node.GetNodeValue("Material1"),
				node.GetNodeValue("Material2"),
				node.GetNodeValue("Material3"),
				node.GetNodeValue("Material4")
			};
			Furniture = node.GetNode("Furniture").GetNodes("Furniture", false).SelectInPlace((XMLParser.XMLNode x) => new FurnitureObject(x));
			Segments = node.GetNode("Segments").GetNodes("Segment", false).SelectInPlace((XMLParser.XMLNode x) => new SegmentObject(x));
			Offset = SVector3.Deserialize(node.GetNodeValue("Offset", "0,0,0,1"));
			Area = (float)Convert.ToDouble(node.GetNodeValue("Area"));
			RoomGroupID = id;
			Rentable = true;
			Atrium = node.GetNodeValue("Atrium", -1);
			Group = node.GetNodeValue("Group");
			Ignore = node.GetNodeValue("Ignore", false);
		}

		public XMLParser.XMLNode ToXmlNode()
		{
			XMLParser.XMLNode xMLNode = new XMLParser.XMLNode("Room", new XMLParser.XMLNode("Outdoor", Outdoor.ToString()), new XMLParser.XMLNode("Pillar", Pillar.ToString()), new XMLParser.XMLNode("Floor", Floor.ToString()), new XMLParser.XMLNode("Edges", Edges.SelectInPlace((int x) => new XMLParser.XMLNode("Edge", x.ToString()))), new XMLParser.XMLNode("Offset", Offset.Serialize()), new XMLParser.XMLNode("Color1", Colors[0].Serialize(3)), new XMLParser.XMLNode("Color2", Colors[1].Serialize(3)), new XMLParser.XMLNode("Color3", Colors[2].Serialize(3)), new XMLParser.XMLNode("Material1", Materials[0]), new XMLParser.XMLNode("Material2", Materials[1]), new XMLParser.XMLNode("Material3", Materials[2]), new XMLParser.XMLNode("Material4", Materials[3]), new XMLParser.XMLNode("Furniture", Furniture.SelectInPlace((FurnitureObject x) => x.ToXmlNode())), new XMLParser.XMLNode("Segments", Segments.SelectInPlace((SegmentObject x) => x.ToXmlNode())), new XMLParser.XMLNode("Area", Area.ToString()), new XMLParser.XMLNode("Atrium", Atrium.ToString()));
			if (EColor1 != null)
			{
				xMLNode.Children.Add(new XMLParser.XMLNode("EColor1", EColor1.Serialize()));
			}
			if (EColor2 != null)
			{
				xMLNode.Children.Add(new XMLParser.XMLNode("EColor1", EColor2.Serialize()));
			}
			if (EColor3 != null)
			{
				xMLNode.Children.Add(new XMLParser.XMLNode("EColor1", EColor3.Serialize()));
			}
			if (Group != null)
			{
				xMLNode.Children.Add(new XMLParser.XMLNode("Group", Group));
			}
			return xMLNode;
		}
	}

	public class RoofObject : IByteData
	{
		public string RoofMaterial;

		public string GableMaterial;

		public SVector3 RoofColor;

		public SVector3 RoofColor2;

		public SVector3 GableColor;

		public SVector3 GableColor2;

		public SVector3[] Area;

		public SVector3[] RoofPoints;

		public int[] RoofEdges;

		public int[] RoofOf;

		public uint[] RoofOfNetwork;

		public int Floor;

		public float Height;

		public float Slope;

		public uint NetworkID;

		public RoofObject(string roofMaterial, string gableMaterial, SVector3 roofColor, SVector3 roofColor2, SVector3 gableColor, SVector3 gableColor2, SVector3[] area, SVector3[] roofPoints, int[] roofEdges, uint[] roofOf, int floor, float height, float slope, uint networkID)
		{
			RoofMaterial = roofMaterial;
			GableMaterial = gableMaterial;
			RoofColor = roofColor;
			RoofColor2 = roofColor2;
			GableColor = gableColor;
			GableColor2 = gableColor2;
			Area = area;
			RoofPoints = roofPoints;
			RoofEdges = roofEdges;
			RoofOfNetwork = roofOf;
			Floor = floor;
			Height = height;
			Slope = slope;
			NetworkID = networkID;
		}

		public void WriteData(Stream st)
		{
			st.WriteUInt(NetworkID);
			st.WriteStringUTF8(RoofMaterial);
			st.WriteStringUTF8(GableMaterial);
			st.WriteColor(RoofColor.ToColor32(), false);
			st.WriteColor((RoofColor2 ?? SVector3.Black).ToColor32(), false);
			st.WriteColor(GableColor.ToColor32(), false);
			st.WriteColor((GableColor2 ?? SVector3.Black).ToColor32(), false);
			st.WriteArray(Area, delegate(Stream s, SVector3 x)
			{
				s.WriteVector(x);
			});
			st.WriteArray(RoofPoints, delegate(Stream s, SVector3 x)
			{
				s.WriteVector(x);
			});
			st.WriteArray(RoofEdges, delegate(Stream s, int x)
			{
				s.WriteInt(x);
			});
			st.WriteArray(RoofOfNetwork, delegate(Stream s, uint x)
			{
				s.WriteUInt(x);
			});
			st.WriteInt(Floor);
			st.WriteFloat(Height);
			st.WriteFloat(Slope);
		}

		public static RoofObject ReadData(Stream st)
		{
			uint networkID = st.ReadUInt();
			string roofMaterial = st.ReadStringUTF8();
			string gableMaterial = st.ReadStringUTF8();
			Color32 color = st.ReadColor(false);
			Color32 color2 = st.ReadColor(false);
			Color32 color3 = st.ReadColor(false);
			Color32 color4 = st.ReadColor(false);
			return new RoofObject(area: st.ReadArray((Stream s) => s.ReadVector()), roofPoints: st.ReadArray((Stream s) => s.ReadVector()), roofEdges: st.ReadArray((Stream s) => s.ReadInt()), roofOf: st.ReadArray((Stream s) => s.ReadUInt()), floor: st.ReadInt(), height: st.ReadFloat(), slope: st.ReadFloat(), roofMaterial: roofMaterial, gableMaterial: gableMaterial, roofColor: color, roofColor2: color2, gableColor: color3, gableColor2: color4, networkID: networkID);
		}

		public RoofObject(Roof roof, IRoom[] rooms, bool network)
		{
			RoofMaterial = roof.RoofMaterial;
			if (roof.GableMesh == null)
			{
				GableMaterial = null;
			}
			else
			{
				GableMaterial = roof.GableMaterial;
				if (RoomMaterialController.AllowSecondaryRecolor(roof.GableMaterial))
				{
					GableColor2 = roof.GableColor2;
				}
			}
			RoofColor = roof.RoofColor;
			GableColor = roof.GableColor;
			if (RoomMaterialController.AllowSecondaryRecolor(roof.RoofMaterial))
			{
				RoofColor2 = roof.RoofColor2;
			}
			Area = ((IList<Vector2>)roof.Area).SelectInPlace((Func<Vector2, SVector3>)((Vector2 x) => x));
			KeyValuePair<List<Roof.RoofPoint>, int[]> keyValuePair = roof.RoofLine.UnZip((Roof.RoofEdge x, bool b) => (!b) ? x.B : x.A);
			RoofEdges = keyValuePair.Value;
			RoofPoints = ((IList<Roof.RoofPoint>)keyValuePair.Key).SelectInPlace((Func<Roof.RoofPoint, SVector3>)((Roof.RoofPoint x) => x.V));
			if (network)
			{
				RoofOfNetwork = (from x in roof.RoofOf
					select x.GetAtriumParent(false).GetRoomNetworkID() into x
					where x != 0
					select x).Distinct().ToArray();
			}
			else
			{
				RoofOf = roof.RoofOf.SelectInPlace((IRoom x) => Array.IndexOf(rooms, x));
			}
			Floor = roof.Floor;
			Height = roof.Height;
			Slope = roof.Bulge;
			NetworkID = (network ? roof.InitLocalNetworkID() : 0u);
		}

		public RoofObject(XMLParser.XMLNode root)
		{
			RoofMaterial = root.GetNodeValue("RoofMaterial", "Roof tiles");
			GableMaterial = root.GetNodeValue("GableMaterial", "Brick wall");
			RoofColor = SVector3.Deserialize(root.GetNodeValue("RoofColor"));
			RoofColor2 = GetColorOrNothing(root, "RoofColor2");
			GableColor = SVector3.Deserialize(root.GetNodeValue("GableColor"));
			GableColor2 = GetColorOrNothing(root, "GableColor2");
			Area = root.GetNodeValue("Area").Split('|').SelectInPlace((string x) => SVector3.Deserialize(x));
			RoofPoints = root.GetNodeValue("RoofPoints").Split('|').SelectInPlace((string x) => SVector3.Deserialize(x));
			RoofEdges = root.GetNodeValue("RoofEdges").Split(',').SelectInPlace((string x) => Convert.ToInt32(x));
			RoofOf = root.GetNodeValue("RoofOf").Split(',').SelectInPlace((string x) => Convert.ToInt32(x));
			Floor = root.GetNodeValue("Floor").ConvertToIntDef(1);
			Height = root.GetNodeValue("Height").ConvertToFloatDef(1f);
			Slope = root.GetNodeValue("Slope").ConvertToFloatDef(1f);
		}

		public XMLParser.XMLNode ToXMLNode()
		{
			XMLParser.XMLNode xMLNode = new XMLParser.XMLNode("Roof", new XMLParser.XMLNode("RoofMaterial", RoofMaterial), new XMLParser.XMLNode("RoofColor", RoofColor.Serialize()), new XMLParser.XMLNode("Height", Height.ToString()), new XMLParser.XMLNode("Slope", Slope.ToString()), new XMLParser.XMLNode("Floor", Floor.ToString()), new XMLParser.XMLNode("Area", string.Join("|", Area.SelectInPlace((SVector3 x) => x.Serialize(2)))), new XMLParser.XMLNode("RoofPoints", string.Join("|", RoofPoints.SelectInPlace((SVector3 x) => x.Serialize(2)))), new XMLParser.XMLNode("RoofEdges", string.Join(",", RoofEdges.SelectInPlace((int x) => x.ToString()))), new XMLParser.XMLNode("RoofOf", string.Join(",", RoofOf.SelectInPlace((int x) => x.ToString()))));
			if (RoofColor2 != null)
			{
				xMLNode.Children.Add(new XMLParser.XMLNode("RoofColor2", RoofColor2.Serialize()));
			}
			if (GableMaterial != null)
			{
				xMLNode.Children.Add(new XMLParser.XMLNode("GableMaterial", GableMaterial));
				xMLNode.Children.Add(new XMLParser.XMLNode("GableColor", GableColor.Serialize()));
				if (GableColor2 != null)
				{
					xMLNode.Children.Add(new XMLParser.XMLNode("GableColor2", GableColor2.Serialize()));
				}
			}
			return xMLNode;
		}
	}

	public string Name;

	public RoomObject[] Rooms;

	public RoofObject[] Roofs;

	public SVector3[] Edges;

	public Dictionary<int, int[]> Smoothing;

	public bool AddTrashCans;

	public static SVector3 GetColorOrNothing(XMLParser.XMLNode node, string key)
	{
		string nodeValue = node.GetNodeValue(key);
		if (nodeValue != null)
		{
			return SVector3.Deserialize(nodeValue);
		}
		return null;
	}

	public BuildingPrefab(RoomObject[] rooms, RoofObject[] roofs, SVector3[] edges, Dictionary<int, int[]> smoothing, bool addTrashCans = false)
	{
		Rooms = rooms;
		Roofs = roofs;
		Edges = edges;
		Smoothing = smoothing;
		AddTrashCans = addTrashCans;
	}

	public XMLParser.XMLNode ToXmlNode()
	{
		XMLParser.XMLNode xMLNode = new XMLParser.XMLNode("Blueprint", new XMLParser.XMLNode("Rooms", Rooms.SelectInPlace((RoomObject x) => x.ToXmlNode())), new XMLParser.XMLNode("Roofs", Roofs.SelectInPlace((RoofObject x) => x.ToXMLNode())), new XMLParser.XMLNode("Edges", Edges.SelectInPlace((SVector3 x) => new XMLParser.XMLNode("Edge", x.Serialize()))));
		xMLNode.Attributes["Trash"] = "False";
		if (Smoothing.Count > 0)
		{
			XMLParser.XMLNode xMLNode2 = new XMLParser.XMLNode("Smoothing");
			foreach (KeyValuePair<int, int[]> item in Smoothing)
			{
				string value = item.Key + "," + string.Join(",", item.Value.SelectInPlace((int x) => x.ToString()));
				xMLNode2.Children.Add(new XMLParser.XMLNode("Edges", value));
			}
			xMLNode.Children.Add(xMLNode2);
		}
		return xMLNode;
	}

	public static BuildingPrefab FromXMLNode(XMLParser.XMLNode node)
	{
		SVector3[] edges = node.GetNode("Edges").GetNodes("Edge").SelectInPlace((XMLParser.XMLNode x) => SVector3.Deserialize(x.Value));
		XMLParser.XMLNode node2 = node.GetNode("Smoothing", false);
		Dictionary<int, int[]> dictionary = new Dictionary<int, int[]>();
		if (node2 != null)
		{
			for (int num = 0; num < node2.Children.Count; num++)
			{
				XMLParser.XMLNode xMLNode = node2.Children[num];
				try
				{
					string[] array = xMLNode.Value.Split(',');
					dictionary[array[0].ConvertToInt("Smoothing key")] = (from x in array.Skip(1)
						select x.ConvertToInt("Smoothing value")).ToArray();
				}
				catch (Exception exception)
				{
					Debug.LogException(exception);
				}
			}
		}
		RoomObject[] array2 = node.GetNode("Rooms").GetNodes("Room").SelectInPlace((XMLParser.XMLNode x, int i) => new RoomObject(x, (uint)i));
		XMLParser.XMLNode node3 = node.GetNode("Roofs", false);
		RoofObject[] roofs = ((node3 == null) ? new RoofObject[0] : node3.GetNodes("Roof", false).SelectInPlace((XMLParser.XMLNode x) => new RoofObject(x)));
		bool flag = true;
		for (int num2 = 0; num2 < array2.Length; num2++)
		{
			if (array2[num2].Floor >= 0)
			{
				flag = false;
				break;
			}
		}
		if (flag)
		{
			foreach (RoomObject roomObject in array2)
			{
				roomObject.Floor++;
				for (int num4 = 0; num4 < roomObject.Segments.Length; num4++)
				{
					SegmentObject segmentObject = roomObject.Segments[num4];
					segmentObject.Position = new SVector3(segmentObject.Position.x, segmentObject.Position.y + 2f, segmentObject.Position.z);
				}
				for (int num5 = 0; num5 < roomObject.Furniture.Length; num5++)
				{
					FurnitureObject furnitureObject = roomObject.Furniture[num5];
					furnitureObject.Position = new SVector3(furnitureObject.Position.x, furnitureObject.Position.y + 2f, furnitureObject.Position.z);
				}
			}
		}
		return new BuildingPrefab(array2, roofs, edges, dictionary, node.Attributes.GetOrDefault("Trash", "True").ConvertToBoolDef(false));
	}

	public static bool ValidCheck(Room[] rooms)
	{
		int minAbove = rooms.GetMinAbove(-1, (Room x) => x.Floor);
		HashSet<Room> with = rooms.ToHashSet();
		if (minAbove >= 0)
		{
			foreach (Room room in rooms)
			{
				if (room.Floor > minAbove && (room.AtriumParent == null || room.AtriumParent == room) && !GameSettings.Instance.sRoomManager.IsSupported(room.Edges.Select((WallEdge x) => x.Pos), room.Floor, null, false, with))
				{
					return false;
				}
			}
		}
		return true;
	}

	public static List<Room> GetInvalid(Room[] rooms)
	{
		List<Room> list = new List<Room>();
		int minAbove = rooms.GetMinAbove(-1, (Room x) => x.Floor);
		HashSet<Room> with = rooms.ToHashSet();
		if (minAbove >= 0)
		{
			foreach (Room room in rooms)
			{
				if (room.Floor > minAbove && !GameSettings.Instance.sRoomManager.IsSupported(room.Edges.Select((WallEdge x) => x.Pos), room.Floor, null, false, with))
				{
					list.Add(room);
				}
			}
		}
		return list;
	}

	public static BuildingPrefab SaveRooms(Room[] rooms, Roof[] roofs, bool fixFloor, bool onlyRooms = false, bool removeInvalidSegments = false, bool withData = false, bool rentInfo = false, bool forceAtriums = false, bool saved = false)
	{
		HashSet<Room> rs;
		if (forceAtriums)
		{
			rs = rooms.ToHashSet();
		}
		else
		{
			HashSet<Room> hashSet = rooms.ToHashSet();
			rs = new HashSet<Room>();
			foreach (Room room in rooms)
			{
				if (room.AtriumParent == null)
				{
					rs.Add(room);
				}
				else
				{
					if (!(room.AtriumParent == room))
					{
						continue;
					}
					rs.Add(room);
					for (int j = 0; j < room.AtriumChildren.Count; j++)
					{
						Room room2 = room.AtriumChildren[j];
						if (!hashSet.Contains(room2) || !room2.AtriumChildren.All(hashSet.Contains))
						{
							break;
						}
						rs.Add(room2);
						rs.AddRange(room2.AtriumChildren);
					}
				}
			}
		}
		Dictionary<WallEdge, int> edgeNum = new Dictionary<WallEdge, int>();
		List<WallEdge> list = new List<WallEdge>();
		Dictionary<int, int[]> dictionary = new Dictionary<int, int[]>();
		int num = 0;
		foreach (WallEdge item in rs.SelectMany((Room x) => x.Edges).Distinct())
		{
			edgeNum[item] = num;
			list.Add(item);
			num++;
		}
		List<int> list2 = new List<int>();
		for (int num2 = 0; num2 < list.Count; num2++)
		{
			WallEdge wallEdge = list[num2];
			if (wallEdge.Smooth.Count <= 0)
			{
				continue;
			}
			list2.Clear();
			foreach (WallEdge item2 in wallEdge.Smooth)
			{
				int value;
				if (edgeNum.TryGetValue(item2, out value) && wallEdge.Links.ContainsValue(item2))
				{
					list2.Add(value);
				}
			}
			if (list2.Count > 0)
			{
				dictionary[edgeNum[wallEdge]] = list2.ToArray();
			}
		}
		List<Roof> list3 = new List<Roof>();
		foreach (Roof roof in roofs)
		{
			if (roof.RoofOf.All((IRoom x) => rs.Contains(x)))
			{
				list3.Add(roof);
			}
		}
		int offset = ((fixFloor && rs.All((Room x) => x.Floor < 0)) ? 1 : 0);
		Dictionary<ServerGroup, int> svID = new Dictionary<ServerGroup, int>();
		ValueTuple<Room, RoomObject>[] array = (from room3 in rs
			orderby room3.GetAtriumSubOrder(), (x.AtriumParent ?? x).AtriumChildren.IndexOf(x)
			select new ValueTuple<Room, RoomObject>(room3, new RoomObject(room3, rs, svID, edgeNum, offset, onlyRooms, withData, removeInvalidSegments, rentInfo, saved))).ToArray();
		HashSet<int> hashSet2 = new HashSet<int>();
		for (int num4 = 0; num4 < array.Length; num4++)
		{
			ValueTuple<Room, RoomObject> r = array[num4];
			if (r.Item1.AtriumParent != null)
			{
				r.Item2.Atrium = array.FindIndex(([TupleElementNames(new string[] { "room", null })] ValueTuple<Room, RoomObject> x) => x.Item1 == r.Item1.AtriumParent);
				if (r.Item2.Atrium != num4)
				{
					hashSet2.Add(r.Item2.Atrium);
				}
			}
		}
		for (int num5 = 0; num5 < array.Length; num5++)
		{
			ValueTuple<Room, RoomObject> valueTuple = array[num5];
			if (valueTuple.Item2.Atrium >= 0 && !hashSet2.Contains(valueTuple.Item2.Atrium))
			{
				valueTuple.Item2.Atrium = -1;
			}
		}
		RoofObject[] roofs2 = list3.SelectInPlace(delegate(Roof x)
		{
			IRoom[] rooms2 = rooms;
			return new RoofObject(x, rooms2, false);
		});
		return new BuildingPrefab(array.SelectInPlace(([TupleElementNames(new string[] { "room", null })] ValueTuple<Room, RoomObject> x) => x.Item2), roofs2, ((IList<WallEdge>)list).SelectInPlace((Func<WallEdge, SVector3>)((WallEdge x) => x.Pos)), dictionary);
	}

	public static BuildingPrefab SaveRoomsForNetwork(Room[] rooms, Roof[] roofs, bool includeSegments)
	{
		List<Room> list = rooms.Where((Room x) => !x.IsUpperAtrium).ToList();
		Dictionary<WallEdge, int> edgeNum = new Dictionary<WallEdge, int>();
		List<WallEdge> list2 = new List<WallEdge>();
		Dictionary<int, int[]> dictionary = new Dictionary<int, int[]>();
		int num = 0;
		foreach (WallEdge item in list.SelectMany((Room x) => x.Edges).Distinct())
		{
			edgeNum[item] = num;
			list2.Add(item);
			num++;
		}
		List<int> list3 = new List<int>();
		for (int num2 = 0; num2 < list2.Count; num2++)
		{
			WallEdge wallEdge = list2[num2];
			if (wallEdge.Smooth.Count <= 0)
			{
				continue;
			}
			list3.Clear();
			foreach (WallEdge item2 in wallEdge.Smooth)
			{
				int value;
				if (edgeNum.TryGetValue(item2, out value) && wallEdge.Links.ContainsValue(item2))
				{
					list3.Add(value);
				}
			}
			if (list3.Count > 0)
			{
				dictionary[edgeNum[wallEdge]] = list3.ToArray();
			}
		}
		RoofObject[] roofs2 = roofs.SelectInPlace(delegate(Roof x)
		{
			IRoom[] rooms2 = rooms;
			return new RoofObject(x, rooms2, true);
		});
		return new BuildingPrefab(list.SelectInPlace((Room x) => new RoomObject(x, edgeNum, includeSegments)), roofs2, ((IList<WallEdge>)list2).SelectInPlace((Func<WallEdge, SVector3>)((WallEdge x) => x.Pos)), dictionary);
	}

	public static BuildingPrefab SaveNetworkRooms(NetworkRoom[] rooms, Roof[] roofs)
	{
		List<NetworkRoom> rs = rooms.ToList();
		Dictionary<WallEdge, int> edgeNum = new Dictionary<WallEdge, int>();
		List<WallEdge> list = new List<WallEdge>();
		Dictionary<int, int[]> dictionary = new Dictionary<int, int[]>();
		int num = 0;
		foreach (WallEdge item in rs.SelectMany((NetworkRoom x) => x.Edges).Distinct())
		{
			edgeNum[item] = num;
			list.Add(item);
			num++;
		}
		List<int> list2 = new List<int>();
		for (int num2 = 0; num2 < list.Count; num2++)
		{
			WallEdge wallEdge = list[num2];
			if (wallEdge.Smooth.Count <= 0)
			{
				continue;
			}
			list2.Clear();
			foreach (WallEdge item2 in wallEdge.Smooth)
			{
				int value;
				if (edgeNum.TryGetValue(item2, out value) && wallEdge.Links.ContainsValue(item2))
				{
					list2.Add(value);
				}
			}
			if (list2.Count > 0)
			{
				dictionary[edgeNum[wallEdge]] = list2.ToArray();
			}
		}
		List<Roof> list3 = new List<Roof>();
		foreach (Roof roof in roofs)
		{
			if (roof.RoofOf.All((IRoom x) => rs.Contains(x)))
			{
				list3.Add(roof);
			}
		}
		RoofObject[] roofs2 = list3.SelectInPlace(delegate(Roof x)
		{
			IRoom[] rooms2 = rooms;
			return new RoofObject(x, rooms2, true);
		});
		return new BuildingPrefab(rs.SelectInPlace((NetworkRoom room) => new RoomObject(room, edgeNum, 0)), roofs2, ((IList<WallEdge>)list).SelectInPlace((Func<WallEdge, SVector3>)((WallEdge x) => x.Pos)), dictionary);
	}

	public override string ToString()
	{
		return Name;
	}

	public void WriteData(Stream st)
	{
		st.WriteArray(Edges, delegate(Stream s, SVector3 x)
		{
			s.WriteVector(x);
		});
		st.WriteArray(Rooms, delegate(Stream s, RoomObject x)
		{
			x.WriteData(s);
		});
		st.WriteArray(Roofs, delegate(Stream s, RoofObject x)
		{
			x.WriteData(s);
		});
		st.WriteInt(Smoothing.Count);
		foreach (KeyValuePair<int, int[]> item in Smoothing)
		{
			st.WriteInt(item.Key);
			st.WriteInt(item.Value.Length);
			for (int num = 0; num < item.Value.Length; num++)
			{
				st.WriteInt(item.Value[num]);
			}
		}
	}

	public static BuildingPrefab ReadData(Stream st)
	{
		SVector3[] edges = st.ReadArray((Stream x) => x.ReadVector());
		RoomObject[] rooms = st.ReadArray(RoomObject.ReadData);
		RoofObject[] roofs = st.ReadArray(RoofObject.ReadData);
		int num = st.ReadInt();
		Dictionary<int, int[]> dictionary = new Dictionary<int, int[]>(num);
		for (int num2 = 0; num2 < num; num2++)
		{
			int[] array = (dictionary[st.ReadInt()] = new int[st.ReadInt()]);
			int[] array3 = array;
			for (int num3 = 0; num3 < array3.Length; num3++)
			{
				array3[num3] = st.ReadInt();
			}
		}
		return new BuildingPrefab(rooms, roofs, edges, dictionary);
	}

	public string GetActualString()
	{
		return Name;
	}
}
