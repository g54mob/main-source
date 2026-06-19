using System;
using System.Collections.Generic;
using UnityEngine;

namespace Water2D
{
	[Serializable]
	[ExecuteInEditMode]
	public class Reflector : MonoBehaviour
	{
		[SerializeField]
		[HideInInspector]
		public ReflectionPivotSourceMode pivotSourceMode;

		[SerializeField]
		[HideInInspector]
		public WaterCryo<bool> flipX;

		[SerializeField]
		[HideInInspector]
		public Transform customPivot;

		[SerializeField]
		[HideInInspector]
		public WaterCryo<bool> MSP_ReflectionGenerator;

		[SerializeField]
		[HideInInspector]
		public WaterCryo<Vector2> displacement;

		[SerializeField]
		[HideInInspector]
		public WaterCryo<float> additionalTilt;

		[SerializeField]
		[HideInInspector]
		public bool raymarched;

		[SerializeField]
		[HideInInspector]
		public int maxLength;

		[SerializeField]
		[HideInInspector]
		[Range(0f, 1f)]
		public float fadeStrength;

		[SerializeField]
		[HideInInspector]
		public Dictionary<Sprite, Sprite> spritesDictionary;

		[HideInInspector]
		[SerializeField]
		private ReflectionSO _data;

		private ReflectionsSystem rsReference;

		[HideInInspector]
		public ReflectionSO data
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		private void OnEnable()
		{
		}

		public void SetCallbacks()
		{
		}

		private void AlgorithmChanged()
		{
		}

		private void SettingsChanged()
		{
		}

		private Sprite GetRaymarchTexture(Sprite original)
		{
			return null;
		}

		private void Start()
		{
		}

		public void CreateData()
		{
		}

		private Sprite CreateMSPSprite(Sprite org)
		{
			return null;
		}

		private bool IsValid()
		{
			return false;
		}

		public void DeleteData()
		{
		}

		public void UpdateData()
		{
		}

		private void DestroyPlus(UnityEngine.Object obj)
		{
		}

		protected void Awake()
		{
		}

		protected void OnDisable()
		{
		}

		protected void OnDestroy()
		{
		}

		private ReflectionsSystem getRF()
		{
			return null;
		}
	}
}
