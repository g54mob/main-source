using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LEDTool : ToolBase
{
	public static LEDTool inst;

	[Header("LED Materials")]
	public Material[] ledMaterials;

	[Header("Creator Box")]
	public InputField cre_forwardVInput;

	public InputField cre_leakageInput;

	public InputField cre_maxCurrentInput;

	public Dropdown cre_colDropdown;

	public Button cre_CancelBtn;

	[Header("Editor Box")]
	public InputField edit_forwardVInput;

	public InputField edit_maxCurrentInput;

	public InputField edit_leakageInput;

	public Dropdown edit_colDropdown;

	public Text edit_voltage;

	public Text edit_current;

	public Text edit_voltageUnit;

	public Text edit_currentUnit;

	[Header("Vars")]
	public float wireDepth;

	public float wireHeight;

	private List<Vector3> wirePoints;

	private readonly float fVStd;

	private readonly float leakStd;

	private readonly float maxIStd;

	private float leak;

	private float maxI;

	private int c;

	private readonly int compMask;

	private Ray ray;

	private RaycastHit hit;

	private TiePoint curPoint;

	private BaseComponent hitComp;

	public static Material[] LEDMaterials => null;

	private new void Awake()
	{
	}

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

	public override void UpdateEditParams(Selectable sel)
	{
	}

	public override void UpdateCreateParams(Selectable sel)
	{
	}

	public override void Update()
	{
	}
}
