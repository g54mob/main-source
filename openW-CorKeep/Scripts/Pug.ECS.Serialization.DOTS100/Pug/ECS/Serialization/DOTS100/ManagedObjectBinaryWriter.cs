using System;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Serialization.Binary;
using UnityEngine;

namespace Pug.ECS.Serialization.DOTS100
{
	internal class ManagedObjectBinaryWriter : IContravariantBinaryAdapter<UnityEngine.Object>, IBinaryAdapter, IBinaryAdapter<AnimationCurve>
	{
		private static readonly UnityEngine.Object[] s_EmptyUnityObjectTable = new UnityEngine.Object[0];

		private unsafe readonly UnsafeAppendBuffer* m_Stream;

		private readonly BinarySerializationParameters m_Params;

		private List<UnityEngine.Object> m_UnityObjects;

		private Dictionary<UnityEngine.Object, int> m_UnityObjectsMap;

		public unsafe ManagedObjectBinaryWriter(UnsafeAppendBuffer* stream)
		{
			m_Stream = stream;
			m_Params = new BinarySerializationParameters
			{
				UserDefinedAdapters = new List<IBinaryAdapter> { this },
				State = new BinarySerializationState()
			};
		}

		public void AddAdapter(IBinaryAdapter adapter)
		{
			m_Params.UserDefinedAdapters.Add(adapter);
		}

		public UnityEngine.Object[] GetUnityObjects()
		{
			return m_UnityObjects?.ToArray() ?? s_EmptyUnityObjectTable;
		}

		public unsafe void WriteObject(object obj)
		{
			BinarySerializationParameters parameters = m_Params;
			parameters.SerializedType = obj?.GetType();
			BinarySerialization.ToBinary(m_Stream, obj, parameters);
		}

		unsafe void IContravariantBinaryAdapter<UnityEngine.Object>.Serialize(IBinarySerializationContext context, UnityEngine.Object value)
		{
			int value2 = -1;
			if (value != null)
			{
				if (m_UnityObjects == null)
				{
					m_UnityObjects = new List<UnityEngine.Object>();
				}
				if (m_UnityObjectsMap == null)
				{
					m_UnityObjectsMap = new Dictionary<UnityEngine.Object, int>();
				}
				if (!m_UnityObjectsMap.TryGetValue(value, out value2))
				{
					value2 = m_UnityObjects.Count;
					m_UnityObjectsMap.Add(value, value2);
					m_UnityObjects.Add(value);
				}
			}
			context.Writer->Add(value2);
		}

		object IContravariantBinaryAdapter<UnityEngine.Object>.Deserialize(IBinaryDeserializationContext context)
		{
			throw new InvalidOperationException("Deserialize should never be invoked by ManagedObjectBinaryWriter");
		}

		unsafe void IBinaryAdapter<AnimationCurve>.Serialize(in BinarySerializationContext<AnimationCurve> context, AnimationCurve value)
		{
			if (value != null)
			{
				context.Writer->Add(value.length);
				context.Writer->Add(value.preWrapMode);
				context.Writer->Add(value.postWrapMode);
				int i = 0;
				for (int length = value.length; i < length; i++)
				{
					context.Writer->Add((SerializedKeyFrame)value[i]);
				}
			}
			else
			{
				context.Writer->Add(-1);
			}
		}

		AnimationCurve IBinaryAdapter<AnimationCurve>.Deserialize(in BinaryDeserializationContext<AnimationCurve> context)
		{
			throw new InvalidOperationException("Deserialize should never be invoked by ManagedObjectBinaryWriter");
		}
	}
}
