using UnityEngine;

namespace GRP
{
	public class SpringPartView : PartView<SpringPartViewable>
	{
		public BoxVisual bottomBody;

		public BoxVisual topBody;

		public SpringVisual spring;

		public Transform bottom;

		public Transform top;

		protected override void OnViewCreated()
		{
		}

		protected override void OnRender()
		{
		}
	}
}
