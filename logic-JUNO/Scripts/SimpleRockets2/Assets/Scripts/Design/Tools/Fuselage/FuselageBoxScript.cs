using ModApi;
using UnityEngine;

namespace Assets.Scripts.Design.Tools.Fuselage
{
	public class FuselageBoxScript : MonoBehaviour
	{
		private Material _material;

		private bool _selected;

		private float _startAlpha;

		public bool IsSelected
		{
			get
			{
				return _selected;
			}
			set
			{
				_selected = value;
				Color gamma = Constants.Colors.Primary.Gamma;
				if (_selected)
				{
					gamma.a = 0.5f;
				}
				else
				{
					gamma.a = _startAlpha;
				}
				base.transform.GetChild(4).gameObject.SetActive(value);
				base.transform.GetChild(5).gameObject.SetActive(value);
				_material.color = gamma;
			}
		}

		public void SetSize(Vector2 size)
		{
			base.transform.GetChild(0).localScale = new Vector3(0.05f, size.y * 2f - 0.05f, 1f);
			base.transform.GetChild(1).localScale = new Vector3(0.05f, size.y * 2f - 0.05f, 1f);
			base.transform.GetChild(2).localScale = new Vector3(0.05f, size.x * 2f + 0.05f, 1f);
			base.transform.GetChild(3).localScale = new Vector3(0.05f, size.x * 2f + 0.05f, 1f);
			base.transform.GetChild(0).localPosition = new Vector3(size.x, 0f, 0f);
			base.transform.GetChild(1).localPosition = new Vector3(0f - size.x, 0f, 0f);
			base.transform.GetChild(2).localPosition = new Vector3(0f, 0f, size.y);
			base.transform.GetChild(3).localPosition = new Vector3(0f, 0f, 0f - size.y);
			BoxCollider component = GetComponent<BoxCollider>();
			if (size.x > 0f && size.y > 0f)
			{
				component.size = new Vector3(size.x * 2f, 0.01f, size.y * 2f);
				component.enabled = true;
			}
			else
			{
				component.enabled = false;
			}
		}

		protected virtual void Awake()
		{
			_material = base.transform.GetChild(0).GetComponent<MeshRenderer>().material;
			_startAlpha = _material.color.a;
			MeshRenderer[] componentsInChildren = GetComponentsInChildren<MeshRenderer>(includeInactive: true);
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				componentsInChildren[i].material = _material;
			}
		}

		protected virtual void OnDestroy()
		{
			if (_material != null)
			{
				Object.Destroy(_material);
				_material = null;
			}
		}
	}
}
