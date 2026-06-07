using EPOOutline;
using UnityEngine;

public class CableLink : Interact
{
	public enum TypeOfLink
	{
		None = 0,
		Server = 1,
		Switch = 2,
		Base = 3,
		LB = 4,
		PatchPanel = 5
	}

	private Outlinable outlineEffect;

	public bool isStartOrEnd;

	private bool isEndPoint;

	public int cableIDsOnLink;

	public string switchID;

	public TypeOfLink typeOfLink;

	public float connectionSpeed;

	public int CustomerID;

	private Server parentServer;

	private NetworkSwitch parentSwitch;

	private PatchPanel parentPatchPanel;

	public bool isSFPPort;

	[SerializeField]
	private int sfpTypeInserted;

	[SerializeField]
	private int sfpTypeSupported;

	public bool isFibrePort;

	public SFPModule insertedSFP;

	[Header("Rope Offset")]
	private float ropeForwardOffset;

	private float sfpForwardOffset;

	private Transform ropeAttachPoint;

	private void Start()
	{
	}

	public void SetConnectionSpeed(float speed)
	{
	}

	public void InsertSFP(float speed, int type, SFPModule module)
	{
	}

	public void RemoveSFP()
	{
	}

	public override void InteractOnClick()
	{
	}

	public override bool IsAllowedToDoSecondAction()
	{
		return false;
	}

	public override void SecondActionOnClick()
	{
	}

	public override void InteractOnHover(RaycastHit hit)
	{
	}

	public override void OnHoverOver()
	{
	}

	private void CreateRopeAttachPoint()
	{
	}

	public Transform GetRopeAttachPoint()
	{
		return null;
	}
}
