using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Obj_UI_PerkCard : MonoBehaviour
{
	[SerializeField]
	private Animator animator;

	[SerializeField]
	private TMP_Text text_Buff;

	[SerializeField]
	private TMP_Text text_Debuff;

	[SerializeField]
	private Image image_BuffIcon;

	[SerializeField]
	private Image image_DebuffIcon;

	[SerializeField]
	private Button button;

	[SerializeField]
	private GameObject node_ItemReward;

	[SerializeField]
	private UI_Obj_ShopCard shopCard;

	[SerializeField]
	private ParticleSystem particle_Spark;

	[SerializeField]
	private GameObject node_SelectOutline;

	private PerkSettingData data_Buff;

	private PerkSettingData data_Debuff;

	private UI_ChooseRoguelitePerk_Popup parent;

	private eItemType extraRewardItemType;

	public Button Button => null;

	private void Awake()
	{
	}

	private void OnEnable()
	{
	}

	private void OnButtonSelect()
	{
	}

	private void OnButtonDeselect()
	{
	}

	private void OnClickButton()
	{
	}

	private void OnDisable()
	{
	}

	private void OnClick()
	{
	}

	public void Setup(PerkSettingData data_Buff, PerkSettingData data_Debuff, UI_ChooseRoguelitePerk_Popup parent, eItemType extraRewardItemType = eItemType.NONE)
	{
	}

	public void Toggle(bool isOn)
	{
	}
}
