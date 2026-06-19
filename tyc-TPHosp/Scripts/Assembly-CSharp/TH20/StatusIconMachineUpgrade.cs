using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class StatusIconMachineUpgrade : StatusIcon
	{
		[SerializeField]
		private ProgressBar _progressBar;

		private RoomItem _item;

		public override void Initialise(IStatusIconEmitter emitter, Level level, int priority)
		{
			base.Initialise(emitter, level, priority);
			_item = emitter as RoomItem;
			Update();
		}

		private void Update()
		{
			RoomItemUpgradeComponent component = _item.GetComponent<RoomItemUpgradeComponent>();
			if (component != null)
			{
				_progressBar.Progress = component.Progress;
			}
		}

		public override bool HasTimedOut()
		{
			return _item.GetComponent<RoomItemUpgradeComponent>() == null;
		}
	}
}
