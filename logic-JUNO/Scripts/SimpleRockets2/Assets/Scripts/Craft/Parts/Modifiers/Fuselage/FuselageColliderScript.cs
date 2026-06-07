using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers.Fuselage
{
	public class FuselageColliderScript : MonoBehaviour
	{
		[SerializeField]
		private string _designerMesh = "Default";

		[SerializeField]
		private string _flightMesh = "Default";

		public AdaptiveMesh AdaptiveMesh { get; private set; }

		public void OnFuselageInitialized()
		{
			string text = _designerMesh;
			if (text == null || text == "Default")
			{
				text = "Collider-Solid-Design";
			}
			string text2 = _flightMesh;
			if (text2 == null || text2 == "Default")
			{
				text2 = "Collider-Solid-Flight";
			}
			string text3 = text2;
			if (Game.InDesignerScene)
			{
				text3 = text;
			}
			Mesh colliderMesh = Game.Instance.FuselageMeshes.GetColliderMesh(text3);
			MeshFilter component = base.gameObject.GetComponent<MeshFilter>();
			component.mesh = colliderMesh;
			MeshCollider component2 = base.gameObject.GetComponent<MeshCollider>();
			AdaptiveMesh = new AdaptiveMesh(component, anchorsEnabled: false, tileableTexture: false, useSimpleRadialScaling: false, component2);
		}
	}
}
