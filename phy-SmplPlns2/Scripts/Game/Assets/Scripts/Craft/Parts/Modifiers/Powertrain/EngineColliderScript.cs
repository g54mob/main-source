using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers.Powertrain
{
	public class EngineColliderScript : MonoBehaviour
	{
		public void UpdateCollider(MeshSandwichScript meshSandwich)
		{
			Vector3 localScale = base.transform.localScale;
			localScale.z = meshSandwich.Length;
			base.transform.localScale = localScale;
		}
	}
}
