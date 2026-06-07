using Assets.Scripts.Flight.MapView.Interfaces.Contexts;
using ModApi.Flight.Sim;
using ModApi.Ioc;
using ModApi.State.MapView;
using UnityEngine;
using Vectrosity;

namespace Assets.Scripts.Flight.MapView.Orbits
{
	public class MapCraftOrbitLine : MapOrbitLine
	{
		public static MapCraftOrbitLine Create(IIocContainer ioc, IMapViewContext mapViewContext, IOrbitNode node, MapItemData data, Color color, string name, Camera mapCamera, Material lineMaterial)
		{
			return MapOrbitLine.Create<MapCraftOrbitLine>(ioc, mapViewContext, node, data, color, name, mapCamera, lineMaterial, isSharedMaterial: false);
		}

		public override void OnNewNextNode()
		{
			base.OnNewNextNode();
			UpdateEndColor();
		}

		protected override void OnLineCreated(VectorLine vectrocityLine)
		{
			base.OnLineCreated(vectrocityLine);
			base.LineMaterial.SetColor("_Color", base.Color);
			base.LineMaterial.SetColor("_startColor", base.Color);
			base.LineMaterial.SetInt("_shaderStyle", 1);
			UpdateEndColor();
		}

		private void UpdateEndColor()
		{
			if (base.LineMaterial != null)
			{
				Color value = (base.OrbitInfo.ChainNode?.ListNode.Next)?.Value.OrbitInfo.OrbitColor ?? (base.Color * 0.4f);
				base.LineMaterial.SetColor("_endColor", value);
			}
		}
	}
}
