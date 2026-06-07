using I2.Loc;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace PajamaLlama.Plugins.I2Language
{
	[ExecuteInEditMode]
	public class LocalizedText : MonoBehaviour
	{
		public enum LocalizedTextTargetType
		{
			Text = 0,
			TextMeshPro = 1
		}

		[SerializeField]
		private LocalizedString _text;

		[SerializeField]
		private LocalizedTextTargetType _targetType;

		[SerializeField]
		[ConditionalEnumHide("_targetType", 0, false, HideInInspector = true)]
		private Text _targetText;

		[SerializeField]
		[ConditionalEnumHide("_targetType", 1, false, HideInInspector = true)]
		private TextMeshProUGUI _targetTextMeshPro;

		private void Start()
		{
			UpdateText();
		}

		private void Update()
		{
			if (Application.isEditor)
			{
				UpdateText();
			}
		}

		private void UpdateText()
		{
			switch (_targetType)
			{
			case LocalizedTextTargetType.Text:
				if ((bool)_targetText)
				{
					_targetText.text = _text;
				}
				break;
			case LocalizedTextTargetType.TextMeshPro:
				if ((bool)_targetTextMeshPro)
				{
					_targetTextMeshPro.text = _text;
				}
				break;
			}
		}
	}
}
