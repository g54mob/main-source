using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Obj_UI_SkeletonKingCurseCard : MonoBehaviour
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
	private List<Image> list_ImageForGrayscale;

	[SerializeField]
	private Material material_Grayscale;

	[SerializeField]
	private ParticleSystem particle_Spark;

	[SerializeField]
	private GameObject node_SelectOutline;

	private PerkSettingData data_Buff;

	private PerkSettingData data_Debuff;

	private UI_ChooseSkeletonKingPerk_Popup parent;

	public Button Button => null;

	private void FetchAllImagesForGrayscale()
	{
	}

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

	public void Setup(PerkSettingData data_Buff, PerkSettingData data_Debuff, UI_ChooseSkeletonKingPerk_Popup parent)
	{
	}

	public void SetUnclickable()
	{
	}

	public void TurnGrayscale()
	{
	}

	public void Toggle(bool isOn)
	{
	}
}
