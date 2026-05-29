using NaughtyAttributes;
using UnityEngine;

namespace CTS
{
	public class TEMPHeadModifier : MonoBehaviour
	{
		[SerializeField]
		private Renderer[] _renderers;

		public Renderer[] Renderers => _renderers;

		[Button(null, EButtonEnableMode.Always)]
		private void UpdateRenderers()
		{
			_renderers = GetComponentsInChildren<Renderer>();
		}
	}
}
