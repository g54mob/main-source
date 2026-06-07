using UnityEngine;
using UnityEngine.UI;

namespace VampireSurvivors
{
	[RequireComponent(typeof(CanvasRenderer))]
	[ExecuteAlways]
	public class UIMeshRenderer : MonoBehaviour
	{
		public Material Material;

		[SerializeField]
		private Mesh mesh;

		[SerializeField]
		private bool mask;

		[SerializeField]
		private bool showMaskGraphic;

		[SerializeField]
		private bool maskable;

		[SerializeField]
		private bool preserveAspect;

		private CanvasRenderer canvasRenderer;

		private Image[] childImage;

		private Vector3[] baseVertices;

		private RectTransform rect;

		private float cachedHeight;

		private float cachedWidth;

		private void Start()
		{
		}

		private void SetupMesh()
		{
		}

		private void Update()
		{
		}

		private void OnEnable()
		{
		}

		private void OnDisable()
		{
		}

		private Mesh CreateNewMesh()
		{
			return null;
		}

		private void SetStencilSelf()
		{
		}

		private void SetMaskableSelf()
		{
		}

		private void SetStencilChildren(Image[] images)
		{
		}

		private void OnValidate()
		{
		}
	}
}
