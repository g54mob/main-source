using System;
using System.Collections.Concurrent;
using System.Text;
using System.Threading.Tasks;
using Controllers;
using Kitchen.Modules;
using Platforms;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Kitchen
{
	public class TextInputView : MonoBehaviour, IInputConsumer
	{
		public enum TextInputState
		{
			Waiting = 0,
			EnteringText = 1,
			TextEntryComplete = 2,
			TextEntryCancelled = 3
		}

		private readonly object valueLock = new object();

		private readonly object stateLock = new object();

		public static TextInputView Main;

		public static Action<TextInputState, string> CurrentCallback;

		private bool ListenerSet;

		public int MaxLength = 20;

		private InputLock.Lock Lock;

		private string _Value = "";

		private TextInputState _State;

		[SerializeField]
		private TextMeshPro ValueBox;

		[SerializeField]
		private TextMeshPro Title;

		[SerializeField]
		private Transform Caret;

		[SerializeField]
		private GameObject Container;

		[SerializeField]
		private SeedInputElement SeedInput;

		[SerializeField]
		private GameObject NonSeedInput;

		[SerializeField]
		private bool IsUsingSeedInputElement;

		private bool IsSeedMode;

		private readonly ConcurrentQueue<bool> SteamGamepadTextInputSubmitted = new ConcurrentQueue<bool>();

		private const char Escape = '\u001b';

		private const char NewLine = '\n';

		private const char CarriageReturn = '\r';

		private const char BackSpace = '\b';

		public string Value
		{
			get
			{
				lock (valueLock)
				{
					return _Value;
				}
			}
			private set
			{
				lock (valueLock)
				{
					_Value = (IsSeedMode ? value.ToLower() : value);
					string text = (IsSeedMode ? "<sprite name=\"seed\">" : "");
					ValueBox.text = text + _Value.Replace(" ", "<style=space>_</style>");
				}
			}
		}

		public TextInputState State
		{
			get
			{
				lock (stateLock)
				{
					return _State;
				}
			}
			private set
			{
				lock (stateLock)
				{
					_State = value;
					InputSource inputSource = InputSourceIdentifier.Default;
					if (_State == TextInputState.EnteringText)
					{
						LocalInputSourceConsumers.Register(this);
						if (!inputSource.IsValidLock(Lock))
						{
							Lock = inputSource.SetLock(PlayerLockState.NonPause);
						}
					}
					else
					{
						LocalInputSourceConsumers.Remove(this);
						inputSource.ConsumeAllInputs();
						inputSource.ReleaseLock(Lock);
					}
					if (_State == TextInputState.TextEntryCancelled || _State == TextInputState.TextEntryComplete)
					{
						Complete();
					}
				}
			}
		}

		public static void RequestTextInput(string title, string text, int max_len, Action<TextInputState, string> callback)
		{
			CurrentCallback = callback;
			Main.Setup(title, text, max_len);
		}

		public static void RequestSeedInput(string title, string text, Action<TextInputState, string> callback)
		{
			CurrentCallback = callback;
			Main.SetupSeed(title, text);
		}

		public static void ReportComplete(TextInputView view)
		{
			Action<TextInputState, string> currentCallback = CurrentCallback;
			CurrentCallback = null;
			currentCallback?.Invoke(view.State, view.Value);
		}

		public void SetTitle(string title)
		{
			Title.text = title;
		}

		public void Setup(string title, string value, int max_len = 20, bool allow_blocking = true)
		{
			SetTitle(title);
			MaxLength = max_len;
			Container.SetActive(!PlatformSettings.UseSoftwareKeyboard);
			State = TextInputState.EnteringText;
			IsSeedMode = false;
			Value = value;
			if (PlatformSettings.UseSoftwareKeyboard)
			{
				OpenSoftwareKeyboard(title, value, max_len, allow_blocking);
			}
		}

		public void SetupSeed(string title, string value, bool allow_blocking = false)
		{
			SetTitle(title);
			MaxLength = 8;
			Container.SetActive(value: true);
			State = TextInputState.EnteringText;
			IsSeedMode = true;
			Value = value;
			if (PlatformSettings.UseSoftwareKeyboard)
			{
				OpenSoftwareKeyboard(title, value, 8, allow_blocking);
			}
		}

		private async void OpenSoftwareKeyboard(string title, string value, int max_len, bool allow_blocking = false)
		{
			if (PlatformSettings.AllowsAsyncKeyboard || allow_blocking)
			{
				(bool, string) tuple = await Platform.Current.OpenSoftwareKeyboard(title, max_len, value);
				Value = SanitizeInput(tuple.Item2);
				State = (tuple.Item1 ? TextInputState.TextEntryComplete : TextInputState.TextEntryCancelled);
			}
			else
			{
				await UseUIKeyboard();
			}
		}

		private async Task UseUIKeyboard()
		{
			SeedInput.gameObject.SetActive(value: true);
			NonSeedInput.SetActive(value: false);
			IsUsingSeedInputElement = true;
			SeedInput.StartUsage(wipe_value: true);
			while (IsUsingSeedInputElement)
			{
				await Task.Delay(50);
			}
			State = TextInputState.TextEntryComplete;
			SeedInput.gameObject.SetActive(value: false);
			NonSeedInput.SetActive(value: true);
		}

		public InputConsumerState TakeInput(int player_id, InputState state)
		{
			if (IsUsingSeedInputElement)
			{
				if (SeedInput.HandleInteraction(state))
				{
					return InputConsumerState.Consumed;
				}
				if (state.IsAdvancingMenu || state.IsCancellingMenu)
				{
					Value = SeedInput.GetResult();
					IsUsingSeedInputElement = false;
					return InputConsumerState.Consumed;
				}
				return InputConsumerState.NotConsumed;
			}
			if (state.IsCancellingMenu && InputSourceIdentifier.DefaultInputSource.GetCurrentController(player_id) != ControllerType.Keyboard)
			{
				State = TextInputState.TextEntryCancelled;
				return InputConsumerState.Consumed;
			}
			if (State == TextInputState.EnteringText)
			{
				return InputConsumerState.Consumed;
			}
			return InputConsumerState.NotConsumed;
		}

		private void Start()
		{
			Main = this;
			if (Keyboard.current == null)
			{
				Debug.LogWarning("There is no current keyboard - no listener will be added to onTextInput!");
			}
			else
			{
				Keyboard.current.onTextInput += OnTextInput;
			}
		}

		private void Update()
		{
			if (State == TextInputState.EnteringText)
			{
				UpdateCaret();
			}
		}

		private void OnDestroy()
		{
			Keyboard.current.onTextInput -= OnTextInput;
		}

		private bool IsValidCharacter(ref char c)
		{
			if (!IsPrintable(c) || Value.Length >= MaxLength)
			{
				return false;
			}
			if (IsSeedMode)
			{
				c = char.ToLower(c);
			}
			if (IsSeedMode)
			{
				return "abcdefghijklmnopqrstuvwxyz123456789".Contains(c.ToString());
			}
			return true;
		}

		private void HandleNewCharacter(char c)
		{
			if (!IsUsingSeedInputElement && IsValidCharacter(ref c))
			{
				Value += c;
			}
		}

		private string SanitizeInput(string s)
		{
			if (s == null)
			{
				return "";
			}
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 0; i < s.Length; i++)
			{
				char c = s[i];
				if (IsValidCharacter(ref c))
				{
					stringBuilder.Append(c);
				}
			}
			return stringBuilder.ToString();
		}

		private void OnTextInput(char c)
		{
			if (IsUsingSeedInputElement || State != TextInputState.EnteringText)
			{
				return;
			}
			if (Keyboard.current.vKey.isPressed && Keyboard.current.ctrlKey.isPressed)
			{
				string systemCopyBuffer = GUIUtility.systemCopyBuffer;
				foreach (char c2 in systemCopyBuffer)
				{
					HandleNewCharacter(c2);
				}
			}
			else
			{
				HandleNewCharacter(c);
			}
			if (c == '\b' && Value.Length > 0)
			{
				Value = Value.Substring(0, Value.Length - 1);
			}
			if (c == '\n' || c == '\r')
			{
				State = TextInputState.TextEntryComplete;
			}
			if (c == '\u001b')
			{
				State = TextInputState.TextEntryCancelled;
			}
		}

		private void Complete()
		{
			Container.SetActive(value: false);
			ReportComplete(this);
		}

		private bool IsPrintable(char c)
		{
			if (c != '\n' && c != '\r')
			{
				if (!char.IsLetterOrDigit(c) && !char.IsWhiteSpace(c) && !char.IsPunctuation(c))
				{
					return char.IsSymbol(c);
				}
				return true;
			}
			return false;
		}

		private void UpdateCaret()
		{
			if (ValueBox.text.Length == 0)
			{
				Caret.localPosition = new Vector3(0f, 0f, 0f);
				return;
			}
			Vector3 localPosition = Caret.localPosition;
			localPosition.x = ValueBox.textBounds.max.x;
			Caret.localPosition = localPosition;
		}
	}
}
