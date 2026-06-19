using PlayerState;
using Pug.UnityExtensions;
using Unity.Mathematics;
using UnityEngine;

public class FishingUI : MonoBehaviour
{
	public GameObject root;

	public SpriteRenderer idleRod;

	public SpriteRenderer reelingRod;

	public SpriteRenderer fishIcon;

	public Transform fishHookPosition;

	public Transform rodTip;

	public Transform rodTipWhenReeling;

	public LineRenderer line;

	public Transform tensionBarMaskPivot;

	public SpriteRenderer tensionBar;

	public Sprite smallFishIcon;

	public Sprite smallFishRedIcon;

	public Sprite bigFishIcon;

	public Sprite bigFishRedIcon;

	public Color redColor;

	public Color redFishColor;

	public Color greenFishColor;

	private float fishAlpha = 1f;

	public ParticleSystem snapParticles;

	private MiniGameOutcome prevMiniGameOutCome;

	private bool uiWasActiveLastFrame;

	public Animator animator;

	private void LateUpdate()
	{
		root.transform.localScale = Manager.ui.CalcGameplayUITargetScaleMultiplier();
		PlayerController player = Manager.main.player;
		if (player != null && EntityUtility.GetComponentData<PlayerStateCD>(player.entity, player.world).HasAnyState(PlayerStateEnum.Fishing) && EntityUtility.GetComponentData<FishingStateCD>(player.entity, player.world).useFishingMiniGame && EntityUtility.GetComponentData<FishingMiniGameStateCD>(player.entity, player.world).isInFishingMiniGame)
		{
			root.SetActive(value: true);
			UpdateVisuals();
			uiWasActiveLastFrame = true;
			return;
		}
		root.SetActive(value: false);
		if (uiWasActiveLastFrame)
		{
			animator.SetTrigger(2043490037);
		}
		uiWasActiveLastFrame = false;
	}

	private void UpdateVisuals()
	{
		if (!uiWasActiveLastFrame)
		{
			animator.SetTrigger(2039883312);
		}
		PlayerController player = Manager.main.player;
		EntityUtility.TryGetComponentData<FishingMiniGameStateCD>(player.entity, player.world, out var value);
		bool flag = value.miniGameOutcome == MiniGameOutcome.LineSnapped || value.miniGameOutcome == MiniGameOutcome.FishEscaped;
		line.gameObject.SetActive(!flag);
		float y = ((value.fishIsStruggling && value.playerReeling) ? (math.sin(Time.time * 64f) * 0.1f - 0.05f) : (value.fishIsStruggling ? (math.sin(Time.time * 32f) * 0.1f - 0.05f) : 0f));
		fishIcon.transform.localPosition = new Vector3(value.fishPosition * 3f, y, 0f);
		tensionBarMaskPivot.localScale = new Vector3(value.lineTension, 1f, 1f);
		bool flag2 = value.miniGameOutcome == MiniGameOutcome.FishCaught;
		fishIcon.color = (flag2 ? greenFishColor : (value.fishIsStruggling ? redFishColor : Color.white));
		if (flag)
		{
			fishAlpha = math.max(0f, fishAlpha - Time.deltaTime);
		}
		else
		{
			fishAlpha = 1f;
		}
		fishIcon.SetAlpha(fishAlpha);
		bool playerReeling = value.playerReeling;
		idleRod.gameObject.SetActive(!playerReeling);
		reelingRod.gameObject.SetActive(playerReeling);
		Vector3 position = (playerReeling ? rodTipWhenReeling.transform.position : rodTip.transform.position);
		line.SetPosition(0, position);
		line.SetPosition(1, fishHookPosition.position);
		Color color = ((value.fishIsStruggling && value.playerReeling) ? redColor : Color.white);
		line.startColor = color;
		line.endColor = color;
		tensionBar.color = Color.Lerp(Color.white, redColor, value.lineTension);
		FishingStateCD componentData = EntityUtility.GetComponentData<FishingStateCD>(player.entity, player.world);
		Rarity rarity = Rarity.Common;
		if (componentData.fishingLootToSpawn != ObjectID.None)
		{
			ObjectInfo objectInfo = PugDatabase.GetObjectInfo(componentData.fishingLootToSpawn);
			if (objectInfo != null)
			{
				rarity = objectInfo.rarity;
			}
		}
		if (rarity >= Rarity.Rare)
		{
			fishIcon.sprite = (value.fishIsStruggling ? smallFishRedIcon : smallFishIcon);
		}
		else
		{
			fishIcon.sprite = (value.fishIsStruggling ? bigFishRedIcon : bigFishIcon);
		}
		if (prevMiniGameOutCome != value.miniGameOutcome)
		{
			if (value.miniGameOutcome == MiniGameOutcome.FishCaught)
			{
				Vector3 vector = new Vector3(0.0625f, 0f, 0f);
				SpriteTempEffect spriteTempEffect = Manager.effects.PlayTempSprite(SpriteTempEffectID.Flash, fishIcon.transform.position + vector, 0.5f);
				spriteTempEffect.SetSortingLayer(SortingLayerID.GUI);
				spriteTempEffect.SetSortingOrder(15);
				spriteTempEffect.gameObject.layer = ObjectLayerID.UI;
			}
			else if (value.miniGameOutcome == MiniGameOutcome.LineSnapped)
			{
				Vector2 vector2 = new Vector2(rodTip.transform.position.x - fishHookPosition.position.x, rodTip.transform.position.y - fishHookPosition.position.y);
				float num = Mathf.Atan2(vector2.y, vector2.x);
				snapParticles.transform.localEulerAngles = new Vector3(0f, 0f, 57.29578f * num);
				snapParticles.transform.position = (rodTip.transform.position + fishHookPosition.position) / 2f;
				ParticleSystem.ShapeModule shape = snapParticles.shape;
				shape.radius = vector2.magnitude / 2f;
				snapParticles.Play();
			}
		}
		prevMiniGameOutCome = value.miniGameOutcome;
	}
}
