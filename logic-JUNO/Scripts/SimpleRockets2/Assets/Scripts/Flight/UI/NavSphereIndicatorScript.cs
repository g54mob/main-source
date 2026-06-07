using ModApi.Flight.UI;
using UnityEngine;

namespace Assets.Scripts.Flight.UI
{
	public class NavSphereIndicatorScript : MonoBehaviour
	{
		private bool _highlighted;

		[SerializeField]
		private NavSphereIndicatorType _indicatorType;

		private MeshRenderer _mesh;

		[SerializeField]
		private string _name = string.Empty;

		private bool _selected;

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

		public NavSphereIndicatorType IndicatorType => _indicatorType;

		public string Name => _name;

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

		public Transform Transform => base.transform;

		public bool Visible => base.gameObject.activeSelf;

		protected virtual void Awake()
		{
			_mesh = GetComponent<MeshRenderer>();
		}

		private void UpdateMaterial()
		{
			float num = 0f;
			if (Highlighted)
			{
				num = 0.3f;
			}
			if (Selected)
			{
				num += 0.5f;
			}
			_mesh.material.SetFloat("_Highlight", num);
		}
	}
}
