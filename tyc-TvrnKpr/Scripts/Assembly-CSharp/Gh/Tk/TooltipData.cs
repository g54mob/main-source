using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using LitJson;
using UnityEngine;

namespace Gh.Tk
{
	public class TooltipData : IPersistable, IReferenceableObject
	{
		[CompilerGenerated]
		private sealed class _003CExtractTooltipLinks_003Ed__20 : IEnumerable<int>, IEnumerable, IEnumerator<int>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private int _003C_003E2__current;

			private int _003C_003El__initialThreadId;

			private string text;

			public string _003C_003E3__text;

			private int _003Cindex_003E5__2;

			int IEnumerator<int>.Current
			{
				[DebuggerHidden]
				get
				{
					return 0;
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
			public _003CExtractTooltipLinks_003Ed__20(int _003C_003E1__state)
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
			IEnumerator<int> IEnumerable<int>.GetEnumerator()
			{
				return null;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return null;
			}
		}

		[CompilerGenerated]
		private sealed class _003CExtractTooltips_003Ed__5 : IEnumerable<TooltipData>, IEnumerable, IEnumerator<TooltipData>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private TooltipData _003C_003E2__current;

			private int _003C_003El__initialThreadId;

			private string text;

			public string _003C_003E3__text;

			private IEnumerator<int> _003C_003E7__wrap1;

			TooltipData IEnumerator<TooltipData>.Current
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
			public _003CExtractTooltips_003Ed__5(int _003C_003E1__state)
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
			IEnumerator<TooltipData> IEnumerable<TooltipData>.GetEnumerator()
			{
				return null;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return null;
			}
		}

		[JsonIgnore]
		private static readonly WeakCollection<TooltipData> _allTooltips;

		private static readonly List<TooltipData> _tmpCache;

		private static int lastFrameNumber;

		[PersistenceDefaultValue(/*Could not decode attribute arguments.*/)]
		private bool _persistData;

		private const string TOOLTIP_LINK_START = "<link=\"";

		private const string TOOLTIP_LINK_TEMPLATE = "<color={2}><u><link=\"{0}\">{1}</link></u></color>";

		private const string HANDBOOK_LINK_TEMPLATE = "<nobr><align=right><inline-icon icon='handbook' /><color={2}><u><link=\"{0}\">{1}</link></u></color></align></nobr>";

		[PersistenceObjectReference]
		[PersistenceAllowBrokenReferenceOnLoad]
		private List<TooltipData> AttachedTooltips;

		public string HeaderKey;

		public TooltipAlignment alignment;

		public Vector3 padding;

		public int maxWidth;

		[JsonIgnore]
		public GameObject buttonPrefab;

		[JsonIgnore]
		public Dictionary<string, Action> buttonActions;

		[JsonIgnore]
		public bool PersistData
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public int Id { get; private set; }

		public string ContentKey { get; internal set; }

		public bool IgnoreFallBackPosition { get; set; }

		public string ExternalLink { get; set; }

		[JsonIgnore]
		public string RelatedCodexKeyword { get; internal set; }

		internal static void DestroyNonGlobalTooltips()
		{
		}

		public static DataStore SaveData()
		{
			return null;
		}

		public static List<TooltipData> LoadData(DataStore data)
		{
			return null;
		}

		public static TooltipData GetTooltipFromId(int id)
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CExtractTooltips_003Ed__5))]
		public static IEnumerable<TooltipData> ExtractTooltips(string text)
		{
			return null;
		}

		private static void CacheTemporarily(TooltipData obj)
		{
		}

		private static void ClearFrameCache()
		{
		}

		protected TooltipData()
		{
		}

		public TooltipData(string headerKey = null, string contentKey = null, TooltipAlignment alignment = TooltipAlignment.Default, bool persistData = false, Dictionary<string, Action> buttonActions = null)
		{
		}

		public string CreateNestedTooltipLink(string word, string colorName = null)
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CExtractTooltipLinks_003Ed__20))]
		private static IEnumerable<int> ExtractTooltipLinks(string text)
		{
			return null;
		}

		private void ParseLinkedTooltips()
		{
		}

		public TooltipData[] GetAttachedTooltips()
		{
			return null;
		}

		public bool ContentsEquals(TooltipData other)
		{
			return false;
		}
	}
}
