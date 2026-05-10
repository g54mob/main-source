using CTS.Core;
using PixelCrushers.DialogueSystem;
using UnityEngine;
using UnityEngine.Localization;

namespace CTS
{
	public class MainQuest01 : Level01Quest
	{
		[SerializeField]
		[Header("Camera Movement")]
		[QuestEntryPopup]
		private int _movementEntryID;

		[SerializeField]
		[VariablePopup(false)]
		private string _movementVariableName;

		[SerializeField]
		[VariablePopup(false)]
		private string _moveMaxVariableName;

		[SerializeField]
		private float _moveMaxVariableNameValue;

		[SerializeField]
		[Header("Camera Rotation")]
		[QuestEntryPopup]
		private int _rotationEntryID;

		[SerializeField]
		[VariablePopup(false)]
		private string _rotationVariableName;

		[SerializeField]
		[VariablePopup(false)]
		private string _rotationMaxVariableName;

		[SerializeField]
		private float _rotationMaxVariableNameValue;

		[SerializeField]
		[Header("Tooltip")]
		[QuestEntryPopup]
		private int _tooltipEntryID;

		[SerializeField]
		private WorkerSpawn _workerSpawn;

		[SerializeField]
		private LocalizedString _bark;

		protected override void OnResetQuest()
		{
			ResetVariableTo0(_movementVariableName);
			ResetVariableTo0(_rotationVariableName);
		}

		protected override void StartObservingObjectives()
		{
			DialogueLua.SetVariable(_moveMaxVariableName, _moveMaxVariableNameValue);
			DialogueLua.SetVariable(_rotationMaxVariableName, _rotationMaxVariableNameValue);
			if (MonoSingleton<MainCamera>.InstanceExists())
			{
				MonoSingleton<MainCamera>.Instance.Movements.OnValueChanged += OnCameraMovement;
				MonoSingleton<MainCamera>.Instance.CameraRotation.CameraRotated += OnCameraRotation;
				EntryHelpTooltip.EntryTooltipShowned += OnEntryTooltipShowned;
			}
		}

		protected override void StopObservingObjectives()
		{
			if (MonoSingleton<MainCamera>.InstanceExists())
			{
				MonoSingleton<MainCamera>.Instance.Movements.OnValueChanged -= OnCameraMovement;
				MonoSingleton<MainCamera>.Instance.CameraRotation.CameraRotated -= OnCameraRotation;
			}
			EntryHelpTooltip.EntryTooltipShowned -= OnEntryTooltipShowned;
		}

		private void OnEntryTooltipShowned()
		{
			EntryHelpTooltip.EntryTooltipShowned -= OnEntryTooltipShowned;
			QuestEntrySuccess(_tooltipEntryID);
		}

		private void OnCameraMovement(float p_distance)
		{
			if (QuestLog.GetQuestEntryState(_questName, _movementEntryID) == QuestState.Active && IncrementQuestEntryVariable(_movementEntryID, _movementVariableName, p_distance, _moveMaxVariableName))
			{
				QuestEntrySuccess(_movementEntryID);
				MonoSingleton<MainCamera>.Instance.Movements.OnValueChanged -= OnCameraMovement;
			}
		}

		private void OnCameraRotation(float p_rotationAngle)
		{
			if (QuestLog.GetQuestEntryState(_questName, _rotationEntryID) == QuestState.Active && IncrementQuestEntryVariable(_rotationEntryID, _rotationVariableName, p_rotationAngle, _rotationMaxVariableName))
			{
				QuestEntrySuccess(_rotationEntryID);
				MonoSingleton<MainCamera>.Instance.CameraRotation.CameraRotated -= OnCameraRotation;
			}
		}

		protected override void OnQuestSuccess()
		{
			base.OnQuestSuccess();
			base.QuestChain.FirstWorker = _workerSpawn.Spawn();
			base.QuestChain.FirstWorker.Dismissable = false;
			base.FirstWorker.Statistics.Paused = true;
			base.FirstWorker.ActionPlayer.AddAction(new AgentActionBark(_bark.GetLocalizedString(), 3f));
		}

		public override void SkipQuest()
		{
			base.SkipQuest();
			base.QuestChain.FirstWorker = _workerSpawn.Spawn();
			base.QuestChain.FirstWorker.Dismissable = false;
			base.FirstWorker.Statistics.Paused = true;
		}
	}
}
