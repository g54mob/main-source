using System.Reflection;
using UnityEngine;
using UnityEngine.UI;

namespace GUPS.EasyPerformanceMonitor.Renderer
{
	[Obfuscation(Exclude = true)]
	public abstract class ASingleGraphRenderer : AGraphRenderer
	{
		[SerializeField]
		private Image legendImage;

		public Image LegendImage => legendImage;
	}
}
