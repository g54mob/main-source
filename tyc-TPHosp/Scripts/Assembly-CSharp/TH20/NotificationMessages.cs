#define LOG_LEVEL_VERBOSE
using System;
using System.Collections.Generic;
using FullInspector;
using I2.Loc;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Video;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class NotificationMessages
	{
		[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
		public class Definition
		{
			private enum genderTermCheckType
			{
				Female = 0,
				Male = 1,
				Default = 2,
				NumChecks = 3
			}

			public bool _showImmediately;

			[FullInspector.InspectorName("[DEPRECATED] Title")]
			[SerializeField]
			private string _title;

			[FullInspector.InspectorName("[DEPRECATED] Text")]
			[SerializeField]
			private string _text;

			public LocalisedString LocalisedTitle;

			public LocalisedString LocalisedText;

			public Sprite _icon;

			[FullInspector.InspectorName("[DEPRECATED] Choices")]
			[SerializeField]
			private string[] _choices;

			public LocalisedString[] Choices;

			public LocalisedString[] ChoicesAlt;

			public int DefaultChoice;

			public int TimeoutInSeconds;

			public bool UseScaledTime;

			public bool CanBeDismissed = true;

			public bool CanBeIgnored = true;

			public bool CanArchiveDefinition;

			public GameObject DialogPrefab;

			public VideoClip VideoToPlayAfterMessage;

			public string AudioToPlayAfterMessage;

			public bool NotificationAudioExclusiveMode;

			private static string[] genderTermSuffixStrs = new string[3] { "_F", "_M", "" };

			public string Title
			{
				set
				{
					_title = value;
				}
			}

			public string Text
			{
				set
				{
					_text = value;
				}
			}

			public virtual string GetTitleString()
			{
				if (!string.IsNullOrEmpty(LocalisedTitle.Term))
				{
					return LocalisedTitle.Translation;
				}
				if (string.IsNullOrEmpty(LocalisedTitle.Term) && !string.IsNullOrEmpty(_title) && _title.EndsWith("Star Hospital"))
				{
					string text = string.Empty;
					if (_title.StartsWith("1"))
					{
						text = "Challenges/Objective_HospitalStarRating1_Name";
					}
					else if (_title.StartsWith("2"))
					{
						text = "Challenges/Objective_HospitalStarRating2_Name";
					}
					else if (_title.StartsWith("3"))
					{
						text = "Challenges/Objective_HospitalStarRating3_Name";
					}
					if (!string.IsNullOrEmpty(text))
					{
						return LocalizationManager.GetTranslation(text);
					}
				}
				Logging.Warning(LogChannels.Unity, "Missing localised title in NotificationMessages");
				return _title;
			}

			public virtual string GetTextString()
			{
				if (!string.IsNullOrEmpty(LocalisedText.Term))
				{
					return LocalisedText.Translation;
				}
				Logging.Warning(LogChannels.Unity, "Missing localised text in NotificationMessages");
				return _text;
			}

			public virtual string GetTextStringForGender(Character.Sex gender)
			{
				string result = _text;
				if (!string.IsNullOrEmpty(LocalisedText.Term))
				{
					int num = 2;
					switch (gender)
					{
					case Character.Sex.Female:
						num = 0;
						break;
					case Character.Sex.Male:
						num = 1;
						break;
					}
					string term = LocalisedText.Term;
					int i = num;
					for (int num2 = 3; i < num2; i++)
					{
						string term2 = term + genderTermSuffixStrs[i];
						if (LocalisedString.DoesTermExist(term2))
						{
							result = LocalizationManager.GetTranslation(term2, FixForRTL: true, 0, ignoreRTLnumbers: true, applyParameters: true);
							break;
						}
					}
				}
				return result;
			}

			public bool GetUnlocalisedChoices(out List<string> retStrings)
			{
				retStrings = null;
				return false;
			}

			public bool ConvertAllUnlocalisedChoices(bool bDoPerformConversion = true)
			{
				return false;
			}

			public string[] GetChoices()
			{
				if (Choices != null && Choices.Length != 0)
				{
					string[] array = new string[Choices.Length];
					for (int i = 0; i < Choices.Length; i++)
					{
						LocalisedString localisedString = Choices[i];
						array[i] = localisedString.Translation;
					}
					return array;
				}
				if (ChoicesAlt != null && ChoicesAlt.Length != 0)
				{
					string[] array2 = new string[ChoicesAlt.Length];
					for (int j = 0; j < ChoicesAlt.Length; j++)
					{
						LocalisedString localisedString2 = ChoicesAlt[j];
						array2[j] = localisedString2.Translation;
					}
					return array2;
				}
				if (_choices.Length == 1 && _choices[0] == "OK!")
				{
					return new string[1] { ScriptLocalization.Menu_Messages.OK_Button_CS };
				}
				return _choices;
			}
		}

		public class DefinitionDynamic : Definition
		{
			private readonly Func<string> _funcGetTitle;

			private readonly Func<string> _funcGetText;

			public DefinitionDynamic(Func<string> funcGetTitle, Func<string> funcGetText)
			{
				_funcGetTitle = funcGetTitle;
				_funcGetText = funcGetText;
			}

			public override string GetTitleString()
			{
				if (_funcGetTitle == null)
				{
					return base.GetTitleString();
				}
				return _funcGetTitle();
			}

			public override string GetTextString()
			{
				if (_funcGetText == null)
				{
					return base.GetTextString();
				}
				return _funcGetText();
			}
		}

		public readonly Definition _newIllnessMessage;

		public readonly Definition _newIllnessRoomBuiltMessage;

		public readonly Definition _diagnosisMessage;

		public readonly Definition _treatmentMessage;

		public readonly Definition _treatmentNewIllnessMessage;

		public readonly Definition _objectiveCompleteMessage;

		public readonly Definition _staffPromotionMessage;

		public readonly Definition _staffTrainingRequiredMessage;

		public readonly Definition _researchCompleteMessage;

		public readonly Definition _cancelRoomMessage;

		public readonly Definition _restartLevelMessage;

		public readonly SharedInstance<Definition> _unlockSilverMessage;

		public readonly SharedInstance<Definition> UnlockStaffCustomisationSilverMessage;

		public readonly SharedInstance<Definition> UnlockRoomCustomisationSilverMessage;

		public readonly SharedInstance<Definition> _completedDemoMessage;

		public readonly SharedInstance<Definition> _sellInvalidItemsMessage;

		public readonly SharedInstance<Definition> FailStateWarning;

		public readonly SharedInstance<Definition> FailStateGameOver;
	}
}
