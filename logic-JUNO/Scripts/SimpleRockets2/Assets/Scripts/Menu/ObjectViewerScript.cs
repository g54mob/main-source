using Assets.Scripts.Terrain.Rendering;
using ModApi.Common.Events;
using ModApi.Ui;
using UnityEngine;

namespace Assets.Scripts.Menu
{
	public class ObjectViewerScript : MonoBehaviour, IListViewObjectViewer
	{
		[SerializeField]
		private Camera _camera;

		private QuadSphereRenderer _fakeQuadsphereRenderer;

		[SerializeField]
		private Light _light;

		[SerializeField]
		private Transform _objectsRoot;

		public Camera Camera => _camera;

		public ObjectViewerContainerScript CurrentObject { get; private set; }

		public bool DestroyWhenFinished
		{
			get
			{
				return CurrentObject.DestroyWhenFinished;
			}
			set
			{
				CurrentObject.DestroyWhenFinished = value;
			}
		}

		public Light Light => _light;

		public void OnDrag(Vector2 delta)
		{
			CurrentObject.OnDrag(delta);
		}

		public void OnEndDrag()
		{
			CurrentObject.OnEndDrag();
		}

		public void PreviewObject(GameObject previewObject, float delay = 0f, bool destroyWhenFinished = true, Vector3? containerRotation = null)
		{
			if (CurrentObject != null)
			{
				if (CurrentObject.PreviewObject == previewObject)
				{
					return;
				}
				CurrentObject.ExitPreviewScene();
				CurrentObject = null;
			}
			if (previewObject != null)
			{
				_fakeQuadsphereRenderer?.RefreshDataAndUpdateRenderer();
				GameObject gameObject = new GameObject("ObjectContainer");
				gameObject.transform.SetParent(_objectsRoot, worldPositionStays: false);
				gameObject.transform.localScale = Vector3.one;
				gameObject.transform.localPosition = Vector3.zero;
				if (containerRotation.HasValue)
				{
					gameObject.transform.localRotation = Quaternion.Euler(containerRotation.Value);
				}
				CurrentObject = gameObject.AddComponent<ObjectViewerContainerScript>();
				CurrentObject.Initialize(previewObject, this, delay, destroyWhenFinished);
			}
		}

		public void Show(bool show)
		{
			if (show)
			{
				base.gameObject.SetActive(value: true);
				return;
			}
			PreviewObject(null);
			UnityEventDispatcher.Instance.ExecuteYield<WaitForEndOfFrame>(delegate
			{
				base.gameObject.SetActive(value: false);
			});
		}

		protected virtual void Awake()
		{
			_fakeQuadsphereRenderer = QuadSphereRenderer.CreateWithoutQuadsphere(base.gameObject, Vector3.zero, Camera.transform, Light.transform);
		}

		protected virtual void LateUpdate()
		{
			if (CurrentObject != null)
			{
				_fakeQuadsphereRenderer.UpdateRenderer();
			}
		}
	}
}
