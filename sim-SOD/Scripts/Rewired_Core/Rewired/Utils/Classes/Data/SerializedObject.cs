using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Xml;
using Rewired.Utils.Attributes;
using Rewired.Utils.Interfaces;

namespace Rewired.Utils.Classes.Data
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[Preserve]
	[CustomObfuscation(rename = false)]
	internal sealed class SerializedObject : IEnumerable, IEnumerable<SerializedObject.Field>, IAddValue<object>, IAddKeyValue<string, object>, IExportToXml, IExportToJson
	{
		[CustomObfuscation(rename = false)]
		public enum ObjectType
		{
			[CustomObfuscation(rename = false)]
			Object = 0,
			[CustomObfuscation(rename = false)]
			List = 1
		}

		[Flags]
		[CustomObfuscation(rename = false)]
		public enum FieldOptions
		{
			[CustomObfuscation(rename = false)]
			None = 0,
			[CustomObfuscation(rename = false)]
			ExculdeFromXml = 1
		}

		private struct LvRIxJKFNrGSgKNxCLwetiaqjIh
		{
			public Type hDtgVbCmhmFCmmrLPyolkLJOYLeq;

			public object vlnXqrXZUnXUpcXPRJmvOerSEWc;

			public FieldOptions tekdfSVNqirfgxlpKjzPddSSJSx;

			public LvRIxJKFNrGSgKNxCLwetiaqjIh(Type type, object value, FieldOptions options)
			{
				hDtgVbCmhmFCmmrLPyolkLJOYLeq = null;
				vlnXqrXZUnXUpcXPRJmvOerSEWc = null;
				tekdfSVNqirfgxlpKjzPddSSJSx = default(FieldOptions);
			}

			public override string ToString()
			{
				return null;
			}
		}

		[CustomObfuscation(rename = false)]
		[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
		public struct Field
		{
			public string name;

			public object value;

			public Type type;

			public FieldOptions options;

			public Field(string name, object value, Type type, FieldOptions options)
			{
				this.name = null;
				this.value = null;
				this.type = null;
				this.options = default(FieldOptions);
			}

			public override string ToString()
			{
				return null;
			}
		}

		[CustomObfuscation(rename = false)]
		[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
		public class XmlInfo
		{
			public abstract class FvqVucXeXrtCmpIqVbbzCjiuEWU
			{
			}

			public class wPDtIYXNcANLKHvaDJcndEOleqxD : FvqVucXeXrtCmpIqVbbzCjiuEWU
			{
				public string pQJHFevxeCvsbngpetzemadkRlq;

				public string VnasMVzPASzywkIoEapsClFSNbM;

				public string UiyqxCylEqWJcivixgKZpEVyfyZ;

				public string vlnXqrXZUnXUpcXPRJmvOerSEWc;

				public override string ToString()
				{
					return null;
				}
			}

			private List<FvqVucXeXrtCmpIqVbbzCjiuEWU> mFQUUKSPJfLDTrXsPJcXmtddCHi;

			public List<FvqVucXeXrtCmpIqVbbzCjiuEWU> attributes => null;

			public override string ToString()
			{
				return null;
			}
		}

		[CustomObfuscation(rename = false)]
		[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
		public struct Enumerator : IDisposable, IEnumerator, IEnumerator<Field>
		{
			private IndexedDictionary<string, LvRIxJKFNrGSgKNxCLwetiaqjIh> xEtYLjRlyaFxVFzULJXVkwKlXoN;

			private Field DNsUOSgZQrgrzaoVIbqmnEQQRth;

			private IEnumerator<KeyValuePair<string, LvRIxJKFNrGSgKNxCLwetiaqjIh>> qJARbOHWuwAQlBPBJIuilMFDixt;

			public Field Current => default(Field);

			object IEnumerator.Current => null;

			internal Enumerator(object dictionary)
			{
				xEtYLjRlyaFxVFzULJXVkwKlXoN = null;
				DNsUOSgZQrgrzaoVIbqmnEQQRth = default(Field);
				qJARbOHWuwAQlBPBJIuilMFDixt = null;
			}

			public bool MoveNext()
			{
				return false;
			}

			public void Dispose()
			{
			}

			void IEnumerator.Reset()
			{
			}
		}

		private class eJCcnMjlXArcjxDWHdSeQYyYwpb
		{
			public class ZrTspZGutgUDogkPYipbjnfjvfSV
			{
				public readonly string qkizrzMRtHOxHKaxNwCJnfOzDGW;

				public readonly ZrTspZGutgUDogkPYipbjnfjvfSV qWgFJFBIlrmHoiykxhUXhURpcwyE;

				public string jCLroTyUlzockuESzMQHeVoBquE;

				public Dictionary<string, string> NABflMhjHzXKiAtJZZtrqdwmJVm;

				public List<ZrTspZGutgUDogkPYipbjnfjvfSV> GSpjFjCAznHzMepUQqmivUZnEUM;

				public int childCount => 0;

				public int attributeCount => 0;

				public ZrTspZGutgUDogkPYipbjnfjvfSV(string name, ZrTspZGutgUDogkPYipbjnfjvfSV parent)
				{
				}

				public void ADNqtdLNUXUxcCPSKoNyOHHmuxo(ZrTspZGutgUDogkPYipbjnfjvfSV P_0)
				{
				}

				public void MbmCMDCnlDjYOZyBNYSLXyTxegP(string P_0, string P_1)
				{
				}

				public bool vTEheYwBCJMssYUBmGnCkDbbURT(string P_0)
				{
					return false;
				}

				public ZrTspZGutgUDogkPYipbjnfjvfSV XoxPJMqdfiCPzLnnvemQUBajabY(string P_0)
				{
					return null;
				}

				public object tzqgHwoHsmdPWGHVxfCjALiCsPwC()
				{
					return null;
				}

				public override string ToString()
				{
					return null;
				}

				private string WlhpJxPzRcGBzoaBUCjitjuFYxm(string P_0, int P_1)
				{
					return null;
				}
			}

			private readonly ZrTspZGutgUDogkPYipbjnfjvfSV hAhCnZcyIZLnJiXBhTWeaiLLVPhp;

			public ZrTspZGutgUDogkPYipbjnfjvfSV root => null;

			public bool isValid => false;

			public eJCcnMjlXArcjxDWHdSeQYyYwpb(string xml)
			{
			}

			private void hirnztiyERPILRpgCgCpXVlIOjA(XmlReader P_0)
			{
			}

			public override string ToString()
			{
				return null;
			}
		}

		private readonly IndexedDictionary<string, LvRIxJKFNrGSgKNxCLwetiaqjIh> KtkrDIPmKBntRncfwGcdJKZoZAp;

		private XmlInfo AcWVcSlFnidrmDFFRCFViPwTbptE;

		private Type WwGNBcAzyQKiegnejLCVExHzkIt;

		private ObjectType TSWGcLgiGYnRZrsnegrjCOlkLDlD;

		private static readonly Dictionary<Type, Dictionary<string, FieldInfo>> EyrFuTBlwPqekRcjxjyjgMSFtZSH;

		private static readonly Dictionary<Type, Dictionary<string, PropertyInfo>> acAWHcsMzhJGHkhfxAHBgNEkpKZ;

		[CompilerGenerated]
		private static Func<FieldInfo, bool> HMOMQkhRNslmnsRSdjdErMIPeq;

		[CompilerGenerated]
		private static Func<FieldInfo, string> rWTPQhLeNWbucoWbsCbtCauqryk;

		[CompilerGenerated]
		private static Func<PropertyInfo, bool> CjqRMztnLjKGLuXIZBgGKOaCzEa;

		[CompilerGenerated]
		private static Func<PropertyInfo, string> uZzfPxpvnPIxhwlzTQVUQsnLlYF;

		private bool allowDuplicateKeys => false;

		public ObjectType objectType
		{
			get
			{
				return default(ObjectType);
			}
			set
			{
			}
		}

		public Type type => null;

		public XmlInfo xmlInfo
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public int count => 0;

		public Field this[int index] => default(Field);

		bool IExportToXml.writesOwnElementTag => false;

		[CustomObfuscation(rename = false)]
		private SerializedObject()
		{
		}

		private SerializedObject(int capacity)
		{
		}

		public SerializedObject(Type type, ObjectType objectType)
		{
		}

		public SerializedObject(Type type, ObjectType objectType, int capacity)
		{
		}

		public SerializedObject(Type type, IDictionary<string, object> dictionary, ObjectType objectType)
		{
		}

		public void Add<T>(string fieldName, T value, FieldOptions options = FieldOptions.None)
		{
		}

		public void Add(Type type, string fieldName, object value, FieldOptions options = FieldOptions.None)
		{
		}

		public void Add(string fieldName, object value)
		{
		}

		public bool Remove(string fieldName)
		{
			return false;
		}

		public bool Contains(string fieldName)
		{
			return false;
		}

		public Type GetDataType(string fieldName)
		{
			return null;
		}

		public bool TryGetOriginalValue(string fieldName, out object value)
		{
			value = null;
			return false;
		}

		public Field GetEntry(string fieldName)
		{
			return default(Field);
		}

		public object GetOriginalValue(string fieldName)
		{
			return null;
		}

		public object GetOriginalValue(int index)
		{
			return null;
		}

		public T GetOriginalValue<T>(string fieldName)
		{
			return default(T);
		}

		public T GetOriginalValue<T>(int index)
		{
			return default(T);
		}

		public bool TryGetDeserializedValue<T>(string fieldName, out T value)
		{
			value = default(T);
			return false;
		}

		public bool TryGetDeserializedValue<T>(int index, out T value)
		{
			value = default(T);
			return false;
		}

		public bool TryGetDeserializedValueByRef<T>(string fieldName, ref T value)
		{
			return false;
		}

		public bool TryGetDeserializedValueByRef<T>(int index, ref T value)
		{
			return false;
		}

		public string ToXmlString(bool writeDocumentTag)
		{
			return null;
		}

		public string ToJsonString()
		{
			return null;
		}

		public override string ToString()
		{
			return null;
		}

		private void fkUxqjWMuMTUlSDsGTwEnSbsawi(XmlWriter P_0)
		{
		}

		private void RtkMlfooYRgMHCVnHBPtEiKEwIue(XmlWriter P_0)
		{
		}

		private void dibBGnPHpzbmrazkACiiDVdbBOtS(XmlWriter P_0)
		{
		}

		void IExportToXml.WriteXml(XmlWriter P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in dibBGnPHpzbmrazkACiiDVdbBOtS
			this.dibBGnPHpzbmrazkACiiDVdbBOtS(P_0);
		}

		private void pLrImWAipprJgYbwwmyCffSSbOw(StringBuilder P_0, Action<StringBuilder, object> P_1)
		{
		}

		void IExportToJson.WriteJson(StringBuilder P_0, Action<StringBuilder, object> P_1)
		{
			//ILSpy generated this explicit interface implementation from .override directive in pLrImWAipprJgYbwwmyCffSSbOw
			this.pLrImWAipprJgYbwwmyCffSSbOw(P_0, P_1);
		}

		private void BPKCoXmauhbdbpZoiIgNRRFbHlF(object P_0)
		{
		}

		void IAddValue<object>.Add(object P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in BPKCoXmauhbdbpZoiIgNRRFbHlF
			this.BPKCoXmauhbdbpZoiIgNRRFbHlF(P_0);
		}

		private void pJzKLPLNQkUUGtjqyubdDtKjrsH(string P_0, object P_1)
		{
		}

		void IAddKeyValue<string, object>.Add(string P_0, object P_1)
		{
			//ILSpy generated this explicit interface implementation from .override directive in pJzKLPLNQkUUGtjqyubdDtKjrsH
			this.pJzKLPLNQkUUGtjqyubdDtKjrsH(P_0, P_1);
		}

		IEnumerator<Field> IEnumerable<Field>.GetEnumerator()
		{
			return null;
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return null;
		}

		private static bool CaAVmRMKPyqOlOtJnrpBYZbJEcd<T>(object P_0, out T P_1, NumberStyles P_2 = NumberStyles.Any, CultureInfo P_3 = null)
		{
			P_1 = default(T);
			return false;
		}

		private static bool CaAVmRMKPyqOlOtJnrpBYZbJEcd(Type P_0, object P_1, out object P_2, NumberStyles P_3 = NumberStyles.Any, CultureInfo P_4 = null)
		{
			P_2 = null;
			return false;
		}

		private static bool dWakjGAegcIBpTVmmjqUJVMeFthy(Type P_0, SerializedObject P_1, out object P_2, NumberStyles P_3 = NumberStyles.Any, CultureInfo P_4 = null)
		{
			P_2 = null;
			return false;
		}

		public static SerializedObject FromJson(Type type, string jsonString)
		{
			return null;
		}

		public static SerializedObject FromXml(Type type, string xmlString)
		{
			return null;
		}

		[CompilerGenerated]
		private static bool DXYsedKFZpielcDtEzeRRnLfuoS(FieldInfo P_0)
		{
			return false;
		}

		[CompilerGenerated]
		private static string qlQcDtcVnUmxhjQWAUTBqUYqmAj(FieldInfo P_0)
		{
			return null;
		}

		[CompilerGenerated]
		private static bool JSvobdNJzIhTqEdLTYlERLZCJML(PropertyInfo P_0)
		{
			return false;
		}

		[CompilerGenerated]
		private static string WxUIFWhmpIWWiGerBFmPfajGlijw(PropertyInfo P_0)
		{
			return null;
		}
	}
}
