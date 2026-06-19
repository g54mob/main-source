using UnityEngine;

namespace Water2D
{
	[ExecuteAlways]
	[RequireComponent(typeof(SpriteRenderer))]
	public class Parallax : MonoBehaviour
	{
		private SpriteRenderer _sr;

		private Camera _cam;

		[Space(10f)]
		[SerializeField]
		private int pixelsPerUnity;

		[SerializeField]
		private float offsetX;

		[SerializeField]
		private float offsetY;

		[SerializeField]
		private float width;

		[SerializeField]
		private float height;

		[Space(10f)]
		[SerializeField]
		private bool useSpeed;

		[SerializeField]
		private float speed;

		[SerializeField]
		private float minX;

		[SerializeField]
		private float maxX;

		[SerializeField]
		private Transform target;

		[SerializeField]
		private Gradient colorOverY;

		[SerializeField]
		private Texture2D spriteTexture;

		[Space(10f)]
		[SerializeField]
		[Range(0f, 20f)]
		private float gamma;

		[SerializeField]
		[Range(0f, 1f)]
		private float hardness;

		[SerializeField]
		[Range(0f, 0.01f)]
		private float area;

		[SerializeField]
		[Range(0f, 3f)]
		private float ratio;

		[SerializeField]
		[Range(2f, 16f)]
		private int quality;

		private SpriteRenderer sr
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		private Camera cam
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		private void OnEnable()
		{
		}

		private void Start()
		{
		}

		private void Update()
		{
		}

		private Material GetSpriteMateral()
		{
			return null;
		}

		private void SetupSprite()
		{
		}

		private void SetupShader()
		{
		}

		private void SetTransform()
		{
		}
	}
}
