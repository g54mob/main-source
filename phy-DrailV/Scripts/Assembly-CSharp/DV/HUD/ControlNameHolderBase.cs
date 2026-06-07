using UnityEngine;

namespace DV.HUD
{
	public abstract class ControlNameHolderBase : MonoBehaviour
	{
		public abstract (string value, string unit) GetName();
	}
}
