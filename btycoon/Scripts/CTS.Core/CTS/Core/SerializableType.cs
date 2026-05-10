using System;
using System.IO;
using UnityEngine;

namespace CTS.Core
{
	[Serializable]
	public class SerializableType : ISerializationCallbackReceiver
	{
		[SerializeField]
		private byte[] _data;

		public Type Type { get; set; }

		public SerializableType(Type aType)
		{
			Type = aType;
		}

		public static Type Read(BinaryReader aReader)
		{
			byte b = aReader.ReadByte();
			if (b == byte.MaxValue)
			{
				return null;
			}
			string text = aReader.ReadString();
			Type type = Type.GetType(text);
			if (type == null)
			{
				throw new Exception("Can't find type; '" + text + "'");
			}
			if (type.IsGenericTypeDefinition && b > 0)
			{
				Type[] array = new Type[b];
				for (int i = 0; i < b; i++)
				{
					array[i] = Read(aReader);
				}
				type = type.MakeGenericType(array);
			}
			return type;
		}

		public static void Write(BinaryWriter aWriter, Type aType)
		{
			if (aType == null)
			{
				aWriter.Write(byte.MaxValue);
			}
			else if (aType.IsGenericType)
			{
				Type genericTypeDefinition = aType.GetGenericTypeDefinition();
				Type[] genericArguments = aType.GetGenericArguments();
				aWriter.Write((byte)genericArguments.Length);
				aWriter.Write(genericTypeDefinition.AssemblyQualifiedName);
				for (int i = 0; i < genericArguments.Length; i++)
				{
					Write(aWriter, genericArguments[i]);
				}
			}
			else
			{
				aWriter.Write((byte)0);
				aWriter.Write(aType.AssemblyQualifiedName);
			}
		}

		public void OnBeforeSerialize()
		{
			if ((object)Type == null)
			{
				return;
			}
			using MemoryStream memoryStream = new MemoryStream();
			using BinaryWriter aWriter = new BinaryWriter(memoryStream);
			Write(aWriter, Type);
			_data = memoryStream.ToArray();
		}

		public void OnAfterDeserialize()
		{
			if (_data == null || _data.Length == 0)
			{
				return;
			}
			using MemoryStream input = new MemoryStream(_data);
			using BinaryReader aReader = new BinaryReader(input);
			Type = Read(aReader);
		}
	}
}
