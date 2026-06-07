using System.Collections.Generic;
using NBT.Tags;
using UnityEngine;

public class BeamManager
{
	private Dictionary<int, Beam> beams;

	private Beam CreateBeam()
	{
		return null;
	}

	public Beam CreateBeam(string colorMat, float hdr, float width, Vector3 start, Vector3 end)
	{
		return null;
	}

	public void RemoveBeam(Beam beam)
	{
	}

	public Beam GetBeam(int beamUID)
	{
		return null;
	}

	public void DestroyAllBeams()
	{
	}

	public void DestroyAllAttachedBeams(UnitManager um)
	{
	}

	public void ReadData(Tag data)
	{
	}

	public void WriteData(TagCompound baseTag)
	{
	}
}
