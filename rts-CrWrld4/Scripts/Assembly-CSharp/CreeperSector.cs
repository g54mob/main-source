using System;
using System.Collections.Generic;
using UnityEngine;

public class CreeperSector
{
	public struct MistToMake
	{
		public Vector3 loc;

		public Color32 color;

		public MistToMake(Vector3 loc, Color color)
		{
			this.loc = default(Vector3);
			this.color = default(Color32);
		}
	}

	public int sectorX;

	public int sectorY;

	public int index;

	public int[] creeperShadow;

	public int[] creeperStainShadow;

	public List<UnitManager> unfreezingUnits;

	public List<MistToMake> mistToMake;

	public List<Vector2> terrainDecayNotifyList;

	public double goodCreep;

	public double badCreep;

	private int minY;

	private int maxY;

	private int minX;

	private int maxX;

	public int RIGHTBIAS;

	public int DOWNBIAS;

	private System.Random random;

	public long creeperTotal;

	public long anticreeperTotal;

	public int creeperCoverTotal;

	public int anticreeperCoverTotal;

	public int digTotal;

	public static float WAVE_DAMP_CUTOFF;

	public int maxCreeper;

	public int minCreeper;

	public int maxCreeperLoc;

	public int minCreeperLoc;

	public int maxAC;

	public int minAC;

	public int maxACLoc;

	public int minACLoc;

	public int maxCreeperWD;

	public int minCreeperWD;

	public int maxCreeperLocWD;

	public int minCreeperLocWD;

	public int maxACWD;

	public int minACWD;

	public int maxACLocWD;

	public int minACLocWD;

	public CreeperSector(int x, int y)
	{
	}

	public virtual void CreateShadow()
	{
	}

	private void DecayTerrain(int x, int y, int d)
	{
	}

	private void DamageWall(int i)
	{
	}

	public void UpdateCreeper(int edge)
	{
	}
}
