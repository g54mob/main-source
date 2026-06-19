using System;
using System.Text;
using Unity.Entities.Serialization;

namespace Pug.ECS.Serialization.DOTS100
{
	internal struct StringTableWriterHandle : IDisposable
	{
		private DotsSerializationWriter.NodeHandle<Unity.Entities.Serialization.DotsSerialization.StringTableNode> _nodeHandle;

		private DotsSerializationWriter.DeferredWriterHandle<Unity.Entities.Serialization.DotsSerialization.StringTableNode> _writerHandle;

		public StringTableWriterHandle(DotsSerializationWriter.NodeHandle<Unity.Entities.Serialization.DotsSerialization.StringTableNode> handle)
		{
			_nodeHandle = handle;
			_nodeHandle.NodeHeader.StringCount = 0;
			_nodeHandle.Dispose();
			_writerHandle = _nodeHandle.GetDeferredWriteHandle();
		}

		public unsafe int WriteString(string str)
		{
			_nodeHandle.NodeHeader.StringCount++;
			byte[] bytes = Encoding.UTF8.GetBytes(str);
			fixed (byte* ptr = bytes)
			{
				void* data = ptr;
				int result = (int)_writerHandle.Writer.Position;
				_writerHandle.Writer.Write(bytes.Length);
				_writerHandle.Writer.WriteBytes(data, bytes.Length);
				return result;
			}
		}

		public void Dispose()
		{
			_writerHandle.Dispose();
		}
	}
}
