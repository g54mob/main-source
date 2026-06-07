using System.Collections.Generic;
using UnityEngine;

namespace AmazingAssets.AdvancedDissolve
{
	[ExecuteAlways]
	public abstract class AdvancedDissolveController : MonoBehaviour
	{
		public AdvancedDissolveKeywords.GlobalControlID globalControlID;

		public List<Material> materials;

		protected virtual void OnDestroy()
		{
		}

		protected virtual void Awake()
		{
		}

		protected virtual void Update()
		{
		}

		public abstract void ForceUpdateShaderData();

		public abstract void ResetShaderData();

		public void AddMaterialsFromSelection(GameObject[] selection)
		{
		}

		public void AddMaterial(Material material)
		{
		}
	}
}
