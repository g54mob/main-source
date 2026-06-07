using UnityEngine;

namespace UMA.Examples
{
	[RequireComponent(typeof(UMASimpleLOD))]
	public class LODDisplay : MonoBehaviour
	{
		public GameObject LODDisplayPrefab;

		private TextMesh _lodDisplay;

		private int _lastSetLevel;

		private Transform _cameraTransform;

		private UMASimpleLOD _simpleLOD;

		public void Start()
		{
		}

		private void Update()
		{
		}
	}
}
