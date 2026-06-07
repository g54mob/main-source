using UnityEngine;

namespace Lightbug.CharacterControllerPro.Demo
{
	[CreateAssetMenu(menuName = "Character Controller Pro/Demo/Materials/Material Properties")]
	public class MaterialsProperties : ScriptableObject
	{
		[SerializeField]
		private Surface defaultSurface = new Surface();

		[SerializeField]
		private Volume defaultVolume = new Volume();

		[SerializeField]
		private Surface[] surfaces;

		[SerializeField]
		private Volume[] volumes;

		public Surface DefaultSurface => defaultSurface;

		public Volume DefaultVolume => defaultVolume;

		public Surface[] Surfaces => surfaces;

		public Volume[] Volumes => volumes;

		public bool GetSurface(GameObject gameObject, out Surface outputSurface)
		{
			outputSurface = null;
			for (int i = 0; i < surfaces.Length; i++)
			{
				Surface surface = surfaces[i];
				if (gameObject.CompareTag(surface.tagName))
				{
					outputSurface = surface;
					return true;
				}
			}
			return false;
		}

		public bool GetVolume(GameObject gameObject, out Volume outputVolume)
		{
			outputVolume = null;
			for (int i = 0; i < volumes.Length; i++)
			{
				Volume volume = volumes[i];
				if (gameObject.CompareTag(volume.tagName))
				{
					outputVolume = volume;
					return true;
				}
			}
			return false;
		}
	}
}
