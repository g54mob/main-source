using UnityEngine;

namespace NSMedieval.Views.Resources
{
	public class CabbageView : PlantMapResourceView
	{
		private Animator anim;

		public override void Dispose()
		{
			anim.enabled = true;
			anim.Play("cabbage chop");
			Dispose(destroyGameObject: false);
		}

		protected override void Start()
		{
			anim = GetComponentInChildren<Animator>();
			base.Start();
		}
	}
}
