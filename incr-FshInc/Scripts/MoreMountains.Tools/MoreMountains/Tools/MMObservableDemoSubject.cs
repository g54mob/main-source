using UnityEngine;

namespace MoreMountains.Tools
{
	[AddComponentMenu("")]
	public class MMObservableDemoSubject : MonoBehaviour
	{
		public MMObservable<float> PositionX;

		protected virtual void Update()
		{
			PositionX.Value = base.transform.position.x;
		}
	}
}
