using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Gh.Tk
{
	public class DataResources : SingletonScriptableObjectAsset<DataResources>
	{
		[Serializable]
		public class DataResource
		{
			public string fileName;

			[HideInInspector]
			public byte[] data;

			public int sizeInBytes;
		}

		public struct LoadingText : IEquatable<LoadingText>
		{
			public string unlocksWithCodexId;

			public string loadingText;

			public bool isTip;

			public bool Equals(LoadingText other)
			{
				return false;
			}

			public override bool Equals(object obj)
			{
				return false;
			}

			public override int GetHashCode()
			{
				return 0;
			}
		}

		[CompilerGenerated]
		private sealed class _003C_003Ec__DisplayClass4_0
		{
			public Func<string, bool> filter;

			public DataResources _003C_003E4__this;

			public Func<DataResource, bool> _003C_003E9__0;

			internal bool _003CGetContentForFilenameFilter_003Eb__0(DataResource x)
			{
				return false;
			}
		}

		[CompilerGenerated]
		private sealed class _003CGetContentForFilenameFilter_003Ed__4 : IEnumerable<(string, Func<string>)>, IEnumerable, IEnumerator<(string, Func<string>)>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private (string fileName, Func<string> readText) _003C_003E2__current;

			private int _003C_003El__initialThreadId;

			private Func<string, bool> filter;

			public Func<string, bool> _003C_003E3__filter;

			public DataResources _003C_003E4__this;

			private _003C_003Ec__DisplayClass4_0 _003C_003E8__1;

			private IEnumerator<DataResource> _003C_003E7__wrap1;

			(string, Func<string>) IEnumerator<(string, Func<string>)>.Current
			{
				[DebuggerHidden]
				get
				{
					return default((string, Func<string>));
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
			public _003CGetContentForFilenameFilter_003Ed__4(int _003C_003E1__state)
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

			[DebuggerHidden]
			IEnumerator<(string, Func<string>)> IEnumerable<(string, Func<string>)>.GetEnumerator()
			{
				return null;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return null;
			}
		}

		public DataResource[] resources;

		public string GetTextData(string filePath)
		{
			return null;
		}

		private string ReadTextData(DataResource item)
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CGetContentForFilenameFilter_003Ed__4))]
		public IEnumerable<(string, Func<string>)> GetContentForFilenameFilter(Func<string, bool> filter)
		{
			return null;
		}

		public static List<LoadingText> ParseLoadingTexts()
		{
			return null;
		}

		public List<BankruptcyEpilogue> ParseBankruptcyEpilogueData()
		{
			return null;
		}
	}
}
