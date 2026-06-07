using UnityEngine;

namespace Assets.Scripts.Craft.Parts
{
	public interface IPartCollisionHandler
	{
		bool OnCollision(PartScript partScript, Collision collision, in ContactPoint contactPoint);
	}
}
