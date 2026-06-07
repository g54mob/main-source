using UnityEngine;

namespace CompassNavigatorPro
{
	[ExecuteInEditMode]
	public class CompassProFogVolume : MonoBehaviour
	{
		[Range(0f, 1f)]
		[Tooltip("Transparency of the fog of war. A value of 1 means fully opaque fog.")]
		public float alpha;

		[Range(0f, 1f)]
		[Tooltip("Controls the hardness of the border.")]
		public float border;

		[Tooltip("Fog volumes are rendered in ascending order.")]
		public int order;

		private Vector3 oldPos;

		private Vector3 oldScale;

		private float oldAlpha;

		private float oldBorder;

		private int oldOrder;

		private void OnEnable()
		{
			if (!Application.isPlaying)
			{
				ShowFogArea(state: true);
			}
		}

		private void Start()
		{
			if (Application.isPlaying)
			{
				ShowFogArea(state: true);
			}
		}

		private void OnDisable()
		{
			ShowFogArea(state: false);
		}

		private void Update()
		{
			if (order != oldOrder || alpha != oldAlpha || border != oldBorder || base.transform.position != oldPos || base.transform.localScale != oldScale)
			{
				NotifyChanges();
			}
		}

		private void NotifyChanges()
		{
			oldPos = base.transform.position;
			oldScale = base.transform.localScale;
			oldAlpha = alpha;
			oldBorder = border;
			oldOrder = order;
			CompassPro instance = CompassPro.instance;
			if (instance != null)
			{
				instance.UpdateFogOfWar();
			}
		}

		private void ShowFogArea(bool state)
		{
			CompassPro instance = CompassPro.instance;
			if (instance != null)
			{
				Bounds bounds = GetComponent<BoxCollider>().bounds;
				float fogNewAlpha = (state ? alpha : 0f);
				instance.SetFogOfWarAlpha(bounds, fogNewAlpha, border);
			}
		}
	}
}
