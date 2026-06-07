using System.Collections.Generic;
using Jundroo.Common.Utils;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers.Powertrain
{
	public class MeshSandwichScript : MonoBehaviour
	{
		[SerializeField]
		private float _centerOfMassY;

		[SerializeField]
		private GameObject[] _extraMeshes;

		private List<GameObject> _fillMeshes = new List<GameObject>();

		private float _fillMeshStartOffset;

		[SerializeField]
		private Transform _fillStretch;

		[SerializeField]
		private GameObject _meshBegin;

		[SerializeField]
		private GameObject _meshEnd;

		[SerializeField]
		private float _meshEndLength;

		[SerializeField]
		private GameObject _meshFill;

		[SerializeField]
		private float _meshFillOffset;

		[SerializeField]
		private float _oddIndexFillAngle;

		private PartMaterialScript _partMaterial;

		private List<MeshRenderer> _renderers = new List<MeshRenderer>();

		public Vector3 CenterOfMass => new Vector3(0f, _centerOfMassY, Length / 2f);

		public float Length { get; private set; }

		public int NumFillMeshes { get; set; }

		public virtual void BuildMeshes()
		{
			if (_partMaterial == null)
			{
				InitializeMeshes();
			}
			GameObject[] extraMeshes = _extraMeshes;
			foreach (GameObject meshGameObject in extraMeshes)
			{
				RegisterRenderers(meshGameObject);
			}
			_meshBegin.transform.SetLocalPositionAndRotation(Vector3.zero, Quaternion.identity);
			float num = _fillMeshStartOffset;
			foreach (GameObject fillMesh in _fillMeshes)
			{
				fillMesh.SetActive(value: false);
			}
			float num2 = 0f;
			for (int j = 0; j < NumFillMeshes; j++)
			{
				if (_fillMeshes.Count <= j)
				{
					GameObject gameObject = Object.Instantiate(_meshFill);
					gameObject.transform.SetParent(base.transform);
					RegisterRenderers(gameObject);
					_fillMeshes.Add(gameObject);
				}
				Quaternion localRotation = Quaternion.identity;
				if (j % 2 == 1)
				{
					localRotation = Quaternion.Euler(0f, 0f, _oddIndexFillAngle);
				}
				GameObject obj = _fillMeshes[j];
				obj.SetActive(value: true);
				obj.transform.SetLocalPositionAndRotation(new Vector3(0f, 0f, num), localRotation);
				obj.transform.localScale = Vector3.one;
				num += _meshFillOffset;
				num2 += _meshFillOffset;
			}
			if (_fillStretch != null)
			{
				_fillStretch.localScale = new Vector3(1f, 1f, num2);
			}
			_meshEnd.transform.SetLocalPositionAndRotation(new Vector3(0f, 0f, num), Quaternion.identity);
			num += _meshEndLength;
			Length = Mathf.Abs(num);
			_partMaterial.InitializeMaterial();
		}

		public void Destroy()
		{
			foreach (MeshRenderer renderer in _renderers)
			{
				_partMaterial.RemoveRenderer(renderer, destroy: true);
			}
			_renderers.Clear();
			Object.Destroy(base.gameObject);
		}

		public virtual void InitializeMeshes()
		{
			_partMaterial = GetComponentInParent<PartMaterialScript>(includeInactive: true);
			RegisterRenderers(_meshBegin);
			RegisterRenderers(_meshEnd);
			RegisterRenderers(_meshFill);
			if (_fillStretch != null)
			{
				RegisterRenderers(_fillStretch.gameObject);
			}
			_fillMeshes.Add(_meshFill);
			_fillMeshStartOffset = _meshFill.transform.localPosition.z;
		}

		protected void RegisterRenderers(GameObject meshGameObject)
		{
			MeshRenderer[] componentsInChildren = meshGameObject.GetComponentsInChildren<MeshRenderer>(includeInactive: true);
			foreach (MeshRenderer meshRenderer in componentsInChildren)
			{
				_renderers.Add(meshRenderer);
				_partMaterial.AddRenderer(meshRenderer);
			}
		}

		[ContextMenu("Auto Adjust")]
		private void AutoAdjustSizes()
		{
			_meshBegin.transform.localPosition = Vector3.zero;
			_meshFill.transform.localPosition = Vector3.zero;
			_meshEnd.transform.localPosition = Vector3.zero;
			Bounds bounds = Utilities.CalculateRendererBounds(_meshBegin);
			Bounds bounds2 = Utilities.CalculateRendererBounds(_meshFill);
			Bounds bounds3 = Utilities.CalculateRendererBounds(_meshEnd);
			_meshFill.transform.localPosition = new Vector3(0f, 0f, bounds.max.z);
			_meshFillOffset = bounds2.size.z / 2f;
			_meshEnd.transform.localPosition = _meshFill.transform.localPosition + new Vector3(0f, 0f, _meshFillOffset);
			_meshEndLength = bounds3.size.z;
			BuildMeshes();
		}
	}
}
