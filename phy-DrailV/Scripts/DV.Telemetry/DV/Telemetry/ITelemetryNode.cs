using System;
using System.Collections.Generic;

namespace DV.Telemetry
{
	public interface ITelemetryNode
	{
		ITelemetryNode Parent { get; set; }

		int BufferLength { get; }

		void RecordFrame();

		void ResetPosition(int index, int count);

		void RegisterChild(ITelemetryNode child);

		void UnregisterChild(ITelemetryNode child);

		void ClearChildren();

		void FillColumnData(string titlePrefix, List<string> columnTitle, List<TelemetryDataField> columnField, List<int> columnIndex, List<Array> sourceArray);

		void SetSuspended(bool suspended);

		void CacheNames();

		void AllocateBuffers();

		void ReleaseBuffers();
	}
}
