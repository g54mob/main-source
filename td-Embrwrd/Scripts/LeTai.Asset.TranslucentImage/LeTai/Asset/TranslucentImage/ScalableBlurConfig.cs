using UnityEngine;

namespace LeTai.Asset.TranslucentImage
{
	[CreateAssetMenu(fileName = "New Scalable Blur Config", menuName = "Translucent Image/ Scalable Blur Config", order = 100)]
	public class ScalableBlurConfig : BlurConfig
	{
		public enum BlurMode
		{
			Performance = 0,
			Balanced = 1
		}

		[Tooltip("Use Balanced for light to medium blur or detailed background, Performance for strong blur, smooth background or very low end hardware")]
		[SerializeField]
		private BlurMode mode;

		[SerializeField]
		[Tooltip("Blurriness. Does NOT affect performance")]
		private float radius;

		[SerializeField]
		[Tooltip("The number of times to run the algorithm to increase the smoothness of the effect. Can affect performance when increase")]
		[Range(0f, 8f)]
		private int iteration;

		[Tooltip("How strong the blur is")]
		[SerializeField]
		private float strength;

		[SerializeField]
		[Tooltip("Resolution the blur strength is designed for. If the camera resolution is larger, the blur will be stronger, and if it's smaller, the blur will be weaker.")]
		private Vector2 referenceResolution;

		[SerializeField]
		[Tooltip("0 = Match width, 1 = Match height, choose depend on how your camera viewport change with resolution. By default, vertical viewport is constant so we should match width")]
		[Range(0f, 1f)]
		private float matchWidthOrHeight;

		[SerializeField]
		private bool useStrength;

		public BlurMode Mode
		{
			get
			{
				return default(BlurMode);
			}
			set
			{
			}
		}

		public float Radius
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public int Iteration
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public override float Strength
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public bool UseStrength
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public Vector2 ReferenceResolution
		{
			get
			{
				return default(Vector2);
			}
			set
			{
			}
		}

		public float MatchWidthOrHeight
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		internal float GetResolutionScaleFactor(float width, float height)
		{
			return 0f;
		}

		internal static (float, int) FromStrength(float targetStrength)
		{
			return default((float, int));
		}
	}
}
