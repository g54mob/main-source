using System;
using System.IO;
using System.Xml.Serialization;

namespace NSEipix.ObjectMapper
{
	public class XmlSerializer<T> : ISerializer<T>
	{
		public class Builder
		{
			private string path;

			private XmlRootAttribute root;

			private XmlAttributeOverrides overrides;

			public Builder(string path)
			{
				this.path = path;
				overrides = new XmlAttributeOverrides();
			}

			public Builder XmlRoot(string root)
			{
				this.root = new XmlRootAttribute();
				this.root.ElementName = root;
				return this;
			}

			public Builder XmlElement(string originalName, string newName)
			{
				XmlElementAttribute xmlElementAttribute = new XmlElementAttribute();
				xmlElementAttribute.ElementName = newName;
				XmlAttributes xmlAttributes = new XmlAttributes();
				xmlAttributes.XmlElements.Add(xmlElementAttribute);
				overrides.Add(typeof(T), originalName, xmlAttributes);
				return this;
			}

			public XmlSerializer<T> Build()
			{
				XmlSerializer serializer = new XmlSerializer(typeof(T), overrides, null, root, string.Empty);
				return XmlSerializer<T>.Both(path, serializer);
			}

			public XmlSerializer<T> BuildWithoutSerializer()
			{
				XmlSerializer serializer = new XmlSerializer(typeof(T), overrides, null, root, string.Empty);
				return XmlSerializer<T>.OnlyDeserializator(path, serializer);
			}

			public XmlSerializer<T> BuildWithoutDeserializer()
			{
				XmlSerializer serializer = new XmlSerializer(typeof(T), overrides, null, root, string.Empty);
				return XmlSerializer<T>.OnlySerializator(path, serializer);
			}
		}

		private string path;

		private XmlSerializer serializer;

		private Action<T> serializerImpl;

		private Func<T> deserializerImpl;

		private XmlSerializer(string path, XmlSerializer serializer)
		{
			this.path = path;
			this.serializer = serializer;
			serializerImpl = SerializeImpl;
			deserializerImpl = DeserializeImpl;
		}

		public void Serialize(T obj)
		{
			if (serializerImpl != null)
			{
				serializerImpl(obj);
			}
		}

		public T Deserialize()
		{
			if (deserializerImpl != null)
			{
				return deserializerImpl();
			}
			return default(T);
		}

		public T[] DeserializeDirectory(string path)
		{
			throw new NotImplementedException("See JsonSerializer.DeserializeDirectory");
		}

		private static XmlSerializer<T> Both(string path, XmlSerializer serializer)
		{
			return new XmlSerializer<T>(path, serializer);
		}

		private static XmlSerializer<T> OnlySerializator(string path, XmlSerializer serializer)
		{
			return new XmlSerializer<T>(path, serializer)
			{
				deserializerImpl = null
			};
		}

		private static XmlSerializer<T> OnlyDeserializator(string path, XmlSerializer serializer)
		{
			return new XmlSerializer<T>(path, serializer)
			{
				serializerImpl = null
			};
		}

		private void SerializeImpl(T obj)
		{
			using Stream stream = new FileStream(path, FileMode.Create);
			serializer.Serialize(stream, obj);
		}

		private T DeserializeImpl()
		{
			if (!File.Exists(path))
			{
				return default(T);
			}
			using Stream stream = new FileStream(path, FileMode.Open);
			return (T)serializer.Deserialize(stream);
		}
	}
}
