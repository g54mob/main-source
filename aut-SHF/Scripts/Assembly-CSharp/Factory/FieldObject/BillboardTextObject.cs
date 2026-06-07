using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Factory.FieldObject
{
	public class BillboardTextObject : MonoBehaviour, ITemporaryBillboardCamera, IEventSystemHandler
	{
		private Transform _billboard;

		public TMP_Text textObject;

		private Transform parentCache;

		private void Awake()
		{
		}

		private void Update()
		{
		}

		public void OnChangeCamera(Camera cm)
		{
		}
	}
}
