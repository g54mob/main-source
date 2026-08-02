using Rhizomatic;
using Rhizomatic.Reactive;
using UnityEngine;

namespace GRP
{
	public class ProjectFileItemView : View<ProjectFileItemViewable>
	{
		public RawImageMember thumbnail;

		public Texture loadingTexture;

		protected override void OnRender()
		{
		}
	}
}
