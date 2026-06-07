using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Simulator
{
	public class UI_InputHint : MonoBehaviour
	{
		[SerializeField]
		private Image m_interactionImage;

		[SerializeField]
		private TMP_Text m_inputTextComponent;

		[SerializeField]
		private Image m_holdImage;

		public Image InteractionImage => m_interactionImage;

		public TMP_Text InputTextComponent => m_inputTextComponent;

		public Image HoldImage => m_holdImage;
	}
}
