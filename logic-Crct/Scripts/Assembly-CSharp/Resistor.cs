using UnityEngine;

public class Resistor : WireComponent
{
	[Header("Variables")]
	public float ohms;

	public float wireRadius;

	public float maxPower;

	[Header("Renderering")]
	public WireRenderer wireRend;

	public Renderer bodyRenderer;

	public Transform bodyTransform;

	public float resistorBodyWidth;

	private MaterialPropertyBlock props;

	public override void Awake()
	{
	}

	public override void TickUpdate()
	{
	}

	private void UpdateBandColours(float ohms)
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
