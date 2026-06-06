using UnityEngine;

namespace PajamaLlama.Fltsm.UI
{
	public abstract class GameSetupPage : MonoBehaviour
	{
		public bool IsCompleted { get; protected set; }

		public abstract bool Activate();

		public abstract GameSetup Apply(GameSetup gameSetup);

		public virtual void Deactivate()
		{
			base.gameObject.SetActive(value: false);
		}
	}
}
