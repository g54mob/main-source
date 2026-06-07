using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResistorTool : ToolBase
{
	public static ResistorTool inst;

	[Header("Bands")]
	public Color[] bandColours;

	[Header("Creator Box")]
	public InputField cre_ohmInput;

	public Image[] cre_bands;

	public Button cre_CancelBtn;

	public InputField cre_MaxPowerInput;

	[Header("Editor Box")]
	public InputField edit_ohmInput;

	public Image[] edit_bands;

	public Text edit_voltage;

	public Text edit_current;

	public Text edit_voltageUnit;

	public Text edit_currentUnit;

	public Text edit_power;

	public Text edit_powerUnit;

	public InputField edit_MaxPowerInput;

	[Header("Vars")]
	public float wireDepth;

	public float wireHeight;

	private List<Vector3> wirePoints;

	private float ohmsNormalized;

	private int c;

	private readonly int compMask;

	private Ray ray;

	private RaycastHit hit;

	private TiePoint curPoint;

	private BaseComponent hitComp;

	public static Color[] BandColours => null;

	private new void Awake()
	{
	}

	private void UpdateBandColours(ref Image[] bands, float ohms)
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
