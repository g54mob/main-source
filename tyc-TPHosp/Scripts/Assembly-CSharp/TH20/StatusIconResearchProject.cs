using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class StatusIconResearchProject : StatusIcon
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
				ResearchProjectComponent component = _item.GetComponent<ResearchProjectComponent>();
				if (component != null && component.Project != null)
				{
					ResearchProject project = component.Project;
					_image.sprite = project.Definition.Icon;
					_progressBar.Progress = project.ResearchedPoints / project.Definition.ResearchPoints;
				}
			}
		}
	}
}
