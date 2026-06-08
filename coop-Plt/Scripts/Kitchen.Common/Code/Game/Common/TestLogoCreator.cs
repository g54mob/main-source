using Kitchen;
using LogoMaker;
using UnityEngine;

namespace Code.Game.Common
{
	public class TestLogoCreator : MonoBehaviour
	{
		public CreateTextLayout LayoutCreator;

		public Texture2D Image;

		public void Start()
		{
			LayoutCreator.Test("Seize-a Salad", playful: false);
			base.transform.localRotation = Quaternion.LookRotation(Vector3.down, Vector3.forward);
			base.transform.localScale = Vector3.one * 0.2f;
			Image = Snapshot.RenderToTexture(512, 512, base.gameObject, 0.5f, 0.5f).Snapshot;
			Shader.SetGlobalTexture("_RestaurantLogo", Image);
		}
	}
}
