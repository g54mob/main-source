using System.Collections;
using UnityEngine;

namespace CTS
{
	public class MachineScreenManager : MonoBehaviour
	{
		private EScreenIcon _tmpScreenIcon;

		[SerializeField]
		private Renderer _screenRenderer;

		public IEnumerator SetScreen(EScreenColor _screenColor, EScreenIcon _screenIcon)
		{
			_screenRenderer.material.SetFloat("_screenColor", (float)_screenColor);
			if (_tmpScreenIcon != _screenIcon)
			{
				_tmpScreenIcon = _screenIcon;
				_screenRenderer.material.SetFloat("_screenIcon", (float)_screenIcon);
				if (_screenColor == EScreenColor.Red)
				{
					yield return new WaitForSeconds(3.5f);
					StartCoroutine(SetScreen(EScreenColor.Blue, EScreenIcon.PowerIcon));
				}
				yield return null;
			}
		}
	}
}
