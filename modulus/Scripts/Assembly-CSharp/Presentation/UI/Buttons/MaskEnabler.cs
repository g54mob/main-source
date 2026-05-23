using UnityEngine;

namespace Presentation.UI.Buttons
{
	public class MaskEnabler : MonoBehaviour
	{
		[SerializeField]
		private GameObject _mask;

		public bool IsActive
		{
			get
			{
				return _mask.activeSelf;
			}
			set
			{
				_mask.SetActive(value);
			}
		}
	}
}
