using System.Collections.Generic;
using AmazingAssets.AdvancedDissolve;
using UnityEngine;

namespace Gh.Tk.UI.Dialogs
{
	public class DissolveArea3DUIView : MonoBehaviour
	{
		public enum DissolveType
		{
			Dialog1 = 0,
			Dialog2 = 1,
			Dialog3 = 2,
			StatusBar = 3,
			Global = 4
		}

		public DissolveType dissolveType;

		private AdvancedDissolveGeometricCutoutController _cutoutController;

		private AdvancedDissolvePropertiesController _propertiesController;

		private AdvancedDissolveKeywordsController _dissolveKeywordsController;

		[Header("Animation")]
		public bool animateMap1;

		public Vector3 scrollSpeedMap1;

		private void Awake()
		{
		}

		private void RefreshReferences()
		{
		}

		public void AddMaterials(IEnumerable<Material> concat)
		{
		}

		private void OnEnable()
		{
		}

		private void OnValidate()
		{
		}

		private void LateUpdate()
		{
		}

		private void EnsureCorrectSettings()
		{
		}

		private void CollectMaterials()
		{
		}

		private void UpdateShaderData()
		{
		}

		private void UpdateGlobalControlId()
		{
		}

		[ContextMenu("Clear Materials")]
		private void CLearMaterials()
		{
		}

		private void CleanMaterialCache()
		{
		}

		public void AddMaterial(Material material)
		{
		}

		private void UpdateAnimation(float deltaTime)
		{
		}
	}
}
