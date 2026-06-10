using System;
using System.Text;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix.Base;
using NSEipix.View.UI;
using NSMedieval.Manager;
using NSMedieval.Roles;
using NSMedieval.State;
using NSMedieval.UI.Utils;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace NSMedieval.UI
{
	public class RoleLayoutItemView : LayoutGroupItemView
	{
		[SerializeField]
		private TMP_Text titleText;

		[SerializeField]
		private GameObject selectedImage;

		[SerializeField]
		private TMP_Text descriptionText;

		[SerializeField]
		private Image roleIconImage;

		[SerializeField]
		private ButtonLayoutItemView assignButton;

		[SerializeField]
		private ButtonLayoutItemView retractButton;

		[SerializeField]
		private TMP_Text assignDescriptionLabel;

		[NonSerialized]
		private UnityAction<Role> assignAction;

		[NonSerialized]
		private UnityAction<Role> retractAction;

		[NonSerialized]
		private Role role;

		[NonSerialized]
		private readonly StringBuilder sb = new StringBuilder();

		[NonSerialized]
		private HumanoidInstance humanoidInstance;

		[SerializeField]
		private GameObject debugGroup;

		[SerializeField]
		private TMP_Text debugLevelText;

		[SerializeField]
		private SoundButton debugLevelUpButton;

		[SerializeField]
		private SoundButton debugLevelDownButton;

		private void Start()
		{
			retractButton.Button.onClick.AddListener(OnRetractButtonClicked);
			assignButton.Button.onClick.AddListener(OnAssignButtonClicked);
			debugGroup.SetActive(value: false);
		}

		public void SetData(Role role, HumanoidInstance humanoidInstance, UnityAction<Role> onAssign, UnityAction<Role> onRetract)
		{
			this.role = role;
			this.humanoidInstance = humanoidInstance;
			assignAction = onAssign;
			retractAction = onRetract;
			Refresh();
		}

		private void Refresh()
		{
			titleText.SetText(base.Localize.GetText(LocKeyUtils.GetName(role.LocKeys), this.humanoidInstance.Info.BodyType));
			selectedImage.SetActive(this.humanoidInstance.WorkerBehaviour.HumanoidRoleOwner.HasRole(role));
			roleIconImage.sprite = AssetUtils.GetSprite(role.IconPath);
			descriptionText.SetText(GetDescription());
			assignDescriptionLabel.gameObject.SetActive(value: false);
			bool isEnabled;
			if (MonoSingleton<WorkerManager>.Instance.IsRoleTaken(role, out var humanoidInstance))
			{
				if (humanoidInstance != this.humanoidInstance)
				{
					FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(26, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\UI\\Base\\RoleLayoutItemView.cs");
					if (isEnabled)
					{
						messageBuilder.AppendFormatted(role);
						messageBuilder.AppendLiteral(" is taken by someone other");
					}
					Log.Trace(messageBuilder);
					retractButton.gameObject.SetActive(value: false);
					assignButton.gameObject.SetActive(value: false);
					assignDescriptionLabel.gameObject.SetActive(value: true);
					assignDescriptionLabel.SetText(base.Localize.GetText("role_assigned_to_info") + ": " + UiUtils.GetWorkerLink(humanoidInstance));
				}
				else if (this.humanoidInstance.WorkerBehaviour.HumanoidRoleOwner.HasRole(role) && this.humanoidInstance.WorkerBehaviour.HumanoidRoleOwner.RoleLevel == role.MaxLevel)
				{
					FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(25, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\UI\\Base\\RoleLayoutItemView.cs");
					if (isEnabled)
					{
						messageBuilder.AppendLiteral("Has ");
						messageBuilder.AppendFormatted(role);
						messageBuilder.AppendLiteral(" and is Maxed Level: ");
						messageBuilder.AppendFormatted(this.humanoidInstance.WorkerBehaviour.HumanoidRoleOwner.RoleLevel == role.MaxLevel);
					}
					Log.Trace(messageBuilder);
					retractButton.gameObject.SetActive(this.humanoidInstance.WorkerBehaviour.HumanoidRoleOwner.HasRole(role));
					assignButton.gameObject.SetActive(value: false);
					assignDescriptionLabel.gameObject.SetActive(value: true);
					assignDescriptionLabel.SetText(base.Localize.GetText("role_max") ?? "");
					titleText.SetText(base.Localize.GetText(LocKeyUtils.GetName(role.LocKeys), this.humanoidInstance.Info.BodyType) + " " + HumanoidRoleUtils.GetLevelNumeral(this.humanoidInstance.WorkerBehaviour.HumanoidRoleOwner.RoleLevel));
				}
				else
				{
					EnableRoleTaking();
				}
			}
			else if (this.humanoidInstance.WorkerBehaviour.HumanoidRoleOwner.AssignedRole)
			{
				FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(51, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\UI\\Base\\RoleLayoutItemView.cs");
				if (isEnabled)
				{
					messageBuilder.AppendFormatted(role);
					messageBuilder.AppendLiteral(" is not taken but this humanoid has some other role");
				}
				Log.Trace(messageBuilder);
				retractButton.gameObject.SetActive(value: false);
				assignButton.gameObject.SetActive(value: false);
				assignDescriptionLabel.gameObject.SetActive(value: true);
				assignDescriptionLabel.SetText(base.Localize.GetText("role_retract_first_info") + ": " + UiUtils.GetWorkerLink(this.humanoidInstance));
			}
			else
			{
				EnableRoleTaking();
			}
			void EnableRoleTaking()
			{
				assignDescriptionLabel.gameObject.SetActive(value: false);
				retractButton.gameObject.SetActive(this.humanoidInstance.WorkerBehaviour.HumanoidRoleOwner.HasRole(role));
				debugLevelText.gameObject.SetActive(value: true);
				assignButton.gameObject.SetActive(value: true);
				assignButton.Button.interactable = this.humanoidInstance.WorkerBehaviour.HumanoidRoleOwner.CanRoleBeLeveledUp(role);
				int num = -1;
				if (this.humanoidInstance.WorkerBehaviour.HumanoidRoleOwner.HasRole(role))
				{
					num = this.humanoidInstance.WorkerBehaviour.HumanoidRoleOwner.RoleLevel;
				}
				assignButton.SetButtonData((num < 0) ? base.Localize.GetText("role_assign") : base.Localize.GetText("role_promote"));
				assignButton.SetTooltipLines(HumanoidRoleUtils.GetRoleLevelUpTooltipLines(this.humanoidInstance, role));
				num = Mathf.Clamp(num + 1, 0, role.RoleLevels.Length - 1);
				titleText.SetText(base.Localize.GetText(LocKeyUtils.GetName(role.LocKeys), this.humanoidInstance.Info.BodyType) + " " + HumanoidRoleUtils.GetLevelNumeral(num));
			}
		}

		private string GetDescription()
		{
			sb.Clear();
			sb.Append(HumanoidRoleUtils.GetRoleDescription(role, humanoidInstance, nextLevel: true));
			sb.Append("\n\n");
			sb.Append(HumanoidRoleUtils.GetRoleInfo(role, humanoidInstance));
			return sb.ToString();
		}

		private void OnAssignButtonClicked()
		{
			assignAction?.Invoke(role);
		}

		private void OnRetractButtonClicked()
		{
			retractAction?.Invoke(role);
		}
	}
}
