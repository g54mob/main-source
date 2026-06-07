using System.Collections.Generic;
using I2.Loc;
using MEC;
using UnityEngine;
using UnityEngine.UI;

public class PetLabUI : OverlayUI
{
	public static PetLabUI I;

	public CoolButton BtnClose;

	public PetLabPage CurPage;

	public GameObject WrapperLabItems;

	[NamedArray(typeof(PetLabPage))]
	public GameObject[] Wrappers;

	public RectTransform XfmLabItems;

	public HorizontalLayoutGroup GrpLabItems;

	public PetLabItem[] LabItems;

	private List<PetInst> _petList;

	private List<PetInst> _selectedPets;

	[Header("Test Tube")]
	public GameObject WrapperTestTubeTitle;

	public Localize LocTestTubeProgress;

	public GameObject WrapperTestTubeProgress;

	public Image TestTubeProgressFill;

	public TestTubeItem[] TestTubeItems;

	public CoolButton BtnUpgrade;

	private int _curTestTubeIdx;

	[Header("Select Pets")]
	public ScrollRect ScrlPickPet;

	public SerializedObjectPool<PetLabSelectItem> PetItemPool;

	public GameObject WrapperNoneAvail;

	[Header("Confirm Fusion")]
	public CoolButton BtnConfirmFusion;

	[Header("Reveal Fusion")]
	public PetDisplayItem FusionCompleteItem;

	public GameObject WrapperFusionCompleteExtraInfo;

	public CoolButton BtnFusionComplete;

	private CoroutineHandle _revealAnim;

	private bool _isRevealingFusion;

	public const int kFusionCount = 2;

	private const float kDefaultLabY = -30f;

	private const float kDefaultGrpSpacing = 5f;
}
