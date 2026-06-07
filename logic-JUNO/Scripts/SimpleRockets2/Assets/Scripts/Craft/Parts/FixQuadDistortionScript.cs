using UnityEngine;

namespace Assets.Scripts.Craft.Parts
{
	public class FixQuadDistortionScript : MonoBehaviour
	{
		protected virtual void Start()
		{
			Debug.LogError("The FixQuadDistortionScript is now deprecated. Please use the PartModelImportData antiDistortion flag.");
		}
	}
}
