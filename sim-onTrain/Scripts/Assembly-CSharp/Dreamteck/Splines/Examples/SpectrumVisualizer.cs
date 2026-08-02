using UnityEngine;

namespace Dreamteck.Splines.Examples
{
	public class SpectrumVisualizer : MonoBehaviour
	{
		public int samples = 1024;

		[Tooltip("The starting percent of the spectrum. 0 is 20Hz and 1 is 20KHz")]
		[Range(0f, 1f)]
		public float minSpectrumRange;

		[Tooltip("The ending percent of the spectrum. 0 is 20Hz and 1 is 20KHz")]
		[Range(0f, 1f)]
		public float maxSpectrumRange = 1f;

		public float increaseSpeed = 50f;

		public float decreaseSpeed = 10f;

		public float maxOffset = 10f;

		public AudioSource source;

		private SplineComputer computer;

		private Vector3[] positions;

		public AnimationCurve spectrumMultiply;

		private float[] spectrumLerp;

		private void Start()
		{
			if (source == null)
			{
				source = GetComponent<AudioSource>();
			}
			computer = GetComponent<SplineComputer>();
			SplinePoint[] points = computer.GetPoints();
			positions = new Vector3[points.Length];
			for (int i = 0; i < points.Length; i++)
			{
				positions[i] = points[i].position;
			}
			spectrumLerp = new float[points.Length];
		}

		private void Update()
		{
			float[] array = new float[samples];
			float[] array2 = new float[samples];
			source.GetSpectrumData(array, 0, FFTWindow.Hanning);
			source.GetSpectrumData(array2, 1, FFTWindow.Hanning);
			float[] array3 = new float[array.Length];
			for (int i = 0; i < array3.Length; i++)
			{
				array3[i] = (array[i] + array2[i]) / 2f;
			}
			SplinePoint[] points = computer.GetPoints();
			int num = Mathf.FloorToInt((float)(array3.Length / points.Length) * (maxSpectrumRange - minSpectrumRange));
			int num2 = Mathf.FloorToInt((float)(array3.Length - 1) * minSpectrumRange);
			for (int j = 0; j < points.Length; j++)
			{
				float num3 = 0f;
				for (int k = 0; k < num; k++)
				{
					num3 += array3[num2 + num * j + k];
				}
				num3 /= (float)num;
				if (num3 > spectrumLerp[j])
				{
					spectrumLerp[j] = Mathf.Lerp(spectrumLerp[j], num3, Time.deltaTime * increaseSpeed);
				}
				else
				{
					spectrumLerp[j] = Mathf.Lerp(spectrumLerp[j], num3, Time.deltaTime * decreaseSpeed);
				}
				float time = (float)j / (float)(points.Length - 1);
				points[j].position = positions[j] + Vector3.up * maxOffset * spectrumLerp[j] * spectrumMultiply.Evaluate(time);
			}
			computer.SetPoints(points);
		}
	}
}
