using System.Reflection;

namespace GUPS.EasyPerformanceMonitor.Renderer
{
	[Obfuscation(Exclude = true)]
	public class NormalizedMultiGraphRenderer : ColoredMultiGraphRenderer
	{
		private float[] FlattenAndScaleArray(float[,] _Array)
		{
			float[] array = new float[_Array.GetLength(0) * _Array.GetLength(1)];
			for (int i = 0; i < _Array.GetLength(0); i++)
			{
				for (int j = 0; j < _Array.GetLength(1); j++)
				{
					float num = 0f;
					for (int k = 0; k < _Array.GetLength(0); k++)
					{
						num += _Array[k, j];
					}
					num = ((num == 0f) ? 1f : num);
					float num2 = _Array[i, j] / num;
					num2 = ((num2 < 0.02f) ? 0.02f : num2);
					array[i * _Array.GetLength(1) + j] = num2;
				}
			}
			return array;
		}

		protected override void UpdateGraph()
		{
			base.Target.material.SetFloatArray(AGraphRenderer.ValuesPropertyId, FlattenAndScaleArray(base.Values));
		}
	}
}
