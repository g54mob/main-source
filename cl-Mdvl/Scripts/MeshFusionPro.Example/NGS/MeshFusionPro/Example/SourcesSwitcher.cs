using UnityEngine;
using UnityEngine.UI;

namespace NGS.MeshFusionPro.Example
{
	public class SourcesSwitcher : MonoBehaviour
	{
		[SerializeField]
		private Text _sourcesEnabledText;

		[SerializeField]
		private Text _sourcesDisabledText;

		private bool _sourcesEnabled = true;

		private void LateUpdate()
		{
			if (SourcesList.UpdatedDirty)
			{
				ToggleSources(_sourcesEnabled);
				SourcesList.UpdatedDirty = false;
			}
			if (Input.GetKeyDown(KeyCode.Tab))
			{
				_sourcesEnabled = !_sourcesEnabled;
				ToggleSources(_sourcesEnabled);
			}
		}

		private void ToggleSources(bool enabled)
		{
			foreach (MeshFusionSource source in SourcesList.Sources)
			{
				if ((bool)source)
				{
					ToggleSource(source, enabled);
				}
			}
			foreach (MeshRenderer combinedObject in SourcesList.CombinedObjects)
			{
				combinedObject.enabled = !enabled;
			}
			_sourcesEnabledText.enabled = enabled;
			_sourcesDisabledText.enabled = !enabled;
		}

		private void ToggleSource(MeshFusionSource source, bool enabled)
		{
			if (source is LODMeshFusionSource)
			{
				source.GetComponent<LODGroup>().enabled = enabled;
				MeshRenderer[] componentsInChildren = source.GetComponentsInChildren<MeshRenderer>();
				for (int i = 0; i < componentsInChildren.Length; i++)
				{
					componentsInChildren[i].enabled = enabled;
				}
			}
			else
			{
				source.GetComponent<MeshRenderer>().enabled = enabled;
			}
		}
	}
}
