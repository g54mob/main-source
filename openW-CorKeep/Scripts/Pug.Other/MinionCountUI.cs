#define PUG_ACHIEVEMENTS
using System.Collections.Generic;
using UnityEngine;

public class MinionCountUI : UIelement
{
	public GameObject container;

	private const string minionCountDescTerm = "MinionCountDesc";

	private const string minionCountFormat = "MinionCountFormat";

	public PugText minionCountText;

	public PugText minionCountTextShadow;

	public ConditionsContainerUI conditionsContainerUI;

	public BoxCollider boxColl;

	private string activeMinions;

	private string maxMinions;

	private void Update()
	{
		PlayerController player = Manager.main.player;
		if (Manager.sceneHandler == null || !Manager.sceneHandler.isInGame || player == null)
		{
			DisableRendering();
			return;
		}
		if (!EntityUtility.TryGetComponentData<MinionCountTrackerCD>(player.entity, player.world, out var value) || value.count == 0)
		{
			DisableRendering();
			return;
		}
		if (value.count > 7 && !Manager.achievements.HasTriggeredAchievement(AchievementID.SummonManyMinions))
		{
			Manager.achievements.TriggerAchievement(AchievementID.SummonManyMinions);
		}
		container.gameObject.SetActive(value: true);
		boxColl.enabled = true;
		int a = MinionExtensions.GetMaxMinions(EntityUtility.GetBuffer<SummarizedConditionEffectsBuffer>(player.entity, player.world));
		activeMinions = Mathf.Min(a, value.count).ToString();
		maxMinions = a.ToString();
		minionCountText.formatFields = new string[2] { activeMinions, maxMinions };
		minionCountText.Render("MinionCountFormat");
		minionCountTextShadow.formatFields = new string[2] { activeMinions, maxMinions };
		minionCountTextShadow.Render("MinionCountFormat");
		Vector3 position = container.transform.position;
		float bottomPosition = conditionsContainerUI.GetBottomPosition();
		container.transform.position = new Vector3(position.x, bottomPosition, position.z);
		boxColl.center = new Vector2(boxColl.center.x, container.transform.localPosition.y);
	}

	private void DisableRendering()
	{
		container.gameObject.SetActive(value: false);
		boxColl.enabled = false;
	}

	protected override void LateUpdate()
	{
		container.transform.localScale = Manager.ui.CalcGameplayUITargetScaleMultiplier();
		base.LateUpdate();
	}

	public override List<TextAndFormatFields> GetHoverDescription()
	{
		List<TextAndFormatFields> list = new List<TextAndFormatFields>();
		list.Add(new TextAndFormatFields
		{
			text = PugText.ProcessText("MinionCountDesc", new string[2] { activeMinions, maxMinions }, shouldLocalize: true, shouldLocalizeFormatFields: false),
			color = Color.white * 0.95f,
			dontLocalize = true
		});
		return list;
	}

	public override HoverWindowAlignment GetHoverWindowAlignment()
	{
		return HoverWindowAlignment.BOTTOM_RIGHT_OF_CURSOR;
	}
}
