using Pathfinding.Serialization;

namespace Pathfinding
{
	public interface IGraphInternals
	{
		string SerializedEditorSettings { get; set; }

		void OnDestroy();

		void DisposeUnmanagedData();

		void DestroyAllNodes();

		IGraphUpdatePromise ScanInternal(bool async);

		void SerializeExtraInfo(GraphSerializationContext ctx);

		void DeserializeExtraInfo(GraphSerializationContext ctx);

		void PostDeserialization(GraphSerializationContext ctx);
	}
}
