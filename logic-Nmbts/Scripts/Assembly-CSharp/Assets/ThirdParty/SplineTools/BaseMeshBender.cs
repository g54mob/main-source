using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.ThirdParty.SplineTools
{
	[SelectionBase]
	[ExecuteInEditMode]
	[RequireComponent(typeof(Spline))]
	public class BaseMeshBender : MonoBehaviour
	{
		public Mesh TextureMesh;

		public Material TextureMaterial;

		public EUvStretchMode UvMode;

		public float ScaleX;

		[HideInInspector]
		public bool ToUpdate;

		[HideInInspector]
		public Spline OwnSpline;

		private List<GameObject> _meshes = new List<GameObject>();

		public void OnEnable()
		{
			OwnSpline = GetComponent<Spline>();
			ToUpdate = true;
		}

		protected void OnValidate()
		{
			ToUpdate = true;
		}

		public virtual void Update()
		{
			if (base.transform.hasChanged)
			{
				ToUpdate = true;
			}
			if (ToUpdate)
			{
				base.transform.hasChanged = false;
				ToUpdate = false;
				if (TextureMesh != null)
				{
					CreateMesh(TextureMesh);
				}
			}
		}

		public void CreateMesh(Mesh mesh)
		{
			ClearMeshes();
			foreach (CubicBezierCurve curf in OwnSpline.curves)
			{
				GameObject gameObject = new GameObject(base.gameObject.name + " Generated", typeof(MeshFilter), typeof(MeshRenderer), typeof(MeshBender), typeof(Rigidbody));
				gameObject.transform.parent = base.transform;
				gameObject.transform.localPosition = Vector3.zero;
				gameObject.transform.localRotation = Quaternion.identity;
				gameObject.transform.localScale = Vector3.one;
				gameObject.hideFlags = HideFlags.NotEditable;
				gameObject.hideFlags = HideFlags.DontSave;
				gameObject.GetComponent<MeshRenderer>().material = TextureMaterial;
				gameObject.GetComponent<Rigidbody>().isKinematic = true;
				gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
				MeshBender component = gameObject.GetComponent<MeshBender>();
				component.SetSourceMesh(mesh, false);
				component.SetRotation(Quaternion.Euler(Vector3.zero), false);
				component.SetCurve(curf, false);
				component.SetUvMode(UvMode, false);
				component.SetStartScale(ScaleX, false);
				component.SetEndScale(ScaleX);
				_meshes.Add(gameObject);
				OnMeshCreated(gameObject, curf);
			}
		}

		private void ClearMeshes()
		{
			foreach (GameObject item in _meshes.ToList())
			{
				SafeDelete(item);
			}
			_meshes.Clear();
		}

		private void SafeDelete(GameObject go)
		{
			if (go != null)
			{
				if (Application.isEditor)
				{
					Object.DestroyImmediate(go);
				}
				else
				{
					Object.Destroy(go);
				}
			}
		}

		public virtual void OnMeshCreated(GameObject go, CubicBezierCurve curve)
		{
		}
	}
}
