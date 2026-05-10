using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;

namespace CTS
{
	public class ContextualActionDisplayNames : MonoBehaviour
	{
		private static readonly Dictionary<EActionName, string> _actions = new Dictionary<EActionName, string>();

		[SerializeField]
		private List<StructContextualsActions> _inspectorActions = new List<StructContextualsActions>();

		private void Awake()
		{
			foreach (StructContextualsActions inspectorAction in _inspectorActions)
			{
				if (!_actions.ContainsKey(inspectorAction.NameOfTheAction))
				{
					_actions.Add(inspectorAction.NameOfTheAction, inspectorAction.TextTransletedOfTheAction.GetLocalizedString());
				}
			}
		}

		private void OnEnable()
		{
			LocalizationSettings.SelectedLocaleChanged += LanguageChanged;
		}

		private void LanguageChanged(Locale obj)
		{
			foreach (StructContextualsActions inspectorAction in _inspectorActions)
			{
				if (_actions.ContainsKey(inspectorAction.NameOfTheAction))
				{
					_actions[inspectorAction.NameOfTheAction] = inspectorAction.TextTransletedOfTheAction.GetLocalizedString();
				}
			}
		}

		private void OnDisable()
		{
			LocalizationSettings.SelectedLocaleChanged -= LanguageChanged;
		}

		public static string GetAction(EActionName name)
		{
			if (_actions.TryGetValue(name, out var value))
			{
				return value;
			}
			Debug.LogWarning($"Action '{name}' not found.");
			return null;
		}
	}
}
