using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace com.ootii.Utilities.Debug
{
	public class Log : MonoBehaviour
	{
		[CompilerGenerated]
		private sealed class _003CStart_003Ed__10 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public Log _003C_003E4__this;

			private WaitForEndOfFrame _003ClWaitForEndOfFrame_003E5__2;

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
			public _003CStart_003Ed__10(int _003C_003E1__state)
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

		public bool _PrefixTime;

		public bool _IsConsoleEnabled;

		public bool _IsScreenEnabled;

		public int _LineCount;

		public int _ScreenFontSize;

		public Color _ScreenForeColor;

		public bool _ClearScreenEachFrame;

		public bool _IsFileEnabled;

		public string _FilePath;

		public bool _FileFlushPerWrite;

		private static string mFilePath;

		private static bool mPrefixTime;

		private static int mLineHeight;

		private static bool mClearScreenEachFrame;

		private static bool mIsEnabled;

		private static bool mIsFileEnabled;

		private static bool mIsScreenEnabled;

		private static bool mIsConsoleEnabled;

		private static bool mFileFlushPerWrite;

		private static int mLineCount;

		private static int mFontSize;

		private static Color mForeColor;

		private static LogText[] mLines;

		private static int mLineIndex;

		private static Rect mLineRect;

		public static string FilePath
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public static bool PrefixTime
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public static int LineHeight
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public static bool ClearScreenEachFrame
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public static bool IsEnabled
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public static bool IsFileEnabled
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public static bool IsScreenEnabled
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public static bool IsConsoleEnabled
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public static bool FileFlushPerWrite
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public static int LineCount
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public static int FontSize
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public static Color ForeColor
		{
			get
			{
				return default(Color);
			}
			set
			{
			}
		}

		[IteratorStateMachine(typeof(_003CStart_003Ed__10))]
		public IEnumerator Start()
		{
			return null;
		}

		public void OnDestroy()
		{
		}

		private void OnGUI()
		{
		}

		static Log()
		{
		}

		public static void Write(string rText)
		{
		}

		public static void FileScreenWrite(string rText, int rLine)
		{
		}

		public static void FileWrite(string rText)
		{
		}

		public static void FileWrite(string rText, bool rPrefixTime)
		{
		}

		public static void ConsoleScreenWrite(string rText)
		{
		}

		public static void ConsoleScreenWrite(string rText, int rLine)
		{
		}

		public static void ConsoleWrite(string rText)
		{
		}

		public static void ConsoleWrite(string rText, bool rPrefixTime)
		{
		}

		public static void ConsoleWriteWarning(string rText)
		{
		}

		public static void ConsoleWriteError(string rText)
		{
		}

		public static void ScreenWrite(string rText)
		{
		}

		public static void ScreenWrite(int rLine, params string[] rText)
		{
		}

		public static void ScreenWrite(string rText, int rLine)
		{
		}

		public static void ScreenWrite(string rText, int rX, int rY)
		{
		}

		public static void ScreenWriteTop(string rText)
		{
		}

		public static void ScreenWriteBottom(string rText)
		{
		}

		public static void Render()
		{
		}

		public static void Clear()
		{
		}

		public static void Close()
		{
		}
	}
}
