using JetBrains.Annotations;
using Restory.Constants;
using Restory.Data.Equipment;
using UnityEngine;

namespace Restory.Gameplay.Equipment.Views
{
	public sealed class BrushCleaningToolView : ToolView
	{
		[SerializeField]
		private Animator animator;

		[SerializeField]
		private GameObject emptyModel;

		[SerializeField]
		private GameObject[] modelsForBrushLevels = new GameObject[0];

		[SerializeField]
		private Transform vfxSpawnPoint;

		private int highestBrushLevel;

		public override void SetTool(ToolInfo toolInfo, bool instantly)
		{
			if ((bool)toolInfo && toolInfo.ToolLevel > highestBrushLevel)
			{
				highestBrushLevel = toolInfo.ToolLevel;
			}
			if (emptyModel.activeSelf)
			{
				if (instantly || !toolInfo)
				{
					animator.SetTrigger(ProjectConstants.Animations.ActivateInstantlyTrigger);
				}
				else
				{
					animator.SetTrigger(ProjectConstants.Animations.ActivateTrigger);
				}
			}
			else
			{
				OnAnimationComplete();
				PlayPlacementEffect(vfxSpawnPoint ? vfxSpawnPoint.transform : base.transform);
			}
		}

		[UsedImplicitly]
		public void OnAnimationComplete()
		{
			for (int i = 0; i < modelsForBrushLevels.Length; i++)
			{
				modelsForBrushLevels[i].SetActive(i == highestBrushLevel);
			}
			emptyModel.gameObject.SetActive(value: false);
		}
	}
}
