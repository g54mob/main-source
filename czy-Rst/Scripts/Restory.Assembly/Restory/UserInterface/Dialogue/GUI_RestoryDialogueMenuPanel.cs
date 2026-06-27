using PixelCrushers.DialogueSystem;
using UnityEngine;
using Zenject;

namespace Restory.UserInterface.Dialogue
{
	public sealed class GUI_RestoryDialogueMenuPanel : StandardUIMenuPanel
	{
		private DiContainer diContainer;

		[Inject]
		private void Construct(DiContainer diContainer)
		{
			this.diContainer = diContainer;
		}

		public void ProcessMouseClick()
		{
			if (base.instantiatedButtons.Count == 1 && base.instantiatedButtons[0].TryGetComponent<GUI_RestoryDialogueResponseButton>(out var component))
			{
				component.OnClick();
			}
		}

		protected override GameObject InstantiateButton()
		{
			if (m_instantiatedButtonPool.Count > 0)
			{
				GameObject result = m_instantiatedButtonPool[0];
				m_instantiatedButtonPool.RemoveAt(0);
				return result;
			}
			return diContainer.InstantiatePrefab(buttonTemplate.gameObject);
		}
	}
}
