using UnityEngine;

namespace Brewery.Controls3D
{
	public class TabButton3D : MonoBehaviour
	{
		[SerializeField]
		private Renderer buttonRenderer;

		[SerializeField]
		private Color activeColor;

		[SerializeField]
		private Color inactiveColor;

		private MaterialPropertyBlock propBlock;

		private void Awake()
		{
		}

		public void SetActiveState(bool active)
		{
		}

		private void OnDrawGizmosSelected()
		{
		}
	}
}
