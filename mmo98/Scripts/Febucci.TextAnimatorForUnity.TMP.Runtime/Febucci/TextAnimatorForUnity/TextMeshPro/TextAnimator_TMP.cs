using Febucci.Parsing.Core;
using Febucci.TextAnimatorCore.Text;
using TMPro;
using UnityEngine;

namespace Febucci.TextAnimatorForUnity.TextMeshPro
{
	[RequireComponent(typeof(TMP_Text))]
	[AddComponentMenu("Febucci/TextAnimator/Text Animator - Text Mesh Pro")]
	public sealed class TextAnimator_TMP : TextAnimatorComponentBase
	{
		private TMP_Text tmpComponent;

		private TMP_InputField inputField;

		private TMProTextProvider generator;

		private bool componentsCached;

		private bool isUI;

		public TMP_Text TMProComponent
		{
			get
			{
				if ((bool)tmpComponent)
				{
					return tmpComponent;
				}
				CacheComponentsOnce();
				return tmpComponent;
			}
		}

		private void CacheComponentsOnce()
		{
			if (!componentsCached)
			{
				if (!base.gameObject.TryGetComponent<TMP_Text>(out tmpComponent))
				{
					Debug.LogError("TextAnimator_TMP " + base.name + " requires a TMP_Text component to work.", base.gameObject);
				}
				base.gameObject.TryGetComponent<TMP_InputField>(out inputField);
				componentsCached = true;
				isUI = tmpComponent is TextMeshProUGUI;
				generator = new TMProTextProvider(tmpComponent, inputField);
			}
		}

		protected override bool IsReady()
		{
			if (componentsCached)
			{
				if (isUI)
				{
					return tmpComponent.canvas;
				}
				return true;
			}
			return false;
		}

		protected override ITextGenerator GetTextGenerator()
		{
			CacheComponentsOnce();
			return generator;
		}

		protected override bool IsUpPositive()
		{
			return true;
		}

		protected override TagParserBase[] GetExtraParsers()
		{
			return new TagParserBase[1]
			{
				new TMPTagParser(tmpComponent.richText, '<', '/', '>')
			};
		}
	}
}
