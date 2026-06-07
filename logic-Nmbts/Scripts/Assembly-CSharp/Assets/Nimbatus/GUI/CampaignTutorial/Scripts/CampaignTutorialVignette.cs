using System.Collections;
using Assets.Nimbatus.Scripts.Campaign;
using UnityEngine;

namespace Assets.Nimbatus.GUI.CampaignTutorial.Scripts
{
	public class CampaignTutorialVignette : MonoBehaviour
	{
		public UITexture Vignette;

		public BoxCollider TopCollider;

		public BoxCollider RightCollider;

		public BoxCollider BottomCollider;

		public BoxCollider LeftCollider;

		private Vector2 _currentSize;

		private Material _vigMat;

		private Camera _cam;

		public void Awake()
		{
			_vigMat = new Material(Vignette.material);
			Vignette.material = _vigMat;
			SetActive(false);
		}

		public void SetActive(bool active)
		{
			StopAllCoroutines();
			if (active)
			{
				Vignette.GetComponent<TweenAlpha>().PlayForward();
			}
			else
			{
				Vignette.GetComponent<TweenAlpha>().PlayReverse();
			}
			TopCollider.enabled = active;
			RightCollider.enabled = active;
			BottomCollider.enabled = active;
			LeftCollider.enabled = active;
		}

		public void Init(CampaignTutorialVignetteSetting setting, Camera cam)
		{
			_cam = cam;
			SetActive(true);
			_currentSize = setting.VignetteCutoutSize;
			switch (setting.VignetteCutoutTarget)
			{
			case ETutorialPositionTarget.Absolute:
				StartCoroutine(AttachVignette(setting.VignetteCutoutPosition, setting));
				break;
			case ETutorialPositionTarget.UiTransform:
				StartCoroutine(AttachVignette(setting.VignetteCutoutUiTransform, setting));
				break;
			}
		}

		public IEnumerator LerpSize(Vector2 target)
		{
			Vector2 startSize = _currentSize;
			float t = 0f;
			while (t < 1f)
			{
				t += Time.deltaTime / 0.6f;
				_currentSize = Vector2.Lerp(startSize, target, t);
				yield return null;
			}
			_currentSize = target;
		}

		public IEnumerator AttachVignette(Vector3 pos, CampaignTutorialVignetteSetting setting)
		{
			while (true)
			{
				SetVignette(pos, setting);
				yield return null;
			}
		}

		public IEnumerator AttachVignette(Transform tr, CampaignTutorialVignetteSetting setting)
		{
			Vector3 zero = Vector3.zero;
			Vector3 prevPos = zero;
			while (true)
			{
				zero = base.transform.parent.InverseTransformPoint(tr.position);
				if (zero != prevPos)
				{
					prevPos = zero;
					SetVignette(zero, setting);
				}
				yield return null;
			}
		}

		public void SetVignette(Vector3 pos, CampaignTutorialVignetteSetting setting)
		{
			Vector3 vector = pos + new Vector3(0f, _currentSize.y / 2f, 0f);
			Vector3 vector2 = pos + new Vector3(_currentSize.x / 2f, 0f, 0f);
			Vector3 vector3 = pos - new Vector3(0f, _currentSize.y / 2f, 0f);
			Vector3 vector4 = pos - new Vector3(_currentSize.x / 2f, 0f, 0f);
			Vector3 vector5 = base.transform.InverseTransformPoint(_cam.ViewportToWorldPoint(new Vector3(0.5f, 1f, 0f)));
			Vector3 vector6 = base.transform.InverseTransformPoint(_cam.ViewportToWorldPoint(new Vector3(1f, 0.5f, 0f)));
			Vector3 vector7 = base.transform.InverseTransformPoint(_cam.ViewportToWorldPoint(new Vector3(0.5f, 0f, 0f)));
			Vector3 vector8 = base.transform.InverseTransformPoint(_cam.ViewportToWorldPoint(new Vector3(0f, 0.5f, 0f)));
			float magnitude = (vector6 - vector8).magnitude;
			float magnitude2 = (vector5 - vector7).magnitude;
			Vector3 vector9 = vector - vector5;
			TopCollider.center = vector5 + new Vector3(0f, vector9.y / 2f, 0f);
			TopCollider.size = new Vector3(magnitude, setting.BlockAll ? magnitude2 : Mathf.Abs(vector9.y), 10f);
			Vector3 vector10 = vector2 - vector6;
			RightCollider.center = vector6 + new Vector3(vector10.x / 2f, 0f, 0f);
			RightCollider.size = new Vector3(setting.BlockAll ? magnitude : Mathf.Abs(vector10.x), magnitude2, 10f);
			Vector3 vector11 = vector3 - vector7;
			BottomCollider.center = vector7 + new Vector3(0f, vector11.y / 2f, 0f);
			BottomCollider.size = new Vector3(magnitude, setting.BlockAll ? magnitude2 : Mathf.Abs(vector11.y), 10f);
			Vector3 vector12 = vector4 - vector8;
			LeftCollider.center = vector8 + new Vector3(vector12.x / 2f, 0f, 0f);
			LeftCollider.size = new Vector3(setting.BlockAll ? magnitude : Mathf.Abs(vector12.x), magnitude2, 10f);
			vector = _cam.WorldToViewportPoint(base.transform.TransformPoint(vector));
			vector2 = _cam.WorldToViewportPoint(base.transform.TransformPoint(vector2));
			vector3 = _cam.WorldToViewportPoint(base.transform.TransformPoint(vector3));
			vector4 = _cam.WorldToViewportPoint(base.transform.TransformPoint(vector4));
			_vigMat.SetFloat("_Top", vector.y);
			_vigMat.SetFloat("_Right", vector2.x);
			_vigMat.SetFloat("_Bottom", vector3.y);
			_vigMat.SetFloat("_Left", vector4.x);
			_vigMat.SetFloat("_Feather", setting.VignetteFeather);
			Vignette.enabled = false;
			Vignette.enabled = true;
		}
	}
}
