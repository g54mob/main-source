using JetBrains.Annotations;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class HoverMenuVisitor : HoverMenuCharacter
	{
		private Visitor _visitor;

		[SerializeField]
		private TMP_Text _name;

		[SerializeField]
		private TMP_Text _jobText;

		[SerializeField]
		private TMP_Text _actionText;

		[SerializeField]
		private TMP_Text _stateText;

		[SerializeField]
		private Image _statusIcon;

		public override void Setup(Character character, Level level)
		{
			base.Setup(character, level);
			_visitor = (Visitor)character;
		}

		protected override void Update()
		{
			base.Update();
			_name.text = _visitor.Name;
			_jobText.text = _visitor.Definition.JobTitleLocalised.Translation;
			_actionText.text = _visitor.GetGUIActionText();
			_stateText.text = _visitor.GetGUIActionText();
			Sprite statusSprite = _visitor.GetStatusSprite();
			if (statusSprite != null)
			{
				_statusIcon.sprite = statusSprite;
				_statusIcon.gameObject.SetActive(value: true);
				_stateText.gameObject.SetActive(value: false);
			}
			else
			{
				_statusIcon.gameObject.SetActive(value: false);
				_stateText.gameObject.SetActive(value: true);
			}
		}
	}
}
