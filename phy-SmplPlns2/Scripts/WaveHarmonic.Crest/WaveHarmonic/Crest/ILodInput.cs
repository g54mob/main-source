using UnityEngine;
using UnityEngine.Rendering;
using WaveHarmonic.Crest.Utility;

namespace WaveHarmonic.Crest
{
	internal interface ILodInput
	{
		const int k_QueueMaximumSubIndex = 1000;

		bool Enabled { get; }

		bool IsCompute { get; }

		int Queue { get; }

		int Pass { get; }

		Rect Rect { get; }

		MonoBehaviour Component { get; }

		IReportsHeight HeightReporter => null;

		IReportsDisplacement DisplacementReporter => null;

		IReportWaveDisplacement WaveDisplacementReporter => null;

		int Order => Queue * 1000 + Mathf.Min(Component.transform.GetSiblingIndex(), 999);

		void Draw(Lod simulation, CommandBuffer buffer, RenderTargetIdentifier target, int pass = -1, float weight = 1f, int slice = -1);

		float Filter(WaterRenderer water, int slice);

		internal static void Attach(ILodInput input, SortedList<int, ILodInput> inputs)
		{
			inputs.Remove(input);
			inputs.Add(input.Order, input);
		}

		internal static void Detach(ILodInput input, SortedList<int, ILodInput> inputs)
		{
			inputs.Remove(input);
		}
	}
}
