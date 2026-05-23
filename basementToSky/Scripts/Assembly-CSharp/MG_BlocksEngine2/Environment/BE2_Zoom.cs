using MG_BlocksEngine2.Block;
using MG_BlocksEngine2.Core;
using UnityEngine;

namespace MG_BlocksEngine2.Environment
{
	public class BE2_Zoom : MonoBehaviour
	{
		public float startSize = 1f;

		public float minSize = 0.1f;

		public float maxSize = 7f;

		public float zoomRate = 1.3f;

		private Vector3 unscaledMousePositin;

		private I_BE2_ProgrammingEnv _programmingEnv;

		private bool primaryKey;

		private bool auxKey;

		private void OnEnable()
		{
			BE2_ExecutionManager.Instance.AddToLateUpdate(HandleZoom);
			BE2_MainEventsManager.Instance.StartListening(BE2EventTypes.OnPrimaryKeyDown, SetPrimaryKeyDown);
			BE2_MainEventsManager.Instance.StartListening(BE2EventTypes.OnPrimaryKeyUp, SetPrimaryKeyUp);
			BE2_MainEventsManager.Instance.StartListening(BE2EventTypes.OnAuxKeyDown, SetAuxKeyDown);
			BE2_MainEventsManager.Instance.StartListening(BE2EventTypes.OnAuxKeyUp, SetAuxKeyUp);
			_programmingEnv = GetComponent<I_BE2_ProgrammingEnv>();
		}

		private void OnDisable()
		{
			BE2_ExecutionManager.Instance?.RemoveFromLateUpdate(HandleZoom);
			BE2_MainEventsManager.Instance.StopListening(BE2EventTypes.OnPrimaryKeyDown, SetPrimaryKeyDown);
			BE2_MainEventsManager.Instance.StopListening(BE2EventTypes.OnPrimaryKeyUp, SetPrimaryKeyUp);
			BE2_MainEventsManager.Instance.StopListening(BE2EventTypes.OnAuxKeyDown, SetAuxKeyDown);
			BE2_MainEventsManager.Instance.StopListening(BE2EventTypes.OnAuxKeyUp, SetAuxKeyUp);
		}

		private void SetPrimaryKeyDown()
		{
			primaryKey = true;
		}

		private void SetPrimaryKeyUp()
		{
			primaryKey = false;
		}

		private void SetAuxKeyDown()
		{
			auxKey = true;
		}

		private void SetAuxKeyUp()
		{
			auxKey = false;
		}

		public void HandleZoom()
		{
			float num = 0f - Input.GetAxis("Mouse ScrollWheel");
			if (num != 0f && !primaryKey && auxKey)
			{
				Zoom(num, BE2_InputManager.Instance.CanvasPointerPosition);
			}
		}

		public void Zoom(float scrollWheel, Vector3 zoomAnchorPosition)
		{
			RectTransform obj = base.transform as RectTransform;
			Vector3[] array = new Vector3[4];
			obj.GetWorldCorners(array);
			if (scrollWheel > 0f && base.transform.localScale.y > minSize)
			{
				float num = Mathf.Clamp(base.transform.localScale.y / zoomRate, minSize, maxSize);
				base.transform.localScale = new Vector3(num, num, 1f);
			}
			else if (scrollWheel < 0f && base.transform.localScale.y < maxSize)
			{
				float num2 = Mathf.Clamp(base.transform.localScale.y * zoomRate, minSize, maxSize);
				base.transform.localScale = new Vector3(num2, num2, 1f);
			}
			unscaledMousePositin = zoomAnchorPosition;
			Vector3[] array2 = new Vector3[4];
			obj.GetWorldCorners(array2);
			Vector3 vector = new Vector3(ConvertValueToNewRange(unscaledMousePositin.x, new Vector2(array[1].x, array[2].x), new Vector2(array2[1].x, array2[2].x)), ConvertValueToNewRange(unscaledMousePositin.y, new Vector2(array[1].y, array[0].y), new Vector2(array2[1].y, array2[0].y)), unscaledMousePositin.z);
			TranslateView(0f - (vector.x - unscaledMousePositin.x), 0f - (vector.y - unscaledMousePositin.y));
		}

		public void ZoomIn()
		{
			RectTransform obj = base.transform.parent as RectTransform;
			Vector3[] array = new Vector3[4];
			obj.GetWorldCorners(array);
			Zoom(-1f, new Vector3((array[1].x + array[2].x) / 2f, (array[1].y + array[0].y) / 2f, base.transform.position.z));
		}

		public void ZoomOut()
		{
			RectTransform obj = base.transform.parent as RectTransform;
			Vector3[] array = new Vector3[4];
			obj.GetWorldCorners(array);
			Zoom(1f, new Vector3((array[1].x + array[2].x) / 2f, (array[1].y + array[0].y) / 2f, base.transform.position.z));
		}

		public void ZoomCenter()
		{
			Vector3 zero = Vector3.zero;
			_programmingEnv.UpdateBlocksList();
			base.transform.localScale = new Vector3(1f, 1f, 1f);
			if (_programmingEnv.BlocksList.Count <= 0)
			{
				return;
			}
			foreach (I_BE2_Block blocks in _programmingEnv.BlocksList)
			{
				RectTransform obj = blocks.Transform as RectTransform;
				Vector3[] array = new Vector3[4];
				obj.GetWorldCorners(array);
				zero += new Vector3((array[1].x + array[2].x) / 2f, (array[1].y + array[0].y) / 2f, blocks.Transform.position.z);
			}
			zero /= (float)_programmingEnv.BlocksList.Count;
			RectTransform obj2 = base.transform.parent as RectTransform;
			Vector3[] array2 = new Vector3[4];
			obj2.GetWorldCorners(array2);
			TranslateView(0f - (zero.x - (array2[1].x + array2[2].x) / 2f), 0f - (zero.y - (array2[1].y + array2[0].y) / 2f));
		}

		private void TranslateView(float x, float y)
		{
			Vector3 position = base.transform.position;
			position.x += x;
			position.y += y;
			base.transform.position = position;
		}

		private float ConvertValueToNewRange(float oldValue, Vector2 oldScale, Vector2 newScale)
		{
			return (oldValue - oldScale.y) * (newScale.x - newScale.y) / (oldScale.x - oldScale.y) + newScale.y;
		}
	}
}
