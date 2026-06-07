using UnityEngine;

namespace Assets.Scripts.Flight.UI
{
	public class NavSphereDiscScript : MonoBehaviour
	{
		private float _angle;

		[SerializeField]
		private GameObject _collider;

		[SerializeField]
		private SphereCollider _colliderSphere;

		[SerializeField]
		private NavSphereDiscType _discType;

		private bool _flipped;

		private bool _hidden;

		private bool _hiddenAlt;

		private bool _highlighted;

		private bool _locked;

		[SerializeField]
		private GameObject _markings;

		[SerializeField]
		private GameObject _markingsAlt;

		[SerializeField]
		private MeshRenderer _mesh;

		[SerializeField]
		private Transform _rootTransform;

		private bool _selected;

		private Quaternion _targetRotation;

		private bool _usePlaneIntersection;

		public float Angle
		{
			get
			{
				return _angle;
			}
			set
			{
				_angle = value;
				if (_discType == NavSphereDiscType.Pitch)
				{
					_targetRotation = Quaternion.Euler(value, 0f, 0f);
				}
				else
				{
					_targetRotation = Quaternion.Euler(0f, 0f, value);
				}
				if (_selected)
				{
					_rootTransform.localRotation = _targetRotation;
				}
			}
		}

		public bool ColliderEnabled
		{
			get
			{
				return _collider.activeSelf;
			}
			set
			{
				_collider.SetActive(value);
			}
		}

		public NavSphereDiscType DiscType => _discType;

		public bool Flipped
		{
			get
			{
				return _flipped;
			}
			set
			{
				_flipped = value;
				if (_flipped)
				{
					_mesh.transform.localRotation = Quaternion.Euler(0f, 0f, 180f);
				}
				else
				{
					_mesh.transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
				}
			}
		}

		public bool Hidden
		{
			set
			{
				_hidden = value;
				UpdateMaterial();
			}
		}

		public bool HiddenAlt
		{
			set
			{
				_hiddenAlt = value;
			}
		}

		public bool Highlighted
		{
			get
			{
				return _highlighted;
			}
			set
			{
				_highlighted = value;
				UpdateMaterial();
			}
		}

		public bool Locked
		{
			get
			{
				return _locked;
			}
			set
			{
				_locked = value;
				UpdateMaterial();
			}
		}

		public bool Selected
		{
			get
			{
				return _selected;
			}
			set
			{
				_selected = value;
				UpdateMaterial();
			}
		}

		public void Animate(float deltaTime)
		{
			_rootTransform.localRotation = Quaternion.Lerp(_rootTransform.localRotation, _targetRotation, 5f * deltaTime);
		}

		public bool CalculateRayIntersectionAngle(Ray ray, out float angle, bool initialRayCast)
		{
			angle = 0f;
			bool result = false;
			if (initialRayCast)
			{
				float f = Vector3.Dot(ray.direction, base.transform.up);
				_usePlaneIntersection = Mathf.Abs(f) > 0.2f;
			}
			if (_usePlaneIntersection)
			{
				Plane plane = new Plane(base.transform.up, base.transform.position);
				float enter = 0f;
				if (plane.Raycast(ray, out enter))
				{
					Vector3 point = ray.GetPoint(enter);
					Vector3 vector = base.transform.InverseTransformPoint(point);
					float num = Mathf.Atan2(vector.x, vector.z) * 57.29578f;
					angle = num;
					result = true;
				}
			}
			else
			{
				_colliderSphere.gameObject.SetActive(value: true);
				if (_colliderSphere.Raycast(ray, out var hitInfo, 10000f))
				{
					Vector3 vector2 = base.transform.InverseTransformPoint(hitInfo.point);
					float num2 = Mathf.Atan2(vector2.x, vector2.z) * 57.29578f;
					angle = num2;
					result = true;
				}
				_colliderSphere.gameObject.SetActive(value: false);
			}
			return result;
		}

		public void HideMarkings()
		{
			_markings.SetActive(value: false);
			_markingsAlt.SetActive(value: false);
		}

		public void SetCameraDistance(float distance)
		{
			_mesh.material.SetFloat("_Distance", 15f);
		}

		public void ShowMarkings(Vector3 viewDirection)
		{
			_markings.SetActive(value: true);
			_markingsAlt.SetActive(!_hiddenAlt);
			if (DiscType == NavSphereDiscType.Pitch)
			{
				if (Vector3.Dot(viewDirection, base.transform.up) > 0f)
				{
					_markings.transform.localRotation = Quaternion.Euler(0f, 90f, 0f);
				}
				else
				{
					_markings.transform.localRotation = Quaternion.Euler(180f, 90f, 0f);
				}
			}
		}

		protected virtual void Start()
		{
			_colliderSphere.gameObject.SetActive(value: false);
			_mesh.material = _mesh.sharedMaterial;
			_markings.SetActive(value: false);
			_markingsAlt.SetActive(value: false);
			UpdateMaterial();
		}

		private void UpdateMaterial()
		{
			if (_hidden)
			{
				_mesh.material.SetFloat("_Opacity", 0f);
			}
			else if (Locked)
			{
				_mesh.material.SetFloat("_Opacity", 0.6f);
			}
			else
			{
				_mesh.material.SetFloat("_Opacity", 0.2f);
			}
			float value = 0f;
			if (Selected)
			{
				value = 1f;
			}
			else if (Highlighted)
			{
				value = 0.2f;
			}
			_mesh.material.SetFloat("_Highlight", value);
		}
	}
}
