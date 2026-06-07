using System.Linq;
using UnityEngine;

namespace TrueClouds
{
	[ExecuteInEditMode]
	internal class CloudPointLight : MonoBehaviour
	{
		public float Start;

		public float Range = 10f;

		public Color Color = Color.white;

		public float ShadowIntensity = 0.2f;

		private static Shader SHADER = null;

		private static int START_ID = -1;

		private static int RANGE_ID = -1;

		private static int COLOR_ID = -1;

		private static int SHADOW_INTENSITY_ID = -1;

		private Material _material;

		private Transform _transform;

		private GameObject _light;

		private Transform _lightTransform;

		private void OnValidate()
		{
			ValidateHasGoodLayer();
			ValidateDistances();
		}

		private void ValidateHasGoodLayer()
		{
			CloudCamera[] components = GetComponents<CloudCamera>();
			if (components.Length != 0 && components.All((CloudCamera camera) => ((int)camera.LightMask & base.gameObject.layer) == 0))
			{
				Debug.LogWarning("This light has a layer that is not rendered by any of the Cloud Cameras", base.gameObject);
			}
		}

		private void ValidateDistances()
		{
			Start = Mathf.Max(0f, Start);
			Range = Mathf.Max(Range, Start);
		}

		private void Awake()
		{
			if (SHADER == null)
			{
				InitShaderAndIDs();
			}
			_transform = base.transform;
			_light = GameObject.CreatePrimitive(PrimitiveType.Sphere);
			_light.layer = base.gameObject.layer;
			_light.hideFlags = HideFlags.HideAndDontSave;
			_material = new Material(SHADER);
			_light.GetComponent<Renderer>().sharedMaterial = _material;
			_lightTransform = _light.transform;
		}

		private void OnDisable()
		{
			_light.SetActive(value: false);
		}

		private void OnEnable()
		{
			_light.SetActive(value: true);
		}

		private void OnDestroy()
		{
			if (Application.isEditor && !Application.isPlaying)
			{
				Object.DestroyImmediate(_light);
			}
			else
			{
				Object.Destroy(_light);
			}
		}

		private void Update()
		{
			if (SHADER == null)
			{
				InitShaderAndIDs();
			}
			_material.SetFloat(START_ID, Start);
			_material.SetFloat(RANGE_ID, Range);
			_material.SetColor(COLOR_ID, Color);
			_material.SetFloat(SHADOW_INTENSITY_ID, ShadowIntensity);
			float num = Range * 2f * 1.1f;
			_lightTransform.localScale = new Vector3(num, num, num);
			_lightTransform.position = _transform.position;
		}

		private void InitShaderAndIDs()
		{
			SHADER = Shader.Find("Hidden/Clouds/PointLight");
			START_ID = Shader.PropertyToID("_Start");
			RANGE_ID = Shader.PropertyToID("_MaxDistance");
			COLOR_ID = Shader.PropertyToID("_TintColor");
			SHADOW_INTENSITY_ID = Shader.PropertyToID("_ShadowIntensity");
		}

		private void OnDrawGizmosSelected()
		{
			Color yellow = Color.yellow;
			yellow.a = 0.7f;
			Gizmos.color = yellow;
			Gizmos.DrawSphere(base.transform.position, Start);
			yellow.a = 0.3f;
			Gizmos.color = yellow;
			Gizmos.DrawSphere(base.transform.position, Range);
		}
	}
}
