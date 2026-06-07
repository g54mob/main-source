using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using FractureField.Rocks;
using FractureField.Tools;

namespace FractureField
{
	public class Localization
	{
		public class Rocks
		{
			public static string GetLayerName(RockLayerType layerType)
			{
				return null;
			}

			public static string GetWithLayerName(string key, RockLayerType rockLayerType)
			{
				return null;
			}

			public static string GetLayerCurrencyName(RockLayerType layerType)
			{
				return null;
			}

			public static string GetWithLayerCurrencyName(string key, RockLayerType rockLayerType)
			{
				return null;
			}

			private static Dictionary<string, object> GetLayerNameDict(RockLayerType layerType)
			{
				return null;
			}

			private static Dictionary<string, object> GetLayerCurrencyNameDict(RockLayerType layerType)
			{
				return null;
			}
		}

		public class Tools
		{
			public static string GetToolName(ToolType toolType)
			{
				return null;
			}

			public static string GetWithToolName(ToolType toolType)
			{
				return null;
			}

			private static Dictionary<string, object> GetToolNameDict(ToolType toolType)
			{
				return null;
			}
		}

		[CompilerGenerated]
		private sealed class _003CRestartGameCoroutine_003Ed__11 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

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
			public _003CRestartGameCoroutine_003Ed__11(int _003C_003E1__state)
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

		public static string SelectedLanguageCode => null;

		public static bool IsSimplifiedChinese => false;

		public static bool IsTraditionalChinese => false;

		public static bool IsChinese => false;

		public static bool IsAsianLanguage => false;

		public static void ChangeLanguage(string code)
		{
		}

		[IteratorStateMachine(typeof(_003CRestartGameCoroutine_003Ed__11))]
		private static IEnumerator RestartGameCoroutine()
		{
			return null;
		}

		private string ByKey(string key, string tableName = "MainLocalization")
		{
			return null;
		}

		private string ByKey(string key, Dictionary<string, object> paramDict, string tableName = "MainLocalization")
		{
			return null;
		}

		private static string FormatKey(string key)
		{
			return null;
		}

		public static string Get(string key)
		{
			return null;
		}

		public static string GetFromTable(string key, string tableName)
		{
			return null;
		}

		public static string GetWithDict(string key, Dictionary<string, object> paramDict)
		{
			return null;
		}

		public static string GetWithSingleDictKey(string key, string singleDictKey)
		{
			return null;
		}

		public static string GetWithSingleDictValue(string key, object value)
		{
			return null;
		}

		public static string GetWithDictKeys(string key, List<string> dictKeys)
		{
			return null;
		}

		private static Dictionary<string, object> GetSingleDictFromKey(string key)
		{
			return null;
		}

		private static Dictionary<string, object> GetSingleDictFromValue(object value)
		{
			return null;
		}

		private static Dictionary<string, object> GetDictFromKeys(List<string> keys)
		{
			return null;
		}
	}
}
