using System;
using System.Collections.Generic;
using Factory;

namespace Server
{
	public class ModelFrameSerializer : PrimitiveSerializer
	{
		private Dictionary<Type, ISerializer> _frameSerializers = new Dictionary<Type, ISerializer>();

		public override bool Serialize(object obj, ExportContext context)
		{
			ISerializer frameSerializer = GetFrameSerializer(obj);
			if (frameSerializer == null)
			{
				return true;
			}
			int num = 0;
			if (context.Scope != null)
			{
				num = context.Scope.Get<Clock>().ModelFrameIndex;
			}
			return frameSerializer.Serialize((obj as Array).GetValue(1 - num), context);
		}

		public override object Deserialize(object existingObj, ImportContext context)
		{
			ISerializer frameSerializer = GetFrameSerializer(existingObj);
			if (frameSerializer == null)
			{
				return existingObj;
			}
			Array obj = existingObj as Array;
			IFrame frame = obj.GetValue(0) as IFrame;
			IFrame cloneState = obj.GetValue(1) as IFrame;
			frameSerializer.Deserialize(frame, context);
			frame.CloneInto(cloneState, context.Scope);
			return existingObj;
		}

		private ISerializer GetFrameSerializer(object stateArrayObj)
		{
			Type elementType = stateArrayObj.GetType().GetElementType();
			if (_frameSerializers.TryGetValue(elementType, out var value))
			{
				return value;
			}
			if (elementType != typeof(EmptyModelFrame))
			{
				value = new CompositeSerializer(elementType);
			}
			_frameSerializers[elementType] = value;
			return value;
		}
	}
}
