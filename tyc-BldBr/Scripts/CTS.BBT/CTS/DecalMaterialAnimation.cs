using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace CTS
{
	public class DecalMaterialAnimation : MonoBehaviour
	{
		private DecalProjector _decalProjector;

		[SerializeField]
		[Range(0f, 1f)]
		private float _opacity;

		private void Awake()
		{
			_decalProjector = GetComponent<DecalProjector>();
			if (!_decalProjector)
			{
				_decalProjector = GetComponentInChildren<DecalProjector>();
			}
		}

		private void Update()
		{
			_decalProjector.fadeFactor = _opacity;
		}
	}
}
