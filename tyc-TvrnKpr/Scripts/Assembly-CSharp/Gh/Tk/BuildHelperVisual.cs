using System.Collections.Generic;
using UnityEngine;

namespace Gh.Tk
{
	public class BuildHelperVisual : MonoBehaviour
	{
		[SerializeField]
		private List<MeshRenderer> _meshRenderers;

		[field: SerializeField]
		public InputMode[] ValidModes { get; set; }

		private void Start()
		{
		}

		private void OnDestroy()
		{
		}

		private void OnEnable()
		{
		}

		private void OnCurrentModeChanged(object sender, EventArgs<InputMode> e)
		{
		}

		private void RefreshState()
		{
		}
	}
}
