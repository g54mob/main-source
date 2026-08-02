using UnityEngine;

namespace JUTPS.Utilities
{
	[AddComponentMenu("JU TPS/Utilities/Damage Trigger")]
	public class JUDamageTrigger : MonoBehaviour
	{
		[SerializeField]
		private float Damage = 5f;

		[SerializeField]
		private string CharacterTag;

		private void OnTriggerEnter(Collider other)
		{
			Debug.Log("test");
			JUHealth component2;
			if (CharacterTag != "")
			{
				if (other.gameObject.CompareTag(CharacterTag) && other.TryGetComponent<JUHealth>(out var component))
				{
					component.DoDamage(Damage);
				}
			}
			else if (other.TryGetComponent<JUHealth>(out component2))
			{
				component2.DoDamage(Damage);
			}
		}
	}
}
