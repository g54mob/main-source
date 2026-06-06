using System;
using System.Collections.Generic;
using System.Diagnostics;
using Febucci.Parsing;
using Febucci.Parsing.Core;
using Febucci.Parsing.Regions;
using Febucci.TextAnimatorCore;
using Febucci.TextAnimatorCore.Data;
using Febucci.TextAnimatorCore.Settings;
using Febucci.TextAnimatorCore.Text;
using Febucci.TextAnimatorCore.Typing;
using Febucci.TextAnimatorForUnity.Actions;
using Febucci.TextAnimatorForUnity.Parsing;
using Febucci.TextAnimatorForUnity.Styles;
using UnityEngine;
using UnityEngine.UIElements;

namespace Febucci.TextAnimatorForUnity.UIToolkit
{
	[UxmlElement]
	public abstract class AnimatedLabelBase : Label, ITextGenerator, ISettingsProvider<TypewriterSettings>, ISettingsProvider<AnimatorSettings>, ITextAnimatorProvider
	{
		[Serializable]
		public new abstract class UxmlSerializedData : Label.UxmlSerializedData
		{
			[SerializeField]
			private AnimatorSettingsScriptable AnimationSettings;

			[SerializeField]
			private TypingsTimingsScriptableBase TimingSettings;

			[SerializeField]
			private TypewriterSettingsScriptable TypewriterSettings;

			[SerializeField]
			private AnimationsDatabase BehaviorsDatabase;

			[SerializeField]
			private StyleSheetScriptable StyleSheetDatabase;

			[SerializeField]
			private ActionDatabase ActionsDatabase;

			[TextArea]
			[SerializeField]
			private string Text;

			[SerializeField]
			[UxmlIgnore]
			[HideInInspector]
			private UxmlAttributeFlags AnimationSettings_UxmlAttributeFlags;

			[SerializeField]
			[UxmlIgnore]
			[HideInInspector]
			private UxmlAttributeFlags TimingSettings_UxmlAttributeFlags;

			[SerializeField]
			[UxmlIgnore]
			[HideInInspector]
			private UxmlAttributeFlags TypewriterSettings_UxmlAttributeFlags;

			[SerializeField]
			[UxmlIgnore]
			[HideInInspector]
			private UxmlAttributeFlags BehaviorsDatabase_UxmlAttributeFlags;

			[SerializeField]
			[UxmlIgnore]
			[HideInInspector]
			private UxmlAttributeFlags StyleSheetDatabase_UxmlAttributeFlags;

			[SerializeField]
			[UxmlIgnore]
			[HideInInspector]
			private UxmlAttributeFlags ActionsDatabase_UxmlAttributeFlags;

			[SerializeField]
			[UxmlIgnore]
			[HideInInspector]
			private UxmlAttributeFlags Text_UxmlAttributeFlags;

			[RegisterUxmlCache]
			[Conditional("UNITY_EDITOR")]
			public new static void Register()
			{
				UxmlDescriptionCache.RegisterType(typeof(UxmlSerializedData), new UxmlAttributeNames[7]
				{
					new UxmlAttributeNames("AnimationSettings", "animation-settings", null),
					new UxmlAttributeNames("TimingSettings", "timing-settings", null),
					new UxmlAttributeNames("TypewriterSettings", "typewriter-settings", null),
					new UxmlAttributeNames("Text", "text", null),
					new UxmlAttributeNames("BehaviorsDatabase", "behaviors-database", null),
					new UxmlAttributeNames("StyleSheetDatabase", "style-sheet-database", null),
					new UxmlAttributeNames("ActionsDatabase", "actions-database", null)
				});
			}

			public override void Deserialize(object obj)
			{
				base.Deserialize(obj);
				AnimatedLabelBase animatedLabelBase = (AnimatedLabelBase)obj;
				if (UnityEngine.UIElements.UxmlSerializedData.ShouldWriteAttributeValue(AnimationSettings_UxmlAttributeFlags))
				{
					animatedLabelBase.AnimationSettings = AnimationSettings;
				}
				if (UnityEngine.UIElements.UxmlSerializedData.ShouldWriteAttributeValue(TimingSettings_UxmlAttributeFlags))
				{
					animatedLabelBase.TimingSettings = TimingSettings;
				}
				if (UnityEngine.UIElements.UxmlSerializedData.ShouldWriteAttributeValue(TypewriterSettings_UxmlAttributeFlags))
				{
					animatedLabelBase.TypewriterSettings = TypewriterSettings;
				}
				if (UnityEngine.UIElements.UxmlSerializedData.ShouldWriteAttributeValue(Text_UxmlAttributeFlags))
				{
					animatedLabelBase.Text = Text;
				}
				if (UnityEngine.UIElements.UxmlSerializedData.ShouldWriteAttributeValue(BehaviorsDatabase_UxmlAttributeFlags))
				{
					animatedLabelBase.BehaviorsDatabase = BehaviorsDatabase;
				}
				if (UnityEngine.UIElements.UxmlSerializedData.ShouldWriteAttributeValue(StyleSheetDatabase_UxmlAttributeFlags))
				{
					animatedLabelBase.StyleSheetDatabase = StyleSheetDatabase;
				}
				if (UnityEngine.UIElements.UxmlSerializedData.ShouldWriteAttributeValue(ActionsDatabase_UxmlAttributeFlags))
				{
					animatedLabelBase.ActionsDatabase = ActionsDatabase;
				}
			}
		}

