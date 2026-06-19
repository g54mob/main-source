using Aggro.Core;
using UnityEngine;

namespace Rendering
{
	public class ShaderGlobalsManager : EntityBehaviourBase
	{
		private static readonly int INSIDE = Shader.PropertyToID("_inside");

		public float inside = 1f;

		protected override void OnUpdatePresentation()
		{
			Shader.SetGlobalFloat(INSIDE, inside);
		}

		public void SetGloabls()
		{
			Shader.SetGlobalFloat(INSIDE, inside);
		}
	}
}
