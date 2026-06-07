using UnityEngine;

namespace Assets.Nimbatus.GUI.DroneWorkshop.Scripts
{
	public class FlipImage : MonoBehaviour
	{
		public UITexture Image;

		public bool Horizonzal;

		public void OnClick()
		{
			if (Image.flip == UIBasicSprite.Flip.Nothing)
			{
				Image.flip = (Horizonzal ? UIBasicSprite.Flip.Horizontally : UIBasicSprite.Flip.Vertically);
			}
			else
			{
				Image.flip = UIBasicSprite.Flip.Nothing;
			}
		}
	}
}
