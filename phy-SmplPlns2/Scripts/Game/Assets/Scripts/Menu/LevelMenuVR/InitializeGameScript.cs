using UnityEngine;

namespace Assets.Scripts.Menu.LevelMenuVR
{
	public class InitializeGameScript : MonoBehaviour
	{
		protected virtual void Awake()
		{
			Game.Instance.ToString();
		}
	}
}
