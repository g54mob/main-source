using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using System.Text;
using System.Xml;
using Rewired.Utils.Attributes;
using Rewired.Utils.Interfaces;

namespace Rewired.Utils.Classes.Data
{
	[Preserve]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal sealed class SerializedObject : IEnumerable<SerializedObject.Field>, IEnumerable, IExportToXml, IExportToJson, IAddValue<object>, IAddKeyValue<string, object>
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

		private struct vHvgJfriEnFAoBZSTlwpNeizyhhiA
		{
			public Type OfwgBhUJWculuelKaCSYIKrOYbKO;

			public object fLsUZyEVbVgvDyJXbfFGQieiZTWd;

			public FieldOptions gcsLSYQNJoAOMFFLlazuhvTIJGsr;

			public vHvgJfriEnFAoBZSTlwpNeizyhhiA(Type P_0, object P_1, FieldOptions P_2)
			{
				OfwgBhUJWculuelKaCSYIKrOYbKO = null;
				fLsUZyEVbVgvDyJXbfFGQieiZTWd = null;
				gcsLSYQNJoAOMFFLlazuhvTIJGsr = default(FieldOptions);
			}

			public override string ToString()
			{
				return null;
			}
		}

		[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
		[CustomObfuscation(rename = false)]
		public struct Field
		{
			public string name;

			public object value;

			public Type type;

			public FieldOptions options;

			public Field(string P_0, object P_1, Type P_2, FieldOptions P_3)
			{
				name = null;
				value = null;
				type = null;
				options = default(FieldOptions);
			}

			public override string ToString()
			{
				return null;
			}
		}

		[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
		[CustomObfuscation(rename = false)]
		public class XmlInfo
		{
			public abstract class foGQQAmUQxijwcrJClUqBrydfQKk
			{
			}

			public class EndBkowpwOTxIGJnMBcsgiGqTpvf : foGQQAmUQxijwcrJClUqBrydfQKk
			{
				public string WxmFjndTttjqQAYFRlGSZJiUawrZ;

				public string pIIbLDKqkVfRyNCGQyHEEVIpxwRdA;

				public string FnmpvPDmwsSGLmiBdhdjjjOdjSKDb;

				public string qqfRFgGAtDPLKSLpFGzHGleMdWxAb;

				public override string ToString()
				{
					return null;
				}
			}

			private List<foGQQAmUQxijwcrJClUqBrydfQKk> hvtFpapzESwBkiXULGOTskCgudBY;

			public List<foGQQAmUQxijwcrJClUqBrydfQKk> attributes => null;

			public override string ToString()
			{
				return null;
			}
		}

		[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
		[CustomObfuscation(rename = false)]
		public struct Enumerator : IEnumerator<Field>, IEnumerator, IDisposable
		{
			private IndexedDictionary<string, vHvgJfriEnFAoBZSTlwpNeizyhhiA> iPYZGuqkJNpcBIOByGpPPqykVgVQ;

			private Field fbmZNIKNatKgLbkRQkORPfpthvjM;

			private IEnumerator<KeyValuePair<string, vHvgJfriEnFAoBZSTlwpNeizyhhiA>> HvqnGVjbGWhPJBLsAcVRbjkjxZhSb;

			public Field Current => default(Field);

			object IEnumerator.Current => null;

			internal Enumerator(object P_0)
			{
				iPYZGuqkJNpcBIOByGpPPqykVgVQ = null;
				fbmZNIKNatKgLbkRQkORPfpthvjM = default(Field);
				HvqnGVjbGWhPJBLsAcVRbjkjxZhSb = null;
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

		private class MYxGtLFzyBwzgmmqLoOROZGhsZzPA
		{
			public class hQQdIlTApjoWLqwAlHOWRpbqYCWr
			{
				public readonly string ZqapNBPQhxYWrtxxhNLshKPnGpDdA;

				public readonly hQQdIlTApjoWLqwAlHOWRpbqYCWr IaNQIXFrAAEHjggqzLtxptJZZffL;

				public string BtLfUvTRqPPxWGEPjKQrERfZicxn;

				public Dictionary<string, string> hJkBKUAFaZEbqzximaspbRaGXCKBc;

				public List<hQQdIlTApjoWLqwAlHOWRpbqYCWr> FnOfitCKhXWuFrtPnctjDXCAYJaF;

				public int hOmkZmqfeJCIGrdixvRDIzdBKrKl => 0;

				public int eEPCxFLfaATJvlTUnPUbUUsvtiSG => 0;

				public hQQdIlTApjoWLqwAlHOWRpbqYCWr(string P_0, hQQdIlTApjoWLqwAlHOWRpbqYCWr P_1)
				{
				}

				public void UxhrwHFWyDKauNsBLNEltoadcTDT(hQQdIlTApjoWLqwAlHOWRpbqYCWr P_0)
				{
				}

				public void xRmNlgezpLrpiCifZZCGRyBGknag(string P_0, string P_1)
				{
				}

				public bool DIapFbmnXEgUAVsRJWSlrYuQuEIv(string P_0)
				{
					return false;
				}

				public hQQdIlTApjoWLqwAlHOWRpbqYCWr CPJxEtiYoklGxzQQDJFLVJsiwYjh(string P_0)
				{
					return null;
				}

				public object nDBimxBxcmxujmWAlfAKROBZrJg()
				{
					return null;
				}

				public override string ToString()
				{
					return null;
				}

				private string TLUUthMHThEIzveTWKtXJmMvcMwZ(string P_0, int P_1)
				{
					return null;
				}
			}

			private readonly hQQdIlTApjoWLqwAlHOWRpbqYCWr eESKntIdMWhDYmiCrkSsSbLYFCrl;

			public hQQdIlTApjoWLqwAlHOWRpbqYCWr JELPgmgqulQWqPOynUHuzxrwQzBk => null;

			public bool kjxyLnVEBJEYlJQggXnoMlvBJVAo => false;

			public MYxGtLFzyBwzgmmqLoOROZGhsZzPA(string P_0)
			{
			}

			private void xnzWKeEKNrZewRCXEkrFARwwnZuF(XmlReader P_0)
			{
			}

			public override string ToString()
			{
				return null;
			}
		}

		[Serializable]
		private sealed class UFnbTGekyLidHdmXdNykYGciKmJVA
		{
			public static readonly UFnbTGekyLidHdmXdNykYGciKmJVA _003C_003E9;

			public static Func<FieldInfo, bool> _003C_003E9__63_0;

			public static Func<FieldInfo, string> _003C_003E9__63_1;

			public static Func<PropertyInfo, bool> _003C_003E9__63_2;

			public static Func<PropertyInfo, string> _003C_003E9__63_3;

			internal bool GJooAjGnfSgCTSjrbeqfVjKEaNuI(FieldInfo P_0)
			{
				return false;
			}

			internal string bYcAGbKggixxwvDPJULMtwspUuhk(FieldInfo P_0)
			{
				return null;
			}

			internal bool ZvUTYzbYKNOGSoRSHOepcJUgiZmF(PropertyInfo P_0)
			{
				return false;
			}

			internal string htUfJPJSczDeqlMoZeWebhqhFoEbA(PropertyInfo P_0)
			{
				return null;
			}
		}

		private readonly IndexedDictionary<string, vHvgJfriEnFAoBZSTlwpNeizyhhiA> NJBFJhEDBvokerDkXgqPdHUwqafzA;

		private XmlInfo DWdNzAVnNcoDUtPWdCXIpGfUYzeK;

		private Type VHLSCQkReHdcRsnpILawZkaGBdOhA;

		private ObjectType IzLLyUApGJmSvSZRMfEEijfxERLDA;

		private static readonly Dictionary<Type, Dictionary<string, FieldInfo>> OOnICwicSnBYQgqtKVQqQyMMFcaE;

		private static readonly Dictionary<Type, Dictionary<string, PropertyInfo>> FueGoYjcbvPcyOauWkBJtGJGNJTP;

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

		private SerializedObject(int P_0)
		{
		}

		public SerializedObject(Type P_0, ObjectType P_1)
		{
		}

		public SerializedObject(Type P_0, ObjectType P_1, int P_2)
		{
		}

		public SerializedObject(Type P_0, IDictionary<string, object> P_1, ObjectType P_2)
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

		private void IRLEFGHNMWjdrKfNhhtPNDCzSxiab(XmlWriter P_0)
		{
		}

		private void YfXxUdUwNpNKvElVffUufBVJPcsi(XmlWriter P_0)
		{
		}

		private void jfEWjhxoubpPokExKPZUQYTBCQAF(XmlWriter P_0)
		{
		}

		void IExportToXml.WriteXml(XmlWriter P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in jfEWjhxoubpPokExKPZUQYTBCQAF
			this.jfEWjhxoubpPokExKPZUQYTBCQAF(P_0);
		}

		private void nOtJUEDwpIhnIstKJrsXKefZeHVo(StringBuilder P_0, Action<StringBuilder, object> P_1)
		{
		}

		void IExportToJson.WriteJson(StringBuilder P_0, Action<StringBuilder, object> P_1)
		{
			//ILSpy generated this explicit interface implementation from .override directive in nOtJUEDwpIhnIstKJrsXKefZeHVo
			this.nOtJUEDwpIhnIstKJrsXKefZeHVo(P_0, P_1);
		}

		private void QlBdPyiSFjBDtPEAAfSFtcAeNJOCA(object P_0)
		{
		}

		void IAddValue<object>.Add(object P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in QlBdPyiSFjBDtPEAAfSFtcAeNJOCA
			this.QlBdPyiSFjBDtPEAAfSFtcAeNJOCA(P_0);
		}

		private void nGQYDiMoSpBaHINfDLxEBFjikUHIA(string P_0, object P_1)
		{
		}

		void IAddKeyValue<string, object>.Add(string P_0, object P_1)
		{
			//ILSpy generated this explicit interface implementation from .override directive in nGQYDiMoSpBaHINfDLxEBFjikUHIA
			this.nGQYDiMoSpBaHINfDLxEBFjikUHIA(P_0, P_1);
		}

		IEnumerator<Field> IEnumerable<Field>.GetEnumerator()
		{
			return null;
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return null;
		}

		private static bool iQVRXHLtqFkJDchEgUojqtsKIHKb<_0001>(object P_0, out _0001 P_1, NumberStyles P_2 = NumberStyles.Any, CultureInfo P_3 = null)
		{
			P_1 = default(_0001);
			return false;
		}

		private static bool RgKoMqlZIaYhTQFVjsVPXoanvhrb(Type P_0, object P_1, out object P_2, NumberStyles P_3 = NumberStyles.Any, CultureInfo P_4 = null)
		{
			P_2 = null;
			return false;
		}

		private static bool tWIgofiJmJglLpKsZtNNLipskaWWA(Type P_0, SerializedObject P_1, out object P_2, NumberStyles P_3 = NumberStyles.Any, CultureInfo P_4 = null)
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
	}
}
