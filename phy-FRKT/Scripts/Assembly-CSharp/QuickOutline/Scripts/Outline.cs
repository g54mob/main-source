using System;
using System.Collections.Generic;
using UnityEngine;

namespace QuickOutline.Scripts
{
	[DisallowMultipleComponent]
	public class Outline : MonoBehaviour
	{
		public enum Mode
		{
			OutlineAll = 0,
			OutlineVisible = 1,
			OutlineHidden = 2,
			OutlineAndSilhouette = 3,
			SilhouetteOnly = 4
		}

		[Serializable]
		private class ListVector3
		{
			public List<Vector3> data;
		}

		private static HashSet<Mesh> pdv;

		[SerializeField]
		private Mode outlineMode;

		[SerializeField]
		private Color outlineColor;

		[SerializeField]
		[Range(0f, 10f)]
		private float outlineWidth;

		[SerializeField]
		private bool precomputeOutline;

		[SerializeField]
		[HideInInspector]
		private List<Mesh> bakeKeys;

		[SerializeField]
		[HideInInspector]
		private List<ListVector3> bakeValues;

		private Renderer[] pdw;

		private Material pdx;

		private Material pdy;

		private bool pdz;

		public Mode wtd
		{
			get
			{
				return default(Mode);
			}
			set
			{
			}
		}

		public Color wte
		{
			get
			{
				return default(Color);
			}
			set
			{
			}
		}

		public float wtf
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		private void Awake()
		{
		}

		private void OnEnable()
		{
		}

		private void OnValidate()
		{
		}

		private void Update()
		{
		}

		private void OnDisable()
		{
		}

		private void OnDestroy()
		{
		}

		private void czn()
		{
		}

		private void czo()
		{
		}

		private List<Vector3> czp(Mesh a)
		{
			return null;
		}

		private void czq(Mesh a, Material[] b)
		{
		}

		private void czr()
		{
		}
	}
}
