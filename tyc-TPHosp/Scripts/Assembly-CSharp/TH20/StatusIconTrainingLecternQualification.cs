using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class StatusIconTrainingLecternQualification : StatusIcon
	{
		[SerializeField]
		private Image _image;

		[SerializeField]
		private ProgressBar _progressBar;

		private RoomItem _item;

		public override void Initialise(IStatusIconEmitter emitter, Level level, int priority)
		{
			base.Initialise(emitter, level, priority);
			_item = emitter as RoomItem;
		}

		private void Update()
		{
			if (_item != null)
			{
				RoomLogicTrainingRoom component = _item.OwningRoom.GetComponent<RoomLogicTrainingRoom>();
				if (component != null && component.Qualification != null)
				{
					_image.sprite = component.Qualification.Icon;
					_progressBar.Progress = GameAlgorithms.CalculateTrainingCourseProgress(component.Qualification, component.Pupils);
				}
			}
		}

		public override bool HasTimedOut()
		{
			if (_item != null)
			{
				return _item.OwningRoom.GetComponent<RoomLogicTrainingRoom>()?.IsAvailable ?? false;
			}
			return true;
		}
	}
}
