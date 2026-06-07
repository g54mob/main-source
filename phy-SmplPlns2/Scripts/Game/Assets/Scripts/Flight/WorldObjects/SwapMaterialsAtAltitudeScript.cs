using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Flight.WorldObjects
{
	public class SwapMaterialsAtAltitudeScript : MonoBehaviour
	{
		private bool? _above;

		[SerializeField]
		private float _altitudeThreshold = 100f;

		private Transform _cameraTransform;

		private Coroutine _checkAltitudeCoroutine;

		[SerializeField]
		private Material[] _materialsAbove;

		[SerializeField]
		private Material[] _materialsBelow;

		[SerializeField]
		private MeshRenderer _renderer;

		protected IEnumerator CheckAltitudeRoutine()
		{
			if (_cameraTransform == null)
			{
				Debug.LogError("SwapMaterialsAtAltitudeScript: Camera Transform is null. Coroutine cannot run.", this);
				yield break;
			}
			while (true)
			{
				yield return new WaitForSecondsRealtime(0.5f);
				UpdateMaterialsBasedOnAltitude();
			}
		}

		protected void OnDisable()
		{
			if (_checkAltitudeCoroutine != null)
			{
				StopCoroutine(_checkAltitudeCoroutine);
				_checkAltitudeCoroutine = null;
			}
		}

		protected void OnEnable()
		{
			if (_cameraTransform == null)
			{
				_cameraTransform = FlightSceneScript.Instance.CameraScript.CameraTransform;
			}
			if (_cameraTransform != null)
			{
				UpdateMaterialsBasedOnAltitude(forceUpdate: true);
			}
			else
			{
				Debug.LogWarning("SwapMaterialsAtAltitudeScript: Camera Transform not found on Enable.", this);
			}
			if (_checkAltitudeCoroutine == null)
			{
				_checkAltitudeCoroutine = StartCoroutine(CheckAltitudeRoutine());
			}
		}

		private void SetMaterials(Material[] materials)
		{
			if (_renderer != null)
			{
				_renderer.materials = materials;
			}
			else
			{
				Debug.LogWarning("SwapMaterialsAtAltitudeScript: Renderer is not assigned.", this);
			}
		}

		private void UpdateMaterialsBasedOnAltitude(bool forceUpdate = false)
		{
			if (_cameraTransform == null)
			{
				return;
			}
			bool flag = _cameraTransform.position.y > base.transform.position.y + _altitudeThreshold;
			if (forceUpdate || flag != _above)
			{
				_above = flag;
				if (flag)
				{
					SetMaterials(_materialsAbove);
				}
				else
				{
					SetMaterials(_materialsBelow);
				}
			}
		}
	}
}
