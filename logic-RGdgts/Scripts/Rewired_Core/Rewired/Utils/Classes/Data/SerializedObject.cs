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
	[CustomClassObfuscation]
	[CustomObfuscation]
	internal sealed class SerializedObject : IEnumerable, IEnumerable<SerializedObject.Field>, IAddValue<object>, IAddKeyValue<string, object>, IExportToXml, IExportToJson
	{
		[CustomObfuscation]
		public enum ObjectType
		{
			[CustomObfuscation]
			Object = 0,
			[CustomObfuscation]
			List = 1
		}

		[Flags]
		[CustomObfuscation]
		public enum FieldOptions
		{
			[CustomObfuscation]
			None = 0,
			[CustomObfuscation]
			ExculdeFromXml = 1
		}

		private struct ZTdHAYJJDBUQKKJNTlfbSRzFfoO
		{
			public Type znvDEmuGvKVGSdBvMcCkiViHjgxuA;

			public object pWbMhcBQKZEHHDwvEOhqpAUJhzfpA;

			public FieldOptions vkpuBgDoOohCgjVVmPOpjzFNruoA;

			public ZTdHAYJJDBUQKKJNTlfbSRzFfoO(Type P_0, object P_1, FieldOptions P_2)
			{
				znvDEmuGvKVGSdBvMcCkiViHjgxuA = null;
				pWbMhcBQKZEHHDwvEOhqpAUJhzfpA = null;
				vkpuBgDoOohCgjVVmPOpjzFNruoA = default(FieldOptions);
			}

			public override string ToString()
			{
				return null;
			}
		}

		[CustomClassObfuscation]
		[CustomObfuscation]
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

		[CustomClassObfuscation]
		[CustomObfuscation]
		public class XmlInfo
		{
			public abstract class XGmYqdZiDDpfAtUYMLCyAZVffUPJ
			{
			}

			public class adZRTZDsgqtDqZBIYAKuebvqeDeUA : XGmYqdZiDDpfAtUYMLCyAZVffUPJ
			{
				public string zgPaEzAbwsGcNWlXnJVzKkGnHIbhb;

				public string DBsVPUbyEmkoGqiATtBbUGsLwABr;

				public string OTermNiKyMWnSeUawIBObeynBxKj;

				public string pWbMhcBQKZEHHDwvEOhqpAUJhzfpA;

				public override string ToString()
				{
					return null;
				}
			}

			private List<XGmYqdZiDDpfAtUYMLCyAZVffUPJ> iUOTmFOtLXZFzpVhQvrjmfYwfInf;

			public List<XGmYqdZiDDpfAtUYMLCyAZVffUPJ> attributes => null;

			public override string ToString()
			{
				return null;
			}
		}

		[CustomObfuscation]
		[CustomClassObfuscation]
		public struct Enumerator : IDisposable, IEnumerator, IEnumerator<Field>
		{
			private IndexedDictionary<string, ZTdHAYJJDBUQKKJNTlfbSRzFfoO> rqzlMgBEqYlprpsgKizQkexqOZQq;

			private Field FzeFBTyCrPwRSotVRRvPtdRXkqzA;

			private IEnumerator<KeyValuePair<string, ZTdHAYJJDBUQKKJNTlfbSRzFfoO>> kzQMnJRYEKQtXHBjUoiftzlWNXkh;

			public Field Current => default(Field);

			object IEnumerator.Current => null;

			internal Enumerator(object P_0)
			{
				rqzlMgBEqYlprpsgKizQkexqOZQq = null;
				FzeFBTyCrPwRSotVRRvPtdRXkqzA = default(Field);
				kzQMnJRYEKQtXHBjUoiftzlWNXkh = null;
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

		private class qUHbuwAFdlivUrivDpTTMixpAPoQ
		{
			public class TCcfMIHmqPnSbSdLxXJCrYSmqGPRA
			{
				public readonly string kXiencEahrSUtKlFEOwKvjtarZHH;

				public readonly TCcfMIHmqPnSbSdLxXJCrYSmqGPRA eHuiQIUmbPfDCAmSwYoMRKeanDnjb;

				public string tqHgRIwpGPgSYcemesJKghZUNWNG;

				public Dictionary<string, string> BLRfyNxxBXMnISXdUJogcCJvbsjP;

				public List<TCcfMIHmqPnSbSdLxXJCrYSmqGPRA> YexceuKjETxEkahgLCRbrHcwfrZH;

				public int OQzVIGKnHHTxlWoIMRdQQamZlSss => 0;

				public int XGlirvNZDaNrIngZYpxQeRkvKsed => 0;

				public TCcfMIHmqPnSbSdLxXJCrYSmqGPRA(string P_0, TCcfMIHmqPnSbSdLxXJCrYSmqGPRA P_1)
				{
				}

				public void GqFueqLxOfJrOMqiBkfvSWqfdVlW(TCcfMIHmqPnSbSdLxXJCrYSmqGPRA P_0)
				{
				}

				public void SLgkNGzipxFSwgmlUasMvVwqtTAZ(string P_0, string P_1)
				{
				}

				public bool tiSBrLIqYxSeUIMlrlDTAgYcRsKJA(string P_0)
				{
					return false;
				}

				public TCcfMIHmqPnSbSdLxXJCrYSmqGPRA FCnErRaWnUUOHNLVuYWXAAFqWtNf(string P_0)
				{
					return null;
				}

				public object nOubOzdysKmHkeRlacewlDBvuwlqA()
				{
					return null;
				}

				public override string ToString()
				{
					return null;
				}

				private string CyzqcuFQjIOjJglpJutjbTLGdstH(string P_0, int P_1)
				{
					return null;
				}
			}

			private readonly TCcfMIHmqPnSbSdLxXJCrYSmqGPRA zmbkmKoHUfgxdZptyBwbdswYKqyoA;

			public TCcfMIHmqPnSbSdLxXJCrYSmqGPRA DzwDAtePGHhejhDQEXsnjDgNqyzy => null;

			public bool MnJpMQFiroAQrejONWrLIhRQIMXzA => false;

			public qUHbuwAFdlivUrivDpTTMixpAPoQ(string P_0)
			{
			}

			private void nWpVyosfIpTExDBWDZskBlGDXSXn(XmlReader P_0)
			{
			}

			public override string ToString()
			{
				return null;
			}
		}

		[Serializable]
		private sealed class uMFZwvLwlhbjhniCpDzuFIVoFaCN
		{
			public static readonly uMFZwvLwlhbjhniCpDzuFIVoFaCN _003C_003E9;

			public static Func<FieldInfo, bool> _003C_003E9__63_0;

			public static Func<FieldInfo, string> _003C_003E9__63_1;

			public static Func<PropertyInfo, bool> _003C_003E9__63_2;

			public static Func<PropertyInfo, string> _003C_003E9__63_3;

			internal bool TXrEcYyQyEgDqYSbkPiLHHgrRzKH(FieldInfo P_0)
			{
				return false;
			}

			internal string BcgDRSuFpZqjFNdefiRsGeFXpapR(FieldInfo P_0)
			{
				return null;
			}

			internal bool ejcFKTEmXRZcyUGiGmrPAERLGqBGb(PropertyInfo P_0)
			{
				return false;
			}

			internal string xQmkuRZyaNMJhADSJmBVdoMIfvbE(PropertyInfo P_0)
			{
				return null;
			}
		}

		private readonly IndexedDictionary<string, ZTdHAYJJDBUQKKJNTlfbSRzFfoO> IHqksJJFofEjPfAUjDuiNWxtFsihA;

		private XmlInfo EnCErHjnJKbtUTjJGriELRBSCcch;

		private Type OkGTKhIUqsJqQkbQwDsMbAsaAzwbb;

		private ObjectType HDWGhGgRAwiVnpFFxoZkEjIdkemP;

		private static readonly Dictionary<Type, Dictionary<string, FieldInfo>> SIpifCnSchXqUoCDmjIsFEzoasXbb;

		private static readonly Dictionary<Type, Dictionary<string, PropertyInfo>> mZcAZEwdQDfJsbcJuwyOHwutISGUA;

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

		public Field Item => default(Field);

		bool IExportToXml.writesOwnElementTag => false;

		[CustomObfuscation]
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

		private void jvImzmESmwAEXCQYXyAZdrAdNRdr(XmlWriter P_0)
		{
		}

		private void BhgXmkezSjAKxRkPAXvwkJtpMtzX(XmlWriter P_0)
		{
		}

		private void fzJNqOZlFQwZEzIBaWpuHCYQxgaA(XmlWriter P_0)
		{
		}

		void IExportToXml.WriteXml(XmlWriter P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in fzJNqOZlFQwZEzIBaWpuHCYQxgaA
			this.fzJNqOZlFQwZEzIBaWpuHCYQxgaA(P_0);
		}

		private void zbvDbVCGhNzNUwOUlMMTBfbTUfpeb(StringBuilder P_0, Action<StringBuilder, object> P_1)
		{
		}

		void IExportToJson.WriteJson(StringBuilder P_0, Action<StringBuilder, object> P_1)
		{
			//ILSpy generated this explicit interface implementation from .override directive in zbvDbVCGhNzNUwOUlMMTBfbTUfpeb
			this.zbvDbVCGhNzNUwOUlMMTBfbTUfpeb(P_0, P_1);
		}

		void IAddValue<object>.Add(object P_0)
		{
		}

		void IAddKeyValue<string, object>.Add(string P_0, object P_1)
		{
		}

		IEnumerator<Field> IEnumerable<Field>.GetEnumerator()
		{
			return null;
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return null;
		}

		private static bool GnYRdSAeRMNYLQXdoFmKYEwSFggF<_0001>(object P_0, out _0001 P_1, NumberStyles P_2 = NumberStyles.Any, CultureInfo P_3 = null)
		{
			P_1 = default(_0001);
			return false;
		}

		private static bool GnYRdSAeRMNYLQXdoFmKYEwSFggF(Type P_0, object P_1, out object P_2, NumberStyles P_3 = NumberStyles.Any, CultureInfo P_4 = null)
		{
			P_2 = null;
			return false;
		}

		private static bool nmgCaDSxgIZLFVyAdqCFZDzdXCoN(Type P_0, SerializedObject P_1, out object P_2, NumberStyles P_3 = NumberStyles.Any, CultureInfo P_4 = null)
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
