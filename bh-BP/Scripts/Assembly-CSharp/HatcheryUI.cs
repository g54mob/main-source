using I2.Loc;
using MEC;
using UnityEngine;
using UnityEngine.UI;

public class HatcheryUI : OverlayUI
{
	public static HatcheryUI I;

	[NamedArray(typeof(HatcheryPage))]
	public GameObject[] Wrappers;

	public HatcheryPage CurPage;

	public CoolButton BtnClose;

	[Header("Incubators")]
	public HatcheryItem[] HatcheryItems;

	public CoolButton BtnUpgrade;

	public LocalizationParamsManager ParamsNumEggs;

	[Header("Pick Egg")]
	public ScrollRect ScrlPickEgg;

	public SerializedObjectPool<EggListItem> EggItemPool;

	[Header("Hatch Egg")]
	public RectTransform WrapperHatchingEgg;

	public Image ImgHatchingEgg;

	public RectTransform WrapperHatchedInfo;

	public PetDisplayItem HatchedDisplay;

	private bool _isHatchingEgg;

	private CoroutineHandle _hatchAnim;

	private CoroutineHandle _hatchSubAnim;

	private int _selectedIncubatorIdx;
}
