using UnityEngine;
using VampireSurvivors.Framework.Geom;

namespace VampireSurvivors.Framework.Particles;

public class EmitZone
{
	public EmitZoneType _type = EmitZoneType.Random;

	public BaseGeom _source;

	public int? _quantity;

	public bool _yoyo;

	public Vector3? _overrideRotation;
}
