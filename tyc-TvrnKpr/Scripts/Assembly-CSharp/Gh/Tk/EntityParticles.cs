using UnityEngine;

namespace Gh.Tk
{
	[DisallowMultipleComponent]
	public class EntityParticles : MonoBehaviour
	{
		public string particlePrefabName;

		public Transform offset;

		private MeshRenderer _meshRenderer;

		private void Start()
		{
		}

		private void OnDestroy()
		{
		}

		private void OnCurrentModeChanged(object sender, EventArgs<InputMode> e)
		{
		}
	}
}
