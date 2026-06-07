using Assets.Nimbatus.Scripts.Behaviours.Health;
using Assets.Nimbatus.Scripts.GalaxyMap.Boss;
using Assets.Nimbatus.Scripts.Persistence;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.Characters.Behaviours.Bossfights
{
	public class SnakeBossfightBodyCollider : MonoBehaviour
	{
		private SnakeBossfightBodyPart _parent;

		private SnakeBossfightManager _snake;

		private int _dronePartCounter;

		public void Init(SnakeBossfightBodyPart part, SnakeBossfightManager snake)
		{
			_parent = part;
			_snake = snake;
		}

		public void OnTriggerStay(Collider other)
		{
			if (_parent.Attached && other.gameObject.layer == RuntimeGlobals.NimbatusPlayer.gameObject.layer)
			{
				other.gameObject.SendMessage("TakeDamage", new DamageInformation(_snake.CurrentDamage * Time.deltaTime, EDamageReason.Environment), SendMessageOptions.DontRequireReceiver);
			}
		}

		public void OnTriggerEnter(Collider other)
		{
			if (!_parent.Attached)
			{
				return;
			}
			if (other.gameObject.layer == RuntimeGlobals.NimbatusPlayer.gameObject.layer && _dronePartCounter == 0)
			{
				if (!AudioController.IsPlaying(_parent.DamageSoundLoop))
				{
					AudioController.Play(_parent.DamageSoundLoop, base.transform);
				}
				_dronePartCounter++;
			}
			if (_parent.IsHead && other.transform.parent != null && (bool)other.transform.parent.GetComponent<SnakeBossfightSpike>() && Vector3.Angle(_parent.transform.up, other.transform.up) > 90f)
			{
				_snake.Stun(other.transform.position);
			}
		}

		public void OnTriggerExit(Collider other)
		{
			if (_parent.Attached && other.gameObject.layer == RuntimeGlobals.NimbatusPlayer.gameObject.layer)
			{
				_dronePartCounter--;
				if (_dronePartCounter <= 0 && AudioController.IsPlaying(_parent.DamageSoundLoop))
				{
					AudioController.Stop(_parent.DamageSoundLoop);
				}
			}
		}
	}
}
