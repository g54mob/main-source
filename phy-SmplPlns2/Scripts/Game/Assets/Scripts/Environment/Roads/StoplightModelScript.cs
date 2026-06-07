using UnityEngine;

namespace Assets.Scripts.Environment.Roads
{
	public class StoplightModelScript : MonoBehaviour
	{
		[SerializeField]
		private MeshRenderer _lightGreen;

		[SerializeField]
		private MeshRenderer _lightRed;

		[SerializeField]
		private MeshRenderer _lightYellow;

		[SerializeField]
		private Material _materialOff;

		[SerializeField]
		private Material _materialOn;

		public void ChangeLight(StoplightType lightType)
		{
			_lightRed.sharedMaterial = ((lightType == StoplightType.Red) ? _materialOn : _materialOff);
			_lightGreen.sharedMaterial = ((lightType == StoplightType.Green) ? _materialOn : _materialOff);
			_lightYellow.sharedMaterial = ((lightType == StoplightType.Yellow) ? _materialOn : _materialOff);
		}
	}
}
