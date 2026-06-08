using UnityEngine;

namespace Michsky.UI.ModernUIPack
{
	public class UIElementInFront : MonoBehaviour
	{
		private void Start()
		{
			base.transform.SetAsLastSibling();
		}
	}
}
