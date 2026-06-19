using BehaviorDesigner.Runtime.Tasks;
using JetBrains.Annotations;
using UnityEngine;

namespace TH20.BTA.Metagame
{
	[TaskCategory(" TH20/Metagame Script")]
	[TaskIcon("Assets/Editor/BehaviorDesigner/Icons/AdvisorIcon.png")]
	[UsedImplicitly(ImplicitUseTargetFlags.Members)]
	public class ShowAdvisor : MetagameAction
	{
		[SerializeField]
		private string _message;

		[SerializeField]
		private Sprite _icon;

		[SerializeField]
		private LocalisedString _messageLocalised;

		[SerializeField]
		private float _displayTime = 20f;

		[SerializeField]
		private bool _userCanDismiss = true;

		[SerializeField]
		private AdvisorDisplayType _displayType;

		[SerializeField]
		private RuntimeAnimatorController _overrideAnimationGraph;

		public override TaskStatus OnUpdate()
		{
			AdvisorMenu advisorMenu = base.Owner.MetagameMap.HUD.FindMenu<AdvisorMenu>();
			if (advisorMenu != null)
			{
				advisorMenu.ShowAdvisorMessage(new AdvisorMessageDefinition
				{
					LocalisedMessage = _messageLocalised,
					Message = _message,
					Icon = _icon,
					Duration = _displayTime,
					DisplayType = _displayType,
					ShowIndefinitely = false,
					UserCanDismiss = _userCanDismiss,
					OverrideAnimationGraph = _overrideAnimationGraph
				});
			}
			return TaskStatus.Success;
		}
	}
}
