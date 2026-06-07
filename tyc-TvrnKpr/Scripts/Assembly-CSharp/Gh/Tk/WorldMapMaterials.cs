using System.Collections.Generic;
using UnityEngine;

namespace Gh.Tk
{
	[RequireComponent(typeof(MeshRenderer))]
	public class WorldMapMaterials : MonoBehaviour
	{
		public bool revealThis;

		public Gradient borderGradient;

		private Material _borderMat;

		private float _currentBorderValue;

		private Material _roadMaterial;

		private List<Material> _mats;

		private List<Color> _revealedColors;

		private List<Color> _unrevealedColors;

		public Color regionUnrevealMultiplyColor;

		public List<GameObject> _objectsToReveal;

		public GameObject filler;

		private void Start()
		{
		}

		private void Update()
		{
		}

		private void GetRegionMatsAndColors()
		{
		}

		private void UnrevealFiller()
		{
		}

		public void UnrevealRegion()
		{
		}

		public void RevealRegion()
		{
		}

		public void RevealRoad()
		{
		}

		public void UpdateBorderColor(float colorLerpValue)
		{
		}
	}
}
