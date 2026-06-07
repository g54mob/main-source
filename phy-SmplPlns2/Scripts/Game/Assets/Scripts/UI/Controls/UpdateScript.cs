using System;
using UnityEngine;

namespace Assets.Scripts.UI.Controls
{
	public class UpdateScript : MonoBehaviour
	{
		public event Action MonoBehaviourUpdate;

		protected virtual void Update()
		{
			this.MonoBehaviourUpdate?.Invoke();
		}
	}
}
