using UnityEngine;

namespace ModApi.Craft.Parts
{
	public class AttachPointScript : MonoBehaviour
	{
		private Color _color;

		private bool _flipVisuals;

		private Material _material;

		private MeshRenderer _meshRenderer;

		private bool _visible = true;

		public AttachPoint AttachPoint { get; private set; }

		public int ConnectToLayer { get; private set; }

		public bool FlipVisuals
		{
			get
			{
				return _flipVisuals;
			}
			set
			{
				if (_flipVisuals == value)
				{
					return;
				}
				_flipVisuals = value;
				if (_meshRenderer != null)
				{
					if (_flipVisuals)
					{
						_meshRenderer.transform.localRotation = Quaternion.Euler(180f, 0f, 0f);
					}
					else
					{
						_meshRenderer.transform.localRotation = Quaternion.identity;
					}
				}
			}
		}

		public IPartScript PartScript { get; private set; }

		public bool Visible
		{
			get
			{
				return _visible;
			}
			set
			{
				if (_visible != value)
				{
					_visible = value;
					if (_meshRenderer != null)
					{
						_meshRenderer.gameObject.SetActive(value);
					}
				}
			}
		}

		public Vector3 WorldJointAxis => base.transform.TransformDirection(AttachPoint.LocalJointAxis);

		public Vector3 WorldNormal => base.transform.forward;

		public Vector3 WorldSecondaryJointAxis => base.transform.up;

		public void Initialize(AttachPoint attachPoint, IPartScript partScript, Color color)
		{
			attachPoint.AttachPointScript = this;
			AttachPoint = attachPoint;
			PartScript = partScript;
			UpdateLayer();
			_meshRenderer = GetComponentInChildren<MeshRenderer>();
			_color = color;
			Visible = false;
			if (_meshRenderer != null)
			{
				_material = _meshRenderer.material;
			}
			AttachPoint.EnabledChanged += OnAttachPointEnabledChanged;
			if (!AttachPoint.Enabled)
			{
				UpdateEnabledState();
			}
		}

		public void RestoreColor()
		{
			if (_material != null)
			{
				_material.SetColor("_Color", _color);
				_material.renderQueue = 3000;
			}
		}

		public void SetColor(Color color)
		{
			if (_material != null)
			{
				_material.SetColor("_Color", color);
				_material.renderQueue = 3001;
			}
		}

		public void UpdateLayer()
		{
			if (AttachPoint.IsSurfaceAttachPoint)
			{
				base.gameObject.layer = 13;
				ConnectToLayer = 13;
			}
			else if (AttachPoint.CanReceive)
			{
				base.gameObject.layer = 12;
				ConnectToLayer = 12;
			}
			else
			{
				base.gameObject.layer = 14;
				ConnectToLayer = 12;
			}
		}

		protected virtual void OnDestroy()
		{
			if (_material != null)
			{
				Object.Destroy(_material);
			}
		}

		protected virtual void Start()
		{
			RestoreColor();
		}

		private void OnAttachPointEnabledChanged(AttachPoint attachPoint)
		{
			UpdateEnabledState();
		}

		private void UpdateEnabledState()
		{
			if (!AttachPoint.IsSurfaceAttachPoint)
			{
				GetComponent<Collider>().enabled = AttachPoint.Enabled;
			}
		}
	}
}
