using UnityEngine;
using TMPro;

namespace SPACE__SYNTAX_HIGHLIGHTER__SYSTEM
{
	/// <summary>
	/// Abstract base class for twin-layer overlay syntax highlighting
	/// Provides extensibility for different programming languages
	/// </summary>
	public abstract class SyntaxHighlighterBase : MonoBehaviour
	{
		[TextArea(minLines: 3, maxLines: 5)]
		[SerializeField] private string README = $@"0. have reference of the child from ${typeof(SyntaxHighlighterBase).Name} externally (eg: via inspector)
1. call the public API .UpdateSyntaxVisual() when update of syntax required";

		[Header("TextMeshPro References")]
		[SerializeField] protected TextMeshPro sourceText;        // Plain text (no rich text)
		[SerializeField] protected TextMeshPro syntaxOverlayText; // Rich text overlay

		[Header("Settings")]
		[SerializeField] protected bool enableHighlighting = true;

		/// <summary>
		/// Public API: Call this to update syntax highlighting
		/// Should be called whenever source text changes
		/// </summary>
		public virtual void UpdateSyntaxVisual()
		{
			if (!enableHighlighting || sourceText == null || syntaxOverlayText == null)
			{
				if (syntaxOverlayText != null)
					syntaxOverlayText.text = sourceText?.text ?? "";
				return;
			}

			string plainText = sourceText.text;
			string highlightedText = ApplySyntaxHighlighting(plainText);
			syntaxOverlayText.text = highlightedText;
		}

		/// <summary>
		/// Override this method in derived classes for language-specific highlighting
		/// </summary>
		/// <param name="plainText">Raw text without formatting</param>
		/// <returns>Text with TMP color tags applied</returns>
		protected abstract string ApplySyntaxHighlighting(string plainText);

		/// <summary>
		/// Utility: Wrap text with TextMeshPro color tag
		/// </summary>
		/// <param name="text">Text to wrap</param>
		/// <param name="color">Unity Color struct</param>
		/// <returns>Text wrapped in color tags</returns>
		protected string ColorWrap(string text, Color color)
		{
			string hexColor = ColorUtility.ToHtmlStringRGB(color);
			return $"<color=#{hexColor}>{text}</color>";
		}

		/// <summary>
		/// Utility: Convert hex string to Color
		/// </summary>
		protected Color HexToColor(string hex)
		{
			if (ColorUtility.TryParseHtmlString("#" + hex, out Color color))
				return color;
			return Color.white;
		}

		/// <summary>
		/// Validate component setup in editor
		/// </summary>
		protected virtual void OnValidate()
		{
			if (sourceText == null)
				Debug.LogWarning($"[{GetType().Name}] Source TextMeshPro not assigned!", this);

			if (syntaxOverlayText == null)
				Debug.LogWarning($"[{GetType().Name}] Syntax Overlay TextMeshPro not assigned!", this);
		}

		private void Start()
		{
			Debug.Log("<color=white>made sourceText(TMP) invisible via color</color>");
			this.sourceText.color = new Color(0.8f, 0.8f, 0.8f, 0f);
		}
	}
}