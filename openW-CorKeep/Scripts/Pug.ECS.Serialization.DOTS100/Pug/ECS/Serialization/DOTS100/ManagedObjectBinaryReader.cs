using System;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Serialization.Binary;
using UnityEngine;

namespace Pug.ECS.Serialization.DOTS100
{
	internal class ManagedObjectBinaryReader : IContravariantBinaryAdapter<UnityEngine.Object>, IBinaryAdapter, IBinaryAdapter<AnimationCurve>
	{
		private unsafe readonly UnsafeAppendBuffer.Reader* m_Stream;

		private readonly BinarySerializationParameters m_Params;

		private readonly UnityEngine.Object[] m_UnityObjects;

		public unsafe ManagedObjectBinaryReader(UnsafeAppendBuffer.Reader* stream, UnityEngine.Object[] unityObjects)
		{
			m_Stream = stream;
			m_Params = new BinarySerializationParameters
			{
				UserDefinedAdapters = new List<IBinaryAdapter> { this },
				State = new BinarySerializationState()
			};
			m_UnityObjects = unityObjects;
		}

		public void AddAdapter(IBinaryAdapter adapter)
		{
			m_Params.UserDefinedAdapters.Add(adapter);
		}

		public unsafe object ReadObject(Type type)
		{
			BinarySerializationParameters parameters = m_Params;
			parameters.SerializedType = type;
			return BinarySerialization.FromBinary<object>(m_Stream, parameters);
		}

		void IContravariantBinaryAdapter<UnityEngine.Object>.Serialize(IBinarySerializationContext context, UnityEngine.Object value)
		{
			throw new InvalidOperationException("Serialize should never be invoked by ManagedObjectBinaryReader.");
		}

		unsafe object IContravariantBinaryAdapter<UnityEngine.Object>.Deserialize(IBinaryDeserializationContext context)
		{
			int num = context.Reader->ReadNext<int>();
			if (num == -1)
			{
				return null;
			}
			if (m_UnityObjects == null)
			{
				throw new ArgumentException("We are reading a UnityEngine.Object however no ObjectTable was provided to the ManagedObjectBinaryReader.");
			}
			if ((uint)num >= m_UnityObjects.Length)
			{
				throw new ArgumentException("We are reading a UnityEngine.Object but the deserialized index is out of range for the given object table.");
			}
			return m_UnityObjects[num];
		}

		void IBinaryAdapter<AnimationCurve>.Serialize(in BinarySerializationContext<AnimationCurve> context, AnimationCurve value)
		{
			throw new InvalidOperationException("Serialize should never be invoked by ManagedObjectBinaryReader.");
		}

		unsafe AnimationCurve IBinaryAdapter<AnimationCurve>.Deserialize(in BinaryDeserializationContext<AnimationCurve> context)
		{
			int num = context.Reader->ReadNext<int>();
			if (num >= 0)
			{
				WrapMode preWrapMode = context.Reader->ReadNext<WrapMode>();
				WrapMode postWrapMode = context.Reader->ReadNext<WrapMode>();
				AnimationCurve animationCurve = new AnimationCurve
				{
					preWrapMode = preWrapMode,
					postWrapMode = postWrapMode
				};
				for (int i = 0; i < num; i++)
				{
					animationCurve.AddKey(context.Reader->ReadNext<SerializedKeyFrame>());
				}
				return animationCurve;
			}
			return null;
		}
	}
}
