using System;

namespace TH20
{
	public class TutorialManager : MustCallDestroy
	{
		private TutorialMode _currentMode;

		private readonly Level _level;

		public PingManagerProxy PingManagerProxy { get; private set; }

		public TutorialManager(Level level)
		{
			_level = level;
			PingManagerProxy = new PingManagerProxy();
			TutorialButtonClickedMessage.OnButtonCreated = (Action<TutorialButtonClickedMessage>)Delegate.Combine(TutorialButtonClickedMessage.OnButtonCreated, new Action<TutorialButtonClickedMessage>(OnTutorialButtonCreated));
		}

		public override void Destroy()
		{
			if (_currentMode != null)
			{
				_currentMode.Destroy();
			}
			TutorialButtonClickedMessage.OnButtonCreated = (Action<TutorialButtonClickedMessage>)Delegate.Remove(TutorialButtonClickedMessage.OnButtonCreated, new Action<TutorialButtonClickedMessage>(OnTutorialButtonCreated));
			PingManagerProxy.Destroy();
			base.Destroy();
		}

		public void SetTutorialMode(TutorialModeDefinition definition)
		{
			if (_currentMode != null)
			{
				_currentMode.Destroy();
				_currentMode = null;
			}
			if (definition != null)
			{
				_currentMode = definition.Create();
			}
			if (_currentMode != null)
			{
				_currentMode.SetLevel(_level);
				_currentMode.Enter();
			}
		}

		public void Update()
		{
			if (_currentMode != null)
			{
				_currentMode.Update();
			}
		}

		private void OnTutorialButtonCreated(TutorialButtonClickedMessage button)
		{
			button.Setup(_level);
		}
	}
}
