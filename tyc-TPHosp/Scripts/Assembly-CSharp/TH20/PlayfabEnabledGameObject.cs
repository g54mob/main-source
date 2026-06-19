using UnityEngine;

namespace TH20
{
	public class PlayfabEnabledGameObject : MonoBehaviour
	{
		[SerializeField]
		private bool _requriesPlayfabEnabled;

		private void Awake()
		{
			if (_requriesPlayfabEnabled != IsPlayfabEnabled())
			{
				Object.Destroy(base.gameObject);
			}
		}

		private bool IsPlayfabEnabled()
		{
			return false;
		}
	}
}
