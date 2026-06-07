using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace Gh.Tk.Story
{
	[AttributeUsage(AttributeTargets.Field, Inherited = false, AllowMultiple = false)]
	internal sealed class StoryNodeTranslateFieldContentAttribute : Attribute
	{
		[CompilerGenerated]
		private sealed class _003CGetAllRelevantFields_003Ed__10 : IEnumerable<(string, string, string)>, IEnumerable, IEnumerator<(string, string, string)>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private (string value, string comment, string translationType) _003C_003E2__current;

			private int _003C_003El__initialThreadId;

			private object obj;

			public object _003C_003E3__obj;

			private FieldInfo[] _003C_003E7__wrap1;

			private int _003C_003E7__wrap2;

			private StoryNodeTranslateFieldContentAttribute _003Cattribute_003E5__4;

			private string[] _003C_003E7__wrap4;

			private int _003C_003E7__wrap5;

			(string, string, string) IEnumerator<(string, string, string)>.Current
			{
				[DebuggerHidden]
				get
				{
					return default((string, string, string));
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
			public _003CGetAllRelevantFields_003Ed__10(int _003C_003E1__state)
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

			[DebuggerHidden]
			IEnumerator<(string, string, string)> IEnumerable<(string, string, string)>.GetEnumerator()
			{
				return null;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return null;
			}
		}

		public string Comments { get; set; }

		public string TranslationType { get; set; }

		public StoryNodeTranslateFieldContentAttribute(string comments = null, string translationType = "Node")
		{
		}

		public static void GenerateI18nEntries(object obj, string context, string fallbackTranslationType)
		{
		}

		[IteratorStateMachine(typeof(_003CGetAllRelevantFields_003Ed__10))]
		public static IEnumerable<(string, string, string)> GetAllRelevantFields(object obj)
		{
			return null;
		}
	}
}
