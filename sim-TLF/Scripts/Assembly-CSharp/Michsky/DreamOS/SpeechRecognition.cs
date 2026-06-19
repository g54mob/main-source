using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Windows.Speech;

namespace Michsky.DreamOS
{
	public class SpeechRecognition : MonoBehaviour
	{
		[Serializable]
		public class CommandItem
		{
			[TextArea]
			public string command;

			public UnityEvent onCalled = new UnityEvent();
		}

		public string[] keywords = new string[1] { "Hey Cori" };

		public List<CommandItem> commands = new List<CommandItem>();

		private List<string> commandsHelper = new List<string>();

		public List<string> listeningMessages = new List<string>();

		public UnityEvent onKeywordCall;

		public UnityEvent onDismiss;

		[SerializeField]
		private PopupPanelManager coriPopup;

		[SerializeField]
		private TextMeshProUGUI listeningText;

		[SerializeField]
		private GameObject taskbarShortcut;

		public bool enableKeywords = true;

		[SerializeField]
		private bool enableLogs;

		[Range(1f, 30f)]
		public float dismissAfter = 4f;

		public AudioClip listeningEffect;

		public AudioClip dismissEffect;

		private DictationRecognizer dictationRecognizer;

		private KeywordRecognizer keywordRecognizer;

		private KeywordRecognizer commandRecognizer;

		[TextArea]
		public string hypotheses;

		[TextArea]
		public string recognitions;

		private bool stopSTT;

		private void Awake()
		{
			try
			{
				PhraseRecognitionSystem.OnStatusChanged += SpeechSystemStatusFn;
				InitializeKeywords();
			}
			catch
			{
				Debug.LogWarning("<b>[Speech Recognition]</b> Cannot initialize STT. Make sure that there is at least a single voice package installed on your Windows OS.");
				base.enabled = false;
				stopSTT = true;
			}
		}

		private void OnDestroy()
		{
			if (!stopSTT)
			{
				if (keywordRecognizer != null && keywordRecognizer.IsRunning)
				{
					StopKeywordRecognizer();
				}
				if (commandRecognizer != null && commandRecognizer.IsRunning)
				{
					StopCommandRecognizer();
				}
				if (PhraseRecognitionSystem.Status != SpeechSystemStatus.Stopped)
				{
					PhraseRecognitionSystem.Shutdown();
				}
			}
		}

		private void InitializeKeywords()
		{
			for (int i = 0; i < commands.Count; i++)
			{
				commandsHelper.Add(commands[i].command);
			}
			if (enableKeywords)
			{
				StartKeywordRecognizer();
			}
		}

		private void SpeechSystemStatusFn(SpeechSystemStatus status)
		{
			if (enableLogs)
			{
				Debug.Log("<b>[Speech Recognition]</b> Speech System Status: " + status);
			}
		}

		public void StartDictation()
		{
			if (PhraseRecognitionSystem.Status != SpeechSystemStatus.Stopped)
			{
				PhraseRecognitionSystem.Shutdown();
			}
			dictationRecognizer = new DictationRecognizer();
			dictationRecognizer.DictationResult += delegate(string text, ConfidenceLevel confidence)
			{
				recognitions = recognitions + text + "\n";
			};
			dictationRecognizer.DictationHypothesis += delegate(string text)
			{
				hypotheses = hypotheses + text + "\n";
			};
			dictationRecognizer.DictationComplete += delegate(DictationCompletionCause completionCause)
			{
				if (enableLogs && completionCause != DictationCompletionCause.Complete)
				{
					Debug.LogErrorFormat("<b>[Speech Recognition]</b> Dictation completed unsuccessfully: {0}.", completionCause);
				}
			};
			dictationRecognizer.DictationError += delegate(string error, int hresult)
			{
				if (enableLogs)
				{
					Debug.LogErrorFormat("<b>[Speech Recognition]</b> Dictation error: {0}; HResult = {1}.", error, hresult);
				}
			};
			dictationRecognizer.Start();
			recognitions = "";
			hypotheses = "";
		}

		public void StopDictation()
		{
			dictationRecognizer.Dispose();
			dictationRecognizer.Stop();
			dictationRecognizer = null;
			if (enableLogs)
			{
				Debug.Log("<b>[Speech Recognition]</b> Dictation stopped.");
			}
		}

		public void OpenCoriPopup()
		{
			coriPopup.OpenPanel();
			StopKeywordRecognizer();
			StartCommandRecognizer();
		}

