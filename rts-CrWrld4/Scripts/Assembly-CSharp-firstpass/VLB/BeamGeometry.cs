using UnityEngine;
using UnityEngine.Rendering;

namespace VLB
{
	[ExecuteInEditMode]
	public class BeamGeometry : MonoBehaviour
	{
		private VolumetricLightBeam m_Master;

		private Matrix4x4 m_ColorGradientMatrix;

		private MeshType m_CurrentMeshType;

		public MeshRenderer meshRenderer { get; private set; }

		public MeshFilter meshFilter { get; private set; }

		public Material material { get; private set; }

		public Mesh coneMesh { get; private set; }

		public bool visible
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public int sortingLayerID
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public int sortingOrder
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		private void Start()
		{
		}

		private void OnDestroy()
		{
		}

		private static bool IsUsingCustomRenderPipeline()
		{
			return false;
		}

		private void OnEnable()
		{
		}

		private void OnDisable()
		{
		}

		public void Initialize(VolumetricLightBeam master, Shader shader)
		{
		}

		public void RegenerateMesh()
		{
		}

		private void ComputeLocalMatrix()
		{
		}

		public void UpdateMaterialAndBounds()
		{
		}

		public void SetClippingPlane(Plane planeWS)
		{
		}

		public void SetClippingPlaneOff()
		{
		}

		private void OnBeginCameraRendering(ScriptableRenderContext context, Camera cam)
		{
		}

		private void OnWillRenderObject()
		{
		}

		private void UpdateCameraRelatedProperties(Camera cam)
		{
		}
	}
}
