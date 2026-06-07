using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CapacitorTool : ToolBase
{
	[Header("Creator Box")]
	public InputField cre_faradInput;

	public Dropdown cre_unitDropdown;

	public Button cre_CancelBtn;

	public Dropdown cre_typeDrowdown;

	public Toggle cre_trapModel;

	[Header("Editor Box")]
	public InputField edit_faradInput;

	public Dropdown edit_unitDropdown;

	public Text edit_voltage;

	public Text edit_current;

	public Text edit_voltageUnit;

	public Text edit_currentUnit;

	public Dropdown edit_typeDrowdown;

	public Toggle edit_trapModel;

	[Header("Vars")]
	public float wireDepth;

	public float wireHeight;

	private List<Vector3> wirePoints;

	private double faradsNormalized;

	private int c;

	private readonly int compMask;

	private Ray ray;

	private RaycastHit hit;

	private TiePoint curPoint;

	private BaseComponent hitComp;

	public override void OnClick()
	{
	}

	public override void LoadEdit(BaseComponent comp)
	{
	}

	public override void BeginCreate()
	{
	}

	public override void CompleteCreate()
	{
	}

	public override void Cancel()
	{
	}

	public override void CancelCreation()
	{
	}

	public override void UpdateEditParams()
	{
	}

	public override void UpdateCreateParams()
	{
	}

	public override void Update()
	{
	}
}