		public void CloseCoriPopup()
		{
			coriPopup.ClosePanel();
			onDismiss.Invoke();
			StopCommandRecognizer();
			if (enableKeywords)
			{
				StartKeywordRecognizer();
			}
		}

		public void StartKeywordRecognizer()
		{
			keywordRecognizer = new KeywordRecognizer(keywords, ConfidenceLevel.Low);
			keywordRecognizer.OnPhraseRecognized += delegate(PhraseRecognizedEventArgs args)
			{
				StringBuilder stringBuilder = new StringBuilder();
				stringBuilder.AppendFormat("{0} ({1}){2}", args.text, args.confidence, Environment.NewLine);
				recognitions += stringBuilder.ToString();
				if (enableLogs)
				{
					Debug.Log("<b>[Speech Recognition]</b> Keyword recognized: <b>" + args.text + " (" + args.confidence.ToString() + ")</b>");
				}
				if (AudioManager.instance != null)
				{
					AudioManager.instance.audioSource.PlayOneShot(listeningEffect);
				}
				if (coriPopup != null)
				{
					coriPopup.OpenPanel();
				}
				onKeywordCall.Invoke();
				StopKeywordRecognizer();
				StartCommandRecognizer();
				StartCoroutine("WaitForCommand", dismissAfter);
			};
			recognitions = "";
			keywordRecognizer.Start();
			hypotheses = "Listening for: \n" + string.Join(", ", keywords);
		}

		public void StopKeywordRecognizer()
		{
			if (keywordRecognizer.IsRunning)
			{
				keywordRecognizer.Stop();
			}
			if (enableLogs)
			{
				Debug.Log("<b>[Speech Recognition]</b> Keyword recognizer stopped.");
			}
			keywordRecognizer.Dispose();
			keywordRecognizer = null;
		}

		public void StartCommandRecognizer()
		{
			if (AudioManager.instance != null)
			{
				AudioManager.instance.audioSource.PlayOneShot(listeningEffect);
			}
			if (listeningEffect != null)
			{
				listeningText.text = listeningMessages[UnityEngine.Random.Range(0, listeningMessages.Count)];
			}
			commandRecognizer = new KeywordRecognizer(commandsHelper.ToArray(), ConfidenceLevel.Low);
			commandRecognizer.OnPhraseRecognized += delegate(PhraseRecognizedEventArgs args)
			{
				StopCoroutine("WaitForCommand");
				StringBuilder stringBuilder = new StringBuilder();
				stringBuilder.AppendFormat("{0} ({1}){2}", args.text, args.confidence, Environment.NewLine);
				recognitions += stringBuilder.ToString();
				if (enableLogs)
				{
					Debug.Log("<b>[Speech Recognition]</b> Command recognized: <b>" + args.text + " (" + args.confidence.ToString() + ")</b>");
				}
				for (int i = 0; i < commands.Count; i++)
				{
					if (args.text == commands[i].command)
					{
						commands[i].onCalled.Invoke();
					}
				}
				StopCommandRecognizer();
				if (enableKeywords)
				{
					StartKeywordRecognizer();
				}
			};
			recognitions = "";
			commandRecognizer.Start();
			hypotheses = "Listening for: \n" + string.Join(", ", commandsHelper);
		}

		public void StopCommandRecognizer()
		{
			if (coriPopup != null)
			{
				coriPopup.ClosePanel();
			}
			if (AudioManager.instance != null)
			{
				AudioManager.instance.audioSource.PlayOneShot(dismissEffect);
			}
			if (commandRecognizer != null && commandRecognizer.IsRunning)
			{
				commandRecognizer.Stop();
			}
			if (enableLogs)
			{
				Debug.Log("<b>[Speech Recognition]</b> Command recognizer stopped.");
			}
			commandRecognizer.Dispose();
			commandRecognizer = null;
		}

		private IEnumerator WaitForCommand(float waitFor)
		{
			yield return new WaitForSeconds(waitFor);
			onDismiss.Invoke();
			if (commandRecognizer.IsRunning)
			{
				StopCommandRecognizer();
			}
			if (enableKeywords)
			{
				StartKeywordRecognizer();
			}
		}

		public void EnableSpeechRecognition(bool value)
		{
			base.gameObject.SetActive(value);
			if (coriPopup != null)
			{
				coriPopup.gameObject.SetActive(value);
			}
			if (taskbarShortcut != null)
			{
				taskbarShortcut.SetActive(value);
			}
		}
	}
}
