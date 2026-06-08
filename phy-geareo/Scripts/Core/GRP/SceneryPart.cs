using Rhizomatic.ImUI;
using Rhizomatic.Reactive;
using Rhizomatic.Utility;
using UnityEngine.SceneManagement;

namespace GRP
{
	public class SceneryPart : Part<SceneryPartConfig>
	{
		public StateList<SceneryTarget> targets;

		private JsonData data;

		protected override PartViewable DoCreateViewable()
		{
			return null;
		}

		public override void OnContext()
		{
		}

		public override void OnContextDispose()
		{
		}

		private void OnSceneChanged()
		{
		}

		public override void OnExpositorUI(ImUIBuilder ui)
		{
		}

		protected override void Save(JsonData data)
		{
		}

		protected override void Load(JsonData data)
		{
		}

		protected override void LoadDiff(JsonData data)
		{
		}

		public void OnSceneReady(Scene scene)
		{
		}

		public void FetchTargets()
		{
		}

		private void LoadTargets()
		{
		}
	}
}
