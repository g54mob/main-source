using UnityEngine;

namespace MagicaCloth2
{
	[AddComponentMenu("MagicaCloth2/MagicaSphereCollider")]
	[HelpURL("https://magicasoft.jp/en/mc2_spherecollidercomponent/")]
	public class MagicaSphereCollider : ColliderComponent
	{
		public override ColliderManager.ColliderType GetColliderType()
		{
			return default(ColliderManager.ColliderType);
		}

		public override void DataValidate()
		{
		}

		public void SetSize(float radius)
		{
		}
	}
}
