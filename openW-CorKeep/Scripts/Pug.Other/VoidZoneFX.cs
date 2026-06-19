using System;
using System.Collections.Generic;
using UnityEngine;

public class VoidZoneFX : MonoBehaviour
{
	[Serializable]
	public class SafeZone
	{
		public float radius = 2f;

		[SerializeField]
		private Transform m_transform;

		public bool enabled
		{
			get
			{
				return m_transform.gameObject.activeInHierarchy;
			}
			set
			{
				m_transform.gameObject.SetActive(value);
			}
		}

		public Vector3 position
		{
			get
			{
				return m_transform.position;
			}
			set
			{
				m_transform.position = value;
			}
		}
	}

	public const int MAX_SAFE_ZONE_COUNT = 8;

	public MeshRenderer renderer;

	public List<SafeZone> safeZones = new List<SafeZone>();

	public float radius = 20f;

	[Range(0f, 1f)]
	public float alpha = 1f;

	private MaterialPropertyBlock m_properties;

	private Vector4[] m_safeZoneParams = new Vector4[8];

	private int m_safeZoneCount;

	private static int _SafeZoneParams = Shader.PropertyToID("_SafeZoneParams");

	private static int _SafeZoneCount = Shader.PropertyToID("_SafeZoneCount");

	private static int _Alpha = Shader.PropertyToID("_Alpha");

	private void Awake()
	{
		m_properties = new MaterialPropertyBlock();
	}

	private void LateUpdate()
	{
		renderer.transform.localScale = new Vector3(radius * 2f, 6f, radius * 2f);
		m_safeZoneCount = 0;
		for (int i = 0; i < safeZones.Count; i++)
		{
			SafeZone safeZone = safeZones[i];
			if (safeZone.enabled)
			{
				if (m_safeZoneCount == 8)
				{
					Debug.LogError($"Too many active safe zones! (max {8})");
					break;
				}
				Vector3 position = safeZone.position;
				m_safeZoneParams[m_safeZoneCount++] = new Vector4(position.x, position.y, position.z, safeZone.radius);
			}
		}
		m_properties.SetVectorArray(_SafeZoneParams, m_safeZoneParams);
		m_properties.SetInt(_SafeZoneCount, m_safeZoneCount);
		m_properties.SetFloat(_Alpha, alpha);
		renderer.SetPropertyBlock(m_properties);
	}
}
