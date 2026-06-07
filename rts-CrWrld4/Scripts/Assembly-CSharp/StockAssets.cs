using System.Collections.Generic;
using UnityEngine;

public class StockAssets : MonoBehaviour
{
	public Mesh Cube;

	public Mesh Sphere;

	public Mesh Capsule;

	public Mesh Cylinder;

	public Mesh Plane;

	public Mesh Cone;

	public Mesh Pyramid;

	public Mesh Carbon_Tower1;

	public Mesh Carbon_Tower1Broken;

	public Mesh Carbon_Tower2;

	public Mesh Carbon_Tower3;

	public Mesh Carbon_Tower4;

	public Mesh Carbon_Silo;

	public Mesh Carbon_Ship1;

	public Mesh Carbon_Ruin1;

	public Mesh Barrel_01;

	public Mesh Barrel_02;

	public Mesh Barrel_03;

	public Mesh Barrel_04;

	public Mesh Column_01;

	public Mesh Column_02;

	public Mesh Column_03;

	public Mesh Detail_03;

	public Mesh Detail_04;

	public Mesh Detail_09;

	public Mesh Detail_10;

	public Mesh Detail_05;

	public Mesh Detail_06;

	public Mesh Detail_07;

	public Mesh Detail_08;

	public Mesh Balk_01;

	public Mesh Balk_02;

	public Mesh Balk_03;

	public Mesh Balk_04;

	public Mesh Container_01;

	public Mesh Container_02;

	public Mesh Diagonal_Plate_01;

	public Mesh Diagonal_Platform_01;

	public Mesh Diagonal_Platform_02;

	public Mesh Diagonal_Wall_01;

	public Mesh Diagonal_Wall_02;

	public Mesh Elevator_Base;

	public Mesh Elevator_Finish;

	public Mesh Elevator_Platform;

	public Mesh Elevator_Rail;

	public Mesh Fence_01;

	public Mesh Fence_02;

	public Mesh Fence_03;

	public Mesh Fence_04;

	public Mesh Fence_Column_01;

	public Mesh Fence_Column_02;

	public Mesh Fence_Column_03;

	public Mesh Fence_Column_04;

	public Mesh Fence_02_Column_01;

	public Mesh Fence_02_Line_Large;

	public Mesh Fence_02_Line_Small;

	public Mesh Fence_02_Round_large;

	public Mesh Fence_02_Round_Small;

	public Mesh Gate_Left;

	public Mesh Gate_Right;

	public Mesh Junk_01;

	public Mesh Junk_02;

	public Mesh Junk_03;

	public Mesh Junk_04;

	public Mesh Light_01;

	public Mesh Light_02;

	public Mesh Light_03;

	public Mesh Light_04;

	public Mesh Light_05;

	public Mesh Light_06;

	public Mesh Light_07;

	public Mesh Plate_Eighth;

	public Mesh Plate_Full;

	public Mesh Plate_Half;

	public Mesh Plate_Long;

	public Mesh Plate_Quarter;

	public Mesh Platform_01;

	public Mesh Platform_02;

	public Mesh Platform_03;

	public Mesh Platform_04;

	public Mesh Platform_05;

	public Mesh Stairs_01;

	public Mesh Stairs_02;

	public Mesh Props_01_Box;

	public Mesh Props_01_Column;

	public Mesh Props_01_Cone;

	public Mesh Props_01_Fence;

	public Mesh Props_01_Tape_02;

	public Mesh Props_01_Tape__01;

	public Mesh Props_01_Wire_01;

	public Mesh Props_01_Wire_02;

	public Mesh Props_01_Wire_03;

	public Mesh Road_I;

	public Mesh Road_L;

	public Mesh Road_T;

	public Mesh Road_X;

	public Mesh Round_01;

	public Mesh Round_02;

	public Mesh Round_03;

	public Mesh Round_04;

	public Mesh Round_05;

	public Mesh Structures_01;

	public Mesh Structures_02;

	public Mesh Structures_03;

	public Mesh Detail_01;

	public Mesh Detail_02;

	public Mesh Tube_01;

	public Mesh Tube_02;

	public Mesh Tube_03;

	public Mesh Wall_01;

	public Mesh Wall_02;

	public Mesh Wall_03;

	public Mesh Wall_Door_01;

	public Mesh Wall_Door_02;

	public Mesh Wall_Door_03;

	public Mesh Wall_Window_01;

	public Mesh Wall_Window_02;

	public Mesh Wall_Window_03;

	public Mesh Wires_01;

	public Mesh Wires_02;

	public Mesh Wires_03;

	public Mesh Wires_04;

	public Mesh Wires_05;

	public Mesh Wires_Decor_01;

	public Mesh Wires_Decor_02;

	public Mesh Wires_Floor;

	public Mesh Wires_Holder;

	public Mesh Wires_Lattice;

	public Mesh AgricultureA;

	public Mesh AlienArtifactA;

	public Mesh AntennaA_Base;

	public Mesh AntennaA_Body;

	public Mesh AntennaTowerA;

	public Mesh Dome50A;

	public Mesh DomeB;

	public Mesh DomeC;

	public Mesh FactoryBuildingA;

	public Mesh FuelTankA;

	public Mesh HexgonSphere;

	public Mesh HouseB_Bld;

	public Mesh HouseD;

	public Mesh ShipA;

	public Mesh ShipB;

	public Mesh ShipC;

	public Mesh TowerA;

	private Dictionary<string, GameObject> gameObjects;

	private Dictionary<string, CPack.CPackTexture> dynCPackTextures;

	private CPack.CPackTexture defaultTexture;

	private Dictionary<string, Texture> dynTextures;

	public List<string> GetMeshNames()
	{
		return null;
	}

	public string GetTextureForMesh(string mesh)
	{
		return null;
	}

	public Mesh GetMesh(string mesh)
	{
		return null;
	}

	public GameObject GetGameObject(string mesh)
	{
		return null;
	}

	public CPack.CPackTexture GetCPackTexture(string t)
	{
		return null;
	}

	public Texture GetTexture(string texture)
	{
		return null;
	}

	private Texture GetDynTexture(string t)
	{
		return null;
	}

	public void OnDisable()
	{
	}
}
