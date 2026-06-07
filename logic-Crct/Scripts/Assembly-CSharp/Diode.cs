using UnityEngine;

public class Diode : WireComponent
{
	[Header("Variables")]
	public double z;

	public double fV;

	public double leakage;

	public double maxCurrent;

	public int t;

	public float wireRadius;

	[Header("Renderering")]
	public WireRenderer wireRend;

	public GameObject[] bodies;

	public Transform bodyTransform;

	public float bodyWidth;

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
