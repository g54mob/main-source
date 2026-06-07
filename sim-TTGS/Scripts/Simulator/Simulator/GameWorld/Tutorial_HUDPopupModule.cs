using I2.Loc;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Simulator.GameWorld
{
	public class Tutorial_HUDPopupModule : HUDPopupModule
	{
		[SerializeField]
		private Image m_image;

		[SerializeField]
		private TMP_Text m_title;

		[SerializeField]
		private TMP_Text m_description;

		public override EHUDPopupModuleType Type => EHUDPopupModuleType.TUTORIAL;

		public override bool StackInputMap => true;

		protected override void OnSetActive()
		{
			base.OnSetActive();
			SetContent(Tutorial.CurrentData);
			Time.timeScale = 0f;
		}

		protected override void OnSetInactive()
		{
			base.OnSetInactive();
			Time.timeScale = 1f;
		}

		protected override void SetCursor()
		{
			CursorManager.StackState(base.Cursor);
		}

		protected override void ResetCursor()
		{
			CursorManager.PopCurrent();
		}

		private void SetContent(TutorialData data)
		{
			m_image.sprite = data.Sprite;
			m_title.text = LocalizationManager.GetTranslation(data.TitleTerm);
			m_description.text = LocalizationManager.GetTranslation(data.DescriptionTerm);
		}

		public override bool OverrideCancel()
		{
			return true;
		}
	}
}
