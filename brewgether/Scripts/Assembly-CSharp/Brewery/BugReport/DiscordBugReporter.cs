using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UIElements;

namespace Brewery.BugReport
{
	public class DiscordBugReporter : MonoBehaviour
	{
		[CompilerGenerated]
		private sealed class _003CSendToDiscord_003Ed__24 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public DiscordBugReporter _003C_003E4__this;

			public string description;

			private byte[] _003ClogBytes_003E5__2;

			private UnityWebRequest _003Crequest_003E5__3;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			public _003CSendToDiscord_003Ed__24(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			private void _003C_003Em__Finally1()
			{
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}
		}

		private const string DiscordInviteUrl = "https://discord.gg/qXk2TXsEvV";

		[Header("Discord Webhook")]
		[Tooltip("Your Discord channel webhook URL. Get it from Discord: Server Settings > Integrations > Webhooks")]
		[SerializeField]
		private string webhookUrl;

		[Header("Settings")]
		[Tooltip("Name shown as the webhook author in Discord")]
		[SerializeField]
		private string botName;

		[Tooltip("Cooldown between reports to prevent spam (seconds)")]
		[SerializeField]
		private float reportCooldown;

		[Header("Log Attachment")]
		[Tooltip("Attach the tail of Player.log to the report (helps debug crashes/disconnects)")]
		[SerializeField]
		private bool attachPlayerLog;

		[Tooltip("How many lines from the END of Player.log to attach. Reads backward from end-of-file, so cost scales with this value, not log size.")]
		[SerializeField]
		private int maxLogLines;

		[Tooltip("Hard byte ceiling — protects against pathological huge single lines. Discord webhook limit is 25MB.")]
		[SerializeField]
		private int maxLogBytes;

		[Header("Debug")]
		[SerializeField]
		private bool showDebugLogs;

		private float _lastReportTime;

		private VisualElement _modal;

		private VisualElement _box;

		private TextField _descriptionField;

		private Label _statusLabel;

		private UIDocument _uiDocument;

		public static DiscordBugReporter Instance { get; private set; }

		private void Awake()
		{
		}

		private void OnDestroy()
		{
		}

		public void ShowReportUI(UIDocument hostDocument)
		{
		}

		public void CloseReportUI()
		{
		}

		private void SetGameplayInput(bool enabled)
		{
		}

		private void SubmitReport()
		{
		}

		[IteratorStateMachine(typeof(_003CSendToDiscord_003Ed__24))]
		private IEnumerator SendToDiscord(string description)
		{
			return null;
		}

		private string BuildContextBlock()
		{
			return null;
		}

		private byte[] TryReadPlayerLogTail(int maxLines, int maxBytes)
		{
			return null;
		}

		private byte[] BuildMultipartBody(string payloadJson, byte[] fileBytes, string fileName, out string contentType)
		{
			contentType = null;
			return null;
		}

		private void ShowSuccessAndDiscordCTA()
		{
		}

		private void ShowStatus(string text, Color color)
		{
		}
	}
}
