using TMPro;
using UnityEngine;

public class Capacitor : WireComponent
{
	[Header("Variables")]
	public double farads;

	public int type;

	public bool trapModel;

	public float wireRadius;

	public float wirePenetration;

	[Header("Renderering")]
	public WireRenderer wireRend;

	public GameObject[] bodies;

	public Renderer bodyRenderer;

	public Transform bodyTransform;

	public TextMeshPro[] ratingTexts;

	private MaterialPropertyBlock props;

	public override void Awake()
	{
	}

	public override void TickUpdate()
	{
	}

	private void SetRatingLabel()
	{
	}

	public override void Select()
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
