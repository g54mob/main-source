using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers.Powertrain
{
	public class MeshSandwichEngineScript : MeshSandwichScript
	{
		[SerializeField]
		private GameObject _airIntake;

		public bool SuperchargerEnabled { get; set; }

		public override void BuildMeshes()
		{
			base.BuildMeshes();
			if (_airIntake != null)
			{
				Vector3 localPosition = _airIntake.transform.localPosition;
				localPosition.z = base.Length / 2f;
				_airIntake.transform.localPosition = localPosition;
			}
			SuperchargerComponentScript[] componentsInChildren = GetComponentsInChildren<SuperchargerComponentScript>(includeInactive: true);
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				componentsInChildren[i].InitializeComponent(SuperchargerEnabled);
			}
		}

		public override void InitializeMeshes()
		{
			base.InitializeMeshes();
			if (_airIntake != null)
			{
				RegisterRenderers(_airIntake);
			}
		}
	}
}
