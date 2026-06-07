using ModApi;
using ModApi.Craft.Parts;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers
{
	public class GaugeBaseScript : PartModifierScript<GaugeBaseData>
	{
		private Transform _base;

		private Transform _rim;

		public void UpdateHiddenMeshes()
		{
			if (Game.InFlightScene)
			{
				if (base.Data.HideBase)
				{
					base.PartScript.PartMaterialScript.RemoveRenderer(_base.GetComponent<Renderer>());
				}
				if (base.Data.HideRim)
				{
					base.PartScript.PartMaterialScript.RemoveRenderer(_rim.GetComponent<Renderer>());
				}
			}
			_base.GetComponent<MeshRenderer>().enabled = !base.Data.HideBase;
			_rim.GetComponent<MeshRenderer>().enabled = !base.Data.HideRim;
		}

		public void UpdateScale()
		{
			foreach (AttachPointScript attachPointScript in base.PartScript.AttachPointScripts)
			{
				attachPointScript.AttachPoint.Scale = 0.3f * base.Data.Scale;
			}
			_base.localScale = new Vector3(base.Data.Scale, base.Data.Scale, 1f);
		}

		public void UpdateTrimType()
		{
			base.PartScript.PartMaterialScript.RemoveRenderer(_rim.GetComponent<Renderer>());
			Object.Destroy(_rim.gameObject);
			_rim = (Object.Instantiate(Resources.Load("Craft/Parts/Prefabs/Gauges/" + base.Data.TrimType), _base) as GameObject).transform;
			base.PartScript.PartMaterialScript.AddRenderer(_rim.GetComponent<Renderer>());
			UpdateHiddenMeshes();
		}

		protected override void OnInitialized()
		{
			base.OnInitialized();
			_base = Utilities.FindFirstGameObjectMyselfOrChildren("GaugeBase", base.gameObject).transform;
			_rim = Utilities.FindFirstGameObjectMyselfOrChildren("GaugeTrim", base.gameObject).transform;
			UpdateScale();
			UpdateTrimType();
		}
	}
}
