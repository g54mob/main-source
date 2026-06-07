using UnityEngine;

public class LevelObjectModel : BaseModel
{
	public int Id { get; set; }

	public string Name { get; set; }

	public string ResourceName { get; set; }

	public LevelObjectType LevelObjectType { get; set; }

	public Vector3 Position { get; set; }

	public Quaternion Rotation { get; set; }

	public Vector3 Scale { get; set; }

	public bool IsAffectedByPhysics { get; set; }

	public float Mass { get; set; }

	public Color Color { get; set; }

	public bool IsWithGrid { get; set; }

	public bool IsAltTexOffset { get; set; }

	public LevelObjectLogicType LogicType { get; set; }

	public int LevelObjectOutputId { get; set; }

	public bool IsInvertedLogic { get; set; }

	public bool IsPressOnce { get; set; }

	public LORotatorModel RotatorModel { get; set; }

	public LevelObjectModel()
	{
		LevelObjectOutputId = -1;
	}
}
