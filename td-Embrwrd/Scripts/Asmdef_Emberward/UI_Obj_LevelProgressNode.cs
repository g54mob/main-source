using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_Obj_LevelProgressNode : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
{
	[SerializeField]
	private Transform node_Content;

	[SerializeField]
	private TMP_Text text_Round;

	[SerializeField]
	private Image image_Icon_1;

	[SerializeField]
	private Image image_Icon_2;

	[SerializeField]
	private Image image_LargeNode;

	[SerializeField]
	private Image image_SmallNode;

	[SerializeField]
	private Sprite sprite_Node_Full_Small;

	[SerializeField]
	private Sprite sprite_Node_Full_Large;

	[SerializeField]
	private Sprite sprite_Icon_Tower;

	[SerializeField]
	private Sprite sprite_Icon_Block;

	[SerializeField]
	private Sprite sprite_Icon_Relic;

	[SerializeField]
	private Sprite sprite_Icon_RerollToken;

	[SerializeField]
	private Sprite sprite_Icon_SkeletonKingTrial;

	[SerializeField]
	private Sprite sprite_Icon_TreasureChest;

	[SerializeField]
	private Sprite sprite_Icon_HPRecovery;

	[SerializeField]
	private Sprite sprite_Icon_SceneReset;

	[SerializeField]
	private Sprite sprite_Icon_XmasGift;

	[SerializeField]
	private Material material_Glow;

	private EndlessModeRoundReward reward;

	private bool isTooltipOn;

	public void Setup(int round, EndlessModeRoundReward reward)
	{
	}

	public void SetIconByRewardType(Image image_Icon, eEndlessModeRoundRewardType rewardType)
	{
	}

	public void SetColor(Color color)
	{
	}

	public void ToggleCurrentWave(bool isOn)
	{
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
	}

	public void OnPointerExit(PointerEventData eventData)
	{
	}
}
