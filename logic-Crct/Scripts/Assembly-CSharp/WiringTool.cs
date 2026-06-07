using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WiringTool : ToolBase
{
	[Header("Creator Box")]
	public Color cre_Color;

	public Image cre_ColorBar;

	public Button cre_CancelBtn;

	public InputField cre_IRatingInput;

	[Header("Editor Box")]
	public Color edit_Color;

	public Image edit_ColorBar;

	public Text edit_voltage;

	public Text edit_current;

	public Text edit_voltageUnit;

	public Text edit_currentUnit;

	public InputField edit_IRatingInput;

	[Header("Vars")]
	public float wireDepth;

	public float wireHeight;

	private List<Vector3> wirePoints;

	private int c;

	private readonly int compMask;

	private Ray ray;

	private RaycastHit hit;

	private TiePoint curPoint;

	private BaseComponent hitComp;

	public override void OnClick()
	{
	}

	public void CreatePickColor()
	{
	}

	public override void LoadEdit(BaseComponent comp)
	{
	}

	public void EditPickColor()
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

	public override void UpdateCreateParams()
	{
	}

	public override void UpdateEditParams()
	{
	}

	public override void Update()
	{
	}
}
