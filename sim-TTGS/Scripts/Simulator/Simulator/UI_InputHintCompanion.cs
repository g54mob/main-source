using System.Collections.ObjectModel;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Simulator
{
	public class UI_InputHintCompanion : MonoBehaviour
	{
		[Header("Prefabs")]
		[SerializeField]
		private Transform m_inputHintContainer;

		[SerializeField]
		private UI_InputHint m_inputHintPrefab;

		[SerializeField]
		private GameObject m_inputHintSeparatorPrefab;

		[Header("Settings")]
		[SerializeField]
		private EnumValues<InputsUISettings.EInteractionType, Sprite> m_interactionSpriteByInteractionType;

		[SerializeField]
		private EnumValues<InputsUISettings.EInteractionType, float> m_textSizeByInteractionType;

		[SerializeField]
		private string m_baseActionPrefix;

		[SerializeField]
		private TMP_Text m_actionText;

		[SerializeField]
		private LayoutGroup m_layoutGroupToRefresh;

		public void Setup(InputHint.DisplayData displayData)
		{
			DestroyPreviousInputs();
			SetupInputs(displayData.InputContainers);
			m_actionText.text = m_baseActionPrefix + " " + displayData.ActionText;
			m_layoutGroupToRefresh.RefreshLayoutGroupsImmediateAndRecursive();
		}

		private void DestroyPreviousInputs()
		{
			for (int num = m_inputHintContainer.childCount - 1; num >= 0; num--)
			{
				Object.Destroy(m_inputHintContainer.GetChild(num).gameObject);
			}
		}

		private void SetupInputs(ReadOnlyCollection<InputsUISettings.Container> inputsContainers)
		{
			if (inputsContainers.Count == 0)
			{
				Debug.LogError("No inputs provided for the current controller to setup input hints.");
				return;
			}
			for (int i = 0; i < inputsContainers.Count - 1; i++)
			{
				SetupInput(inputsContainers[i]);
				Object.Instantiate(m_inputHintSeparatorPrefab, m_inputHintContainer);
			}
			SetupInput(inputsContainers[inputsContainers.Count - 1]);
		}

		private void SetupInput(InputsUISettings.Container inputContainer)
		{
			UI_InputHint uI_InputHint = Object.Instantiate(m_inputHintPrefab, m_inputHintContainer);
			if (inputContainer.Sprite != null)
			{
				uI_InputHint.InteractionImage.sprite = inputContainer.Sprite;
				uI_InputHint.HoldImage.enabled = inputContainer.CurrentDevice == EInputDeviceType.GAMEPAD && inputContainer.interactionType == InputsUISettings.EInteractionType.HOLD;
				uI_InputHint.InputTextComponent.enabled = false;
			}
			else
			{
				uI_InputHint.InteractionImage.sprite = m_interactionSpriteByInteractionType[inputContainer.interactionType];
				uI_InputHint.InputTextComponent.fontSize = m_textSizeByInteractionType[inputContainer.interactionType];
				uI_InputHint.InputTextComponent.text = inputContainer.name;
				uI_InputHint.InputTextComponent.enabled = true;
				uI_InputHint.HoldImage.enabled = false;
			}
			uI_InputHint.InteractionImage.enabled = uI_InputHint.InteractionImage.sprite != null;
		}
	}
}
