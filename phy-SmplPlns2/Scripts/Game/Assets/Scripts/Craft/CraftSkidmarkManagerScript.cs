using Assets.Scripts.Flight.Events;
using Jundroo.Common.Extensions;
using UnityEngine;

namespace Assets.Scripts.Craft
{
	public class CraftSkidmarkManagerScript : MonoBehaviour
	{
		public static void InitializeManager()
		{
			GameObject gameObject = GameObject.Find("SkidContainer");
			if (gameObject == null)
			{
				gameObject = new GameObject("SkidContainer");
				gameObject.isStatic = true;
			}
			gameObject.AddMissingComponent<CraftSkidmarkManagerScript>();
		}

		protected void Awake()
		{
			GameWorld.Instance.FloatingOriginChanged += OnFloatingOriginChanged;
		}

		protected virtual void OnDestroy()
		{
			GameWorld instance = GameWorld.Instance;
			if (instance != null)
			{
				instance.FloatingOriginChanged -= OnFloatingOriginChanged;
			}
		}

		private void OnFloatingOriginChanged(object sender, FloatingOriginChangedEventArgs e)
		{
			base.transform.position += e.Delta;
		}
	}
}
