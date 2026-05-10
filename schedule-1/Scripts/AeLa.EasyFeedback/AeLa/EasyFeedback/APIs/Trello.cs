using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine.Networking;

namespace AeLa.EasyFeedback.APIs
{
	public class Trello
	{
		[CompilerGenerated]
		private sealed class _003CAddAttachmentAsync_003Ed__18 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public Trello _003C_003E4__this;

			public byte[] file;

			public string name;

			public string url;

			public string mimeType;

			public string cardID;

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
			public _003CAddAttachmentAsync_003Ed__18(int _003C_003E1__state)
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

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}
		}

		[CompilerGenerated]
		private sealed class _003CAddCard_003Ed__17 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public Trello _003C_003E4__this;

			public string name;

			public string description;

			public IEnumerable<Label> labels;

			public string list;

			public byte[] fileSource;

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
			public _003CAddCard_003Ed__17(int _003C_003E1__state)
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

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}
		}

		[CompilerGenerated]
		private sealed class _003CGetBoardsAsync_003Ed__23 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public Action<Board[]> onFinished;

			public Trello _003C_003E4__this;

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
			public _003CGetBoardsAsync_003Ed__23(int _003C_003E1__state)
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

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}
		}

		[CompilerGenerated]
		private sealed class _003CGetLabelsAsync_003Ed__19 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public Action<Label[]> onFinished;

			public Trello _003C_003E4__this;

			public string boardID;

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
			public _003CGetLabelsAsync_003Ed__19(int _003C_003E1__state)
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

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}
		}

		[CompilerGenerated]
		private sealed class _003CGetListsAsync_003Ed__20 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public Action<List[]> onFinished;

			public Trello _003C_003E4__this;

			public string boardID;

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
			public _003CGetListsAsync_003Ed__20(int _003C_003E1__state)
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

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}
		}

		public const int MaxCharLength = 16384;

		public const string CategoryTag = "(EF)";

		public const string TemplateBoardID = "589d1b02a4856195b7cc31c9";

		public const string AppKey = "9babe077311b8a24fddaebb73de1df6a";

		public const string ApiUri = "https://trello.com/1";

		public bool IsDoneUploading;

		public bool UploadError;

		public string ErrorMessage;

		public Exception UploadException;

		public AddCardResponse LastAddCardResponse;

		public UnityWebRequest LastRequest;

		private readonly string token;

		public static string AuthURL => null;

		public Trello(string token)
		{
		}

		public string GetURI(string apiPath)
		{
			return null;
		}

		public static bool IsValidToken(string token, bool silent = false)
		{
			return false;
		}

		[IteratorStateMachine(typeof(_003CAddCard_003Ed__17))]
		public IEnumerator AddCard(string name, string description, IEnumerable<Label> labels, string list, byte[] fileSource = null)
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CAddAttachmentAsync_003Ed__18))]
		public IEnumerator AddAttachmentAsync(string cardID, byte[] file = null, string url = null, string name = null, string mimeType = null)
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CGetLabelsAsync_003Ed__19))]
		public IEnumerator GetLabelsAsync(string boardID, Action<Label[]> onFinished)
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CGetListsAsync_003Ed__20))]
		public IEnumerator GetListsAsync(string boardID, Action<List[]> onFinished)
		{
			return null;
		}

		public List[] GetLists(string boardID)
		{
			return null;
		}

		public Board AddBoard(string name, bool defaultLabels = true, bool defaultLists = true, string desc = null, string idOrganization = null, string idBoardSource = null, string keepFromSource = "all", string powerUps = "all", Prefs? prefs = null)
		{
			return default(Board);
		}

		[IteratorStateMachine(typeof(_003CGetBoardsAsync_003Ed__23))]
		public IEnumerator GetBoardsAsync(Action<Board[]> onFinished)
		{
			return null;
		}

		public Board[] GetBoards()
		{
			return null;
		}

		public Label[] GetLabels(string boardID)
		{
			return null;
		}

		public bool GetSubscribed(string boardID)
		{
			return false;
		}

		public void PutSubscribed(string boardID, bool value)
		{
		}
	}
}
