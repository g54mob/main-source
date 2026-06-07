using UnityEngine;

namespace Simulator.GameWorld
{
	public abstract class CharacterComponent : MonoBehaviour
	{
		[SerializeField]
		protected Character m_character;

		protected virtual void OnEnable()
		{
		}

		protected virtual void OnDisable()
		{
		}
	}
}