		private AnimatorSettingsScriptable animationSettings;

		private TypingsTimingsScriptableBase timingsSettings;

		private TypewriterSettingsScriptable typewriterSettings;

		private AnimationsDatabase _behaviorsDatabase;

		private StyleSheetScriptable _stylesDatabase;

		private ActionDatabase _actionsDatabase;

		private TextParser uitkParser;

		private UIToolkitLabelTagParser uiToolkitLabelTagParser;

		private float lastTime;

		private TypewriterSettings settings;

		protected bool isValid { get; private set; }

		protected TextAnimator animator { get; private set; }

		public TypewriterCore Typewriter { get; private set; }

		protected int CharactersCountWithoutTAnimTags { get; private set; }

		TextAnimator ITextAnimatorProvider.TextAnimator => animator;

		public int CharactersCount => animator.CharactersCount;

		public CharacterData[] Characters => animator.Characters;

		public int WordsCount => animator.WordsCount;

		public WordInfo[] Words => animator.Words;

		[UxmlAttribute]
		public AnimatorSettingsScriptable AnimationSettings
		{
			get
			{
				return animationSettings;
			}
			set
			{
				animationSettings = value;
				if (animator != null)
				{
					animator.LocalSettingsProvider = animationSettings;
					RefreshText();
				}
			}
		}

		AnimatorSettings ISettingsProvider<AnimatorSettings>.Settings
		{
			get
			{
				if (!(animationSettings != null))
				{
					return null;
				}
				return animationSettings.Settings;
			}
		}

		[UxmlAttribute]
		public TypingsTimingsScriptableBase TimingSettings
		{
			get
			{
				return timingsSettings;
			}
			set
			{
				timingsSettings = value;
				if (Typewriter != null)
				{
					Typewriter.timingsProvider = timingsSettings;
				}
			}
		}

		TypewriterSettings ISettingsProvider<TypewriterSettings>.Settings => settings;

		[UxmlAttribute]
		public TypewriterSettingsScriptable TypewriterSettings
		{
			get
			{
				return typewriterSettings;
			}
			set
			{
				typewriterSettings = value;
				_ = Typewriter;
			}
		}

		[UxmlAttribute]
		[TextArea]
		public string Text
		{
			get
			{
				return animator.TextFull;
			}
			set
			{
				string text = value;
				if (base.parseEscapeSequences)
				{
					text = text.Replace("\\n", "\n");
				}
				this.text = text;
				animator?.SetText(text);
			}
		}

		[UxmlAttribute]
		public AnimationsDatabase BehaviorsDatabase
		{
			get
			{
				return _behaviorsDatabase;
			}
			set
			{
				if (!(_behaviorsDatabase == value))
				{
					_behaviorsDatabase = value;
					if (animator != null)
					{
						animator.effectsDatabase = _behaviorsDatabase;
						RefreshText();
					}
				}
			}
		}

		[UxmlAttribute]
		public StyleSheetScriptable StyleSheetDatabase
		{
			get
			{
				return _stylesDatabase;
			}
			set
			{
				if (!(_stylesDatabase == value))
				{
					_stylesDatabase = value;
					if (animator != null)
					{
						animator.stylesDatabase = _stylesDatabase;
						RefreshText();
					}
				}
			}
		}

		[UxmlAttribute]
		public ActionDatabase ActionsDatabase
		{
			get
			{
				return _actionsDatabase;
			}
			set
			{
				if (_actionsDatabase == value)
				{
					return;
				}
				_actionsDatabase = value;
				if (Application.isPlaying)
				{
					if (Typewriter != null)
					{
						Typewriter.ActionProviders = GetActionProviders();
					}
					RefreshText();
				}
			}
		}

		public TextRegion<IEffectPlayer>[] Disappearances { get; }

		public int FirstVisibleCharacter
		{
			get
			{
				return animator.FirstVisibleCharacter;
			}
			set
			{
				animator.FirstVisibleCharacter = value;
			}
		}

		public int MaxVisibleCharacters
		{
			get
			{
				return animator.MaxVisibleCharacters;
			}
			set
			{
				animator.MaxVisibleCharacters = value;
			}
		}

		public TextRegion<IEffectPlayer>[] Behaviors { get; }

		public TextRegion<IEffectPlayer>[] Appearances { get; }

		private IDatabaseProvider<ITypewriterAction>[] GetActionProviders()
		{
			List<IDatabaseProvider<ITypewriterAction>> list = new List<IDatabaseProvider<ITypewriterAction>>();
			bool num = base.panel != null && Application.isPlaying;
			if (_actionsDatabase != null)
			{
				list.Add(_actionsDatabase);
			}
			if (num && GlobalActionComponentsDatabase.Instance != null)
			{
				list.Add(GlobalActionComponentsDatabase.Instance);
			}
			return list.ToArray();
		}

