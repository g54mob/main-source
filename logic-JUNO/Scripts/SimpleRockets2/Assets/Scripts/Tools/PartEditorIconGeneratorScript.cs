using UnityEngine;

namespace Assets.Scripts.Tools
{
	public class PartEditorIconGeneratorScript : MonoBehaviour
	{
		private void Start()
		{
			PartViewerScript.Create(createPartShaderScript: true).TakeAllPartPictures(retakeExisting: true, destroySelfWhenComplete: true);
		}
	}
}
