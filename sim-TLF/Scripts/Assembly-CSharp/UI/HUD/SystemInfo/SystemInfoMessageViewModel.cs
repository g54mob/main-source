using Cysharp.Threading.Tasks;
using Loxodon.Framework.Interactivity;
using Loxodon.Framework.Observables;
using Loxodon.Framework.ViewModels;
using UnityEngine;

namespace UI.HUD.SystemInfo
{
	public class SystemInfoMessageViewModel : ViewModelBase
	{
		public ObservableProperty<float> Progress = new ObservableProperty<float>();

		private InteractionRequest _onTimeUp;

		private string _messageText;

		private Sprite _iconSprite;

		private float _timeVisible;

		private float _currentTime;

		public IInteractionRequest OnTimeUp => _onTimeUp;

		public string MessageText
		{
			get
			{
				return _messageText;
			}
			set
			{
				Set(ref _messageText, value, "MessageText");
			}
		}

		public Sprite IconSprite
		{
			get
			{
				return _iconSprite;
			}
			set
			{
				Set(ref _iconSprite, value, "IconSprite");
			}
		}

		public SystemInfoMessageViewModel(string messageText, Sprite icon, float time = 2f)
		{
			_onTimeUp = new InteractionRequest(this);
			_messageText = messageText;
			_iconSprite = icon;
			_timeVisible = time;
			Progress.Value = 1f;
		}

		public void StartTimer()
		{
			CountProgress().Forget();
		}

		private async UniTaskVoid CountProgress()
		{
			while (_currentTime < _timeVisible)
			{
				Progress.Value = 1f - _currentTime / _timeVisible;
				_currentTime += Time.deltaTime;
				await UniTask.WaitForEndOfFrame();
			}
			_onTimeUp?.Raise();
		}
	}
}