		public AnimatedLabelBase()
		{
			try
			{
				uiToolkitLabelTagParser = new UIToolkitLabelTagParser(this, '<', '/', '>');
			}
			catch (Exception arg)
			{
				UnityEngine.Debug.LogError($"Something went wrong initializing the UI Toolkit tag parser. Please make sure the setup is correct, or contact support with the stack trace and we'll fix it as soon as possible. Error: {arg}");
				return;
			}
			uitkParser = new TextParser(pasteNoParseTag: false, '<', '>');
			try
			{
				UnityEngineProvider instance = UnityEngineProvider.Instance;
				ISettingsProvider<GlobalSettingsBase> instance2 = TextAnimatorSettings.Instance;
				animator = new TextAnimator(textGenerator: this, animatorSettingsProvider: this, globalSettingsProvider: instance2, isUpPositive: false, caller: this, pasteNoParseTag: false, openingBracket: '<', closingTagSymbol: '/', closingBracket: '>', engineProvider: instance, extraParsers: new TagParserBase[1] { uiToolkitLabelTagParser });
				animator.OnStartedParsing += delegate(string textFull)
				{
					text = textFull;
				};
				isValid = true;
			}
			catch (Exception arg2)
			{
				UnityEngine.Debug.LogError($"Something went wrong initializing TextAnimator for UI Toolkit. Please make sure the setup is correct, or contact support with the stack trace and we'll fix it as soon as possible. Error: {arg2}");
				return;
			}
			try
			{
				Typewriter = new TypewriterCore(animator, this, timingsSettings, TextAnimatorSettings.Instance, this, GetActionProviders());
			}
			catch (Exception arg3)
			{
				UnityEngine.Debug.LogError($"Unable to create typewriter on {this}. Skipping. - {arg3}");
				return;
			}
			animator.OnTextParsed += OnTextParsed;
			animator.effectsDatabase = BehaviorsDatabase;
			animator.stylesDatabase = StyleSheetDatabase;
			RegisterCallback<AttachToPanelEvent>(OnAttachedToPanel);
		}

		private void OnAttachedToPanel(AttachToPanelEvent evt)
		{
			if (Application.isPlaying && Typewriter != null)
			{
				Typewriter.ActionProviders = GetActionProviders();
			}
		}

		public void TryInitializingOnce()
		{
		}

		public void SetText(string text, bool hideText = false)
		{
			animator.SetText(text, (!hideText) ? ShowTextMode.Shown : ShowTextMode.Hidden);
		}

		public void SwapText(string text)
		{
			animator.SwapText(text);
		}

		public void AppendText(string appendedText, bool hideText = false)
		{
			animator.AppendText(appendedText, hideText);
		}

		public void SetVisibilityChar(int index, bool isVisible, bool canPlayEffects)
		{
			animator.SetVisibilityChar(index, isVisible, canPlayEffects);
		}

		public void SetVisibilityWord(int index, bool isVisible, bool canPlayEffects)
		{
			animator.SetVisibilityWord(index, isVisible, canPlayEffects);
		}

		public void SetVisibilityEntireText(bool isVisible, bool canPlayEffects = true)
		{
			animator.SetVisibilityEntireText(isVisible, canPlayEffects);
		}

		protected virtual void OnTextParsed()
		{
			text = animator.TextWithoutTextAnimatorTags;
			CharactersCountWithoutTAnimTags = text.Length;
			base.schedule.Execute(base.MarkDirtyRepaint);
			base.schedule.Execute(base.MarkDirtyText);
		}

		private float GetCurrentTime()
		{
			return Time.time;
		}

		private void RefreshText()
		{
			if (Application.isPlaying)
			{
				animator.SetText(animator.TextFull);
			}
		}

		protected void Animate()
		{
			float currentTime = GetCurrentTime();
			float deltaTime = currentTime - lastTime;
			lastTime = currentTime;
			animator.Animate(deltaTime);
		}

		public void SetTextToSource(string text)
		{
		}

		public abstract void CopyMeshFromSource(ref CharacterData[] characters, int charactersCount);

		public abstract void PasteMeshToSource(CharacterData[] characters, int charactersCount);

		public virtual void ForceMeshUpdate()
		{
			base.schedule.Execute(base.MarkDirtyRepaint);
		}

		public string GetStrippedTextWithoutAnyTags(string textWithoutTAnimTags)
		{
			return uitkParser.ParseText(textWithoutTAnimTags, uiToolkitLabelTagParser);
		}

		public abstract string GetFullText();

		public abstract int GetCharactersCount();

		public abstract bool HasChangedMeshRenderingSettings();

		public int GetFirstCharacterIndexInsidePage()
		{
			return 0;
		}

		public int GetRenderedCharactersCountInsidePage(int charactersCount)
		{
			return int.MaxValue;
		}
	}
}
