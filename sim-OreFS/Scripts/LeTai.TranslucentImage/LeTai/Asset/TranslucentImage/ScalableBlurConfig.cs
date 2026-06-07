using UnityEngine;

namespace LeTai.Asset.TranslucentImage
{
	[CreateAssetMenu(fileName = "New Scalable Blur Config", menuName = "Translucent Image/ Scalable Blur Config", order = 100)]
	public class ScalableBlurConfig : BlurConfig
	{
		[SerializeField]
		[Tooltip("Blurriness. Does NOT affect performance")]
		private float radius = 4f;

		[SerializeField]
		[Tooltip("The number of times to run the algorithm to increase the smoothness of the effect. Can affect performance when increase")]
		[Range(0f, 8f)]
		private int iteration = 4;

		[SerializeField]
		[Tooltip("How strong the blur is")]
		private float strength;

		public float Radius
		{
			get
			{
				return radius;
			}
			set
			{
				radius = Mathf.Max(0f, value);
			}
		}

		public int Iteration
		{
			get
			{
				return iteration;
			}
			set
			{
				iteration = Mathf.Max(0, value);
			}
		}

		public override float Strength
		{
			get
			{
				return strength = Radius * Mathf.Pow(2f, Iteration);
			}
			set
			{
				strength = Mathf.Clamp(value, 0f, 268435460f);
				radius = Mathf.Sqrt(strength);
				iteration = 0;
				while ((float)(1 << iteration) < radius)
				{
					iteration++;
				}
				radius = strength / (float)(1 << iteration);
			}
		}
	}
}
