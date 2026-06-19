using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using Cysharp.Threading.Tasks;
using JSAM;
using Loxodon.Framework.Interactivity;
using Loxodon.Framework.Observables;
using Loxodon.Framework.ViewModels;

namespace UI.HUD.Assistant
{
	public class AssistantPopupViewModel : ViewModelBase
	{
		private InteractionRequest<Notification> _startSpeech;

		private InteractionRequest<Notification> _skipToEndSpeech;

		private ObservableProperty<bool> _folded = new ObservableProperty<bool>(value: true);

		private ObservableProperty<bool> _hidden = new ObservableProperty<bool>(value: false);

		private ObservableProperty<bool> _closed = new ObservableProperty<bool>();

		private ObservableProperty<bool> _bubbleVisible = new ObservableProperty<bool>();

		private ObservableList<AssistantMissionViewModel> _missions = new ObservableList<AssistantMissionViewModel>();

		private string _speechBubbleText;

		private bool _textAnimatorEnabled;

		private bool _textAnimatorPlaying;

		private readonly List<string> _speechLines = new List<string>();

		private int _currentLineIndex = -1;

		public IInteractionRequest StartSpeech => _startSpeech;

		public IInteractionRequest SkipToEndSpeech => _skipToEndSpeech;

		public ObservableProperty<bool> Folded => _folded;

		public ObservableProperty<bool> Hidden => _hidden;

		public ObservableProperty<bool> Closed => _closed;

		public ObservableProperty<bool> BubbleVisible => _bubbleVisible;

		public ObservableList<AssistantMissionViewModel> Missions => _missions;

		public string SpeechBubbleText
		{
			get
			{
				return _speechBubbleText;
			}
			set
			{
				Set(ref _speechBubbleText, value, "SpeechBubbleText");
			}
		}

		public bool IsTextAnimatorEnabled
		{
			get
			{
				return _textAnimatorEnabled;
			}
			set
			{
				Set(ref _textAnimatorEnabled, value, "IsTextAnimatorEnabled");
			}
		}

		public bool IsTextAnimatorPlaying
		{
			get
			{
				return _textAnimatorPlaying;
			}
			set
			{
				Set(ref _textAnimatorPlaying, value, "IsTextAnimatorPlaying");
			}
		}

		public AssistantPopupViewModel()
		{
			_startSpeech = new InteractionRequest<Notification>(this);
			_skipToEndSpeech = new InteractionRequest<Notification>(this);
			Missions.CollectionChanged += MissionsCollectionChanged;
		}

		public void SetBubbleTextNoAnim(string text)
		{
			SpeechBubbleText = text;
		}

		public void CloseSpeechBubble()
		{
			BubbleVisible.Value = false;
			_speechLines.Clear();
			_currentLineIndex = -1;
		}

		public void HideCommand()
		{
			Hidden.Value = !Hidden.Value;
		}

		public void FoldCommand()
		{
			Folded.Value = !Folded.Value;
		}

		public void CloseCommand()
		{
			AudioManager.PlaySound(UILibrarySounds.UIMascotDisappear);
			Closed.Value = true;
			SetSpeechBubbleVisible(value: false);
			_speechLines.Clear();
			_currentLineIndex = -1;
		}

		public void SetSpeechBubbleText(string text)
		{
			_speechLines.Clear();
			_speechLines.Add(text);
			_currentLineIndex = 0;
			SetTextAndPlay(text).Forget();
		}

		public void SetSpeechLines(IEnumerable<string> lines)
		{
			_speechLines.Clear();
			_speechLines.AddRange(lines);
			_currentLineIndex = -1;
			if (_speechLines.Count > 0)
			{
				ShowLineAt(0);
			}
		}

		public void AppendSpeechLines(IEnumerable<string> lines)
		{
			bool num = _speechLines.Count == 0;
			_speechLines.AddRange(lines);
			if (num && _speechLines.Count > 0)
			{
				ShowLineAt(0);
			}
		}

		public void AdvanceSpeechCommand()
		{
			if (IsTextAnimatorPlaying)
			{
				_skipToEndSpeech.Raise(new Notification("skip"));
				return;
			}
			int num = _currentLineIndex + 1;
			if (num < _speechLines.Count)
			{
				ShowLineAt(num);
			}
			else
			{
				CloseSpeechBubble();
			}
		}

		private void ShowLineAt(int index)
		{
			_currentLineIndex = index;
			SetTextAndPlay(_speechLines[index]).Forget();
		}

		private async UniTaskVoid SetTextAndPlay(string text)
		{
			SetSpeechBubbleVisible(value: true);
			IsTextAnimatorPlaying = true;
			_bubbleVisible.Value = true;
			SpeechBubbleText = text;
			await UniTask.Yield();
			PlayBubbleText();
		}

		public void Appear()
		{
			AudioManager.PlaySound(UILibrarySounds.UIMascotAppear);
			Closed.Value = false;
			Hidden.Value = false;
		}

		public void SetSpeechBubbleVisible(bool value)
		{
			BubbleVisible.Value = value;
		}

		public void Disappear()
		{
			Closed.Value = true;
			Hidden.Value = true;
		}

		public void PlayBubbleText()
		{
			_startSpeech.Raise(new Notification("raised"));
		}

		public void AddMission(AssistantMissionViewModel missionVM)
		{
			Missions.Add(missionVM);
		}

		internal void RemoveMission(string missionId)
		{
			AssistantMissionViewModel assistantMissionViewModel = Missions.ToList().FirstOrDefault((AssistantMissionViewModel x) => x.Id == missionId);
			if (assistantMissionViewModel != null)
			{
				assistantMissionViewModel.Completed = true;
			}
		}

		private void MissionsCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
		{
			if (Missions.Count > 2)
			{
				RemoveOverflowMissionsAsync().Forget();
			}
		}

		private async UniTaskVoid RemoveOverflowMissionsAsync()
		{
			await UniTask.Yield();
			while (Missions.Count > 2)
			{
				Missions.RemoveAt(0);
			}
		}
	}
}
