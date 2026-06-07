using System;
using TMPro;
using UnityEngine;

namespace Gh.Tk.UI
{
	public class VersionText3DUIView : MonoBehaviour
	{
		[SerializeField]
		private TMP_Text _versionText;

		private void Awake()
		{
		}

		private void OnDestroy()
		{
		}

		private void InvalidateState(object sender, EventArgs e)
		{
		}

		private void InvalidateState()
		{
		}

		private bool ShouldShow()
		{
			return false;
		}
	}
}
