using UnityEngine;

namespace Assets.Behaviour.Frame.Parts
{
	public class T12CasingPlate : MonoBehaviour
	{
		[SerializeField]
		private SpriteRenderer _brand;

		public bool Stamped => _brand.gameObject.activeSelf;

		public void Stamp(float x)
		{
			_brand.transform.position = new Vector3(x, _brand.transform.position.y, _brand.transform.position.z);
			_brand.gameObject.SetActive(value: true);
		}
	}
}
