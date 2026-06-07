using MalbersAnimations.Scriptables;
using UnityEngine;

namespace MalbersAnimations
{
	[AddComponentMenu("Malbers/Input/Mouse World Position")]
	public class MouseToWorld : MonoBehaviour
	{
		[Tooltip("Reference to the camera")]
		public TransformReference MainCamera = new TransformReference();

		[Tooltip("Reference to the Mouse Point Transform")]
		public TransformReference MousePoint = new TransformReference();

		[Tooltip("Reference to the Mouse Point Transform")]
		public LayerReference layer = new LayerReference(-1);

		public QueryTriggerInteraction interaction;

		public FloatReference MaxDistance = new FloatReference(100f);

		[Tooltip("If the MousePoint Value is null set the value to this Transform")]
		public BoolReference SetOnNull = new BoolReference(value: true);

		private Camera m_camera;

		public Transform HitTransform { get; set; }

		public Vector3 TransformCenter { get; set; }

		private void Start()
		{
			if (MainCamera.Value == null)
			{
				m_camera = MTools.FindMainCamera();
				if ((bool)m_camera)
				{
					MainCamera = m_camera.transform;
				}
				else
				{
					Debug.LogWarning("There's no Main Camera on the Scene");
					base.enabled = false;
				}
			}
			else if (!MainCamera.Value.TryGetComponent<Camera>(out m_camera))
			{
				Debug.LogWarning("There's no Main Camera on the Scene");
				base.enabled = false;
			}
			if (MousePoint.Value == null)
			{
				MousePoint.Value = base.transform;
			}
		}

		private void Update()
		{
			if (SetOnNull.Value && MousePoint.Value == null)
			{
				MousePoint.Value = base.transform;
			}
			else if (MousePoint.Value != base.transform)
			{
				return;
			}
			Vector3 mousePosition = Input.mousePosition;
			if (Physics.Raycast(m_camera.ScreenPointToRay(mousePosition), out var hitInfo, MaxDistance, layer, interaction))
			{
				if (MousePoint.Value == null)
				{
					MousePoint.Value = base.transform;
				}
				MousePoint.Value.position = hitInfo.point;
				MDebug.DrawWireSphere(hitInfo.point, Quaternion.identity, Color.red, 0.02f);
			}
		}

		private void Reset()
		{
			MousePoint.Value = base.transform;
		}
	}
}
