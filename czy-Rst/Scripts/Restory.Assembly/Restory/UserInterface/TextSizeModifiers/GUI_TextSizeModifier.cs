using System;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Restory.UserInterface.TextSizeModifiers
{
	public class GUI_TextSizeModifier : MonoBehaviour
	{
		[SerializeField]
		private string debugString;

		[SerializeField]
		private bool ignore;

		[SerializeField]
		private TMP_Text textMeshPro;

		[SerializeField]
		private Text text;

		[SerializeField]
		private TextSizeProfile profile;

		private TextSizeModifier.Factory factory;

		private TextSizeModifier textSizeModifier;

		private bool ready;

		public bool Ignore
		{
			get
			{
				return ignore;
			}
			set
			{
				ignore = value;
			}
		}

		[Inject]
		private void Construct(TextSizeModifier.Factory factory)
		{
			this.factory = factory;
			CreateModifier();
			if (base.isActiveAndEnabled)
			{
				OnEnable();
			}
		}

		private void OnEnable()
		{
			if (textSizeModifier != null)
			{
				textSizeModifier.OnEnable();
				textSizeModifier.OnUpdated -= UpdateDebugString;
				textSizeModifier.OnUpdated += UpdateDebugString;
			}
			UpdateDebugString();
		}

		private void OnDisable()
		{
			if (textSizeModifier != null)
			{
				textSizeModifier.OnDisable();
				textSizeModifier.OnUpdated -= UpdateDebugString;
			}
		}

		private void OnDestroy()
		{
			textSizeModifier?.Dispose();
			textSizeModifier = null;
		}

		private void CreateModifier()
		{
			if (textSizeModifier != null)
			{
				textSizeModifier.Dispose();
				textSizeModifier = null;
			}
			GetTextComponents();
			textSizeModifier = factory.Create();
			textSizeModifier.Setup(textMeshPro, text, ignore, profile);
			UpdateDebugString();
		}

		private void OnValidate()
		{
			if (profile == null)
			{
				TextSizeProfile textSizeProfile = Resources.FindObjectsOfTypeAll<TextSizeProfile>().FirstOrDefault((TextSizeProfile x) => x.name.Contains("default", StringComparison.OrdinalIgnoreCase));
				if (textSizeProfile != null)
				{
					profile = textSizeProfile;
				}
			}
			GetTextComponents();
		}

		private void GetTextComponents()
		{
			if (!text && !textMeshPro && !TryGetComponent<TMP_Text>(out textMeshPro) && !TryGetComponent<Text>(out text))
			{
				Debug.LogError("<color=red>Wrong game object for text size modifier " + base.gameObject.name + "</color>", base.gameObject);
			}
		}

		private void UpdateDebugString()
		{
		}
	}
}
