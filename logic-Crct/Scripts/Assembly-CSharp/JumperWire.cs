using UnityEngine;

public class JumperWire : WireComponent
{
	[Header("Variables")]
	public int color;

	public float wireRadius;

	public float sheathRadius;

	public float IRating;

	[Header("Renderering")]
	public WireRenderer sheathRend;

	private Color sheathCol;

	public WireRenderer wireRend;

	private Color wireCol;

	private MaterialPropertyBlock props;

	public override void Awake()
	{
	}

	public override void TickUpdate()
	{
	}

	public override object[] VarData()
	{
		return null;
	}

	public override void ProcessVarData(object[] data)
	{
	}

	public override bool ValuesChanged(object[] data)
	{
		return false;
	}

	public override object[] ReturnSaveData()
	{
		return null;
	}

	public override void ProcessSaveData(object[] data)
	{
	}

	public override void FinishPlacement()
	{
	}

	public override void GenerateWire(bool finish = false)
	{
	}
}
