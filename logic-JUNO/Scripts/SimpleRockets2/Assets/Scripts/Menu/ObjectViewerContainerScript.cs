using DG.Tweening;
using ModApi;
using UnityEngine;

namespace Assets.Scripts.Menu
{
	public class ObjectViewerContainerScript : MonoBehaviour
	{
		private bool _dragging;

		private float _exitDelay;

		public bool DestroyWhenFinished { get; set; }

		public GameObject PreviewObject { get; private set; }

		public void ExitPreviewScene()
		{
			if (_exitDelay > 0f)
			{
				DOTween.To(() => base.transform.localPosition, delegate(Vector3 p)
				{
					base.transform.localPosition = p;
				}, new Vector3(0f, 100f, 0f), 0.5f).SetEase(Ease.InOutCubic).OnComplete(delegate
				{
					OnExitFinished();
				});
			}
			else
			{
				OnExitFinished();
			}
		}

		public void Initialize(GameObject gameObject, ObjectViewerScript objectViewer, float delay, bool destroyWhenFinished)
		{
			PreviewObject = gameObject;
			DestroyWhenFinished = destroyWhenFinished;
			gameObject.transform.SetParent(base.transform, worldPositionStays: false);
			ScaleObject(gameObject);
			_exitDelay = delay;
			if (delay > 0f)
			{
				EnterPreviewScene(delay);
			}
		}

		public void OnDrag(Vector2 delta)
		{
			_dragging = true;
			base.transform.Rotate(new Vector3(delta.y, 0f - delta.x, 0f), Space.World);
		}

		public void OnEndDrag()
		{
			_dragging = false;
		}

		protected virtual void Start()
		{
		}

		protected virtual void Update()
		{
			if (!_dragging)
			{
				base.transform.Rotate(Vector3.up, 25f * Time.deltaTime, Space.Self);
			}
		}

		private void EnterPreviewScene(float delay)
		{
			base.transform.localPosition = new Vector3(0f, -100f, 0f);
			DOTween.To(() => base.transform.localPosition, delegate(Vector3 p)
			{
				base.transform.localPosition = p;
			}, Vector3.zero, 0.5f).SetEase(Ease.OutCubic).SetDelay(delay);
		}

		private void OnExitFinished()
		{
			base.gameObject.SetActive(value: false);
			if (DestroyWhenFinished)
			{
				Object.Destroy(base.gameObject);
			}
		}

		private void ScaleObject(GameObject target)
		{
			target.transform.localScale = Vector3.one;
			target.transform.SetLocalPositionAndRotation(Vector3.zero, Quaternion.identity);
			Bounds bounds = Utilities.CalculateBounds(target, includeSkinnedMeshRenderers: true);
			float num = Mathf.Max(bounds.extents.x, bounds.extents.y, bounds.extents.z) * 2f;
			float num2 = 25f / num;
			Vector3 vector = target.transform.InverseTransformPoint(bounds.center);
			IObjectViewerScale componentInChildren = target.GetComponentInChildren<IObjectViewerScale>();
			if (componentInChildren != null)
			{
				componentInChildren.ScaleObject(num2);
			}
			else
			{
				target.transform.localScale = new Vector3(num2, num2, num2);
			}
			target.transform.localPosition = -vector * target.transform.localScale.x;
		}
	}
}
