using UnityEngine;

namespace ModApi.Craft.Parts
{
	public class DepthMaskScript : MonoBehaviour
	{
		protected virtual void Start()
		{
			if (Game.InDesignerScene)
			{
				base.gameObject.layer = 13;
			}
		}
	}
}
